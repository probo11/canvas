using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace canvas
{
    class MakeGroup : Command
    {
        public void Execute()
        {
            Point p = new Point();
            p.X = -1;
            p.Y = -1;
            Group g = new Group(p, 0, 0, true);

            if (Singleton.getSelectedList().Count > 0)
            {
                foreach (var item in Singleton.getSelectedList())
                {
                    g.Add(item);
                    item.SetParent(g);
                }

                Singleton.ClearSelectedList();
                Singleton.AddToDrawnShapes(g);
            }
        }

        public void Undo()
        {
            //
        }
    }
}

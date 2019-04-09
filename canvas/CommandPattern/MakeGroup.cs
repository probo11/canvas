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
            Point p = new Point
            {
                X = 10000,
                Y = 10000
            };
            Group g = new Group(p, 0, 0);
            int tx = 0, ty = 0;
            if (Singleton.getSelectedList().Count > 0)
            {
                foreach (var item in Singleton.getSelectedList())
                {
                    g.Add(item);
                    item.SetParent(g);
                    Singleton.RemoveFromDrawnShapes(item);

                    if (item.GetX() < g.GetX())
                    {
                        g.SetX(item.GetX());
                    }
                    if (item.GetY() < g.GetY())
                    {
                        g.SetY(item.GetY());
                    }

                    if (tx < item.GetX())
                    {
                        tx = item.GetX();
                        g.SetWidth(Math.Abs(item.GetX() + item.GetWidth()));
                    }
                    if (ty < item.GetY())
                    {
                        ty = item.GetY();
                        g.SetHeight(Math.Abs(item.GetY() + item.GetHeight()));
                    }
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
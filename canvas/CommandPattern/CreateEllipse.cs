using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class CreateEllipse : Command
    {
        Ellipse e;

        public CreateEllipse(Ellipse e)
        {
            this.e = e;
        }

        public void Execute()
        {
            Singleton.AddToDrawnShapes(e);
            Singleton.AddAction(this);
        }

        public void Undo()
        {
            Singleton.RemoveFromDrawnShapes(e);
            Singleton.RemoveFromSelectedList(e);
            Singleton.RemoveAction(this);
        }
    }
}

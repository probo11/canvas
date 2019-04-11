using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class CreateFigure : ICommand
    {
        Figure f;

        public CreateFigure(Figure f)
        {
            this.f = f;
        }

        public void Execute()
        {
            Singleton.AddToDrawnShapes(f);
            Singleton.AddAction(this);
        }

        public void Undo()
        {
            Singleton.RemoveFromDrawnShapes(f);
            Singleton.RemoveFromSelectedList(f);
            Singleton.RemoveAction(this);
        }
    }
}

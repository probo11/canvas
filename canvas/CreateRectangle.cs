using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class CreateRectangle : Command
    {
        Rectangle r;

        public CreateRectangle(Rectangle r)
        {
            this.r = r;
        }

        public void Execute()
        {
            Singleton.AddToDrawnShapes(r);
            Singleton.AddAction(this);

        }

        public void Undo()
        {
            throw new NotImplementedException();
            //zie createellipse
        }
    }
}

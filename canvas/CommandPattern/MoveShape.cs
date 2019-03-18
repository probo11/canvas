using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class MoveShape : Command
    {
        Shape shape;
        int x, y;
        int oldX, oldY;

        public MoveShape(Shape shape, int x, int y)
        {
            this.shape = shape;
            this.x = x;
            this.y = y;

            oldX = shape.GetX();
            oldY = shape.GetY();
        }

        public void Execute()
        {
            shape.SetX(x);
            shape.SetY(y);
            Singleton.AddAction(this);
        }

        public void Undo()
        {
            shape.SetX(oldX);
            shape.SetY(oldY);
            Singleton.RemoveAction(this);
        }
    }
}

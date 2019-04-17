using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class MoveShape : ICommand
    {
        Shape shape;
        int x, y;
        int oldX, oldY;
        int mostLeftX, mostUpY;

        /// <summary>
        /// Move selected items
        /// </summary>
        /// <param name="shape">Shape</param>
        /// <param name="x">Mousepostion x</param>
        /// <param name="y">Mousepostion y</param>
        /// <param name="mostLeftX">X of the shape that is closest to 0</param>
        /// <param name="mostUpY">Y of the shape that is closest to 0</param>
        public MoveShape(Shape shape, int x, int y, int mostLeftX, int mostUpY)
        {
            this.shape = shape;
            this.x = x;
            this.y = y;
            this.mostLeftX = mostLeftX;
            this.mostUpY = mostUpY;

            oldX = shape.GetX();
            oldY = shape.GetY();
        }

        public void Execute()
        {
            int transitionX = Math.Abs(x - mostLeftX);
            int transitionY = Math.Abs(y - mostUpY);

            if (mostLeftX < x)
            {
                shape.SetX(oldX + transitionX);
            }
            else
            {
                shape.SetX(oldX - transitionX);
            }
            if (mostUpY < y)
            {
                shape.SetY(oldY + transitionY);
            }
            else
            {
                shape.SetY(oldY - transitionY);
            }
            
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

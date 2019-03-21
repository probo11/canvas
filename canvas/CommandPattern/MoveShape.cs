using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class MoveShape : Command
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
            //shape.SetX(oldX - Math.Abs(x - mostLeftX));
            //if (oldY > y)
            //{
            //    shape.SetY(oldY - Math.Abs(y - mostLeftY));
            //}
            string a = $"X: {x}\nY: {y}\noldX: {oldX}\noldY: {oldY}\nmostLeftX: {mostLeftX}\nmostLeftY: {mostUpY}";
            string b = $"x - mostLeftX: {Math.Abs(x - mostLeftX)}\ny - mostUpY: {Math.Abs(y - mostUpY)}";
            //MessageBox.Show(a + "\n" + b);

            int transitionX = Math.Abs(x - mostLeftX);
            int transitionY = Math.Abs(y - mostUpY);

            if (oldX < x)
            {
                shape.SetX(oldX + transitionX);
            }
            else
            {
                shape.SetX(oldX - transitionX);
            }
            if (oldY < y)
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

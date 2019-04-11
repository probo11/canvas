using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class IncreaseShapeSize : ICommand
    {
        Shape shape;
        public IncreaseShapeSize(Shape shape)
        {
            this.shape = shape;
        }

        public void Execute()
        {
            shape.SetHeight(shape.GetHeight() + 5);
            shape.SetWidth(shape.GetWidth() + 5);
            Singleton.AddAction(this);
        }

        public void Undo()
        {
            shape.SetHeight(shape.GetHeight() - 5);
            shape.SetWidth(shape.GetWidth() - 5);
            Singleton.RemoveAction(this);
        }
    }
}

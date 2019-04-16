using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class DecreaseShapeSize : ICommand
    {
        Shape shape;

        public DecreaseShapeSize(Shape shape)
        {
            this.shape = shape;
        }

        public void Execute()
        {
            shape.SetHeight(shape.GetHeight() - 5);
            shape.SetWidth(shape.GetWidth() - 5);
            Singleton.AddAction(this);
        }

        public void Undo()
        {
            shape.SetHeight(shape.GetHeight() + 5);
            shape.SetWidth(shape.GetWidth() + 5);
            Singleton.RemoveAction(this);
        }
    }
}

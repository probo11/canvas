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
            ResizeVisitor rv = new ResizeVisitor(true);
            shape.Accept(rv);
            Singleton.AddAction(this);

        }

        public void Undo()
        {
            ResizeVisitor rv = new ResizeVisitor(false);
            shape.Accept(rv);
            Singleton.AddAction(this);
        }
    }
}

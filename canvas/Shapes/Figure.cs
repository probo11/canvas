using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace canvas
{
    class Figure : Shape
    {
        bool isRectangle;

        public Figure(Point p, int width, int height, bool isRectangle) : base(p, width, height)
        {
            this.isRectangle = isRectangle;
        }

        public string GetFigureType()
        {
            if (isRectangle)
            {
                return "rectangle";
            }
            else
            {
                return "ellipse";
            }
        }

        public override void Accept(IVisitor v)
        {
            v.VisitFigure(this);
        }

        public override void Draw()
        {
            if (isRectangle)
            {
                RectangleStrategy re = new RectangleStrategy();
                re.Execute(this, this.GetSelected());
            }
            else
            {
                EllipseStrategy es = new EllipseStrategy();
                es.Execute(this, GetSelected());
            }
        }
    }
}

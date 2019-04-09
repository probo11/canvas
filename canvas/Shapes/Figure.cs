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

        public override void Draw()
        {
            if (isRectangle)
            {
                RectangleStrategy re = new RectangleStrategy(Singleton.GetCanvas());
                re.Execute(this);
            }
            else
            {
                EllipseStrategy es = new EllipseStrategy(Singleton.GetCanvas());
                es.Execute(this);
            }
        }
    }
}

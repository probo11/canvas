using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class Rectangle : Shape, IShape
    {
        public Rectangle(Point p, int width = 0, int height = 0) : base(p, width, height)
        {
            
        }

        public void Accept()
        {
            throw new NotImplementedException();
        }

        public void Intersect(Point point)
        {
            throw new NotImplementedException();
        }

        public void Update(PictureBox p)
        {
            throw new NotImplementedException();
        }

        //intersect

        //update
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class Rectangle : Shape
    {
        public Rectangle(Point p, int width = 0, int height = 0, bool isSelected = false) : base(p, width, height, isSelected)
        {
            
        }
    }
}

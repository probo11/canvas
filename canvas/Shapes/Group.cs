using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class Group : Shape
    {
        List<Shape> groupContent = new List<Shape>();

        public Group(Point p, int width = 0, int height = 0, bool isSelected = false) : base(p, width, height, isSelected)
        {

        }

        public void Add(Shape s)
        {
            groupContent.Add(s);
        }

        public void Remove(Shape s)
        {
            groupContent.Remove(s);
        }

        public List<Shape> GetChildren()
        {
            return groupContent;
        }
    }
}

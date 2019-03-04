using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class Group : Shape, IShape
    {
        public Group(int x, int y, int width = 0, int height = 0) : base(x, y, width, height)
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
        //update
        //calculate width heigth
    }
}

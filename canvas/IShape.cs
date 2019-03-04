using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    interface IShape
    {
        void Update(System.Windows.Forms.PictureBox p);
        void Intersect(System.Drawing.Point point);
        void Accept();
    }
}

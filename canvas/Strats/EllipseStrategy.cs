using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace canvas
{
    class EllipseStrategy : IStrategy
    {
        public EllipseStrategy( ){}

        public void Execute(Figure f, bool ean)
        {
            // checks if figure is selected
            if (ean)
            {
                Singleton.GetCanvas().DrawEllipse(Singleton.GetSelectedPen(), f.GetX(), f.GetY(), f.GetWidth(), f.GetHeight());
            }
            else
            {
                Singleton.GetCanvas().DrawEllipse(Singleton.GetPen(), f.GetX(), f.GetY(), f.GetWidth(), f.GetHeight());
            }
        }
    }
}

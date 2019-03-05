using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace canvas
{
    class Shape
    {
        private Point p;
        private int width;
        private int height;

        public Shape(Point p, int width, int height)
        {
            this.p = p;
            this.width = width;
            this.height = height;
        }
        
        public int[] GetShapeData()
        {
            int[] Data = { p.X, p.Y, width, height};
            return Data;
        }
    }
}

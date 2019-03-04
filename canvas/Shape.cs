using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class Shape
    {
        private int x;
        private int y;
        private int width;
        private int height;

        public Shape(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        
        public int[] GetShapeData()
        {
            int[] Data = { x, y, width, height};
            return Data;
        }
    }
}

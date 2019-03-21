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
        private bool isSelected = false;
        private Group parent;

        public Shape(Point p, int width, int height, bool isSelected)
        {
            this.p = p;
            this.width = width;
            this.height = height;
            this.isSelected = isSelected;
        }

        public void SetParent(Group s)
        {
            parent = s;
        }

        public Group GetParent()
        {
            return parent;
        }

        public int[] GetShapeData()
        {
            int[] Data = { p.X, p.Y, width, height };
            return Data;
        }

        public int GetX()
        {
            return p.X;
        }

        public int GetY()
        {
            return p.Y;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public bool GetIsSelected()
        {
            return isSelected;
        }

        public void SetIsSelected(bool a)
        {
            isSelected = a;
        }

        public void SetX(int x)
        {
            p.X = x;
        }

        public void SetY(int y)
        {
            p.Y = y;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public string GetShapeType()
        {
            return GetType().ToString().Substring(7).ToLower();
        }
    }
}

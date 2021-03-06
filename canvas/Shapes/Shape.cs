﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace canvas
{
    abstract class Shape
    {
        private Point p;
        private int width;
        private int height;
        private Group parent;
        private bool selected = false;

        public Shape(Point p, int width, int height)
        {
            this.p = p;
            this.width = width;
            this.height = height;
        }

        public bool GetSelected()
        {
            return selected;
        }

        public void SetSelected(bool ean)
        {
            selected = ean;
        }

        public virtual void Accept(IVisitor v)
        {

        }

        public virtual void Draw() { }

        public void SetParent(Group s)
        {
            parent = s;
        }

        public Group GetParent()
        {
            return parent;
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

        public void SetX(int x)
        {
            p.X = x;
        }

        public void SetY(int y)
        {
            p.Y = y;
        }

        public Point GetPoint()
        {
            return p;
        }

        public void SetPoint(Point p)
        {
            this.p = p;
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

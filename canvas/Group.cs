﻿using System;
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
        List<Shape> groupContent = new List<Shape>(); 

        public Group(Point p, int width = 0, int height = 0, bool isSelected = false) : base(p, width, height, isSelected)
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

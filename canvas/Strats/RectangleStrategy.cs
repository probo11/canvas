﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace canvas
{
    class RectangleStrategy : IStrategy
    {

        public RectangleStrategy( )
        {
            
        }

        public void Execute(Figure f, bool ean)
        {
            // checks if figure is selected
            if (ean)
            {
                Singleton.GetCanvas().DrawRectangle(Singleton.GetSelectedPen(), f.GetX(), f.GetY(), f.GetWidth(), f.GetHeight());
            }
            else
            {
                Singleton.GetCanvas().DrawRectangle(Singleton.GetPen(), f.GetX(), f.GetY(), f.GetWidth(), f.GetHeight());
            }
        }
    }
}

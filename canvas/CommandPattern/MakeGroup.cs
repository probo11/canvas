﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace canvas
{
    class MakeGroup : ICommand
    {
        public void Execute()
        {
            Point p = new Point
            {
                X = 10000,
                Y = 10000
            };
            Group g = new Group(p, 0, 0);
            int tx = 0, ty = 0;
            if (Singleton.getSelectedList().Count > 0)
            {
                foreach (var item in Singleton.getSelectedList())
                {
                    g.Add(item);
                    item.SetParent(g);
                    Singleton.RemoveFromDrawnShapes(item);

                    if (item.GetX() < g.GetX())
                    {
                        g.SetX(item.GetX());
                    }
                    if (item.GetY() < g.GetY())
                    {
                        g.SetY(item.GetY());
                    }

                    if (tx < item.GetX())
                    {
                        tx = item.GetX();
                        g.SetWidth(Math.Abs(tx + item.GetWidth() - g.GetX()));
                    }
                    if (ty < item.GetY())
                    {
                        ty = item.GetY();
                        g.SetHeight(Math.Abs(ty + item.GetHeight() - g.GetY()));
                    }
                }
                Singleton.ClearSelectedList();
                Singleton.AddToDrawnShapes(g);
            }
        }

        public void Undo()
        {
            // Deze hebben we leeg gelaten omdat het verwarrend kan zijn wanneer je op "undo" drukt en er dan niks lijkt te gebeuren
        }
    }
}
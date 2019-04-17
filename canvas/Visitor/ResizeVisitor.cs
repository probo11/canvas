using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class ResizeVisitor : IVisitor
    {
        bool increaseSize;

        public ResizeVisitor(bool b)
        {
            increaseSize = b;
        }

        public void VisitFigure(Figure f)
        {
            if (increaseSize)
            {
                f.SetHeight(f.GetHeight() + 5);
                f.SetWidth(f.GetWidth() + 5);
                
            }
            else
            {
                f.SetHeight(f.GetHeight() - 5);
                f.SetWidth(f.GetWidth() - 5);
            }
        }

        public void VisitGroup(Group g)
        {
            if (increaseSize)
            {
                foreach (var item in g.GetChildren())
                {
                    item.SetHeight(item.GetHeight() + 5);
                    item.SetWidth(item.GetWidth() + 5);
                }
            }
            else
            {
                foreach (var item in g.GetChildren())
                {
                    item.SetHeight(item.GetHeight() - 5);
                    item.SetWidth(item.GetWidth() - 5);
                }
            }
        }
    }
}

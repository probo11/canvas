using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    interface IVisitor
    {
        void VisitFigure(Figure f);
        void VisitGroup(Group g);
    }
}

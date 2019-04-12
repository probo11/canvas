using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class SaveVisitor : IVisitor
    {
        private string saveData;
        private int groupCount = 0;
        private int tabCount = 0;

        public void VisitFigure(Figure f)
        {
            saveData += f.GetFigureType() + " " + f.GetX() + " " + f.GetY() + " " + f.GetWidth() + " " + f.GetHeight() +"\n"; 
        }

        public void VisitGroup(Group g)
        {
            groupCount++;
            saveData += g.GetShapeType()+ " " + groupCount + "\n";
            tabCount++;

            foreach (var item in g.GetChildren())
            {
                for(int i = 0; i < tabCount; i++)
                {
                    saveData += "\t ";
                }

                item.Accept(this);             
            }

            tabCount--;
        }

        public string GetSaveData()
        {
            return saveData;
        }
    }
}

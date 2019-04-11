using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class Invoker
    {
        public Invoker() { }
        
        public void DoAction(ICommand c)
        {
            c.Execute();
        }

        public void UndoAction(ICommand c)
        {
            c.Undo();
        }
    }
}

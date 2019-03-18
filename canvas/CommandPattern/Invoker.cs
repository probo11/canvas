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
        
        public void DoAction(Command c)
        {
            c.Execute();
        }

        public void UndoAction(Command c)
        {
            c.Undo();
        }
    }
}

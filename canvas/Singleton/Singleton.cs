using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canvas
{
    class Singleton
    {
        /*
            er is een lijst van gedane acties
            als je dat wilt undoën, dan schrap je dat ding gewoon uit die lijst, stopt het in redo-lijst, en refresht het canvas.
            
             */
        private static Singleton instance = new Singleton();
        private static List<Command> doneActions = new List<Command>();
        private static List<Command> redoActions = new List<Command>();
        private static List<Shape> drawnShapes = new List<Shape>();
        private static Graphics canvas;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            return instance;
        }

        /*alles qua acties*/

        public static void AddAction(Command c)
        {
            doneActions.Add(c);
        }

        public static void RemoveAction(Command c)
        {
            doneActions.Remove(c);
        }

        public static void UndoAction()
        {
            if (doneActions.Count > 0)
            {
                redoActions.Add(doneActions.Last());
                doneActions.Last().Undo();
            }
        }

        public static void EmptyRedoList()
        {
            redoActions.Clear();
        }

        public static void RedoAction()
        {
            if (redoActions.Count > 0)
            {
                Command c = redoActions.Last();
                redoActions.Last().Execute();
                redoActions.Remove(c);
            }

        }

        public static void ClearAllActions()
        {
            redoActions.Clear();
            doneActions.Clear();
            drawnShapes.Clear();
        }

        public static List<Command> GetActions()
        {
            return doneActions;
        }

        /*alles met het tekenen*/
        public static List<Shape> GetDrawnShapes()
        {
            return drawnShapes;
        }

        public static void AddToDrawnShapes(Shape s)
        {
            drawnShapes.Add(s);
        }

        public static void RemoveFromDrawnShapes(Shape s)
        {

            drawnShapes.Remove(s);
        }

        public static void ClearDrawnShapes()
        {
            drawnShapes.Clear();
        }

        public static Graphics GetCanvas()
        {
            return canvas;
        }

        public static void SetCanvas(Graphics g)
        {
            canvas = g;
        }

    }
}

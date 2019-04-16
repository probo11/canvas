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
            ok
             */
        private static Singleton instance = new Singleton();
        private static List<ICommand> doneActions = new List<ICommand>();
        private static List<ICommand> redoActions = new List<ICommand>();
        private static List<Shape> drawnShapes = new List<Shape>();
        private static List<Shape> selectedList = new List<Shape>();
        private static Graphics canvas;
        private static Pen pen = new Pen(Color.Black);
        private static Pen penSelected = new Pen(Color.Red);


        private Singleton() { }

        public static Singleton GetInstance()
        {
            return instance;
        }

        /*haal de pennen op*/
        public static Pen GetPen()
        {
            return pen;
        }

        public static Pen GetSelectedPen()
        {
            return penSelected;
        }

        /*alles qua acties*/

        public static void AddAction(ICommand c)
        {
            doneActions.Add(c);
        }

        public static void RemoveAction(ICommand c)
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
                ICommand c = redoActions.Last();
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

        public static List<ICommand> GetActions()
        {
            return doneActions;
        }

        /*het selecteren*/
        public static List<Shape> getSelectedList()
        {
            return selectedList;
        }

        public static void ClearSelectedList()
        {
            selectedList.Clear();
        }

        public static void AddToSelectedList(Shape s)
        {
            selectedList.Add(s);
        }

        public static void RemoveFromSelectedList(Shape s)
        {
            selectedList.Remove(s);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    public partial class Form1 : Form
    {

        Boolean paint = false;
        int currentAction = 0;
        Point tempPoint;
        Invoker inv = new Invoker();

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;

        }

        private void rectButton_Click(object sender, EventArgs e)
        {
            DeselectAll();
            RefreshCanvas();
            currentAction = 0;
        }

        private void elipButton_Click(object sender, EventArgs e)
        {
            DeselectAll();
            RefreshCanvas();
            currentAction = 1;
        }

        private void seleButton_Click(object sender, EventArgs e)
        {
            currentAction = 2;
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            currentAction = 3;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            foreach (var shape in Singleton.getSelectedList())
            {

                Singleton.EmptyRedoList();
                inv.DoAction(new IncreaseShapeSize(shape));

            }
            paint = true;
            canvas.Refresh();
            paint = false;
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            foreach (var shape in Singleton.getSelectedList())
            {

                Singleton.EmptyRedoList();
                inv.DoAction(new DecreaseShapeSize(shape));

            }
            paint = true;
            canvas.Refresh();
            paint = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Singleton.SetCanvas(canvas.CreateGraphics());
            canvas.BackColor = Color.White;
            canvas.Paint += new PaintEventHandler(this.canvas_Paint);
            this.Controls.Add(canvas);
        }

        private void canvas_Paint(object sender, PaintEventArgs e) //hier vindt het tekenen plaats
        {
            if (paint)
            {
                Singleton.SetCanvas(e.Graphics);
                foreach (var item in Singleton.GetDrawnShapes())
                {
                    item.Draw();
                }
            }


            //if (paint)
            //{
            //    singleton.setcanvas(e.graphics);


            //    /**/
            //    point p = new point
            //    {
            //        x = 1,
            //        y = 2
            //    };
            //    rectangle re = new rectangle(p, 0, 0);
            //    ellipse el = new ellipse(p, 0, 0);

            //    foreach (var item in singleton.getdrawnshapes())
            //    {
            //        bool isselected = false;

            //        foreach (var itemobject in singleton.getselectedlist()) // true is vierkant
            //        {
            //            if (item == itemobject)
            //            {
            //                isselected = true;

            //                if (item.gettype() == re.gettype())
            //                {
            //                    drawshapes(, item.getshapedata(), true);
            //                }
            //                else if (item.gettype() == el.gettype())
            //                {
            //                    drawshapes(penselected, item.getshapedata(), false);
            //                }
            //                else
            //                {

            //                }
            //            }
            //        }

            //        if (!isselected) // true = vierkant
            //        {
            //            if (item.gettype() == re.gettype())
            //            {
            //                drawshapes(pen, item.getshapedata(), true);
            //            }
            //            else if (item.gettype() == el.gettype())
            //            {
            //                drawshapes(pen, item.getshapedata(), false);
            //            }
            //            else
            //            {
            //                list<shape> g = item.getchildren();
            //                foreach (var a in g)
            //                {
            //                    drawshapes(pen, a.getshapedata(), true);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            tempPoint = e.Location;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currentAction)
            {
                case 0://draw rectangle
                    if (e.Location.X > tempPoint.X && e.Location.Y > tempPoint.Y)// draggen rechtsonder
                    {
                        Singleton.EmptyRedoList();
                        inv.DoAction(new CreateFigure(new Figure(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y, true)));

                    }
                    else if (e.Location.X < tempPoint.X && e.Location.Y > tempPoint.Y) // draggen linksonder
                    {
                        Point temp = new Point(0, 0);
                        int width = tempPoint.X - e.Location.X;
                        int height = e.Location.Y - tempPoint.Y;
                        temp.X = tempPoint.X - width;
                        temp.Y = e.Location.Y - height;
                        Singleton.EmptyRedoList();
                        inv.DoAction(new CreateFigure(new Figure(temp, width, height, true)));
                    }
                    else if (e.Location.X < tempPoint.X && e.Location.Y < tempPoint.Y) //draggen linksboven
                    {
                        int width = tempPoint.X - e.Location.X;
                        int height = tempPoint.Y - e.Location.Y;
                        Singleton.EmptyRedoList();
                        inv.DoAction(new CreateFigure(new Figure(e.Location, width, height, true)));
                    }
                    else
                    {
                        Point temp = new Point(0, 0);
                        int width = e.Location.X - tempPoint.X;
                        int height = tempPoint.Y - e.Location.Y;
                        temp.X = tempPoint.X;
                        temp.Y = e.Location.Y;
                        Singleton.EmptyRedoList();
                        inv.DoAction(new CreateFigure(new Figure(temp, width, height, true)));
                    }

                    break;
                case 1://draw ellipse
                    Singleton.EmptyRedoList();
                    inv.DoAction(new CreateFigure(new Figure(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y, false)));
                    break;
                case 2://select
                    foreach (var shape in Singleton.GetDrawnShapes())
                    {
                        if (e.X >= shape.GetX() && e.X <= shape.GetX() + shape.GetWidth())
                        {
                            if (e.Y >= shape.GetY() && e.Y <= shape.GetY() + shape.GetHeight())
                            {
                                bool isInSelectedList = false;

                                if (shape.GetShapeType() == "figure")
                                {
                                    foreach (Shape thing in Singleton.getSelectedList())
                                    {
                                        if (thing == shape)
                                        {
                                            isInSelectedList = true;
                                            break;
                                        }
                                    }
                                    if (isInSelectedList)
                                    {
                                        Singleton.RemoveFromSelectedList(shape);
                                    }
                                    else
                                    {
                                        Singleton.AddToSelectedList(shape);
                                    }
                                }
                                else
                                {
                                    var group = (Group)shape;


                                    foreach (Shape thing in Singleton.getSelectedList())
                                    {
                                        if (thing == shape)
                                        {
                                            isInSelectedList = true;
                                            break;
                                        }
                                    }

                                    if (isInSelectedList)
                                    {
                                        foreach (var item in group.GetChildren())
                                        {
                                            Singleton.RemoveFromSelectedList(item);
                                        }
                                        Singleton.RemoveFromSelectedList(group);
                                    }
                                    else
                                    {
                                        foreach (var item in group.GetChildren())
                                        {
                                            Singleton.AddToSelectedList(item);
                                        }
                                        Singleton.AddToSelectedList(group);
                                    }

                                }
                                EnableButtons();
                            }
                        }
                    }
                    break;
                case 3:
                    int leftX = 10000;
                    int leftY = 10000;
                    foreach (var item in Singleton.getSelectedList())
                    {
                        if (item.GetX() < leftX)
                        {
                            leftX = item.GetX();
                        }
                        if (item.GetY() < leftY)
                        {
                            leftY = item.GetY();
                        }
                    }
                    foreach (var shape in Singleton.getSelectedList())
                    {
                        Singleton.EmptyRedoList();
                        inv.DoAction(new MoveShape(shape, e.X, e.Y, leftX, leftY));
                    }
                    Singleton.ClearSelectedList();
                    DisableButtons();
                    break;
            }
            canvas.Refresh();
            paint = false;
        }

        void DisableButtons()
        {
            moveButton.Enabled = false;
            plusButton.Enabled = false;
            minButton.Enabled = false;
        }

        void EnableButtons()
        {
            moveButton.Enabled = true;
            plusButton.Enabled = true;
            minButton.Enabled = true;
        }

        private void DrawShapes(Pen pen, int[] shape, bool shapeType)
        {
            if (shapeType) // rectangle
            {
                Singleton.GetCanvas().DrawRectangle(pen, shape[0], shape[1], shape[2], shape[3]);
            }
            else
            {
                Singleton.GetCanvas().DrawEllipse(pen, shape[0], shape[1], shape[2], shape[3]);
            }

        }

        private void DeselectAll()
        {
            Singleton.ClearSelectedList();
            RefreshCanvas();
        }

        private void RefreshCanvas()
        {
            paint = true;
            canvas.Refresh();
            paint = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inv.DoAction(new OpenFile());
            //RefreshCanvas();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inv.DoAction(new SaveFile());
            RefreshCanvas();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Singleton.ClearSelectedList();
            Singleton.ClearDrawnShapes();
            Singleton.ClearAllActions();
            Singleton.EmptyRedoList();
            canvas.Refresh();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            Singleton.RedoAction();
            RefreshCanvas();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            Singleton.UndoAction();
            RefreshCanvas();
        }

        private void grouButton_Click(object sender, EventArgs e)
        {
            inv.DoAction(new MakeGroup());
            DeselectAll();
        }
    }
}
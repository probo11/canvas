﻿using System;
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
                if (shape.GetShapeType() == "group")
                {
                    Group sh = (Group)shape;

                    foreach (var ding in sh.GetChildren())
                    {
                        inv.DoAction(new IncreaseShapeSize(ding));
                    }
                }
                else
                {
                    inv.DoAction(new IncreaseShapeSize(shape));
                }

                Singleton.EmptyRedoList();


            }
            RefreshCanvas();
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            foreach (var shape in Singleton.getSelectedList())
            {
                if (shape.GetShapeType() == "group")
                {
                    Group sh = (Group)shape;


                    foreach (var ding in sh.GetChildren())
                    {
                        inv.DoAction(new DecreaseShapeSize(ding));
                    }
                }
                else
                {
                    inv.DoAction(new DecreaseShapeSize(shape));
                }

                Singleton.EmptyRedoList();
            }
            RefreshCanvas();
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
                    List<Shape> list = new List<Shape>();
                    foreach (var shape in Singleton.GetDrawnShapes())
                    {
                        if (e.X >= shape.GetX() && e.X <= shape.GetX() + shape.GetWidth())
                        {
                            if (e.Y >= shape.GetY() && e.Y <= shape.GetY() + shape.GetHeight())
                            {
                                list.Add(shape);
                                if (shape.GetSelected() == true)
                                {
                                    Singleton.selectItems(list, false);
                                }
                                else
                                {
                                    Singleton.selectItems(list, true);
                                }
                                EnableButtons();
                            }
                        }
                    }
                    break;
                case 3: // move
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
                        if (shape.GetShapeType() == "group")
                        {
                            Group sh = (Group)shape;


                            foreach (var ding in sh.GetChildren())
                            {
                                inv.DoAction(new MoveShape(ding, e.X, e.Y, leftX, leftY));
                            }
                        }
                        inv.DoAction(new MoveShape(shape, e.X, e.Y, leftX, leftY));

                        Singleton.EmptyRedoList();

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
            inv.DoAction(new OpenFile());
            RefreshCanvas();
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
            DisableButtons();
        }
    }
}
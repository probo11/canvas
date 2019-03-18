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
            foreach (var shape in Singleton.GetDrawnShapes())
            {
                if (shape.GetIsSelected())
                {
                    Singleton.EmptyRedoList();
                    inv.DoAction(new IncreaseShapeSize(shape));
                }
            }
            paint = true;
            canvas.Refresh();
            paint = false;
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            foreach (var shape in Singleton.GetDrawnShapes())
            {
                if (shape.GetIsSelected())
                {
                    Singleton.EmptyRedoList();
                    inv.DoAction(new DecreaseShapeSize(shape));
                }
            }
            paint = true;
            canvas.Refresh();
            paint = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas.BackColor = Color.White;
            canvas.Paint += new PaintEventHandler(this.canvas_Paint);
            Singleton.SetCanvas(canvas.CreateGraphics());
            this.Controls.Add(canvas);
        }

        private void canvas_Paint(object sender, PaintEventArgs e) //hier vindt het tekenen plaats
        {
            if (paint)
            {
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Black);
                Pen penSelected = new Pen(Color.Red);

                /**/
                Point p = new Point();
                p.X = 1;
                p.Y = 2;
                Rectangle re = new Rectangle(p, 0, 0);
                Ellipse el = new Ellipse(p, 0, 0);

                foreach (var item in Singleton.GetDrawnShapes())
                {
                    if (item.GetIsSelected())
                    {
                        if (item.GetType() == re.GetType())
                        {
                            DrawShapes(penSelected, g, item.GetShapeData(), true);
                        }
                        else if (item.GetType() == el.GetType())
                        {
                            DrawShapes(penSelected, g, item.GetShapeData(), false);
                        }
                    }
                    else
                    {// if the item is not selected
                        if (item.GetType() == re.GetType())
                        {
                            DrawShapes(pen, g, item.GetShapeData(), true);
                        }
                        else if (item.GetType() == el.GetType())
                        {
                            DrawShapes(pen, g, item.GetShapeData(), false);
                        }
                        else
                        {
                            MessageBox.Show(MousePosition.X.ToString() + ";" + MousePosition.Y.ToString());
                        }
                    }
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
                        inv.DoAction(new CreateRectangle(new Rectangle(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y)));

                    }
                    else if (e.Location.X < tempPoint.X && e.Location.Y > tempPoint.Y) // draggen linksonder
                    {
                        Point temp = new Point(0, 0);
                        int width = tempPoint.X - e.Location.X;
                        int height = e.Location.Y - tempPoint.Y;
                        temp.X = tempPoint.X - width;
                        temp.Y = e.Location.Y - height;
                        Singleton.EmptyRedoList();
                        inv.DoAction(new CreateRectangle(new Rectangle(temp, width, height)));
                    }
                    else if (e.Location.X < tempPoint.X && e.Location.Y < tempPoint.Y) //draggen linksboven
                    {
                        int width = tempPoint.X - e.Location.X;
                        int height = tempPoint.Y - e.Location.Y;
                        Singleton.EmptyRedoList();
                        inv.DoAction(new CreateRectangle(new Rectangle(e.Location, width, height)));
                    }
                    else
                    {
                        Point temp = new Point(0, 0);
                        int width = e.Location.X - tempPoint.X;
                        int height = tempPoint.Y - e.Location.Y;
                        temp.X = tempPoint.X;
                        temp.Y = e.Location.Y;
                        Singleton.EmptyRedoList();
                        inv.DoAction(new CreateRectangle(new Rectangle(temp, width, height)));
                    }
                    break;
                case 1://draw ellipse
                    Singleton.EmptyRedoList();
                    inv.DoAction(new CreateEllipse(new Ellipse(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y)));
                    break;
                case 2://select
                    foreach (var shape in Singleton.GetDrawnShapes())
                    {
                        if (e.X >= shape.GetX() && e.X <= shape.GetX() + shape.GetWidth())
                        {
                            if (e.Y >= shape.GetY() && e.Y <= shape.GetY() + shape.GetHeight())
                            {
                                if (shape.GetIsSelected())
                                {
                                    shape.SetIsSelected(false);
                                }
                                else
                                {
                                    shape.SetIsSelected(true);
                                }
                                EnableButtons();
                            }
                        }
                    }
                    break;
                case 3:
                    foreach (var shape in Singleton.GetDrawnShapes())
                    {
                        if (shape.GetIsSelected())
                        {
                            Singleton.EmptyRedoList();
                            inv.DoAction(new MoveShape(shape, e.X, e.Y));
                        }
                        shape.SetIsSelected(false);
                    }
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

        private void DrawShapes(Pen pen, Graphics g, int[] shape, bool shapeType)
        {
            if (shapeType) // rectangle
            {
                g.DrawRectangle(pen, shape[0], shape[1], shape[2], shape[3]);
            }
            else
            {
                g.DrawEllipse(pen, shape[0], shape[1], shape[2], shape[3]);
            }

        }

        private void DeselectAll()
        {
            foreach (var item in Singleton.GetDrawnShapes())
            {
                item.SetIsSelected(false);
            }
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

        private void button1_Click(object sender, EventArgs e)//undo
        {
            Singleton.UndoAction();
            RefreshCanvas();
        }

        private void button2_Click(object sender, EventArgs e)//redo
        {
            Singleton.RedoAction();
            RefreshCanvas();
        }
    }
}
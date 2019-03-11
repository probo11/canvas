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
        List<Shape> drawnShapes = new List<Shape>();

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
            foreach (var shape in drawnShapes)
            {
                if (shape.GetIsSelected())
                {
                    shape.SetHeight(shape.GetHeight() + 5);
                    shape.SetWidth(shape.GetWidth() + 5);
                }
            }
            paint = true;
            canvas.Refresh();
            paint = false;
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            foreach (var shape in drawnShapes)
            {
                if (shape.GetIsSelected())
                {
                    shape.SetHeight(shape.GetHeight() - 5);
                    shape.SetWidth(shape.GetWidth() - 5);
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

            this.Controls.Add(canvas);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
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

                foreach (var item in drawnShapes)
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
            //MessageBox.Show(e.X +" " + e.Y);
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            /**/
            switch (currentAction)
            {
                case 0://draw rectangle
                    if (e.Location.X > tempPoint.X && e.Location.Y > tempPoint.Y)// draggen rechtsonder
                    {
                        drawnShapes.Add(new Rectangle(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y));
                    }
                    else if (e.Location.X < tempPoint.X && e.Location.Y > tempPoint.Y) // draggen linksonder
                    {
                        Point temp = new Point(0, 0);
                        int width = tempPoint.X - e.Location.X;
                        int height = e.Location.Y - tempPoint.Y;
                        temp.X = tempPoint.X - width;
                        temp.Y = e.Location.Y - height;
                        drawnShapes.Add(new Rectangle(temp, width, height));
                    }
                    else if (e.Location.X < tempPoint.X && e.Location.Y < tempPoint.Y) //draggen linksboven
                    {
                        int width = tempPoint.X - e.Location.X;
                        int height = tempPoint.Y - e.Location.Y;
                        drawnShapes.Add(new Rectangle(e.Location, width, height));
                    }
                    else
                    {
                        Point temp = new Point(0, 0);
                        int width = e.Location.X - tempPoint.X;
                        int height = tempPoint.Y - e.Location.Y;
                        temp.X = tempPoint.X;
                        temp.Y = e.Location.Y;
                        drawnShapes.Add(new Rectangle(temp, width, height));
                    }
                    break;
                case 1://draw ellipse
                    drawnShapes.Add(new Ellipse(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y));
                    break;
                case 2://select
                    foreach (var shape in drawnShapes)
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
                    foreach (var shape in drawnShapes)
                    {
                        if (shape.GetIsSelected())
                        {
                            shape.SetX(e.X);
                            shape.SetY(e.Y);
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
            foreach (var item in drawnShapes)
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
            Stream stream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Yolo file (*.yolo)|*.yolo",
                Title = "Open file."
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    drawnShapes.RemoveRange(0, drawnShapes.Count);
                    canvas.Refresh();
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            do
                            {
                                string[] txt = sr.ReadLine().Split(' ');
                                Graphics eb= canvas.CreateGraphics();
                                int[] shape = { Int32.Parse(txt[1]), Int32.Parse(txt[2]), Int32.Parse(txt[3]), Int32.Parse(txt[4]) };
                                Point p = new Point(Int32.Parse(txt[1]), Int32.Parse(txt[2]));
                                if (txt[0] == "rectangle")
                                {
                                    DrawShapes(new Pen(Color.Black), eb, shape, true);
                                    drawnShapes.Add(new Rectangle(p, Int32.Parse(txt[3]), Int32.Parse(txt[4])));
                                }
                                else if (txt[0] == "ellipse")
                                {
                                    DrawShapes(new Pen(Color.Black), eb, shape, false);
                                    drawnShapes.Add(new Ellipse(p, Int32.Parse(txt[3]), Int32.Parse(txt[4])));
                                }
                                
                            } while (sr.EndOfStream == false);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Couldn't open the file please try again.");
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // foreach shape in drawnshapes
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Yolo file (*.yolo)|*.yolo",
                Title = "Save file."
            };


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {//iets doen met savefiledialog.filename
                    using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var shape in drawnShapes)
                        {
                            streamWriter.WriteLine(/*hier moet shapetype x y width height*/);
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Couldn't save the file please try again.");
                }
            }
        }
    }
}
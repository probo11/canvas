using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    public partial class Form1 : Form
    {

        Boolean paint = false;
        int action = 0;

        List<Point> points = new List<Point>();
        List<int> shapes = new List<int>();


        public Form1()
        {
            InitializeComponent();
        }

        private void rectButton_Click(object sender, EventArgs e)
        {
            action = 0;
        }

        private void elipButton_Click(object sender, EventArgs e)
        {
            action = 1;
        }

        private void seleButton_Click(object sender, EventArgs e)
        {
            action = 2;
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
                int i = 0;
                int j = 0;

                foreach (var item in points)
                {
                    if (i%2 ==0)
                    {
                        Shape shape = new Shape(points[i], points[i + 1].X - points[i].X, points[i + 1].Y - points[i].Y);
                        switch (shapes[j])
                        {
                            case 0:
                                //g.DrawRectangle(pen, points[i].X, points[i].Y, points[i + 1].X - points[i].X, points[i + 1].Y - points[i].Y);

                                
                                DrawShapes(pen, g, shape.GetShapeData(), true);
                                
                                break;
                            case 1:
                                // g.DrawEllipse(pen, points[i].X, points[i].Y, points[i + 1].X - points[i].X, points[i + 1].Y - points[i].Y);
                               
                                DrawShapes(pen, g, shape.GetShapeData(), false);
                                break;
                            case 2:
                                //selecteer
                                MessageBox.Show(MousePosition.X.ToString() + ";" + MousePosition.Y.ToString());
                                int closestX = 1000000;
                                int closestY = 1000000;
                                foreach (var itm in points)
                                {
                                    if (itm.X < closestX)
                                    {
                                        closestX = itm.X;
                                    }
                                    if (itm.Y < closestY)
                                    {
                                        closestY = itm.Y;
                                    }
                                }
                                break;
                        }
                        j++;
                    }
                    i++;
                }
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            points.Add(e.Location);
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            shapes.Add(action);
            canvas.Refresh();
            paint = false;

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
    }
}

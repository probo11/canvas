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
        int currentAction = 0;
        Point tempPoint;
        List<Shape> drawnShapes = new List<Shape>(); // 

        public Form1()
        {
            InitializeComponent();
        }

        private void rectButton_Click(object sender, EventArgs e)
        {
            currentAction = 0;
        }

        private void elipButton_Click(object sender, EventArgs e)
        {
            currentAction = 1;
        }

        private void seleButton_Click(object sender, EventArgs e)
        {
            currentAction = 2;
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

                /**/
                Point p = new Point(); 
                p.X = 1; 
                p.Y = 2;
                Rectangle re = new Rectangle(p, 0, 0);
                Ellipse el = new Ellipse(p, 0, 0);

                foreach (var item in drawnShapes)
                {
                    
                    if(item.GetType() == re.GetType())
                    {
                        DrawShapes(pen, g, item.GetShapeData(), true);
                    }
                    else if(item.GetType() == el.GetType())
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

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            tempPoint = e.Location;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            /**/
            switch (currentAction)
            {
                case 0: //draw rectangle
                    drawnShapes.Add(new Rectangle(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y));
                    break;
                case 1://draw ellipse
                    drawnShapes.Add(new Ellipse(tempPoint, e.Location.X - tempPoint.X, e.Location.Y - tempPoint.Y));
                    break;
                case 2://select
                    
                    break;
            }
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


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
        int bob = 0;

        List<Point> points = new List<Point>();
        List<int> shapes = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void rectButton_Click(object sender, EventArgs e)
        {
            bob = 0;
        }

        private void elipButton_Click(object sender, EventArgs e)
        {
            bob = 1;
        }

        private void seleButton_Click(object sender, EventArgs e)
        {
            bob = 2;
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
                        switch (shapes[j])
                        {
                            case 0:
                                g.DrawRectangle(pen, points[i].X, points[i].Y, points[i + 1].X - points[i].X, points[i + 1].Y - points[i].Y);
                                break;
                            case 1:
                                //g.DrawLine(pen, points[i], points[i + 1]);
                                g.DrawEllipse(pen, points[i].X, points[i].Y, points[i + 1].X - points[i].X, points[i + 1].Y - points[i].Y);
                                break;
                            case 2:
                                //selecteer
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
            shapes.Add(bob);
            canvas.Refresh();
            paint = false;

        }


    }
}

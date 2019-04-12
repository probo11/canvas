using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class OpenFile : ICommand
    {
        public void Execute()
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
                    Singleton.ClearAllActions();
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            do
                            {
                                string[] txt = sr.ReadLine().Split(' ');
                                
                                if (txt[0] == "rectangle")
                                {
                                    int[] shape = { Int32.Parse(txt[1]), Int32.Parse(txt[2]), Int32.Parse(txt[3]), Int32.Parse(txt[4]) };
                                    Point p = new Point(Int32.Parse(txt[1]), Int32.Parse(txt[2]));
                                    Singleton.AddToDrawnShapes(new Figure(p, Int32.Parse(txt[3]), Int32.Parse(txt[4]), true));
                                }
                                else if (txt[0] == "ellipse")
                                {
                                    int[] shape = { Int32.Parse(txt[1]), Int32.Parse(txt[2]), Int32.Parse(txt[3]), Int32.Parse(txt[4]) };
                                    Point p = new Point(Int32.Parse(txt[1]), Int32.Parse(txt[2]));
                                    Singleton.AddToDrawnShapes(new Figure(p, Int32.Parse(txt[3]), Int32.Parse(txt[4]), false));
                                }
                                else if (txt[0] == "group")
                                {
                                    Point p = new Point(0,0);
                                    Singleton.AddToDrawnShapes(new Group(p));
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

        public void Undo()
        {

        }
    }
}

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
        List<string> txt = new List<string>();
        Invoker inv = new Invoker();

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

                    int tabCount = 0;
                    List<Group> groupList = new List<Group>();

                    Point po = new Point(10000, 10000);
                    int tx = 0, ty = 0;

                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            do
                            {
                                arrayToList(sr.ReadLine().Split(' '));
                                tabCount = tabCounter(txt);
                                if (tabCount == 0)
                                {
                                    po = new Point(10000, 10000);
                                    tx = 0; ty = 0;
                                    if (txt[0] == "rectangle")
                                    {
                                        Point p = new Point(Int32.Parse(txt[1]), Int32.Parse(txt[2]));
                                        Singleton.AddToDrawnShapes(new Figure(p, Int32.Parse(txt[3]), Int32.Parse(txt[4]), true));
                                    }
                                    else if (txt[0] == "ellipse")
                                    {
                                        Point p = new Point(Int32.Parse(txt[1]), Int32.Parse(txt[2]));
                                        Singleton.AddToDrawnShapes(new Figure(p, Int32.Parse(txt[3]), Int32.Parse(txt[4]), false));
                                    }
                                    else if (txt[0] == "group")
                                    {
                                        groupList = new List<Group>();
                                        Point p = new Point(0, 0);
                                        Group group = new Group(p);
                                        Singleton.AddToDrawnShapes(group);
                                        groupList.Add(group);
                                    }
                                }
                                else
                                {
                                    cleanList();

                                    if (txt[0] == "rectangle")
                                    {
                                        Point p = new Point(Int32.Parse(txt[1]), Int32.Parse(txt[2]));
                                        if (p.X <= po.X)
                                        {
                                            po.X = p.X;
                                        }
                                        if (p.Y <= po.Y)
                                        {
                                            po.Y = p.Y;
                                        }

                                        if (tx <= p.X)
                                        {
                                            tx = p.X;
                                            groupList[tabCount - 1].SetWidth(Math.Abs(tx + int.Parse(txt[3]) - po.X));
                                        }
                                        if (ty <= p.Y)
                                        {
                                            ty = p.Y;
                                            groupList[tabCount - 1].SetHeight(Math.Abs(ty + int.Parse(txt[4]) - po.Y));
                                        }
                                        Figure figure = new Figure(p, Int32.Parse(txt[3]), Int32.Parse(txt[4]), true);
                                        groupList[tabCount - 1].Add(figure);
                                        figure.SetParent(groupList[tabCount - 1]);
                                        groupList[tabCount - 1].SetX(po.X);
                                        groupList[tabCount - 1].SetY(po.Y);
                                    }
                                    else if (txt[0] == "ellipse")
                                    {
                                        Point p = new Point(Int32.Parse(txt[1]), Int32.Parse(txt[2]));
                                        if (p.X <= po.X)
                                        {
                                            po.X = p.X;
                                        }
                                        if (p.Y <= po.Y)
                                        {
                                            po.Y = p.Y;
                                        }

                                        if (tx >= p.X)
                                        {
                                            tx = p.X;
                                            groupList[tabCount - 1].SetWidth(Math.Abs(tx + int.Parse(txt[3]) - po.X));
                                        }
                                        if (ty >= p.Y)
                                        {
                                            ty = p.Y;
                                            groupList[tabCount - 1].SetHeight(Math.Abs(ty + int.Parse(txt[4]) - po.Y));
                                        }
                                        Figure figure = new Figure(p, Int32.Parse(txt[3]), Int32.Parse(txt[4]), false);
                                        groupList[tabCount - 1].Add(figure);
                                        figure.SetParent(groupList[tabCount - 1]);
                                        groupList[tabCount - 1].SetX(po.X);
                                        groupList[tabCount - 1].SetY(po.Y);
                                    }
                                    else if (txt[0] == "group")
                                    {
                                        Point pn = new Point(0, 0);
                                        Group group = new Group(pn);

                                        groupList[tabCount - 1].Add(group);
                                        group.SetParent(groupList[tabCount - 1]);
                                        groupList.Add(group);
                                    }
                                }

                            } while (sr.EndOfStream == false);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Couldn't open the file please try again.");
                    Singleton.ClearDrawnShapes();
                }
            }
        }

        public void Undo()
        {

        }

        int tabCounter(List<string> a)
        {
            int tabs = 0;
            foreach (var item in a)
            {
                if (item == "\t") // tab
                {
                    tabs++;
                }
            }
            return tabs;
        }

        void cleanList()
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < txt.Count; i++)
            {
                if (txt[i] != "\t")
                {
                    temp.Add(txt[i]);
                }
            }
            txt.Clear();
            txt = temp;
        }

        void arrayToList(string[] a)
        {
            txt.Clear();
            for (int i = 0; i < a.Length; i++)
            {
                txt.Add(a[i]);
            }
        }
    }
}

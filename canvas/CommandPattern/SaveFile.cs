using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace canvas
{
    class SaveFile : ICommand
    {
        public void Execute()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Yolo file (*.yolo)|*.yolo",
                Title = "Save file."
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                    {
                        SaveVisitor sv = new SaveVisitor();

                        foreach (var shape in Singleton.GetDrawnShapes())
                        {
                            shape.Accept(sv);
                        }

                        streamWriter.WriteLine(sv.GetSaveData());
                    }
                }
                catch
                {
                    MessageBox.Show("Couldn't save the file, please try again.");
                }
            }
        }

        public void Undo()
        {

        }
    }
}

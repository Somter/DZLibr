using ILoad;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Load
{
    public class LoadClass : ILoadClass
    {
        public string LoadFile()
        {
            try
            {
                using (OpenFileDialog openDialog = new OpenFileDialog())
                {
                    openDialog.Filter = "RTF Files|*.rtf|All Files|*.*";
                    openDialog.Title = "Открыть RTF файл";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        return File.ReadAllText(openDialog.FileName, Encoding.Default);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
            return string.Empty;
        }
    }
}

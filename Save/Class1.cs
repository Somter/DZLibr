using ISave;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Save
{
    public class SaveClass : ISaveClass
    {
        public void SaveFile(string content)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "RTF Files|*.rtf|All Files|*.*";
                    saveDialog.Title = "Сохранить RTF файл";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, content, Encoding.Default);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}

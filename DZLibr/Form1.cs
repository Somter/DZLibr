using ILoad;
using ISave;
using ISelectionColor;
using ISelectionFont;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DZLibr
{
    public partial class Form1 : Form
    {
        private ISaveClass save;
        private ILoadClass load;
        private ISelectionFontClass font;
        private ISelectionColorClass color;   
      
        public Form1()
        {
            InitializeComponent();
            LoadImplementations();
            this.loadToolStripMenuItem.Click += OnLoadFileClick;
            this.fontToolStripMenuItem.Click += OnSelectFontClick;
            this.colorToolStripMenuItem.Click += OnSelectColorClick;
            this.saveToolStripMenuItem.Click += OnSaveFileClick;
            
        }

        private void LoadImplementations()
        {
            try
            {
                Assembly asmLoad = Assembly.LoadFrom("Load.dll");
                Type typeLoad = asmLoad.GetType("Load.LoadClass");
                load = (ILoadClass)Activator.CreateInstance(typeLoad);

                Assembly asmSave = Assembly.LoadFrom("Save.dll");
                Type typeSave = asmSave.GetType("Save.SaveClass");
                save = (ISaveClass)Activator.CreateInstance(typeSave);

                Assembly asmColor = Assembly.LoadFrom("SelectionColor.dll");
                Type typeColor = asmColor.GetType("SelectionColor.SelectionColorClass");
                color = (ISelectionColorClass)Activator.CreateInstance(typeColor);

                Assembly asmFont = Assembly.LoadFrom("SelectionFont.dll");
                Type typeFont = asmFont.GetType("SelectionFont.SelectionFontClass");
                font = (ISelectionFontClass)Activator.CreateInstance(typeFont);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка DLL: {ex.Message}");
            }
        }

        private void OnLoadFileClick(object sender, EventArgs e)
        {
            string content = load?.LoadFile();
            if (!string.IsNullOrEmpty(content))
            {
                richTextBox1.Rtf = content;
            }
        }
        private void OnSelectColorClick(object sender, EventArgs e)
        {
            Color selectedColor = color?.SelectColor() ?? Color.Black;
            richTextBox1.SelectionColor = selectedColor;
        }

        private void OnSelectFontClick(object sender, EventArgs e)
        {
            Font selectedFont = font?.SelectFont();
            if (selectedFont != null)
            {
                richTextBox1.SelectionFont = selectedFont;
            }
        }

        private void OnSaveFileClick(object sender, EventArgs e)
        {
            save?.SaveFile(richTextBox1.Rtf);
        }

       
       

    }
}

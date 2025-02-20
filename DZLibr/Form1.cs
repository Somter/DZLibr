using System.Reflection;

namespace DZLibr
{
    public partial class Form1 : Form
    {
        private ILoadClass loadObject;
        private ISaveClass saveObject;
        private IColorClass colorObject;
        private IFontClass fontObject;

        public Form1()
        {
            InitializeComponent();
            LoadImplementations();
            this.loadToolStripMenuItem.Click += OnLoadFileClick;
            this.saveToolStripMenuItem.Click += OnSaveFileClick;
            this.fontToolStripMenuItem.Click += OnSelectFontClick;
            this.colorToolStripMenuItem.Click += OnSelectColorClick; //check
        }

        private void LoadImplementations()
        {
            try
            {
                Assembly asmLoad = Assembly.LoadFrom("Load.dll");
                Type typeLoad = asmLoad.GetType("Load.LoadClass");
                loadObject = (ILoadClass)Activator.CreateInstance(typeLoad);

                Assembly asmSave = Assembly.LoadFrom("Save.dll");
                Type typeSave = asmSave.GetType("Save.SaveClass");
                saveObject = (ISaveClass)Activator.CreateInstance(typeSave);

                Assembly asmColor = Assembly.LoadFrom("SelectionColor.dll");
                Type typeColor = asmColor.GetType("SelectionColor.SelectionColorClass");
                colorObject = (ISelectionColorClass)Activator.CreateInstance(typeColor);

                Assembly asmFont = Assembly.LoadFrom("SelectionFont.dll");
                Type typeFont = asmFont.GetType("SelectionFont.SelectionFontClass");
                fontObject = (ISelectionFontClass)Activator.CreateInstance(typeFont);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки реализационных DLL: {ex.Message}");
            }
        }

        private void OnLoadFileClick(object sender, EventArgs e)
        {
            string content = loadObject?.LoadFile();
            if (!string.IsNullOrEmpty(content))
            {
                richTextBox1.Rtf = content;
            }
        }

        private void OnSaveFileClick(object sender, EventArgs e)
        {
            saveObject?.SaveFile(richTextBox1.Rtf);
        }

        private void OnSelectFontClick(object sender, EventArgs e)
        {
            Font selectedFont = fontObject?.SelectFont();
            if (selectedFont != null)
            {
                richTextBox1.SelectionFont = selectedFont;
            }
        }

        private void OnSelectColorClick(object sender, EventArgs e)
        {
            Color selectedColor = colorObject?.SelectColor() ?? Color.Black;
            richTextBox1.SelectionColor = selectedColor;
        }

    }
}

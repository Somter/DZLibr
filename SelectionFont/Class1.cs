using ISelectionFont;
using System.Drawing;
using System.Windows.Forms;

namespace SelectionFont
{
    public class SelectionFontClass : ISelectionFontClass 
    {
        public Font SelectFont()
        {
            using (FontDialog fontDialog = new FontDialog())    
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    return fontDialog.Font;
                }
            }
            return SystemFonts.DefaultFont;
        }
    }
}

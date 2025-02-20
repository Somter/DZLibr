using ISelectionColor;
using System.Drawing;
using System.Windows.Forms;

namespace SelectionColor
{
    public class SelectionColorClass : ISelectionColorClass
    {
        public Color SelectColor()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    return colorDialog.Color;
            }
            return Color.Black; 
        }
    }
}

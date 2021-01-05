using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomButton
{
    public class CaroButton: Button
    {
        public CaroButton() : base()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = ColorTranslator.FromHtml("#8BC4FC");
        }
    }
}

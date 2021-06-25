using CaroGame.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class PlayerPanel: Panel
    {
        public PlayerPanel()
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {

        }
    }
}

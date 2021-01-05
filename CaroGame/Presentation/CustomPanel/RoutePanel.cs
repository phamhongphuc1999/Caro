using CaroGame.Presentation.CustomButton;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class RoutePanel: Panel
    {
        public Button nextActionBut, cancelActionBut;

        public RoutePanel(): base()
        {
            this.Size = new Size(600, 95);
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {
            nextActionBut = new CaroButton()
            {
                Text = "Save",
                Size = new Size(90, 40),
                Location = new Point(490, 0)
            };
            cancelActionBut = new CaroButton()
            {
                Text = "Back",
                Size = new Size(90, 40),
                Location = new Point(370, 0)
            };
            this.Controls.Add(nextActionBut);
            this.Controls.Add(cancelActionBut);
        }
    }
}

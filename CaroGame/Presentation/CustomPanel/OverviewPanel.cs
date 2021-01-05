using CaroGame.Presentation.CustomButton;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class OverviewPanel: Panel
    {
        public Button butNewGame, butGuide;

        public OverviewPanel(): base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {
            butNewGame = new CaroButton()
            {
                Text = "New Game",
                Size = new Size(150, 65),
                Location = new Point(100, 155)
            };
            butGuide = new CaroButton()
            {
                Text = "Guide",
                Size = new Size(150, 65),
                Location = new Point(350, 155),
            };
            this.Controls.Add(butNewGame);
            this.Controls.Add(butGuide);
        }
    }
}

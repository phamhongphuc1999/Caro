using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class GameModePanel : Panel
    {
        public Button butTwoPlayer, butModeLan, butModeAI, butLoadGame;
        public Label lblOr;
        public RoutePanel routePanel;

        public GameModePanel() : base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {
            butTwoPlayer = new Button()
            {
                Text = "Two Player",
                Size = new Size(144, 55),
                Location = new Point(42, 45),
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            butModeLan = new Button()
            {
                Text = "LAN Mode",
                Size = new Size(144, 55),
                Location = new Point(228, 45),
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            butModeAI = new Button()
            {
                Name = "butModeAI",
                Text = "One Player",
                Size = new Size(144, 55),
                Location = new Point(414, 45),
                BackColor = ColorTranslator.FromHtml("#8BC4FC")
            };
            lblOr = new Label()
            {
                Name = "lblOr",
                Text = "OR",
                Size = new Size(60, 20),
                Location = new Point(270, 147)
            };
            butLoadGame = new Button()
            {
                Location = new Point(225, 200),
                Text = "Load Game",
                Size = new Size(150, 55)
            };
            routePanel = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(butTwoPlayer);
            this.Controls.Add(butModeLan);
            this.Controls.Add(butModeAI);
            this.Controls.Add(lblOr);
            this.Controls.Add(butLoadGame);
            this.Controls.Add(routePanel);
        }
    }
}

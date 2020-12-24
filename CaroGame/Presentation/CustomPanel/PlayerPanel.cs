using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class PlayerPanel: Panel
    {
        public TextBox txtName1, txtName2;
        public Label lblName1, lblName2;
        private RoutePanel routePnl;

        public PlayerPanel(): base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public Button nextActionBut
        {
            get { return routePnl.nextActionBut; }
            set { }
        }

        public Button cancelActionBut
        {
            get { return routePnl.cancelActionBut; }
            set { }
        }

        private void DrawBasePanel()
        {
            lblName1 = new Label
            {
                Text = "Player1",
                Size = new Size(80, 45),
                Location = new Point(30, 85)
            };
            lblName2 = new Label()
            {
                Text = "Player2",
                Size = new Size(80, 45),
                Location = new Point(30, 170)
            };
            txtName1 = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 85)
            };
            txtName2 = new TextBox()
            {
                Width = 360,
                Location = new Point(120, 170)
            };
            routePnl = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(lblName1);
            this.Controls.Add(lblName2);
            this.Controls.Add(txtName1);
            this.Controls.Add(txtName2);
            this.Controls.Add(routePnl);
        }
    }
}

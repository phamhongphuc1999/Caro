using CaroGame.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class SoundPanel: Panel
    {
        public Label lblSSound;
        public NumericUpDown numSound;
        public RoutePanel routePnl;

        public SoundPanel(): base()
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

        public void DrawBasePanel()
        {
            lblSSound = new Label()
            {
                Text = "Volume",
                Size = new Size(80, 40),
                Location = new Point(40, 100)
            };
            numSound = new NumericUpDown()
            {
                Size = new Size(350, 30),
                Location = new Point(130, 100),
                Value = new decimal(Config.VOLUME_SIZE),
                Maximum = new decimal(100),
                Minimum = new decimal(0),
                ThousandsSeparator = true
            };
            routePnl = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(lblSSound);
            this.Controls.Add(numSound);
            this.Controls.Add(routePnl);
        }
    }
}

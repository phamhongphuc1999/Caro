using CaroGame.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class TimePanel: Panel
    {
        public Label lblSTimeTurn, lblSTimeInterval, lblSSound;
        public TextBox txtSTimeTurn, txtSTimeInterval;
        public Button butStatusTime;
        private RoutePanel routePnl;
        private bool enable;

        public TimePanel(): base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
            enable = true;
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

        public bool Enable
        {
            get
            {
                return enable;
            }
            set
            {
                enable = value;
                txtSTimeTurn.Enabled = enable;
                txtSTimeInterval.Enabled = enable;
                lblSTimeTurn.Enabled = enable;
                lblSTimeInterval.Enabled = enable;
                butStatusTime.Text = enable ? "Off Timer" : "On Timer";
            }
        }

        public void DrawBasePanel()
        {
            lblSTimeTurn = new Label()
            {
                Text = "Time Turn",
                Enabled = Config.IS_ON_TIMER ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 80)
            };
            lblSTimeInterval = new Label()
            {
                Text = "Interval",
                Enabled = Config.IS_ON_TIMER ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 170)
            };
            txtSTimeTurn = new TextBox()
            {
                Text = Config.TIME_TURN.ToString(),
                Enabled = Config.IS_ON_TIMER ? true : false,
                Width = 360,
                Location = new Point(120, 85)
            };
            txtSTimeInterval = new TextBox()
            {
                Text = Config.INTERVAL.ToString(),
                Enabled = Config.IS_ON_TIMER ? true : false,
                Width = 360,
                Location = new Point(120, 170)
            };
            butStatusTime = new Button()
            {
                Text = Config.IS_ON_TIMER ? "Off Timer" : "On Timer",
                Size = new Size(90, 40),
                Location = new Point(250, 280)
            };
            routePnl = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(lblSTimeTurn);
            this.Controls.Add(lblSTimeInterval);
            this.Controls.Add(txtSTimeTurn);
            this.Controls.Add(txtSTimeInterval);
            this.Controls.Add(butStatusTime);
            this.Controls.Add(routePnl);
        }
    }
}

using CaroGame.Configuration;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class TimePanel: Panel
    {
        protected Label lblSTimeTurn, lblSTimeInterval, lblSSound;
        protected TextBox txtSTimeTurn, txtSTimeInterval;
        protected Button butStatusTime;
        protected RoutePanel routePnl;
        protected bool enable;

        public TimePanel() : base()
        {
            this.Size = new Size(600, 375);
            enable = Config.IS_TIMER;
            DrawBasePanel();
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

        public event EventHandler NextActionClickEvent
        {
            add
            {
                routePnl.NextActionClickEvent += value;
            }
            remove
            {
                routePnl.NextActionClickEvent -= value;
            }
        }

        public event EventHandler CancelActionClickEvent
        {
            add
            {
                routePnl.CancelActionClickEvent += value;
            }
            remove
            {
                routePnl.CancelActionClickEvent -= value;
            }
        }

        public string NextText
        {
            get
            {
                return routePnl.NextText;
            }
            set
            {
                routePnl.NextText = value;
            }
        }

        public string CancelText
        {
            get
            {
                return routePnl.CancelText;
            }
            set
            {
                routePnl.CancelText = value;
            }
        }

        public void DrawBasePanel()
        {
            lblSTimeTurn = new Label()
            {
                Text = "Time Turn",
                Enabled = enable ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 80)
            };
            lblSTimeInterval = new Label()
            {
                Text = "Interval",
                Enabled = enable ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 170)
            };
            txtSTimeTurn = new TextBox()
            {
                Text = Config.TIME_TURN.ToString(),
                Enabled = enable ? true : false,
                Width = 360,
                Location = new Point(120, 85)
            };
            txtSTimeInterval = new TextBox()
            {
                Text = Config.INTERVAL.ToString(),
                Enabled = enable ? true : false,
                Width = 360,
                Location = new Point(120, 170)
            };
            butStatusTime = new Button()
            {
                Text = enable ? "Off Timer" : "On Timer",
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

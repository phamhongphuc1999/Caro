using CaroGame.Presentation.CaroButton;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class RoutePanel: Panel
    {
        protected CaroButton1 nextActionBut, cancelActionBut;

        public event EventHandler NextActionClickEvent
        {
            add { nextActionBut.Click += value; }
            remove { nextActionBut.Click -= value; }
        }

        public event EventHandler CancelActionClickEvent
        {
            add { cancelActionBut.Click += value; }
            remove { cancelActionBut.Click -= value; }
        }

        public RoutePanel() : base()
        {
            this.Size = new Size(600, 95);
            DrawBasePanel();
        }

        public bool NextVisible
        {
            get { return nextActionBut.Visible; }
            set
            {
                nextActionBut.Visible = value;
                if (value)
                {
                    nextActionBut.Location = new Point(490, 0);
                    cancelActionBut.Location = new Point(370, 0);
                }
                else cancelActionBut.Location = new Point(490, 0);
            }
        }

        public bool CancelVisible
        {
            get { return cancelActionBut.Visible; }
            set { cancelActionBut.Visible = value; }
        }

        public void DrawBasePanel()
        {
            nextActionBut = new CaroButton1()
            {
                Text = "Save",
                Size = new Size(90, 40),
                Location = new Point(490, 0)
            };
            cancelActionBut = new CaroButton1()
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

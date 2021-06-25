using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class SizePanel : Panel
    {
        public Action<object, EventArgs> ClickEvent;
        protected CaroButton backBut;

        public event EventHandler BackClickEvent
        {
            add
            {
                backBut.Click += value;
            }
            remove
            {
                backBut.Click -= value;
            }
        }

        public SizePanel()
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        public void DrawSizeButtonPanel()
        {
            int index = 0;
            int Y = 10;
            foreach ((int, int) size in Constants.CARO_SIZE)
            {
                int X = 29 + 129 * index;
                if(X > Constants.WIDTH_STANDARD)
                {
                    index = 0;
                    X = 29;
                    Y += 120;
                }
                CaroButton button = new CaroButton
                {
                    Size = new Size(100, 100),
                    Font = new Font("Time New Roman", 15),
                    Location = new Point(X, Y),
                    Text = string.Format("{0} x {1}", size.Item1, size.Item2)
                };
                button.Click += (sender, e) =>
                {
                    SettingConfig.NUMBER_OF_COLUMN = size.Item1;
                    SettingConfig.NUMBER_OF_ROW = size.Item2;
                    ClickEvent(sender, e);
                };
                this.Controls.Add(button);
                index++;
            }
        }

        public void DrawBasePanel()
        {
            DrawSizeButtonPanel();
            backBut = new CaroButton()
            {
                Location = new Point(20, 300),
                Text = "Back",
                Size = new Size(70, 30)
            };
            this.Controls.Add(backBut);
        }
    }
}

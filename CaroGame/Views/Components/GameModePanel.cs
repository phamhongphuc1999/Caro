using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class GameModePanel: BaseCaroPanel
    {
        protected CaroButton twoPlayerBut, lanModeBut, aiModeBut, loadgameBut;
        protected CaroButton backBut;
        protected Label orLbl;

        public event EventHandler TwoPlayerClickEvent
        {
            add
            {
                twoPlayerBut.Click += value;
            }
            remove
            {
                twoPlayerBut.Click -= value;
            }
        }

        public event EventHandler LanModeClickEvent
        {
            add
            {
                lanModeBut.Click += value;
            }
            remove
            {
                lanModeBut.Click -= value;
            }
        }

        public event EventHandler AIModeClickEvent
        {
            add
            {
                aiModeBut.Click += value;
            }
            remove
            {
                aiModeBut.Click -= value;
            }
        }

        public event EventHandler LoadGameClickEvent
        {
            add
            {
                loadgameBut.Click += value;
            }
            remove
            {
                loadgameBut.Click -= value;
            }
        }

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

        public GameModePanel(): base()
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
        }

        protected override void DrawBasePanel()
        {
            twoPlayerBut = new CaroButton()
            {
                Text = "Two Player",
                Size = new Size(130, 40),
                Location = new Point(22, 45)
            };
            lanModeBut = new CaroButton()
            {
                Text = "LAN Mode",
                Size = new Size(130, 40),
                Location = new Point(202, 45)
            };
            aiModeBut = new CaroButton()
            {
                Name = "butModeAI",
                Text = "One Player",
                Size = new Size(130, 40),
                Location = new Point(382, 45)
            };
            orLbl = new Label()
            {
                Name = "lblOr",
                Text = "OR",
                Size = new Size(60, 20),
                Location = new Point(270, 147)
            };
            loadgameBut = new CaroButton()
            {
                Location = new Point(202, 200),
                Text = "Load Game",
                Size = new Size(130, 40)
            };
            backBut = new CaroButton()
            {
                Location = new Point(20, 300),
                Text = "Back",
                Size = new Size(70, 30)
            };
            this.Controls.Add(twoPlayerBut);
            this.Controls.Add(lanModeBut);
            this.Controls.Add(aiModeBut);
            this.Controls.Add(orLbl);
            this.Controls.Add(loadgameBut);
            this.Controls.Add(backBut);
        }
    }
}

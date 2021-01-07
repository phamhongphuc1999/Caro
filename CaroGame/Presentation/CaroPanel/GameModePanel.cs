// --------------------CARO  GAME-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ------------------------------------------------------

using CaroGame.Presentation.CaroButton;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class GameModePanel : Panel
    {
        protected CaroButton1 twoPlayerBut, lanModeBut, aiModeBut, loadgameBut;
        protected Label orLbl;
        protected RoutePanel routePnl;

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

        public GameModePanel() : base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {
            twoPlayerBut = new CaroButton1()
            {
                Text = "Two Player",
                Size = new Size(144, 55),
                Location = new Point(42, 45)
            };
            lanModeBut = new CaroButton1()
            {
                Text = "LAN Mode",
                Size = new Size(144, 55),
                Location = new Point(228, 45)
            };
            aiModeBut = new CaroButton1()
            {
                Name = "butModeAI",
                Text = "One Player",
                Size = new Size(144, 55),
                Location = new Point(414, 45)
            };
            orLbl = new Label()
            {
                Name = "lblOr",
                Text = "OR",
                Size = new Size(60, 20),
                Location = new Point(270, 147)
            };
            loadgameBut = new CaroButton1()
            {
                Location = new Point(225, 200),
                Text = "Load Game",
                Size = new Size(150, 55)
            };
            routePnl = new RoutePanel()
            {
                Location = new Point(0, 280),
                NextVisible = false
            };
            this.Controls.Add(twoPlayerBut);
            this.Controls.Add(lanModeBut);
            this.Controls.Add(aiModeBut);
            this.Controls.Add(orLbl);
            this.Controls.Add(loadgameBut);
            this.Controls.Add(routePnl);
        }
    }
}

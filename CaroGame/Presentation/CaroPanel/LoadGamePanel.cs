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

using CaroGame.Entities;
using CaroGame.Presentation.CaroButton;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Presentation.CaroPanel
{
    class LoadGamePanel : Panel
    {
        private CaroButton1 backBut;
        private Panel displayGamePnl;

        public LoadGamePanel() : base()
        {
            DrawBasePanel();
        }

        public Action<object, EventArgs> ButGameClickEvent
        {
            get; set;
        }

        public Action<object, EventArgs> ButDeleteClickEvent
        {
            get; set;
        }

        public event EventHandler CancelActionClickEvent
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

        private void DrawBasePanel()
        {
            backBut = new CaroButton1()
            {
                Text = "Back",
                Size = new Size(80, 45)
            };
            displayGamePnl = new Panel
            {
                Location = new Point(0, 0)
            };
            this.Controls.Add(backBut);
            this.Controls.Add(displayGamePnl);
        }

        public void DrawLoadGame()
        {
            int Y = 40, count = 1;
            displayGamePnl.Controls.Clear();
            if (storageManager.Count == 0)
            {
                Label info = new Label()
                {
                    Text = "Nothing To Load",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(200, 30),
                    Location = new Point(120, Y)
                };
                Y += 60;
                this.Controls.Add(info);
            }
            else
            {
                foreach (GameSaveData item in storageManager.GameSaveList)
                {
                    string butText = count.ToString() + "." + item.PlayerName1 + " vs " + item.PlayerName2;
                    Button butGame = new Button()
                    {
                        Text = butText,
                        Size = new Size(280, 40),
                        Location = new Point(30, Y)
                    };
                    Button buttonDelete = new Button()
                    {
                        Tag = count,
                        Text = "X",
                        Size = new Size(40, 40),
                        Location = new Point(310, Y)
                    };
                    butGame.Click += ButGame_Click;
                    buttonDelete.Click += ButtonDelete_Click;
                    displayGamePnl.Controls.Add(butGame);
                    displayGamePnl.Controls.Add(buttonDelete);
                    Y += 60; count++;
                }
            }
            displayGamePnl.Size = new Size(400, Y + 30);
            this.Size = new Size(400, Y + 170);
            backBut.Location = new Point(170, Y + 30);
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            this.ButDeleteClickEvent(sender, e);
        }

        private void ButGame_Click(object sender, EventArgs e)
        {
            this.ButGameClickEvent(sender, e);
        }
    }
}

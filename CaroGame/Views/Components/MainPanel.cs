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

using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class MainPanel : BaseCaroPanel
    {
        public CaroMenu mainMenu;
        public TextBox playerTxt;
        protected CaroButton undoBut, redoBut;
        public Label timeLbl;
        public Panel caroBoardView;

        public event EventHandler UndoClickEvent
        {
            add
            {
                undoBut.Click += value;
            }
            remove
            {
                undoBut.Click -= value;
            }
        }

        public event EventHandler RedoClickEvent
        {
            add
            {
                redoBut.Click += value;
            }
            remove
            {
                redoBut.Click -= value;
            }
        }

        public event EventHandler NewGameToolClickEvent
        {
            add
            {
                mainMenu.NewGameItemClickEvent += value;
            }
            remove
            {
                mainMenu.NewGameItemClickEvent -= value;
            }
        }

        public event EventHandler QuickItemClickEvent
        {
            add
            {
                mainMenu.QuickItemClickEvent += value;
            }
            remove
            {
                mainMenu.QuickItemClickEvent -= value;
            }
        }

        public event EventHandler SettingItemClickEvent
        {
            add
            {
                mainMenu.SettingItemClickEvent += value;
            }
            remove
            {
                mainMenu.SettingItemClickEvent -= value;
            }
        }

        public event EventHandler AboutItemClickEvent
        {
            add
            {
                mainMenu.AboutItemClickEvent += value;
            }
            remove
            {
                mainMenu.AboutItemClickEvent -= value;
            }
        }

        public MainPanel(bool isAutoSize) : base(isAutoSize)
        {
            DrawBasePanel();
        }

        protected override void DrawBasePanel()
        {
            undoBut = new CaroButton()
            {
                Text = "Undo",
                Size = new Size(100, 30),
            };
            redoBut = new CaroButton()
            {
                Text = "Redo",
                Size = new Size(100, 30)
            };
            playerTxt = new TextBox()
            {
                Width = 200,
                ReadOnly = true
            };
            timeLbl = new Label()
            {
                Size = new Size(90, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 35)
            };
            mainMenu = new CaroMenu
            {
                Name = "mainMenu",
                Text = "Menu",
                GripMargin = new Padding(2, 2, 0, 2),
                ImageScalingSize = new Size(24, 24),
                Location = new Point(0, 0),
                TabIndex = 0
            };
            caroBoardView = new Panel()
            {
                Location = new Point(0, 75),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            caroBoardView.SizeChanged += CaroBoardView_SizeChanged;
            this.Controls.Add(undoBut);
            this.Controls.Add(redoBut);
            this.Controls.Add(playerTxt);
            this.Controls.Add(timeLbl);
            this.Controls.Add(mainMenu);
            this.Controls.Add(caroBoardView);
        }

        private void CaroBoardView_SizeChanged(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                int X_MIN = panel.Width - 200;
                int X_OTHER = panel.Width - 100;
                if (X_MIN < 0)
                {
                    playerTxt.Width = 100;
                    undoBut.Width = 50;
                    redoBut.Width = 50;
                    X_MIN = panel.Width - 100;
                    X_OTHER = panel.Width - 50;
                }
                else
                {
                    playerTxt.Width = 200;
                    undoBut.Width = 100;
                    redoBut.Width = 100;
                }
                playerTxt.Location = new Point(X_MIN, 0);
                undoBut.Location = new Point(X_MIN, 35);
                redoBut.Location = new Point(X_OTHER, 35);
            }
        }
    }
}

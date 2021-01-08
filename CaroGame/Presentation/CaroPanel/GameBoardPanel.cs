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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class GameBoardPanel : Panel
    {
        public TextBox playerTxt;
        protected Button undoBut, redoBut;
        protected Label timeLbl;
        protected CustomMenu mainMenu;
        protected Panel boardPnl;

        public GameBoardPanel() : base()
        {
            DrawBasePanel();
        }

        public Panel BoardPnl
        {
            get
            {
                return boardPnl;
            }
            set
            {
                this.boardPnl = value;
                this.boardPnl.Location = new Point(0, 75);
                this.Controls.Add(boardPnl);
            }
        }

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

        private void DrawBasePanel()
        {
            undoBut = new Button()
            {
                Text = "Undo",
                Size = new Size(120, 35),
            };
            redoBut = new Button()
            {
                Text = "Redo",
                Size = new Size(120, 35)
            };
            playerTxt = new TextBox()
            {
                Width = 240,
                ReadOnly = true
            };
            timeLbl = new Label()
            {
                Size = new Size(90, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 35)
            };
            mainMenu = new CustomMenu
            {
                Name = "mainMenu",
                Text = "Menu",
                GripMargin = new Padding(2, 2, 0, 2),
                ImageScalingSize = new Size(24, 24),
                Location = new Point(0, 0),
                TabIndex = 0
            };
            this.Controls.Add(undoBut);
            this.Controls.Add(redoBut);
            this.Controls.Add(playerTxt);
            this.Controls.Add(timeLbl);
            this.Controls.Add(mainMenu);
        }

        public void DrawCaroGameBoard()
        {
            if(this.boardPnl != null)
            {
                this.Size = new Size(this.boardPnl.Width, this.boardPnl.Height + 75);
                playerTxt.Location = new Point(this.Width - 240, 0);
                undoBut.Location = new Point(this.Width - 120, 35);
                redoBut.Location = new Point(this.Width - 240, 35);
            }
        }
    }
}

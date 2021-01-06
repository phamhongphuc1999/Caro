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
    public class SettingPanel : Panel
    {
        protected Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butLanguage, butLoadGame, butSaveGame;
        protected RoutePanel routePanel;

        public SettingPanel() : base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public event EventHandler GameModeClickEvent
        {
            add
            {
                butGameMode.Click += value;
            }
            remove
            {
                butGameMode.Click -= value;
            }
        }

        public event EventHandler TimerClickEvent
        {
            add
            {
                butTimer.Click += value;
            }
            remove
            {
                butTimer.Click -= value;
            }
        }

        public event EventHandler NamePlayerClickEvent
        {
            add
            {
                butNamePlayer.Click += value;
            }
            remove
            {
                butNamePlayer.Click -= value;
            }
        }

        public event EventHandler SizeClickEvent
        {
            add
            {
                butSizeBoard.Click += value;
            }
            remove
            {
                butSizeBoard.Click -= value;
            }
        }

        public event EventHandler SoundClickEvent
        {
            add
            {
                butSound.Click += value;
            }
            remove
            {
                butSound.Click -= value;
            }
        }

        public event EventHandler LanguageClickEvent
        {
            add
            {
                butLanguage.Click += value;
            }
            remove
            {
                butLanguage.Click -= value;
            }
        }

        public event EventHandler LoadGameClickEvent
        {
            add
            {
                butLoadGame.Click += value;
            }
            remove
            {
                butLoadGame.Click -= value;
            }
        }

        public event EventHandler SaveGameClickEvent
        {
            add
            {
                butSaveGame.Click += value;
            }
            remove
            {
                butSaveGame.Click -= value;
            }
        }

        public event EventHandler NextActionClickEvent
        {
            add
            {
                routePanel.NextActionClickEvent += value;
            }
            remove
            {
                routePanel.NextActionClickEvent -= value;
            }
        }

        public event EventHandler CancelActionClickEvent
        {
            add
            {
                routePanel.CancelActionClickEvent += value;
            }
            remove
            {
                routePanel.CancelActionClickEvent -= value;
            }
        }

        private void DrawBasePanel()
        {
            butGameMode = new Button()
            {
                Text = "Game Mode",
                Size = new Size(144, 55),
                Location = new Point(42, 70)
            };
            butTimer = new Button()
            {
                Text = "Time",
                Size = new Size(144, 55),
                Location = new Point(228, 70)
            };
            butNamePlayer = new Button()
            {
                Text = "Player",
                Size = new Size(144, 55),
                Location = new Point(414, 70)
            };
            butSizeBoard = new Button()
            {
                Text = "Size Board",
                Size = new Size(144, 55),
                Location = new Point(42, 145)
            };
            butSound = new Button()
            {
                Text = "Sound",
                Size = new Size(144, 55),
                Location = new Point(228, 145)
            };
            butLanguage = new SettingButton()
            {
                Text = "Language",
                Size = new Size(144, 55),
                Location = new Point(414, 145)
            };
            butLoadGame = new Button()
            {
                Text = "Load Game",
                Size = new Size(110, 40),
                Location = new Point(370, 0)
            };
            butSaveGame = new Button()
            {
                Text = "Save Game",
                Size = new Size(110, 40),
                Location = new Point(485, 0)
            };
            routePanel = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(butGameMode);
            this.Controls.Add(butTimer);
            this.Controls.Add(butNamePlayer);
            this.Controls.Add(butSizeBoard);
            this.Controls.Add(butSound);
            this.Controls.Add(butLanguage);
            this.Controls.Add(butLoadGame);
            this.Controls.Add(butSaveGame);
            this.Controls.Add(routePanel);
        }
    }
}

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
        protected Button gameModeBut, timerBut, namePlayerBut, sizeBoardBut, soundBut, languageBut, loadGameBut, saveGameBut;
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
                gameModeBut.Click += value;
            }
            remove
            {
                gameModeBut.Click -= value;
            }
        }

        public event EventHandler TimerClickEvent
        {
            add
            {
                timerBut.Click += value;
            }
            remove
            {
                timerBut.Click -= value;
            }
        }

        public event EventHandler NamePlayerClickEvent
        {
            add
            {
                namePlayerBut.Click += value;
            }
            remove
            {
                namePlayerBut.Click -= value;
            }
        }

        public event EventHandler SizeClickEvent
        {
            add
            {
                sizeBoardBut.Click += value;
            }
            remove
            {
                sizeBoardBut.Click -= value;
            }
        }

        public event EventHandler SoundClickEvent
        {
            add
            {
                soundBut.Click += value;
            }
            remove
            {
                soundBut.Click -= value;
            }
        }

        public event EventHandler LanguageClickEvent
        {
            add
            {
                languageBut.Click += value;
            }
            remove
            {
                languageBut.Click -= value;
            }
        }

        public event EventHandler LoadGameClickEvent
        {
            add
            {
                loadGameBut.Click += value;
            }
            remove
            {
                loadGameBut.Click -= value;
            }
        }

        public event EventHandler SaveGameClickEvent
        {
            add
            {
                saveGameBut.Click += value;
            }
            remove
            {
                saveGameBut.Click -= value;
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

        public string NextText
        {
            get
            {
                return routePanel.NextText;
            }
            set
            {
                routePanel.NextText = value;
            }
        }

        public string CancelText
        {
            get
            {
                return routePanel.CancelText;
            }
            set
            {
                routePanel.CancelText = value;
            }
        }

        private void DrawBasePanel()
        {
            gameModeBut = new Button()
            {
                Text = "Game Mode",
                Size = new Size(144, 55),
                Location = new Point(42, 70)
            };
            timerBut = new Button()
            {
                Text = "Time",
                Size = new Size(144, 55),
                Location = new Point(228, 70)
            };
            namePlayerBut = new Button()
            {
                Text = "Player",
                Size = new Size(144, 55),
                Location = new Point(414, 70)
            };
            sizeBoardBut = new Button()
            {
                Text = "Size Board",
                Size = new Size(144, 55),
                Location = new Point(42, 145)
            };
            soundBut = new Button()
            {
                Text = "Sound",
                Size = new Size(144, 55),
                Location = new Point(228, 145)
            };
            languageBut = new SettingButton()
            {
                Text = "Language",
                Size = new Size(144, 55),
                Location = new Point(414, 145)
            };
            loadGameBut = new Button()
            {
                Text = "Load Game",
                Size = new Size(110, 40),
                Location = new Point(370, 0)
            };
            saveGameBut = new Button()
            {
                Text = "Save Game",
                Size = new Size(110, 40),
                Location = new Point(485, 0)
            };
            routePanel = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(gameModeBut);
            this.Controls.Add(timerBut);
            this.Controls.Add(namePlayerBut);
            this.Controls.Add(sizeBoardBut);
            this.Controls.Add(soundBut);
            this.Controls.Add(languageBut);
            this.Controls.Add(loadGameBut);
            this.Controls.Add(saveGameBut);
            this.Controls.Add(routePanel);
        }
    }
}

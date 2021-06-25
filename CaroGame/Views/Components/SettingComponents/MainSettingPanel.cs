using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;

namespace CaroGame.Views.Components.SettingComponents
{
    public class MainSettingPanel : BaseCaroPanel
    {
        protected CaroButton gameModeBut, timerBut, playerBut, sizeBut, soundBut, languageBut, loadGameBut, saveGameBut;
        private CaroButton permitBut, cancelBut;

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

        public event EventHandler PlayerClickEvent
        {
            add
            {
                playerBut.Click += value;
            }
            remove
            {
                playerBut.Click -= value;
            }
        }

        public event EventHandler SizeClickEvent
        {
            add
            {
                sizeBut.Click += value;
            }
            remove
            {
                sizeBut.Click -= value;
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

        public event EventHandler PermitClickEvent
        {
            add
            {
                permitBut.Click += value;
            }
            remove
            {
                permitBut.Click -= value;
            }
        }

        public event EventHandler CancelClickEvent
        {
            add
            {
                cancelBut.Click += value;
            }
            remove
            {
                cancelBut.Click -= value;
            }
        }

        public MainSettingPanel() : base()
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
        }

        protected override void DrawBasePanel()
        {
            gameModeBut = new CaroButton()
            {
                Text = "Game Mode",
                Size = new Size(100, 45),
                Location = new Point(29, 70)
            };
            timerBut = new CaroButton()
            {
                Text = "Time",
                Size = new Size(100, 45),
                Location = new Point(158, 70)
            };
            playerBut = new CaroButton()
            {
                Text = "Player",
                Size = new Size(100, 45),
                Location = new Point(287, 70)
            };
            sizeBut = new CaroButton()
            {
                Text = "Size Board",
                Size = new Size(100, 45),
                Location = new Point(416, 70)
            };
            soundBut = new CaroButton()
            {
                Text = "Sound",
                Size = new Size(100, 45),
                Location = new Point(29, 135)
            };
            languageBut = new CaroButton()
            {
                Text = "Language",
                Size = new Size(100, 45),
                Location = new Point(158, 135)
            };
            loadGameBut = new CaroButton()
            {
                Text = "Load Game",
                Size = new Size(80, 30),
                Location = new Point(345, 0)
            };
            saveGameBut = new CaroButton()
            {
                Text = "Save Game",
                Size = new Size(80, 30),
                Location = new Point(445, 0)
            };
            cancelBut = new CaroButton
            {
                Location = new Point(380, 300),
                Text = "Cancel",
                Size = new Size(70, 30)
            };
            permitBut = new CaroButton()
            {
                Location = new Point(455, 300),
                Text = "Next",
                Size = new Size(70, 30)
            };
            this.Controls.Add(gameModeBut);
            this.Controls.Add(timerBut);
            this.Controls.Add(playerBut);
            this.Controls.Add(sizeBut);
            this.Controls.Add(soundBut);
            this.Controls.Add(languageBut);
            this.Controls.Add(loadGameBut);
            this.Controls.Add(saveGameBut);
            this.Controls.Add(cancelBut);
            this.Controls.Add(permitBut);
        }
    }
}

using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class MainPanel: Panel
    {
        public CaroMenu mainMenu;
        public TextBox playerTxt;
        protected CaroButton undoBut, redoBut;
        public Label timeLbl;
        public Panel caroBoardView;

        public MainPanel(): base()
        {
            DrawBasePanel();
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
            undoBut = new CaroButton()
            {
                Text = "Undo",
                Size = new Size(120, 35),
            };
            redoBut = new CaroButton()
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
                Location = new Point(0, 75)
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
            this.Size = new Size(this.caroBoardView.Width, this.caroBoardView.Height + 75);
            playerTxt.Location = new Point(this.Width - 240, 0);
            undoBut.Location = new Point(this.Width - 120, 35);
            redoBut.Location = new Point(this.Width - 240, 35);
        }
    }
}

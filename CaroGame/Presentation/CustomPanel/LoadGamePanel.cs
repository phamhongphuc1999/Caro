using CaroGame.Entities;
using CaroGame.SaveGameManagement;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class LoadGamePanel: Panel
    {
        public Button butBack;
        private event EventHandler loadGame_Click;
        public event EventHandler LoadGame_Click
        {
            add { loadGame_Click += value; }
            remove { loadGame_Click -= value; }
        }

        private event EventHandler cancelLoadGame_Click;
        public event EventHandler CancelLoadGame_Click
        {
            add { cancelLoadGame_Click += value; }
            remove { cancelLoadGame_Click -= value; }
        }

        public LoadGamePanel(): base()
        {
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {
            butBack = new Button
            {
                Text = "Back",
                Size = new Size(60, 55)
            };
            this.Controls.Add(butBack);
        }

        public void DrawLoadGame()
        {
            int Y = 40, count = 1;
            this.Controls.Clear();
            if (SaveGameHelper.saveData.GameSaveList.Count == 0)
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
                foreach (GameSaveData item in SaveGameHelper.saveData.GameSaveList)
                {
                    string butText = count.ToString() + "." + item.PlayerName1 + " vs " + item.PlayerName2 + "; row: "
                        + item.NumberOfRow + "/ column: " + item.NumberOfColumn;
                    Button button = new Button()
                    {
                        Text = butText,
                        Size = new Size(200, 40),
                        Location = new Point(70, Y)
                    };
                    Button buttonDelete = new Button()
                    {
                        Tag = count,
                        Text = "X",
                        Size = new Size(40, 40),
                        Location = new Point(270, Y)
                    };
                    button.Click += loadGame_Click;
                    buttonDelete.Click += cancelLoadGame_Click;
                    this.Controls.Add(button);
                    this.Controls.Add(buttonDelete);
                    Y += 60; count++;
                }
            }
            this.Size = new Size(400, Y + 110);
            butBack.Location = new Point(170, Y + 30);
        }
    }
}

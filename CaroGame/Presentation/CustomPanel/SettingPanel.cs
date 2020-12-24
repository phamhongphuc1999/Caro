using CaroGame.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CustomPanel
{
    public class SettingPanel: Panel
    {
        public Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butLoadGame, butSaveGame;
        public RoutePanel routePanel;

        public SettingPanel() : base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
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
            if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.TWO_PLAYER) butTimer.Enabled = true;
            else if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN) butTimer.Enabled = false;
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
            this.Controls.Add(butLoadGame);
            this.Controls.Add(butSaveGame);
            this.Controls.Add(routePanel);
        }
    }
}

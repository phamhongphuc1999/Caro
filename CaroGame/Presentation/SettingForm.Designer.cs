using CaroGame.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    partial class SettingForm
    {
        public Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butSave, butLoadGame, butCancel, butSaveGame;
        public Label lblSTimeTurn, lblSTimeInterval;
        public TextBox txtSTimeTurn, txtSTimeInterval;
        public Button butStatusTime;

        private void InitializeTimeSetting()
        {
            lblSTimeTurn = new Label()
            {
                Text = "Time Turn",
                Enabled = Config.IS_ON_TIMER ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 80)
            };

            lblSTimeInterval = new Label()
            {
                Text = "Interval",
                Enabled = Config.IS_ON_TIMER ? true : false,
                Size = new Size(80, 40),
                Location = new Point(30, 170)
            };

            txtSTimeTurn = new TextBox()
            {
                Text = Config.TIME_TURN.ToString(),
                Enabled = Config.IS_ON_TIMER ? true : false,
                Width = 360,
                Location = new Point(120, 85)
            };

            txtSTimeInterval = new TextBox()
            {
                Text = Config.INTERVAL.ToString(),
                Enabled = Config.IS_ON_TIMER ? true : false,
                Width = 360,
                Location = new Point(120, 170)
            };

            butStatusTime = new Button()
            {
                Text = Config.IS_ON_TIMER ? "Off Timer" : "On Timer",
                Size = new Size(90, 40),
                Location = new Point(250, 280)
            };
            butStatusTime.Click += ButStatusTime_Click;
        }

        private void InitializeCommonSetting()
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
            butSave = new Button()
            {
                Text = "Save Change",
                Size = new Size(90, 40),
                Location = new Point(490, 280)
            };
            butLoadGame = new Button()
            {
                Text = "Load Game",
                Size = new Size(110, 40),
                Location = new Point(370, 0)
            };
            butCancel = new Button()
            {
                Text = "Back",
                Size = new Size(90, 40),
                Location = new Point(370, 280)
            };
            butSaveGame = new Button()
            {
                Text = "Save Game",
                Size = new Size(110, 40),
                Location = new Point(485, 0)
            };
            butGameMode.Click += ButGameMode_Click;
            butTimer.Click += ButTimer_Click;
            //butNamePlayer.Click += ButNamePlayer_Click;
            //butSizeBoard.Click += ButSizeBoard_Click;
            //butSound.Click += ButSound_Click;
            //butSave.Click += ButSave_Click;
        }

        private void InitializeController()
        {
            InitializeCommonSetting();
            InitializeTimeSetting();
        }

        public void DrawSettingForm(Form settingForm)
        {
            DrawCommonForm(ref settingForm, Config.NAME.SETTING);
            settingForm.Controls.Add(butGameMode);
            settingForm.Controls.Add(butTimer);
            settingForm.Controls.Add(butNamePlayer);
            settingForm.Controls.Add(butSizeBoard);
            settingForm.Controls.Add(butSound);
            settingForm.Controls.Add(butSave);
            settingForm.Controls.Add(butCancel);
            settingForm.Controls.Add(butSaveGame);
            settingForm.Controls.Add(butLoadGame);
            if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.TWO_PLAYER) butTimer.Enabled = true;
            else if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN) butTimer.Enabled = false;
        }

        public void DrawTimeSettingForm(Form timeSettingForm)
        {
            DrawCommonForm(ref timeSettingForm, Config.NAME.TIME_SETTING);
            timeSettingForm.Controls.Add(lblSTimeTurn);
            timeSettingForm.Controls.Add(lblSTimeInterval);
            timeSettingForm.Controls.Add(txtSTimeTurn);
            timeSettingForm.Controls.Add(txtSTimeInterval);
            timeSettingForm.Controls.Add(butStatusTime);
            timeSettingForm.Controls.Add(butCancel);
            timeSettingForm.Controls.Add(butSave);
        }
    }
}
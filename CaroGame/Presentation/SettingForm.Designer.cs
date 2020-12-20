using CaroGame.Configuration;
using CaroGame.Presentation.CustomPanel;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    partial class SettingForm
    {
        public Label lblSTimeTurn, lblSTimeInterval, lblSSound;
        public TextBox txtSTimeTurn, txtSTimeInterval;
        public Button butStatusTime;
        public NumericUpDown numSound;
        public PlayerPanel playerPanel;
        public SizePanel sizePanel;
        public SettingPanel settingPanel;

        //Controler in Common Setting
        public Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butLoadGame, butSaveGame;

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

        private void InitializeSoundSetting()
        {
            lblSSound = new Label()
            {
                Text = "Volume",
                Size = new Size(80, 40),
                Location = new Point(40, 100)
            };
            numSound = new NumericUpDown()
            {
                Size = new Size(350, 30),
                Location = new Point(130, 100),
                Value = new decimal(Config.VOLUME_SIZE),
                Maximum = new decimal(100),
                Minimum = new decimal(0),
                ThousandsSeparator = true
            };
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
            butGameMode.Click += ButGameMode_Click;
            butTimer.Click += ButTimer_Click;
            butNamePlayer.Click += ButNamePlayer_Click;
            butSizeBoard.Click += ButSizeBoard_Click;
            butSound.Click += ButSound_Click;
            
        }

        private void InitializeController()
        {
            playerPanel = new PlayerPanel()
            {
                Location = new Point(0, 0)
            };
            sizePanel = new SizePanel()
            {
                Location = new Point(0, 0)
            };
            settingPanel = new SettingPanel()
            {
                Location = new Point(0, 280)
            };
            settingPanel.saveBut.Click += SettingPanel_SaveBut_Click;
            InitializeCommonSetting();
            InitializeSoundSetting();
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
            settingForm.Controls.Add(butSaveGame);
            settingForm.Controls.Add(butLoadGame);
            settingForm.Controls.Add(settingPanel);
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
            timeSettingForm.Controls.Add(settingPanel);
        }

        public void DrawSoundSettingForm(Form soundSettingForm)
        {
            DrawCommonForm(ref soundSettingForm, Config.NAME.SOUND_SETTING);
            soundSettingForm.Controls.Add(lblSSound);
            soundSettingForm.Controls.Add(numSound);
            soundSettingForm.Controls.Add(settingPanel);
        }

        public void DrawPlayerForm(Form playerForm, string formText, string gameMode = "")
        {
            DrawCommonForm(ref playerForm, formText);
            playerForm.Controls.Add(playerPanel);
            playerForm.Controls.Add(settingPanel);
        }

        public void DrawSizeSettingForm(Form sizeSettingForm)
        {
            DrawCommonForm(ref sizeSettingForm, Config.NAME.SIZE_SETTING);
            sizeSettingForm.Controls.Add(sizePanel);
            sizeSettingForm.Controls.Add(settingPanel);
        }
    }
}
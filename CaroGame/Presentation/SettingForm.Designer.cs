using CaroGame.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    partial class SettingForm
    {
        private Button butGameMode, butTimer, butNamePlayer, butSizeBoard, butSound, butSave, butLoadGame, butCancel, butSaveGame;

        private void InitializeController()
        {
            #region Common Setting
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
            //butGameMode.Click += ButGameMode_Click;
            //butTimer.Click += ButTimer_Click;
            //butNamePlayer.Click += ButNamePlayer_Click;
            //butSizeBoard.Click += ButSizeBoard_Click;
            //butSound.Click += ButSound_Click;
            //butSave.Click += ButSave_Click;
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingForm"></param>
        private void DrawSettingForm(Form settingForm)
        {
            DrawCommonForm(ref settingForm, Config.NAME.SETTING);
            settingForm.Icon = new Icon("../../../Resources/Image/setting.ico");
            settingForm.Controls.Add(butGameMode);
            settingForm.Controls.Add(butTimer);
            settingForm.Controls.Add(butNamePlayer);
            settingForm.Controls.Add(butSizeBoard);
            settingForm.Controls.Add(butSound);
            settingForm.Controls.Add(butSave);
            settingForm.Controls.Add(butCancel);
            settingForm.Controls.Add(butSaveGame);
            settingForm.Controls.Add(butLoadGame);
            butSave.Text = "Save Change";
            if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.TWO_PLAYER) butTimer.Enabled = true;
            else if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN) butTimer.Enabled = false;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "SettingForm";
        }
        #endregion
    }
}
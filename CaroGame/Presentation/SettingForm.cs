// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Presentation
{
    public partial class SettingForm : BaseForm
    {
        public SettingForm(string formText, Icon icon): base(formText, icon)
        {
            this.ClientSize = new Size(600, 375);
            InitializeController();
            DrawSettingForm();
            this.FormClosing += SettingForm_FormClosing;
        }

        private void DisplayCommonSetting()
        {
            this.Text = Config.NAME.SETTING;
            currentPnl.Visible = false;
            settingPanel.Visible = true;
            currentPnl = settingPanel;
        }

        private void DisplayTimeSetting()
        {
            this.Text = Config.NAME.TIME_SETTING;
            currentPnl.Visible = false;
            timePanel.Visible = true;
            currentPnl = timePanel;
        }

        private void DisplaySoundSetting()
        {
            this.Text = Config.NAME.SOUND_SETTING;
            currentPnl.Visible = false;
            soundPanel.Visible = true;
            currentPnl = soundPanel;
        }

        private void DisplayPlayerSetting(string gameMode)
        {
            this.Text = Config.NAME.PLAYER_SETTING;
            currentPnl.Visible = false;
            playerPanel.Visible = true;
            currentPnl = playerPanel;
        }

        private void DisplaySizeSetting()
        {
            this.Text = Config.NAME.SIZE_SETTING;
            currentPnl.Visible = false;
            sizePanel.Visible = true;
            currentPnl = sizePanel;
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Config.TIME_CONFIG.IsTime && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) mainForm.timer.Start();
        }

        private void Time_ButStatusTime_Click1(object sender, EventArgs e)
        {
            timePanel.Enable = !timePanel.Enable;
        }

        private void Common_ButTimer_Click(object sender, EventArgs e)
        {
            DisplayTimeSetting();
        }

        private void Common_ButGameMode_Click(object sender, EventArgs e)
        {
        }

        private void Common_ButNamePlayer_Click(object sender, EventArgs e)
        {
            DisplayPlayerSetting(Config.GAME_MODE.CurrentGameMode);
        }

        private void SettingPanel_SaveBut_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Config.TIME_CONFIG.IsTime && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) mainForm.timer.Start();
        }

        private void Common_ButSound_Click(object sender, EventArgs e)
        {
            DisplaySoundSetting();
        }

        private void Common_ButSizeBoard_Click(object sender, EventArgs e)
        {
            DisplaySizeSetting();
        }

        private void Player_CancelActionBut_Click(object sender, EventArgs e)
        {
            DisplayCommonSetting();
        }

        private void Player_NextActionBut_Click(object sender, EventArgs e)
        {
            string namePlayer1 = playerPanel.txtName1.Text;
            string namePlayer2 = playerPanel.txtName2.Text;
            if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
            {
                MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                playerPanel.txtName1.Text = Config.NAME_PLAYER1;
                playerPanel.txtName2.Text = Config.NAME_PLAYER2;
                return;
            }
            if (namePlayer1 == namePlayer2)
            {
                MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                playerPanel.txtName1.Text = Config.NAME_PLAYER1;
                playerPanel.txtName2.Text = Config.NAME_PLAYER2;
                return;
            }
            Config.NAME_PLAYER1 = namePlayer1;
            Config.NAME_PLAYER2 = namePlayer2;
            caroManager.PlayerList[0].NamePlayer = Config.NAME_PLAYER1;
            caroManager.PlayerList[1].NamePlayer = Config.NAME_PLAYER2;
            mainForm.txtPlayer.Text = caroManager.PlayerList[caroManager.Turn].NamePlayer;
            DisplayCommonSetting();
        }

        private void Time_CancelActionBut_Click(object sender, EventArgs e)
        {
            DisplayCommonSetting();
        }

        private void Time_NextActionBut_Click(object sender, EventArgs e)
        {
            if (timePanel.butStatusTime.Text == "Off Timer")
            {
                int timeTurn = 0, interval = 0;
                bool check1 = Int32.TryParse(timePanel.txtSTimeTurn.Text, out timeTurn);
                bool check2 = Int32.TryParse(timePanel.txtSTimeInterval.Text, out interval);
                if (!check1 || !check2)
                {
                    MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timePanel.txtSTimeTurn.Text = Config.TIME_CONFIG.TimeTurn.ToString();
                    timePanel.txtSTimeInterval.Text = Config.TIME_CONFIG.Interval.ToString();
                    return;
                }
                if (timeTurn <= 0 || timeTurn < interval || timeTurn > 30)
                {
                    MessageBox.Show("time turn is the integer within 0 and 30 and less than interval", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timePanel.txtSTimeTurn.Text = Config.TIME_CONFIG.TimeTurn.ToString();
                    timePanel.txtSTimeInterval.Text = Config.TIME_CONFIG.Interval.ToString();
                    return;
                }
                Config.TIME_CONFIG.IsTime = true;
                Config.TIME_CONFIG.TimeTurn = timeTurn;
                Config.TIME_CONFIG.Interval = interval;
                mainForm.lblTime.Text = Config.TIME_CONFIG.TimeTurn.ToString();
            }
            else
            {
                Config.TIME_CONFIG.IsTime = false;
                mainForm.lblTime.Text = "No Timer";
            }
            DisplayCommonSetting();
        }

        private void Sound_CancelActionBut_Click(object sender, EventArgs e)
        {
            DisplayCommonSetting();
        }

        private void Sound_NextActionBut_Click(object sender, EventArgs e)
        {
            Config.VOLUME_SIZE = (int)soundPanel.numSound.Value;
            soundManager.Volume = Config.VOLUME_SIZE;
            if (Config.VOLUME_SIZE == 0)
            {
                Config.IS_PLAY_MUSIC = false;
                soundManager.Stop();
            }
            else
            {
                Config.IS_PLAY_MUSIC = true;
                soundManager.IsLoop = true;
                soundManager.Volume = Config.VOLUME_SIZE;
                soundManager.Play("su-thanh-hoa.wav");
            }
            DisplayCommonSetting();
        }

        private void Size_CancelActionBut_Click(object sender, EventArgs e)
        {
            DisplayCommonSetting();
        }

        private void Size_NextActionBut_Click(object sender, EventArgs e)
        {
            int row = 0, column = 0;
            bool check1 = Int32.TryParse(sizePanel.txtRow.Text, out row);
            bool check2 = Int32.TryParse(sizePanel.txtColumn.Text, out column);
            if (!check1 || !check2)
            {
                MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sizePanel.txtRow.Text = Config.NUMBER_OF_ROW.ToString();
                sizePanel.txtColumn.Text = Config.NUMBER_OF_COLUMN.ToString();
                return;
            }
            if (row > 20 || row < 10 || column > 30 || column < 10)
            {
                MessageBox.Show("Number of row is less than 20 and greater than 10\nNumber of column is less than 30 and greater than 10"
                    , "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sizePanel.txtRow.Text = Config.NUMBER_OF_ROW.ToString();
                sizePanel.txtColumn.Text = Config.NUMBER_OF_COLUMN.ToString();
                return;
            }
            DialogResult result = MessageBox.Show("This action will make a new game\nAre you sure?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Config.NUMBER_OF_ROW = row;
                Config.NUMBER_OF_COLUMN = column;
                this.Close();
                caroManager.NewGameHandle(caroManager.Turn);
            }
        }
    }
}

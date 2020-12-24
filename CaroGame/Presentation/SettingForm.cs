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
            InitializeController();
            DrawSettingForm(this);
            this.FormClosing += SettingForm_FormClosing;
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) mainForm.timer.Start();
        }

        private void ButStatusTime_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if (but.Text == "Off Timer")
            {
                but.Text = "On Timer";
                txtSTimeTurn.Enabled = false;
                txtSTimeInterval.Enabled = false;
                lblSTimeTurn.Enabled = false;
                lblSTimeInterval.Enabled = false;
            }
            else
            {
                but.Text = "Off Timer";
                txtSTimeTurn.Enabled = true;
                txtSTimeInterval.Enabled = true;
                lblSTimeTurn.Enabled = true;
                lblSTimeInterval.Enabled = true;
            }
        }

        private void ButTimer_Click(object sender, EventArgs e)
        {
            DrawTimeSettingForm(this);
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
            DrawSettingForm(this);
        }

        private void ButNamePlayer_Click(object sender, EventArgs e)
        {
            DrawPlayerForm(this, Config.NAME.PLAYER_SETTING);
        }

        private void SettingPanel_SaveBut_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) mainForm.timer.Start();
        }

        private void ButSound_Click(object sender, EventArgs e)
        {
            DrawSoundSettingForm(this);
        }

        private void ButSizeBoard_Click(object sender, EventArgs e)
        {
            DrawSizeSettingForm(this);
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            string currentForm = Config.caroFlow.Peek();
            if (currentForm == Config.NAME.TIME_SETTING)
            {
                if (butStatusTime.Text == "Off Timer")
                {
                    int timeTurn = 0, interval = 0;
                    bool check1 = Int32.TryParse(txtSTimeTurn.Text, out timeTurn);
                    bool check2 = Int32.TryParse(txtSTimeInterval.Text, out interval);
                    if (!check1 || !check2)
                    {
                        MessageBox.Show("Must be enter integer", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSTimeTurn.Text = Config.TIME_TURN.ToString();
                        txtSTimeInterval.Text = Config.INTERVAL.ToString();
                        return;
                    }
                    if (timeTurn <= 0 || timeTurn < interval || timeTurn > 30)
                    {
                        MessageBox.Show("time turn is the integer within 0 and 30 and less than interval", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSTimeTurn.Text = Config.TIME_TURN.ToString();
                        txtSTimeInterval.Text = Config.INTERVAL.ToString();
                        return;
                    }
                    Config.IS_ON_TIMER = true;
                    Config.TIME_TURN = timeTurn;
                    Config.INTERVAL = interval;
                    mainForm.lblTime.Text = Config.TIME_TURN.ToString();
                }
                else
                {
                    Config.IS_ON_TIMER = false;
                    mainForm.lblTime.Text = "No Timer";
                }
                DrawSettingForm(this);
            }
            else if (currentForm == Config.NAME.SIZE_SETTING)
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
            //else if (currentForm == Config.NAME.PLAYER && Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.TWO_PLAYER)
            //{
            //    string namePlayer1 = txtName1Row.Text;
            //    string namePlayer2 = txtName2Column.Text;
            //    if (string.IsNullOrEmpty(namePlayer1) || string.IsNullOrEmpty(namePlayer2))
            //    {
            //        MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtName1Row.Text = Config.NAME_PLAYER1;
            //        txtName2Column.Text = Config.NAME_PLAYER2;
            //        return;
            //    }
            //    if (namePlayer1 == namePlayer2)
            //    {
            //        MessageBox.Show("Wrong", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtName1Row.Text = Config.NAME_PLAYER1;
            //        txtName2Column.Text = Config.NAME_PLAYER2;
            //        return;
            //    }
            //    Config.NAME_PLAYER1 = namePlayer1;
            //    Config.NAME_PLAYER2 = namePlayer2;
            //    caroManager.NewGameHandle(0);
            //    //if (Config.IS_ON_TIMER) timer.Start();
            //}
            //else if (currentForm == Config.NAME.PLAYER && Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN)
            //{
            //    string namePlayer = txtName1Row.Text;
            //    if (string.IsNullOrEmpty(namePlayer))
            //    {
            //        MessageBox.Show("Must be enter your name", "WRONG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtName1Row.Text = Config.NAME_PLAYER1;
            //        return;
            //    }
            //    Config.NAME_PLAYER1 = namePlayer;
            //    DrawLANForm(this);
            //}
            else if (currentForm == Config.NAME.PLAYER_SETTING)
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
                settingForm.DrawSettingForm(settingForm);
            }
            else if (currentForm == Config.NAME.LAN_CONNECTION) caroManager.NewGameHandle(0);
            else if (currentForm == Config.NAME.SOUND_SETTING)
            {
                Config.VOLUME_SIZE = (int)settingForm.numSound.Value;
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
                DrawSettingForm(this);
            }
        }
    }
}

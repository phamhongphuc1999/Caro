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

using static CaroGame.Program;
using CaroGame.Configuration;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    public partial class SettingForm : BaseForm
    {
        public SettingForm(string formText, Icon icon): base(formText, icon)
        {
            DrawCommonSetting();
            DrawSoundSetting();
            DrawTimeSetting();
            DrawPlayerNamePanel();
            DrawSettingSize();
            DrawGameMode();

            this.SetCurrentPanel(settingPnl);
        }

        private void SettingPnl_SaveGameClickEvent(object sender, EventArgs e)
        {

        }

        private void SettingPnl_LoadGameClickEvent(object sender, EventArgs e)
        {
        }

        private void SettingPnl_SoundClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(soundPanel);
        }

        private void SettingPnl_SizeClickEvent(object sender, EventArgs e)
        {
            settingSizePanel.Text1 = Config.NUMBER_OF_ROW.ToString();
            settingSizePanel.Text2 = Config.NUMBER_OF_COLUMN.ToString();
            SetCurrentPanel(settingSizePanel);
        }

        private void SettingPnl_NamePlayerClickEvent(object sender, EventArgs e)
        {
            playerNamePanel.Text1 = Config.NAME_PLAYER1.ToString();
            playerNamePanel.Text2 = Config.NAME_PLAYER2.ToString();
            SetCurrentPanel(playerNamePanel);
        }

        private void SettingPnl_TimerClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(timePanel);
        }

        private void SettingPnl_GameModeClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(gameModePanel);
        }

        private void SettingPnl_CancelActionClickEvent(object sender, EventArgs e)
        {
        }

        private void SettingPnl_NextActionClickEvent(object sender, EventArgs e)
        {
        }

        private void SoundPanel_CancelActionClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(settingPnl);
        }

        private void SoundPanel_NextActionClickEvent(object sender, EventArgs e)
        {
        }

        private void SettingSizePanel_CancelActionClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(settingPnl);
        }

        private void SettingSizePanel_NextActionClickEvent(object sender, EventArgs e)
        {
            (bool, string) info = settingSizePanel.IsValid();
            if(!info.Item1)
            {
                MessageBox.Show(info.Item2, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                settingSizePanel.Text1 = Config.NUMBER_OF_ROW.ToString();
                settingSizePanel.Text2 = Config.NUMBER_OF_COLUMN.ToString();
                return;
            }
            int numberOfRow = Int32.Parse(settingSizePanel.Text1);
            int numberOfColumn = Int32.Parse(settingSizePanel.Text2);
            this.Hide();
            caroManager.ResizeCaroBoard(numberOfRow, numberOfColumn);
        }

        private void TimePanel_CancelActionClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(settingPnl);
        }

        private void TimePanel_NextActionClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(settingPnl);
        }

        private void PlayerNamePanel_CancelActionClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(settingPnl);
        }

        private void PlayerNamePanel_NextActionClickEvent(object sender, EventArgs e)
        {
            (bool, string) info = playerNamePanel.IsValid();
            if (!info.Item1)
            {
                MessageBox.Show(info.Item2, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                playerNamePanel.Text1 = Config.NAME_PLAYER1.ToString();
                playerNamePanel.Text2 = Config.NAME_PLAYER2.ToString();
                return;
            }
            Config.NAME_PLAYER1 = playerNamePanel.Text1;
            Config.NAME_PLAYER2 = playerNamePanel.Text2;
            caroManager.SetPlayerName(playerNamePanel.Text1, playerNamePanel.Text2);
            this.Hide();
        }

        private void GameModePanel_CancelActionClickEvent(object sender, EventArgs e)
        {
            SetCurrentPanel(settingPnl);
        }

        private void GameModePanel_LoadGameClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePanel_LanModeClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePanel_AIModeClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePanel_TwoPlayerClickEvent(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Hành động này sẽ tạo một trò chơi mới\n Bạn có muốn tiếp tục?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                caroManager.CreateNewGame();
                this.Hide();
            }
        }
    }
}

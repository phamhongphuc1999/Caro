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

using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views.Components.SettingComponents
{
    public class PlayerSettingPanel: BaseSettingPanel
    {
        protected CaroTextBox player1Tb, player2Tb;
        protected Label lbl1, lbl2;

        public PlayerSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize, isSave)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
            this.VisibleChanged += PlayerSettingPanel_VisibleChanged;
        }

        protected override void DrawBasePanel()
        {
            base.DrawBasePanel();
            lbl1 = new Label
            {
                Size = new Size(80, 45),
                Location = new Point(30, 85),
                Text = Constants.PLAYER1_DEFAULT_NAME
            };
            lbl2 = new Label()
            {
                Size = new Size(80, 45),
                Location = new Point(30, 170),
                Text = Constants.PLAYER2_DEFAULT_NAME
            };
            player1Tb = new CaroTextBox()
            {
                TextWidth = 360,
                Size = new Size(400, 80),
                Location = new Point(120, 85),
                RequiredText = "Invalide text",
                ValidateText = (text) =>
                {
                    if (string.IsNullOrEmpty(text)) return false;
                    if (!string.IsNullOrEmpty(player2Tb.InfoText))
                    {
                        if (text.Equals(player2Tb.InfoText)) return false;
                    }
                    return true;
                }
            };
            player2Tb = new CaroTextBox()
            {
                TextWidth = 360,
                Location = new Point(120, 170),
                Size = new Size(400, 80),
                RequiredText = "Invalide text",
                ValidateText = (text) =>
                {
                    if (string.IsNullOrEmpty(text)) return false;
                    if (!string.IsNullOrEmpty(player1Tb.InfoText))
                    {
                        if (text.Equals(player1Tb.InfoText)) return false;
                    }
                    return true;
                }
            };
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(player1Tb);
            this.Controls.Add(player2Tb);
        }

        protected override void SaveBut_Click(object sender, EventArgs e)
        {
            SettingConfig.PlayerOption = true;
            TempConfig.NamePlayer1 = player1Tb.InfoText;
            TempConfig.NamePlayer2 = player2Tb.InfoText;
            settingRoutes.Routing(Constants.MAIN_SETTING);
        }

        protected override void CancelBut_Click(object sender, EventArgs e)
        {
            SettingConfig.PlayerOption = false;
            settingRoutes.Routing(Constants.MAIN_SETTING);
        }

        private void PlayerSettingPanel_VisibleChanged(object sender, EventArgs e)
        {
            Panel mainPanel = sender as Panel;
            if(mainPanel != null)
            {
                if (mainPanel.Visible)
                {
                    player1Tb.InfoText = playerManager.PlayerName1;
                    player2Tb.InfoText = playerManager.PlayerName2;
                }
            }
        }
    }
}

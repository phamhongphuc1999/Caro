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

namespace CaroGame.Views.Components
{
    public class PlayerPanel : BaseCaroPanel
    {
        protected CaroTextBox player1Tb, player2Tb;
        protected Label lbl1, lbl2;
        protected CaroButton backBut, nextBut;

        public PlayerPanel(bool isAutoSize) : base(isAutoSize)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        protected override void DrawBasePanel()
        {
            lbl1 = new Label
            {
                Size = new Size(100, 45),
                Location = new Point(30, 85),
                Text = languageManager.GetString(Constants.PLAYER1_DEFAULT_NAME)
            };
            lbl2 = new Label()
            {
                Size = new Size(100, 45),
                Location = new Point(30, 170),
                Text = languageManager.GetString(Constants.PLAYER2_DEFAULT_NAME)
            };
            player1Tb = new CaroTextBox()
            {
                TextWidth = 360,
                Size = new Size(400, 80),
                Location = new Point(135, 85),
                RequiredText = languageManager.GetString("invalid"),
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
                Location = new Point(135, 170),
                Size = new Size(400, 80),
                RequiredText = languageManager.GetString("invalid"),
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
            backBut = new CaroButton()
            {
                Location = new Point(20, 300),
                Text = languageManager.GetString("back"),
                Size = new Size(70, 30)
            };
            nextBut = new CaroButton()
            {
                Location = new Point(455, 300),
                Text = languageManager.GetString("next"),
                Size = new Size(70, 30)
            };
            backBut.Click += BackBut_Click;
            nextBut.Click += NextBut_Click;
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(player1Tb);
            this.Controls.Add(player2Tb);
            this.Controls.Add(backBut);
            this.Controls.Add(nextBut);
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            routes.Routing(Constants.SIZE_SETTING);
        }

        private void NextBut_Click(object sender, EventArgs e)
        {
            if (player1Tb.TextValidate && player2Tb.TextValidate)
            {
                playerManager.PlayerName1 = player1Tb.InfoText;
                playerManager.PlayerName2 = player2Tb.InfoText;
                routes.Routing(Constants.MAIN);
            }
        }
    }
}

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

        public Action<object, EventArgs> NextClickEvent;

        public event EventHandler BackClickEvent
        {
            add
            {
                backBut.Click += value;
            }
            remove
            {
                backBut.Click -= value;
            }
        }

        public PlayerPanel()
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
        }

        protected override void DrawBasePanel()
        {
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
            backBut = new CaroButton()
            {
                Location = new Point(20, 300),
                Text = "Back",
                Size = new Size(70, 30)
            };
            nextBut = new CaroButton()
            {
                Location = new Point(455, 300),
                Text = "Next",
                Size = new Size(70, 30)
            };
            nextBut.Click += NextBut_Click;
            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(player1Tb);
            this.Controls.Add(player2Tb);
            this.Controls.Add(backBut);
            this.Controls.Add(nextBut);
        }

        private void NextBut_Click(object sender, EventArgs e)
        {
            if (player1Tb.TextValidate && player2Tb.TextValidate)
            {
                playerManager.SetPlayerName(player1Tb.InfoText, Constants.PLAYER1);
                playerManager.SetPlayerName(player2Tb.InfoText, Constants.PLAYER2);
                NextClickEvent(sender, e);
            }
        }
    }
}

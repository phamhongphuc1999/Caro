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
using CaroGame.Entities;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views.Components.SettingComponents
{
    public class LoadGamePanel : BaseSettingPanel
    {
        private bool isSetting;
        public LoadGamePanel(bool isAutoSize, bool isSave, bool isSetting) : base(isAutoSize, isSave)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            this.isSetting = isSetting;
            DrawBasePanel();
            this.VisibleChanged += LoadGamePanel_VisibleChanged;
        }

        protected override void DrawBasePanel()
        {
            base.DrawBasePanel();
        }

        protected override void CancelBut_Click(object sender, EventArgs e)
        {
            if (isSetting) settingRoutes.Routing(Constants.MAIN_SETTING);
            else routes.Routing(Constants.GAME_MODE);
        }

        private void LoadGamePanel_VisibleChanged(object sender, EventArgs e)
        {
            int Y = 40, count = 1;
            this.Controls.Clear();
            if (storageManager.Count == 0)
            {
                Label info = new Label()
                {
                    Text = languageManager.GetString("nothingMessage"),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Size = new Size(200, 30),
                    Location = new Point(120, Y)
                };
                Y += 60;
                this.Controls.Add(info);
            }
            else
            {
                foreach (GameSaveData item in storageManager.GameSaveList)
                {
                    string butText = count.ToString() + "." + item.PlayerName1 + " vs " + item.PlayerName2;
                    Button butGame = new Button()
                    {
                        Tag = count,
                        Text = butText,
                        Size = new Size(280, 40),
                        Location = new Point(30, Y)
                    };
                    Button buttonDelete = new Button()
                    {
                        Tag = count,
                        Text = "X",
                        Size = new Size(40, 40),
                        Location = new Point(310, Y)
                    };
                    butGame.Click += ButGame_Click;
                    buttonDelete.Click += ButtonDelete_Click;
                    this.Controls.Add(butGame);
                    this.Controls.Add(buttonDelete);
                    Y += 60; count++;
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void ButGame_Click(object sender, EventArgs e)
        {
            if (isSetting)
            {
                DialogResult choose = MessageBox.Show("123", "Thong bao", MessageBoxButtons.OKCancel);
                if (choose == DialogResult.Cancel) return;
            }
            Button but = sender as Button;
            int count = (int)but.Tag;
            GameSaveData data = storageManager.GameSaveList[count - 1];
            SettingConfig.Rows = data.Row;
            SettingConfig.Columns = data.Column;
            SettingConfig.BoardPattern = data.CaroBoard;
            playerManager.PlayerName1 = data.PlayerName1;
            playerManager.PlayerName2 = data.PlayerName2;
            playerManager.Turn = data.Turn;
            actionManager.ResetAction();
            caroBoardManager.InitCaroBoard();
            caroBoardManager.DrawCaroBoard();
            winnerManager.LoadSaveGame(data.Turn, data.CaroBoard);
            if (isSetting)
            {
                Control parent = this.Parent;
                parent.Hide();
            }
            else routes.Routing(Constants.MAIN);
        }
    }
}

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
using System.Linq;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.Views.Components.SettingComponents
{
    public class LoadGamePanel : BaseSettingPanel
    {
        private bool isSetting;
        private Panel containerPnl;

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
            containerPnl = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(Constants.WIDTH_STANDARD, 300)
            };
            this.Controls.Add(containerPnl);
        }

        protected override void CancelBut_Click(object sender, EventArgs e)
        {
            if (isSetting) settingRoutes.Routing(Constants.MAIN_SETTING);
            else routes.Routing(Constants.GAME_MODE);
        }

        private void LoadGamePanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                int Y = 40, count = 1;
                containerPnl.Controls.Clear();
                if (CaroService.Storage.GameList.Count == 0)
                {
                    Label info = new Label()
                    {
                        Text = CaroService.Language.GetString("nothingMessage"),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(200, 30),
                        Location = new Point(172, Y)
                    };
                    Y += 60;
                    containerPnl.Controls.Add(info);
                }
                else
                {
                    foreach (GameSaveData item in CaroService.Storage.GameList)
                    {
                        string butText = count.ToString() + "." + item.PlayerName1 + " vs " + item.PlayerName2;
                        Button butGame = new Button()
                        {
                            Tag = item.id,
                            Text = butText,
                            Size = new Size(445, 40),
                            Location = new Point(30, Y)
                        };
                        Button buttonDelete = new Button()
                        {
                            Tag = item.id,
                            Text = "X",
                            Size = new Size(40, 40),
                            Location = new Point(475, Y)
                        };
                        butGame.Click += ButGame_Click;
                        buttonDelete.Click += ButtonDelete_Click;
                        containerPnl.Controls.Add(butGame);
                        containerPnl.Controls.Add(buttonDelete);
                        Y += 60; count++;
                    }
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            int id = (int)but.Tag;
            CaroService.Storage.DeleteGame(id);
            LoadGamePanel_VisibleChanged(this, new EventArgs());
        }

        private void ButGame_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            int id = (int)but.Tag;
            GameSaveData data = CaroService.Storage.GameList.SingleOrDefault(x => x.id == id);
            if (data != null)
            {
                CaroService.Storage.CurrentIndex = id;
                SettingConfig.InitializeGameSaveSetting(data);
                CaroService.Player.PlayerName1 = data.PlayerName1;
                CaroService.Player.PlayerName2 = data.PlayerName2;
                CaroService.Player.Turn = data.Turn;
                CaroService.Action.ResetAction();
                CaroService.Board.InitCaroBoard();
                CaroService.Board.DrawCaroBoard();
                CaroService.Winner.LoadSaveGame(data.Turn, data.CaroBoard);
                if (isSetting)
                {
                    Control parent = this.Parent;
                    parent.Hide();
                }
                else routes.Routing(Constants.MAIN);
            }
            else MessageBox.Show("Not Found Your Game", "Thông Báo", MessageBoxButtons.OK);
        }
    }
}

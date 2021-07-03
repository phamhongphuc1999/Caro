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
    public class GameModePanel : BaseCaroPanel
    {
        protected CaroButton twoPlayerBut, lanModeBut, aiModeBut, loadgameBut;
        protected CaroButton backBut;
        protected Label orLbl;

        public GameModePanel(bool isAutoSize) : base(isAutoSize)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        protected override void DrawBasePanel()
        {
            twoPlayerBut = new CaroButton()
            {
                Text = languageManager.GetString("twoPlayerMode"),
                Size = new Size(130, 40),
                Location = new Point(22, 45)
            };
            lanModeBut = new CaroButton()
            {
                Text = languageManager.GetString("lanMode"),
                Size = new Size(130, 40),
                Location = new Point(202, 45)
            };
            aiModeBut = new CaroButton()
            {
                Text = languageManager.GetString("aiMode"),
                Size = new Size(130, 40),
                Location = new Point(382, 45)
            };
            orLbl = new Label()
            {
                Text = languageManager.GetString("or"),
                Size = new Size(60, 20),
                Location = new Point(260, 147)
            };
            loadgameBut = new CaroButton()
            {
                Location = new Point(202, 200),
                Text = languageManager.GetString("loadGame"),
                Size = new Size(130, 40)
            };
            backBut = new CaroButton()
            {
                Location = new Point(20, 300),
                Text = languageManager.GetString("back"),
                Size = new Size(70, 30)
            };
            twoPlayerBut.Click += TwoPlayerBut_Click;
            lanModeBut.Click += LanModeBut_Click;
            aiModeBut.Click += AiModeBut_Click;
            loadgameBut.Click += LoadgameBut_Click;
            backBut.Click += BackBut_Click;
            this.Controls.Add(twoPlayerBut);
            this.Controls.Add(lanModeBut);
            this.Controls.Add(aiModeBut);
            this.Controls.Add(orLbl);
            this.Controls.Add(loadgameBut);
            this.Controls.Add(backBut);
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            routes.Routing(Constants.OVERVIEW);
        }

        private void LoadgameBut_Click(object sender, EventArgs e)
        {
            
        }

        private void AiModeBut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa có chức năng này");
        }

        private void LanModeBut_Click(object sender, EventArgs e)
        {
            
        }

        private void TwoPlayerBut_Click(object sender, EventArgs e)
        {
            SettingConfig.GameMode = Constants.TWO_PLAYER_GAME_MODE;
            routes.Routing(Constants.SIZE_SETTING);
        }
    }
}

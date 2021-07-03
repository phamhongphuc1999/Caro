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
    public class SizePanel : BaseCaroPanel
    {
        protected CaroButton backBut, nextBut;
        private Button currentBut;

        public SizePanel(bool isAutoSize) : base(isAutoSize)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            currentBut = new Button();
            DrawBasePanel();
        }

        private void DrawSizeButtonPanel()
        {
            int index = 0;
            int Y = 20;
            foreach ((int, int) size in Constants.CARO_SIZE)
            {
                int X = 29 + 129 * index;
                if (X > Constants.WIDTH_STANDARD)
                {
                    index = 0;
                    X = 29;
                    Y += 80;
                }
                CaroButton button = new CaroButton
                {
                    Size = new Size(100, 60),
                    Font = new Font("Time New Roman", 15),
                    Location = new Point(X, Y),
                    Text = string.Format("{0} x {1}", size.Item1, size.Item2)
                };
                button.Click += (sender, e) =>
                {
                    SettingConfig.Columns = size.Item1;
                    SettingConfig.Rows = size.Item2;
                    if (currentBut != null) currentBut.FlatStyle = FlatStyle.Flat;
                    Button but = sender as Button;
                    if (but != null)
                    {
                        currentBut = but;
                        currentBut.FlatStyle = FlatStyle.Standard;
                    }
                };
                this.Controls.Add(button);
                index++;
            }
        }

        protected override void DrawBasePanel()
        {
            DrawSizeButtonPanel();
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
            this.Controls.Add(backBut);
            this.Controls.Add(nextBut);
        }

        private void NextBut_Click(object sender, EventArgs e)
        {
            int rows = SettingConfig.Rows;
            int columns = SettingConfig.Columns;
            if (rows < 5 || rows > 25 || columns < 5 || columns > 25)
            {
                MessageBox.Show("Nhập số sai");
                SettingConfig.Rows = SettingConfig.Columns = 0;
                return;
            }
            else routes.Routing(Constants.PLAYER_SETTING);
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            routes.Routing(Constants.GAME_MODE);
        }
    }
}

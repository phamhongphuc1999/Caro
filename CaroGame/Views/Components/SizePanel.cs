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
        protected CaroButton backBut, nextBut, addBut, removeBut;
        private Panel containerPnl;

        public SizePanel(bool isAutoSize) : base(isAutoSize)
        {
            this.Size = new Size(700, 330);
            DrawBasePanel();
        }

        private void DrawSizeButtonPanel()
        {
            containerPnl = new Panel
            {
                Location = new Point(5, 5),
                Size = new Size(620, 320)
            };
            ResizePanel resizePanel = new ResizePanel(false, true)
            {
                Location = new Point(5, 5),
                Size = new Size(610, 310),
                BorderStyle = BorderStyle.FixedSingle,
                MaximumSize = new Size(620, 320),
                MinimumSize = new Size(20, 20),
                BackColor = Color.Red
            };
            containerPnl.Controls.Add(resizePanel);
            int X = 10, Y = 10;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Button but = new Button
                    {
                        Location = new Point(X, Y),
                        Size = new Size(20, 20)
                    };
                    but.Click += But_Click;
                    containerPnl.Controls.Add(but);
                    X += 20;
                }
                X = 10; Y += 20;
            }
            this.Controls.Add(containerPnl);
        }

        protected override void DrawBasePanel()
        {
            DrawSizeButtonPanel();
            addBut = new CaroButton
            {
                Location = new Point(630, 5),
                Text = "Add",
                Size = new Size(60, 30)
            };
            removeBut = new CaroButton
            {
                Location = new Point(630, 55),
                Text = "Remove",
                Size = new Size(60, 30)
            };
            backBut = new CaroButton()
            {
                Location = new Point(630, 105),
                Text = languageManager.GetString("back"),
                Size = new Size(60, 30)
            };
            nextBut = new CaroButton()
            {
                Location = new Point(630, 155),
                Text = languageManager.GetString("next"),
                Size = new Size(60, 30)
            };
            addBut.Click += AddBut_Click;
            removeBut.Click += RemoveBut_Click;
            backBut.Click += BackBut_Click;
            nextBut.Click += NextBut_Click;
            this.Controls.Add(addBut);
            this.Controls.Add(removeBut);
            this.Controls.Add(backBut);
            this.Controls.Add(nextBut);
        }

        private void RemoveBut_Click(object sender, EventArgs e)
        {

        }

        private void AddBut_Click(object sender, EventArgs e)
        {

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
            routes.Routing(Constants.PLAYER_SETTING);
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            routes.Routing(Constants.GAME_MODE);
        }

        private void But_Click(object sender, EventArgs e)
        {

        }
    }
}

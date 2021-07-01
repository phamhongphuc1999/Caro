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
using static CaroGame.Program;

namespace CaroGame.Views.Components
{
    public class OverviewPanel : BaseCaroPanel
    {
        protected CaroButton newGameBut, guideBut;

        public OverviewPanel(bool isAutoSize) : base(isAutoSize)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        protected override void DrawBasePanel()
        {
            newGameBut = new CaroButton()
            {
                Text = "New Game",
                Size = new Size(130, 50),
                Location = new Point(100, 155)
            };
            guideBut = new CaroButton()
            {
                Text = "Guide",
                Size = new Size(130, 50),
                Location = new Point(350, 155)
            };
            newGameBut.Click += NewGameBut_Click;
            guideBut.Click += GuideBut_Click;
            this.Controls.Add(newGameBut);
            this.Controls.Add(guideBut);
        }

        private void GuideBut_Click(object sender, EventArgs e)
        {
            
        }

        private void NewGameBut_Click(object sender, EventArgs e)
        {
            routes.Routing(Constants.GAME_MODE);
        }
    }
}

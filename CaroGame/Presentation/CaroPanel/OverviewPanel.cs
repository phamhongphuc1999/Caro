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

using CaroGame.Presentation.CaroButton;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class OverviewPanel: Panel
    {
        protected CaroButton1 newGameBut, guideBut;

        public event EventHandler NewGameClickEvent
        {
            add { newGameBut.Click += value; }
            remove { newGameBut.Click -= value; }
        }

        public event EventHandler GuideClickEvent
        {
            add { guideBut.Click += value; }
            remove { guideBut.Click -= value; }
        }

        public OverviewPanel() : base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {
            newGameBut = new CaroButton1()
            {
                Text = "New Game",
                Size = new Size(150, 65),
                Location = new Point(100, 155)
            };
            guideBut = new CaroButton1()
            {
                Text = "Guide",
                Size = new Size(150, 65),
                Location = new Point(350, 155)
            };
            this.Controls.Add(newGameBut);
            this.Controls.Add(guideBut);
        }
    }
}

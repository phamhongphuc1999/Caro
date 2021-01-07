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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class SoundPanel : Panel
    {
        protected Label soundLbl;
        protected NumericUpDown soundNud;
        protected RoutePanel routePanel;

        public SoundPanel() : base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public event EventHandler NextActionClickEvent
        {
            add
            {
                routePanel.NextActionClickEvent += value;
            }
            remove
            {
                routePanel.NextActionClickEvent -= value;
            }
        }

        public event EventHandler CancelActionClickEvent
        {
            add
            {
                routePanel.CancelActionClickEvent += value;
            }
            remove
            {
                routePanel.CancelActionClickEvent -= value;
            }
        }

        public void DrawBasePanel()
        {
            soundLbl = new Label()
            {
                Text = "Volume",
                Size = new Size(80, 40),
                Location = new Point(40, 100)
            };
            soundNud = new NumericUpDown()
            {
                Size = new Size(350, 30),
                Location = new Point(130, 100),
                Value = new decimal(Config.VOLUME_SIZE),
                Maximum = new decimal(100),
                Minimum = new decimal(0),
                ThousandsSeparator = true
            };
            routePanel = new RoutePanel()
            {
                Location = new Point(0, 280)
            };
            this.Controls.Add(soundLbl);
            this.Controls.Add(soundNud);
            this.Controls.Add(routePanel);
        }
    }
}

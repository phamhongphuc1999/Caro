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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation.CaroPanel
{
    public class LanPanel: TwoTextPanel
    {
        protected Button connectBut, ipBut;

        public event EventHandler ConnectButClickEvent
        {
            add
            {
                connectBut.Click += value;
            }
            remove
            {
                connectBut.Click -= value;
            }
        }

        public event EventHandler IPButClickEvent
        {
            add
            {
                ipBut.Click += value;
            }
            remove
            {
                ipBut.Click -= value;
            }
        }

        public LanPanel(): base()
        {
            this.Size = new Size(600, 375);
            DrawBasePanel();
        }

        public override (bool, string) IsValid()
        {
            return base.IsValid();
        }

        private void DrawBasePanel()
        {
            connectBut = new Button
            {
                Size = new Size(360, 35),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(120, 205),
                Text = "Connect"
            };
            ipBut = new Button()
            {
                Text = "Get IP",
                Size = new Size(80, 35),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(490, 85)
            };
            this.Controls.Add(connectBut);
            this.Controls.Add(ipBut);
        }
    }
}

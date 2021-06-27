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

namespace CaroGame.Views.Components.SettingComponents
{
    public class GameModeSettingPanel: BaseSettingPanel
    {
        protected CaroButton twoPlayerBut, lanModeBut, aiModeBut, loadgameBut;

        public event EventHandler TwoPlayerClickEvent
        {
            add
            {
                twoPlayerBut.Click += value;
            }
            remove
            {
                twoPlayerBut.Click -= value;
            }
        }

        public event EventHandler LanModeClickEvent
        {
            add
            {
                lanModeBut.Click += value;
            }
            remove
            {
                lanModeBut.Click -= value;
            }
        }

        public event EventHandler AIModeClickEvent
        {
            add
            {
                aiModeBut.Click += value;
            }
            remove
            {
                aiModeBut.Click -= value;
            }
        }

        public GameModeSettingPanel(): base(false)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
        }

        protected override void DrawBasePanel()
        {
            base.DrawBasePanel();
            twoPlayerBut = new CaroButton()
            {
                Text = "Two Player",
                Size = new Size(130, 40),
                Location = new Point(22, 100)
            };
            lanModeBut = new CaroButton()
            {
                Text = "LAN Mode",
                Size = new Size(130, 40),
                Location = new Point(202, 100)
            };
            aiModeBut = new CaroButton()
            {
                Name = "butModeAI",
                Text = "One Player",
                Size = new Size(130, 40),
                Location = new Point(382, 100)
            };
            this.Controls.Add(twoPlayerBut);
            this.Controls.Add(lanModeBut);
            this.Controls.Add(aiModeBut);
        }

        protected override void SaveBut_Click(object sender, EventArgs e)
        {
            SaveClickEvent(sender, e);
        }

        protected override void CancelBut_Click(object sender, EventArgs e)
        {
            CancelClickEvent(sender, e);
        }
    }
}

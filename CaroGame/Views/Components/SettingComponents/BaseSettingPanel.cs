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
    public class BaseSettingPanel : BaseCaroPanel
    {
        protected CaroButton cancelBut, saveBut;
        protected bool isSave;

        public BaseSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize)
        {
            this.isSave = isSave;
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
        }

        protected override void DrawBasePanel()
        {
            cancelBut = new CaroButton
            {
                Text = "Cancel",
                Size = new Size(70, 30)
            };
            saveBut = new CaroButton()
            {
                Location = new Point(455, 300),
                Text = "Save",
                Size = new Size(70, 30)
            };
            if (isSave) cancelBut.Location = new Point(380, 300);
            else
            {
                saveBut.Visible = false;
                cancelBut.Location = new Point(455, 300);
            }
            saveBut.Click += SaveBut_Click;
            cancelBut.Click += CancelBut_Click;
            this.Controls.Add(cancelBut);
            this.Controls.Add(saveBut);
        }

        protected virtual void CancelBut_Click(object sender, EventArgs e)
        {
            
        }

        protected virtual void SaveBut_Click(object sender, EventArgs e)
        {
            
        }
    }
}

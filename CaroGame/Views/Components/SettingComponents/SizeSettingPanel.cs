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

namespace CaroGame.Views.Components.SettingComponents
{
    public class SizeSettingPanel : BaseSettingPanel
    {
        public SizeSettingPanel(bool isAutoSize, bool isSave) : base(isAutoSize, isSave)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        protected override void DrawBasePanel()
        {
            
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

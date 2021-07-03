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
using System.Drawing;

namespace CaroGame.Views.Components
{
    public class LanPanel: BaseCaroPanel
    {
        public LanPanel(bool isAutoSize) : base(isAutoSize)
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        protected override void DrawBasePanel()
        {
            
        }
    }
}

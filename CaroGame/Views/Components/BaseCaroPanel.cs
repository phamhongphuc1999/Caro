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

using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class BaseCaroPanel : Panel
    {
        public BaseCaroPanel(bool isAutoSize) : base()
        {
            if (isAutoSize)
            {
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
        }

        protected virtual void DrawBasePanel()
        {
        }
    }
}

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

using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Controls
{
    public class CaroButton: Button
    {
        public CaroButton() : base()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = ColorTranslator.FromHtml("#8BC4FC");
        }
    }
}

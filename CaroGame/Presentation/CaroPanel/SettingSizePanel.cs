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

namespace CaroGame.Presentation.CaroPanel
{
    public class SettingSizePanel: TwoTextPanel
    {
        public SettingSizePanel() : base()
        {
            this.LabelText1 = "Hàng";
            this.LabelText2 = "Cột";
        }

        public override (bool, string) IsValid()
        {
            return base.IsValid();
        }
    }
}

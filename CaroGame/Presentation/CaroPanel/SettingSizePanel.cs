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
            int column, row;
            bool check1 = Int32.TryParse(txt1.Text, out column);
            bool check2 = Int32.TryParse(txt2.Text, out row);
            if (!check1 || !check2) return (false, "Yêu cầu nhập số");
            if (column < 5 || column > 30 || row < 5 || row > 30)
                return (false, "Tràn số");
            return (true, "");
        }
    }
}

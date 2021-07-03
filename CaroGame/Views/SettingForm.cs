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

namespace CaroGame.Views
{
    public partial class SettingForm : BaseForm
    {
        public SettingForm(string title, Icon icon) : base(title, icon)
        {
        }

        protected override void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}

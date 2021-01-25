﻿// --------------------CARO  GAME-----------------
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
using System.Diagnostics;
using System.Drawing;

namespace CaroGame.Presentation
{
    public partial class AboutForm : BaseForm
    {
        public AboutForm(string formText, Icon icon): base(formText, icon)
        {
            this.Size = new Size(400, 250);
            InitializeController();
        }

        private void GitLlbl_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/phamhongphuc1999/Caro");
        }
    }
}

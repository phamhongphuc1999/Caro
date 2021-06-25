﻿using System;
using System.Diagnostics;
using System.Drawing;

namespace CaroGame.Views
{
    public partial class AboutForm : BaseForm
    {
        public AboutForm(string title, Icon icon): base(title, icon)
        {
            InitializeComponent(title, icon);
            InitializeController();
        }

        private void GitLlbl_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/phamhongphuc1999/Caro");
        }
    }
}

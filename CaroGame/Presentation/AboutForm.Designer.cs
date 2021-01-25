﻿using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    partial class AboutForm
    {
        private RichTextBox rtbAbout;
        private LinkLabel gitLlbl;

        public void InitializeController()
        {
            rtbAbout = new RichTextBox()
            {
                Name = "rtbAbout",
                Text = "\n" +
                "          Devepoler: Phạm Hồng Phúc\n" +
                "          Country: Việt Nam\n" +
                "          Game: Caro Game\n" +
                "          Version: v2.0",
                Size = new Size(400, 150),
                Location = new Point(0, 0),
                Enabled = false
            };
            gitLlbl = new LinkLabel
            {
                BackColor = Color.Red,
                ForeColor = Color.Green,
                Text = "github",
                Size = new Size(400, 50),
                Location = new Point(0, 150)
            };
            gitLlbl.Click += GitLlbl_Click;
            this.Controls.Add(rtbAbout);
            this.Controls.Add(gitLlbl);
        }
    }
}
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

namespace CaroGame.Presentation
{
    public partial class BaseForm : Form
    {
        private Panel currentPnl;

        public BaseForm(string formText, Icon icon)
        {
            InitializeComponent(formText, icon);
        }

        protected Panel CurrentPnl
        {
            get
            {
                return currentPnl;
            }
        }

        protected void SetCurrentPanel(Panel panel)
        {
            if (currentPnl != null)
                currentPnl.Visible = false;
            currentPnl = panel;
            currentPnl.Visible = true;
        }

        protected void SetCurrentPanel(Panel panel, string title)
        {
            SetCurrentPanel(panel);
            this.Text = title;
        }

        protected void AddFit(Panel panel)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = panel.Size;
            this.Controls.Add(panel);
        }
    }
}

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
using static CaroGame.Program;

namespace CaroGame.Presentation
{
    public partial class BaseForm : Form
    {
        protected Panel currentPnl;

        public BaseForm(string formText, Icon icon)
        {
            InitializeComponent(formText, icon);
            this.FormClosing += BaseForm_FormClosing;
        }

        public Panel CurrentPnl
        {
            get
            {
                return currentPnl;
            }
        }

        public void SetCurrentPanel(Panel panel)
        {
            if (currentPnl != null)
                currentPnl.Visible = false;
            currentPnl = panel;
            currentPnl.Visible = true;
        }

        public void SetCurrentPanel(Panel panel, string title)
        {
            SetCurrentPanel(panel);
            this.Text = title;
        }

        protected Point SetCenterLocation(Point baseLocation, Size baseSize, Size size)
        {
            int setY = (baseSize.Height - size.Height) / 2;
            int setX = (baseSize.Width - size.Width) / 2;
            return new Point(baseLocation.X - setX, baseLocation.Y - setY);
        }

        public void Show(Form baseForm)
        {
            this.Location = SetCenterLocation(baseForm.Location, baseForm.Size, this.Size);
            this.Show();
        }

        public void ShowDialog(Form baseForm)
        {
            Point point = SetCenterLocation(baseForm.Location, baseForm.Size, this.Size);
            this.Location = new Point(point.X, point.Y);
            this.ShowDialog();
        }

        protected void AddFit(Panel panel)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = panel.Size;
            this.Controls.Add(panel);
        }

        protected virtual void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            storageManager.SaveGameToFile();
            Application.Exit();
        }
    }
}

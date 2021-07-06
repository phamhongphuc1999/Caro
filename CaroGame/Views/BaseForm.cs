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

namespace CaroGame.Views
{
    public partial class BaseForm : Form
    {
        public BaseForm(string title, Icon icon)
        {
            InitializeComponent(title, icon);
            this.FormClosing += BaseForm_FormClosing;
        }

        protected virtual void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ApplicationExit();
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
            this.Location = SetCenterLocation(baseForm.Location, baseForm.Size, this.Size);
            this.ShowDialog();
        }
    }
}

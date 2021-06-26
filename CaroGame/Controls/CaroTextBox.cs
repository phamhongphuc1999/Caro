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
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Controls
{
    public partial class CaroTextBox : UserControl
    {
        public Func<string, bool> ValidateText;
        public string InfoText
        {
            get { return baseTextBox.Text; }
            set { baseTextBox.Text = value; }
        }

        public string RequiredText
        {
            get { return requiredLbl.Text; }
            set { requiredLbl.Text = value; }
        }

        public int TextWidth
        {
            get { return baseTextBox.Width; }
            set { baseTextBox.Width = value; }
        }

        public bool TextValidate
        {
            get { return !requiredLbl.Visible; }
        }

        public CaroTextBox()
        {
            InitializeComponent();
            baseTextBox.TextChanged += BaseTextBox_TextChanged;
        }

        private void BaseTextBox_TextChanged(object sender, EventArgs e)
        {
            BaseTextBox baseText = sender as BaseTextBox;
            if (baseText != null)
            {
                if (ValidateText == null) return;
                if (!ValidateText(baseText.Text))
                {
                    baseText.BorderColor = Color.Red;
                    requiredLbl.Visible = true;
                }
                else
                {
                    baseText.BorderColor = Color.Blue;
                    requiredLbl.Visible = false;
                }
            }
        }
    }
}

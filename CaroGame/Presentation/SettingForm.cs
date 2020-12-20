// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Presentation
{
    public partial class SettingForm : BaseForm
    {
        public SettingForm(string formText, Icon icon): base(formText, icon)
        {
            InitializeController();
            DrawSettingForm(this);
            this.FormClosing += SettingForm_FormClosing;
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Config.IS_ON_TIMER && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) timer.Start();
        }

        private void ButStatusTime_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if (but.Text == "Off Timer")
            {
                but.Text = "On Timer";
                txtSTimeTurn.Enabled = false;
                txtSTimeInterval.Enabled = false;
                lblSTimeTurn.Enabled = false;
                lblSTimeInterval.Enabled = false;
            }
            else
            {
                but.Text = "Off Timer";
                txtSTimeTurn.Enabled = true;
                txtSTimeInterval.Enabled = true;
                lblSTimeTurn.Enabled = true;
                lblSTimeInterval.Enabled = true;
            }
        }

        private void ButTimer_Click(object sender, EventArgs e)
        {
            DrawTimeSettingForm(this);
        }

        private void ButGameMode_Click(object sender, EventArgs e)
        {
            DrawSettingForm(this);
        }
    }
}

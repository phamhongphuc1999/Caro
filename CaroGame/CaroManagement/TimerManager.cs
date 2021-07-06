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

using CaroGame.Configuration;
using CaroGame.Views.Components;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    public class TimerManager
    {
        private Label timeLbl;
        private Timer caroTimer;
        private int count;

        public TimerManager()
        {
            caroTimer = new Timer
            {
                Interval = SettingConfig.Interval
            };
            caroTimer.Tick += CaroTimer_Tick;
        }

        private void CaroTimer_Tick(object sender, System.EventArgs e)
        {
            count = count - 1;
            if (count < 0) caroTimer.Stop();
            timeLbl.Text = count.ToString();
        }

        public void InitMainView(MainPanel mainView)
        {
            timeLbl = mainView.timeLbl;
        }

        public void StartTimer(bool reset)
        {
            if (!caroTimer.Enabled && SettingConfig.IsTime)
            {
                caroTimer.Start();
                count = SettingConfig.TimeTurn;
                if (reset) timeLbl.Text = count.ToString();
            }
        }

        public void StopTimer(bool reset)
        {
            if (caroTimer.Enabled)
            {
                caroTimer.Stop();
                if (reset) timeLbl.Text = "";
            }
        }

        public void TurnTimer()
        {
            timeLbl.Text = count.ToString();
        }
    }
}

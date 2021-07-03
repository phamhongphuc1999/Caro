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

        }

        public void InitMainView(MainPanel mainView)
        {
            timeLbl = mainView.timeLbl;
        }

        public void StartTimer()
        {
            if (!caroTimer.Enabled) caroTimer.Start();
        }

        public void StopTimer()
        {
            if (caroTimer.Enabled) caroTimer.Stop();
        }
    }
}

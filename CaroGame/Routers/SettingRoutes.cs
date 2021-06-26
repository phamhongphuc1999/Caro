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
using CaroGame.Views;
using CaroGame.Views.Components;
using CaroGame.Views.Components.SettingComponents;
using System;

namespace CaroGame.Routers
{
    public class SettingRoutes : BaseRoutes
    {
        public MainSettingPanel MainSettingView
        {
            get; set;
        }
        public PlayerPanel PlayerView
        {
            get; set;
        }
        public SizePanel SizeView
        {
            get; set;
        }

        public SettingRoutes(SettingForm viewForm) : base()
        {
            MainSettingView = new MainSettingPanel { Visible = false };
            PlayerView = new PlayerPanel { Visible = false };
            SizeView = new SizePanel { Visible = false };
            viewForm.Controls.Add(MainSettingView);
            viewForm.Controls.Add(PlayerView);
            viewForm.Controls.Add(SizeView);
        }

        public void Routing(string router)
        {
            if (router.Equals(Constants.MAIN_SETTING)) SetCurrentControl(MainSettingView);
            else if (router.Equals(Constants.PLAYER_SETTING)) SetCurrentControl(PlayerView);
            else if (router.Equals(Constants.SIZE_SETTING)) SetCurrentControl(SizeView);
            else throw new Exception();
        }
    }
}

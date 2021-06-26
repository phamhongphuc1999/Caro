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
using CaroGame.Routers;
using System;
using System.Drawing;

namespace CaroGame.Views
{
    public partial class SettingForm : BaseForm
    {
        private SettingRoutes settingRoutes;

        public SettingForm(string title, Icon icon) : base(title, icon)
        {
            CreateRoute();
            HandleEvent();
        }

        private void CreateRoute()
        {
            settingRoutes = new SettingRoutes(this);
            settingRoutes.Routing(Constants.MAIN_SETTING);
        }

        private void HandleEvent()
        {
            settingRoutes.MainSettingView.GameModeClickEvent += MainSettingView_GameModeClickEvent;
            settingRoutes.MainSettingView.TimerClickEvent += MainSettingView_TimerClickEvent;
            settingRoutes.MainSettingView.PlayerClickEvent += MainSettingView_PlayerClickEvent;
            settingRoutes.MainSettingView.SizeClickEvent += MainSettingView_SizeClickEvent;
            settingRoutes.MainSettingView.SoundClickEvent += MainSettingView_SoundClickEvent;
            settingRoutes.MainSettingView.LanguageClickEvent += MainSettingView_LanguageClickEvent;
            settingRoutes.MainSettingView.LoadGameClickEvent += MainSettingView_LoadGameClickEvent;
            settingRoutes.MainSettingView.SaveGameClickEvent += MainSettingView_SaveGameClickEvent;
            settingRoutes.MainSettingView.PermitClickEvent += MainSettingView_PermitClickEvent;
            settingRoutes.MainSettingView.CancelClickEvent += MainSettingView_CancelClickEvent;
        }

        #region Main Setting
        private void MainSettingView_CancelClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_PermitClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_SaveGameClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_LoadGameClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_LanguageClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_SoundClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_SizeClickEvent(object sender, EventArgs e)
        {
            settingRoutes.Routing(Constants.SIZE_SETTING);
        }

        private void MainSettingView_PlayerClickEvent(object sender, EventArgs e)
        {
            settingRoutes.Routing(Constants.PLAYER_SETTING);
        }

        private void MainSettingView_TimerClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_GameModeClickEvent(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

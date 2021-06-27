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
using System.Windows.Forms;

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

        protected override void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        private void CreateRoute()
        {
            settingRoutes = new SettingRoutes(this);
            settingRoutes.Routing(Constants.MAIN_SETTING);
        }

        private void HandleEvent()
        {
            // Main Setting
            settingRoutes.MainSettingView.GameModeClickEvent += MainSettingView_GameModeClickEvent;
            settingRoutes.MainSettingView.TimerClickEvent += MainSettingView_TimerClickEvent;
            settingRoutes.MainSettingView.PlayerClickEvent += MainSettingView_PlayerClickEvent;
            settingRoutes.MainSettingView.SizeClickEvent += MainSettingView_SizeClickEvent;
            settingRoutes.MainSettingView.SoundClickEvent += MainSettingView_SoundClickEvent;
            settingRoutes.MainSettingView.LanguageClickEvent += MainSettingView_LanguageClickEvent;
            settingRoutes.MainSettingView.LoadGameClickEvent += MainSettingView_LoadGameClickEvent;
            settingRoutes.MainSettingView.SaveGameClickEvent += MainSettingView_SaveGameClickEvent;
            settingRoutes.MainSettingView.SaveClickEvent = MainSettingView_SaveClickEvent;
            settingRoutes.MainSettingView.CancelClickEvent = MainSettingView_CancelClickEvent;
            // Game Mode Setting
            settingRoutes.GameModeSettingView.TwoPlayerClickEvent += GameModeSettingView_TwoPlayerClickEvent;
            settingRoutes.GameModeSettingView.AIModeClickEvent += GameModeSettingView_AIModeClickEvent;
            settingRoutes.GameModeSettingView.LanModeClickEvent += GameModeSettingView_LanModeClickEvent;
            settingRoutes.GameModeSettingView.CancelClickEvent = GameModeSettingView_CancelClickEvent;
            // Time Setting
            settingRoutes.TimeSettingView.SaveClickEvent = TimeSettingView_SaveClickEvent;
            settingRoutes.TimeSettingView.CancelClickEvent = TimeSettingView_CancelClickEvent;
        }

        #region Main Setting
        private void MainSettingView_CancelClickEvent(object sender, EventArgs e)
        {

        }

        private void MainSettingView_SaveClickEvent(object sender, EventArgs e)
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
            settingRoutes.Routing(Constants.LANGUAGE_SETTING);
        }

        private void MainSettingView_SoundClickEvent(object sender, EventArgs e)
        {
            settingRoutes.Routing(Constants.SOUND_SETTING);
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
            settingRoutes.Routing(Constants.TIME_SETTING);
        }

        private void MainSettingView_GameModeClickEvent(object sender, EventArgs e)
        {
            settingRoutes.Routing(Constants.GAME_MODE);
        }
        #endregion

        #region Game Mode Setting
        private void GameModeSettingView_CancelClickEvent(object sender, EventArgs e)
        {
            settingRoutes.Routing(Constants.MAIN_SETTING);
        }

        private void GameModeSettingView_LanModeClickEvent(object sender, EventArgs e)
        {

        }

        private void GameModeSettingView_AIModeClickEvent(object sender, EventArgs e)
        {

        }

        private void GameModeSettingView_TwoPlayerClickEvent(object sender, EventArgs e)
        {

        }
        #endregion

        #region Time Setting
        private void TimeSettingView_SaveClickEvent(object sender, EventArgs e)
        {
            settingRoutes.Routing(Constants.MAIN_SETTING);
        }
        private void TimeSettingView_CancelClickEvent(object sender, EventArgs e)
        {
            settingRoutes.Routing(Constants.MAIN_SETTING);
        }
        #endregion
    }
}

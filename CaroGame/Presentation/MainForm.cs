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

using CaroGame.CaroManagement;
using CaroGame.Configuration;
using System;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Configuration.Config;
using static CaroGame.Program;

namespace CaroGame.Presentation
{
    public partial class MainForm : BaseForm
    {
        public MainForm(string formText, Icon icon): base(formText, icon)
        {
            DrawOverview();
            DrawGameMode();
            DrawPayer();
            DrawGameBoard();
            this.SetCurrentPanel(overviewPnl);
            StartPosition = FormStartPosition.CenterScreen;

            caroManager = new CaroManager(gameBoardPanel.playerTxt);
            caroManager.ResizeCaroBoardEvent += CaroManager_ResizeCaroBoardEvent;
        }

        private void CaroManager_ResizeCaroBoardEvent(object sender, EventArgs e)
        {
            gameBoardPanel.DrawCaroGameBoard();
        }

        private void OverviewPnl_GuideClickEvent(object sender, EventArgs e)
        {

        }

        private void OverviewPnl_NewGameClickEvent(object sender, EventArgs e)
        {
            this.SetCurrentPanel(gameModePnl, Config.NAME.OVERVIEW);
        }

        private void GameModePnl_CancelActionClickEvent(object sender, EventArgs e)
        {
            this.SetCurrentPanel(overviewPnl, Config.NAME.OVERVIEW);
        }

        private void GameModePnl_LoadGameClickEvent(object sender, EventArgs e)
        {
        }

        private void GameModePnl_LanModeClickEvent(object sender, EventArgs e)
        {
            Config.CURRENT_GAME_MODE = GameMode.LAN;
            playerPnl.CaroVisible = false;
            playerPnl.LabelText1 = "Player";
            this.SetCurrentPanel(playerPnl, Config.NAME.PLAYER);
        }

        private void GameModePnl_AIModeClickEvent(object sender, EventArgs e)
        {
            Config.CURRENT_GAME_MODE = GameMode.AI;
            playerPnl.LabelText1 = "Player";
            playerPnl.CaroVisible = false;
            this.SetCurrentPanel(playerPnl, Config.NAME.PLAYER);
        }

        private void GameModePnl_TwoPlayerClickEvent(object sender, EventArgs e)
        {
            Config.CURRENT_GAME_MODE = GameMode.TWO_PLAYER;
            playerPnl.LabelText1 = "Player1";
            playerPnl.LabelText2 = "Player2";
            playerPnl.CaroVisible = true;
            this.SetCurrentPanel(playerPnl, Config.NAME.PLAYER);
        }

        private void PlayerPnl_CancelActionClickEvent(object sender, EventArgs e)
        {
            this.SetCurrentPanel(gameModePnl, Config.NAME.GAME_MODE);
        }

        private void PlayerPnl_NextActionClickEvent(object sender, EventArgs e)
        {
            (bool, string) result = playerPnl.IsValid();
            if (!result.Item1)
            {
                MessageBox.Show(result.Item2, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                playerPnl.Text1 = playerPnl.Text2 = "";
                return;
            }
            Config.NAME_PLAYER1 = playerPnl.Text1;
            Config.NAME_PLAYER2 = playerPnl.Text2;
            caroManager.CreateNewGame(playerPnl.Text1, playerPnl.Text2);
            gameBoardPanel.BoardPnl = caroManager.CaroGameBoard;
            gameBoardPanel.DrawCaroGameBoard();
            this.AddFit(this.gameBoardPanel);
            this.SetCurrentPanel(this.gameBoardPanel);
        }

        private void GameBoardPanel_AboutItemClickEvent(object sender, EventArgs e)
        {
        }

        private void GameBoardPanel_SettingItemClickEvent(object sender, EventArgs e)
        {
            settingForm.Show();
        }

        private void GameBoardPanel_QuickItemClickEvent(object sender, EventArgs e)
        {
        }

        private void GameBoardPanel_NewGameToolClickEvent(object sender, EventArgs e)
        {
        }

        private void GameBoardPanel_RedoClickEvent(object sender, EventArgs e)
        {
            caroManager.RedoGame();
        }

        private void GameBoardPanel_UndoClickEvent(object sender, EventArgs e)
        {
            caroManager.UndoGame();
        }
    }
}

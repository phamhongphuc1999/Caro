﻿using CaroGame.Presentation.CaroPanel;
using System.Drawing;
using System;

namespace CaroGame.Presentation
{
    partial class MainForm
    {
        private OverviewPanel overviewPnl;
        private GameModePanel gameModePnl;
        private TwoTextPanel playerPnl;

        private void DrawOverview()
        {
            overviewPnl = new OverviewPanel
            {
                Location = new Point(0, 0)
            };
            overviewPnl.NewGameClickEvent += OverviewPnl_NewGameClickEvent;
            overviewPnl.GuideClickEvent += OverviewPnl_GuideClickEvent;
            this.Controls.Add(overviewPnl);
        }

        private void DrawGameMode()
        {
            gameModePnl = new GameModePanel
            {
                Location = new Point(0, 0)
            };
            gameModePnl.TwoPlayerClickEvent += GameModePnl_TwoPlayerClickEvent;
            gameModePnl.AIModeClickEvent += GameModePnl_AIModeClickEvent;
            gameModePnl.LanModeClickEvent += GameModePnl_LanModeClickEvent;
            gameModePnl.LoadGameClickEvent += GameModePnl_LoadGameClickEvent;
            gameModePnl.CancelActionClickEvent += GameModePnl_CancelActionClickEvent;
            this.Controls.Add(gameModePnl);
        }

        private void DrawPayer()
        {
            playerPnl = new TwoTextPanel()
            {
                Location = new Point(0, 0),
                LabelText1 = "Player1",
                LabelText2 = "Player2"
            };
            playerPnl.NextActionClickEvent += PlayerPnl_NextActionClickEvent;
            playerPnl.CancelActionClickEvent += PlayerPnl_CancelActionClickEvent;
            this.Controls.Add(playerPnl);
        }
    }
}
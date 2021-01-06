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
using CaroGame.PlayerManagement;
using System;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    public class CaroManager
    {
        private PlayerManager playerManager;
        private CaroBoardManager caroBoardManager;
        private WinnerManager winnerManager;
        private TextBox playerTxt;

        public CaroManager(TextBox playerTxt)
        {
            this.playerTxt = playerTxt;

            playerManager = new PlayerManager();
            caroBoardManager = new CaroBoardManager();
            winnerManager = new WinnerManager();
            caroBoardManager.ButClick = But_Click;
        }

        public Panel CaroGameBoard
        {
            get { return caroBoardManager.CaroBoardPnl; }
        }

        private void SetControl(Control control)
        {
            control.Text = playerManager.CurrentPlayerName;
            control.BackColor = playerManager.CurrentPlayerColor;
        }

        public void CreateNewGame(int turn = 0)
        {
            caroBoardManager.ResizeCaroBoard();
            caroBoardManager.DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
            playerManager.Turn = turn;
            SetControl(this.playerTxt);
        }

        public void CreateNewGame(string name1, string name2, int turn = 0)
        {
            caroBoardManager.ResizeCaroBoard();
            caroBoardManager.DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
            playerManager.Set(name1, name2);
            playerManager.Turn = turn;
            SetControl(this.playerTxt);
        }

        private void Winner(Button eventBut)
        {
            caroBoardManager.ChangeFlatStypeWhenEndGame(eventBut, this.winnerManager);
            if(Config.CURRENT_GAME_MODE == Config.GameMode.TWO_PLAYER)
            {
                MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) CreateNewGame(playerManager.Turn);
            }

        }

        private void EndGame(Button eventBut)
        {
            if (Config.CURRENT_GAME_MODE == Config.GameMode.TWO_PLAYER)
            {
                MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) CreateNewGame(playerManager.Turn);
            }

        }

        private void TurnPlayer()
        {
            playerManager.Turn = playerManager.Turn + 1;
            winnerManager.Turn = 1 - winnerManager.Turn;
            SetControl(this.playerTxt);
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            int X = but.Location.X;
            int Y = but.Location.Y;
            but.BackColor = playerManager.CurrentPlayerColor;
            winnerManager.DrawCaroBoard(but.Location);
            if (winnerManager.IsWiner(X, Y).Result) Winner(but);
            else if (winnerManager.IsEndGame()) EndGame(but);
            else TurnPlayer();
        }
    }
}

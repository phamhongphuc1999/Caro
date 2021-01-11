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
using CaroGame.Configuration;
using CaroGame.PlayerManagement;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    public class CaroManager
    {
        private PlayerManager playerManager;
        private CaroBoardManager caroBoardManager;
        private WinnerManager winnerManager;
        private ActionManager actionManager;
        private TextBox playerTxt;

        public CaroManager(TextBox playerTxt)
        {
            this.playerTxt = playerTxt;

            playerManager = new PlayerManager();
            caroBoardManager = new CaroBoardManager();
            winnerManager = new WinnerManager();
            actionManager = new ActionManager();
            caroBoardManager.ButClick = But_Click;
        }

        private event EventHandler resizeCaroBoardEvent;
        public event EventHandler ResizeCaroBoardEvent
        {
            add
            {
                resizeCaroBoardEvent += value;
            }
            remove
            {
                resizeCaroBoardEvent -= value;
            }
        }

        public Panel CaroGameBoard
        {
            get
            {
                return caroBoardManager.CaroBoardPnl;
            }
        }

        private void SetControl(Control control)
        {
            control.Text = playerManager.CurrentPlayerName;
            control.BackColor = playerManager.CurrentPlayerColor;
        }

        public void SetPlayerName(string name1, string name2 = "")
        {
            playerManager.Set(name1, name2);
        }

        public void ResizeCaroBoard(int numberOfRow, int numberOfColumn)
        {
            int oldRow = Config.NUMBER_OF_ROW;
            int oldColumn = Config.NUMBER_OF_COLUMN;
            Config.NUMBER_OF_COLUMN = numberOfColumn;
            Config.NUMBER_OF_ROW = numberOfRow;
            caroBoardManager.ResizeCaroBoard(oldRow, oldColumn);
            winnerManager.ResetDictionary(oldRow, oldColumn);
            resizeCaroBoardEvent(this, new EventArgs());
        }

        public void CreateNewGame(int turn = 0)
        {
            caroBoardManager.InitSizeCaroBoard();
            caroBoardManager.DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
            playerManager.Turn = turn;
            actionManager.ResetAction();
            SetControl(this.playerTxt);
        }

        public void CreateNewGame(string name1, string name2, int turn = 0)
        {
            caroBoardManager.InitSizeCaroBoard();
            caroBoardManager.DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
            playerManager.Set(name1, name2);
            playerManager.Turn = turn;
            actionManager.ResetAction();
            SetControl(this.playerTxt);
        }

        public void UndoGame()
        {
            try
            {
                Button but = actionManager.AddUndo();
                winnerManager.UndoHandle(but.Location.X, but.Location.Y);
                playerManager.Turn = playerManager.Turn + 1;
                caroBoardManager.UndoGame(but.Location.X, but.Location.Y);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void RedoGame()
        {
            try
            {
                Button but = actionManager.AddRedo();
                winnerManager.RedoHandle(but.Location.X, but.Location.Y);
                SetControl(this.playerTxt);
                caroBoardManager.RedoGame(but.Location.X, but.Location.Y, playerManager.CurrentPlayerColor);
                playerManager.Turn = playerManager.Turn + 1;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Winner(Button eventBut)
        {
            caroBoardManager.Winner(eventBut, this.winnerManager);
            if (Config.CURRENT_GAME_MODE == Config.GameMode.TWO_PLAYER)
            {
                MessageBox.Show($"Người chơi {playerManager.CurrentPlayerName} chiến thắng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Bạn có muốn chơi trò chơi mới?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) CreateNewGame(playerManager.Turn);
            }
        }

        private void EndGame()
        {
            caroBoardManager.EndGame();
            if (Config.CURRENT_GAME_MODE == Config.GameMode.TWO_PLAYER)
            {
                MessageBox.Show("Trò chơi kết thúc, không ai giành chiến thắng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Bạn có muốn chơi trò chơi mới?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
            actionManager.UpdateTurn(but);
            if (winnerManager.IsWiner(X, Y).Result) Winner(but);
            else if (winnerManager.IsEndGame()) EndGame();
            else TurnPlayer();
        }
    }
}

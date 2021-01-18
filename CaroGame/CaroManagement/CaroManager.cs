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
using CaroGame.CaroException;

namespace CaroGame.CaroManagement
{
    public class CaroManager
    {
        private PlayerManager playerManager;
        private CaroBoardManager caroBoardManager;
        private WinnerManager winnerManager;
        private ActionManager actionManager;

        public CaroManager(TextBox playerTxt, Label timeLbl)
        {
            playerManager = new PlayerManager();
            caroBoardManager = new CaroBoardManager(playerTxt, timeLbl);
            winnerManager = new WinnerManager();
            actionManager = new ActionManager();

            caroBoardManager.ButClick = But_Click;
            caroBoardManager.TimeTick = Timer_Tick;
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

        public int Turn
        {
            get
            {
                return playerManager.Turn;
            }
        }

        public Panel CaroGameBoard
        {
            get
            {
                return caroBoardManager.CaroBoardPnl;
            }
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
            playerManager.Turn = turn;
            actionManager.ResetAction();
            caroBoardManager.InitCaroBoard(playerManager.CurrentPlayerName, playerManager.CurrentPlayerColor);
            caroBoardManager.DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
        }

        public void CreateNewGame(string name1, string name2, int turn = 0)
        {
            playerManager.Set(name1, name2);
            playerManager.Turn = turn;
            actionManager.ResetAction();
            caroBoardManager.InitCaroBoard(playerManager.CurrentPlayerName, playerManager.CurrentPlayerColor);
            caroBoardManager.DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
        }

        public string ConvertBoardToString()
        {
            return caroBoardManager.ConvertBoardToString(playerManager.PlayerColor1, playerManager.PlayerColor2);
        }

        private void ExecuteNewGame()
        {
            DialogResult result = MessageBox.Show("Bạn có muốn chơi trò chơi mới?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) CreateNewGame(playerManager.Turn);
            throw new StayOldGameException();
        }

        public void UndoGame()
        {
            try
            {
                Button but = actionManager.AddUndo();
                winnerManager.UndoHandle(but.Location.X, but.Location.Y);
                playerManager.Turn = playerManager.Turn + 1;
                caroBoardManager.UndoGame(but.Location.X, but.Location.Y, playerManager.CurrentPlayerName);
                caroBoardManager.TimeText = Config.TIME_TURN.ToString();
            }
            catch (Exception e)
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
                caroBoardManager.RedoGame(but.Location.X, but.Location.Y, playerManager.CurrentPlayerName, playerManager.CurrentPlayerColor);
                playerManager.Turn = playerManager.Turn + 1;
                caroBoardManager.TimeText = Config.TIME_TURN.ToString();
            }
            catch (Exception e)
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
                try
                {
                    ExecuteNewGame();
                }
                catch { }
            }
        }

        private void EndGame()
        {
            caroBoardManager.EndGame();
            if (Config.CURRENT_GAME_MODE == Config.GameMode.TWO_PLAYER)
            {
                MessageBox.Show("Trò chơi kết thúc, không ai giành chiến thắng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    ExecuteNewGame();
                }
                catch { }
            }
        }

        private void TurnPlayer()
        {
            playerManager.Turn = playerManager.Turn + 1;
            winnerManager.Turn = 1 - winnerManager.Turn;
            caroBoardManager.Turn(playerManager.CurrentPlayerName, playerManager.CurrentPlayerColor);
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            if (!winnerManager.CheckExtist(but.Location))
            {
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            int remainTime = Int32.Parse(caroBoardManager.TimeText);
            if (remainTime == 0)
            {
                caroBoardManager.TimeEnable = false;
                MessageBox.Show($"Người chơi {playerManager.OtherPlayerName} chiến thắng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    ExecuteNewGame();
                }
                catch { }
            }
            else caroBoardManager.TimeText = (remainTime - 1).ToString();
        }
    }
}

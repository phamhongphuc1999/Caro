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
using CaroGame.Controls;
using CaroGame.Entities;
using CaroGame.Views.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame.CaroManagement
{
    public class CaroBoardManager
    {
        private Panel caroBoardView;
        private Dictionary<BoardPosition, Button> caroBoard;
        private TextBox playerTxt;

        public void InitMainView(MainPanel mainView)
        {
            caroBoardView = mainView.caroBoardView;
            playerTxt = mainView.playerTxt;
        }

        public void InitCaroBoard()
        {
            playerTxt.Text = playerManager.CurrentPlayerName;
            playerTxt.BackColor = playerManager.CurrentPlayerColor;
            caroBoard = new Dictionary<BoardPosition, Button>();
        }

        public void DrawCaroBoard()
        {
            caroBoardView.Controls.Clear();
            caroBoardView.Enabled = true;
            caroBoard.Clear();
            int count = 0;
            for (int i = 0; i < SettingConfig.Rows; i++)
                for (int j = 0; j < SettingConfig.Columns; j++)
                {
                    if (SettingConfig.BoardPattern[count] != '0')
                    {
                        BoardButton but = new BoardButton
                        {
                            Size = new Size(Constants.CHESS_WIDTH, Constants.CHESS_HEIGHT),
                            Location = new Point(Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i),
                            Rows = i,
                            Columns = j
                        };
                        if (SettingConfig.BoardPattern[count] == '1') but.BackColor = playerManager.PlayerColor1;
                        else if (SettingConfig.BoardPattern[count] == '2') but.BackColor = playerManager.PlayerColor2;
                        but.Click += But_Click;
                        caroBoard.Add(new BoardPosition(i, j), but);
                        caroBoardView.Controls.Add(but);
                    }
                    count++;
                }
        }

        public string ConvertBoardToString()
        {
            string board = "";
            Color playerColor1 = playerManager.PlayerColor1;
            Color playerColor2 = playerManager.PlayerColor2;
            foreach (KeyValuePair<BoardPosition, Button> item in caroBoard)
            {
                Button button = item.Value;
                if (button.BackColor == playerColor1) board += "1";
                else if (button.BackColor == playerColor2) board += "2";
                else board += "0";
            }
            return board;
        }

        public void CreateNewGame(int turn)
        {
            playerManager.Turn = turn;
            actionManager.ResetAction();
            InitCaroBoard();
            DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
        }

        public void UndoGame(int row, int column, string playerName)
        {
            Button but = caroBoard[new BoardPosition(row, column)];
            but.BackColor = Color.Transparent;
            but.FlatStyle = FlatStyle.Standard;
            playerTxt.Text = playerName;
        }

        public void RedoGame(int row, int column, string playerName, Color playerColor)
        {
            Button but = caroBoard[new BoardPosition(row, column)];
            but.BackColor = playerColor;
            playerTxt.Text = playerName;
            but.FlatStyle = FlatStyle.Standard;
        }

        private void ExecuteNewGame()
        {
            DialogResult result = MessageBox.Show("Bạn có muốn chơi trò chơi mới?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) CreateNewGame(playerManager.Turn);
            throw new StayOldGameException();
        }

        private void DrawWinner(Button eventBut)
        {
            caroBoardView.Enabled = false;
            int[] check = winnerManager.check;
            if (check[0] == 1)
            {
                foreach (BoardPosition item in winnerManager.arrRow)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[1] == 1)
            {
                foreach (BoardPosition item in winnerManager.arrColumn)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[2] == 1)
            {
                foreach (BoardPosition item in winnerManager.arrMainDiagonal)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[3] == 1)
            {
                foreach (BoardPosition item in winnerManager.arrSubDiagomal)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            eventBut.FlatStyle = FlatStyle.Flat;
        }

        private void Winner(Button eventBut)
        {
            DrawWinner(eventBut);
            if (SettingConfig.GameMode == Constants.TWO_PLAYER_GAME_MODE)
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
            caroBoardView.Enabled = false;
            if (SettingConfig.GameMode == Constants.TWO_PLAYER_GAME_MODE)
            {
                MessageBox.Show("Trò chơi kết thúc, không ai giành chiến thắng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    ExecuteNewGame();
                }
                catch { }
            }
        }

        private void But_Click(object sender, EventArgs e)
        {
            BoardButton but = sender as BoardButton;
            if (!winnerManager.CheckExtist(but.Rows, but.Columns))
            {
                but.BackColor = playerManager.CurrentPlayerColor;
                winnerManager.DrawCaroBoard(but.Rows, but.Columns);
                actionManager.UpdateTurn(but);
                if (winnerManager.IsWiner(but.Rows, but.Columns).Result) Winner(but);
                else if (winnerManager.IsEndGame()) EndGame();
                else
                {
                    playerManager.Turn = playerManager.Turn + 1;
                    winnerManager.Turn = 1 - winnerManager.Turn;
                }
            }
        }
    }
}

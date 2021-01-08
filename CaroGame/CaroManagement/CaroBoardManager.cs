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
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    internal class CaroBoardManager
    {
        public Panel CaroBoardPnl
        {
            get;
        }
        private Dictionary<KeyValuePair<int, int>, Button> caroBoard;

        public Action<object, EventArgs> ButClick
        {
            get; set;
        }

        public CaroBoardManager()
        {
            CaroBoardPnl = new Panel();
            caroBoard = new Dictionary<KeyValuePair<int, int>, Button>();
        }

        public void ResizeCaroBoard()
        {
            int width = Config.NUMBER_OF_COLUMN * Config.CHESS_SIZE.Width;
            int height = Config.NUMBER_OF_ROW * Config.CHESS_SIZE.Height;
            CaroBoardPnl.Size = new Size(width, height);
        }

        public void DrawCaroBoard()
        {
            CaroBoardPnl.Controls.Clear();
            CaroBoardPnl.Enabled = true;
            caroBoard.Clear();
            for (int i = 0; i < Config.NUMBER_OF_ROW; i++)
            {
                for (int j = 0; j < Config.NUMBER_OF_COLUMN; j++)
                {
                    Button but = new Button()
                    {
                        Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                        Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i),
                        FlatStyle = FlatStyle.Standard
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new KeyValuePair<int, int>(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                    CaroBoardPnl.Controls.Add(but);
                }
            }
        }

        public void DrawCaroBoard(int numberOfRow, int numberOfColumn)
        {
            CaroBoardPnl.Enabled = true;
            if (CaroBoardPnl.Controls.Count == 0)
            {
                for (int i = 0; i < numberOfRow; i++)
                {
                    for (int j = 0; j < numberOfColumn; j++)
                    {
                        Button but = new Button()
                        {
                            Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                            Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i),
                            FlatStyle = FlatStyle.Standard
                        };
                        but.Click += But_Click;
                        caroBoard.Add(new KeyValuePair<int, int>(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                        CaroBoardPnl.Controls.Add(but);
                    }
                }
            }
            else
            {
                for (int i = 0; i < numberOfRow; i++)
                {
                    for (int j = 0; j < numberOfColumn; j++)
                    {
                        Button but = caroBoard[new KeyValuePair<int, int>(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i)];
                        but.BackColor = Color.Empty;
                        but.FlatStyle = FlatStyle.Standard;
                    }

                }
            }
        }

        public string ConvertBoardToString(Color playerColor1, Color playerColor2)
        {
            string board = "";
            foreach (KeyValuePair<KeyValuePair<int, int>, Button> item in caroBoard)
            {
                Button button = item.Value;
                if (button.BackColor == playerColor1) board += "1";
                else if (button.BackColor == playerColor2) board += "2";
                else board += "0";
            }
            return board;
        }

        public void UndoGame(int X, int Y)
        {
            Button but = caroBoard[new KeyValuePair<int, int>(X, Y)];
            but.BackColor = Color.Transparent;
            but.FlatStyle = FlatStyle.Standard;
        }

        public void RedoGame(int X, int Y,  Color playerColor)
        {
            Button but = caroBoard[new KeyValuePair<int, int>(X, Y)];
            but.BackColor = playerColor;
            but.FlatStyle = FlatStyle.Standard;
        }

        public void Winner(Button eventBut, WinnerManager winnerManager)
        {
            CaroBoardPnl.Enabled = false;
            int[] check = winnerManager.check;
            if (check[0] == 1)
            {
                foreach (KeyValuePair<int, int> item in winnerManager.arrRow)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[1] == 1)
            {
                foreach (KeyValuePair<int, int> item in winnerManager.arrColumn)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[2] == 1)
            {
                foreach (KeyValuePair<int, int> item in winnerManager.arrMainDiagonal)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[3] == 1)
            {
                foreach (KeyValuePair<int, int> item in winnerManager.arrSubDiagomal)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            eventBut.FlatStyle = FlatStyle.Flat;
        }

        public void EndGame()
        {
            CaroBoardPnl.Enabled = false;
        }

        private void But_Click(object sender, EventArgs e)
        {
            this.ButClick(sender, e);
        }
    }
}

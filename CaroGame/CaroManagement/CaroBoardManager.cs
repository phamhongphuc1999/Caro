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
        private Dictionary<Point, Button> caroBoard;

        private TextBox playerTxt;
        private Label timeLbl;
        private Timer caroTimer;

        public Action<object, EventArgs> ButClick
        {
            get; set;
        }

        public Action<object, EventArgs> TimeTick
        {
            get; set;
        }

        public CaroBoardManager(TextBox playerTxt, Label timeLbl)
        {
            this.playerTxt = playerTxt;
            this.timeLbl = timeLbl;
            this.caroTimer = new Timer
            {
                Interval = Config.INTERVAL
            };
            this.caroTimer.Tick += CaroTimer_Tick;

            CaroBoardPnl = new Panel();
            caroBoard = new Dictionary<Point, Button>();
        }

        public string TimeText
        {
            get
            {
                return timeLbl.Text;
            }
            set
            {
                timeLbl.Text = value;
            }
        }

        public bool TimeEnable
        {
            get
            {
                return caroTimer.Enabled;
            }
            set
            {
                caroTimer.Enabled = value;
            }
        }

        public void Turn(string playerName, Color playerColor)
        {
            playerTxt.Text = playerName;
            playerTxt.BackColor = playerColor;
            if (Config.IS_TIMER) timeLbl.Text = Config.TIME_TURN.ToString();
        }

        public void InitCaroBoard(string playerFirstName, Color playerColor)
        {
            int width = Config.NUMBER_OF_COLUMN * Config.CHESS_SIZE.Width;
            int height = Config.NUMBER_OF_ROW * Config.CHESS_SIZE.Height;
            playerTxt.Text = playerFirstName;
            playerTxt.BackColor = playerColor;
            CaroBoardPnl.Size = new Size(width, height);
            if (Config.IS_TIMER)
            {
                timeLbl.Text = Config.TIME_TURN.ToString();
                caroTimer.Start();
            }
            else timeLbl.Text = "No Timer";
        }

        public void ResizeCaroBoard(int oldRow, int oldColumn)
        {
            int width = Config.NUMBER_OF_COLUMN * Config.CHESS_SIZE.Width;
            int height = Config.NUMBER_OF_ROW * Config.CHESS_SIZE.Height;
            CaroBoardPnl.Size = new Size(width, height);
            UpdateDictionary(oldRow, oldColumn);
            RedrawCaroBoard(oldRow, oldColumn);
        }

        private void UpdateDictionary(int oldRow, int oldColumn)
        {
            if (oldRow > Config.NUMBER_OF_ROW)
            {
                for (int i = Config.NUMBER_OF_ROW; i < oldRow; i++)
                {
                    for (int j = 0; j < oldColumn; j++)
                    {
                        Point location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i);
                        if (caroBoard.ContainsKey(location)) caroBoard.Remove(location);
                    }
                }
            }
            if (oldColumn < Config.NUMBER_OF_COLUMN)
            {
                for (int i = 0; i < oldRow; i++)
                {
                    for (int j = oldColumn; j < Config.NUMBER_OF_COLUMN; j++)
                    {
                        Point location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i);
                        if (caroBoard.ContainsKey(location)) caroBoard.Remove(location);
                    }
                }
            }
        }

        private void RedrawCaroBoard(int oldRow, int oldColumn)
        {
            if (oldRow < Config.NUMBER_OF_ROW)
            {
                for (int i = oldRow; i < Config.NUMBER_OF_ROW; i++)
                {
                    for (int j = 0; j < oldColumn; j++)
                    {
                        Button but = new Button()
                        {
                            Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                            Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i),
                            FlatStyle = FlatStyle.Standard
                        };
                        but.Click += But_Click;
                        caroBoard.Add(new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                        CaroBoardPnl.Controls.Add(but);
                    }
                }
                if (oldColumn >= Config.NUMBER_OF_COLUMN) return;
            }
            if (oldColumn < Config.NUMBER_OF_COLUMN)
            {
                for (int i = 0; i < oldRow; i++)
                {
                    for (int j = oldColumn; j < Config.NUMBER_OF_COLUMN; j++)
                    {
                        Button but = new Button()
                        {
                            Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                            Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i),
                            FlatStyle = FlatStyle.Standard
                        };
                        but.Click += But_Click;
                        caroBoard.Add(new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                        CaroBoardPnl.Controls.Add(but);
                    }
                }
                if (oldRow >= Config.NUMBER_OF_ROW) return;
            }
            for (int i = oldRow; i < Config.NUMBER_OF_ROW; i++)
            {
                for (int j = oldColumn; j < Config.NUMBER_OF_COLUMN; j++)
                {
                    Button but = new Button()
                    {
                        Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                        Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i),
                        FlatStyle = FlatStyle.Standard
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                    CaroBoardPnl.Controls.Add(but);
                }
            }
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
                    caroBoard.Add(new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                    CaroBoardPnl.Controls.Add(but);
                }
            }
        }

        public List<(Point, int)> DrawLoadCaroBoard(string sCaroBoard, Color playerColor1, Color playerColor2)
        {
            CaroBoardPnl.Controls.Clear();
            CaroBoardPnl.Enabled = true;
            caroBoard.Clear();
            List<(Point, int)> result = new List<(Point, int)>(); 
            int count = 0;
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
                    if (sCaroBoard[count] == '1')
                    {
                        but.BackColor = playerColor1;
                        result.Add((but.Location, 0));
                    }
                    else if (sCaroBoard[count] == '2')
                    {
                        but.BackColor = playerColor2;
                        result.Add((but.Location, 1));
                    }
                    but.Click += But_Click;
                    caroBoard.Add(new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                    CaroBoardPnl.Controls.Add(but);
                    count++;
                }
            }
            return result;
        }

        public string ConvertBoardToString(Color playerColor1, Color playerColor2)
        {
            string board = "";
            foreach (KeyValuePair<Point, Button> item in caroBoard)
            {
                Button button = item.Value;
                if (button.BackColor == playerColor1) board += "1";
                else if (button.BackColor == playerColor2) board += "2";
                else board += "0";
            }
            return board;
        }

        public void UndoGame(int X, int Y, string playerName)
        {
            Button but = caroBoard[new Point(X, Y)];
            but.BackColor = Color.Transparent;
            but.FlatStyle = FlatStyle.Standard;
            playerTxt.Text = playerName;
        }

        public void RedoGame(int X, int Y, string playerName, Color playerColor)
        {
            Button but = caroBoard[new Point(X, Y)];
            but.BackColor = playerColor;
            playerTxt.Text = playerName;
            but.FlatStyle = FlatStyle.Standard;
        }

        public void Winner(Button eventBut, WinnerManager winnerManager)
        {
            CaroBoardPnl.Enabled = false;
            int[] check = winnerManager.check;
            if (check[0] == 1)
            {
                foreach (Point item in winnerManager.arrRow)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[1] == 1)
            {
                foreach (Point item in winnerManager.arrColumn)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[2] == 1)
            {
                foreach (Point item in winnerManager.arrMainDiagonal)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[3] == 1)
            {
                foreach (Point item in winnerManager.arrSubDiagomal)
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

        private void CaroTimer_Tick(object sender, EventArgs e)
        {
            this.TimeTick(sender, e);
        }
    }
}

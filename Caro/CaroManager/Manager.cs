﻿using Caro.Config;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using Caro.ConnectManager;
using System.Net.Sockets;
using DataTransmission;

namespace Caro.CaroManager
{
    class Manager
    {
        private int turn;
        public int Turn
        {
            get { return turn; }
            set { turn = value; }
        }
        public Panel pnlCaroBoard;
        private TextBox txtPlayer;
        private Label lblTime;
        private static CheckWinner checkWinner;
        public static SocketManager socketManager;
        private Dictionary<KeyValuePair<int, int>, Button> caroBoard;
        private List<Player> playerList;
        public List<Player> PlayerList
        {
            get { return playerList; }
            set { playerList = value; }
        }
        private CaroStack<Button> butUndo, butRedo;

        private event EventHandler newGameEvent;
        public event EventHandler NewGameEvent
        {
            add { newGameEvent += value; }
            remove { newGameEvent += value; }
        }

        private event EventHandler endGameEvent;
        public event EventHandler EndGameEvent
        {
            add { endGameEvent += value; }
            remove { endGameEvent += value; }
        }

        public Manager(TextBox txtPlayer, Panel pnlCaroBoard, Label lblTime)
        {
            this.txtPlayer = txtPlayer;
            this.pnlCaroBoard = pnlCaroBoard;
            this.lblTime = lblTime;
            butUndo = new CaroStack<Button>(5);
            butRedo = new CaroStack<Button>(5);
            checkWinner = new CheckWinner(CONST.NUMBER_OF_COLUMN, CONST.NUMBER_OF_ROW);
            caroBoard = new Dictionary<KeyValuePair<int, int>, Button>();
            playerList = new List<Player>()
            {
                new Player("", Color.Red, 0),
                new Player("", Color.Green, 1)
            };
        }

        private void DrawCaroBoard(int numberOfRow, int numberOfColumn)
        {
            pnlCaroBoard.Controls.Clear();
            caroBoard.Clear();
            for (int i = 0; i < numberOfRow; i++)
            {
                for (int j = 0; j < numberOfColumn; j++)
                {
                    Button but = new Button()
                    {
                        Size = new Size(CONST.CHESS_SIZE.Width, CONST.CHESS_SIZE.Height),
                        Location = new Point(CONST.CHESS_SIZE.Width * j, CONST.CHESS_SIZE.Height * i)
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new KeyValuePair<int, int>(CONST.CHESS_SIZE.Width * j, CONST.CHESS_SIZE.Height * i), but);
                    pnlCaroBoard.Controls.Add(but);
                }
            }
        }

        private void DrawCaroBoard(int numberOfRow, int numberOfColumn, string sCaroBoard)
        {
            int index = 0;
            caroBoard.Clear();
            pnlCaroBoard.Controls.Clear();
            for (int i = 0; i < numberOfRow; i++)
            {
                for (int j = 0; j < numberOfColumn; j++)
                {
                    Button but = new Button()
                    {
                        Size = new Size(CONST.CHESS_SIZE.Width, CONST.CHESS_SIZE.Height),
                        Location = new Point(CONST.CHESS_SIZE.Width * j, CONST.CHESS_SIZE.Height * i)
                    };
                    if (sCaroBoard[index] == '1')
                    {
                        but.BackColor = playerList[0].ColorPlayer;
                        checkWinner.DrawCaroBoard(but.Location, 0);
                        butUndo.Push(but);
                    }
                    else if (sCaroBoard[index] == '2')
                    {
                        but.BackColor = playerList[1].ColorPlayer;
                        checkWinner.DrawCaroBoard(but.Location, 1);
                        butUndo.Push(but);
                    }
                    but.Click += But_Click;
                    caroBoard.Add(new KeyValuePair<int, int>(CONST.CHESS_SIZE.Width * j, CONST.CHESS_SIZE.Height * i), but);
                    pnlCaroBoard.Controls.Add(but);
                    index++;
                }
            }
        }

        public string ConvertBoardToString()
        {
            string board = "";
            foreach (KeyValuePair<KeyValuePair<int, int>, Button> item in caroBoard)
            {
                Button button = item.Value;
                if (button.BackColor == null) board += "0";
                else if (button.BackColor == playerList[0].ColorPlayer) board += "1";
                else board += "2";
            }
            return board;
        }

        private void TurnPalyer()
        {
            turn = 1 - turn;
            playerList[turn].IsTurn = 1;
            playerList[1 - turn].IsTurn = 0;
            txtPlayer.BackColor = playerList[turn].ColorPlayer;
            txtPlayer.Text = playerList[turn].NamePlayer;
        }

        public void LoadSaveGame(int player, string sCaroGame)
        {
            turn = player;
            checkWinner.NewGameHanlde(player);
            txtPlayer.BackColor = (turn == 0) ? Color.Red : Color.Green;
            txtPlayer.Text = playerList[turn].NamePlayer;
            playerList[0].NamePlayer = CONST.NAME_PLAYER1;
            playerList[1].NamePlayer = CONST.NAME_PLAYER2;
            DrawCaroBoard(CONST.NUMBER_OF_ROW, CONST.NUMBER_OF_COLUMN, sCaroGame);
        }

        public void NewGameHandle(int player)
        {
            turn = player;
            pnlCaroBoard.Enabled = true;
            if (CONST.GAME_MODE == "LAN" && !CONST.IS_SERVER)
            {
                playerList[0].NamePlayer = CONST.NAME_PLAYER2;
                playerList[0].ColorPlayer = Color.FromName(CONST.COLOR_PLAYER2);
                playerList[1].NamePlayer = CONST.NAME_PLAYER1;
                playerList[1].ColorPlayer = Color.FromName(CONST.COLOR_PLAYER1);
            }
            else
            {
                playerList[0].NamePlayer = CONST.NAME_PLAYER1;
                playerList[0].ColorPlayer = Color.FromName(CONST.COLOR_PLAYER1);
                playerList[1].NamePlayer = CONST.NAME_PLAYER2;
                playerList[1].ColorPlayer = Color.FromName(CONST.COLOR_PLAYER2);
            }
            txtPlayer.Text = playerList[turn].NamePlayer;
            txtPlayer.BackColor = playerList[turn].ColorPlayer;
            checkWinner.NewGameHanlde(player);
            DrawCaroBoard(CONST.NUMBER_OF_ROW, CONST.NUMBER_OF_COLUMN);
            lblTime.Text = (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") ? CONST.TIME_TURN.ToString() : "No Timer";
            CONST.IS_OLD_GAME = false;
            CONST.INDEX_OLD_GAME = -1;
            newGameEvent(this, new EventArgs());
        }

        private void EndGameHandle(int player, Button eventBut, int sign = 0)
        {
            endGameEvent(this, new EventArgs());
            pnlCaroBoard.Enabled = false;
            if (sign == 0)
            {
                int[] check = checkWinner.check;
                if (check[0] == 1)
                {
                    foreach (KeyValuePair<int, int> item in checkWinner.arrRow)
                        caroBoard[item].FlatStyle = FlatStyle.Flat;
                }
                if (check[1] == 1)
                {
                    foreach (KeyValuePair<int, int> item in checkWinner.arrColumn)
                        caroBoard[item].FlatStyle = FlatStyle.Flat;
                }
                if (check[2] == 1)
                {
                    foreach (KeyValuePair<int, int> item in checkWinner.arrMainDiagonal)
                        caroBoard[item].FlatStyle = FlatStyle.Flat;
                }
                if (check[3] == 1)
                {
                    foreach (KeyValuePair<int, int> item in checkWinner.arrSubDiagomal)
                        caroBoard[item].FlatStyle = FlatStyle.Flat;
                }
                eventBut.FlatStyle = FlatStyle.Flat;
            }

            if (CONST.GAME_MODE == "TWO_PLAYER")
            {
                if (sign == 0) MessageBox.Show("The " + playerList[player].NamePlayer + " win", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) NewGameHandle(player);
            }
            else if (CONST.GAME_MODE == "LAN" && !CONST.IS_TURN)
            {
                CONST.IS_LOCK = !CONST.IS_LOCK;
                CONST.IS_TURN = !CONST.IS_TURN;
                if (sign == 0) MessageBox.Show("You are the winner", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    MessageData message = new MessageData(112, 0, 0, "");
                    socketManager.SEND_TCP(message, SocketFlags.None);
                    NewGameHandle(player);
                }
                else
                {

                }
            }
            else if (CONST.GAME_MODE == "LAN" && CONST.IS_TURN)
            {
                CONST.IS_LOCK = !CONST.IS_LOCK;
                CONST.IS_TURN = !CONST.IS_TURN;
                if (sign == 0) MessageBox.Show("You are the lost", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UndoHandle()
        {
            if (butUndo.Count() > 0)
            {
                if (CONST.IS_ON_TIMER) lblTime.Text = CONST.TIME_TURN.ToString();
                else lblTime.Text = "No Timer";
                Button but = butUndo.Pop();
                butRedo.Push(but);
                but.Image = null;
                but.FlatStyle = FlatStyle.Standard;
                checkWinner.UndoHandle(but.Location.X, but.Location.Y);
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Flat;
                TurnPalyer();
            }
        }

        public void RedoHandle()
        {
            if (butRedo.Count() > 0)
            {
                if (CONST.IS_ON_TIMER) lblTime.Text = CONST.TIME_TURN.ToString();
                else lblTime.Text = "No Timer";
                try
                {
                    Button but = butRedo.Pop();
                    if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                    butUndo.Push(but);
                    but.BackColor = playerList[turn].ColorPlayer;
                    but.FlatStyle = FlatStyle.Flat;
                    checkWinner.RedoHandle(but.Location.X, but.Location.Y);
                    TurnPalyer();
                }
                catch
                {
                    MessageBox.Show("Can Not Redo Game", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LANMovePointHandle(int X, int Y)
        {
            CONST.IS_LOCK = true;
            Button eventBut = caroBoard[new KeyValuePair<int, int>(X, Y)];
            But_Click(eventBut, new EventArgs());
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            int X = eventBut.Location.X;
            int Y = eventBut.Location.Y;
            if (eventBut.Image == null && CONST.IS_LOCK)
            {
                if (CONST.GAME_MODE == "LAN" && CONST.IS_TURN)
                {
                    MessageData message = new MessageData(101, X, Y, "");
                    socketManager.SEND_TCP(message, SocketFlags.None);
                    CONST.IS_TURN = !CONST.IS_TURN;
                    CONST.IS_LOCK = !CONST.IS_LOCK;
                }
                else if (CONST.GAME_MODE == "LAN") CONST.IS_TURN = !CONST.IS_TURN;
                if (CONST.IS_ON_TIMER && CONST.GAME_MODE != "LAN") lblTime.Text = CONST.TIME_TURN.ToString();
                eventBut.FlatStyle = FlatStyle.Flat;
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                butUndo.Push(eventBut);
                checkWinner.Turn = turn;
                eventBut.BackColor = playerList[turn].ColorPlayer;
                if (checkWinner.IsWiner(X, Y).Result) EndGameHandle(turn, eventBut);
                else if (checkWinner.IsEndGame()) EndGameHandle(turn, eventBut, 1);
                else
                {
                    checkWinner.DrawCaroBoard(X, Y);
                    CrossThread.PerformSafely(txtPlayer, TurnPalyer);
                }
            }
        }
    }
}

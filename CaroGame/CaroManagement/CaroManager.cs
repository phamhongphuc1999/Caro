// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
using CaroGame.LANManagement;
using CaroGame.PlayerManagement;
using DataTransmission;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    class CaroManager
    {
        public int Turn { get; set; }
        public Panel pnlCaroBoard { get; set; }
        public TextBox txtPlayer { get; set; }
        public Label lblTime { get; set; }
        private static WinManager winManager;
        public static LANManager lanManager;
        private Dictionary<KeyValuePair<int, int>, Button> caroBoard;
        public List<Player> PlayerList { get; set; }
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

        public CaroManager()
        {
            butUndo = new CaroStack<Button>(5);
            butRedo = new CaroStack<Button>(5);
            winManager = new WinManager(Config.NUMBER_OF_COLUMN, Config.NUMBER_OF_ROW);
            caroBoard = new Dictionary<KeyValuePair<int, int>, Button>();
            PlayerList = new List<Player>()
            {
                new Player("", Color.Red, 0),
                new Player("", Color.Green, 1)
            };
        }

        /// <summary>
        /// Draw caro board with number of row and column in Config
        /// </summary>
        private void DrawCaroBoard()
        {
            pnlCaroBoard.Controls.Clear();
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
                    pnlCaroBoard.Controls.Add(but);
                }
            }
        }

        /// <summary>
        /// Draw caro board with specified number of row and column
        /// </summary>
        /// <param name="numberOfRow">the number of row</param>
        /// <param name="numberOfColumn">the number of column</param>
        private void DrawCaroBoard(int numberOfRow, int numberOfColumn)
        {
            if(pnlCaroBoard.Controls.Count == 0)
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
                        pnlCaroBoard.Controls.Add(but);
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

        /// <summary>Draw caro board with specified number of row and column and secified SCaroBoard</summary>
        /// <param name="numberOfRow">the number of row</param>
        /// <param name="numberOfColumn">the number of column</param>
        /// <param name="sCaroBoard">the specified caro board in save game</param>
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
                        Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                        Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i),
                        FlatStyle = FlatStyle.Standard
                    };
                    if (sCaroBoard[index] == '1')
                    {
                        but.BackColor = PlayerList[0].ColorPlayer;
                        winManager.DrawCaroBoard(but.Location, 0);
                        butUndo.Push(but);
                    }
                    else if (sCaroBoard[index] == '2')
                    {
                        but.BackColor = PlayerList[1].ColorPlayer;
                        winManager.DrawCaroBoard(but.Location, 1);
                        butUndo.Push(but);
                    }
                    but.Click += But_Click;
                    caroBoard.Add(new KeyValuePair<int, int>(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
                    pnlCaroBoard.Controls.Add(but);
                    index++;
                }
            }
        }

        /// <summary>
        /// Create the instance of string to represent the current board
        /// </summary>
        /// <returns>Return the string to represent the current board</returns>
        public string ConvertBoardToString()
        {
            string board = "";
            foreach (KeyValuePair<KeyValuePair<int, int>, Button> item in caroBoard)
            {
                Button button = item.Value;
                if (button.BackColor == PlayerList[0].ColorPlayer) board += "1";
                else if (button.BackColor == PlayerList[1].ColorPlayer) board += "2";
                else board += "0";
            }
            return board;
        }

        /// <summary>
        /// change player's turn
        /// </summary>
        private void TurnPalyer()
        {
            Turn = 1 - Turn;
            PlayerList[Turn].IsTurn = 1;
            PlayerList[1 - Turn].IsTurn = 0;
            txtPlayer.BackColor = PlayerList[Turn].ColorPlayer;
            txtPlayer.Text = PlayerList[Turn].NamePlayer;
        }

        /// <summary>
        /// Render save game
        /// </summary>
        /// <param name="player">The current player</param>
        /// <param name="sCaroGame">The string representing the board</param>
        public void LoadSaveGame(int player, string sCaroGame)
        {
            Turn = player;
            winManager.NewGameHanlde(player);
            txtPlayer.BackColor = (Turn == 0) ? Color.Red : Color.Green;
            txtPlayer.Text = PlayerList[Turn].NamePlayer;
            PlayerList[0].NamePlayer = Config.NAME_PLAYER1;
            PlayerList[1].NamePlayer = Config.NAME_PLAYER2;
            DrawCaroBoard(Config.NUMBER_OF_ROW, Config.NUMBER_OF_COLUMN, sCaroGame);
        }

        /// <summary>
        /// Handle the action of create the new game
        /// </summary>
        /// <param name="player">The player will be given the lead in the new game</param>
        public void NewGameHandle(int player)
        {
            Turn = player;
            pnlCaroBoard.Enabled = true;
            if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN && !Config.LAN_CONFIG.IsServer)
            {
                PlayerList[0].NamePlayer = Config.NAME_PLAYER2;
                PlayerList[1].NamePlayer = Config.NAME_PLAYER1;
            }
            else
            {
                PlayerList[0].NamePlayer = Config.NAME_PLAYER1;
                PlayerList[1].NamePlayer = Config.NAME_PLAYER2;
            }
            txtPlayer.Text = PlayerList[Turn].NamePlayer;
            txtPlayer.BackColor = PlayerList[Turn].ColorPlayer;
            winManager.NewGameHanlde(player);
            if (Config.caroFlow.Peek() == Config.NAME.SIZE_SETTING) DrawCaroBoard();
            else DrawCaroBoard(Config.NUMBER_OF_ROW, Config.NUMBER_OF_COLUMN);
            lblTime.Text = (Config.TIME_CONFIG.IsTime && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) ? 
                Config.TIME_CONFIG.TimeTurn.ToString() : "No Timer";
            Config.IS_OLD_GAME = false;
            Config.INDEX_OLD_GAME = -1;
            newGameEvent(this, new EventArgs());
        }

        /// <summary>
        /// Change the stype of buttons when game over
        /// </summary>
        /// <param name="eventBut">The button make the end game</param>
        private void ChangeFlatStypeWhenEndGame(Button eventBut)
        {
            int[] check = winManager.check;
            if (check[0] == 1)
            {
                foreach (KeyValuePair<int, int> item in winManager.arrRow)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[1] == 1)
            {
                foreach (KeyValuePair<int, int> item in winManager.arrColumn)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[2] == 1)
            {
                foreach (KeyValuePair<int, int> item in winManager.arrMainDiagonal)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            if (check[3] == 1)
            {
                foreach (KeyValuePair<int, int> item in winManager.arrSubDiagomal)
                    caroBoard[item].FlatStyle = FlatStyle.Flat;
            }
            eventBut.FlatStyle = FlatStyle.Flat;
        }

        /// <summary>
        /// Handle the action of end game
        /// </summary>
        /// <param name="player">The winer</param>
        /// <param name="eventBut">The button make the end game</param>
        /// <param name="sign">A symbol that identifies how the game ended. Zero when one of players winned and other when nobody winned</param>
        private void EndGameHandle(int player, Button eventBut, int sign = 0)
        {
            endGameEvent(this, new EventArgs());
            pnlCaroBoard.Enabled = false;
            if (sign == 0) ChangeFlatStypeWhenEndGame(eventBut);
            if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.TWO_PLAYER)
            {
                if (sign == 0) MessageBox.Show(String.Format("The {0} win", PlayerList[player].NamePlayer), "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) NewGameHandle(player);
            }
            else if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN && !Config.LAN_CONFIG.IsTurn)
            {
                Config.LAN_CONFIG.IsLock = !Config.LAN_CONFIG.IsLock;
                Config.LAN_CONFIG.IsTurn = !Config.LAN_CONFIG.IsTurn;
                if (sign == 0) MessageBox.Show("You are the winner", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    MessageData message = new MessageData(112, 0, 0, "");
                    lanManager.SEND_TCP(message, SocketFlags.None);
                    NewGameHandle(player);
                }
                else
                {

                }
            }
            else if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN && Config.LAN_CONFIG.IsTurn)
            {
                Config.LAN_CONFIG.IsLock = !Config.LAN_CONFIG.IsLock;
                Config.LAN_CONFIG.IsTurn = !Config.LAN_CONFIG.IsTurn;
                if (sign == 0) MessageBox.Show("You are the lost", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handle the action of undo game
        /// </summary>
        public void UndoHandle()
        {
            if (butUndo.Count > 0)
            {
                try
                {
                    if (Config.TIME_CONFIG.IsTime) lblTime.Text = Config.TIME_CONFIG.TimeTurn.ToString();
                    else lblTime.Text = "No Timer";
                    Button but = butUndo.Pop();
                    butRedo.Push(but);
                    but.BackColor = Color.Transparent;
                    but.FlatStyle = FlatStyle.Standard;
                    winManager.UndoHandle(but.Location.X, but.Location.Y);
                    if (butUndo.Count > 0) butUndo.Peek().FlatStyle = FlatStyle.Flat;
                    TurnPalyer();
                }
                catch
                {
                    MessageBox.Show("Do not undo game", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handle the action of redo game
        /// </summary>
        public void RedoHandle()
        {
            if (butRedo.Count > 0)
            {
                if (Config.TIME_CONFIG.IsTime) lblTime.Text = Config.TIME_CONFIG.TimeTurn.ToString();
                else lblTime.Text = "No Timer";
                Button but = butRedo.Pop();
                if (butUndo.Count > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                butUndo.Push(but);
                but.BackColor = PlayerList[Turn].ColorPlayer;
                but.FlatStyle = FlatStyle.Flat;
                winManager.RedoHandle(but.Location.X, but.Location.Y);
                TurnPalyer();
            }
        }

        /// <summary>
        /// Send the location to move chess base on socket with LAN network
        /// </summary>
        /// <param name="X">X-coordinate</param>
        /// <param name="Y">Y-coordinate</param>
        public void LANMovePointHandle(int X, int Y)
        {
            Config.LAN_CONFIG.IsLock = true;
            Button eventBut = caroBoard[new KeyValuePair<int, int>(X, Y)];
            But_Click(eventBut, new EventArgs());
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            int X = eventBut.Location.X;
            int Y = eventBut.Location.Y;
            if (eventBut.Image == null && Config.LAN_CONFIG.IsLock)
            {
                if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN && Config.LAN_CONFIG.IsTurn)
                {
                    MessageData message = new MessageData(101, X, Y, "");
                    lanManager.SEND_TCP(message, SocketFlags.None);
                    Config.LAN_CONFIG.IsTurn = !Config.LAN_CONFIG.IsTurn;
                    Config.LAN_CONFIG.IsLock = !Config.LAN_CONFIG.IsLock;
                }
                else if (Config.GAME_MODE.CurrentGameMode == Config.GAME_MODE.LAN) Config.LAN_CONFIG.IsTurn = !Config.LAN_CONFIG.IsTurn;
                if (Config.TIME_CONFIG.IsTime && Config.GAME_MODE.CurrentGameMode != Config.GAME_MODE.LAN) 
                    lblTime.Text = Config.TIME_CONFIG.TimeTurn.ToString();
                eventBut.FlatStyle = FlatStyle.Flat;
                if (butUndo.Count > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                butUndo.Push(eventBut);
                winManager.Turn = Turn;
                eventBut.BackColor = PlayerList[Turn].ColorPlayer;
                if (winManager.IsWiner(X, Y).Result) EndGameHandle(Turn, eventBut);
                else if (winManager.IsEndGame()) EndGameHandle(Turn, eventBut, 1);
                else
                {
                    winManager.DrawCaroBoard(X, Y);
                    CrossThread.PerformSafely(txtPlayer, TurnPalyer);
                }
            }
        }
    }
}

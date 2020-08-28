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
        public Panel pnlCaroBoard;
        private TextBox txtPlayer;
        private Label lblTime;
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

        public CaroManager(TextBox txtPlayer, Panel pnlCaroBoard, Label lblTime)
        {
            this.txtPlayer = txtPlayer;
            this.pnlCaroBoard = pnlCaroBoard;
            this.lblTime = lblTime;
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
                        Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                        Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i)
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new KeyValuePair<int, int>(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i), but);
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
                        Size = new Size(Config.CHESS_SIZE.Width, Config.CHESS_SIZE.Height),
                        Location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i)
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

        private void TurnPalyer()
        {
            Turn = 1 - Turn;
            PlayerList[Turn].IsTurn = 1;
            PlayerList[1 - Turn].IsTurn = 0;
            txtPlayer.BackColor = PlayerList[Turn].ColorPlayer;
            txtPlayer.Text = PlayerList[Turn].NamePlayer;
        }

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

        public void NewGameHandle(int player)
        {
            Turn = player;
            pnlCaroBoard.Enabled = true;
            if (Config.GAME_MODE == "LAN" && !Config.IS_SERVER)
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
            DrawCaroBoard(Config.NUMBER_OF_ROW, Config.NUMBER_OF_COLUMN);
            lblTime.Text = (Config.IS_ON_TIMER && Config.GAME_MODE != "LAN") ? Config.TIME_TURN.ToString() : "No Timer";
            Config.IS_OLD_GAME = false;
            Config.INDEX_OLD_GAME = -1;
            newGameEvent(this, new EventArgs());
        }

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

        private void EndGameHandle(int player, Button eventBut, int sign = 0)
        {
            endGameEvent(this, new EventArgs());
            pnlCaroBoard.Enabled = false;
            if (sign == 0) ChangeFlatStypeWhenEndGame(eventBut);
            if (Config.GAME_MODE == "TWO_PLAYER")
            {
                if (sign == 0) MessageBox.Show(String.Format("The {0} win", PlayerList[player].NamePlayer), "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) NewGameHandle(player);
            }
            else if (Config.GAME_MODE == "LAN" && !Config.IS_TURN)
            {
                Config.IS_LOCK = !Config.IS_LOCK;
                Config.IS_TURN = !Config.IS_TURN;
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
            else if (Config.GAME_MODE == "LAN" && Config.IS_TURN)
            {
                Config.IS_LOCK = !Config.IS_LOCK;
                Config.IS_TURN = !Config.IS_TURN;
                if (sign == 0) MessageBox.Show("You are the lost", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("The Game is ended, no players is winer", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UndoHandle()
        {
            if (butUndo.Count() > 0)
            {
                if (Config.IS_ON_TIMER) lblTime.Text = Config.TIME_TURN.ToString();
                else lblTime.Text = "No Timer";
                Button but = butUndo.Pop();
                butRedo.Push(but);
                but.BackColor = Color.Transparent;
                but.FlatStyle = FlatStyle.Standard;
                winManager.UndoHandle(but.Location.X, but.Location.Y);
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Flat;
                TurnPalyer();
            }
        }

        public void RedoHandle()
        {
            if (butRedo.Count() > 0)
            {
                if (Config.IS_ON_TIMER) lblTime.Text = Config.TIME_TURN.ToString();
                else lblTime.Text = "No Timer";
                try
                {
                    Button but = butRedo.Pop();
                    if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                    butUndo.Push(but);
                    but.BackColor = PlayerList[Turn].ColorPlayer;
                    but.FlatStyle = FlatStyle.Flat;
                    winManager.RedoHandle(but.Location.X, but.Location.Y);
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
            Config.IS_LOCK = true;
            Button eventBut = caroBoard[new KeyValuePair<int, int>(X, Y)];
            But_Click(eventBut, new EventArgs());
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button eventBut = sender as Button;
            int X = eventBut.Location.X;
            int Y = eventBut.Location.Y;
            if (eventBut.Image == null && Config.IS_LOCK)
            {
                if (Config.GAME_MODE == "LAN" && Config.IS_TURN)
                {
                    MessageData message = new MessageData(101, X, Y, "");
                    lanManager.SEND_TCP(message, SocketFlags.None);
                    Config.IS_TURN = !Config.IS_TURN;
                    Config.IS_LOCK = !Config.IS_LOCK;
                }
                else if (Config.GAME_MODE == "LAN") Config.IS_TURN = !Config.IS_TURN;
                if (Config.IS_ON_TIMER && Config.GAME_MODE != "LAN") lblTime.Text = Config.TIME_TURN.ToString();
                eventBut.FlatStyle = FlatStyle.Flat;
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
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

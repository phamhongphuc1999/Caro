using CaroTest.Setting;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using CaroTest.ConnectManager;
using System.Net.Sockets;

namespace CaroTest.CaroManager
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
            checkWinner = new CheckWinner(CONST.numberOfColumn, CONST.numberOfRow);
            caroBoard = new Dictionary<KeyValuePair<int, int>, Button>();
            playerList = new List<Player>()
            {
                new Player("", Image.FromFile("./Image/red.png"), 0),
                new Player("", Image.FromFile("./Image/green.png"), 1)
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
                        Size = new Size(CONST.WIDTH, CONST.HEIGHT),
                        Location = new Point(CONST.WIDTH * j, CONST.HEIGHT * i)
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new KeyValuePair<int, int>(CONST.WIDTH * j, CONST.HEIGHT * i), but);
                    pnlCaroBoard.Controls.Add(but);
                }
            }
        }

        private void TurnPalyer()
        {
            turn = 1 - turn;
            playerList[turn].IsTurn = 1;
            playerList[1 - turn].IsTurn = 0;
            if (turn == 0)
            {

                txtPlayer.BackColor = Color.Red;
                txtPlayer.Text = playerList[0].NamePlayer;
            }
            else
            {
                txtPlayer.BackColor = Color.Green;
                txtPlayer.Text = playerList[1].NamePlayer;
            }
        }

        public void NewGameHandle(int player)
        {
            turn = player;
            if (CONST.gameMode == "LAN" && !CONST.isServer)
            {
                playerList[0].NamePlayer = CONST.NAME_PLAYER2;
                playerList[1].NamePlayer = CONST.NAME_PLAYER1;
            }
            else if (CONST.gameMode == "LAN" && CONST.isServer)
            {
                playerList[0].NamePlayer = CONST.NAME_PLAYER1;
                playerList[1].NamePlayer = CONST.NAME_PLAYER2;
            }
            else
            {
                playerList[0].NamePlayer = CONST.NAME_PLAYER1;
                playerList[1].NamePlayer = CONST.NAME_PLAYER2;
            }
            txtPlayer.Text = playerList[turn].NamePlayer;
            txtPlayer.BackColor = (turn == 0) ? Color.Red : Color.Green;
            checkWinner.NewGameHanlde(player);
            txtPlayer.Text = playerList[player].NamePlayer;
            txtPlayer.BackColor = (player == 0) ? Color.Red : Color.Green;
            DrawCaroBoard(CONST.numberOfRow, CONST.numberOfColumn);
            lblTime.Text = CONST.TIME_TURN.ToString();
            newGameEvent(this, new EventArgs());
        }

        private void EndGameHandle(int player, Button eventBut)
        {
            endGameEvent(this, new EventArgs());
            pnlCaroBoard.Enabled = true;
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
            if (CONST.gameMode == "TWO_PLAYER")
            {
                MessageBox.Show("The " + playerList[player].NamePlayer + " win", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK) NewGameHandle(player);
            }
            else if (CONST.gameMode == "LAN" && !CONST.IS_TURN)
            {
                CONST.IS_LOCK = !CONST.IS_LOCK;
                CONST.IS_TURN = !CONST.IS_TURN;
                MessageBox.Show("You are the winner", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    socketManager.SEND_TCP(EncapsulateData.CreateMessage(112, ""), SocketFlags.None);
                    NewGameHandle(player);
                }
                else
                {

                }
            }
            else if (CONST.gameMode == "LAN" && CONST.IS_TURN)
            {
                CONST.IS_LOCK = !CONST.IS_LOCK;
                CONST.IS_TURN = !CONST.IS_TURN;
                MessageBox.Show("You are the lost", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UndoHandle()
        {
            if (butUndo.Count() > 0)
            {
                lblTime.Text = CONST.TIME_TURN.ToString();
                Button but = butUndo.Pop();
                butRedo.Push(but);
                but.Image = null;
                but.FlatStyle = FlatStyle.Standard;
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Flat;
                TurnPalyer();
            }
        }

        public void RedoHandle()
        {
            if (butRedo.Count() > 0)
            {
                lblTime.Text = CONST.TIME_TURN.ToString();
                Button but = butRedo.Pop();
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                butUndo.Push(but);
                but.Image = playerList[turn].ImagePlayer;
                but.FlatStyle = FlatStyle.Flat;
                TurnPalyer();
            }
        }

        public void LANMovePointHandle(int X, int Y)
        {
            CONST.IS_LOCK = true;
            Button eventBut = caroBoard[new KeyValuePair<int, int>(X, Y)];
            But_Click(eventBut, new EventArgs());
        }

        #region Event handle
        private void But_Click(object sender, EventArgs e)
        {
            Button eventBut = (Button)sender;
            int X = eventBut.Location.X;
            int Y = eventBut.Location.Y;
            if (eventBut.Image == null && CONST.IS_LOCK)
            {
                if (CONST.gameMode == "LAN" && CONST.IS_TURN)
                {
                    string sX = X.ToString(), sY = Y.ToString();
                    socketManager.SEND_TCP(EncapsulateData.CreateMessage(101, sX + " " + sY), SocketFlags.None);
                    CONST.IS_TURN = !CONST.IS_TURN;
                    CONST.IS_LOCK = !CONST.IS_LOCK;
                }
                else if (CONST.gameMode == "LAN") CONST.IS_TURN = !CONST.IS_TURN;
                lblTime.Text = CONST.TIME_TURN.ToString();
                eventBut.FlatStyle = FlatStyle.Flat;
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                butUndo.Push(eventBut);
                checkWinner.Turn = turn;
                eventBut.Image = playerList[turn].ImagePlayer;
                bool isWiner = checkWinner.IsWiner(X, Y);
                if (isWiner) EndGameHandle(turn, eventBut);
                else
                {
                    checkWinner.DrawCaroBoard(X, Y);
                    CrossThread.PerformSafely(txtPlayer, TurnPalyer);
                }
            }
        }
        #endregion
    }
}

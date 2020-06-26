using Caro.Setting;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

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
        private Panel pnlCaroBoard;
        private TextBox txtPlayer;
        private Label lblTime;
        private static CheckWinner checkWinner;
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
                new Player("Player 1", Image.FromFile("./Image/red.png"), 0),
                new Player("Player 2", Image.FromFile("./Image/green.png"), 1)
            };
            txtPlayer.Text = "Player 1";
            txtPlayer.BackColor = Color.Red;
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
                txtPlayer.Text = "Player 1";
                txtPlayer.BackColor = Color.Red;
            }
            else
            {
                txtPlayer.Text = "Player 2";
                txtPlayer.BackColor = Color.Green;
            }
        }

        public void NewGameHandle(int player)
        {
            turn = player;
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
            MessageBox.Show("The " + playerList[player].NamePlayer + " win", "ANNOUNT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult result = MessageBox.Show("Do you want to play new game?", "ANNOUNT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK) NewGameHandle(player);
        }

        public void UndoHandle()
        {
            if (butUndo.Count() > 0)
            {
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
                Button but = butRedo.Pop();
                if (butUndo.Count() > 0) butUndo.Peek().FlatStyle = FlatStyle.Standard;
                butUndo.Push(but);
                but.Image = playerList[turn].ImagePlayer;
                but.FlatStyle = FlatStyle.Flat;
                TurnPalyer();
            }
        }

        #region Event handle
        private void But_Click(object sender, System.EventArgs e)
        {
            Button eventBut = (Button)sender;
            int X = eventBut.Location.X;
            int Y = eventBut.Location.Y;
            if (eventBut.Image == null)
            {
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
                    TurnPalyer();
                }
            }
        }
        #endregion
    }
}

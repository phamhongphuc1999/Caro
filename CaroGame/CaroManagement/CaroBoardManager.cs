using CaroGame.Configuration;
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
        private MainPanel MainView;
        private Panel caroBoardView;
        private Dictionary<Point, Button> caroBoard;
        private TextBox playerTxt;
        private Label timeLbl;

        public Action<object, EventArgs> ButClick;

        public void InitMainView(MainPanel mainView)
        {
            MainView = mainView;
            caroBoardView = mainView.caroBoardView;
            playerTxt = mainView.playerTxt;
            timeLbl = mainView.timeLbl;
        }

        public void Turn()
        {
            playerTxt.Text = playerManager.CurrentPlayerName;
            playerTxt.BackColor = playerManager.CurrentPlayerColor;
        }

        public void InitCaroBoard()
        {
            playerTxt.Text = playerManager.CurrentPlayerName;
            playerTxt.BackColor = playerManager.CurrentPlayerColor;
            caroBoard = new Dictionary<Point, Button>();
        }

        public void DrawCaroBoard()
        {
            caroBoardView.Controls.Clear();
            caroBoardView.Enabled = true;
            caroBoard.Clear();
            for (int i = 0; i < SettingConfig.NUMBER_OF_ROW; i++)
            {
                for (int j = 0; j < SettingConfig.NUMBER_OF_COLUMN; j++)
                {
                    Button but = new Button()
                    {
                        Size = new Size(Constants.CHESS_WIDTH, Constants.CHESS_HEIGHT),
                        Location = new Point(Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i),
                        FlatStyle = FlatStyle.Standard
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new Point(Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i), but);
                    caroBoardView.Controls.Add(but);
                }
            }
        }

        public void CreateNewGame(int turn)
        {
            playerManager.Turn = turn;
            actionManager.ResetAction();
            InitCaroBoard();
            DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
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
                else
                {
                    playerManager.Turn = playerManager.Turn + 1;
                    winnerManager.Turn = 1 - winnerManager.Turn;
                    Turn();
                }
            }
        }
    }
}

using Caro.Setting;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Caro.CaroManager
{
    class Manager
    {
        private Form1 mainForm;
        private Panel pnlCaroBoard;
        private TextBox txtPlayer;
        private static CONST caroConst;
        private static CheckWinner checkWinner;
        private Dictionary<KeyValuePair<int, int>, Button> caroBoard;
        private List<Player> playerList;

        public Manager(Form1 mainForm, TextBox txtPlayer, Panel pnlCaroBoard, CONST caroConst)
        {
            this.mainForm = mainForm;
            this.txtPlayer = txtPlayer;
            this.pnlCaroBoard = pnlCaroBoard;
            Manager.caroConst = caroConst;
            checkWinner = new CheckWinner(caroConst.numberOfColumn, caroConst.numberOfRow);

            caroBoard = new Dictionary<KeyValuePair<int, int>, Button>();
            playerList = new List<Player>()
            {
                new Player("Player 1", Image.FromFile("./Image/red.png"), 0),
                new Player("Player 2", Image.FromFile("./Image/green.png"), 1)
            };
            txtPlayer.Text = "Player 1";
            txtPlayer.BackColor = Color.Red;
        }

        public void DrawCaroBoard(int numberOfRow, int numberOfColumn)
        {
            pnlCaroBoard.Controls.Clear();
            for(int i = 0; i < numberOfRow; i++)
            {
                for(int j = 0; j < numberOfColumn; j++)
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

        private int TurnPalyer()
        {
            int player = -1;
            if(playerList[0].IsTurn == 1)
            {
                player = 1;
                playerList[0].IsTurn = 0;
                playerList[1].IsTurn = 1;
                txtPlayer.Text = "Player 1";
                txtPlayer.BackColor = Color.Red;
            }
            else
            {
                player = 0;
                playerList[1].IsTurn = 0;
                playerList[0].IsTurn = 1;
                txtPlayer.Text = "Player 2";
                txtPlayer.BackColor = Color.Green;
            }
            return player;
        }

        #region Event handle
        private void But_Click(object sender, System.EventArgs e)
        {
            Button eventBut = (Button)sender;
            int X = eventBut.Location.X;
            int Y = eventBut.Location.Y;
            if(eventBut.Image == null)
            {
                int player = TurnPalyer();
                checkWinner.Turn = player;
                eventBut.Image = playerList[player].ImagePlayer;
                bool isWiner = checkWinner.IsWiner(X, Y);
                if (isWiner) MessageBox.Show("Win");
                else checkWinner.DrawCaroBoard(X, Y);
            }
        }
        #endregion
    }
}

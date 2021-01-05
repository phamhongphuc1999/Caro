using CaroGame.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    internal class DisplayManager
    {
        public Panel PnlCaroBoard { get; set; }
        private Dictionary<KeyValuePair<int, int>, Button> caroBoard;

        public Action<object, EventArgs> ButClick { get; set; }

        public DisplayManager()
        {
            PnlCaroBoard = new Panel();
            caroBoard = new Dictionary<KeyValuePair<int, int>, Button>();
        }

        public void DrawCaroBoard()
        {
            PnlCaroBoard.Controls.Clear();
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
                    PnlCaroBoard.Controls.Add(but);
                }
            }
        }

        public void DrawCaroBoard(int numberOfRow, int numberOfColumn)
        {
            if (PnlCaroBoard.Controls.Count == 0)
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
                        PnlCaroBoard.Controls.Add(but);
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

        private void But_Click(object sender, EventArgs e)
        {
            this.ButClick(sender, e);
        }
    }
}

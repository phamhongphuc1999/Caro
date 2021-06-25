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

        public void InitCaroBoard()
        {
            int width = SettingConfig.NUMBER_OF_COLUMN * Constants.CHESS_WIDTH;
            int height = SettingConfig.NUMBER_OF_ROW * Constants.CHESS_HEIGHT;
            playerTxt.Text = playerManager.CurrentPlayerName;
            playerTxt.BackColor = playerManager.CurrentPlayerColor;
            //caroBoardView.Size = new Size(width, height);
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
                        Location = new Point(2 + Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i),
                        FlatStyle = FlatStyle.Standard
                    };
                    but.Click += But_Click;
                    caroBoard.Add(new Point(Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i), but);
                    caroBoardView.Controls.Add(but);
                }
            }
        }

        private void But_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MainView.Width.ToString());
        }
    }
}

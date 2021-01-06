using CaroGame.PlayerManagement;
using CaroGame.Presentation.CaroPanel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    public class CaroManager
    {
        private PlayerManager playerManager;
        private CaroBoardManager caroBoardManager;
        private WinnerManager winnerManager;

        public CaroManager()
        {
            playerManager = new PlayerManager();
            caroBoardManager = new CaroBoardManager();
            winnerManager = new WinnerManager();
            caroBoardManager.ButClick = But_Click;
        }

        public Panel CaroGameBoard
        {
            get { return caroBoardManager.CaroBoardPnl; }
        }

        public void CreateNewGame(int turn = 1)
        {
            caroBoardManager.ResizeCaroBoard();
            caroBoardManager.DrawCaroBoard();
            winnerManager.NewGameHanlde(turn);
            playerManager.Turn = turn % 2;
        }

        private void But_Click(object sender, EventArgs e)
        {
            MessageBox.Show("123");
        }
    }
}

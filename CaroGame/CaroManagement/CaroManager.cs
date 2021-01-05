using CaroGame.PlayerManagement;
using System;

namespace CaroGame.CaroManagement
{
    public class CaroManager
    {
        private PlayerManager playerManager;
        private DisplayManager displayManager;
        private WinnerManager winnerManager;

        public CaroManager()
        {
            playerManager = new PlayerManager();
            displayManager = new DisplayManager();
            displayManager.ButClick = But_Click;
        }

        public void CreateNewGame(int turn)
        {
            playerManager.Turn = turn % 2;
            displayManager.DrawCaroBoard();
        }

        private void But_Click(object sender, EventArgs e)
        {

        }
    }
}

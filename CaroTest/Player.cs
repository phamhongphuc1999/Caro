using System.Drawing;

namespace CaroTest
{
    public class Player
    {
        private string namePlayer;
        public string NamePlayer
        {
            get { return namePlayer; }
            set { namePlayer = value; }
        }

        private int isTurn;
        public int IsTurn
        {
            get { return isTurn; }
            set { isTurn = value; }
        }

        private Image imagePlayer;
        public Image ImagePlayer
        {
            get { return imagePlayer; }
            set { imagePlayer = value; }
        }

        public Player(string namePlayer, Image imagePlayer, int isTurn)
        {
            this.namePlayer = namePlayer;
            this.imagePlayer = imagePlayer;
            this.isTurn = isTurn;
        }
    }
}

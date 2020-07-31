using System.Drawing;

namespace Caro
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

        private Color colorPlayer;
        public Color ColorPlayer
        {
            get { return colorPlayer; }
            set { colorPlayer = value; }
        }

        public Player(string namePlayer, Color colorPlayer, int isTurn)
        {
            this.namePlayer = namePlayer;
            this.colorPlayer = colorPlayer;
            this.isTurn = isTurn;
        }
    }
}

using System.Drawing;

namespace CaroGame.PlayerManagement
{
    public class PlayerManager
    {
        private Player player1;
        private Player player2;

        public PlayerManager()
        {
            player1 = new Player("player1", Color.Green, true);
            player2 = new Player("player2", Color.Red, false);
        }

        public PlayerManager(string playerName1, string playerName2)
        {
            player1 = new Player(playerName1, Color.Green, true);
            player2 = new Player(playerName2, Color.Red, false);
        }

        public int Turn
        {
            get { return player1.IsTurn ? 1 : 2; }
            set
            {
                if(value == 1)
                {
                    player1.IsTurn = true;
                    player2.IsTurn = false;
                }
                else if(value == 2)
                {
                    player1.IsTurn = false;
                    player2.IsTurn = true;
                }
            }
        }

        public string PlayerName1
        {
            get { return player1.NamePlayer; }
        }

        public string PlayerName2
        {
            get { return player2.NamePlayer; }
        }

        public Color PlayerColor1
        {
            get { return player1.ColorPlayer; }
        }

        public Color PlayerColor2
        {
            get { return player2.ColorPlayer; }
        }
    }
}

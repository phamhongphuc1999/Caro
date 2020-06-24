using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private Image imagePlayer;
        public Image ImagePlayer
        {
            get { return imagePlayer; }
            set { imagePlayer = value; }
        }

        public Player(string namePlayer, Image imagePlayer)
        {
            this.namePlayer = namePlayer;
            this.imagePlayer = imagePlayer;
        }
    }
}

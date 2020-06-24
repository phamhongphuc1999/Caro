using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caro.Setting
{
    public class CONST
    {
        public string gameMode;
        public int numberOfRow, numberOfColumn;
        public static int WIDTH = 25;
        public static int HEIGHT = 25;

        public CONST(string gameMode = "ONE_COMPUTER", int  numberOfRow = 10, int numberOfColumn = 10)
        {
            this.gameMode = gameMode;
            this.numberOfColumn = numberOfColumn;
            this.numberOfRow = numberOfRow;
        }
    }
}

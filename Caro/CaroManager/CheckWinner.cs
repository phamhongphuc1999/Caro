using Caro.Setting;
using System.Collections.Generic;

namespace Caro.CaroManager
{
    class CheckWinner
    {
        private int turn;
        public int Turn
        {
            get { return turn; }
            set { turn = value; }
        }
        private int numberOfColumn;
        private int numberOfRow;
        private Dictionary<KeyValuePair<int, int>, int> caroBoard;

        public CheckWinner(int numberOfColumn, int numberOfRow)
        {
            this.numberOfColumn = numberOfColumn;
            this.numberOfRow = numberOfRow;

            caroBoard = new Dictionary<KeyValuePair<int, int>, int>();
        }

        public void DrawCaroBoard(int X, int Y)
        {
            caroBoard.Add(new KeyValuePair<int, int>(X, Y), turn);
        }

        public bool IsWiner(int X, int Y)
        {
            return IsWinColumn(X, Y) || IsWinRow(X, Y) || IsWinMainDiagonal(X, Y) || IsWinSubDiagonal(X, Y);
        }

        private bool IsWinRow(int X, int Y)
        {
            int count = 0, player = -1;
            for(int i = X - CONST.WIDTH; i >= 0; i = i - CONST.WIDTH)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(i, Y), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            int MAX_X = numberOfColumn * CONST.WIDTH;
            for(int i = X + CONST.WIDTH; i <= MAX_X; i = i + CONST.WIDTH)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(i, Y), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            return (count == 4);
        }

        private bool IsWinColumn(int X, int Y)
        {
            int count = 0, player = -1;
            for(int i = Y - CONST.HEIGHT; i >= 0; i = i - CONST.HEIGHT)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(X, i), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            int MAX_Y = numberOfRow * CONST.HEIGHT;
            for(int i = Y + CONST.HEIGHT; i <= MAX_Y; i = i + CONST.HEIGHT)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(X, i), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            return (count == 4);
        }

        private bool IsWinMainDiagonal(int X, int Y)
        {
            int count = 0, player = -1;
            for (int i = X - CONST.WIDTH, j = Y - CONST.HEIGHT; i >= 0 && j >= 0; i = i - CONST.WIDTH, j = j - CONST.HEIGHT)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(i, j), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            int MAX_X = numberOfColumn * CONST.WIDTH;
            int MAX_Y = numberOfRow * CONST.HEIGHT;
            for (int i = X + CONST.WIDTH, j = Y + CONST.HEIGHT; i <= MAX_X && j < MAX_Y; i = i + CONST.WIDTH, j = j + CONST.HEIGHT)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(i, j), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            return (count == 4);
        }

        private bool IsWinSubDiagonal(int X, int Y)
        {
            int count = 0, player = -1;
            int MAX_X = numberOfColumn * CONST.WIDTH;
            for (int i = X + CONST.WIDTH, j = Y - CONST.HEIGHT; i <= MAX_X && j >= 0; i = i + CONST.WIDTH, j = j - CONST.HEIGHT)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(i, j), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            int MAX_Y = numberOfRow * CONST.HEIGHT;
            for(int i = X - CONST.WIDTH, j = Y + CONST.HEIGHT; i >= 0 && j <= MAX_Y; i = i - CONST.WIDTH, j = j + CONST.HEIGHT)
            {
                if (caroBoard.TryGetValue(new KeyValuePair<int, int>(i, j), out player))
                {
                    if (player == turn) count++;
                    else break;
                }
                else break;
            }
            return (count == 4);
        }
    }
}

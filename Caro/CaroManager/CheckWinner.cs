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
        public KeyValuePair<int, int>[] arrRow, arrColumn, arrMainDiagonal, arrSubDiagomal;
        public int[] check;

        public CheckWinner(int numberOfColumn, int numberOfRow)
        {
            this.numberOfColumn = numberOfColumn;
            this.numberOfRow = numberOfRow;

            caroBoard = new Dictionary<KeyValuePair<int, int>, int>();
            arrRow = new KeyValuePair<int, int>[4];
            arrColumn = new KeyValuePair<int, int>[4];
            arrMainDiagonal = new KeyValuePair<int, int>[4];
            arrSubDiagomal = new KeyValuePair<int, int>[4];
            check = new int[4] { 0, 0, 0, 0 };
        }

        public void NewGameHanlde(int turn)
        {
            this.turn = turn;
            check[0] = check[1] = check[2] = check[3] = 0;
            caroBoard.Clear();
        }

        public void DrawCaroBoard(int X, int Y)
        {
            caroBoard.Add(new KeyValuePair<int, int>(X, Y), turn);
        }

        public bool IsWiner(int X, int Y)
        {
            bool row = IsWinRow(X, Y);
            bool collumn = IsWinColumn(X, Y);
            bool mainDiagonal = IsWinMainDiagonal(X, Y);
            bool subDiagonal = IsWinSubDiagonal(X, Y);
            if (row) check[0] = 1;
            if (collumn) check[1] = 1;
            if (mainDiagonal) check[2] = 1;
            if (subDiagonal) check[3] = 1;
            return row || collumn || mainDiagonal || subDiagonal;
        }

        private bool IsWinRow(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for(int i = X - CONST.WIDTH; i >= 0; i = i - CONST.WIDTH)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(i, Y);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrRow[count] = temp;
                        count++;
                        if (i == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_X = numberOfColumn * CONST.WIDTH;
            for(int i = X + CONST.WIDTH; i <= MAX_X; i = i + CONST.WIDTH)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(i, Y);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrRow[count] = temp;
                        count++;
                        if (i == MAX_X) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            return (count == 4) && (countEnemy < 2);
        }

        private bool IsWinColumn(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for(int i = Y - CONST.HEIGHT; i >= 0; i = i - CONST.HEIGHT)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(X, i);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrColumn[count] = temp;
                        count++;
                        if (i == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_Y = numberOfRow * CONST.HEIGHT;
            for(int i = Y + CONST.HEIGHT; i <= MAX_Y; i = i + CONST.HEIGHT)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(X, i);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrColumn[count] = temp;
                        count++;
                        if (i == MAX_Y) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            return (count == 4) && (countEnemy < 2);
        }

        private bool IsWinMainDiagonal(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = X - CONST.WIDTH, j = Y - CONST.HEIGHT; i >= 0 && j >= 0; i = i - CONST.WIDTH, j = j - CONST.HEIGHT)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrMainDiagonal[count] = temp;
                        count++;
                        if (i == 0 || j == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_X = numberOfColumn * CONST.WIDTH;
            int MAX_Y = numberOfRow * CONST.HEIGHT;
            for (int i = X + CONST.WIDTH, j = Y + CONST.HEIGHT; i <= MAX_X && j < MAX_Y; i = i + CONST.WIDTH, j = j + CONST.HEIGHT)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrMainDiagonal[count] = temp;
                        count++;
                        if (i == MAX_X || j == MAX_Y) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            return (count == 4) && (countEnemy < 2);
        }

        private bool IsWinSubDiagonal(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            int MAX_X = numberOfColumn * CONST.WIDTH;
            for (int i = X + CONST.WIDTH, j = Y - CONST.HEIGHT; i <= MAX_X && j >= 0; i = i + CONST.WIDTH, j = j - CONST.HEIGHT)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrSubDiagomal[count] = temp;
                        count++;
                        if (i == MAX_X || j == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_Y = numberOfRow * CONST.HEIGHT;
            for(int i = X - CONST.WIDTH, j = Y + CONST.HEIGHT; i >= 0 && j <= MAX_Y; i = i - CONST.WIDTH, j = j + CONST.HEIGHT)
            {
                KeyValuePair<int, int> temp = new KeyValuePair<int, int>(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == turn)
                    {
                        arrSubDiagomal[count] = temp;
                        count++;
                        if (i == 0 || j == MAX_Y) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            return (count == 4) && (countEnemy < 2);
        }
    }
}

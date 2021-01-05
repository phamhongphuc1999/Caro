using CaroGame.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace CaroGame.CaroManagement
{
    internal class WinnerManager
    {
        private int turn;
        public int Turn
        {
            get { return turn; }
            set { turn = value; }
        }
        private int numberOfColumn;
        private int numberOfRow;
        private int numberOfChess;
        private Dictionary<KeyValuePair<int, int>, int> caroBoard;
        public KeyValuePair<int, int>[] arrRow, arrColumn, arrMainDiagonal, arrSubDiagomal;
        public int[] check;

        public WinnerManager(int numberOfColumn, int numberOfRow)
        {
            this.numberOfColumn = numberOfColumn;
            this.numberOfRow = numberOfRow;
            numberOfChess = numberOfColumn * numberOfRow;

            caroBoard = new Dictionary<KeyValuePair<int, int>, int>();
            arrRow = new KeyValuePair<int, int>[4];
            arrColumn = new KeyValuePair<int, int>[4];
            arrMainDiagonal = new KeyValuePair<int, int>[4];
            arrSubDiagomal = new KeyValuePair<int, int>[4];
            check = new int[4] { 0, 0, 0, 0 };
        }

        /// <summary>
        /// Initialized the properties when new game
        /// </summary>
        /// <param name="turn">The player turn is created</param>
        public void NewGameHanlde(int turn)
        {
            this.turn = turn;
            check[0] = check[1] = check[2] = check[3] = 0;
            while (caroBoard.Count > 0) caroBoard.Clear();
            numberOfColumn = Config.NUMBER_OF_COLUMN;
            numberOfRow = Config.NUMBER_OF_ROW;
            numberOfChess = numberOfColumn * numberOfRow;
        }

        /// <summary>
        /// Add location of the chess in the dictionary
        /// </summary>
        /// <param name="X">X-coordinate</param>
        /// <param name="Y">Y-coordinate</param>
        public void DrawCaroBoard(int X, int Y)
        {
            caroBoard.Add(new KeyValuePair<int, int>(X, Y), turn);
        }

        /// <summary>
        /// Add location of the chess in the dictionary
        /// </summary>
        /// <param name="point">The location of chess</param>
        public void DrawCaroBoard(Point point)
        {
            caroBoard.Add(new KeyValuePair<int, int>(point.X, point.Y), turn);
        }

        /// <summary>
        /// Add location of the chess in the dictionary
        /// </summary>
        /// <param name="point">The location of chess</param>
        /// <param name="turn">The specified player's turn</param>
        public void DrawCaroBoard(Point point, int turn)
        {
            caroBoard.Add(new KeyValuePair<int, int>(point.X, point.Y), turn);
        }

        /// <summary>
        /// Remove the location of chess from dictionary when undo game
        /// </summary>
        /// <param name="X">X-coordinate</param>
        /// <param name="Y">Y-coordinate</param>
        public void UndoHandle(int X, int Y)
        {
            caroBoard.Remove(new KeyValuePair<int, int>(X, Y));
            turn = 1 - turn;
        }

        /// <summary>
        /// Add location of chess to dictinary when redo game
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void RedoHandle(int X, int Y)
        {
            caroBoard.Add(new KeyValuePair<int, int>(X, Y), turn);
            turn = 1 - turn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>True if ended game or False when game is continning</returns>
        public bool IsEndGame()
        {
            return caroBoard.Count == numberOfChess - 1;
        }

        /// <summary>
        /// Check end game when one of players winned
        /// </summary>
        /// <param name="X">X-continue of event button</param>
        /// <param name="Y">Y-continue of event button</param>
        /// <returns>True if one of players wined or False when nobody wined</returns>
        public async Task<bool> IsWiner(int X, int Y)
        {
            bool row = await IsWinRow(X, Y);
            bool collumn = await IsWinColumn(X, Y);
            bool mainDiagonal = await IsWinMainDiagonal(X, Y);
            bool subDiagonal = await IsWinSubDiagonal(X, Y);
            if (row) check[0] = 1;
            if (collumn) check[1] = 1;
            if (mainDiagonal) check[2] = 1;
            if (subDiagonal) check[3] = 1;
            return row || collumn || mainDiagonal || subDiagonal;
        }

#pragma warning disable CS1998
        /// <summary>
        /// check end game base on row
        /// </summary>
        /// <param name="X">X-continue of event button</param>
        /// <param name="Y">Y-continue of event button</param>
        /// <returns>True if one of players wined base on row or False when nobody wined</returns>
        private async Task<bool> IsWinRow(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = X - Config.CHESS_SIZE.Width; i >= 0; i = i - Config.CHESS_SIZE.Width)
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
            int MAX_X = numberOfColumn * Config.CHESS_SIZE.Width;
            for (int i = X + Config.CHESS_SIZE.Width; i <= MAX_X; i = i + Config.CHESS_SIZE.Width)
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

        /// <summary>
        /// check end game base on column
        /// </summary>
        /// <param name="X">X-continue of event button</param>
        /// <param name="Y">Y-continue of event button</param>
        /// <returns>True if one of players wined base on column or False when nobody wined</returns>
        private async Task<bool> IsWinColumn(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = Y - Config.CHESS_SIZE.Height; i >= 0; i = i - Config.CHESS_SIZE.Height)
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
            int MAX_Y = numberOfRow * Config.CHESS_SIZE.Height;
            for (int i = Y + Config.CHESS_SIZE.Height; i <= MAX_Y; i = i + Config.CHESS_SIZE.Height)
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

        /// <summary>
        /// check end game base on main diagonal
        /// </summary>
        /// <param name="X">X-continue of event button</param>
        /// <param name="Y">Y-continue of event button</param>
        /// <returns>True if one of players wined base on main diagonal or False when nobody wined</returns>
        private async Task<bool> IsWinMainDiagonal(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = X - Config.CHESS_SIZE.Width, j = Y - Config.CHESS_SIZE.Height;
                i >= 0 && j >= 0; i = i - Config.CHESS_SIZE.Width, j = j - Config.CHESS_SIZE.Height)
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
            int MAX_X = numberOfColumn * Config.CHESS_SIZE.Width;
            int MAX_Y = numberOfRow * Config.CHESS_SIZE.Height;
            for (int i = X + Config.CHESS_SIZE.Width, j = Y + Config.CHESS_SIZE.Height;
                i <= MAX_X && j < MAX_Y; i = i + Config.CHESS_SIZE.Width, j = j + Config.CHESS_SIZE.Height)
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

        /// <summary>
        /// check end game base on sub diagonal
        /// </summary>
        /// <param name="X">X-continue of event button</param>
        /// <param name="Y">Y-continue of event button</param>
        /// <returns>True if one of players wined base on sub diagonal or False when nobody wined</returns>
        private async Task<bool> IsWinSubDiagonal(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            int MAX_X = numberOfColumn * Config.CHESS_SIZE.Width;
            for (int i = X + Config.CHESS_SIZE.Width, j = Y - Config.CHESS_SIZE.Height;
                i <= MAX_X && j >= 0; i = i + Config.CHESS_SIZE.Width, j = j - Config.CHESS_SIZE.Height)
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
            int MAX_Y = numberOfRow * Config.CHESS_SIZE.Height;
            for (int i = X - Config.CHESS_SIZE.Width, j = Y + Config.CHESS_SIZE.Height;
                i >= 0 && j <= MAX_Y; i = i - Config.CHESS_SIZE.Width, j = j + Config.CHESS_SIZE.Height)
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

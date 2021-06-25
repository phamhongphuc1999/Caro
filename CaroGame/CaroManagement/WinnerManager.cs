using CaroGame.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace CaroGame.CaroManagement
{
    public class WinnerManager
    {
        public int Turn { get; set; }
        private Dictionary<Point, int> caroBoard;
        public Point[] arrRow, arrColumn, arrMainDiagonal, arrSubDiagomal;
        public int[] check;

        public WinnerManager()
        {
            caroBoard = new Dictionary<Point, int>();
            arrRow = new Point[4];
            arrColumn = new Point[4];
            arrMainDiagonal = new Point[4];
            arrSubDiagomal = new Point[4];
            check = new int[4] { 0, 0, 0, 0 };
        }

        public void ResetDictionary(int oldRow, int oldColumn)
        {
            if (oldRow > SettingConfig.NUMBER_OF_ROW)
            {
                for (int i = SettingConfig.NUMBER_OF_ROW; i < oldRow; i++)
                {
                    for (int j = 0; j < oldColumn; j++)
                    {
                        Point location = new Point(Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i);
                        if (caroBoard.ContainsKey(location)) caroBoard.Remove(location);
                    }
                }
            }
            if (oldColumn > SettingConfig.NUMBER_OF_COLUMN)
            {
                for (int i = 0; i < oldRow; i++)
                {
                    for (int j = SettingConfig.NUMBER_OF_COLUMN; j < oldColumn; j++)
                    {
                        Point location = new Point(Constants.CHESS_WIDTH * j, Constants.CHESS_HEIGHT * i);
                        if (caroBoard.ContainsKey(location)) caroBoard.Remove(location);
                    }
                }
            }
        }

        public bool CheckExtist(Point location)
        {
            return caroBoard.ContainsKey(location);
        }

        public void NewGameHanlde(int turn)
        {
            this.Turn = turn % 2;
            check[0] = check[1] = check[2] = check[3] = 0;
            caroBoard.Clear();
        }

        public void LoadSaveGame(int turn, List<(Point, int)> listChess)
        {
            this.Turn = turn % 2;
            check[0] = check[1] = check[2] = check[3] = 0;
            caroBoard.Clear();
            foreach ((Point, int) item in listChess)
                caroBoard.Add(item.Item1, item.Item2);
        }

        public void DrawCaroBoard(int X, int Y)
        {
            caroBoard.Add(new Point(X, Y), Turn);
        }

        public void DrawCaroBoard(Point point)
        {
            caroBoard.Add(point, Turn);
        }

        public void DrawCaroBoard(Point point, int turn)
        {
            caroBoard.Add(point, turn);
        }

        public void UndoHandle(int X, int Y)
        {
            caroBoard.Remove(new Point(X, Y));
            Turn = 1 - Turn;
        }

        public void RedoHandle(int X, int Y)
        {
            caroBoard.Add(new Point(X, Y), Turn);
            Turn = 1 - Turn;
        }

        public bool IsEndGame()
        {
            return caroBoard.Count == SettingConfig.NUMBER_OF_ROW * SettingConfig.NUMBER_OF_COLUMN - 1;
        }

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
        private async Task<bool> IsWinRow(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = X - Constants.CHESS_WIDTH; i >= 0; i = i - Constants.CHESS_WIDTH)
            {
                Point temp = new Point(i, Y);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
                    {
                        arrRow[count] = temp;
                        count++;
                        if (i == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_X = SettingConfig.NUMBER_OF_COLUMN * Constants.CHESS_WIDTH;
            for (int i = X + Constants.CHESS_WIDTH; i <= MAX_X; i = i + Constants.CHESS_WIDTH)
            {
                Point temp = new Point(i, Y);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
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

        private async Task<bool> IsWinColumn(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = Y - Constants.CHESS_HEIGHT; i >= 0; i = i - Constants.CHESS_HEIGHT)
            {
                Point temp = new Point(X, i);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
                    {
                        arrColumn[count] = temp;
                        count++;
                        if (i == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_Y = SettingConfig.NUMBER_OF_ROW * Constants.CHESS_HEIGHT;
            for (int i = Y + Constants.CHESS_HEIGHT; i <= MAX_Y; i = i + Constants.CHESS_HEIGHT)
            {
                Point temp = new Point(X, i);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
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

        private async Task<bool> IsWinMainDiagonal(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = X - Constants.CHESS_WIDTH, j = Y - Constants.CHESS_HEIGHT;
                i >= 0 && j >= 0; i = i - Constants.CHESS_WIDTH, j = j - Constants.CHESS_HEIGHT)
            {
                Point temp = new Point(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
                    {
                        arrMainDiagonal[count] = temp;
                        count++;
                        if (i == 0 || j == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_X = SettingConfig.NUMBER_OF_COLUMN * Constants.CHESS_WIDTH;
            int MAX_Y = SettingConfig.NUMBER_OF_ROW * Constants.CHESS_HEIGHT;
            for (int i = X + Constants.CHESS_WIDTH, j = Y + Constants.CHESS_HEIGHT;
                i <= MAX_X && j < MAX_Y; i = i + Constants.CHESS_WIDTH, j = j + Constants.CHESS_HEIGHT)
            {
                Point temp = new Point(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
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

        private async Task<bool> IsWinSubDiagonal(int X, int Y)
        {
            int count = 0, countEnemy = 0, player = -1;
            int MAX_X = SettingConfig.NUMBER_OF_COLUMN * Constants.CHESS_WIDTH;
            for (int i = X + Constants.CHESS_WIDTH, j = Y - Constants.CHESS_HEIGHT;
                i <= MAX_X && j >= 0; i = i + Constants.CHESS_WIDTH, j = j - Constants.CHESS_HEIGHT)
            {
                Point temp = new Point(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
                    {
                        arrSubDiagomal[count] = temp;
                        count++;
                        if (i == MAX_X || j == 0) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            int MAX_Y = SettingConfig.NUMBER_OF_ROW * Constants.CHESS_HEIGHT;
            for (int i = X - Constants.CHESS_WIDTH, j = Y + Constants.CHESS_HEIGHT;
                i >= 0 && j <= MAX_Y; i = i - Constants.CHESS_WIDTH, j = j + Constants.CHESS_HEIGHT)
            {
                Point temp = new Point(i, j);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
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

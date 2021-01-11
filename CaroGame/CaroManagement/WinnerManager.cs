// --------------------CARO  GAME-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ------------------------------------------------------

using CaroGame.Configuration;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame.CaroManagement
{
    internal class WinnerManager
    {
        public int Turn
        {
            get; set;
        }
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
            if (oldRow > Config.NUMBER_OF_ROW)
            {
                for (int i = Config.NUMBER_OF_ROW; i < oldRow; i++)
                {
                    for (int j = 0; j < oldColumn; j++)
                    {
                        Point location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i);
                        if (caroBoard.ContainsKey(location)) caroBoard.Remove(location);
                    }
                }
            }
            if (oldColumn > Config.NUMBER_OF_COLUMN)
            {
                for (int i = 0; i < oldRow; i++)
                {
                    for (int j = Config.NUMBER_OF_COLUMN; j < oldColumn; j++)
                    {
                        Point location = new Point(Config.CHESS_SIZE.Width * j, Config.CHESS_SIZE.Height * i);
                        if (caroBoard.ContainsKey(location)) caroBoard.Remove(location);
                    }
                }
            }
        }

        public void NewGameHanlde(int turn)
        {
            this.Turn = turn % 2;
            check[0] = check[1] = check[2] = check[3] = 0;
            while (caroBoard.Count > 0) caroBoard.Clear();
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
            return caroBoard.Count == Config.NUMBER_OF_ROW * Config.NUMBER_OF_COLUMN - 1;
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
            for (int i = X - Config.CHESS_SIZE.Width; i >= 0; i = i - Config.CHESS_SIZE.Width)
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
            int MAX_X = Config.NUMBER_OF_COLUMN * Config.CHESS_SIZE.Width;
            for (int i = X + Config.CHESS_SIZE.Width; i <= MAX_X; i = i + Config.CHESS_SIZE.Width)
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
            for (int i = Y - Config.CHESS_SIZE.Height; i >= 0; i = i - Config.CHESS_SIZE.Height)
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
            int MAX_Y = Config.NUMBER_OF_ROW * Config.CHESS_SIZE.Height;
            for (int i = Y + Config.CHESS_SIZE.Height; i <= MAX_Y; i = i + Config.CHESS_SIZE.Height)
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
            for (int i = X - Config.CHESS_SIZE.Width, j = Y - Config.CHESS_SIZE.Height;
                i >= 0 && j >= 0; i = i - Config.CHESS_SIZE.Width, j = j - Config.CHESS_SIZE.Height)
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
            int MAX_X = Config.NUMBER_OF_COLUMN * Config.CHESS_SIZE.Width;
            int MAX_Y = Config.NUMBER_OF_ROW * Config.CHESS_SIZE.Height;
            for (int i = X + Config.CHESS_SIZE.Width, j = Y + Config.CHESS_SIZE.Height;
                i <= MAX_X && j < MAX_Y; i = i + Config.CHESS_SIZE.Width, j = j + Config.CHESS_SIZE.Height)
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
            int MAX_X = Config.NUMBER_OF_COLUMN * Config.CHESS_SIZE.Width;
            for (int i = X + Config.CHESS_SIZE.Width, j = Y - Config.CHESS_SIZE.Height;
                i <= MAX_X && j >= 0; i = i + Config.CHESS_SIZE.Width, j = j - Config.CHESS_SIZE.Height)
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
            int MAX_Y = Config.NUMBER_OF_ROW * Config.CHESS_SIZE.Height;
            for (int i = X - Config.CHESS_SIZE.Width, j = Y + Config.CHESS_SIZE.Height;
                i >= 0 && j <= MAX_Y; i = i - Config.CHESS_SIZE.Width, j = j + Config.CHESS_SIZE.Height)
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

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
using CaroGame.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaroGame.CaroManagement
{
    public class WinnerManager
    {
        public int Turn
        {
            get; set;
        }
        private Dictionary<BoardPosition, int> caroBoard;
        public BoardPosition[] arrRow, arrColumn, arrMainDiagonal, arrSubDiagomal;
        public int[] check;

        public WinnerManager()
        {
            caroBoard = new Dictionary<BoardPosition, int>();
            arrRow = new BoardPosition[4];
            arrColumn = new BoardPosition[4];
            arrMainDiagonal = new BoardPosition[4];
            arrSubDiagomal = new BoardPosition[4];
            check = new int[4] { 0, 0, 0, 0 };
        }

        public void ResetDictionary(int oldRow, int oldColumn)
        {
            if (oldRow > SettingConfig.Rows)
            {
                for (int i = SettingConfig.Rows; i < oldRow; i++)
                {
                    for (int j = 0; j < oldColumn; j++)
                    {
                        BoardPosition position = new BoardPosition(i, j);
                        if (caroBoard.ContainsKey(position)) caroBoard.Remove(position);
                    }
                }
            }
            if (oldColumn > SettingConfig.Columns)
            {
                for (int i = 0; i < oldRow; i++)
                {
                    for (int j = SettingConfig.Columns; j < oldColumn; j++)
                    {
                        BoardPosition position = new BoardPosition(i, j);
                        if (caroBoard.ContainsKey(position)) caroBoard.Remove(position);
                    }
                }
            }
        }

        public bool CheckExtist(int row, int column)
        {
            return caroBoard.ContainsKey(new BoardPosition(row, column));
        }

        public void NewGameHanlde(int turn)
        {
            this.Turn = turn % 2;
            check[0] = check[1] = check[2] = check[3] = 0;
            caroBoard.Clear();
        }

        public void LoadSaveGame(int turn, string stringCaroBoard)
        {
            this.Turn = turn % 2;
            check[0] = check[1] = check[2] = check[3] = 0;
            caroBoard.Clear();
            int count = 0;
            for (int i = 0; i < SettingConfig.Rows; i++)
                for (int j = 0; j < SettingConfig.Columns; j++)
                {
                    if (stringCaroBoard[count] == '1') caroBoard.Add(new BoardPosition(i, j), 1);
                    else if (stringCaroBoard[count] == '2') caroBoard.Add(new BoardPosition(i, j), 2);
                    count++;
                }
        }

        public void DrawCaroBoard(int row, int column)
        {
            caroBoard.Add(new BoardPosition(row, column), Turn);
        }

        public void DrawCaroBoard(BoardPosition position)
        {
            caroBoard.Add(position, Turn);
        }

        public void DrawCaroBoard(BoardPosition position, int turn)
        {
            caroBoard.Add(position, turn);
        }

        public void UndoHandle(int row, int column)
        {
            caroBoard.Remove(new BoardPosition(row, column));
            Turn = 1 - Turn;
        }

        public void RedoHandle(int row, int column)
        {
            caroBoard.Add(new BoardPosition(row, column), Turn);
            Turn = 1 - Turn;
        }

        public bool IsEndGame()
        {
            return caroBoard.Count == SettingConfig.Rows * SettingConfig.Columns - 1;
        }

        public async Task<bool> IsWiner(int row, int column)
        {
            bool rowCheck = await IsWinRow(row, column);
            bool columnCheck = await IsWinColumn(row, column);
            bool mainDiagonalCheck = await IsWinMainDiagonal(row, column);
            bool subDiagonalCheck = await IsWinSubDiagonal(row, column);
            if (rowCheck) check[0] = 1;
            if (columnCheck) check[1] = 1;
            if (mainDiagonalCheck) check[2] = 1;
            if (subDiagonalCheck) check[3] = 1;
            return rowCheck || columnCheck || mainDiagonalCheck || subDiagonalCheck;
        }

#pragma warning disable CS1998
        private async Task<bool> IsWinRow(int row, int column)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = column - 1; i >= 0; i--)
            {
                BoardPosition temp = new BoardPosition(row, i);
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
            for (int i = column + 1; i <= SettingConfig.Columns - 1; i++)
            {
                BoardPosition temp = new BoardPosition(row, i);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
                    {
                        arrRow[count] = temp;
                        count++;
                        if (i == SettingConfig.Columns - 1) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            return (count == 4) && (countEnemy < 2);
        }

        private async Task<bool> IsWinColumn(int row, int column)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = row - 1; i >= 0; i--)
            {
                BoardPosition temp = new BoardPosition(i, column);
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
            for (int i = row + 1; i <= SettingConfig.Rows - 1; i++)
            {
                BoardPosition temp = new BoardPosition(i, column);
                if (caroBoard.TryGetValue(temp, out player))
                {
                    if (player == Turn)
                    {
                        arrColumn[count] = temp;
                        count++;
                        if (i == SettingConfig.Rows - 1) countEnemy++;
                    }
                    else { countEnemy++; break; }
                }
                else break;
            }
            return (count == 4) && (countEnemy < 2);
        }

        private async Task<bool> IsWinMainDiagonal(int row, int column)
        {
            int count = 0, countEnemy = 0, player = -1;
            for (int i = column - 1, j = row - 1; i >= 0 && j >= 0; i--, j--)
            {
                BoardPosition temp = new BoardPosition(j, i);
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
            int MAX_X = SettingConfig.Columns - 1;
            int MAX_Y = SettingConfig.Rows - 1;
            for (int i = column + 1, j = row + 1; i <= MAX_X && j < MAX_Y; i++, j++)
            {
                BoardPosition temp = new BoardPosition(j, i);
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

        private async Task<bool> IsWinSubDiagonal(int row, int column)
        {
            int count = 0, countEnemy = 0, player = -1;
            int MAX_X = SettingConfig.Columns - 1;
            for (int i = column + 1, j = row - 1; i <= MAX_X && j >= 0; i++, j--)
            {
                BoardPosition temp = new BoardPosition(j, i);
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
            int MAX_Y = SettingConfig.Rows - 1;
            for (int i = column - 1, j = row + 1; i >= 0 && j <= MAX_Y; i--, j++)
            {
                BoardPosition temp = new BoardPosition(j, i);
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

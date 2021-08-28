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

using System;
using CaroGame.Configuration;
using CaroGame.Controls;
using System.Drawing;
using System.Windows.Forms;
using static CaroGame.Configuration.Constants;
using static CaroGame.Program;
using System.Collections.Generic;
using CaroGame.Entities;

namespace CaroGame.Views.Components
{
    public class SizePanel : BaseCaroPanel
    {
        protected CaroButton backBut, nextBut, addBut, saveBut, removeBut, resetBut;
        protected NumericUpDown rowNud, columnNud;
        protected Label rowLbl, columnLbl;
        private ResizePanel resizePanel;
        private Panel containerPnl;
        private SizeAction action = SizeAction.Add;
        private int[,] board;
        private Dictionary<BoardPosition, Button> butList;

        public SizePanel(bool isAutoSize) : base(isAutoSize)
        {
            butList = new Dictionary<BoardPosition, Button>();
            board = new int[15, 30];
            this.Size = new Size(800, 340);
            DrawBasePanel();
        }

        private void DrawSizeButtonPanel()
        {
            containerPnl = new Panel
            {
                Location = new Point(5, 5),
                Size = new Size(630, 330)
            };
            resizePanel = new ResizePanel(false, true)
            {
                Location = new Point(5, 5),
                Size = new Size(620, 320),
                BorderStyle = BorderStyle.FixedSingle,
                MaximumSize = new Size(620, 320),
                MinimumSize = new Size(115, 115)
            };
            resizePanel.SizeChanged += ResizePanel_SizeChanged;
            containerPnl.Controls.Add(resizePanel);
            int X = 20, Y = 20;
            for (int i = 0; i < Constants.MAX_ROW; i++)
            {
                for (int j = 0; j < Constants.MAX_COLUMN; j++)
                {
                    Button but = new Button
                    {
                        Location = new Point(X, Y),
                        Size = new Size(20, 20),
                        Enabled = false
                    };
                    containerPnl.Controls.Add(but);
                    X += 20;
                }
                X = 20; Y += 20;
            }
            X = 14; Y = 14;
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    BoardButton but = new BoardButton
                    {
                        Location = new Point(X, Y),
                        Size = new Size(20, 20),
                        Rows = i,
                        Columns = j
                    };
                    but.Click += But_Click;
                    resizePanel.Controls.Add(but);
                    X += 20;
                    board[i, j] = 3;
                    butList.Add(new BoardPosition(i, j), but);
                }
                X = 14; Y += 20;
            }
            this.Controls.Add(containerPnl);
        }

        protected override void DrawBasePanel()
        {
            DrawSizeButtonPanel();
            rowLbl = new Label
            {
                Location = new Point(650, 25),
                Text = "Row",
                Size = new Size(50, 30)
            };
            columnLbl = new Label
            {
                Location = new Point(650, 65),
                Text = "Column",
                Size = new Size(50, 30)
            };
            rowNud = new NumericUpDown
            {
                Location = new Point(710, 25),
                Size = new Size(80, 30),
                Minimum = Constants.MIN_ROW,
                Maximum = Constants.MAX_ROW,
                Value = (resizePanel.Height - 15) / 20
            };
            columnNud = new NumericUpDown
            {
                Location = new Point(710, 65),
                Size = new Size(80, 30),
                Minimum = Constants.MIN_COLUMN,
                Maximum = Constants.MAX_COLUMN,
                Value = (resizePanel.Width - 15) / 20
            };
            addBut = new CaroButton
            {
                Location = new Point(650, 105),
                Text = CaroService.Language.GetString("add"),
                Size = new Size(70, 30),
                FlatStyle = FlatStyle.Flat
            };
            removeBut = new CaroButton
            {
                Location = new Point(720, 105),
                Text = CaroService.Language.GetString("remove"),
                Size = new Size(70, 30)
            };
            resetBut = new CaroButton
            {
                Location = new Point(650, 145),
                Text = CaroService.Language.GetString("reset"),
                Size = new Size(140, 30)
            };
            saveBut = new CaroButton()
            {
                Location = new Point(650, 185),
                Text = CaroService.Language.GetString("save"),
                Size = new Size(140, 30)
            };
            backBut = new CaroButton()
            {
                Location = new Point(650, 225),
                Text = CaroService.Language.GetString("back"),
                Size = new Size(70, 30)
            };
            nextBut = new CaroButton()
            {
                Location = new Point(720, 225),
                Text = CaroService.Language.GetString("next"),
                Size = new Size(70, 30)
            };
            rowNud.ValueChanged += RowNud_ValueChanged;
            columnNud.ValueChanged += ColumnNud_ValueChanged;
            addBut.Click += AddBut_Click;
            removeBut.Click += RemoveBut_Click;
            resetBut.Click += ResetBut_Click;
            saveBut.Click += SaveBut_Click;
            backBut.Click += BackBut_Click;
            nextBut.Click += NextBut_Click;
            this.Controls.Add(rowLbl);
            this.Controls.Add(columnLbl);
            this.Controls.Add(rowNud);
            this.Controls.Add(columnNud);
            this.Controls.Add(addBut);
            this.Controls.Add(removeBut);
            this.Controls.Add(resetBut);
            this.Controls.Add(saveBut);
            this.Controls.Add(backBut);
            this.Controls.Add(nextBut);
        }

        private void ResizePanel_SizeChanged(object sender, EventArgs e)
        {
            ResizePanel rePnl = sender as ResizePanel;
            if (rePnl != null)
            {
                rowNud.Value = (rePnl.Height - 15) / 20;
                columnNud.Value = (rePnl.Width - 15) / 20;
            }
        }

        private void ColumnNud_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown temp = sender as NumericUpDown;
            if (temp != null)
            {
                resizePanel.Width = 15 + 20 * (int)temp.Value;
            }
        }

        private void RowNud_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown temp = sender as NumericUpDown;
            if (temp != null)
            {
                resizePanel.Height = 15 + 20 * (int)temp.Value;
            }
        }

        private void RemoveBut_Click(object sender, EventArgs e)
        {
            if (action == SizeAction.Add)
            {
                removeBut.FlatStyle = FlatStyle.Flat;
                addBut.FlatStyle = FlatStyle.Standard;
                action = SizeAction.Remove;
            }
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            if (action == SizeAction.Remove)
            {
                addBut.FlatStyle = FlatStyle.Flat;
                removeBut.FlatStyle = FlatStyle.Standard;
                action = SizeAction.Add;
            }
        }

        private void ResetBut_Click(object sender, EventArgs e)
        {
            int rows = (int)rowNud.Value;
            int columns = (int)columnNud.Value;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    butList[new BoardPosition(i, j)].BackColor = Color.Transparent;
                    board[i, j] = 3;
                }
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {

        }

        private void NextBut_Click(object sender, EventArgs e)
        {
            int rows = (int)rowNud.Value;
            int columns = (int)columnNud.Value;
            SettingConfig.BoardPattern = "";
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    SettingConfig.BoardPattern += board[i, j];
            SettingConfig.Rows = rows;
            SettingConfig.Columns = columns;
            routes.Routing(Constants.PLAYER_SETTING);
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            routes.Routing(Constants.GAME_MODE);
        }

        private void But_Click(object sender, EventArgs e)
        {
            BoardButton but = sender as BoardButton;
            if (action == SizeAction.Remove)
            {
                if (but.BackColor != Color.Black)
                {
                    but.BackColor = Color.Black;
                    int row = but.Rows;
                    int column = but.Columns;
                    board[row, column] = 0;
                }
            }
            else
            {
                if (but.BackColor == Color.Black)
                {
                    but.BackColor = Color.Transparent;
                    int row = but.Rows;
                    int column = but.Columns;
                    board[row, column] = 3;
                }
            }
        }
    }
}

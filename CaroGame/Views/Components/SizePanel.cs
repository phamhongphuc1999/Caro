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
using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class SizePanel : Panel
    {
        protected CaroButton backBut, nextBut;

        public event EventHandler BackClickEvent
        {
            add
            {
                backBut.Click += value;
            }
            remove
            {
                backBut.Click -= value;
            }
        }

        public event EventHandler NextClickEvent
        {
            add
            {
                nextBut.Click += value;
            }
            remove
            {
                nextBut.Click -= value;
            }
        }

        public SizePanel()
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        public void DrawSizeButtonPanel()
        {
            int index = 0;
            int Y = 20;
            foreach ((int, int) size in Constants.CARO_SIZE)
            {
                int X = 29 + 129 * index;
                if (X > Constants.WIDTH_STANDARD)
                {
                    index = 0;
                    X = 29;
                    Y += 80;
                }
                CaroButton button = new CaroButton
                {
                    Size = new Size(100, 60),
                    Font = new Font("Time New Roman", 15),
                    Location = new Point(X, Y),
                    Text = string.Format("{0} x {1}", size.Item1, size.Item2)
                };
                button.Click += (sender, e) =>
                {
                    SettingConfig.Columns = size.Item1;
                    SettingConfig.Rows = size.Item2;
                };
                this.Controls.Add(button);
                index++;
            }
        }

        public void DrawBasePanel()
        {
            DrawSizeButtonPanel();
            backBut = new CaroButton()
            {
                Location = new Point(20, 300),
                Text = "Back",
                Size = new Size(70, 30)
            };
            nextBut = new CaroButton()
            {
                Location = new Point(455, 300),
                Text = "Next",
                Size = new Size(70, 30)
            };
            this.Controls.Add(backBut);
            this.Controls.Add(nextBut);
        }
    }
}

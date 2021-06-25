﻿using CaroGame.Configuration;
using CaroGame.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame.Views.Components
{
    public class OverviewPanel: Panel
    {
        protected CaroButton newGameBut, guideBut;

        public event EventHandler NewGameClickEvent
        {
            add
            {
                newGameBut.Click += value;
            }
            remove
            {
                newGameBut.Click -= value;
            }
        }

        public event EventHandler GuideClickEvent
        {
            add
            {
                guideBut.Click += value;
            }
            remove
            {
                guideBut.Click -= value;
            }
        }

        public OverviewPanel(): base()
        {
            this.Size = new Size(Constants.WIDTH_STANDARD, Constants.HEIGHT_STANDARD);
            DrawBasePanel();
        }

        public void DrawBasePanel()
        {
            newGameBut = new CaroButton()
            {
                Text = "New Game",
                Size = new Size(150, 65),
                Location = new Point(100, 155)
            };
            guideBut = new CaroButton()
            {
                Text = "Guide",
                Size = new Size(150, 65),
                Location = new Point(350, 155)
            };
            this.Controls.Add(newGameBut);
            this.Controls.Add(guideBut);
        }
    }
}

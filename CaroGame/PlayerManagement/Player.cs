﻿// --------------------CARO  GAME-----------------
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

using System.Drawing;

namespace CaroGame.PlayerManagement
{
    internal class Player
    {
        public string NamePlayer
        {
            get; set;
        }
        public bool IsTurn
        {
            get; set;
        }
        public Color ColorPlayer
        {
            get; set;
        }

        public Player(string namePlayer, Color colorPlayer, bool isTurn)
        {
            this.NamePlayer = namePlayer;
            this.ColorPlayer = colorPlayer;
            this.IsTurn = isTurn;
        }

        public Player()
        {
            this.NamePlayer = "player";
            this.ColorPlayer = Color.Green;
            this.IsTurn = true;
        }
    }
}

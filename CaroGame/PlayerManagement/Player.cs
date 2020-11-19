// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using System.Drawing;

namespace CaroGame.PlayerManagement
{
    public class Player
    {
        public string NamePlayer { get; set; }
        public int IsTurn { get; set; }
        public Color ColorPlayer { get; set; }

        public Player(string namePlayer, Color colorPlayer, int isTurn)
        {
            this.NamePlayer = namePlayer;
            this.ColorPlayer = colorPlayer;
            this.IsTurn = isTurn;
        }
    }
}

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
using System.Drawing;

namespace CaroGame.PlayerManagement
{
    public class PlayerManager
    {
        private Player player1;
        private Player player2;

        public PlayerManager()
        {
            player1 = new Player(Constants.PLAYER1_DEFAULT_NAME, Color.Green, true);
            player2 = new Player(Constants.PLAYER2_DEFAULT_NAME, Color.Red, false);
        }

        public PlayerManager(string playerName1, string playerName2)
        {
            player1 = new Player(playerName1, Color.Green, true);
            player2 = new Player(playerName2, Color.Red, false);
        }

        public int Turn
        {
            get
            {
                return player1.IsTurn ? Constants.PLAYER1_TURN : Constants.PLAYER2_TURN;
            }
            set
            {
                if (value % 2 == 0)
                {
                    player1.IsTurn = true;
                    player2.IsTurn = false;
                }
                else if (value % 2 == 1)
                {
                    player1.IsTurn = false;
                    player2.IsTurn = true;
                }
            }
        }

        public string PlayerName1
        {
            get
            {
                return player1.NamePlayer;
            }
        }

        public string PlayerName2
        {
            get
            {
                return player2.NamePlayer;
            }
        }

        public Color PlayerColor1
        {
            get
            {
                return player1.ColorPlayer;
            }
        }

        public Color PlayerColor2
        {
            get
            {
                return player2.ColorPlayer;
            }
        }

        public string CurrentPlayerName
        {
            get
            {
                if (player1.IsTurn) return player1.NamePlayer;
                return player2.NamePlayer;
            }
        }

        public Color CurrentPlayerColor
        {
            get
            {
                if (player1.IsTurn) return player1.ColorPlayer;
                return player2.ColorPlayer;
            }
        }

        public string OtherPlayerName
        {
            get
            {
                if (player1.IsTurn) return player2.NamePlayer;
                return player1.NamePlayer;
            }
        }

        public Color OtherPlayerColor
        {
            get
            {
                if (player1.IsTurn) return player2.ColorPlayer;
                return player1.ColorPlayer;
            }
        }

        public void SetPlayerName(string playerName, string player)
        {
            if (player.Equals(Constants.PLAYER1)) player1.NamePlayer = playerName;
            else player2.NamePlayer = playerName;
        }
    }
}

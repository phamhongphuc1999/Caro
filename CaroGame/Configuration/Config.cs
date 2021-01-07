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

using System.Drawing;

namespace CaroGame.Configuration
{
    public static class Config
    {
        public static int NUMBER_OF_ROW = 10;
        public static int NUMBER_OF_COLUMN = 10;
        public static readonly Size CHESS_SIZE = new Size(40, 40);

        public static string NAME_PLAYER1 = "";
        public static string NAME_PLAYER2 = "";

        public static bool IS_PLAY_MUSIC = false;
        public static int VOLUME_SIZE = 20;

        public static bool IS_TIMER = false;
        public static int TIME_TURN = 30;
        public static int INTERVAL = 1;

        public enum GameMode
        {
            TWO_PLAYER,
            AI, LAN
        }

        public static GameMode CURRENT_GAME_MODE;

        public static class NAME
        {
            public const string OVERVIEW = "Overview";
            public const string GAME_MODE_SETTING = "Game Mode Setting";
            public const string GAME_MODE = "Game Mode";
            public const string PLAYER_SETTING = "Payler Setting";
            public const string PLAYER = "Player";
            public const string LAN_CONNECTION = "Lan Connection";
            public const string CARO = "Caro";
            public const string SETTING = "Setting";
            public const string TIME_SETTING = "Time Setting";
            public const string SIZE_SETTING = "Size Setting";
            public const string SOUND_SETTING = "Sound Setting";
            public const string LOAD_GAME = "Load Game";
            public const string ABOUT = "About";
        }
    }
}

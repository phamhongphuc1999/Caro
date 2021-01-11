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
        public static int NUMBER_OF_ROW;
        public static int NUMBER_OF_COLUMN;
        public static readonly Size CHESS_SIZE = new Size(40, 40);

        public static string NAME_PLAYER1 = "";
        public static string NAME_PLAYER2 = "";

        public static bool IS_PLAY_MUSIC;
        public static int VOLUME_SIZE;

        public static bool IS_TIMER;
        public static int TIME_TURN;
        public static int INTERVAL;

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

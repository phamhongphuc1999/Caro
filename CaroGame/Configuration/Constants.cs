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

namespace CaroGame.Configuration
{
    public static class Constants
    {
        public readonly static int WIDTH_STANDARD = 545;
        public readonly static int HEIGHT_STANDARD = 340;

        public readonly static string TWO_PLAYER_GAME_MODE = "two_palyer";
        public readonly static string LAN_GAME_MODE = "lan_game_mode";
        public readonly static string AI_GAME_MODE = "ai_game_mode";

        public readonly static string PLAYER1_DEFAULT_NAME = "player1";
        public readonly static string PLAYER2_DEFAULT_NAME = "player2";
        public readonly static string PLAYER1 = "player1";
        public readonly static string PLAYER2 = "player2";
        public readonly static string SINGLE_PLAYER = "player";
        public readonly static int PLAYER1_TURN = 0;
        public readonly static int PLAYER2_TURN = 1;

        public readonly static int CHESS_WIDTH = 30;
        public readonly static int CHESS_HEIGHT = 30;

        public readonly static (int, int)[] CARO_SIZE = new (int, int)[] { (5, 5), (10, 5), (10, 10), (15, 10), (15, 15), (20, 15), (20, 20), (25, 20), (25, 25) };

        public readonly static string OVERVIEW = "Overview";
        public readonly static string GAME_MODE = "Game Mode";
        public readonly static string SIZE_SETTING = "Size Setting";
        public readonly static string PLAYER_SETTING = "Player Setting";
        public readonly static string MAIN = "Caro";

        public readonly static string MAIN_SETTING = "Setting";
        public readonly static string LANGUAGE_SETTING = "Language Setting";
        public readonly static string SOUND_SETTING = "Sound Setting";
        public readonly static string TIME_SETTING = "Time Setting";

        public readonly static string ABOUT = "about";
        public readonly static string ABOUT_DETAIL = "\n" +
                "          Devepoler: Phạm Hồng Phúc\n" +
                "          Country: Việt Nam\n" +
                "          Game: Caro Game\n" +
                "          Version: v2.0";
    }
}

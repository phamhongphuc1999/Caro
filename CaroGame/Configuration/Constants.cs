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

        public readonly static int MIN_ROW = 10;
        public readonly static int MAX_ROW = 15;
        public readonly static int MIN_COLUMN = 10;
        public readonly static int MAX_COLUMN = 30;

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

        public readonly static string VI_LANGUAGE = "vi";
        public readonly static string EN_LANGUAGE = "en";

        public readonly static string OVERVIEW = "overview";
        public readonly static string GAME_MODE = "gameMode";
        public readonly static string SIZE_SETTING = "sizeSetting";
        public readonly static string PLAYER_SETTING = "playerSetting";
        public readonly static string MAIN = "caro";
        public readonly static string LOAD_GAME = "loadGame";

        public readonly static string MAIN_SETTING = "setting";
        public readonly static string LANGUAGE_SETTING = "languageSetting";
        public readonly static string SOUND_SETTING = "soundSetting";
        public readonly static string TIME_SETTING = "timeSetting";
        public readonly static string APPEARANCE_SETTING = "appearanceSetting";

        public readonly static char VOID_POSITION = '0';
        public readonly static char PLAYER1_POSITION = '1';
        public readonly static char PLAYER2_POSITION = '2';
        public readonly static char EMPTY_POSITION = '3';

        public readonly static string ABOUT = "about";
        public readonly static string GITHUB_LINK = "https://github.com/phamhongphuc1999/Caro";

        public enum EdgeEnum
        {
            None, Right,
            Left, Top,
            Bottom, TopLeft
        }

        public enum SizeAction
        {
            Remove, Add
        }
    }
}

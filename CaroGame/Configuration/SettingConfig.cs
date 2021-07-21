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

using CaroGame.Entities;

namespace CaroGame.Configuration
{
    public static class SettingConfig
    {
        public static int Columns = 0;
        public static int Rows = 0;
        public static string BoardPattern = "";
        public static string GameMode = "";
        public static bool IsTime = false;
        public static bool IsPlayMusic = false;
        public static int VolumnSize = 0;
        public static int TimeTurn = 30;
        public static int Interval = 1000;
        public static string Language = "";

        public static bool IsSaveGame = false;

        public static bool AppearanceOption = false;
        public static bool LanguageOption = false;
        public static bool PlayerOption = false;
        public static bool SizeOption = false;
        public static bool SoundOption = false;
        public static bool TimeOption = false;

        public static void InitializeGameSaveSetting(GameSaveData data)
        {
            Rows = data.Row;
            Columns = data.Column;
            GameMode = data.GameMode;
            BoardPattern = data.CaroBoard;
        }

        public static void NewGame()
        {
            IsSaveGame = false;
        }

        public static void ResetSettingOption()
        {
            AppearanceOption = false;
            LanguageOption = false;
            PlayerOption = false;
            SizeOption = false;
            SoundOption = false;
            TimeOption = false;
        }
    }
}

// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using CaroGame.Entities;

namespace CaroGame.Configuration
{
    public static class Config
    {
        public static int NUMBER_OF_ROW;
        public static int NUMBER_OF_COLUMN;
        public static Size CHESS_SIZE = new Size(40, 40);
        public static bool IS_PLAY_MUSIC;
        public static int VOLUME_SIZE;
        public static string NAME_PLAYER1 = "";
        public static string NAME_PLAYER2 = "";
        public static TimeConfigEntity TIME_CONFIG;
        public static LanConfigEntity LAN_CONFIG;

        //const load and save game
        public static bool IS_LOAD_GAME = false;
        public static bool IS_OLD_GAME = false;
        public static int INDEX_OLD_GAME = -1;

        private static ConfigEntity jsonConst;
        public static Stack<string> caroFlow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public static void InitializePlayereName(string player1, string player2)
        {
            NAME_PLAYER1 = player1;
            NAME_PLAYER2 = player2;
        }

        /// <summary>
        /// Initialized configuration when the program begin
        /// </summary>
        public static void InitializeConfiguration()
        {
            jsonConst = new ConfigEntity();
            caroFlow = new Stack<string>();
            LAN_CONFIG = new LanConfigEntity
            {
                IP = "127.0.0.1",
                Port = 9999,
                BuffSize = 10240,
                IsServer = true,
                IsLock = true,
                IsTurn = true
            };
            using (StreamReader sr = File.OpenText("../../../Configuration/Config.json"))
            {
                string data = sr.ReadToEnd();
                jsonConst = JsonConvert.DeserializeObject<ConfigEntity>(data);
                NUMBER_OF_ROW = jsonConst.numberOfRow;
                NUMBER_OF_COLUMN = jsonConst.numberOfColumn;
                IS_PLAY_MUSIC = jsonConst.isPlayMusic;
                VOLUME_SIZE = jsonConst.volumeSize;
                TIME_CONFIG = new TimeConfigEntity
                {
                    IsTime = jsonConst.isOnTime,
                    TimeTurn = jsonConst.timeTurn,
                    Interval = jsonConst.interval
                };
            }
        }

        /// <summary>
        /// Save configuration in file
        /// </summary>
        public static void SaveConfiguration()
        {
            if (!(GAME_MODE.CurrentGameMode == GAME_MODE.LAN && !Config.LAN_CONFIG.IsServer))
            {
                jsonConst.numberOfColumn = NUMBER_OF_COLUMN;
                jsonConst.numberOfRow = NUMBER_OF_ROW;
            }
            jsonConst.isOnTime = TIME_CONFIG.IsTime;
            jsonConst.isPlayMusic = IS_PLAY_MUSIC;
            jsonConst.timeTurn = TIME_CONFIG.TimeTurn;
            jsonConst.interval = TIME_CONFIG.Interval;
            jsonConst.volumeSize = VOLUME_SIZE;
            StreamWriter sw = new StreamWriter("../../../Configuration/Config.json");
            string data = JsonConvert.SerializeObject(jsonConst);
            sw.WriteLine(data);
            sw.Close();
        }

        public static class NAME
        {
            public const string OVERVIEW = "Overview";
            public const string GAME_MODE_SETTING = "Game Mode Setting";
            public const string GAME_MODE = "Game Mode";
            public const string PLAYER_SETTING = "Player_SETTING";
            public const string PLAYER = "Player";
            public const string LAN_CONNECTION = "LAN Connection";
            public const string CARO = "Caro";
            public const string SETTING = "Setting";
            public const string TIME_SETTING = "Time Setting";
            public const string SIZE_SETTING = "Size Setting";
            public const string SOUND_SETTING = "Sound Setting";
            public const string LOAD_GAME = "Load Game";
            public const string ABOUT = "About";
        }

        public static class GAME_MODE
        {
            public const string TWO_PLAYER = "TWO PLAYER";
            public const string ONE_PLAYER = "ONE PLAYER";
            public const string LAN = "LAN";

            public static string CurrentGameMode { get; set; }
        }
    }
}

﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace Caro.Setting
{
    public static class CONST
    {
        public static string GAME_MODE = "TWO_PLAYER";
        public static int NUMBER_OF_ROW;
        public static int NUMBER_OF_COLUMN;
        public static int WIDTH = 25;
        public static int HEIGHT = 25;
        public static bool IS_ON_TIMER;
        public static bool IS_PLAY_MUSIC;
        public static int VOLUME_SIZE;
        public static int TIME_TURN;
        public static int INTERVAL;
        public static string NAME_PLAYER1 = "";
        public static string NAME_PLAYER2 = "";

        public static string IP = "127.0.0.1";
        public static int PORT = 9999;
        public static int BUFF_SIZE = 10240;
        public static bool IS_SERVER = true;
        public static bool IS_TURN = true;
        public static bool IS_LOCK = true;

        private static JsonConst jsonConst = new JsonConst();
        public static void ReadCONST()
        {
            using (StreamReader sr = File.OpenText("./CONST.json"))
            {
                string data = sr.ReadToEnd();
                jsonConst = JsonConvert.DeserializeObject<JsonConst>(data);
                NUMBER_OF_ROW = jsonConst.numberOfRow;
                NUMBER_OF_COLUMN = jsonConst.numberOfColumn;
                IS_ON_TIMER = jsonConst.isOnTime;
                IS_PLAY_MUSIC = jsonConst.isPlayMusic;
                TIME_TURN = jsonConst.timeTurn;
                INTERVAL = jsonConst.interval;
                VOLUME_SIZE = jsonConst.volumeSize;
            }
        }

        public static void WriteCONST()
        {
            if(!(CONST.GAME_MODE == "LAN" && !CONST.IS_SERVER))
            {
                jsonConst.numberOfColumn = NUMBER_OF_COLUMN;
                jsonConst.numberOfRow = NUMBER_OF_ROW;
            }
            jsonConst.isOnTime = IS_ON_TIMER;
            jsonConst.isPlayMusic = IS_PLAY_MUSIC;
            jsonConst.timeTurn = TIME_TURN;
            jsonConst.interval = INTERVAL;
            jsonConst.volumeSize = VOLUME_SIZE;
            StreamWriter sw = new StreamWriter("./CONST.json");
            string data = JsonConvert.SerializeObject(jsonConst);
            sw.WriteLine(data);
            sw.Close();
        }
    }
}

using CaroGame.SaveGameManagement;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CaroGame.Configuration
{
    public static class Config
    {
        public static int NUMBER_OF_ROW;
        public static int NUMBER_OF_COLUMN;
        public static Size CHESS_SIZE = new Size(40, 40);
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
        //const load and save game
        public static bool IS_LOAD_GAME = false;
        public static bool IS_OLD_GAME = false;
        public static int INDEX_OLD_GAME = -1;

        private static EntityConfig jsonConst = new EntityConfig();
        public static GameSaveData saveData = new GameSaveData();
        public static Stack<string> caroFlow = new Stack<string>();

        public static void ReadCONST()
        {
            using (StreamReader sr = File.OpenText("./CONST.json"))
            {
                string data = sr.ReadToEnd();
                jsonConst = JsonConvert.DeserializeObject<EntityConfig>(data);
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
            if (!(GAME_MODE.CurrentGameMode == GAME_MODE.LAN && !Config.IS_SERVER))
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

        public static void LoadGame()
        {
            using (StreamReader sr = File.OpenText("./SaveGame.json"))
            {
                string data = sr.ReadToEnd();
                if (data.Length > 0) saveData = JsonConvert.DeserializeObject<GameSaveData>(data);
            }
        }

        public static void WriteSaveGame()
        {
            StreamWriter sw = new StreamWriter("./SaveGame.json");
            string data = JsonConvert.SerializeObject(saveData);
            sw.WriteLine(data);
            sw.Close();
        }

        public static class NAME
        {
            public const string GAME_MODE_SETTING = "Game Mode Setting";
            public const string GAME_MODE = "Game Mode";
            public const string PLAYER_SETTING = "Player_SETTING";
            public const string PLAYER = "Player";
            public const string LAN_CONNECTION = "LAN COnnection";
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

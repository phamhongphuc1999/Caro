using Caro.SaveGame;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace Caro.Config
{
    public static class CONST
    {
        public static string GAME_MODE = "TWO_PLAYER";
        public static int NUMBER_OF_ROW;
        public static int NUMBER_OF_COLUMN;
        public static Size CHESS_SIZE = new Size(25, 25);
        public static bool IS_ON_TIMER;
        public static bool IS_PLAY_MUSIC;
        public static int VOLUME_SIZE;
        public static int TIME_TURN;
        public static int INTERVAL;
        public static string NAME_PLAYER1 = "";
        public static string NAME_PLAYER2 = "";
        public static string COLOR_PLAYER1 = "";
        public static string COLOR_PLAYER2 = "";

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

        private static JsonConst jsonConst = new JsonConst();
        public static GameSaveData saveData = new GameSaveData();

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

        public static void LoadGame()
        {
            using (StreamReader sr = File.OpenText("./SaveGame.json"))
            {
                string data = sr.ReadToEnd();
                saveData = JsonConvert.DeserializeObject<GameSaveData>(data);
            }
        }

        public static void WriteSaveGame()
        {
            StreamWriter sw = new StreamWriter("./SaveGame.json");
            string data = JsonConvert.SerializeObject(saveData);
            sw.WriteLine(data);
            sw.Close();
        }
    }
}

using CaroGame.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace CaroGame.SaveGameManagement
{
    public class SaveGameHelper
    {
        public static string caroBoard = "";
        public static int turn = -1;
        public static int index = -1;

        public static void LoadGame()
        {
            using (StreamReader sr = File.OpenText("../../../Resources/SaveGame.json"))
            {
                string data = sr.ReadToEnd();
                if (data.Length > 0) Config.saveData = JsonConvert.DeserializeObject<GameSaveModel>(data);
            }
        }

        public static void SaveGameToFile()
        {
            StreamWriter sw = new StreamWriter("../../../Resources/SaveGame.json");
            string data = JsonConvert.SerializeObject(Config.saveData);
            sw.WriteLine(data);
            sw.Close();
        }

        public static void SaveCurrentGame()
        {
            if (Config.IS_LOAD_GAME)
            {
                Config.saveData.GameSaveList[index].NumberOfColumn = Config.NUMBER_OF_COLUMN;
                Config.saveData.GameSaveList[index].NumberOfRow = Config.NUMBER_OF_ROW;
                Config.saveData.GameSaveList[index].PlayerName1 = Config.NAME_PLAYER1;
                Config.saveData.GameSaveList[index].PlayerName2 = Config.NAME_PLAYER2;
                Config.saveData.GameSaveList[index].CaroBoard = caroBoard;
                Config.saveData.GameSaveList[index].GameMode = Config.GAME_MODE.CurrentGameMode;
                Config.saveData.GameSaveList[index].Turn = turn;
            }
            else if (Config.IS_OLD_GAME)
            {
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].NumberOfColumn = Config.NUMBER_OF_COLUMN;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].NumberOfRow = Config.NUMBER_OF_ROW;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].PlayerName1 = Config.NAME_PLAYER1;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].PlayerName2 = Config.NAME_PLAYER2;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].CaroBoard = caroBoard;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].GameMode = Config.GAME_MODE.CurrentGameMode;
                Config.saveData.GameSaveList[Config.INDEX_OLD_GAME].Turn = turn;
            }
            else
            {
                GameSaveData gameSave = new GameSaveData()
                {
                    NumberOfColumn = Config.NUMBER_OF_COLUMN,
                    NumberOfRow = Config.NUMBER_OF_ROW,
                    PlayerName1 = Config.NAME_PLAYER1,
                    PlayerName2 = Config.NAME_PLAYER2,
                    CaroBoard = caroBoard,
                    GameMode = Config.GAME_MODE.CurrentGameMode,
                    Turn = turn
                };
                Config.saveData.GameSaveList.Add(gameSave);
                Config.IS_OLD_GAME = true;
                Config.INDEX_OLD_GAME = Config.saveData.GameSaveList.Count - 1;
            }
        }

        public static void DrawSaveGame(GameSaveData gameSave)
        {
            Config.NAME_PLAYER1 = gameSave.PlayerName1;
            Config.NAME_PLAYER2 = gameSave.PlayerName2;
            Config.NUMBER_OF_COLUMN = gameSave.NumberOfColumn;
            Config.NUMBER_OF_ROW = gameSave.NumberOfRow;
            Config.GAME_MODE.CurrentGameMode = gameSave.GameMode;
        }
    }
}

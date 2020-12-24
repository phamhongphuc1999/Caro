// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
using Newtonsoft.Json;
using System.IO;
using CaroGame.Entities;

namespace CaroGame.SaveGameManagement
{
    public class SaveGameHelper
    {
        public static string caroBoard = "";
        public static int turn = -1;
        public static int index = -1;

        public static GameSaveModel saveData = new GameSaveModel();

        /// <summary>
        /// Load save game from file json
        /// </summary>
        public static void LoadGame()
        {
            using (StreamReader sr = File.OpenText("../../../SaveGameManagement/SaveGame.json"))
            {
                string data = sr.ReadToEnd();
                if (data.Length > 0) saveData = JsonConvert.DeserializeObject<GameSaveModel>(data);
            }
        }

        /// <summary>
        /// Save current game to file json
        /// </summary>
        public static void SaveGameToFile()
        {
            StreamWriter sw = new StreamWriter("../../../SaveGameManagement/SaveGame.json");
            string data = JsonConvert.SerializeObject(saveData);
            sw.WriteLine(data);
            sw.Close();
        }

        /// <summary>
        /// Update data of current game to temporary list game
        /// </summary>
        public static void SaveCurrentGame()
        {
            if (Config.IS_LOAD_GAME)
            {
                saveData.GameSaveList[index].NumberOfColumn = Config.NUMBER_OF_COLUMN;
                saveData.GameSaveList[index].NumberOfRow = Config.NUMBER_OF_ROW;
                saveData.GameSaveList[index].PlayerName1 = Config.NAME_PLAYER1;
                saveData.GameSaveList[index].PlayerName2 = Config.NAME_PLAYER2;
                saveData.GameSaveList[index].CaroBoard = caroBoard;
                saveData.GameSaveList[index].GameMode = Config.GAME_MODE.CurrentGameMode;
                saveData.GameSaveList[index].Turn = turn;
            }
            else if (Config.IS_OLD_GAME)
            {
                saveData.GameSaveList[Config.INDEX_OLD_GAME].NumberOfColumn = Config.NUMBER_OF_COLUMN;
                saveData.GameSaveList[Config.INDEX_OLD_GAME].NumberOfRow = Config.NUMBER_OF_ROW;
                saveData.GameSaveList[Config.INDEX_OLD_GAME].PlayerName1 = Config.NAME_PLAYER1;
                saveData.GameSaveList[Config.INDEX_OLD_GAME].PlayerName2 = Config.NAME_PLAYER2;
                saveData.GameSaveList[Config.INDEX_OLD_GAME].CaroBoard = caroBoard;
                saveData.GameSaveList[Config.INDEX_OLD_GAME].GameMode = Config.GAME_MODE.CurrentGameMode;
                saveData.GameSaveList[Config.INDEX_OLD_GAME].Turn = turn;
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
                saveData.GameSaveList.Add(gameSave);
                Config.IS_OLD_GAME = true;
                Config.INDEX_OLD_GAME = saveData.GameSaveList.Count - 1;
            }
        }

        /// <summary>
        /// Initialized save game config
        /// </summary>
        /// <param name="gameSave"></param>
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

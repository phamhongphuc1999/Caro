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

using CaroGame.Configuration;
using CaroGame.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CaroGame.StorageManagement
{
    public class StorageManager
    {
        private GameSaveModel gameSaveModel;

        private int current_index;

        public StorageManager()
        {
            gameSaveModel = new GameSaveModel();
            current_index = -1;
            InitializeConfiguration();
            LoadGame();
        }

        public int Count
        {
            get
            {
                return gameSaveModel.GameSaveList.Count;
            }
        }

        public List<GameSaveData> GameSaveList
        {
            get
            {
                return gameSaveModel.GameSaveList;
            }
        }

        private void InitializeConfiguration()
        {
            using (StreamReader sr = File.OpenText("../../../StorageManagement/Config.json"))
            {
                string data = sr.ReadToEnd();
                ConfigEntity configEntity = JsonConvert.DeserializeObject<ConfigEntity>(data);
                Config.NUMBER_OF_COLUMN = configEntity.column;
                Config.NUMBER_OF_ROW = configEntity.row;
                Config.IS_TIMER = configEntity.isOnTime;
                Config.IS_PLAY_MUSIC = configEntity.isPlayMusic;
                Config.VOLUME_SIZE = configEntity.volumeSize;
                Config.TIME_TURN = configEntity.timeTurn;
                Config.INTERVAL = configEntity.interval;
            }
        }

        public void SaveConfiguration()
        {
            ConfigEntity configEntity = new ConfigEntity
            {
                column = Config.NUMBER_OF_COLUMN,
                row = Config.NUMBER_OF_ROW,
                isOnTime = Config.IS_TIMER,
                isPlayMusic = Config.IS_PLAY_MUSIC,
                volumeSize = Config.VOLUME_SIZE,
                timeTurn = Config.TIME_TURN,
                interval = Config.INTERVAL
            };
            StreamWriter sw = new StreamWriter("../../../StorageManagement/Config.json");
            string data = JsonConvert.SerializeObject(configEntity);
            sw.WriteLine(data);
            sw.Close();
        }

        private void LoadGame()
        {
            using (StreamReader sr = File.OpenText("../../../StorageManagement/SaveGame.json"))
            {
                string data = sr.ReadToEnd();
                if (data.Length > 0) gameSaveModel = JsonConvert.DeserializeObject<GameSaveModel>(data);
            }
        }

        public void SaveCurrentGame(string caroBoard, int turn)
        {
            if (current_index >= 0)
            {
                gameSaveModel.GameSaveList[current_index].Row = Config.NUMBER_OF_ROW;
                gameSaveModel.GameSaveList[current_index].Column = Config.NUMBER_OF_COLUMN;
                gameSaveModel.GameSaveList[current_index].PlayerName1 = Config.NAME_PLAYER1;
                gameSaveModel.GameSaveList[current_index].PlayerName2 = Config.NAME_PLAYER2;
                gameSaveModel.GameSaveList[current_index].CaroBoard = caroBoard;
                gameSaveModel.GameSaveList[current_index].Turn = turn;
                gameSaveModel.GameSaveList[current_index].GameMode = Config.CURRENT_GAME_MODE.ToString();
            }
            else
            {
                GameSaveData gameSave = new GameSaveData()
                {
                    Column = Config.NUMBER_OF_COLUMN,
                    Row = Config.NUMBER_OF_ROW,
                    PlayerName1 = Config.NAME_PLAYER1,
                    PlayerName2 = Config.NAME_PLAYER2,
                    CaroBoard = caroBoard,
                    GameMode = Config.CURRENT_GAME_MODE.ToString(),
                    Turn = turn
                };
                gameSaveModel.GameSaveList.Add(gameSave);
                current_index = gameSaveModel.GameSaveList.Count - 1;
            }
        }

        public void SaveGameToFile()
        {
            StreamWriter sw = new StreamWriter("../../../StorageManagement/SaveGame.json");
            string data = JsonConvert.SerializeObject(gameSaveModel);
            sw.WriteLine(data);
            sw.Close();
        }
    }
}

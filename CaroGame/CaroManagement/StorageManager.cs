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
using static CaroGame.Program;

namespace CaroGame.CaroManagement
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

        public int CurrentIndex
        {
            get
            {
                return current_index;
            }
            set
            {
                current_index = value;
            }
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
            using (StreamReader sr = File.OpenText("../../Resources/settings.json"))
            {
                string data = sr.ReadToEnd();
                SettingEntity configEntity = JsonConvert.DeserializeObject<SettingEntity>(data);
                SettingConfig.Columns = configEntity.column;
                SettingConfig.Rows = configEntity.row;
                SettingConfig.IsTime = configEntity.isOnTime;
                SettingConfig.IsPlayMusic = configEntity.isPlayMusic;
                SettingConfig.VolumnSize = configEntity.volumeSize;
                SettingConfig.TimeTurn = configEntity.timeTurn;
                SettingConfig.Interval = configEntity.interval;
            }
        }

        public void SaveConfiguration()
        {
            SettingEntity configEntity = new SettingEntity
            {
                column = SettingConfig.Columns,
                row = SettingConfig.Rows,
                isOnTime = SettingConfig.IsTime,
                isPlayMusic = SettingConfig.IsPlayMusic,
                volumeSize = SettingConfig.VolumnSize,
                timeTurn = SettingConfig.TimeTurn,
                interval = SettingConfig.Interval
            };
            StreamWriter sw = new StreamWriter("../../Resources/settings.json");
            string data = JsonConvert.SerializeObject(configEntity);
            sw.WriteLine(data);
            sw.Close();
        }

        private void LoadGame()
        {
            using (StreamReader sr = File.OpenText("../../resources/game-save.json"))
            {
                string data = sr.ReadToEnd();
                if (data.Length > 0) gameSaveModel = JsonConvert.DeserializeObject<GameSaveModel>(data);
            }
        }

        public void SaveCurrentGame(string caroBoard, int turn)
        {
            if (current_index >= 0)
            {
                gameSaveModel.GameSaveList[current_index].Row = SettingConfig.Rows;
                gameSaveModel.GameSaveList[current_index].Column = SettingConfig.Columns;
                gameSaveModel.GameSaveList[current_index].PlayerName1 = playerManager.PlayerName1;
                gameSaveModel.GameSaveList[current_index].PlayerName2 = playerManager.PlayerName2;
                gameSaveModel.GameSaveList[current_index].CaroBoard = caroBoard;
                gameSaveModel.GameSaveList[current_index].Turn = turn;
                gameSaveModel.GameSaveList[current_index].GameMode = SettingConfig.GameMode;
            }
            else
            {
                GameSaveData gameSave = new GameSaveData()
                {
                    Column = SettingConfig.Columns,
                    Row = SettingConfig.Rows,
                    PlayerName1 = playerManager.PlayerName1,
                    PlayerName2 = playerManager.PlayerName2,
                    CaroBoard = caroBoard,
                    GameMode = SettingConfig.GameMode,
                    Turn = turn
                };
                gameSaveModel.GameSaveList.Add(gameSave);
                current_index = gameSaveModel.GameSaveList.Count - 1;
            }
        }

        public void SaveGameToFile()
        {
            StreamWriter sw = new StreamWriter("../../Resources/game-save.json");
            string data = JsonConvert.SerializeObject(gameSaveModel);
            sw.WriteLine(data);
            sw.Close();
        }
    }
}

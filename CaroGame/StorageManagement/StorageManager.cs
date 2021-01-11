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
using System.IO;

namespace CaroGame.StorageManagement
{
    public class StorageManager
    {
        public void InitializeConfiguration()
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
    }
}

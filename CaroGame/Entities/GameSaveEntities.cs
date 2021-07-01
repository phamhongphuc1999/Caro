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

using System.Collections.Generic;

namespace CaroGame.Entities
{
    public class GameSaveData
    {
        public int Row
        {
            get; set;
        }
        public int Column
        {
            get; set;
        }
        public string PlayerName1
        {
            get; set;
        }
        public string PlayerName2
        {
            get; set;
        }
        public string GameMode
        {
            get; set;
        }
        public int Turn
        {
            get; set;
        }
        public string CaroBoard
        {
            get; set;
        }
    }

    public class GameSaveModel
    {
        public List<GameSaveData> GameSaveList
        {
            get; set;
        }

        public GameSaveModel()
        {
            GameSaveList = new List<GameSaveData>();
        }
    }
}

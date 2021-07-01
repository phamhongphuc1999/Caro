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

namespace CaroGame.Entities
{
    public class SettingEntity
    {
        public int row
        {
            get; set;
        }
        public int column
        {
            get; set;
        }
        public bool isOnTime
        {
            get; set;
        }
        public bool isPlayMusic
        {
            get; set;
        }
        public int timeTurn
        {
            get; set;
        }
        public int interval
        {
            get; set;
        }
        public int volumeSize
        {
            get; set;
        }
    }
}

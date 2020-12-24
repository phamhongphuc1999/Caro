// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

namespace CaroGame.Entities
{
    class ConfigEntity
    {
        public int numberOfRow { get; set; }
        public int numberOfColumn { get; set; }
        public bool isOnTime { get; set; }
        public bool isPlayMusic { get; set; }
        public int timeTurn { get; set; }
        public int interval { get; set; }
        public int volumeSize { get; set; }
    }
}

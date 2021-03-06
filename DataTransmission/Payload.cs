﻿// --------------------CARO  GAME-----------------
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

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataTransmission
{
    [Serializable]
    public struct MessageData
    {
        public int odcode;
        public int X;
        public int Y;
        public string data;

        public MessageData(int odcode, int X, int Y, string data)
        {
            this.odcode = odcode;
            this.X = X;
            this.Y = Y;
            this.data = data;
        }
    };

    public class Payload
    {
        public static byte[] SerializeData(object data)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, data);
            return ms.ToArray();
        }

        public static object DeserializeData(byte[] byteData)
        {
            MemoryStream ms = new MemoryStream(byteData);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }

        public static void AdjustMessage(ref MessageData message, int odcode, int X, int Y, string data)
        {
            message.odcode = odcode;
            message.X = X;
            message.Y = Y;
            message.data = data;
        }
    }
}

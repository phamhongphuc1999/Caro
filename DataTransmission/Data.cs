using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataTransmission
{
    //100: send name player
    //101: send point
    //110: handle undo game
    //111: handle redo game
    //112: new game
    //120: send chat
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
    public class Data
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

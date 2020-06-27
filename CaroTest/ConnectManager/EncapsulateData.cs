using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace CaroTest.ConnectManager
{
    [Serializable]
    public struct MessageData
    {
        public int odcode;
        public string data;

        public MessageData(int odcode, string data)
        {
            this.odcode = odcode;
            this.data = data;
        }
    };

    class EncapsulateData
    {
        public static int SIZE = Marshal.SizeOf(typeof(MessageData));

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
    }
}

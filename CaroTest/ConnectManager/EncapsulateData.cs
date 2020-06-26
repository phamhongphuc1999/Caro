using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CaroTest.ConnectManager
{
    //100: send player name to other player
    struct MessageData
    {
        public int odcode;
        public string data;
    }

    class EncapsulateData
    {
        public static byte[] SerializeData(MessageData message)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, message);
            return ms.ToArray();
        }

        public static MessageData DeserializeData(byte[] byteData)
        {
            MemoryStream ms = new MemoryStream(byteData);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return (MessageData)bf1.Deserialize(ms);
        }

        public static MessageData CreateMessage(int odcode, string data)
        {
            MessageData result;
            result.odcode = odcode;
            result.data = data;
            return result;
        }
    }
}

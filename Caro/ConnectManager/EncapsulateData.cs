using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Caro.ConnectManager
{
    struct Message
    {
        int odcode;
        string data;
    }

    class EncapsulateData
    {
        public static byte[] SerializeData(Message message)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, message);
            return ms.ToArray();
        }

        public static Message DeserializeData(byte[] byteData)
        {
            MemoryStream ms = new MemoryStream(byteData);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return (Message)bf1.Deserialize(ms);
        }
    }
}

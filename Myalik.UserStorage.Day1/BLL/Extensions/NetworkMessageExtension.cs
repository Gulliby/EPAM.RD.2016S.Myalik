using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BLL.Entities.Interface;

namespace BLL.Extensions
{
    public static class NetworkMessageSerializeExtension
    {
        public static byte[] SerializeMessageToBinary(this IMessage messsage)
        {
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, messsage);
            return ms.GetBuffer();
        }
    }

    public static class NetworkMessageDeserializeExtension
    {
        public static IMessage DeserializeMessageFromBinary(this Stream stream)
        {
            var formatter = new BinaryFormatter();
            return formatter.Deserialize(stream) as IMessage;
        }
    }
}

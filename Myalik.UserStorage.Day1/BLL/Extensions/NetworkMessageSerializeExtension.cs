// <copyright file="NetworkMessageSerializeExtension.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Extensions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Entities.Interface;

    public static class NetworkMessageSerializeExtension
    {
        /// <summary>
        /// Method serialize message to binary format.
        /// </summary>
        /// <param name="messsage">Message for serializing.</param>
        /// <returns>Message in binary format.</returns>
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
        /// <summary>
        /// Method deserialize message from the binary format to IMessage.
        /// </summary>
        /// <param name="stream">Stream which contains message in binary format.</param>
        /// <returns>Message in IMessage "format".</returns>
        public static IMessage DeserializeMessageFromBinary(this Stream stream)
        {
            var formatter = new BinaryFormatter();
            return formatter.Deserialize(stream) as IMessage;
        }
    }
}

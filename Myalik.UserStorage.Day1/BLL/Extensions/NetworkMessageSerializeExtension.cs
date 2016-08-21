// <copyright file="NetworkMessageSerializeExtension.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Extensions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using Entities.Interface;

    /// <summary>
    /// Extension for message serialization.
    /// </summary>
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
}

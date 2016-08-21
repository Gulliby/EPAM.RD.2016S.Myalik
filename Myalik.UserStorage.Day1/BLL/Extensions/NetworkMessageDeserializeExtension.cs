// <copyright file="NetworkMessageDeserializeExtension.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Extensions
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using BLL.Entities.Interface;

    /// <summary>
    /// Extension for message de-serialization.
    /// </summary>
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

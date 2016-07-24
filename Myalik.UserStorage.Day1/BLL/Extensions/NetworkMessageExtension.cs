﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
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
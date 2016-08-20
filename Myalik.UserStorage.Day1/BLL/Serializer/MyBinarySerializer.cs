// <copyright file="MyBinarySerializer.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace BLL.Serializer
{
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using Entities.Interface;

    /// <summary>
    /// Custom binary serializer.
    /// </summary>
    public static class MyBinarySerializer
    {
        /// <summary>
        /// Converts non-async method "Read" to async one.
        /// </summary>
        /// <typeparam name="T">Type which need to be read.</typeparam>
        /// <param name="stream">Stream where it need to be read from.</param>
        /// <returns>Async function of "Read".</returns>
        public static Task<T> ReadAsync<T>(Stream stream)
            where T : struct, IMessage
        {
            return Task.FromResult(Read<T>(stream));
        }

        /// <summary>
        /// Custom binary de-serializer.
        /// </summary>
        /// <typeparam name="T">Type which need to be deserialized(read).</typeparam>
        /// <param name="stream">Stream where it need to be read from.</param>
        /// <returns>Deserialized object.</returns>
        public static T Read<T>(Stream stream)
            where T : struct, IMessage 
        {  
            var length = Marshal.SizeOf(typeof(T));
            var bytes = new byte[length];
            stream.Read(bytes, 0, length);
            var handle = Marshal.AllocHGlobal(length);
            Marshal.Copy(bytes, 0, handle, length);
            var result = (T)Marshal.PtrToStructure(handle, typeof(T));
            Marshal.FreeHGlobal(handle);
            return result;     
        }

        /// <summary>
        /// Custom binary serializer.
        /// </summary>
        /// <param name="obj">Object which need to be serialized.</param>
        /// <returns>Object in binary format.</returns>
        public static byte[] Write(object obj)
        {
            var ms = new MemoryStream();
            var length = Marshal.SizeOf(obj);
            var bytes = new byte[length];
            var handle = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(obj, handle, true);
            Marshal.Copy(handle, bytes, 0, length);
            Marshal.FreeHGlobal(handle);
            ms.Write(bytes, 0, length);
            return ms.ToArray();
        }
    }
}

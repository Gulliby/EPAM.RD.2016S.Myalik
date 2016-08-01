using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BLL.Entities.Interface;

namespace BLL.Serializer
{
    public static class MyBinarySerializer
    {
        public static Task<T> ReadAsync<T>(Stream stream)
            where T : struct, IMessage
        {
            return Task.FromResult(Read<T>(stream));
        }

        public  static T Read<T>(Stream stream)
            where T : struct , IMessage 
        {  
            var Length = Marshal.SizeOf(typeof (T));
            var Bytes = new byte[Length];
            stream.Read(Bytes, 0, Length);
            var Handle = Marshal.AllocHGlobal(Length);
            Marshal.Copy(Bytes, 0, Handle, Length);
            var Result = (T) Marshal.PtrToStructure(Handle, typeof (T));
            Marshal.FreeHGlobal(Handle);
            return Result;     
        }

        public static byte[] Write(object obj)
        {
            var ms = new MemoryStream();
            var Length = Marshal.SizeOf(obj);
            var Bytes = new byte[Length];
            var Handle = Marshal.AllocHGlobal(Length);
            Marshal.StructureToPtr(obj, Handle, true);
            Marshal.Copy(Handle, Bytes, 0, Length);
            Marshal.FreeHGlobal(Handle);
            ms.Write(Bytes, 0, Length);
            return ms.ToArray();
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    public static class Helper
    {
        public static IntPtr AllocateBuffer() { return IntPtr.Zero; }
        public static void DeallocateBuffer(IntPtr ptr) { }
        public static SafeHandle GetResource() { return new Microsoft.Win32.SafeHandles.SafeFileHandle(IntPtr.Zero, true); }
    }
}

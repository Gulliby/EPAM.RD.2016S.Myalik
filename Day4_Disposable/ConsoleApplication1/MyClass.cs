using System;
using System.Runtime.InteropServices;
using System.IO;

namespace ConsoleApplication1
{
    // TODO: The code below contains a lot of issues. Please, fix all of them.
    // Use as a guidelines:
    // https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx
    // https://msdn.microsoft.com/en-us/library/b1yfkh5e%28v=vs.100%29.aspx?f=255&MSPPError=-2147217396
    // https://msdn.microsoft.com/en-us/library/fs2xkftw(v=vs.110).aspx
    public class MyClass : IDisposable
    {
        private IntPtr _buffer;       // unmanaged resource
        private SafeHandle _resource; // managed resource
        private bool _disposed = false;

        public MyClass()
        {
            this._buffer = Helper.AllocateBuffer();
            this._resource = Helper.GetResource();
        }

        ~MyClass()
        {
            Dispose(true);
        }

        public virtual void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)       
                _resource = null;              
            _buffer = IntPtr.Zero;
            _disposed = true;
        }

        public void DoSomething()
        {
            // NOTE: Manupulation with _buffer and _resource in this line.
            if (_resource.IsInvalid) 
                throw new ObjectDisposedException(nameof(_resource));
            using (var file = new FileStream("testname", FileMode.Create, FileAccess.Write))
            {
                unsafe
                {
                    var ustream = new UnmanagedMemoryStream((byte*)_buffer, 0);
                    ustream.CopyTo(file);
                    file.Close();
                    ustream.Close();
                }
            }
        }
    }
}

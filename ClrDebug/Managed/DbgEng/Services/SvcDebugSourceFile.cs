using System;

namespace ClrDebug.DbgEng
{
    public class SvcDebugSourceFile : ComObject<ISvcDebugSourceFile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDebugSourceFile"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDebugSourceFile(ISvcDebugSourceFile raw) : base(raw)
        {
        }

        #region ISvcDebugSourceFile
        #region Read

        public long Read(long byteOffset, IntPtr buffer, long readSize)
        {
            long bytesRead;
            TryRead(byteOffset, buffer, readSize, out bytesRead).ThrowDbgEngNotOK();

            return bytesRead;
        }

        public HRESULT TryRead(long byteOffset, IntPtr buffer, long readSize, out long bytesRead)
        {
            /*HRESULT Read(
            [In] long byteOffset,
            [Out] IntPtr buffer,
            [In] long readSize,
            [Out] out long bytesRead);*/
            return Raw.Read(byteOffset, buffer, readSize, out bytesRead);
        }

        #endregion
        #region Write

        public long Write(long byteOffset, IntPtr buffer, long writeSize)
        {
            long bytesWritten;
            TryWrite(byteOffset, buffer, writeSize, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        public HRESULT TryWrite(long byteOffset, IntPtr buffer, long writeSize, out long bytesWritten)
        {
            /*HRESULT Write(
            [In] long byteOffset,
            [In] IntPtr buffer,
            [In] long writeSize,
            [Out] out long bytesWritten);*/
            return Raw.Write(byteOffset, buffer, writeSize, out bytesWritten);
        }

        #endregion
        #endregion
    }
}

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

        /// <summary>
        /// Attempts to read the number of bytes specified by the 'readSize' argument from the file offset supplied by 'byteOffset' into the buffer supplied by the 'buffer' argument.<para/>
        /// Note that a partial read is a successful state of this method. In such a case, the 'bytesRead' argument will be set to the number of bytes actually read and S_FALSE will be returned.
        /// </summary>
        public long Read(long byteOffset, IntPtr buffer, long readSize)
        {
            long bytesRead;
            TryRead(byteOffset, buffer, readSize, out bytesRead).ThrowDbgEngNotOK();

            return bytesRead;
        }

        /// <summary>
        /// Attempts to read the number of bytes specified by the 'readSize' argument from the file offset supplied by 'byteOffset' into the buffer supplied by the 'buffer' argument.<para/>
        /// Note that a partial read is a successful state of this method. In such a case, the 'bytesRead' argument will be set to the number of bytes actually read and S_FALSE will be returned.
        /// </summary>
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

        /// <summary>
        /// Attempts to write the number of bytes specified by the 'writeSize' argument into the file (or a copy-on-write mapping on top of the file as determined by the implementation) at the offset supplied by the 'byteOffset' argument.<para/>
        /// The contents written are from the buffer supplied by the 'buffer' argument. Note that a partial write is a successful state of this method.<para/>
        /// In such a case, the 'bytesWritten' argument will be set to the number of bytes actually written and S_FALSE will be returned.
        /// </summary>
        public long Write(long byteOffset, IntPtr buffer, long writeSize)
        {
            long bytesWritten;
            TryWrite(byteOffset, buffer, writeSize, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        /// <summary>
        /// Attempts to write the number of bytes specified by the 'writeSize' argument into the file (or a copy-on-write mapping on top of the file as determined by the implementation) at the offset supplied by the 'byteOffset' argument.<para/>
        /// The contents written are from the buffer supplied by the 'buffer' argument. Note that a partial write is a successful state of this method.<para/>
        /// In such a case, the 'bytesWritten' argument will be set to the number of bytes actually written and S_FALSE will be returned.
        /// </summary>
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

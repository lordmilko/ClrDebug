using System;

namespace ClrDebug.DbgEng
{
    public class SvcClassicSpecialContext : ComObject<ISvcClassicSpecialContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcClassicSpecialContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcClassicSpecialContext(ISvcClassicSpecialContext raw) : base(raw)
        {
        }

        #region ISvcClassicSpecialContext
        #region SpecialContextSize

        public long SpecialContextSize
        {
            get
            {
                /*long GetSpecialContextSize();*/
                return Raw.GetSpecialContextSize();
            }
        }

        #endregion
        #region GetSpecialContext

        public long GetSpecialContext(long bufferSize, IntPtr contextBuffer)
        {
            long contextSize;
            TryGetSpecialContext(bufferSize, contextBuffer, out contextSize).ThrowDbgEngNotOK();

            return contextSize;
        }

        public HRESULT TryGetSpecialContext(long bufferSize, IntPtr contextBuffer, out long contextSize)
        {
            /*HRESULT GetSpecialContext(
            [In] long bufferSize,
            [Out] IntPtr contextBuffer,
            [Out] out long contextSize);*/
            return Raw.GetSpecialContext(bufferSize, contextBuffer, out contextSize);
        }

        #endregion
        #region SetSpecialContext

        public void SetSpecialContext(long bufferSize, IntPtr contextBuffer)
        {
            TrySetSpecialContext(bufferSize, contextBuffer).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetSpecialContext(long bufferSize, IntPtr contextBuffer)
        {
            /*HRESULT SetSpecialContext(
            [In] long bufferSize,
            [In] IntPtr contextBuffer);*/
            return Raw.SetSpecialContext(bufferSize, contextBuffer);
        }

        #endregion
        #endregion
    }
}

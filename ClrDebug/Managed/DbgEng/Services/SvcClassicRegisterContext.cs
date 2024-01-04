using System;

namespace ClrDebug.DbgEng
{
    public class SvcClassicRegisterContext : ComObject<ISvcClassicRegisterContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcClassicRegisterContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcClassicRegisterContext(ISvcClassicRegisterContext raw) : base(raw)
        {
        }

        #region ISvcClassicRegisterContext
        #region ContextSize

        public long ContextSize
        {
            get
            {
                /*long GetContextSize();*/
                return Raw.GetContextSize();
            }
        }

        #endregion
        #region GetContext

        public long GetContext(long bufferSize, IntPtr contextBuffer)
        {
            long contextSize;
            TryGetContext(bufferSize, contextBuffer, out contextSize).ThrowDbgEngNotOK();

            return contextSize;
        }

        public HRESULT TryGetContext(long bufferSize, IntPtr contextBuffer, out long contextSize)
        {
            /*HRESULT GetContext(
            [In] long bufferSize,
            [Out] IntPtr contextBuffer,
            [Out] out long contextSize);*/
            return Raw.GetContext(bufferSize, contextBuffer, out contextSize);
        }

        #endregion
        #region SetContext

        public void SetContext(long bufferSize, IntPtr contextBuffer)
        {
            TrySetContext(bufferSize, contextBuffer).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetContext(long bufferSize, IntPtr contextBuffer)
        {
            /*HRESULT SetContext(
            [In] long bufferSize,
            [In] IntPtr contextBuffer);*/
            return Raw.SetContext(bufferSize, contextBuffer);
        }

        #endregion
        #endregion
    }
}

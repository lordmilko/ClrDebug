using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcClassicRegisterContext interface is provided by register contexts whose backing store is a platform specific CONTEXT structure.<para/>
    /// No register context is required to support this interface. Any register context which supports this interface *IS REQUIRED* to support ISvcRegisterContext.<para/>
    /// Note that one can achieve the same thing by getting the DEBUG_SERVICE_REGISTERCONTEXTTRANSLATION for the Windows platform domain.<para/>
    /// This is just faster for contexts that support such.
    /// </summary>
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

        /// <summary>
        /// Gets the size of the context structure (CONTEXT for the given architecture that this ISvcClassicRegisterContext represents).
        /// </summary>
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

        /// <summary>
        /// Fills in a Win32 CONTEXT structure for the given machine architecture.
        /// </summary>
        public long GetContext(long bufferSize, IntPtr contextBuffer)
        {
            long contextSize;
            TryGetContext(bufferSize, contextBuffer, out contextSize).ThrowDbgEngNotOK();

            return contextSize;
        }

        /// <summary>
        /// Fills in a Win32 CONTEXT structure for the given machine architecture.
        /// </summary>
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

        /// <summary>
        /// Changes the values in this register context to the ones given by the incoming Win32 CONTEXT structure.
        /// </summary>
        public void SetContext(long bufferSize, IntPtr contextBuffer)
        {
            TrySetContext(bufferSize, contextBuffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Changes the values in this register context to the ones given by the incoming Win32 CONTEXT structure.
        /// </summary>
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

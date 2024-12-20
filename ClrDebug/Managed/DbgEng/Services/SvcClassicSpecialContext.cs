using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcClassicSpecialContext interface is provided by register contexts have a portion of their backing store given by a platform specific KSPECIAL_REGISTERS structure.<para/>
    /// No register context is required to support this interface. Any register context which supports this interface *IS REQUIRED* to support ISvcRegisterContext.
    /// </summary>
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

        /// <summary>
        /// Gets the size of the special context structure (KSPECIAL_REGISTERS for the given architecture that this ISvcClassicSpecialContext represents).
        /// </summary>
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

        /// <summary>
        /// Fills in a KSPECIAL_REGISTERS structure for the given machine architecture.
        /// </summary>
        public long GetSpecialContext(long bufferSize, IntPtr contextBuffer)
        {
            long contextSize;
            TryGetSpecialContext(bufferSize, contextBuffer, out contextSize).ThrowDbgEngNotOK();

            return contextSize;
        }

        /// <summary>
        /// Fills in a KSPECIAL_REGISTERS structure for the given machine architecture.
        /// </summary>
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

        /// <summary>
        /// Changes the values in this register context to the ones given by the incoming KSPECIAL_REGISTERS structure.
        /// </summary>
        public void SetSpecialContext(long bufferSize, IntPtr contextBuffer)
        {
            TrySetSpecialContext(bufferSize, contextBuffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Changes the values in this register context to the ones given by the incoming KSPECIAL_REGISTERS structure.
        /// </summary>
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

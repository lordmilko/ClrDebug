using System;

namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetCapabilities : ComObject<ISvcSymbolSetCapabilities>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetCapabilities"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetCapabilities(ISvcSymbolSetCapabilities raw) : base(raw)
        {
        }

        #region ISvcSymbolSetCapabilities
        #region QueryCapability

        public void QueryCapability(Guid set, int id, int bufferSize, IntPtr buffer)
        {
            TryQueryCapability(set, id, bufferSize, buffer).ThrowDbgEngNotOK();
        }

        public HRESULT TryQueryCapability(Guid set, int id, int bufferSize, IntPtr buffer)
        {
            /*HRESULT QueryCapability(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [In] int bufferSize,
            [Out] IntPtr buffer);*/
            return Raw.QueryCapability(set, id, bufferSize, buffer);
        }

        #endregion
        #endregion
    }
}

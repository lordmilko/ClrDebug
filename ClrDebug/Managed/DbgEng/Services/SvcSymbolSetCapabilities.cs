using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Optionally provided by any symbol set. Represents a way to query the capabilities (and some key properties) of a symbol set.<para/>
    /// This interface is *ENTIRELY* optional. If it is not present, the default value of any capability queried must be assumed.
    /// </summary>
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

        /// <summary>
        /// Asks the symbol set about a particular capability as identified by a set GUID and an ID within that set. Each GUID/ID identifies the type of data returned in the resulting buffer.<para/>
        /// The following error codes carry special semantics with this API E_NOT_SET: The symbol set does not understand the capability.<para/>
        /// Assume default behavior.
        /// </summary>
        public void QueryCapability(Guid set, int id, int bufferSize, IntPtr buffer)
        {
            TryQueryCapability(set, id, bufferSize, buffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Asks the symbol set about a particular capability as identified by a set GUID and an ID within that set. Each GUID/ID identifies the type of data returned in the resulting buffer.<para/>
        /// The following error codes carry special semantics with this API E_NOT_SET: The symbol set does not understand the capability.<para/>
        /// Assume default behavior.
        /// </summary>
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

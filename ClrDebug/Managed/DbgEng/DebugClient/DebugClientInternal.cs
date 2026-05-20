using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugClientInternal : ComObject<IDebugClientInternal>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugClientInternal"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugClientInternal(IDebugClientInternal raw) : base(raw)
        {
        }

        #region IDebugClientInternal
        #region OpenProtocolConnectionWide

        public void OpenProtocolConnectionWide(string protocolString)
        {
            TryOpenProtocolConnectionWide(protocolString).ThrowDbgEngNotOK();
        }

        public HRESULT TryOpenProtocolConnectionWide(string protocolString)
        {
            /*HRESULT OpenProtocolConnectionWide(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString);*/
            return Raw.OpenProtocolConnectionWide(protocolString);
        }

        #endregion
        #endregion
        #region IDebugClientInternal2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugClientInternal2 Raw2 => (IDebugClientInternal2) Raw;

        #region OpenProtocolConnectionWide2

        public OpenProtocolConnectionWide2Result OpenProtocolConnectionWide2(string protocolString)
        {
            OpenProtocolConnectionWide2Result result;
            TryOpenProtocolConnectionWide2(protocolString, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryOpenProtocolConnectionWide2(string protocolString, out OpenProtocolConnectionWide2Result result)
        {
            /*HRESULT OpenProtocolConnectionWide2(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString,
            [Out] out ProtocolConnectionKind connectionKind,
            [Out] out int systemId,
            [Out] out long server);*/
            ProtocolConnectionKind connectionKind;
            int systemId;
            long server;
            HRESULT hr = Raw2.OpenProtocolConnectionWide2(protocolString, out connectionKind, out systemId, out server);

            if (hr == HRESULT.S_OK)
                result = new OpenProtocolConnectionWide2Result(connectionKind, systemId, server);
            else
                result = default(OpenProtocolConnectionWide2Result);

            return hr;
        }

        #endregion
        #endregion
    }
}

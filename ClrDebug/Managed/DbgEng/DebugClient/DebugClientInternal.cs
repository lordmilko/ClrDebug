using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugClientInternal : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugClientInternal = new Guid("0995BEC6-8A12-453d-A694-09CD2712BDD7");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugClientInternalVtbl* Vtbl => (IDebugClientInternalVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugClientInternal2Vtbl* Vtbl2 => (IDebugClientInternal2Vtbl*) base.Vtbl;

        #endregion

        public DebugClientInternal(IntPtr raw) : base(raw, IID_IDebugClientInternal)
        {
        }

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
            InitDelegate(ref openProtocolConnectionWide, Vtbl->OpenProtocolConnectionWide);

            /*HRESULT OpenProtocolConnectionWide(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString);*/
            return openProtocolConnectionWide(Raw, protocolString);
        }

        #endregion
        #endregion
        #region IDebugClientInternal2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr raw2;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IntPtr Raw2
        {
            get
            {
                InitInterface(typeof(IDebugClientInternal2).GUID, ref raw2);

                return raw2;
            }
        }

        #region OpenProtocolConnectionWide2

        public OpenProtocolConnectionWide2Result OpenProtocolConnectionWide2(string protocolString)
        {
            OpenProtocolConnectionWide2Result result;
            TryOpenProtocolConnectionWide2(protocolString, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryOpenProtocolConnectionWide2(string protocolString, out OpenProtocolConnectionWide2Result result)
        {
            InitDelegate(ref openProtocolConnectionWide2, Vtbl2->OpenProtocolConnectionWide2);
            /*HRESULT OpenProtocolConnectionWide2(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString,
            [Out] out ProtocolConnectionKind connectionKind,
            [Out] out int systemId,
            [Out] out long server);*/
            ProtocolConnectionKind connectionKind;
            int systemId;
            long server;
            HRESULT hr = openProtocolConnectionWide2(Raw2, protocolString, out connectionKind, out systemId, out server);

            if (hr == HRESULT.S_OK)
                result = new OpenProtocolConnectionWide2Result(connectionKind, systemId, server);
            else
                result = default(OpenProtocolConnectionWide2Result);

            return hr;
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugClientInternal

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenProtocolConnectionWideDelegate openProtocolConnectionWide;

        #endregion
        #region IDebugClientInternal2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenProtocolConnectionWide2Delegate openProtocolConnectionWide2;

        #endregion
        #endregion
        #region Delegates
        #region IDebugClientInternal

        private delegate HRESULT OpenProtocolConnectionWideDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string protocolString);

        #endregion
        #region IDebugClientInternal2

        private delegate HRESULT OpenProtocolConnectionWide2Delegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string protocolString, [Out] out ProtocolConnectionKind connectionKind, [Out] out int systemId, [Out] out long server);

        #endregion
        #endregion

        protected override void ReleaseSubInterfaces()
        {
            ReleaseInterface(ref raw2);
        }
    }
}

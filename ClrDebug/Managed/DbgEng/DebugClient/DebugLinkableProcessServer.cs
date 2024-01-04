using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugLinkableProcessServer : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugLinkableProcessServer = new Guid("4DE9A876-D3C5-4313-9D8F-660C29CBEB9A");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugLinkableProcessServerVtbl* Vtbl => (IDebugLinkableProcessServerVtbl*) base.Vtbl;

        #endregion

        public DebugLinkableProcessServer(IntPtr raw) : base(raw, IID_IDebugLinkableProcessServer)
        {
        }

        public DebugLinkableProcessServer(IDebugLinkableProcessServer raw) : base(raw)
        {
        }

        #region IDebugLinkableProcessServer
        #region ConnectLinkedProcessServer

        public long ConnectLinkedProcessServer(long server, string remoteOptions)
        {
            long newServer;
            TryConnectLinkedProcessServer(server, remoteOptions, out newServer).ThrowDbgEngNotOK();

            return newServer;
        }

        public HRESULT TryConnectLinkedProcessServer(long server, string remoteOptions, out long newServer)
        {
            InitDelegate(ref connectLinkedProcessServer, Vtbl->ConnectLinkedProcessServer);

            /*HRESULT ConnectLinkedProcessServer(
            [In] long server,
            [MarshalAs(UnmanagedType.LPWStr), In] string remoteOptions,
            [Out] out long newServer);*/
            return connectLinkedProcessServer(Raw, server, remoteOptions, out newServer);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugLinkableProcessServer

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ConnectLinkedProcessServerDelegate connectLinkedProcessServer;

        #endregion
        #endregion
        #region Delegates
        #region IDebugLinkableProcessServer

        private delegate HRESULT ConnectLinkedProcessServerDelegate(IntPtr self, [In] long server, [MarshalAs(UnmanagedType.LPWStr), In] string remoteOptions, [Out] out long newServer);

        #endregion
        #endregion
    }
}

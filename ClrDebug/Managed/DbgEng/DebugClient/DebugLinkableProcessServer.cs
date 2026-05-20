namespace ClrDebug.DbgEng
{
    public class DebugLinkableProcessServer : ComObject<IDebugLinkableProcessServer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLinkableProcessServer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
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
            /*HRESULT ConnectLinkedProcessServer(
            [In] long server,
            [MarshalAs(UnmanagedType.LPWStr), In] string remoteOptions,
            [Out] out long newServer);*/
            return Raw.ConnectLinkedProcessServer(server, remoteOptions, out newServer);
        }

        #endregion
        #endregion
    }
}

namespace ClrDebug.DbgEng
{
    public class DebugTargetCompositionProtocolActivator : ComObject<IDebugTargetCompositionProtocolActivator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugTargetCompositionProtocolActivator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugTargetCompositionProtocolActivator(IDebugTargetCompositionProtocolActivator raw) : base(raw)
        {
        }

        #region IDebugTargetCompositionProtocolActivator
        #region IsRecognizedProtocol

        /// <summary>
        /// Returns whether or not the given protocol string is recognized as the type of protocol expected. At the time of this call, the service manager is empty.
        /// </summary>
        public bool IsRecognizedProtocol(IDebugServiceManager pServiceManager, string pwszProtocolString)
        {
            bool pIsRecognized;
            TryIsRecognizedProtocol(pServiceManager, pwszProtocolString, out pIsRecognized).ThrowDbgEngNotOK();

            return pIsRecognized;
        }

        /// <summary>
        /// Returns whether or not the given protocol string is recognized as the type of protocol expected. At the time of this call, the service manager is empty.
        /// </summary>
        public HRESULT TryIsRecognizedProtocol(IDebugServiceManager pServiceManager, string pwszProtocolString, out bool pIsRecognized)
        {
            /*HRESULT IsRecognizedProtocol(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolString,
            [Out] out bool pIsRecognized);*/
            return Raw.IsRecognizedProtocol(pServiceManager, pwszProtocolString, out pIsRecognized);
        }

        #endregion
        #region InitializeServices

        /// <summary>
        /// For a protocol which is recognized by this activator as the type of protocol expected (IsRecognizedProtocol returns true), this call is made to the activator to add the requisite set of services to the service manager in order to make the full target debuggable.
        /// </summary>
        public void InitializeServices(IDebugServiceManager pServiceManager, string pwszProtocolString)
        {
            TryInitializeServices(pServiceManager, pwszProtocolString).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// For a protocol which is recognized by this activator as the type of protocol expected (IsRecognizedProtocol returns true), this call is made to the activator to add the requisite set of services to the service manager in order to make the full target debuggable.
        /// </summary>
        public HRESULT TryInitializeServices(IDebugServiceManager pServiceManager, string pwszProtocolString)
        {
            /*HRESULT InitializeServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolString);*/
            return Raw.InitializeServices(pServiceManager, pwszProtocolString);
        }

        #endregion
        #endregion
    }
}

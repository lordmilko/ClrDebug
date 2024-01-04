namespace ClrDebug.DbgEng
{
    public class DebugHostContextTargetComposition : ComObject<IDebugHostContextTargetComposition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostContextTargetComposition"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostContextTargetComposition(IDebugHostContextTargetComposition raw) : base(raw)
        {
        }

        #region IDebugHostContextTargetComposition
        #region ServiceManager

        public DebugServiceManager ServiceManager
        {
            get
            {
                DebugServiceManager ppServiceManagerResult;
                TryGetServiceManager(out ppServiceManagerResult).ThrowDbgEngNotOK();

                return ppServiceManagerResult;
            }
        }

        public HRESULT TryGetServiceManager(out DebugServiceManager ppServiceManagerResult)
        {
            /*HRESULT GetServiceManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager ppServiceManager);*/
            IDebugServiceManager ppServiceManager;
            HRESULT hr = Raw.GetServiceManager(out ppServiceManager);

            if (hr == HRESULT.S_OK)
                ppServiceManagerResult = ppServiceManager == null ? null : new DebugServiceManager(ppServiceManager);
            else
                ppServiceManagerResult = default(DebugServiceManager);

            return hr;
        }

        #endregion
        #region ServiceProcess

        public SvcProcess ServiceProcess
        {
            get
            {
                SvcProcess ppProcessResult;
                TryGetServiceProcess(out ppProcessResult).ThrowDbgEngNotOK();

                return ppProcessResult;
            }
        }

        public HRESULT TryGetServiceProcess(out SvcProcess ppProcessResult)
        {
            /*HRESULT GetServiceProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);*/
            ISvcProcess ppProcess;
            HRESULT hr = Raw.GetServiceProcess(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = ppProcess == null ? null : new SvcProcess(ppProcess);
            else
                ppProcessResult = default(SvcProcess);

            return hr;
        }

        #endregion
        #region ServiceThread

        public SvcThread ServiceThread
        {
            get
            {
                SvcThread ppThreadResult;
                TryGetServiceThread(out ppThreadResult).ThrowDbgEngNotOK();

                return ppThreadResult;
            }
        }

        public HRESULT TryGetServiceThread(out SvcThread ppThreadResult)
        {
            /*HRESULT GetServiceThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread ppThread);*/
            ISvcThread ppThread;
            HRESULT hr = Raw.GetServiceThread(out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = ppThread == null ? null : new SvcThread(ppThread);
            else
                ppThreadResult = default(SvcThread);

            return hr;
        }

        #endregion
        #endregion
    }
}

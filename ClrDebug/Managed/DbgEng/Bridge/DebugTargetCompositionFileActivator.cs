using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugTargetCompositionFileActivator : ComObject<IDebugTargetCompositionFileActivator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugTargetCompositionFileActivator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugTargetCompositionFileActivator(IDebugTargetCompositionFileActivator raw) : base(raw)
        {
        }

        #region IDebugTargetCompositionFileActivator
        #region IsRecognizedFile

        /// <summary>
        /// Returns whether or not the given file is recognized as the type of file expected. At the time of this call, the service manager contains a file debug source and nothing else.<para/>
        /// The file debug source is also passed explicitly to the method.
        /// </summary>
        public bool IsRecognizedFile(IDebugServiceManager pServiceManager, ISvcDebugSourceFile pFile)
        {
            bool pIsRecognized;
            TryIsRecognizedFile(pServiceManager, pFile, out pIsRecognized).ThrowDbgEngNotOK();

            return pIsRecognized;
        }

        /// <summary>
        /// Returns whether or not the given file is recognized as the type of file expected. At the time of this call, the service manager contains a file debug source and nothing else.<para/>
        /// The file debug source is also passed explicitly to the method.
        /// </summary>
        public HRESULT TryIsRecognizedFile(IDebugServiceManager pServiceManager, ISvcDebugSourceFile pFile, out bool pIsRecognized)
        {
            /*HRESULT IsRecognizedFile(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In] ISvcDebugSourceFile pFile,
            [Out] out bool pIsRecognized);*/
            return Raw.IsRecognizedFile(pServiceManager, pFile, out pIsRecognized);
        }

        #endregion
        #region InitializeServices

        /// <summary>
        /// For a file type which is recognized by this activator as the type of file expected (IsRecognizedFile returns true), this call is made to the activator to add the requisite set of services to the service manager in order to make the full target debuggable.
        /// </summary>
        public void InitializeServices(IDebugServiceManager pServiceManager)
        {
            TryInitializeServices(pServiceManager).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// For a file type which is recognized by this activator as the type of file expected (IsRecognizedFile returns true), this call is made to the activator to add the requisite set of services to the service manager in order to make the full target debuggable.
        /// </summary>
        public HRESULT TryInitializeServices(IDebugServiceManager pServiceManager)
        {
            /*HRESULT InitializeServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager);*/
            return Raw.InitializeServices(pServiceManager);
        }

        #endregion
        #endregion
        #region IDebugTargetCompositionFileActivator2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugTargetCompositionFileActivator2 Raw2 => (IDebugTargetCompositionFileActivator2) Raw;

        #region IsRecognizedFileName

        /// <summary>
        /// Activators which want to serve a more complex query against file names than a singular extension or wildcard extension match may implement IDebugTargetCompositionFileActivator2 and IsRecognizedFileName.<para/>
        /// This method will be called *PRIOR* to any IsRecognizedFile call. If *pIsRecognized is set to false, no further calls will be made on the activator for the file in question.<para/>
        /// If *pIsRecognized is set to true, the activator will proceed to a further IsRecognizedFile check. NOTE: For files contained within compressed containers (e.g.: ZIP/CAB/etc...), this check on a given activator is made *PRIOR* to decompression.<para/>
        /// An *IsRecognizedFile* check is made *AFTER* decompression. An implementation of this method may legally return E_NOTIMPL.<para/>
        /// If such is returned, behavior is identical to returning *pIsRecognized of true. Further checks will be made on the activator.
        /// </summary>
        public bool IsRecognizedFileName(string pwszFileName)
        {
            bool pIsRecognized;
            TryIsRecognizedFileName(pwszFileName, out pIsRecognized).ThrowDbgEngNotOK();

            return pIsRecognized;
        }

        /// <summary>
        /// Activators which want to serve a more complex query against file names than a singular extension or wildcard extension match may implement IDebugTargetCompositionFileActivator2 and IsRecognizedFileName.<para/>
        /// This method will be called *PRIOR* to any IsRecognizedFile call. If *pIsRecognized is set to false, no further calls will be made on the activator for the file in question.<para/>
        /// If *pIsRecognized is set to true, the activator will proceed to a further IsRecognizedFile check. NOTE: For files contained within compressed containers (e.g.: ZIP/CAB/etc...), this check on a given activator is made *PRIOR* to decompression.<para/>
        /// An *IsRecognizedFile* check is made *AFTER* decompression. An implementation of this method may legally return E_NOTIMPL.<para/>
        /// If such is returned, behavior is identical to returning *pIsRecognized of true. Further checks will be made on the activator.
        /// </summary>
        public HRESULT TryIsRecognizedFileName(string pwszFileName, out bool pIsRecognized)
        {
            /*HRESULT IsRecognizedFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [Out] out bool pIsRecognized);*/
            return Raw2.IsRecognizedFileName(pwszFileName, out pIsRecognized);
        }

        #endregion
        #endregion
    }
}

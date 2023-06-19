using System.Linq;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that access information to be displayed about a process.
    /// </summary>
    public class CorPublishProcess : ComObject<ICorPublishProcess>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorPublishProcess"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorPublishProcess(ICorPublishProcess raw) : base(raw)
        {
        }

        #region ICorPublishProcess
        #region IsManaged

        /// <summary>
        /// Gets a value that indicates whether the process referenced by this <see cref="ICorPublishProcess"/> is known to have managed code.
        /// </summary>
        public bool IsManaged
        {
            get
            {
                bool pbManaged;
                TryIsManaged(out pbManaged).ThrowOnNotOK();

                return pbManaged;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the process referenced by this <see cref="ICorPublishProcess"/> is known to have managed code.
        /// </summary>
        /// <param name="pbManaged">[out] A pointer to a Boolean value that indicates whether the process has managed code. The value is true if the process has managed code; otherwise, false.</param>
        /// <remarks>
        /// Since the current version of ICorPublishProcess allows access only to processes that have managed code, IsManaged
        /// always returns true.
        /// </remarks>
        public HRESULT TryIsManaged(out bool pbManaged)
        {
            /*HRESULT IsManaged(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbManaged);*/
            return Raw.IsManaged(out pbManaged);
        }

        #endregion
        #region ProcessID

        /// <summary>
        /// Gets the operating system identifier for this process.
        /// </summary>
        public int ProcessID
        {
            get
            {
                int pid;
                TryGetProcessID(out pid).ThrowOnNotOK();

                return pid;
            }
        }

        /// <summary>
        /// Gets the operating system identifier for this process.
        /// </summary>
        /// <param name="pid">[out] A pointer to the identifier of the process represented by this <see cref="ICorPublishProcess"/> object.</param>
        public HRESULT TryGetProcessID(out int pid)
        {
            /*HRESULT GetProcessID(
            [Out] out int pid);*/
            return Raw.GetProcessID(out pid);
        }

        #endregion
        #region DisplayName

        /// <summary>
        /// Gets the full path of the executable for the process referenced by this <see cref="ICorPublishProcess"/>.
        /// </summary>
        public string DisplayName
        {
            get
            {
                string szNameResult;
                TryGetDisplayName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the full path of the executable for the process referenced by this <see cref="ICorPublishProcess"/>.
        /// </summary>
        /// <param name="szNameResult">[out] An array to store the name, including the full path, of the executable. The name is null-terminated.</param>
        public HRESULT TryGetDisplayName(out string szNameResult)
        {
            /*HRESULT GetDisplayName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);*/
            int cchName = 0;
            int pcchName;
            char[] szName;
            HRESULT hr = Raw.GetDisplayName(cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw.GetDisplayName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = CreateString(szName, pcchName);

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region EnumAppDomains

        /// <summary>
        /// Gets an enumerator for the application domains in the process that is referenced by this <see cref="ICorPublishProcess"/>.
        /// </summary>
        public CorPublishAppDomain[] AppDomains => EnumAppDomains().ToArray();

        /// <summary>
        /// Gets an enumerator for the application domains in the process that is referenced by this <see cref="ICorPublishProcess"/>.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorPublishAppDomainEnum"/> instance that allows iteration through the collection of application domains in this process.</returns>
        /// <remarks>
        /// The list of application domains is based on a snapshot of the application domains that exist when the EnumAppDomains
        /// method is called. This method may be called more than once to create a new up-to-date list. Existing lists will
        /// not be affected by subsequent calls of this method. If the process has been terminated, EnumAppDomains will fail
        /// with an HRESULT value of CORDBG_E_PROCESS_TERMINATED.
        /// </remarks>
        public CorPublishAppDomainEnum EnumAppDomains()
        {
            CorPublishAppDomainEnum ppEnumResult;
            TryEnumAppDomains(out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        /// <summary>
        /// Gets an enumerator for the application domains in the process that is referenced by this <see cref="ICorPublishProcess"/>.
        /// </summary>
        /// <param name="ppEnumResult">[out] A pointer to the address of an <see cref="ICorPublishAppDomainEnum"/> instance that allows iteration through the collection of application domains in this process.</param>
        /// <remarks>
        /// The list of application domains is based on a snapshot of the application domains that exist when the EnumAppDomains
        /// method is called. This method may be called more than once to create a new up-to-date list. Existing lists will
        /// not be affected by subsequent calls of this method. If the process has been terminated, EnumAppDomains will fail
        /// with an HRESULT value of CORDBG_E_PROCESS_TERMINATED.
        /// </remarks>
        public HRESULT TryEnumAppDomains(out CorPublishAppDomainEnum ppEnumResult)
        {
            /*HRESULT EnumAppDomains(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishAppDomainEnum ppEnum);*/
            ICorPublishAppDomainEnum ppEnum;
            HRESULT hr = Raw.EnumAppDomains(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = new CorPublishAppDomainEnum(ppEnum);
            else
                ppEnumResult = default(CorPublishAppDomainEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}

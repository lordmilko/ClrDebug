namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_KERNELINFRASTRUCTURE.
    /// </summary>
    public class SvcOSKernelTypes : ComObject<ISvcOSKernelTypes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcOSKernelTypes"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcOSKernelTypes(ISvcOSKernelTypes raw) : base(raw)
        {
        }

        #region ISvcOSKernelTypes
        #region ProcessType

        /// <summary>
        /// If the kernel describes the notion of processes from a process enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// For Windows, this would be EPROCESS. A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        public SvcSymbol ProcessType
        {
            get
            {
                SvcSymbol ppProcessTypeResult;
                TryGetProcessType(out ppProcessTypeResult).ThrowDbgEngNotOK();

                return ppProcessTypeResult;
            }
        }

        /// <summary>
        /// If the kernel describes the notion of processes from a process enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// For Windows, this would be EPROCESS. A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        public HRESULT TryGetProcessType(out SvcSymbol ppProcessTypeResult)
        {
            /*HRESULT GetProcessType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppProcessType);*/
            ISvcSymbol ppProcessType;
            HRESULT hr = Raw.GetProcessType(out ppProcessType);

            if (hr == HRESULT.S_OK)
                ppProcessTypeResult = ppProcessType == null ? null : new SvcSymbol(ppProcessType);
            else
                ppProcessTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region ThreadType

        /// <summary>
        /// If the kernel describes the notion of threads from a thread enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// For Windows, this would be ETHREAD. A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        public SvcSymbol ThreadType
        {
            get
            {
                SvcSymbol ppThreadTypeResult;
                TryGetThreadType(out ppThreadTypeResult).ThrowDbgEngNotOK();

                return ppThreadTypeResult;
            }
        }

        /// <summary>
        /// If the kernel describes the notion of threads from a thread enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// For Windows, this would be ETHREAD. A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        public HRESULT TryGetThreadType(out SvcSymbol ppThreadTypeResult)
        {
            /*HRESULT GetThreadType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppThreadType);*/
            ISvcSymbol ppThreadType;
            HRESULT hr = Raw.GetThreadType(out ppThreadType);

            if (hr == HRESULT.S_OK)
                ppThreadTypeResult = ppThreadType == null ? null : new SvcSymbol(ppThreadType);
            else
                ppThreadTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region ModuleType

        /// <summary>
        /// If the kernel describes the notion of a module (SO / DLL / driver) from a module enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        public SvcSymbol ModuleType
        {
            get
            {
                SvcSymbol ppModuleTypeResult;
                TryGetModuleType(out ppModuleTypeResult).ThrowDbgEngNotOK();

                return ppModuleTypeResult;
            }
        }

        /// <summary>
        /// If the kernel describes the notion of a module (SO / DLL / driver) from a module enumerator and such objects have an object in the kernel associated with them, that object is of this type.<para/>
        /// A return of E_NOT_SET indicates that no such type exists.
        /// </summary>
        public HRESULT TryGetModuleType(out SvcSymbol ppModuleTypeResult)
        {
            /*HRESULT GetModuleType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppModuleType);*/
            ISvcSymbol ppModuleType;
            HRESULT hr = Raw.GetModuleType(out ppModuleType);

            if (hr == HRESULT.S_OK)
                ppModuleTypeResult = ppModuleType == null ? null : new SvcSymbol(ppModuleType);
            else
                ppModuleTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #endregion
    }
}

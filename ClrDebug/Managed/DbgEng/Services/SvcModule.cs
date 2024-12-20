using System;

namespace ClrDebug.DbgEng
{
    public abstract class SvcModule : ComObject<ISvcModule>
    {
        public static SvcModule New(ISvcModule value)
        {
            if (value == null)
                return null;

            if (value is ISvcModuleWithTimestampAndChecksum)
                return new SvcModuleWithTimestampAndChecksum((ISvcModuleWithTimestampAndChecksum) value);

            throw new NotImplementedException("Encountered an 'ISvcModule' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SvcModule"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected SvcModule(ISvcModule raw) : base(raw)
        {
        }

        #region ISvcModule
        #region ContainingProcessKey

        /// <summary>
        /// Gets the unique key of the process to which this thread belongs. This is the same key returned from the containing ISvcProcess's GetKey method.<para/>
        /// This method may return S_FALSE and a process key of zero for modules which do not logically belong to any process (e.g.: they are kernel modules / drivers that are mapped into every process).
        /// </summary>
        public long ContainingProcessKey
        {
            get
            {
                long containingProcessKey;
                TryGetContainingProcessKey(out containingProcessKey).ThrowDbgEngNotOK();

                return containingProcessKey;
            }
        }

        /// <summary>
        /// Gets the unique key of the process to which this thread belongs. This is the same key returned from the containing ISvcProcess's GetKey method.<para/>
        /// This method may return S_FALSE and a process key of zero for modules which do not logically belong to any process (e.g.: they are kernel modules / drivers that are mapped into every process).
        /// </summary>
        public HRESULT TryGetContainingProcessKey(out long containingProcessKey)
        {
            /*HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);*/
            return Raw.GetContainingProcessKey(out containingProcessKey);
        }

        #endregion
        #region Key

        /// <summary>
        /// Gets the unique "per-process" module key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// This may be the base address of the module.
        /// </summary>
        public long Key
        {
            get
            {
                long moduleKey;
                TryGetKey(out moduleKey).ThrowDbgEngNotOK();

                return moduleKey;
            }
        }

        /// <summary>
        /// Gets the unique "per-process" module key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// This may be the base address of the module.
        /// </summary>
        public HRESULT TryGetKey(out long moduleKey)
        {
            /*HRESULT GetKey(
            [Out] out long moduleKey);*/
            return Raw.GetKey(out moduleKey);
        }

        #endregion
        #region BaseAddress

        /// <summary>
        /// Gets the base address of the module.
        /// </summary>
        public long BaseAddress
        {
            get
            {
                long moduleBaseAddress;
                TryGetBaseAddress(out moduleBaseAddress).ThrowDbgEngNotOK();

                return moduleBaseAddress;
            }
        }

        /// <summary>
        /// Gets the base address of the module.
        /// </summary>
        public HRESULT TryGetBaseAddress(out long moduleBaseAddress)
        {
            /*HRESULT GetBaseAddress(
            [Out] out long moduleBaseAddress);*/
            return Raw.GetBaseAddress(out moduleBaseAddress);
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size of the module.
        /// </summary>
        public long Size
        {
            get
            {
                long moduleSize;
                TryGetSize(out moduleSize).ThrowDbgEngNotOK();

                return moduleSize;
            }
        }

        /// <summary>
        /// Gets the size of the module.
        /// </summary>
        public HRESULT TryGetSize(out long moduleSize)
        {
            /*HRESULT GetSize(
            [Out] out long moduleSize);*/
            return Raw.GetSize(out moduleSize);
        }

        #endregion
        #region Name

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        public string Name
        {
            get
            {
                string moduleName;
                TryGetName(out moduleName).ThrowDbgEngNotOK();

                return moduleName;
            }
        }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        public HRESULT TryGetName(out string moduleName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string moduleName);*/
            return Raw.GetName(out moduleName);
        }

        #endregion
        #region Path

        /// <summary>
        /// Gets the load path of the module.
        /// </summary>
        public string Path
        {
            get
            {
                string modulePath;
                TryGetPath(out modulePath).ThrowDbgEngNotOK();

                return modulePath;
            }
        }

        /// <summary>
        /// Gets the load path of the module.
        /// </summary>
        public HRESULT TryGetPath(out string modulePath)
        {
            /*HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string modulePath);*/
            return Raw.GetPath(out modulePath);
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}

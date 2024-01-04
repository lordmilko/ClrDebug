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

        public long ContainingProcessKey
        {
            get
            {
                long containingProcessKey;
                TryGetContainingProcessKey(out containingProcessKey).ThrowDbgEngNotOK();

                return containingProcessKey;
            }
        }

        public HRESULT TryGetContainingProcessKey(out long containingProcessKey)
        {
            /*HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);*/
            return Raw.GetContainingProcessKey(out containingProcessKey);
        }

        #endregion
        #region Key

        public long Key
        {
            get
            {
                long moduleKey;
                TryGetKey(out moduleKey).ThrowDbgEngNotOK();

                return moduleKey;
            }
        }

        public HRESULT TryGetKey(out long moduleKey)
        {
            /*HRESULT GetKey(
            [Out] out long moduleKey);*/
            return Raw.GetKey(out moduleKey);
        }

        #endregion
        #region BaseAddress

        public long BaseAddress
        {
            get
            {
                long moduleBaseAddress;
                TryGetBaseAddress(out moduleBaseAddress).ThrowDbgEngNotOK();

                return moduleBaseAddress;
            }
        }

        public HRESULT TryGetBaseAddress(out long moduleBaseAddress)
        {
            /*HRESULT GetBaseAddress(
            [Out] out long moduleBaseAddress);*/
            return Raw.GetBaseAddress(out moduleBaseAddress);
        }

        #endregion
        #region Size

        public long Size
        {
            get
            {
                long moduleSize;
                TryGetSize(out moduleSize).ThrowDbgEngNotOK();

                return moduleSize;
            }
        }

        public HRESULT TryGetSize(out long moduleSize)
        {
            /*HRESULT GetSize(
            [Out] out long moduleSize);*/
            return Raw.GetSize(out moduleSize);
        }

        #endregion
        #region Name

        public string Name
        {
            get
            {
                string moduleName;
                TryGetName(out moduleName).ThrowDbgEngNotOK();

                return moduleName;
            }
        }

        public HRESULT TryGetName(out string moduleName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string moduleName);*/
            return Raw.GetName(out moduleName);
        }

        #endregion
        #region Path

        public string Path
        {
            get
            {
                string modulePath;
                TryGetPath(out modulePath).ThrowDbgEngNotOK();

                return modulePath;
            }
        }

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

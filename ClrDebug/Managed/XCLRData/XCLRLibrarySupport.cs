using System;

namespace ClrDebug
{
    public class XCLRLibrarySupport : ComObject<IXCLRLibrarySupport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRLibrarySupport"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRLibrarySupport(IXCLRLibrarySupport raw) : base(raw)
        {
        }

        #region IXCLRLibrarySupport
        #region LoadHardboundDependency

        public long LoadHardboundDependency(string name, Guid mvid)
        {
            long loadedBase;
            TryLoadHardboundDependency(name, mvid, out loadedBase).ThrowOnNotOK();

            return loadedBase;
        }

        public HRESULT TryLoadHardboundDependency(string name, Guid mvid, out long loadedBase)
        {
            /*HRESULT LoadHardboundDependency(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] ref Guid mvid,
            [Out] out long loadedBase);*/
            return Raw.LoadHardboundDependency(name, ref mvid, out loadedBase);
        }

        #endregion
        #region LoadSoftboundDependency

        public long LoadSoftboundDependency(string name, IntPtr assemblymetadataBinding, IntPtr hash, int hashLength)
        {
            long loadedBase;
            TryLoadSoftboundDependency(name, assemblymetadataBinding, hash, hashLength, out loadedBase).ThrowOnNotOK();

            return loadedBase;
        }

        public HRESULT TryLoadSoftboundDependency(string name, IntPtr assemblymetadataBinding, IntPtr hash, int hashLength, out long loadedBase)
        {
            /*HRESULT LoadSoftboundDependency(
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] IntPtr assemblymetadataBinding,
            [In] IntPtr hash,
            [In] int hashLength,
            [Out] out long loadedBase);*/
            return Raw.LoadSoftboundDependency(name, assemblymetadataBinding, hash, hashLength, out loadedBase);
        }

        #endregion
        #endregion
    }
}
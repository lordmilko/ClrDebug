using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
            HRESULT hr;
            long loadedBase;

            if ((hr = TryLoadHardboundDependency(name, mvid, out loadedBase)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return loadedBase;
        }

        public HRESULT TryLoadHardboundDependency(string name, Guid mvid, out long loadedBase)
        {
            /*HRESULT LoadHardboundDependency(
            [In] string name,
            [In] ref Guid mvid,
            [Out] out long loadedBase);*/
            return Raw.LoadHardboundDependency(name, ref mvid, out loadedBase);
        }

        #endregion
        #region LoadSoftboundDependency

        public long LoadSoftboundDependency(string name, IntPtr assemblymetadataBinding, IntPtr hash, int hashLength)
        {
            HRESULT hr;
            long loadedBase;

            if ((hr = TryLoadSoftboundDependency(name, assemblymetadataBinding, hash, hashLength, out loadedBase)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return loadedBase;
        }

        public HRESULT TryLoadSoftboundDependency(string name, IntPtr assemblymetadataBinding, IntPtr hash, int hashLength, out long loadedBase)
        {
            /*HRESULT LoadSoftboundDependency(
            [In] string name,
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
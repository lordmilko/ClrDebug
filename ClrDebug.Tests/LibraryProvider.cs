using System;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.Tests
{
#if NET8_0_OR_GREATER
    [GeneratedComClass]
#endif
    partial class LibraryProvider : ICLRDebuggingLibraryProvider3
    {
        public bool Called { get; set; }

        public HRESULT ProvideWindowsLibrary(string pwszFileName, string pwszRuntimeModule, LIBRARY_PROVIDER_INDEX_TYPE indexType,
            int dwTimestamp, int dwSizeOfImage, out IntPtr ppResolvedModulePath)
        {
            Called = true;
            ppResolvedModulePath = default;
            return HRESULT.E_NOTIMPL;
        }

        public HRESULT ProvideUnixLibrary(string pwszFileName, string pwszRuntimeModule, LIBRARY_PROVIDER_INDEX_TYPE indexType,
            byte[] pbBuildId, int iBuildIdSize, out IntPtr ppResolvedModulePath)
        {
            Called = true;
            ppResolvedModulePath = default;
            return HRESULT.E_NOTIMPL;
        }
    }
}

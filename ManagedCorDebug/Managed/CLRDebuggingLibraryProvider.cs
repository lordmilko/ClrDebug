using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRDebuggingLibraryProvider : ComObject<ICLRDebuggingLibraryProvider>
    {
        public CLRDebuggingLibraryProvider(ICLRDebuggingLibraryProvider raw) : base(raw)
        {
        }

        #region ICLRDebuggingLibraryProvider
        #region ProvideLibrary

        public IntPtr ProvideLibrary(string pwszFileName, uint dwTimestamp, uint dwSizeOfImage)
        {
            HRESULT hr;
            IntPtr phModule;

            if ((hr = TryProvideLibrary(pwszFileName, dwTimestamp, dwSizeOfImage, out phModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return phModule;
        }

        public HRESULT TryProvideLibrary(string pwszFileName, uint dwTimestamp, uint dwSizeOfImage, out IntPtr phModule)
        {
            /*HRESULT ProvideLibrary(
            [In] string pwszFileName,
            [In] uint dwTimestamp,
            [In] uint dwSizeOfImage,
            out IntPtr phModule);*/
            return Raw.ProvideLibrary(pwszFileName, dwTimestamp, dwSizeOfImage, out phModule);
        }

        #endregion
        #endregion
    }
}
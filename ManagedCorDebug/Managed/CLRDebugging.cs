using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRDebugging : ComObject<ICLRDebugging>
    {
        public CLRDebugging(ICLRDebugging raw) : base(raw)
        {
        }

        #region ICLRDebugging
        #region OpenVirtualProcess

        public OpenVirtualProcessResult OpenVirtualProcess(ulong moduleBaseAddress, object pDataTarget, ICLRDebuggingLibraryProvider pLibraryProvider, CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion, Guid riidProcess)
        {
            HRESULT hr;
            OpenVirtualProcessResult result;

            if ((hr = TryOpenVirtualProcess(moduleBaseAddress, pDataTarget, pLibraryProvider, pMaxDebuggerSupportedVersion, riidProcess, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryOpenVirtualProcess(ulong moduleBaseAddress, object pDataTarget, ICLRDebuggingLibraryProvider pLibraryProvider, CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion, Guid riidProcess, out OpenVirtualProcessResult result)
        {
            /*HRESULT OpenVirtualProcess(
            [In] ulong moduleBaseAddress,
            [MarshalAs(UnmanagedType.IUnknown), In]
            object pDataTarget,
            [MarshalAs(UnmanagedType.Interface), In]
            ICLRDebuggingLibraryProvider pLibraryProvider,
            [In] ref CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion,
            [In] ref Guid riidProcess,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppProcess,
            [In] [Out] ref CLR_DEBUGGING_VERSION pVersion,
            out CLR_DEBUGGING_PROCESS_FLAGS pdwFlags);*/
            object ppProcess;
            CLR_DEBUGGING_VERSION pVersion = default(CLR_DEBUGGING_VERSION);
            CLR_DEBUGGING_PROCESS_FLAGS pdwFlags;
            HRESULT hr = Raw.OpenVirtualProcess(moduleBaseAddress, pDataTarget, pLibraryProvider, ref pMaxDebuggerSupportedVersion, ref riidProcess, out ppProcess, ref pVersion, out pdwFlags);

            if (hr == HRESULT.S_OK)
                result = new OpenVirtualProcessResult(ppProcess, pVersion, pdwFlags);
            else
                result = default(OpenVirtualProcessResult);

            return hr;
        }

        #endregion
        #region CanUnloadNow

        public void CanUnloadNow(IntPtr hModule)
        {
            HRESULT hr;

            if ((hr = TryCanUnloadNow(hModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCanUnloadNow(IntPtr hModule)
        {
            /*HRESULT CanUnloadNow(IntPtr hModule);*/
            return Raw.CanUnloadNow(hModule);
        }

        #endregion
        #endregion
    }
}
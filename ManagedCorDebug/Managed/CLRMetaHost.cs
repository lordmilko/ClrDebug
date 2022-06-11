using System;
using System.Deployment.Internal.Isolation;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CLRMetaHost : ComObject<ICLRMetaHost>
    {
        public CLRMetaHost(ICLRMetaHost raw) : base(raw)
        {
        }

        #region ICLRMetaHost
        #region GetRuntime

        public void GetRuntime(string pwzVersion, Guid riid)
        {
            HRESULT hr;

            if ((hr = TryGetRuntime(pwzVersion, riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetRuntime(string pwzVersion, Guid riid)
        {
            /*HRESULT GetRuntime([MarshalAs(UnmanagedType.LPWStr), In] string pwzVersion, [In] ref Guid riid, [Out] out object ppRuntime);*/
            object ppRuntime;

            return Raw.GetRuntime(pwzVersion, ref riid, out ppRuntime);
        }

        #endregion
        #region GetVersionFromFile

        public string GetVersionFromFile(string pwzFilePath)
        {
            HRESULT hr;
            string pwzBufferResult;

            if ((hr = TryGetVersionFromFile(pwzFilePath, out pwzBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pwzBufferResult;
        }

        public HRESULT TryGetVersionFromFile(string pwzFilePath, out string pwzBufferResult)
        {
            /*HRESULT GetVersionFromFile([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);*/
            StringBuilder pwzBuffer = null;
            uint pcchBuffer = default(uint);
            HRESULT hr = Raw.GetVersionFromFile(pwzFilePath, pwzBuffer, ref pcchBuffer);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzBuffer = new StringBuilder((int) pcchBuffer);
            hr = Raw.GetVersionFromFile(pwzFilePath, pwzBuffer, ref pcchBuffer);

            if (hr == HRESULT.S_OK)
            {
                pwzBufferResult = pwzBuffer.ToString();

                return hr;
            }

            fail:
            pwzBufferResult = default(string);

            return hr;
        }

        #endregion
        #region EnumerateInstalledRuntimes

        public EnumUnknown EnumerateInstalledRuntimes()
        {
            HRESULT hr;
            EnumUnknown ppEnumeratorResult;

            if ((hr = TryEnumerateInstalledRuntimes(out ppEnumeratorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumeratorResult;
        }

        public HRESULT TryEnumerateInstalledRuntimes(out EnumUnknown ppEnumeratorResult)
        {
            /*HRESULT EnumerateInstalledRuntimes([MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);*/
            IEnumUnknown ppEnumerator;
            HRESULT hr = Raw.EnumerateInstalledRuntimes(out ppEnumerator);

            if (hr == HRESULT.S_OK)
                ppEnumeratorResult = new EnumUnknown(ppEnumerator);
            else
                ppEnumeratorResult = default(EnumUnknown);

            return hr;
        }

        #endregion
        #region EnumerateLoadedRuntimes

        public EnumUnknown EnumerateLoadedRuntimes(IntPtr hndProcess)
        {
            HRESULT hr;
            EnumUnknown ppEnumeratorResult;

            if ((hr = TryEnumerateLoadedRuntimes(hndProcess, out ppEnumeratorResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEnumeratorResult;
        }

        public HRESULT TryEnumerateLoadedRuntimes(IntPtr hndProcess, out EnumUnknown ppEnumeratorResult)
        {
            /*HRESULT EnumerateLoadedRuntimes([In] IntPtr hndProcess, [MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);*/
            IEnumUnknown ppEnumerator;
            HRESULT hr = Raw.EnumerateLoadedRuntimes(hndProcess, out ppEnumerator);

            if (hr == HRESULT.S_OK)
                ppEnumeratorResult = new EnumUnknown(ppEnumerator);
            else
                ppEnumeratorResult = default(EnumUnknown);

            return hr;
        }

        #endregion
        #region RequestRuntimeLoadedNotification

        public void RequestRuntimeLoadedNotification(RuntimeLoadedCallback pCallbackFunction)
        {
            HRESULT hr;

            if ((hr = TryRequestRuntimeLoadedNotification(pCallbackFunction)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryRequestRuntimeLoadedNotification(RuntimeLoadedCallback pCallbackFunction)
        {
            /*HRESULT RequestRuntimeLoadedNotification([MarshalAs(UnmanagedType.FunctionPtr), In]
            RuntimeLoadedCallback pCallbackFunction);*/
            return Raw.RequestRuntimeLoadedNotification(pCallbackFunction);
        }

        #endregion
        #region QueryLegacyV2RuntimeBinding

        public void QueryLegacyV2RuntimeBinding(Guid riid)
        {
            HRESULT hr;

            if ((hr = TryQueryLegacyV2RuntimeBinding(riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryQueryLegacyV2RuntimeBinding(Guid riid)
        {
            /*HRESULT QueryLegacyV2RuntimeBinding(
            [In] ref Guid riid,
            [Out] IntPtr ppUnk);*/
            IntPtr ppUnk = default(IntPtr);

            return Raw.QueryLegacyV2RuntimeBinding(ref riid, ppUnk);
        }

        #endregion
        #region ExitProcess

        public void ExitProcess(int iExitCode)
        {
            HRESULT hr;

            if ((hr = TryExitProcess(iExitCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExitProcess(int iExitCode)
        {
            /*HRESULT ExitProcess([In] int iExitCode);*/
            return Raw.ExitProcess(iExitCode);
        }

        #endregion
        #endregion
    }
}
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CLRRuntimeInfo : ComObject<ICLRRuntimeInfo>
    {
        public CLRRuntimeInfo(ICLRRuntimeInfo raw) : base(raw)
        {
        }

        #region ICLRRuntimeInfo
        #region GetVersionString

        public string VersionString
        {
            get
            {
                HRESULT hr;
                string pwzBufferResult;

                if ((hr = TryGetVersionString(out pwzBufferResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pwzBufferResult;
            }
        }

        public HRESULT TryGetVersionString(out string pwzBufferResult)
        {
            /*HRESULT GetVersionString([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);*/
            StringBuilder pwzBuffer = null;
            uint pcchBuffer = default(uint);
            HRESULT hr = Raw.GetVersionString(pwzBuffer, ref pcchBuffer);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzBuffer = new StringBuilder((int) pcchBuffer);
            hr = Raw.GetVersionString(pwzBuffer, ref pcchBuffer);

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
        #region GetRuntimeDirectory

        public string RuntimeDirectory
        {
            get
            {
                HRESULT hr;
                string pwzBufferResult;

                if ((hr = TryGetRuntimeDirectory(out pwzBufferResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pwzBufferResult;
            }
        }

        public HRESULT TryGetRuntimeDirectory(out string pwzBufferResult)
        {
            /*HRESULT GetRuntimeDirectory([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);*/
            StringBuilder pwzBuffer = null;
            uint pcchBuffer = default(uint);
            HRESULT hr = Raw.GetRuntimeDirectory(pwzBuffer, ref pcchBuffer);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzBuffer = new StringBuilder((int) pcchBuffer);
            hr = Raw.GetRuntimeDirectory(pwzBuffer, ref pcchBuffer);

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
        #region IsLoadable

        public int IsLoadable
        {
            get
            {
                HRESULT hr;
                int pbLoadable;

                if ((hr = TryIsLoadable(out pbLoadable)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbLoadable;
            }
        }

        public HRESULT TryIsLoadable(out int pbLoadable)
        {
            /*HRESULT IsLoadable(
            [Out] out int pbLoadable);*/
            return Raw.IsLoadable(out pbLoadable);
        }

        #endregion
        #region IsStarted

        public IsStartedResult IsStarted
        {
            get
            {
                HRESULT hr;
                IsStartedResult result;

                if ((hr = TryIsStarted(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryIsStarted(out IsStartedResult result)
        {
            /*HRESULT IsStarted(out int pbStarted, out uint pdwStartupFlags);*/
            int pbStarted;
            uint pdwStartupFlags;
            HRESULT hr = Raw.IsStarted(out pbStarted, out pdwStartupFlags);

            if (hr == HRESULT.S_OK)
                result = new IsStartedResult(pbStarted, pdwStartupFlags);
            else
                result = default(IsStartedResult);

            return hr;
        }

        #endregion
        #region IsLoaded

        public int IsLoaded(IntPtr hndProcess)
        {
            HRESULT hr;
            int pbLoaded;

            if ((hr = TryIsLoaded(hndProcess, out pbLoaded)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbLoaded;
        }

        public HRESULT TryIsLoaded(IntPtr hndProcess, out int pbLoaded)
        {
            /*HRESULT IsLoaded(
            [In] IntPtr hndProcess,
            [Out] out int pbLoaded);*/
            return Raw.IsLoaded(hndProcess, out pbLoaded);
        }

        #endregion
        #region LoadErrorString

        public string LoadErrorString(HRESULT iResourceID, int iLocaleID)
        {
            HRESULT hr;
            string pwzBufferResult;

            if ((hr = TryLoadErrorString(iResourceID, iLocaleID, out pwzBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pwzBufferResult;
        }

        public HRESULT TryLoadErrorString(HRESULT iResourceID, int iLocaleID, out string pwzBufferResult)
        {
            /*HRESULT LoadErrorString(
            [In] HRESULT iResourceID,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pwzBuffer,
            [In, Out] ref uint pcchBuffer,
            [In] int iLocaleID);*/
            StringBuilder pwzBuffer = null;
            uint pcchBuffer = default(uint);
            HRESULT hr = Raw.LoadErrorString(iResourceID, pwzBuffer, ref pcchBuffer, iLocaleID);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzBuffer = new StringBuilder((int) pcchBuffer);
            hr = Raw.LoadErrorString(iResourceID, pwzBuffer, ref pcchBuffer, iLocaleID);

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
        #region LoadLibrary

        public IntPtr LoadLibrary(string pwzDllName)
        {
            HRESULT hr;
            IntPtr phndModule = default(IntPtr);

            if ((hr = TryLoadLibrary(pwzDllName, ref phndModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return phndModule;
        }

        public HRESULT TryLoadLibrary(string pwzDllName, ref IntPtr phndModule)
        {
            /*HRESULT LoadLibrary(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzDllName,
            [Out] IntPtr phndModule);*/
            return Raw.LoadLibrary(pwzDllName, phndModule);
        }

        #endregion
        #region GetProcAddress

        public IntPtr GetProcAddress(string pszProcName)
        {
            HRESULT hr;
            IntPtr ppProc = default(IntPtr);

            if ((hr = TryGetProcAddress(pszProcName, ref ppProc)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProc;
        }

        public HRESULT TryGetProcAddress(string pszProcName, ref IntPtr ppProc)
        {
            /*HRESULT GetProcAddress(
            [MarshalAs(UnmanagedType.LPStr), In] string pszProcName,
            [Out] IntPtr ppProc);*/
            return Raw.GetProcAddress(pszProcName, ppProc);
        }

        #endregion
        #region GetInterface

        public void GetInterface(Guid rclsid, Guid riid)
        {
            HRESULT hr;

            if ((hr = TryGetInterface(rclsid, riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetInterface(Guid rclsid, Guid riid)
        {
            /*HRESULT GetInterface(
            [In] ref Guid rclsid,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppUnk);*/
            object ppUnk;

            return Raw.GetInterface(ref rclsid, ref riid, out ppUnk);
        }

        #endregion
        #region SetDefaultStartupFlags

        public void SetDefaultStartupFlags(uint dwStartupFlags, string pwzHostConfigFile)
        {
            HRESULT hr;

            if ((hr = TrySetDefaultStartupFlags(dwStartupFlags, pwzHostConfigFile)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetDefaultStartupFlags(uint dwStartupFlags, string pwzHostConfigFile)
        {
            /*HRESULT SetDefaultStartupFlags([In] uint dwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzHostConfigFile);*/
            return Raw.SetDefaultStartupFlags(dwStartupFlags, pwzHostConfigFile);
        }

        #endregion
        #region GetDefaultStartupFlags

        public GetDefaultStartupFlagsResult GetDefaultStartupFlags()
        {
            HRESULT hr;
            GetDefaultStartupFlagsResult result;

            if ((hr = TryGetDefaultStartupFlags(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetDefaultStartupFlags(out GetDefaultStartupFlagsResult result)
        {
            /*HRESULT GetDefaultStartupFlags(
            out uint pdwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzHostConfigFile,
            [In] [Out] ref uint pcchHostConfigFile);*/
            uint pdwStartupFlags;
            StringBuilder pwzHostConfigFile = null;
            uint pcchHostConfigFile = default(uint);
            HRESULT hr = Raw.GetDefaultStartupFlags(out pdwStartupFlags, pwzHostConfigFile, ref pcchHostConfigFile);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzHostConfigFile = new StringBuilder((int) pcchHostConfigFile);
            hr = Raw.GetDefaultStartupFlags(out pdwStartupFlags, pwzHostConfigFile, ref pcchHostConfigFile);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDefaultStartupFlagsResult(pdwStartupFlags, pwzHostConfigFile.ToString());

                return hr;
            }

            fail:
            result = default(GetDefaultStartupFlagsResult);

            return hr;
        }

        #endregion
        #region BindAsLegacyV2Runtime

        public void BindAsLegacyV2Runtime()
        {
            HRESULT hr;

            if ((hr = TryBindAsLegacyV2Runtime()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBindAsLegacyV2Runtime()
        {
            /*HRESULT BindAsLegacyV2Runtime();*/
            return Raw.BindAsLegacyV2Runtime();
        }

        #endregion
        #endregion
    }
}
using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRRuntimeHost : ComObject<ICLRRuntimeHost>
    {
        public CLRRuntimeHost(ICLRRuntimeHost raw) : base(raw)
        {
        }

        #region ICLRRuntimeHost
        #region GetCLRControl

        public CLRControl CLRControl
        {
            get
            {
                HRESULT hr;
                CLRControl pCLRControlResult;

                if ((hr = TryGetCLRControl(out pCLRControlResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pCLRControlResult;
            }
        }

        public HRESULT TryGetCLRControl(out CLRControl pCLRControlResult)
        {
            /*HRESULT GetCLRControl([MarshalAs(UnmanagedType.Interface)] out ICLRControl pCLRControl);*/
            ICLRControl pCLRControl;
            HRESULT hr = Raw.GetCLRControl(out pCLRControl);

            if (hr == HRESULT.S_OK)
                pCLRControlResult = new CLRControl(pCLRControl);
            else
                pCLRControlResult = default(CLRControl);

            return hr;
        }

        #endregion
        #region GetCurrentAppDomainId

        public uint CurrentAppDomainId
        {
            get
            {
                HRESULT hr;
                uint pdwAppDomainId;

                if ((hr = TryGetCurrentAppDomainId(out pdwAppDomainId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwAppDomainId;
            }
        }

        public HRESULT TryGetCurrentAppDomainId(out uint pdwAppDomainId)
        {
            /*HRESULT GetCurrentAppDomainId(out uint pdwAppDomainId);*/
            return Raw.GetCurrentAppDomainId(out pdwAppDomainId);
        }

        #endregion
        #region Start

        public void Start()
        {
            HRESULT hr;

            if ((hr = TryStart()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStart()
        {
            /*HRESULT Start();*/
            return Raw.Start();
        }

        #endregion
        #region Stop

        public void Stop()
        {
            HRESULT hr;

            if ((hr = TryStop()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStop()
        {
            /*HRESULT Stop();*/
            return Raw.Stop();
        }

        #endregion
        #region SetHostControl

        public void SetHostControl(IHostControl pHostControl)
        {
            HRESULT hr;

            if ((hr = TrySetHostControl(pHostControl)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetHostControl(IHostControl pHostControl)
        {
            /*HRESULT SetHostControl([MarshalAs(UnmanagedType.Interface)] [In] IHostControl pHostControl);*/
            return Raw.SetHostControl(pHostControl);
        }

        #endregion
        #region UnloadAppDomain

        public void UnloadAppDomain(uint dwAppDomainID, int fWaitUntilDone)
        {
            HRESULT hr;

            if ((hr = TryUnloadAppDomain(dwAppDomainID, fWaitUntilDone)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUnloadAppDomain(uint dwAppDomainID, int fWaitUntilDone)
        {
            /*HRESULT UnloadAppDomain([In] uint dwAppDomainID, [In] int fWaitUntilDone);*/
            return Raw.UnloadAppDomain(dwAppDomainID, fWaitUntilDone);
        }

        #endregion
        #region ExecuteInAppDomain

        public void ExecuteInAppDomain(uint dwAppDomainID, FExecuteInAppDomainCallback pCallback, IntPtr cookie)
        {
            HRESULT hr;

            if ((hr = TryExecuteInAppDomain(dwAppDomainID, pCallback, cookie)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExecuteInAppDomain(uint dwAppDomainID, FExecuteInAppDomainCallback pCallback, IntPtr cookie)
        {
            /*HRESULT ExecuteInAppDomain(
            [In] uint dwAppDomainID,
            [MarshalAs(UnmanagedType.FunctionPtr)] [In] FExecuteInAppDomainCallback pCallback,
            [In] IntPtr cookie);*/
            return Raw.ExecuteInAppDomain(dwAppDomainID, pCallback, cookie);
        }

        #endregion
        #region ExecuteApplication

        public void ExecuteApplication(string pwzAppFullName, uint dwManifestPaths, string ppwzManifestPaths, uint dwActivationData, string ppwzActivationData)
        {
            HRESULT hr;

            if ((hr = TryExecuteApplication(pwzAppFullName, dwManifestPaths, ppwzManifestPaths, dwActivationData, ppwzActivationData)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExecuteApplication(string pwzAppFullName, uint dwManifestPaths, string ppwzManifestPaths, uint dwActivationData, string ppwzActivationData)
        {
            /*HRESULT ExecuteApplication(
            [MarshalAs(UnmanagedType.LPWStr)] [In] string pwzAppFullName,
            [In] uint dwManifestPaths,
            [MarshalAs(UnmanagedType.LPWStr)] [In] ref string ppwzManifestPaths,
            [In] uint dwActivationData,
            [MarshalAs(UnmanagedType.LPWStr)] [In] ref string ppwzActivationData,
            out int pReturnValue);*/
            int pReturnValue;

            return Raw.ExecuteApplication(pwzAppFullName, dwManifestPaths, ref ppwzManifestPaths, dwActivationData, ref ppwzActivationData, out pReturnValue);
        }

        #endregion
        #region ExecuteInDefaultAppDomain

        public uint ExecuteInDefaultAppDomain(string pwzAssemblyPath, string pwzTypeName, string pwzMethodName, string pwzArgument)
        {
            HRESULT hr;
            uint pReturnValue;

            if ((hr = TryExecuteInDefaultAppDomain(pwzAssemblyPath, pwzTypeName, pwzMethodName, pwzArgument, out pReturnValue)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pReturnValue;
        }

        public HRESULT TryExecuteInDefaultAppDomain(string pwzAssemblyPath, string pwzTypeName, string pwzMethodName, string pwzArgument, out uint pReturnValue)
        {
            /*HRESULT ExecuteInDefaultAppDomain(
            [MarshalAs(UnmanagedType.LPWStr)] [In] string pwzAssemblyPath,
            [MarshalAs(UnmanagedType.LPWStr)] [In] string pwzTypeName,
            [MarshalAs(UnmanagedType.LPWStr)] [In] string pwzMethodName,
            [MarshalAs(UnmanagedType.LPWStr)] [In] string pwzArgument, out uint pReturnValue);*/
            return Raw.ExecuteInDefaultAppDomain(pwzAssemblyPath, pwzTypeName, pwzMethodName, pwzArgument, out pReturnValue);
        }

        #endregion
        #endregion
    }
}
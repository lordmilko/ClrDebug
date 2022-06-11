using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorRuntimeHost : ComObject<ICorRuntimeHost>
    {
        public CorRuntimeHost(ICorRuntimeHost raw) : base(raw)
        {
        }

        #region ICorRuntimeHost
        #region GetConfiguration

        public object Configuration
        {
            get
            {
                HRESULT hr;
                object pConfiguration;

                if ((hr = TryGetConfiguration(out pConfiguration)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pConfiguration;
            }
        }

        public HRESULT TryGetConfiguration(out object pConfiguration)
        {
            /*HRESULT GetConfiguration([MarshalAs(UnmanagedType.IUnknown)] out object pConfiguration);*/
            return Raw.GetConfiguration(out pConfiguration);
        }

        #endregion
        #region GetDefaultDomain

        public object DefaultDomain
        {
            get
            {
                HRESULT hr;
                object pAppDomain;

                if ((hr = TryGetDefaultDomain(out pAppDomain)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAppDomain;
            }
        }

        public HRESULT TryGetDefaultDomain(out object pAppDomain)
        {
            /*HRESULT GetDefaultDomain([Out, MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.GetDefaultDomain(out pAppDomain);
        }

        #endregion
        #region CreateLogicalThreadState

        public void CreateLogicalThreadState()
        {
            HRESULT hr;

            if ((hr = TryCreateLogicalThreadState()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCreateLogicalThreadState()
        {
            /*HRESULT CreateLogicalThreadState();*/
            return Raw.CreateLogicalThreadState();
        }

        #endregion
        #region DeleteLogicalThreadState

        public void DeleteLogicalThreadState()
        {
            HRESULT hr;

            if ((hr = TryDeleteLogicalThreadState()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDeleteLogicalThreadState()
        {
            /*HRESULT DeleteLogicalThreadState();*/
            return Raw.DeleteLogicalThreadState();
        }

        #endregion
        #region SwitchInLogicalThreadState

        public void SwitchInLogicalThreadState(uint pFiberCookie)
        {
            HRESULT hr;

            if ((hr = TrySwitchInLogicalThreadState(pFiberCookie)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySwitchInLogicalThreadState(uint pFiberCookie)
        {
            /*HRESULT SwitchInLogicalThreadState([In] ref uint pFiberCookie);*/
            return Raw.SwitchInLogicalThreadState(ref pFiberCookie);
        }

        #endregion
        #region SwitchOutLogicalThreadState

        public uint SwitchOutLogicalThreadState()
        {
            HRESULT hr;
            uint fiberCookie;

            if ((hr = TrySwitchOutLogicalThreadState(out fiberCookie)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return fiberCookie;
        }

        public HRESULT TrySwitchOutLogicalThreadState(out uint fiberCookie)
        {
            /*HRESULT SwitchOutLogicalThreadState(out uint FiberCookie);*/
            return Raw.SwitchOutLogicalThreadState(out fiberCookie);
        }

        #endregion
        #region LocksHeldByLogicalThread

        public uint LocksHeldByLogicalThread()
        {
            HRESULT hr;
            uint pCount;

            if ((hr = TryLocksHeldByLogicalThread(out pCount)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pCount;
        }

        public HRESULT TryLocksHeldByLogicalThread(out uint pCount)
        {
            /*HRESULT LocksHeldByLogicalThread(out uint pCount);*/
            return Raw.LocksHeldByLogicalThread(out pCount);
        }

        #endregion
        #region MapFile

        [Obsolete]
        public IntPtr MapFile(IntPtr hFile)
        {
            HRESULT hr;
            IntPtr hMapAddress;

            if ((hr = TryMapFile(hFile, out hMapAddress)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hMapAddress;
        }

        [Obsolete]
        public HRESULT TryMapFile(IntPtr hFile, out IntPtr hMapAddress)
        {
            /*HRESULT MapFile(IntPtr hFile, out IntPtr hMapAddress);*/
            return Raw.MapFile(hFile, out hMapAddress);
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
        #region CreateDomain

        public object CreateDomain(string pwzFriendlyName, object pIdentityArray)
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryCreateDomain(pwzFriendlyName, pIdentityArray, out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        public HRESULT TryCreateDomain(string pwzFriendlyName, object pIdentityArray, out object pAppDomain)
        {
            /*HRESULT CreateDomain(string pwzFriendlyName, [MarshalAs(UnmanagedType.IUnknown)] object pIdentityArray, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.CreateDomain(pwzFriendlyName, pIdentityArray, out pAppDomain);
        }

        #endregion
        #region EnumDomains

        public IntPtr EnumDomains()
        {
            HRESULT hr;
            IntPtr hEnum;

            if ((hr = TryEnumDomains(out hEnum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return hEnum;
        }

        public HRESULT TryEnumDomains(out IntPtr hEnum)
        {
            /*HRESULT EnumDomains(out IntPtr hEnum);*/
            return Raw.EnumDomains(out hEnum);
        }

        #endregion
        #region NextDomain

        public object NextDomain(IntPtr hEnum)
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryNextDomain(hEnum, out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        public HRESULT TryNextDomain(IntPtr hEnum, out object pAppDomain)
        {
            /*HRESULT NextDomain(IntPtr hEnum, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.NextDomain(hEnum, out pAppDomain);
        }

        #endregion
        #region CloseEnum

        public void CloseEnum(IntPtr hEnum)
        {
            HRESULT hr;

            if ((hr = TryCloseEnum(hEnum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseEnum(IntPtr hEnum)
        {
            /*HRESULT CloseEnum(IntPtr hEnum);*/
            return Raw.CloseEnum(hEnum);
        }

        #endregion
        #region CreateDomainEx

        public object CreateDomainEx(string pwzFriendlyName, object pSetup, object pEvidence)
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryCreateDomainEx(pwzFriendlyName, pSetup, pEvidence, out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        public HRESULT TryCreateDomainEx(string pwzFriendlyName, object pSetup, object pEvidence, out object pAppDomain)
        {
            /*HRESULT CreateDomainEx(
            [In] string pwzFriendlyName,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pSetup,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pEvidence,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.CreateDomainEx(pwzFriendlyName, pSetup, pEvidence, out pAppDomain);
        }

        #endregion
        #region CreateDomainSetup

        public object CreateDomainSetup()
        {
            HRESULT hr;
            object pAppDomainSetup;

            if ((hr = TryCreateDomainSetup(out pAppDomainSetup)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomainSetup;
        }

        public HRESULT TryCreateDomainSetup(out object pAppDomainSetup)
        {
            /*HRESULT CreateDomainSetup([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomainSetup);*/
            return Raw.CreateDomainSetup(out pAppDomainSetup);
        }

        #endregion
        #region CreateEvidence

        public object CreateEvidence()
        {
            HRESULT hr;
            object pEvidence;

            if ((hr = TryCreateEvidence(out pEvidence)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pEvidence;
        }

        public HRESULT TryCreateEvidence(out object pEvidence)
        {
            /*HRESULT CreateEvidence([MarshalAs(UnmanagedType.IUnknown)] out object pEvidence);*/
            return Raw.CreateEvidence(out pEvidence);
        }

        #endregion
        #region UnloadDomain

        public void UnloadDomain(object pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryUnloadDomain(pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUnloadDomain(object pAppDomain)
        {
            /*HRESULT UnloadDomain([MarshalAs(UnmanagedType.IUnknown)] object pAppDomain);*/
            return Raw.UnloadDomain(pAppDomain);
        }

        #endregion
        #region CurrentDomain

        public object CurrentDomain()
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryCurrentDomain(out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        public HRESULT TryCurrentDomain(out object pAppDomain)
        {
            /*HRESULT CurrentDomain([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.CurrentDomain(out pAppDomain);
        }

        #endregion
        #endregion
    }
}
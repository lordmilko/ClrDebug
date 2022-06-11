using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugAssembly : ComObject<ICorDebugAssembly>
    {
        public CorDebugAssembly(ICorDebugAssembly raw) : base(raw)
        {
        }

        #region ICorDebugAssembly
        #region GetProcess

        public CorDebugProcess Process
        {
            get
            {
                HRESULT hr;
                CorDebugProcess ppProcessResult;

                if ((hr = TryGetProcess(out ppProcessResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppProcessResult;
            }
        }

        public HRESULT TryGetProcess(out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region GetAppDomain

        public CorDebugAppDomain AppDomain
        {
            get
            {
                HRESULT hr;
                CorDebugAppDomain ppAppDomainResult;

                if ((hr = TryGetAppDomain(out ppAppDomainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppAppDomainResult;
            }
        }

        public HRESULT TryGetAppDomain(out CorDebugAppDomain ppAppDomainResult)
        {
            /*HRESULT GetAppDomain([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomain ppAppDomain);*/
            ICorDebugAppDomain ppAppDomain;
            HRESULT hr = Raw.GetAppDomain(out ppAppDomain);

            if (hr == HRESULT.S_OK)
                ppAppDomainResult = new CorDebugAppDomain(ppAppDomain);
            else
                ppAppDomainResult = default(CorDebugAppDomain);

            return hr;
        }

        #endregion
        #region EnumerateModules

        public CorDebugModuleEnum EnumerateModules()
        {
            HRESULT hr;
            CorDebugModuleEnum ppModulesResult;

            if ((hr = TryEnumerateModules(out ppModulesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppModulesResult;
        }

        public HRESULT TryEnumerateModules(out CorDebugModuleEnum ppModulesResult)
        {
            /*HRESULT EnumerateModules([MarshalAs(UnmanagedType.Interface)] out ICorDebugModuleEnum ppModules);*/
            ICorDebugModuleEnum ppModules;
            HRESULT hr = Raw.EnumerateModules(out ppModules);

            if (hr == HRESULT.S_OK)
                ppModulesResult = new CorDebugModuleEnum(ppModules);
            else
                ppModulesResult = default(CorDebugModuleEnum);

            return hr;
        }

        #endregion
        #region GetCodeBase

        public string GetCodeBase()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetCodeBase(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetCodeBase(out string szNameResult)
        {
            /*HRESULT GetCodeBase([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetCodeBase(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetCodeBase(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetName

        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugAssembly2

        public ICorDebugAssembly2 Raw2 => (ICorDebugAssembly2) Raw;

        #region IsFullyTrusted

        public int IsFullyTrusted
        {
            get
            {
                HRESULT hr;
                int pbFullyTrusted;

                if ((hr = TryIsFullyTrusted(out pbFullyTrusted)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbFullyTrusted;
            }
        }

        public HRESULT TryIsFullyTrusted(out int pbFullyTrusted)
        {
            /*HRESULT IsFullyTrusted(out int pbFullyTrusted);*/
            return Raw2.IsFullyTrusted(out pbFullyTrusted);
        }

        #endregion
        #endregion
        #region ICorDebugAssembly3

        public ICorDebugAssembly3 Raw3 => (ICorDebugAssembly3) Raw;

        #region GetContainerAssembly

        public CorDebugAssembly ContainerAssembly
        {
            get
            {
                HRESULT hr;
                CorDebugAssembly ppAssemblyResult;

                if ((hr = TryGetContainerAssembly(out ppAssemblyResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppAssemblyResult;
            }
        }

        public HRESULT TryGetContainerAssembly(out CorDebugAssembly ppAssemblyResult)
        {
            /*HRESULT GetContainerAssembly([MarshalAs(UnmanagedType.Interface)] ref ICorDebugAssembly ppAssembly);*/
            ICorDebugAssembly ppAssembly = default(ICorDebugAssembly);
            HRESULT hr = Raw3.GetContainerAssembly(ref ppAssembly);

            if (hr == HRESULT.S_OK)
                ppAssemblyResult = new CorDebugAssembly(ppAssembly);
            else
                ppAssemblyResult = default(CorDebugAssembly);

            return hr;
        }

        #endregion
        #region EnumerateContainedAssemblies

        public CorDebugAssemblyEnum EnumerateContainedAssemblies()
        {
            HRESULT hr;
            CorDebugAssemblyEnum ppAssembliesResult;

            if ((hr = TryEnumerateContainedAssemblies(out ppAssembliesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppAssembliesResult;
        }

        public HRESULT TryEnumerateContainedAssemblies(out CorDebugAssemblyEnum ppAssembliesResult)
        {
            /*HRESULT EnumerateContainedAssemblies([MarshalAs(UnmanagedType.Interface)] ref ICorDebugAssemblyEnum ppAssemblies);*/
            ICorDebugAssemblyEnum ppAssemblies = default(ICorDebugAssemblyEnum);
            HRESULT hr = Raw3.EnumerateContainedAssemblies(ref ppAssemblies);

            if (hr == HRESULT.S_OK)
                ppAssembliesResult = new CorDebugAssemblyEnum(ppAssemblies);
            else
                ppAssembliesResult = default(CorDebugAssemblyEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}
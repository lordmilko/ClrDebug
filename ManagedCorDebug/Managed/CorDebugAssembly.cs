using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents an assembly.
    /// </summary>
    public class CorDebugAssembly : ComObject<ICorDebugAssembly>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugAssembly"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugAssembly(ICorDebugAssembly raw) : base(raw)
        {
        }

        #region ICorDebugAssembly
        #region Process

        /// <summary>
        /// Gets an interface pointer to the process in which this <see cref="ICorDebugAssembly"/> instance is running.
        /// </summary>
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

        /// <summary>
        /// Gets an interface pointer to the process in which this <see cref="ICorDebugAssembly"/> instance is running.
        /// </summary>
        /// <param name="ppProcessResult">[out] A pointer to an <see cref="ICorDebugProcess"/> interface that represents the process.</param>
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
        #region AppDomain

        /// <summary>
        /// Gets an interface pointer to the application domain that contains this <see cref="ICorDebugAssembly"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets an interface pointer to the application domain that contains this <see cref="ICorDebugAssembly"/> instance.
        /// </summary>
        /// <param name="ppAppDomainResult">[out] A pointer to the address of an <see cref="ICorDebugAppDomain"/> interface that represents the application domain.</param>
        /// <remarks>
        /// If this assembly is the system assembly, GetAppDomain returns null.
        /// </remarks>
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

        /// <summary>
        /// Gets an enumerator for the modules contained in the <see cref="ICorDebugAssembly"/>.
        /// </summary>
        /// <returns>[out] A pointer to the address of the <see cref="ICorDebugModuleEnum"/> interface that is the enumerator.</returns>
        public CorDebugModuleEnum EnumerateModules()
        {
            HRESULT hr;
            CorDebugModuleEnum ppModulesResult;

            if ((hr = TryEnumerateModules(out ppModulesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppModulesResult;
        }

        /// <summary>
        /// Gets an enumerator for the modules contained in the <see cref="ICorDebugAssembly"/>.
        /// </summary>
        /// <param name="ppModulesResult">[out] A pointer to the address of the <see cref="ICorDebugModuleEnum"/> interface that is the enumerator.</param>
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

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        public string GetCodeBase()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetCodeBase(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        public HRESULT TryGetCodeBase(out string szNameResult)
        {
            /*HRESULT GetCodeBase([In] int cchName, out int pcchName, [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetCodeBase(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
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

        /// <summary>
        /// Gets the name of the assembly that this <see cref="ICorDebugAssembly"/> instance represents.
        /// </summary>
        /// <returns>[out] An array that stores the name.</returns>
        /// <remarks>
        /// The GetName method returns the full path and file name of the assembly.
        /// </remarks>
        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of the assembly that this <see cref="ICorDebugAssembly"/> instance represents.
        /// </summary>
        /// <param name="szNameResult">[out] An array that stores the name.</param>
        /// <remarks>
        /// The GetName method returns the full path and file name of the assembly.
        /// </remarks>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, out int pcchName, [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugAssembly2 Raw2 => (ICorDebugAssembly2) Raw;

        #region IsFullyTrusted

        /// <summary>
        /// Gets a value that indicates whether the assembly has been granted full trust by the runtime security system.
        /// </summary>
        public bool IsFullyTrusted
        {
            get
            {
                HRESULT hr;
                bool pbFullyTrustedResult;

                if ((hr = TryIsFullyTrusted(out pbFullyTrustedResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbFullyTrustedResult;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the assembly has been granted full trust by the runtime security system.
        /// </summary>
        /// <param name="pbFullyTrustedResult">[out] true if the assembly has been granted full trust by the runtime security system; otherwise, false.</param>
        /// <remarks>
        /// This method returns an <see cref="HRESULT"/> of CORDBG_E_NOTREADY if the security policy for the assembly has not yet been resolved,
        /// that is, if no code in the assembly has been run yet.
        /// </remarks>
        public HRESULT TryIsFullyTrusted(out bool pbFullyTrustedResult)
        {
            /*HRESULT IsFullyTrusted(out int pbFullyTrusted);*/
            int pbFullyTrusted;
            HRESULT hr = Raw2.IsFullyTrusted(out pbFullyTrusted);

            if (hr == HRESULT.S_OK)
                pbFullyTrustedResult = pbFullyTrusted == 1;
            else
                pbFullyTrustedResult = default(bool);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugAssembly3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugAssembly3 Raw3 => (ICorDebugAssembly3) Raw;

        #region ContainerAssembly

        /// <summary>
        /// Returns the container assembly of this <see cref="ICorDebugAssembly3"/> object.
        /// </summary>
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

        /// <summary>
        /// Returns the container assembly of this <see cref="ICorDebugAssembly3"/> object.
        /// </summary>
        /// <param name="ppAssemblyResult">A pointer to the address of an <see cref="ICorDebugAssembly"/> object that represents the container assembly, or null if the method call fails.</param>
        /// <returns>S_OK if the method call succeeds; otherwise, S_FALSE, and ppAssembly is null.</returns>
        /// <remarks>
        /// If this assembly has been merged with others inside a single container assembly, this method returns the container
        /// assembly. For more information and terminology, see the <see cref="CorDebugProcess.EnableVirtualModuleSplitting"/>
        /// topic.
        /// </remarks>
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

        /// <summary>
        /// Gets an enumerator for the assemblies contained in this assembly.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugAssemblyEnum"/> interface object that is the enumerator.</returns>
        /// <remarks>
        /// Symbols are needed to enumerate the contained assemblies. If they aren't present, the method returns S_FALSE, and
        /// no valid enumerator is provided.
        /// </remarks>
        public CorDebugAssemblyEnum EnumerateContainedAssemblies()
        {
            HRESULT hr;
            CorDebugAssemblyEnum ppAssembliesResult;

            if ((hr = TryEnumerateContainedAssemblies(out ppAssembliesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppAssembliesResult;
        }

        /// <summary>
        /// Gets an enumerator for the assemblies contained in this assembly.
        /// </summary>
        /// <param name="ppAssembliesResult">[out] A pointer to the address of an <see cref="ICorDebugAssemblyEnum"/> interface object that is the enumerator.</param>
        /// <returns>S_OK if this <see cref="ICorDebugAssembly3"/> object is a container; otherwise, S_FALSE, and the enumeration is empty.</returns>
        /// <remarks>
        /// Symbols are needed to enumerate the contained assemblies. If they aren't present, the method returns S_FALSE, and
        /// no valid enumerator is provided.
        /// </remarks>
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
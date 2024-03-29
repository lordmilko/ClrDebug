﻿using System;
using System.Security.Principal;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that enable the host to start and stop the common language runtime (CLR) explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.<para/>
    /// In the .NET Framework version 2.0, this interface is superseded by <see cref="ICLRRuntimeHost"/>.
    /// </summary>
    public class CorRuntimeHost : ComObject<ICorRuntimeHost>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorRuntimeHost"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorRuntimeHost(ICorRuntimeHost raw) : base(raw)
        {
        }

        #region ICorRuntimeHost
        #region Configuration

        /// <summary>
        /// Gets an object that allows the host to specify the callback configuration of the common language runtime (CLR).
        /// </summary>
        public CorConfiguration Configuration
        {
            get
            {
                CorConfiguration pConfigurationResult;
                TryGetConfiguration(out pConfigurationResult).ThrowOnNotOK();

                return pConfigurationResult;
            }
        }

        /// <summary>
        /// Gets an object that allows the host to specify the callback configuration of the common language runtime (CLR).
        /// </summary>
        /// <param name="pConfigurationResult">[out] A pointer to the address of an <see cref="ICorConfiguration"/> object that can be used to configure the CLR.</param>
        /// <remarks>
        /// The CLR must be configured prior to its initialization; otherwise, the GetConfiguration method returns an <see cref="HRESULT"/>
        /// indicating an error.
        /// </remarks>
        public HRESULT TryGetConfiguration(out CorConfiguration pConfigurationResult)
        {
            /*HRESULT GetConfiguration(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorConfiguration pConfiguration);*/
            ICorConfiguration pConfiguration;
            HRESULT hr = Raw.GetConfiguration(out pConfiguration);

            if (hr == HRESULT.S_OK)
                pConfigurationResult = pConfiguration == null ? null : new CorConfiguration(pConfiguration);
            else
                pConfigurationResult = default(CorConfiguration);

            return hr;
        }

        #endregion
        #region DefaultDomain

        /// <summary>
        /// Gets an interface pointer of type System._AppDomain that represents the default domain for the current process.
        /// </summary>
        public object DefaultDomain
        {
            get
            {
                object pAppDomain;
                TryGetDefaultDomain(out pAppDomain).ThrowOnNotOK();

                return pAppDomain;
            }
        }

        /// <summary>
        /// Gets an interface pointer of type System._AppDomain that represents the default domain for the current process.
        /// </summary>
        /// <param name="pAppDomain">[out] An interface pointer of type System._AppDomain to the <see cref="AppDomain"/> instance that represents the default application domain for the process.<para/>
        /// This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain an interface pointer of type System._AppDomain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryGetDefaultDomain(out object pAppDomain)
        {
            /*HRESULT GetDefaultDomain(
            [Out, MarshalAs(UnmanagedType.Interface)] out object pAppDomain);*/
            return Raw.GetDefaultDomain(out pAppDomain);
        }

        #endregion
        #region CreateLogicalThreadState

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public void CreateLogicalThreadState()
        {
            TryCreateLogicalThreadState().ThrowOnNotOK();
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public HRESULT TryCreateLogicalThreadState()
        {
            /*HRESULT CreateLogicalThreadState();*/
            return Raw.CreateLogicalThreadState();
        }

        #endregion
        #region DeleteLogicalThreadState

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public void DeleteLogicalThreadState()
        {
            TryDeleteLogicalThreadState().ThrowOnNotOK();
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public HRESULT TryDeleteLogicalThreadState()
        {
            /*HRESULT DeleteLogicalThreadState();*/
            return Raw.DeleteLogicalThreadState();
        }

        #endregion
        #region SwitchInLogicalThreadState

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="pFiberCookie">[in] Cookie that indicates the fiber to use.</param>
        public void SwitchInLogicalThreadState(int pFiberCookie)
        {
            TrySwitchInLogicalThreadState(pFiberCookie).ThrowOnNotOK();
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="pFiberCookie">[in] Cookie that indicates the fiber to use.</param>
        public HRESULT TrySwitchInLogicalThreadState(int pFiberCookie)
        {
            /*HRESULT SwitchInLogicalThreadState(
            [In] ref int pFiberCookie);*/
            return Raw.SwitchInLogicalThreadState(ref pFiberCookie);
        }

        #endregion
        #region SwitchOutLogicalThreadState

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns>[out] Cookie that indicates the fiber being switched out.</returns>
        public int SwitchOutLogicalThreadState()
        {
            int fiberCookie;
            TrySwitchOutLogicalThreadState(out fiberCookie).ThrowOnNotOK();

            return fiberCookie;
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="fiberCookie">[out] Cookie that indicates the fiber being switched out.</param>
        public HRESULT TrySwitchOutLogicalThreadState(out int fiberCookie)
        {
            /*HRESULT SwitchOutLogicalThreadState(
            [Out] out int FiberCookie);*/
            return Raw.SwitchOutLogicalThreadState(out fiberCookie);
        }

        #endregion
        #region LocksHeldByLogicalThread

        /// <summary>
        /// Retrieves the number of locks that current thread holds. This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns>[out] A pointer to the number of locks that the current thread holds.</returns>
        public int LocksHeldByLogicalThread()
        {
            int pCount;
            TryLocksHeldByLogicalThread(out pCount).ThrowOnNotOK();

            return pCount;
        }

        /// <summary>
        /// Retrieves the number of locks that current thread holds. This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="pCount">[out] A pointer to the number of locks that the current thread holds.</param>
        public HRESULT TryLocksHeldByLogicalThread(out int pCount)
        {
            /*HRESULT LocksHeldByLogicalThread(
            [Out] out int pCount);*/
            return Raw.LocksHeldByLogicalThread(out pCount);
        }

        #endregion
        #region MapFile

        /// <summary>
        /// Maps the specified file into memory. This method is obsolete.
        /// </summary>
        /// <param name="hFile">[in] The handle of the file to be mapped.</param>
        /// <returns>[out] The starting memory address at which to begin mapping the file.</returns>
        [Obsolete]
        public IntPtr MapFile(IntPtr hFile)
        {
            IntPtr hMapAddress;
            TryMapFile(hFile, out hMapAddress).ThrowOnNotOK();

            return hMapAddress;
        }

        /// <summary>
        /// Maps the specified file into memory. This method is obsolete.
        /// </summary>
        /// <param name="hFile">[in] The handle of the file to be mapped.</param>
        /// <param name="hMapAddress">[out] The starting memory address at which to begin mapping the file.</param>
        [Obsolete]
        public HRESULT TryMapFile(IntPtr hFile, out IntPtr hMapAddress)
        {
            /*HRESULT MapFile(
            [In] IntPtr hFile,
            [Out] out IntPtr hMapAddress);*/
            return Raw.MapFile(hFile, out hMapAddress);
        }

        #endregion
        #region Start

        /// <summary>
        /// Starts the common language runtime (CLR).
        /// </summary>
        /// <remarks>
        /// It is typically not necessary to call the Start method, because the CLR starts automatically upon the first request
        /// to run managed code.
        /// </remarks>
        public void Start()
        {
            TryStart().ThrowOnNotOK();
        }

        /// <summary>
        /// Starts the common language runtime (CLR).
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                            |
        /// | ---------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                          |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                      |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                             |
        /// </returns>
        /// <remarks>
        /// It is typically not necessary to call the Start method, because the CLR starts automatically upon the first request
        /// to run managed code.
        /// </remarks>
        public HRESULT TryStart()
        {
            /*HRESULT Start();*/
            return Raw.Start();
        }

        #endregion
        #region Stop

        /// <summary>
        /// Stops the execution of code in the runtime for the current process.
        /// </summary>
        /// <remarks>
        /// It is typically unnecessary to call the Stop method, because the code stops executing when the process exits.
        /// </remarks>
        public void Stop()
        {
            TryStop().ThrowOnNotOK();
        }

        /// <summary>
        /// Stops the execution of code in the runtime for the current process.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// It is typically unnecessary to call the Stop method, because the code stops executing when the process exits.
        /// </remarks>
        public HRESULT TryStop()
        {
            /*HRESULT Stop();*/
            return Raw.Stop();
        }

        #endregion
        #region CreateDomain

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer of type System._AppDomain to an instance of type <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pIdentityArray">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <returns>[out] An interface pointer of type System._AppDomain to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</returns>
        public object CreateDomain(string pwzFriendlyName, object[] pIdentityArray)
        {
            object pAppDomain;
            TryCreateDomain(pwzFriendlyName, pIdentityArray, out pAppDomain).ThrowOnNotOK();

            return pAppDomain;
        }

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer of type System._AppDomain to an instance of type <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pIdentityArray">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <param name="pAppDomain">[out] An interface pointer of type System._AppDomain to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryCreateDomain(string pwzFriendlyName, object[] pIdentityArray, out object pAppDomain)
        {
            /*HRESULT CreateDomain(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwzFriendlyName,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] object[] pIdentityArray,
            [Out, MarshalAs(UnmanagedType.Interface)] out object pAppDomain);*/
            return Raw.CreateDomain(pwzFriendlyName, pIdentityArray, out pAppDomain);
        }

        #endregion
        #region EnumDomains

        /// <summary>
        /// Gets an enumerator for the domains in the current process.
        /// </summary>
        /// <returns>[out] An enumerator for the domains.</returns>
        public IntPtr EnumDomains()
        {
            IntPtr hEnum;
            TryEnumDomains(out hEnum).ThrowOnNotOK();

            return hEnum;
        }

        /// <summary>
        /// Gets an enumerator for the domains in the current process.
        /// </summary>
        /// <param name="hEnum">[out] An enumerator for the domains.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryEnumDomains(out IntPtr hEnum)
        {
            /*HRESULT EnumDomains(
            [Out] out IntPtr hEnum);*/
            return Raw.EnumDomains(out hEnum);
        }

        #endregion
        #region NextDomain

        /// <summary>
        /// Gets an interface pointer to the next domain in the enumeration.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator that was obtained through a call to <see cref="EnumDomains"/>.</param>
        /// <returns>[out] An interface pointer to the System._AppDomain type that represents the next domain in the enumeration, or null, if no more domains exist.</returns>
        public object NextDomain(IntPtr hEnum)
        {
            object pAppDomain;
            TryNextDomain(hEnum, out pAppDomain).ThrowOnNotOK();

            return pAppDomain;
        }

        /// <summary>
        /// Gets an interface pointer to the next domain in the enumeration.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator that was obtained through a call to <see cref="EnumDomains"/>.</param>
        /// <param name="pAppDomain">[out] An interface pointer to the System._AppDomain type that represents the next domain in the enumeration, or null, if no more domains exist.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete, or there are no more domains in the enumeration.                                                                                                                               |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryNextDomain(IntPtr hEnum, out object pAppDomain)
        {
            /*HRESULT NextDomain(
            [In] IntPtr hEnum,
            [Out, MarshalAs(UnmanagedType.Interface)] out object pAppDomain);*/
            return Raw.NextDomain(hEnum, out pAppDomain);
        }

        #endregion
        #region CloseEnum

        /// <summary>
        /// Resets a domain enumerator back to the beginning of the domain list.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator to reset.</param>
        public void CloseEnum(IntPtr hEnum)
        {
            TryCloseEnum(hEnum).ThrowOnNotOK();
        }

        /// <summary>
        /// Resets a domain enumerator back to the beginning of the domain list.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator to reset.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryCloseEnum(IntPtr hEnum)
        {
            /*HRESULT CloseEnum(
            [In] IntPtr hEnum);*/
            return Raw.CloseEnum(hEnum);
        }

        #endregion
        #region CreateDomainEx

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer, of type System._AppDomain, to an instance of type <see cref="AppDomain"/>.<para/>
        /// This method allows the caller to pass an IAppDomainSetup instance to configure additional features of the returned System._AppDomain instance.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pSetup">[in] An optional interface pointer of type IAppDomainSetup, obtained by a call to the <see cref="CreateDomainSetup"/> method.</param>
        /// <param name="pEvidence">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <returns>[out] An interface pointer of type System._AppDomain to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</returns>
        /// <remarks>
        /// CreateDomainEx extends the capabilities of <see cref="CreateDomain"/> by allowing the caller to pass in an IAppDomainSetup
        /// instance with property values for configuring the application domain.
        /// </remarks>
        public object CreateDomainEx(string pwzFriendlyName, object pSetup, object pEvidence)
        {
            object pAppDomain;
            TryCreateDomainEx(pwzFriendlyName, pSetup, pEvidence, out pAppDomain).ThrowOnNotOK();

            return pAppDomain;
        }

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer, of type System._AppDomain, to an instance of type <see cref="AppDomain"/>.<para/>
        /// This method allows the caller to pass an IAppDomainSetup instance to configure additional features of the returned System._AppDomain instance.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pSetup">[in] An optional interface pointer of type IAppDomainSetup, obtained by a call to the <see cref="CreateDomainSetup"/> method.</param>
        /// <param name="pEvidence">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <param name="pAppDomain">[out] An interface pointer of type System._AppDomain to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// CreateDomainEx extends the capabilities of <see cref="CreateDomain"/> by allowing the caller to pass in an IAppDomainSetup
        /// instance with property values for configuring the application domain.
        /// </remarks>
        public HRESULT TryCreateDomainEx(string pwzFriendlyName, object pSetup, object pEvidence, out object pAppDomain)
        {
            /*HRESULT CreateDomainEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwzFriendlyName,
            [In, MarshalAs(UnmanagedType.Interface)] object pSetup,
            [In, MarshalAs(UnmanagedType.Interface)] object pEvidence,
            [Out, MarshalAs(UnmanagedType.Interface)] out object pAppDomain);*/
            return Raw.CreateDomainEx(pwzFriendlyName, pSetup, pEvidence, out pAppDomain);
        }

        #endregion
        #region CreateDomainSetup

        /// <summary>
        /// Gets an interface pointer of type IAppDomainSetup to an System.AppDomainSetup instance. IAppDomainSetup provides methods to configure aspects of an application domain before it is created.
        /// </summary>
        /// <returns>[out] An interface pointer to an System.AppDomainSetup instance. This parameter is typed as IUnknown, so callers should generally call QueryInterface on this pointer to obtain an interface pointer of type IAppDomainSetup.</returns>
        /// <remarks>
        /// The pointer returned from this method is typically passed as a parameter to the <see cref="CreateDomainEx"/> method.
        /// </remarks>
        public object CreateDomainSetup()
        {
            object pAppDomainSetup;
            TryCreateDomainSetup(out pAppDomainSetup).ThrowOnNotOK();

            return pAppDomainSetup;
        }

        /// <summary>
        /// Gets an interface pointer of type IAppDomainSetup to an System.AppDomainSetup instance. IAppDomainSetup provides methods to configure aspects of an application domain before it is created.
        /// </summary>
        /// <param name="pAppDomainSetup">[out] An interface pointer to an System.AppDomainSetup instance. This parameter is typed as IUnknown, so callers should generally call QueryInterface on this pointer to obtain an interface pointer of type IAppDomainSetup.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// The pointer returned from this method is typically passed as a parameter to the <see cref="CreateDomainEx"/> method.
        /// </remarks>
        public HRESULT TryCreateDomainSetup(out object pAppDomainSetup)
        {
            /*HRESULT CreateDomainSetup(
            [Out, MarshalAs(UnmanagedType.Interface)] out object pAppDomainSetup);*/
            return Raw.CreateDomainSetup(out pAppDomainSetup);
        }

        #endregion
        #region CreateEvidence

        /// <summary>
        /// Gets an interface pointer of type <see cref="IIdentity"/>, which allows the host to create security evidence to pass to the <see cref="CreateDomain"/> or <see cref="CreateDomainEx"/> method.
        /// </summary>
        /// <returns>[out] A interface pointer to an <see cref="IIdentity"/> instance used to create security evidence. This pointer is typed IUnknown, so callers should typically call QueryInterface on this interface to obtain a pointer to an <see cref="IIdentity"/>.</returns>
        /// <remarks>
        /// This method returns an empty collection that cannot be populated from native code. You should use the Evidence
        /// method instead.
        /// </remarks>
        public object CreateEvidence()
        {
            object pEvidence;
            TryCreateEvidence(out pEvidence).ThrowOnNotOK();

            return pEvidence;
        }

        /// <summary>
        /// Gets an interface pointer of type <see cref="IIdentity"/>, which allows the host to create security evidence to pass to the <see cref="CreateDomain"/> or <see cref="CreateDomainEx"/> method.
        /// </summary>
        /// <param name="pEvidence">[out] A interface pointer to an <see cref="IIdentity"/> instance used to create security evidence. This pointer is typed IUnknown, so callers should typically call QueryInterface on this interface to obtain a pointer to an <see cref="IIdentity"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        /// <remarks>
        /// This method returns an empty collection that cannot be populated from native code. You should use the Evidence
        /// method instead.
        /// </remarks>
        public HRESULT TryCreateEvidence(out object pEvidence)
        {
            /*HRESULT CreateEvidence(
            [Out, MarshalAs(UnmanagedType.Interface)] out object pEvidence);*/
            return Raw.CreateEvidence(out pEvidence);
        }

        #endregion
        #region UnloadDomain

        /// <summary>
        /// Unloads the specified application domain from the current process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer of type System._AppDomain that represents the domain to be unloaded.</param>
        public void UnloadDomain(object pAppDomain)
        {
            TryUnloadDomain(pAppDomain).ThrowOnNotOK();
        }

        /// <summary>
        /// Unloads the specified application domain from the current process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer of type System._AppDomain that represents the domain to be unloaded.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryUnloadDomain(object pAppDomain)
        {
            /*HRESULT UnloadDomain(
            [In, MarshalAs(UnmanagedType.Interface)] object pAppDomain);*/
            return Raw.UnloadDomain(pAppDomain);
        }

        #endregion
        #region CurrentDomain

        /// <summary>
        /// Gets an interface pointer of type <see cref="AppDomain"/> that represents the domain loaded on the current thread.
        /// </summary>
        /// <returns>[out] A pointer of type <see cref="AppDomain"/> that represents the thread's current application domain. This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain a pointer of type System._AppDomain.</returns>
        public object CurrentDomain()
        {
            object pAppDomain;
            TryCurrentDomain(out pAppDomain).ThrowOnNotOK();

            return pAppDomain;
        }

        /// <summary>
        /// Gets an interface pointer of type <see cref="AppDomain"/> that represents the domain loaded on the current thread.
        /// </summary>
        /// <param name="pAppDomain">[out] A pointer of type <see cref="AppDomain"/> that represents the thread's current application domain. This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain a pointer of type System._AppDomain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryCurrentDomain(out object pAppDomain)
        {
            /*HRESULT CurrentDomain(
            [Out, MarshalAs(UnmanagedType.Interface)] out object pAppDomain);*/
            return Raw.CurrentDomain(out pAppDomain);
        }

        #endregion
        #endregion
    }
}

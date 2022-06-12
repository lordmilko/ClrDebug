using System;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Principal;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that enable the host to start and stop the common language runtime (CLR) explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.<para/>
    /// In the .NET Framework version 2.0, this interface is superseded by <see cref="ICLRRuntimeHost"/>.
    /// </summary>
    public class CorRuntimeHost : ComObject<ICorRuntimeHost>
    {
        public CorRuntimeHost(ICorRuntimeHost raw) : base(raw)
        {
        }

        #region ICorRuntimeHost
        #region GetConfiguration

        /// <summary>
        /// Gets an object that allows the host to specify the callback configuration of the common language runtime (CLR).
        /// </summary>
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

        /// <summary>
        /// Gets an object that allows the host to specify the callback configuration of the common language runtime (CLR).
        /// </summary>
        /// <param name="pConfiguration">[out] A pointer to the address of an <see cref="ICorConfiguration"/> object that can be used to configure the CLR.</param>
        /// <remarks>
        /// The CLR must be configured prior to its initialization; otherwise, the GetConfiguration method returns an <see cref="HRESULT"/>
        /// indicating an error.
        /// </remarks>
        public HRESULT TryGetConfiguration(out object pConfiguration)
        {
            /*HRESULT GetConfiguration([MarshalAs(UnmanagedType.IUnknown)] out object pConfiguration);*/
            return Raw.GetConfiguration(out pConfiguration);
        }

        #endregion
        #region GetDefaultDomain

        /// <summary>
        /// Gets an interface pointer of type <see cref="_AppDomain"/> that represents the default domain for the current process.
        /// </summary>
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

        /// <summary>
        /// Gets an interface pointer of type <see cref="_AppDomain"/> that represents the default domain for the current process.
        /// </summary>
        /// <param name="pAppDomain">[out] An interface pointer of type <see cref="_AppDomain"/> to the <see cref="AppDomain"/> instance that represents the default application domain for the process.<para/>
        /// This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain an interface pointer of type <see cref="_AppDomain"/>.</param>
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
            /*HRESULT GetDefaultDomain([Out, MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.GetDefaultDomain(out pAppDomain);
        }

        #endregion
        #region CreateLogicalThreadState

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public void CreateLogicalThreadState()
        {
            HRESULT hr;

            if ((hr = TryCreateLogicalThreadState()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryDeleteLogicalThreadState()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TrySwitchInLogicalThreadState(pFiberCookie)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="pFiberCookie">[in] Cookie that indicates the fiber to use.</param>
        public HRESULT TrySwitchInLogicalThreadState(int pFiberCookie)
        {
            /*HRESULT SwitchInLogicalThreadState([In] ref int pFiberCookie);*/
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
            HRESULT hr;
            int fiberCookie;

            if ((hr = TrySwitchOutLogicalThreadState(out fiberCookie)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return fiberCookie;
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="fiberCookie">[out] Cookie that indicates the fiber being switched out.</param>
        public HRESULT TrySwitchOutLogicalThreadState(out int fiberCookie)
        {
            /*HRESULT SwitchOutLogicalThreadState(out int FiberCookie);*/
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
            HRESULT hr;
            int pCount;

            if ((hr = TryLocksHeldByLogicalThread(out pCount)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pCount;
        }

        /// <summary>
        /// Retrieves the number of locks that current thread holds. This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <param name="pCount">[out] A pointer to the number of locks that the current thread holds.</param>
        public HRESULT TryLocksHeldByLogicalThread(out int pCount)
        {
            /*HRESULT LocksHeldByLogicalThread(out int pCount);*/
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
            HRESULT hr;
            IntPtr hMapAddress;

            if ((hr = TryMapFile(hFile, out hMapAddress)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT MapFile(IntPtr hFile, out IntPtr hMapAddress);*/
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
            HRESULT hr;

            if ((hr = TryStart()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            HRESULT hr;

            if ((hr = TryStop()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
        /// Creates an application domain. The caller receives an interface pointer of type <see cref="_AppDomain"/> to an instance of type <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pIdentityArray">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <returns>[out] An interface pointer of type <see cref="_AppDomain"/> to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</returns>
        public object CreateDomain(string pwzFriendlyName, object pIdentityArray)
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryCreateDomain(pwzFriendlyName, pIdentityArray, out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer of type <see cref="_AppDomain"/> to an instance of type <see cref="AppDomain"/>.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pIdentityArray">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <param name="pAppDomain">[out] An interface pointer of type <see cref="_AppDomain"/> to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                                      |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | The operation was successful.                                                                                                                                                                                    |
        /// | S_FALSE                | The operation failed to complete.                                                                                                                                                                                |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                                       |
        /// </returns>
        public HRESULT TryCreateDomain(string pwzFriendlyName, object pIdentityArray, out object pAppDomain)
        {
            /*HRESULT CreateDomain(string pwzFriendlyName, [MarshalAs(UnmanagedType.IUnknown)] object pIdentityArray, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
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
            HRESULT hr;
            IntPtr hEnum;

            if ((hr = TryEnumDomains(out hEnum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT EnumDomains(out IntPtr hEnum);*/
            return Raw.EnumDomains(out hEnum);
        }

        #endregion
        #region NextDomain

        /// <summary>
        /// Gets an interface pointer to the next domain in the enumeration.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator that was obtained through a call to <see cref="EnumDomains"/>.</param>
        /// <returns>[out] An interface pointer to the <see cref="_AppDomain"/> type that represents the next domain in the enumeration, or null, if no more domains exist.</returns>
        public object NextDomain(IntPtr hEnum)
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryNextDomain(hEnum, out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        /// <summary>
        /// Gets an interface pointer to the next domain in the enumeration.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator that was obtained through a call to <see cref="EnumDomains"/>.</param>
        /// <param name="pAppDomain">[out] An interface pointer to the <see cref="_AppDomain"/> type that represents the next domain in the enumeration, or null, if no more domains exist.</param>
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
            /*HRESULT NextDomain(IntPtr hEnum, [MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
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
            HRESULT hr;

            if ((hr = TryCloseEnum(hEnum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
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
            /*HRESULT CloseEnum(IntPtr hEnum);*/
            return Raw.CloseEnum(hEnum);
        }

        #endregion
        #region CreateDomainEx

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer, of type <see cref="_AppDomain"/>, to an instance of type <see cref="AppDomain"/>.<para/>
        /// This method allows the caller to pass an IAppDomainSetup instance to configure additional features of the returned <see cref="_AppDomain"/> instance.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pSetup">[in] An optional interface pointer of type IAppDomainSetup, obtained by a call to the <see cref="CreateDomainSetup"/> method.</param>
        /// <param name="pEvidence">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <returns>[out] An interface pointer of type <see cref="_AppDomain"/> to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</returns>
        /// <remarks>
        /// CreateDomainEx extends the capabilities of <see cref="CreateDomain"/> by allowing the caller to pass in an IAppDomainSetup
        /// instance with property values for configuring the application domain.
        /// </remarks>
        public object CreateDomainEx(string pwzFriendlyName, object pSetup, object pEvidence)
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryCreateDomainEx(pwzFriendlyName, pSetup, pEvidence, out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        /// <summary>
        /// Creates an application domain. The caller receives an interface pointer, of type <see cref="_AppDomain"/>, to an instance of type <see cref="AppDomain"/>.<para/>
        /// This method allows the caller to pass an IAppDomainSetup instance to configure additional features of the returned <see cref="_AppDomain"/> instance.
        /// </summary>
        /// <param name="pwzFriendlyName">[in] An optional parameter used to give a friendly name to the domain. This friendly name can be displayed in user interfaces such as debuggers to identify the domain.</param>
        /// <param name="pSetup">[in] An optional interface pointer of type IAppDomainSetup, obtained by a call to the <see cref="CreateDomainSetup"/> method.</param>
        /// <param name="pEvidence">[in] An optional array of pointers to IIdentity instances that represent evidence mapped through security policy to establish a permission set.<para/>
        /// An IIdentity object can be obtained by calling the <see cref="CreateEvidence"/> method.</param>
        /// <param name="pAppDomain">[out] An interface pointer of type <see cref="_AppDomain"/> to an instance of <see cref="AppDomain"/> that can be used to further control the domain.</param>
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
            [In] string pwzFriendlyName,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pSetup,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pEvidence,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.CreateDomainEx(pwzFriendlyName, pSetup, pEvidence, out pAppDomain);
        }

        #endregion
        #region CreateDomainSetup

        /// <summary>
        /// Gets an interface pointer of type IAppDomainSetup to an <see cref="AppDomainSetup"/> instance. IAppDomainSetup provides methods to configure aspects of an application domain before it is created.
        /// </summary>
        /// <returns>[out] An interface pointer to an <see cref="AppDomainSetup"/> instance. This parameter is typed as IUnknown, so callers should generally call QueryInterface on this pointer to obtain an interface pointer of type IAppDomainSetup.</returns>
        /// <remarks>
        /// The pointer returned from this method is typically passed as a parameter to the <see cref="CreateDomainEx"/> method.
        /// </remarks>
        public object CreateDomainSetup()
        {
            HRESULT hr;
            object pAppDomainSetup;

            if ((hr = TryCreateDomainSetup(out pAppDomainSetup)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomainSetup;
        }

        /// <summary>
        /// Gets an interface pointer of type IAppDomainSetup to an <see cref="AppDomainSetup"/> instance. IAppDomainSetup provides methods to configure aspects of an application domain before it is created.
        /// </summary>
        /// <param name="pAppDomainSetup">[out] An interface pointer to an <see cref="AppDomainSetup"/> instance. This parameter is typed as IUnknown, so callers should generally call QueryInterface on this pointer to obtain an interface pointer of type IAppDomainSetup.</param>
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
            /*HRESULT CreateDomainSetup([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomainSetup);*/
            return Raw.CreateDomainSetup(out pAppDomainSetup);
        }

        #endregion
        #region CreateEvidence

        /// <summary>
        /// Gets an interface pointer of type <see cref="IIdentity"/>, which allows the host to create security evidence to pass to the <see cref="CreateDomain"/> or <see cref="CreateDomainEx"/> method.
        /// </summary>
        /// <returns>[out] A interface pointer to an <see cref="IIdentity"/> instance used to create security evidence. This pointer is typed IUnknown, so callers should typically call QueryInterface on this interface to obtain a pointer to an <see cref="IIdentity"/>.</returns>
        /// <remarks>
        /// This method returns an empty collection that cannot be populated from native code. You should use the <see cref="Evidence"/>
        /// method instead.
        /// </remarks>
        public object CreateEvidence()
        {
            HRESULT hr;
            object pEvidence;

            if ((hr = TryCreateEvidence(out pEvidence)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

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
        /// This method returns an empty collection that cannot be populated from native code. You should use the <see cref="Evidence"/>
        /// method instead.
        /// </remarks>
        public HRESULT TryCreateEvidence(out object pEvidence)
        {
            /*HRESULT CreateEvidence([MarshalAs(UnmanagedType.IUnknown)] out object pEvidence);*/
            return Raw.CreateEvidence(out pEvidence);
        }

        #endregion
        #region UnloadDomain

        /// <summary>
        /// Unloads the specified application domain from the current process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer of type <see cref="_AppDomain"/> that represents the domain to be unloaded.</param>
        public void UnloadDomain(object pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryUnloadDomain(pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Unloads the specified application domain from the current process.
        /// </summary>
        /// <param name="pAppDomain">[in] A pointer of type <see cref="_AppDomain"/> that represents the domain to be unloaded.</param>
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
            /*HRESULT UnloadDomain([MarshalAs(UnmanagedType.IUnknown)] object pAppDomain);*/
            return Raw.UnloadDomain(pAppDomain);
        }

        #endregion
        #region CurrentDomain

        /// <summary>
        /// Gets an interface pointer of type <see cref="AppDomain"/> that represents the domain loaded on the current thread.
        /// </summary>
        /// <returns>[out] A pointer of type <see cref="AppDomain"/> that represents the thread's current application domain. This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain a pointer of type <see cref="_AppDomain"/>.</returns>
        public object CurrentDomain()
        {
            HRESULT hr;
            object pAppDomain;

            if ((hr = TryCurrentDomain(out pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pAppDomain;
        }

        /// <summary>
        /// Gets an interface pointer of type <see cref="AppDomain"/> that represents the domain loaded on the current thread.
        /// </summary>
        /// <param name="pAppDomain">[out] A pointer of type <see cref="AppDomain"/> that represents the thread's current application domain. This pointer is typed IUnknown, so callers should generally call QueryInterface to obtain a pointer of type <see cref="_AppDomain"/>.</param>
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
            /*HRESULT CurrentDomain([MarshalAs(UnmanagedType.IUnknown)] out object pAppDomain);*/
            return Raw.CurrentDomain(out pAppDomain);
        }

        #endregion
        #endregion
    }
}
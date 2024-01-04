using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The symbols interface to the underlying debugger. The IDebugHostSymbols interface is the main starting point to access symbols in the debug target.<para/>
    /// This interface can be queried from an instance of <see cref="IDebugHost"/>.
    /// </summary>
    public class DebugHostSymbols : ComObject<IDebugHostSymbols>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostSymbols"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostSymbols(IDebugHostSymbols raw) : base(raw)
        {
        }

        #region IDebugHostSymbols
        #region CreateModuleSignature

        /// <summary>
        /// The CreateModuleSignature method creates a signature which can be used to match a set of specific modules by name and optionally, by version.<para/>
        /// There are three components to a module signature:
        /// </summary>
        /// <param name="pwszModuleName">The name that a module must have in order to match the signature (case insensitive).</param>
        /// <param name="pwszMinVersion">The minimum version that a module must have in order to match the signature. If this argument is nullptr, there is no minimum version required to match the signature.<para/>
        /// Versions are specified as strings in "A.B.C.D" format with only the first component being required and subsequent components being less important.</param>
        /// <param name="pwszMaxVersion">The maximum version that a module can have in order to match the signature. If this argument is nullptr, there is no upper limit on version number required to match the signature.<para/>
        /// Versions are specified as strings in "A.B.C.D" format with only the first component being required and subsequent components being less important.</param>
        /// <returns>The created module signature object is returned here.</returns>
        public DebugHostModuleSignature CreateModuleSignature(string pwszModuleName, string pwszMinVersion, string pwszMaxVersion)
        {
            DebugHostModuleSignature ppModuleSignatureResult;
            TryCreateModuleSignature(pwszModuleName, pwszMinVersion, pwszMaxVersion, out ppModuleSignatureResult).ThrowDbgEngNotOK();

            return ppModuleSignatureResult;
        }

        /// <summary>
        /// The CreateModuleSignature method creates a signature which can be used to match a set of specific modules by name and optionally, by version.<para/>
        /// There are three components to a module signature:
        /// </summary>
        /// <param name="pwszModuleName">The name that a module must have in order to match the signature (case insensitive).</param>
        /// <param name="pwszMinVersion">The minimum version that a module must have in order to match the signature. If this argument is nullptr, there is no minimum version required to match the signature.<para/>
        /// Versions are specified as strings in "A.B.C.D" format with only the first component being required and subsequent components being less important.</param>
        /// <param name="pwszMaxVersion">The maximum version that a module can have in order to match the signature. If this argument is nullptr, there is no upper limit on version number required to match the signature.<para/>
        /// Versions are specified as strings in "A.B.C.D" format with only the first component being required and subsequent components being less important.</param>
        /// <param name="ppModuleSignatureResult">The created module signature object is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCreateModuleSignature(string pwszModuleName, string pwszMinVersion, string pwszMaxVersion, out DebugHostModuleSignature ppModuleSignatureResult)
        {
            /*HRESULT CreateModuleSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszModuleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMinVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMaxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModuleSignature ppModuleSignature);*/
            IDebugHostModuleSignature ppModuleSignature;
            HRESULT hr = Raw.CreateModuleSignature(pwszModuleName, pwszMinVersion, pwszMaxVersion, out ppModuleSignature);

            if (hr == HRESULT.S_OK)
                ppModuleSignatureResult = ppModuleSignature == null ? null : new DebugHostModuleSignature(ppModuleSignature);
            else
                ppModuleSignatureResult = default(DebugHostModuleSignature);

            return hr;
        }

        #endregion
        #region CreateTypeSignature

        /// <summary>
        /// The CreateTypeSignature method creates a signature which can be used to match a set of concrete types by containing module and type name.<para/>
        /// The format of the type name signature string is specific to the language being debugged (and debug host). For C/C++, the signature string is equivalent to a NatVis Type Specification.<para/>
        /// That is, the signature string is a type name where wildcards (specified as *) are allowed for template arguments.
        /// </summary>
        /// <param name="signatureSpecification">The signature string which identifies the types to which this signature applies. The format of this string is specific to the language being debugged.<para/>
        /// For C/C++, this is equivalent to a NatVis type specification. Such is a type name where wildcards are allowed for template arguments (specified as a *).</param>
        /// <param name="module">If specified, only types which are contained within the given module match the signature. If not specified, types in any module can potentially match the signature.</param>
        /// <returns>The created type signature object is returned here.</returns>
        /// <remarks>
        /// Differences in symbol module matching in FindModuleByName, CreateTypeSignature and CreateTypeSignatureForModuleRange
        /// <see cref="FindModuleByName"/> will allow the passed module name to be either the module's real image name for
        /// example My Module.dll, or the one that you can reference it by in the debugger engine (e.g.: MyModule or MyModule_&lt;hex_base&gt;).
        /// Calling <see cref="CreateTypeSignatureForModuleRange"/> and passing a name/nullptr/nullptr will create a signature
        /// that will match any module that matches that name of any version. The module name passed to the CreateTypeSignature
        /// functions will only accept the module's real image name (e.g.: MyModule.dll). Calling <see cref="FindModuleByName"/>
        /// and then CreateTypeSignature with that module will create a signature that will match only the particular instance
        /// of the module passed to it. If there's two copies of a module that is loaded (e.g.: ntdll in a 32-bit process running
        /// on 64-bit Windows), it would only match the specific instance passed. It would also no longer match if that DLL
        /// were unloaded and reloaded. The signature is associated to a specific instance of a module as known by the debugger.
        /// </remarks>
        public DebugHostTypeSignature CreateTypeSignature(string signatureSpecification, IDebugHostModule module)
        {
            DebugHostTypeSignature typeSignatureResult;
            TryCreateTypeSignature(signatureSpecification, module, out typeSignatureResult).ThrowDbgEngNotOK();

            return typeSignatureResult;
        }

        /// <summary>
        /// The CreateTypeSignature method creates a signature which can be used to match a set of concrete types by containing module and type name.<para/>
        /// The format of the type name signature string is specific to the language being debugged (and debug host). For C/C++, the signature string is equivalent to a NatVis Type Specification.<para/>
        /// That is, the signature string is a type name where wildcards (specified as *) are allowed for template arguments.
        /// </summary>
        /// <param name="signatureSpecification">The signature string which identifies the types to which this signature applies. The format of this string is specific to the language being debugged.<para/>
        /// For C/C++, this is equivalent to a NatVis type specification. Such is a type name where wildcards are allowed for template arguments (specified as a *).</param>
        /// <param name="module">If specified, only types which are contained within the given module match the signature. If not specified, types in any module can potentially match the signature.</param>
        /// <param name="typeSignatureResult">The created type signature object is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// Differences in symbol module matching in FindModuleByName, CreateTypeSignature and CreateTypeSignatureForModuleRange
        /// <see cref="FindModuleByName"/> will allow the passed module name to be either the module's real image name for
        /// example My Module.dll, or the one that you can reference it by in the debugger engine (e.g.: MyModule or MyModule_&lt;hex_base&gt;).
        /// Calling <see cref="CreateTypeSignatureForModuleRange"/> and passing a name/nullptr/nullptr will create a signature
        /// that will match any module that matches that name of any version. The module name passed to the CreateTypeSignature
        /// functions will only accept the module's real image name (e.g.: MyModule.dll). Calling <see cref="FindModuleByName"/>
        /// and then CreateTypeSignature with that module will create a signature that will match only the particular instance
        /// of the module passed to it. If there's two copies of a module that is loaded (e.g.: ntdll in a 32-bit process running
        /// on 64-bit Windows), it would only match the specific instance passed. It would also no longer match if that DLL
        /// were unloaded and reloaded. The signature is associated to a specific instance of a module as known by the debugger.
        /// </remarks>
        public HRESULT TryCreateTypeSignature(string signatureSpecification, IDebugHostModule module, out DebugHostTypeSignature typeSignatureResult)
        {
            /*HRESULT CreateTypeSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostModule module,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);*/
            IDebugHostTypeSignature typeSignature;
            HRESULT hr = Raw.CreateTypeSignature(signatureSpecification, module, out typeSignature);

            if (hr == HRESULT.S_OK)
                typeSignatureResult = typeSignature == null ? null : new DebugHostTypeSignature(typeSignature);
            else
                typeSignatureResult = default(DebugHostTypeSignature);

            return hr;
        }

        #endregion
        #region CreateTypeSignatureForModuleRange

        /// <summary>
        /// The CreateTypeSignatureForModuleRange method creates a signature which can be used to match a set of concrete types by module signature and type name.<para/>
        /// This is similar to the CreateTypeSignature method excepting that instead of passing a specific module to match for the signature, the caller passes the arguments necessary to create a module signature (as if the module signature were created with the CreateModuleSignature method).
        /// </summary>
        /// <param name="signatureSpecification">The signature string which identifies the types to which this signature applies. The format of this string is specific to the language being debugged.<para/>
        /// For C/C++, this is equivalent to a NatVis type specification. Such is a type name where wildcards are allowed for template arguments (specified as a *).</param>
        /// <param name="moduleName">The name that the containing module must match (case insensitive) in order for the type to be considered a match for the signature.</param>
        /// <param name="minVersion">The minimum version of the containing module for the type to be considered a match for the signature. The format of this argument is equivalent to the same argument in CreateModuleSignature</param>
        /// <param name="maxVersion">The maximum version of the containing module for the type to be considered a match for the signature. The format of this argument is equivalent to the same argument in CreateModuleSignature</param>
        /// <returns>The newly created type signature object will be returned here.</returns>
        /// <remarks>
        /// Differences in symbol module matching in FindModuleByName, CreateTypeSignature and CreateTypeSignatureForModuleRange
        /// <see cref="FindModuleByName"/> will allow the passed module name to be either the module's real image name for
        /// example My Module.dll, or the one that you can reference it by in the debugger engine (e.g.: MyModule or MyModule_&lt;hex_base&gt;).
        /// Calling CreateTypeSignatureForModuleRange and passing a name/nullptr/nullptr will create a signature that will
        /// match any module that matches that name of any version. The module name passed to the CreateTypeSignature functions
        /// will only accept the module's real image name (e.g.: MyModule.dll). Calling <see cref="FindModuleByName"/> and
        /// then <see cref="CreateTypeSignature"/> with that module will create a signature that will match only the particular
        /// instance of the module passed to it. If there's two copies of a module that is loaded (e.g.: ntdll in a 32-bit
        /// process running on 64-bit Windows), it would only match the specific instance passed. It would also no longer match
        /// if that DLL were unloaded and reloaded. The signature is associated to a specific instance of a module as known
        /// by the debugger.
        /// </remarks>
        public DebugHostTypeSignature CreateTypeSignatureForModuleRange(string signatureSpecification, string moduleName, string minVersion, string maxVersion)
        {
            DebugHostTypeSignature typeSignatureResult;
            TryCreateTypeSignatureForModuleRange(signatureSpecification, moduleName, minVersion, maxVersion, out typeSignatureResult).ThrowDbgEngNotOK();

            return typeSignatureResult;
        }

        /// <summary>
        /// The CreateTypeSignatureForModuleRange method creates a signature which can be used to match a set of concrete types by module signature and type name.<para/>
        /// This is similar to the CreateTypeSignature method excepting that instead of passing a specific module to match for the signature, the caller passes the arguments necessary to create a module signature (as if the module signature were created with the CreateModuleSignature method).
        /// </summary>
        /// <param name="signatureSpecification">The signature string which identifies the types to which this signature applies. The format of this string is specific to the language being debugged.<para/>
        /// For C/C++, this is equivalent to a NatVis type specification. Such is a type name where wildcards are allowed for template arguments (specified as a *).</param>
        /// <param name="moduleName">The name that the containing module must match (case insensitive) in order for the type to be considered a match for the signature.</param>
        /// <param name="minVersion">The minimum version of the containing module for the type to be considered a match for the signature. The format of this argument is equivalent to the same argument in CreateModuleSignature</param>
        /// <param name="maxVersion">The maximum version of the containing module for the type to be considered a match for the signature. The format of this argument is equivalent to the same argument in CreateModuleSignature</param>
        /// <param name="typeSignatureResult">The newly created type signature object will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// Differences in symbol module matching in FindModuleByName, CreateTypeSignature and CreateTypeSignatureForModuleRange
        /// <see cref="FindModuleByName"/> will allow the passed module name to be either the module's real image name for
        /// example My Module.dll, or the one that you can reference it by in the debugger engine (e.g.: MyModule or MyModule_&lt;hex_base&gt;).
        /// Calling CreateTypeSignatureForModuleRange and passing a name/nullptr/nullptr will create a signature that will
        /// match any module that matches that name of any version. The module name passed to the CreateTypeSignature functions
        /// will only accept the module's real image name (e.g.: MyModule.dll). Calling <see cref="FindModuleByName"/> and
        /// then <see cref="CreateTypeSignature"/> with that module will create a signature that will match only the particular
        /// instance of the module passed to it. If there's two copies of a module that is loaded (e.g.: ntdll in a 32-bit
        /// process running on 64-bit Windows), it would only match the specific instance passed. It would also no longer match
        /// if that DLL were unloaded and reloaded. The signature is associated to a specific instance of a module as known
        /// by the debugger.
        /// </remarks>
        public HRESULT TryCreateTypeSignatureForModuleRange(string signatureSpecification, string moduleName, string minVersion, string maxVersion, out DebugHostTypeSignature typeSignatureResult)
        {
            /*HRESULT CreateTypeSignatureForModuleRange(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string minVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string maxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);*/
            IDebugHostTypeSignature typeSignature;
            HRESULT hr = Raw.CreateTypeSignatureForModuleRange(signatureSpecification, moduleName, minVersion, maxVersion, out typeSignature);

            if (hr == HRESULT.S_OK)
                typeSignatureResult = typeSignature == null ? null : new DebugHostTypeSignature(typeSignature);
            else
                typeSignatureResult = default(DebugHostTypeSignature);

            return hr;
        }

        #endregion
        #region EnumerateModules

        /// <summary>
        /// The EnumerateModules method creates an enumerator which will enumerate every module available in a particular host context.<para/>
        /// That host context might encapsulate a process context or it might encapsulate something like the Windows kernel.
        /// </summary>
        /// <param name="context">The host context for which to enumerate every loaded module.</param>
        /// <returns>An enumerator which will enumerate every module loaded into the given context will be returned here.</returns>
        public DebugHostSymbolEnumerator EnumerateModules(IDebugHostContext context)
        {
            DebugHostSymbolEnumerator moduleEnumResult;
            TryEnumerateModules(context, out moduleEnumResult).ThrowDbgEngNotOK();

            return moduleEnumResult;
        }

        /// <summary>
        /// The EnumerateModules method creates an enumerator which will enumerate every module available in a particular host context.<para/>
        /// That host context might encapsulate a process context or it might encapsulate something like the Windows kernel.
        /// </summary>
        /// <param name="context">The host context for which to enumerate every loaded module.</param>
        /// <param name="moduleEnumResult">An enumerator which will enumerate every module loaded into the given context will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryEnumerateModules(IDebugHostContext context, out DebugHostSymbolEnumerator moduleEnumResult)
        {
            /*HRESULT EnumerateModules(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator moduleEnum);*/
            IDebugHostSymbolEnumerator moduleEnum;
            HRESULT hr = Raw.EnumerateModules(context, out moduleEnum);

            if (hr == HRESULT.S_OK)
                moduleEnumResult = DebugHostSymbolEnumerator.New(moduleEnum);
            else
                moduleEnumResult = default(DebugHostSymbolEnumerator);

            return hr;
        }

        #endregion
        #region FindModuleByName

        /// <summary>
        /// The FindModuleByName method will look through the given host context and locate a module which has the specified name and return an interface to it.<para/>
        /// It is legal to search for the module by name with or without the file extension.
        /// </summary>
        /// <param name="context">This host context will be searched for a loaded module matching the given name.</param>
        /// <param name="moduleName">The name of the module to search for. The name may be specified with or without a file extension.</param>
        /// <returns>If the module is found, an interface to the module will be returned here.</returns>
        /// <remarks>
        /// Differences in symbol module matching in FindModuleByName, CreateTypeSignature and CreateTypeSignatureForModuleRange
        /// FindModuleByName will allow the passed module name to be either the module's real image name for example My Module.dll,
        /// or the one that you can reference it by in the debugger engine (e.g.: MyModule or MyModule_&lt;hex_base&gt;). Calling
        /// <see cref="CreateTypeSignatureForModuleRange"/> and passing a name/nullptr/nullptr will create a signature that
        /// will match any module that matches that name of any version. The module name passed to the <see cref="CreateTypeSignature"/>
        /// functions will only accept the module's real image name (e.g.: MyModule.dll). Calling FindModuleByName and then
        /// CreateTypeSignature with that module will create a signature that will match only the particular instance of the
        /// module passed to it. If there's two copies of a module that is loaded (e.g.: ntdll in a 32-bit process running
        /// on 64-bit Windows), it would only match the specific instance passed. It would also no longer match if that DLL
        /// were unloaded and reloaded. The signature is associated to a specific instance of a module as known by the debugger.
        /// </remarks>
        public DebugHostModule FindModuleByName(IDebugHostContext context, string moduleName)
        {
            DebugHostModule moduleResult;
            TryFindModuleByName(context, moduleName, out moduleResult).ThrowDbgEngNotOK();

            return moduleResult;
        }

        /// <summary>
        /// The FindModuleByName method will look through the given host context and locate a module which has the specified name and return an interface to it.<para/>
        /// It is legal to search for the module by name with or without the file extension.
        /// </summary>
        /// <param name="context">This host context will be searched for a loaded module matching the given name.</param>
        /// <param name="moduleName">The name of the module to search for. The name may be specified with or without a file extension.</param>
        /// <param name="moduleResult">If the module is found, an interface to the module will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// Differences in symbol module matching in FindModuleByName, CreateTypeSignature and CreateTypeSignatureForModuleRange
        /// FindModuleByName will allow the passed module name to be either the module's real image name for example My Module.dll,
        /// or the one that you can reference it by in the debugger engine (e.g.: MyModule or MyModule_&lt;hex_base&gt;). Calling
        /// <see cref="CreateTypeSignatureForModuleRange"/> and passing a name/nullptr/nullptr will create a signature that
        /// will match any module that matches that name of any version. The module name passed to the <see cref="CreateTypeSignature"/>
        /// functions will only accept the module's real image name (e.g.: MyModule.dll). Calling FindModuleByName and then
        /// CreateTypeSignature with that module will create a signature that will match only the particular instance of the
        /// module passed to it. If there's two copies of a module that is loaded (e.g.: ntdll in a 32-bit process running
        /// on 64-bit Windows), it would only match the specific instance passed. It would also no longer match if that DLL
        /// were unloaded and reloaded. The signature is associated to a specific instance of a module as known by the debugger.
        /// </remarks>
        public HRESULT TryFindModuleByName(IDebugHostContext context, string moduleName, out DebugHostModule moduleResult)
        {
            /*HRESULT FindModuleByName(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);*/
            IDebugHostModule module;
            HRESULT hr = Raw.FindModuleByName(context, moduleName, out module);

            if (hr == HRESULT.S_OK)
                moduleResult = module == null ? null : new DebugHostModule(module);
            else
                moduleResult = default(DebugHostModule);

            return hr;
        }

        #endregion
        #region FindModuleByLocation

        /// <summary>
        /// The FindModuleByLocation method will look through the given host context and determine what module contains the address given by the specified location.<para/>
        /// It will then return an interface to such module.
        /// </summary>
        /// <param name="context">This host context will be searched for a loaded module containing the address given by the moduleLocation argument.</param>
        /// <param name="moduleLocation">The module in the given context which contains the address specified by this argument will be returned (or the method will fail).</param>
        /// <returns>If the module is found, an interface to the module will be returned here.</returns>
        public DebugHostModule FindModuleByLocation(IDebugHostContext context, Location moduleLocation)
        {
            DebugHostModule moduleResult;
            TryFindModuleByLocation(context, moduleLocation, out moduleResult).ThrowDbgEngNotOK();

            return moduleResult;
        }

        /// <summary>
        /// The FindModuleByLocation method will look through the given host context and determine what module contains the address given by the specified location.<para/>
        /// It will then return an interface to such module.
        /// </summary>
        /// <param name="context">This host context will be searched for a loaded module containing the address given by the moduleLocation argument.</param>
        /// <param name="moduleLocation">The module in the given context which contains the address specified by this argument will be returned (or the method will fail).</param>
        /// <param name="moduleResult">If the module is found, an interface to the module will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryFindModuleByLocation(IDebugHostContext context, Location moduleLocation, out DebugHostModule moduleResult)
        {
            /*HRESULT FindModuleByLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location moduleLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);*/
            IDebugHostModule module;
            HRESULT hr = Raw.FindModuleByLocation(context, moduleLocation, out module);

            if (hr == HRESULT.S_OK)
                moduleResult = module == null ? null : new DebugHostModule(module);
            else
                moduleResult = default(DebugHostModule);

            return hr;
        }

        #endregion
        #region GetMostDerivedObject

        /// <summary>
        /// The GetMostDerivedObject will use the type system of the debugger to determine the runtime type of an object from its static type.<para/>
        /// This method will only use symbolic information and heuristics available at the type system layer in order to perform this analysis.<para/>
        /// Such information may include C++ RTTI (run time type information) or analysis of the shape of the virtual function tables of the object.<para/>
        /// It does not include things such as the preferred runtime type concept on an <see cref="IModelObject"/>. If the analysis cannot find a runtime type or cannot find a runtime type different from the static type passed into the method, the input location and type may be passed out.<para/>
        /// The method will not fail for these reasons.
        /// </summary>
        /// <param name="pContext">The context in which the given location is valid. If this value is not specified, the context will be assumed to be identical to the context given by objectType.</param>
        /// <param name="location">The location of the statically typed object within the address space given by either the pContext argument or the objectType argument.</param>
        /// <param name="objectType">The static type of the object at the given location.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMostDerivedObjectResult GetMostDerivedObject(IDebugHostContext pContext, Location location, IDebugHostType objectType)
        {
            GetMostDerivedObjectResult result;
            TryGetMostDerivedObject(pContext, location, objectType, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetMostDerivedObject will use the type system of the debugger to determine the runtime type of an object from its static type.<para/>
        /// This method will only use symbolic information and heuristics available at the type system layer in order to perform this analysis.<para/>
        /// Such information may include C++ RTTI (run time type information) or analysis of the shape of the virtual function tables of the object.<para/>
        /// It does not include things such as the preferred runtime type concept on an <see cref="IModelObject"/>. If the analysis cannot find a runtime type or cannot find a runtime type different from the static type passed into the method, the input location and type may be passed out.<para/>
        /// The method will not fail for these reasons.
        /// </summary>
        /// <param name="pContext">The context in which the given location is valid. If this value is not specified, the context will be assumed to be identical to the context given by objectType.</param>
        /// <param name="location">The location of the statically typed object within the address space given by either the pContext argument or the objectType argument.</param>
        /// <param name="objectType">The static type of the object at the given location.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetMostDerivedObject(IDebugHostContext pContext, Location location, IDebugHostType objectType, out GetMostDerivedObjectResult result)
        {
            /*HRESULT GetMostDerivedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [In] Location location,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out] out Location derivedLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType derivedType);*/
            Location derivedLocation;
            IDebugHostType derivedType;
            HRESULT hr = Raw.GetMostDerivedObject(pContext, location, objectType, out derivedLocation, out derivedType);

            if (hr == HRESULT.S_OK)
                result = new GetMostDerivedObjectResult(derivedLocation, derivedType == null ? null : new DebugHostType(derivedType));
            else
                result = default(GetMostDerivedObjectResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostSymbols2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostSymbols2 Raw2 => (IDebugHostSymbols2) Raw;

        #region DemangleSymbolName

        public string DemangleSymbolName(IDebugHostSymbol pSymbol, int flags)
        {
            string pDemangledSymbolName;
            TryDemangleSymbolName(pSymbol, flags, out pDemangledSymbolName).ThrowDbgEngNotOK();

            return pDemangledSymbolName;
        }

        public HRESULT TryDemangleSymbolName(IDebugHostSymbol pSymbol, int flags, out string pDemangledSymbolName)
        {
            /*HRESULT DemangleSymbolName(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pSymbol,
            [In] int flags,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDemangledSymbolName);*/
            return Raw2.DemangleSymbolName(pSymbol, flags, out pDemangledSymbolName);
        }

        #endregion
        #endregion
    }
}

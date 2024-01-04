﻿using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The symbols interface to the underlying debugger. The IDebugHostSymbols interface is the main starting point to access symbols in the debug target.<para/>
    /// This interface can be queried from an instance of <see cref="IDebugHost"/>.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("854FD751-C2E1-4EB2-B525-6619CB97A588")]
    [ComImport]
    public interface IDebugHostSymbols
    {
        /// <summary>
        /// The CreateModuleSignature method creates a signature which can be used to match a set of specific modules by name and optionally, by version.<para/>
        /// There are three components to a module signature:
        /// </summary>
        /// <param name="pwszModuleName">The name that a module must have in order to match the signature (case insensitive).</param>
        /// <param name="pwszMinVersion">The minimum version that a module must have in order to match the signature. If this argument is nullptr, there is no minimum version required to match the signature.<para/>
        /// Versions are specified as strings in "A.B.C.D" format with only the first component being required and subsequent components being less important.</param>
        /// <param name="pwszMaxVersion">The maximum version that a module can have in order to match the signature. If this argument is nullptr, there is no upper limit on version number required to match the signature.<para/>
        /// Versions are specified as strings in "A.B.C.D" format with only the first component being required and subsequent components being less important.</param>
        /// <param name="ppModuleSignature">The created module signature object is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT CreateModuleSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszModuleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMinVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMaxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModuleSignature ppModuleSignature);

        /// <summary>
        /// The CreateTypeSignature method creates a signature which can be used to match a set of concrete types by containing module and type name.<para/>
        /// The format of the type name signature string is specific to the language being debugged (and debug host). For C/C++, the signature string is equivalent to a NatVis Type Specification.<para/>
        /// That is, the signature string is a type name where wildcards (specified as *) are allowed for template arguments.
        /// </summary>
        /// <param name="signatureSpecification">The signature string which identifies the types to which this signature applies. The format of this string is specific to the language being debugged.<para/>
        /// For C/C++, this is equivalent to a NatVis type specification. Such is a type name where wildcards are allowed for template arguments (specified as a *).</param>
        /// <param name="module">If specified, only types which are contained within the given module match the signature. If not specified, types in any module can potentially match the signature.</param>
        /// <param name="typeSignature">The created type signature object is returned here.</param>
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
        [PreserveSig]
        HRESULT CreateTypeSignature(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostModule module,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);

        /// <summary>
        /// The CreateTypeSignatureForModuleRange method creates a signature which can be used to match a set of concrete types by module signature and type name.<para/>
        /// This is similar to the CreateTypeSignature method excepting that instead of passing a specific module to match for the signature, the caller passes the arguments necessary to create a module signature (as if the module signature were created with the CreateModuleSignature method).
        /// </summary>
        /// <param name="signatureSpecification">The signature string which identifies the types to which this signature applies. The format of this string is specific to the language being debugged.<para/>
        /// For C/C++, this is equivalent to a NatVis type specification. Such is a type name where wildcards are allowed for template arguments (specified as a *).</param>
        /// <param name="moduleName">The name that the containing module must match (case insensitive) in order for the type to be considered a match for the signature.</param>
        /// <param name="minVersion">The minimum version of the containing module for the type to be considered a match for the signature. The format of this argument is equivalent to the same argument in CreateModuleSignature</param>
        /// <param name="maxVersion">The maximum version of the containing module for the type to be considered a match for the signature. The format of this argument is equivalent to the same argument in CreateModuleSignature</param>
        /// <param name="typeSignature">The newly created type signature object will be returned here.</param>
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
        [PreserveSig]
        HRESULT CreateTypeSignatureForModuleRange(
            [In, MarshalAs(UnmanagedType.LPWStr)] string signatureSpecification,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string minVersion,
            [In, MarshalAs(UnmanagedType.LPWStr)] string maxVersion,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostTypeSignature typeSignature);

        /// <summary>
        /// The EnumerateModules method creates an enumerator which will enumerate every module available in a particular host context.<para/>
        /// That host context might encapsulate a process context or it might encapsulate something like the Windows kernel.
        /// </summary>
        /// <param name="context">The host context for which to enumerate every loaded module.</param>
        /// <param name="moduleEnum">An enumerator which will enumerate every module loaded into the given context will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT EnumerateModules(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator moduleEnum);

        /// <summary>
        /// The FindModuleByName method will look through the given host context and locate a module which has the specified name and return an interface to it.<para/>
        /// It is legal to search for the module by name with or without the file extension.
        /// </summary>
        /// <param name="context">This host context will be searched for a loaded module matching the given name.</param>
        /// <param name="moduleName">The name of the module to search for. The name may be specified with or without a file extension.</param>
        /// <param name="module">If the module is found, an interface to the module will be returned here.</param>
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
        [PreserveSig]
        HRESULT FindModuleByName(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string moduleName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);

        /// <summary>
        /// The FindModuleByLocation method will look through the given host context and determine what module contains the address given by the specified location.<para/>
        /// It will then return an interface to such module.
        /// </summary>
        /// <param name="context">This host context will be searched for a loaded module containing the address given by the moduleLocation argument.</param>
        /// <param name="moduleLocation">The module in the given context which contains the address specified by this argument will be returned (or the method will fail).</param>
        /// <param name="module">If the module is found, an interface to the module will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT FindModuleByLocation(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In] Location moduleLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostModule module);

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
        /// <param name="derivedLocation">The location of the runtime typed object within the address space given by either the pContext argument or the objectType argument.<para/>
        /// This may or may not be the same as the location given by the location argument.</param>
        /// <param name="derivedType">The runtime type of the object will be returned here. This may or may not be the same as the type passed in the objectType argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetMostDerivedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [In] Location location,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostType objectType,
            [Out] out Location derivedLocation,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType derivedType);
    }
}

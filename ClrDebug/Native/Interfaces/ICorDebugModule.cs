using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Represents a common language runtime (CLR) module, which is either an executable file or a dynamic-link library (DLL).
    /// </summary>
    [Guid("DBA2D8C1-E5C5-4069-8C13-10A7C6ABF43D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugModule
    {
        /// <summary>
        /// Gets the containing process of this module.
        /// </summary>
        /// <param name="ppProcess">[out] A pointer to the address of an <see cref="ICorDebugProcess"/> object that represents the process containing this module.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        /// <summary>
        /// Gets the base address of the module.
        /// </summary>
        /// <param name="pAddress">[out] A <see cref="CORDB_ADDRESS"/> that specifies the base address of the module.</param>
        /// <remarks>
        /// If the module is a native image (that is, if the module was produced by the native image generator, NGen.exe),
        /// its base address will be zero.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBaseAddress(
            [Out] out CORDB_ADDRESS pAddress);

        /// <summary>
        /// Gets the containing assembly for this module.
        /// </summary>
        /// <param name="ppAssembly">[out] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly containing this module.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAssembly(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);

        /// <summary>
        /// Gets the file name of the module.
        /// </summary>
        /// <param name="cchName">[in] The size of the szName array.</param>
        /// <param name="pcchName">[in] A pointer to the length of the returned name.</param>
        /// <param name="szName">[out] An array that stores the returned name.</param>
        /// <remarks>
        /// The GetName method returns an S_OK <see cref="HRESULT"/> if the module's file name matches the name on disk. GetName returns
        /// an S_FALSE <see cref="HRESULT"/> if the name is fabricated, such as for a dynamic or in-memory module.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0), Out] char[] szName);

        /// <summary>
        /// Controls whether the just-in-time (JIT) compiler preserves debugging information for methods within this module.
        /// </summary>
        /// <param name="bTrackJITInfo">[in] Set this value to true to enable the JIT compiler to preserve mapping information between the Microsoft intermediate language (MSIL) version and the JIT-compiled version of each method in this module.</param>
        /// <param name="bAllowJitOpts">[in] Set this value to true to enable the JIT compiler to generate code with certain JIT-specific optimizations for debugging.</param>
        /// <remarks>
        /// JIT debugging is enabled by default for all modules that are loaded when the debugger is active. Programmatically
        /// enabling or disabling the settings overrides global settings.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableJITDebugging(
            [In, MarshalAs(UnmanagedType.Bool)] bool bTrackJITInfo,
            [In, MarshalAs(UnmanagedType.Bool)] bool bAllowJitOpts);

        /// <summary>
        /// Controls whether the <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks are called for this module.
        /// </summary>
        /// <param name="bClassLoadCallbacks">[in] Set this value to true to enable the common language runtime (CLR) to call the <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> methods when their associated events occur.<para/>
        /// The default value is false for non-dynamic modules. The value is always true for dynamic modules and cannot be changed.</param>
        /// <remarks>
        /// The <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks are always enabled
        /// for dynamic modules and cannot be disabled.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableClassLoadCallbacks(
            [In, MarshalAs(UnmanagedType.Bool)] bool bClassLoadCallbacks);

        /// <summary>
        /// Gets the function that is specified by the metadata token.
        /// </summary>
        /// <param name="methodDef">[in] A <see cref="mdMethodDef"/> metadata token that references the function's metadata.</param>
        /// <param name="ppFunction">[out] A pointer to the address of a <see cref="ICorDebugFunction"/> interface object that represents the function.</param>
        /// <remarks>
        /// The GetFunctionFromToken method returns a CORDBG_E_FUNCTION_NOT_IL <see cref="HRESULT"/> if the value passed in methodDef does
        /// not refer to a Microsoft intermediate language (MSIL) method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunctionFromToken(
            [In] mdMethodDef methodDef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// This method has not been implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunctionFromRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// Gets the class specified by the metadata token.
        /// </summary>
        /// <param name="typeDef">[in] An <see cref="mdTypeDef"/> metadata token that references the metadata of a class.</param>
        /// <param name="ppClass">[out] A pointer to the address of an <see cref="ICorDebugClass"/> object that represents the class.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetClassFromToken(
            [In] mdTypeDef typeDef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        /// <summary>
        /// This method has not been implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateBreakpoint(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModuleBreakpoint ppBreakpoint);

        /// <summary>
        /// Deprecated.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetEditAndContinueSnapshot(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEditAndContinueSnapshot ppEditAndContinueSnapshot);

        /// <summary>
        /// Gets a metadata interface object that can be used to examine the metadata for the module.
        /// </summary>
        /// <param name="riid">[in] The reference ID that specifies the metadata interface.</param>
        /// <param name="ppObj">[out] A pointer to the address of an IUnknown object that is one of the metadata interfaces.</param>
        /// <remarks>
        /// The debugger can use the GetMetaDataInterface method to make a copy of the original metadata for a module, which
        /// it must do in order to edit that module. The debugger calls GetMetaDataInterface to get an <see cref="IMetaDataEmit"/>
        /// interface object for the module, then calls <see cref="IMetaDataEmit.SaveToMemory"/> to save a copy of the module's
        /// metadata to memory.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMetaDataInterface(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppObj);

        /// <summary>
        /// Gets the token for the table entry for this module.
        /// </summary>
        /// <param name="pToken">[out] A pointer to the <see cref="mdModule"/> token that references the module's metadata.</param>
        /// <remarks>
        /// The token can be passed to the <see cref="IMetaDataImport"/>, <see cref="IMetaDataImport2"/>, and <see cref="IMetaDataAssemblyImport"/>
        /// metadata import interfaces.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetToken(
            [Out] out mdModule pToken);

        /// <summary>
        /// Gets a value that indicates whether this module is dynamic.
        /// </summary>
        /// <param name="pDynamic">[out] true if this module is dynamic; otherwise, false.</param>
        /// <remarks>
        /// A dynamic module can add new classes and delete existing classes even after the module has been loaded. The <see
        /// cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks inform
        /// the debugger when a class has been added or deleted.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsDynamic(
            [Out] out int pDynamic);

        /// <summary>
        /// Gets the value of the specified global variable.
        /// </summary>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that references the metadata describing the global variable.</param>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified global variable.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetGlobalVariableValue(
            [In] mdFieldDef fieldDef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets the size, in bytes, of the module.
        /// </summary>
        /// <param name="pcBytes">[out] The size of the module in bytes. If the module was produced from the native image generator (NGen.exe), the size of the module will be zero.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize(
            [Out] out int pcBytes);

        /// <summary>
        /// Gets a value that indicates whether this module exists only in memory.
        /// </summary>
        /// <param name="pInMemory">[out] true if this module exists only in memory; otherwise, false.</param>
        /// <remarks>
        /// The common language runtime (CLR) supports the loading of modules from raw streams of bytes. Such modules are called
        /// in-memory modules and do not exist on disk.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsInMemory(
            [Out] out int pInMemory);
    }
}

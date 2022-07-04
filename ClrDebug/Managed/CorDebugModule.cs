using System;
using System.Diagnostics;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Represents a common language runtime (CLR) module, which is either an executable file or a dynamic-link library (DLL).
    /// </summary>
    public class CorDebugModule : ComObject<ICorDebugModule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugModule"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugModule(ICorDebugModule raw) : base(raw)
        {
        }

        #region ICorDebugModule
        #region Process

        /// <summary>
        /// Gets the containing process of this module.
        /// </summary>
        public CorDebugProcess Process
        {
            get
            {
                CorDebugProcess ppProcessResult;
                TryGetProcess(out ppProcessResult).ThrowOnNotOK();

                return ppProcessResult;
            }
        }

        /// <summary>
        /// Gets the containing process of this module.
        /// </summary>
        /// <param name="ppProcessResult">[out] A pointer to the address of an <see cref="ICorDebugProcess"/> object that represents the process containing this module.</param>
        public HRESULT TryGetProcess(out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region BaseAddress

        /// <summary>
        /// Gets the base address of the module.
        /// </summary>
        public CORDB_ADDRESS BaseAddress
        {
            get
            {
                CORDB_ADDRESS pAddress;
                TryGetBaseAddress(out pAddress).ThrowOnNotOK();

                return pAddress;
            }
        }

        /// <summary>
        /// Gets the base address of the module.
        /// </summary>
        /// <param name="pAddress">[out] A <see cref="CORDB_ADDRESS"/> that specifies the base address of the module.</param>
        /// <remarks>
        /// If the module is a native image (that is, if the module was produced by the native image generator, NGen.exe),
        /// its base address will be zero.
        /// </remarks>
        public HRESULT TryGetBaseAddress(out CORDB_ADDRESS pAddress)
        {
            /*HRESULT GetBaseAddress([Out] out CORDB_ADDRESS pAddress);*/
            return Raw.GetBaseAddress(out pAddress);
        }

        #endregion
        #region Assembly

        /// <summary>
        /// Gets the containing assembly for this module.
        /// </summary>
        public CorDebugAssembly Assembly
        {
            get
            {
                CorDebugAssembly ppAssemblyResult;
                TryGetAssembly(out ppAssemblyResult).ThrowOnNotOK();

                return ppAssemblyResult;
            }
        }

        /// <summary>
        /// Gets the containing assembly for this module.
        /// </summary>
        /// <param name="ppAssemblyResult">[out] A pointer to an <see cref="ICorDebugAssembly"/> object that represents the assembly containing this module.</param>
        public HRESULT TryGetAssembly(out CorDebugAssembly ppAssemblyResult)
        {
            /*HRESULT GetAssembly([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);*/
            ICorDebugAssembly ppAssembly;
            HRESULT hr = Raw.GetAssembly(out ppAssembly);

            if (hr == HRESULT.S_OK)
                ppAssemblyResult = new CorDebugAssembly(ppAssembly);
            else
                ppAssemblyResult = default(CorDebugAssembly);

            return hr;
        }

        #endregion
        #region Name

        /// <summary>
        /// Gets the file name of the module.
        /// </summary>
        public string Name
        {
            get
            {
                string szNameResult;
                TryGetName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the file name of the module.
        /// </summary>
        /// <param name="szNameResult">[out] An array that stores the returned name.</param>
        /// <remarks>
        /// The GetName method returns an S_OK <see cref="HRESULT"/> if the module's file name matches the name on disk. GetName returns
        /// an S_FALSE <see cref="HRESULT"/> if the name is fabricated, such as for a dynamic or in-memory module.
        /// </remarks>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, [Out] out int pcchName, [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
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
        #region EditAndContinueSnapshot

        /// <summary>
        /// Deprecated.
        /// </summary>
        public CorDebugEditAndContinueSnapshot EditAndContinueSnapshot
        {
            get
            {
                CorDebugEditAndContinueSnapshot ppEditAndContinueSnapshotResult;
                TryGetEditAndContinueSnapshot(out ppEditAndContinueSnapshotResult).ThrowOnNotOK();

                return ppEditAndContinueSnapshotResult;
            }
        }

        /// <summary>
        /// Deprecated.
        /// </summary>
        public HRESULT TryGetEditAndContinueSnapshot(out CorDebugEditAndContinueSnapshot ppEditAndContinueSnapshotResult)
        {
            /*HRESULT GetEditAndContinueSnapshot(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEditAndContinueSnapshot ppEditAndContinueSnapshot);*/
            ICorDebugEditAndContinueSnapshot ppEditAndContinueSnapshot;
            HRESULT hr = Raw.GetEditAndContinueSnapshot(out ppEditAndContinueSnapshot);

            if (hr == HRESULT.S_OK)
                ppEditAndContinueSnapshotResult = new CorDebugEditAndContinueSnapshot(ppEditAndContinueSnapshot);
            else
                ppEditAndContinueSnapshotResult = default(CorDebugEditAndContinueSnapshot);

            return hr;
        }

        #endregion
        #region Token

        /// <summary>
        /// Gets the token for the table entry for this module.
        /// </summary>
        public mdModule Token
        {
            get
            {
                mdModule pToken;
                TryGetToken(out pToken).ThrowOnNotOK();

                return pToken;
            }
        }

        /// <summary>
        /// Gets the token for the table entry for this module.
        /// </summary>
        /// <param name="pToken">[out] A pointer to the <see cref="mdModule"/> token that references the module's metadata.</param>
        /// <remarks>
        /// The token can be passed to the <see cref="IMetaDataImport"/>, <see cref="IMetaDataImport2"/>, and <see cref="IMetaDataAssemblyImport"/>
        /// metadata import interfaces.
        /// </remarks>
        public HRESULT TryGetToken(out mdModule pToken)
        {
            /*HRESULT GetToken([Out] out mdModule pToken);*/
            return Raw.GetToken(out pToken);
        }

        #endregion
        #region IsDynamic

        /// <summary>
        /// Gets a value that indicates whether this module is dynamic.
        /// </summary>
        public bool IsDynamic
        {
            get
            {
                bool pDynamicResult;
                TryIsDynamic(out pDynamicResult).ThrowOnNotOK();

                return pDynamicResult;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this module is dynamic.
        /// </summary>
        /// <param name="pDynamicResult">[out] true if this module is dynamic; otherwise, false.</param>
        /// <remarks>
        /// A dynamic module can add new classes and delete existing classes even after the module has been loaded. The <see 
        ///cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks inform
        /// the debugger when a class has been added or deleted.
        /// </remarks>
        public HRESULT TryIsDynamic(out bool pDynamicResult)
        {
            /*HRESULT IsDynamic([Out] out int pDynamic);*/
            int pDynamic;
            HRESULT hr = Raw.IsDynamic(out pDynamic);

            if (hr == HRESULT.S_OK)
                pDynamicResult = pDynamic == 1;
            else
                pDynamicResult = default(bool);

            return hr;
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size, in bytes, of the module.
        /// </summary>
        public int Size
        {
            get
            {
                int pcBytes;
                TryGetSize(out pcBytes).ThrowOnNotOK();

                return pcBytes;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the module.
        /// </summary>
        /// <param name="pcBytes">[out] The size of the module in bytes. If the module was produced from the native image generator (NGen.exe), the size of the module will be zero.</param>
        public HRESULT TryGetSize(out int pcBytes)
        {
            /*HRESULT GetSize([Out] out int pcBytes);*/
            return Raw.GetSize(out pcBytes);
        }

        #endregion
        #region IsInMemory

        /// <summary>
        /// Gets a value that indicates whether this module exists only in memory.
        /// </summary>
        public bool IsInMemory
        {
            get
            {
                bool pInMemoryResult;
                TryIsInMemory(out pInMemoryResult).ThrowOnNotOK();

                return pInMemoryResult;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this module exists only in memory.
        /// </summary>
        /// <param name="pInMemoryResult">[out] true if this module exists only in memory; otherwise, false.</param>
        /// <remarks>
        /// The common language runtime (CLR) supports the loading of modules from raw streams of bytes. Such modules are called
        /// in-memory modules and do not exist on disk.
        /// </remarks>
        public HRESULT TryIsInMemory(out bool pInMemoryResult)
        {
            /*HRESULT IsInMemory([Out] out int pInMemory);*/
            int pInMemory;
            HRESULT hr = Raw.IsInMemory(out pInMemory);

            if (hr == HRESULT.S_OK)
                pInMemoryResult = pInMemory == 1;
            else
                pInMemoryResult = default(bool);

            return hr;
        }

        #endregion
        #region EnableJITDebugging

        /// <summary>
        /// Controls whether the just-in-time (JIT) compiler preserves debugging information for methods within this module.
        /// </summary>
        /// <param name="bTrackJITInfo">[in] Set this value to true to enable the JIT compiler to preserve mapping information between the Microsoft intermediate language (MSIL) version and the JIT-compiled version of each method in this module.</param>
        /// <param name="bAllowJitOpts">[in] Set this value to true to enable the JIT compiler to generate code with certain JIT-specific optimizations for debugging.</param>
        /// <remarks>
        /// JIT debugging is enabled by default for all modules that are loaded when the debugger is active. Programmatically
        /// enabling or disabling the settings overrides global settings.
        /// </remarks>
        public void EnableJITDebugging(bool bTrackJITInfo, bool bAllowJitOpts)
        {
            TryEnableJITDebugging(bTrackJITInfo, bAllowJitOpts).ThrowOnNotOK();
        }

        /// <summary>
        /// Controls whether the just-in-time (JIT) compiler preserves debugging information for methods within this module.
        /// </summary>
        /// <param name="bTrackJITInfo">[in] Set this value to true to enable the JIT compiler to preserve mapping information between the Microsoft intermediate language (MSIL) version and the JIT-compiled version of each method in this module.</param>
        /// <param name="bAllowJitOpts">[in] Set this value to true to enable the JIT compiler to generate code with certain JIT-specific optimizations for debugging.</param>
        /// <remarks>
        /// JIT debugging is enabled by default for all modules that are loaded when the debugger is active. Programmatically
        /// enabling or disabling the settings overrides global settings.
        /// </remarks>
        public HRESULT TryEnableJITDebugging(bool bTrackJITInfo, bool bAllowJitOpts)
        {
            /*HRESULT EnableJITDebugging([In] bool bTrackJITInfo, [In] bool bAllowJitOpts);*/
            return Raw.EnableJITDebugging(bTrackJITInfo, bAllowJitOpts);
        }

        #endregion
        #region EnableClassLoadCallbacks

        /// <summary>
        /// Controls whether the <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks are called for this module.
        /// </summary>
        /// <param name="bClassLoadCallbacks">[in] Set this value to true to enable the common language runtime (CLR) to call the <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> methods when their associated events occur.<para/>
        /// The default value is false for non-dynamic modules. The value is always true for dynamic modules and cannot be changed.</param>
        /// <remarks>
        /// The <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks are always enabled
        /// for dynamic modules and cannot be disabled.
        /// </remarks>
        public void EnableClassLoadCallbacks(bool bClassLoadCallbacks)
        {
            TryEnableClassLoadCallbacks(bClassLoadCallbacks).ThrowOnNotOK();
        }

        /// <summary>
        /// Controls whether the <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks are called for this module.
        /// </summary>
        /// <param name="bClassLoadCallbacks">[in] Set this value to true to enable the common language runtime (CLR) to call the <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> methods when their associated events occur.<para/>
        /// The default value is false for non-dynamic modules. The value is always true for dynamic modules and cannot be changed.</param>
        /// <remarks>
        /// The <see cref="ICorDebugManagedCallback.LoadClass"/> and <see cref="ICorDebugManagedCallback.UnloadClass"/> callbacks are always enabled
        /// for dynamic modules and cannot be disabled.
        /// </remarks>
        public HRESULT TryEnableClassLoadCallbacks(bool bClassLoadCallbacks)
        {
            /*HRESULT EnableClassLoadCallbacks([In] bool bClassLoadCallbacks);*/
            return Raw.EnableClassLoadCallbacks(bClassLoadCallbacks);
        }

        #endregion
        #region GetFunctionFromToken

        /// <summary>
        /// Gets the function that is specified by the metadata token.
        /// </summary>
        /// <param name="methodDef">[in] A <see cref="mdMethodDef"/> metadata token that references the function's metadata.</param>
        /// <returns>[out] A pointer to the address of a <see cref="ICorDebugFunction"/> interface object that represents the function.</returns>
        /// <remarks>
        /// The GetFunctionFromToken method returns a CORDBG_E_FUNCTION_NOT_IL <see cref="HRESULT"/> if the value passed in methodDef does
        /// not refer to a Microsoft intermediate language (MSIL) method.
        /// </remarks>
        public CorDebugFunction GetFunctionFromToken(mdMethodDef methodDef)
        {
            CorDebugFunction ppFunctionResult;
            TryGetFunctionFromToken(methodDef, out ppFunctionResult).ThrowOnNotOK();

            return ppFunctionResult;
        }

        /// <summary>
        /// Gets the function that is specified by the metadata token.
        /// </summary>
        /// <param name="methodDef">[in] A <see cref="mdMethodDef"/> metadata token that references the function's metadata.</param>
        /// <param name="ppFunctionResult">[out] A pointer to the address of a <see cref="ICorDebugFunction"/> interface object that represents the function.</param>
        /// <remarks>
        /// The GetFunctionFromToken method returns a CORDBG_E_FUNCTION_NOT_IL <see cref="HRESULT"/> if the value passed in methodDef does
        /// not refer to a Microsoft intermediate language (MSIL) method.
        /// </remarks>
        public HRESULT TryGetFunctionFromToken(mdMethodDef methodDef, out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunctionFromToken([In] mdMethodDef methodDef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetFunctionFromToken(methodDef, out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region GetFunctionFromRVA

        /// <summary>
        /// This method has not been implemented in the current version of the .NET Framework.
        /// </summary>
        public CorDebugFunction GetFunctionFromRVA(long rva)
        {
            CorDebugFunction ppFunctionResult;
            TryGetFunctionFromRVA(rva, out ppFunctionResult).ThrowOnNotOK();

            return ppFunctionResult;
        }

        /// <summary>
        /// This method has not been implemented in the current version of the .NET Framework.
        /// </summary>
        public HRESULT TryGetFunctionFromRVA(long rva, out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunctionFromRVA([In] long rva, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetFunctionFromRVA(rva, out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region GetClassFromToken

        /// <summary>
        /// Gets the class specified by the metadata token.
        /// </summary>
        /// <param name="typeDef">[in] An <see cref="mdTypeDef"/> metadata token that references the metadata of a class.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugClass"/> object that represents the class.</returns>
        public CorDebugClass GetClassFromToken(mdTypeDef typeDef)
        {
            CorDebugClass ppClassResult;
            TryGetClassFromToken(typeDef, out ppClassResult).ThrowOnNotOK();

            return ppClassResult;
        }

        /// <summary>
        /// Gets the class specified by the metadata token.
        /// </summary>
        /// <param name="typeDef">[in] An <see cref="mdTypeDef"/> metadata token that references the metadata of a class.</param>
        /// <param name="ppClassResult">[out] A pointer to the address of an <see cref="ICorDebugClass"/> object that represents the class.</param>
        public HRESULT TryGetClassFromToken(mdTypeDef typeDef, out CorDebugClass ppClassResult)
        {
            /*HRESULT GetClassFromToken([In] mdTypeDef typeDef, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);*/
            ICorDebugClass ppClass;
            HRESULT hr = Raw.GetClassFromToken(typeDef, out ppClass);

            if (hr == HRESULT.S_OK)
                ppClassResult = new CorDebugClass(ppClass);
            else
                ppClassResult = default(CorDebugClass);

            return hr;
        }

        #endregion
        #region CreateBreakpoint

        /// <summary>
        /// This method has not been implemented in the current version of the .NET Framework.
        /// </summary>
        public CorDebugModuleBreakpoint CreateBreakpoint()
        {
            CorDebugModuleBreakpoint ppBreakpointResult;
            TryCreateBreakpoint(out ppBreakpointResult).ThrowOnNotOK();

            return ppBreakpointResult;
        }

        /// <summary>
        /// This method has not been implemented in the current version of the .NET Framework.
        /// </summary>
        public HRESULT TryCreateBreakpoint(out CorDebugModuleBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModuleBreakpoint ppBreakpoint);*/
            ICorDebugModuleBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugModuleBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugModuleBreakpoint);

            return hr;
        }

        #endregion
        #region GetMetaDataInterface

        /// <summary>
        /// Gets a metadata interface object that can be used to examine the metadata for the module.
        /// </summary>
        /// <param name="riid">[in] The reference ID that specifies the metadata interface.</param>
        /// <returns>[out] A pointer to the address of an IUnknown object that is one of the metadata interfaces.</returns>
        /// <remarks>
        /// The debugger can use the GetMetaDataInterface method to make a copy of the original metadata for a module, which
        /// it must do in order to edit that module. The debugger calls GetMetaDataInterface to get an <see cref="IMetaDataEmit"/>
        /// interface object for the module, then calls <see cref="MetaDataEmit.SaveToMemory"/> to save a copy of the module's
        /// metadata to memory.
        /// </remarks>
        public object GetMetaDataInterface(Guid riid)
        {
            object ppObj;
            TryGetMetaDataInterface(riid, out ppObj).ThrowOnNotOK();

            return ppObj;
        }

        /// <summary>
        /// Gets a metadata interface object that can be used to examine the metadata for the module.
        /// </summary>
        /// <param name="riid">[in] The reference ID that specifies the metadata interface.</param>
        /// <param name="ppObj">[out] A pointer to the address of an IUnknown object that is one of the metadata interfaces.</param>
        /// <remarks>
        /// The debugger can use the GetMetaDataInterface method to make a copy of the original metadata for a module, which
        /// it must do in order to edit that module. The debugger calls GetMetaDataInterface to get an <see cref="IMetaDataEmit"/>
        /// interface object for the module, then calls <see cref="MetaDataEmit.SaveToMemory"/> to save a copy of the module's
        /// metadata to memory.
        /// </remarks>
        public HRESULT TryGetMetaDataInterface(Guid riid, out object ppObj)
        {
            /*HRESULT GetMetaDataInterface([In] ref Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppObj);*/
            return Raw.GetMetaDataInterface(ref riid, out ppObj);
        }

        #endregion
        #region GetGlobalVariableValue

        /// <summary>
        /// Gets the value of the specified global variable.
        /// </summary>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that references the metadata describing the global variable.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified global variable.</returns>
        public CorDebugValue GetGlobalVariableValue(mdFieldDef fieldDef)
        {
            CorDebugValue ppValueResult;
            TryGetGlobalVariableValue(fieldDef, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of the specified global variable.
        /// </summary>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that references the metadata describing the global variable.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified global variable.</param>
        public HRESULT TryGetGlobalVariableValue(mdFieldDef fieldDef, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetGlobalVariableValue([In] mdFieldDef fieldDef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetGlobalVariableValue(fieldDef, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugModule2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugModule2 Raw2 => (ICorDebugModule2) Raw;

        #region JITCompilerFlags

        /// <summary>
        /// Gets or sets the flags that control the just-in-time (JIT) compilation of this <see cref="ICorDebugModule2"/>.
        /// </summary>
        public int JITCompilerFlags
        {
            get
            {
                int pdwFlags;
                TryGetJITCompilerFlags(out pdwFlags).ThrowOnNotOK();

                return pdwFlags;
            }
            set
            {
                TrySetJITCompilerFlags(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Gets the flags that control the just-in-time (JIT) compilation of this <see cref="ICorDebugModule2"/>.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a value of the <see cref="CorDebugJITCompilerFlags"/> enumeration that controls the JIT compilation.</param>
        public HRESULT TryGetJITCompilerFlags(out int pdwFlags)
        {
            /*HRESULT GetJITCompilerFlags([Out] out int pdwFlags);*/
            return Raw2.GetJITCompilerFlags(out pdwFlags);
        }

        /// <summary>
        /// Sets the flags that control the just-in-time (JIT) compilation of this <see cref="ICorDebugModule2"/>.
        /// </summary>
        /// <param name="dwFlags">[in] A bitwise combination of the <see cref="CorDebugJITCompilerFlags"/> enumeration values.</param>
        /// <remarks>
        /// If the dwFlags value is invalid, the SetJITCompilerFlags method will fail. The SetJITCompilerFlags method can be
        /// called only from within the <see cref="ICorDebugManagedCallback.LoadModule"/> callback for this module. Attempts
        /// to call it after the <see cref="ICorDebugManagedCallback.LoadModule"/> callback has been delivered will fail. Edit and Continue
        /// is not supported on 64-bit or Win9x platforms. Therefore, if you call the SetJITCompilerFlags method on either
        /// of these two platforms with the CORDEBUG_JIT_ENABLE_ENC flag set in dwFlags, the SetJITCompilerFlags method and
        /// all methods specific to Edit and Continue, such as <see cref="ApplyChanges"/>, will fail.
        /// </remarks>
        public HRESULT TrySetJITCompilerFlags(int dwFlags)
        {
            /*HRESULT SetJITCompilerFlags([In] int dwFlags);*/
            return Raw2.SetJITCompilerFlags(dwFlags);
        }

        #endregion
        #region SetJMCStatus

        /// <summary>
        /// Sets the Just My Code (JMC) status of all methods of all the classes in this <see cref="ICorDebugModule2"/> to the specified value, except those in the pTokens array, which it sets to the opposite value.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true if the code is to be debugged; otherwise, set to false.</param>
        /// <param name="cTokens">[in] The size of the pTokens array.</param>
        /// <param name="pTokens">[in] An array of <see cref="mdToken"/> values, each of which refers to a method that will have its JMC status set to !bIsJustMycode.</param>
        /// <remarks>
        /// The JMC status of each method that is specified in the pTokens array is set to the opposite of the bIsJustMycode
        /// value. The status of all other methods in this module is set to the bIsJustMycode value. The SetJMCStatus method
        /// erases all previous JMC settings in this module. The SetJMCStatus method returns an S_OK <see cref="HRESULT"/> if all functions
        /// were set successfully. It returns a CORDBG_E_FUNCTION_NOT_DEBUGGABLE <see cref="HRESULT"/> if some functions that are marked
        /// true are not debuggable.
        /// </remarks>
        public void SetJMCStatus(bool bIsJustMyCode, int cTokens, mdToken[] pTokens)
        {
            TrySetJMCStatus(bIsJustMyCode, cTokens, pTokens).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the Just My Code (JMC) status of all methods of all the classes in this <see cref="ICorDebugModule2"/> to the specified value, except those in the pTokens array, which it sets to the opposite value.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true if the code is to be debugged; otherwise, set to false.</param>
        /// <param name="cTokens">[in] The size of the pTokens array.</param>
        /// <param name="pTokens">[in] An array of <see cref="mdToken"/> values, each of which refers to a method that will have its JMC status set to !bIsJustMycode.</param>
        /// <remarks>
        /// The JMC status of each method that is specified in the pTokens array is set to the opposite of the bIsJustMycode
        /// value. The status of all other methods in this module is set to the bIsJustMycode value. The SetJMCStatus method
        /// erases all previous JMC settings in this module. The SetJMCStatus method returns an S_OK <see cref="HRESULT"/> if all functions
        /// were set successfully. It returns a CORDBG_E_FUNCTION_NOT_DEBUGGABLE <see cref="HRESULT"/> if some functions that are marked
        /// true are not debuggable.
        /// </remarks>
        public HRESULT TrySetJMCStatus(bool bIsJustMyCode, int cTokens, mdToken[] pTokens)
        {
            /*HRESULT SetJMCStatus([In] bool bIsJustMyCode, [In] int cTokens, [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] pTokens);*/
            return Raw2.SetJMCStatus(bIsJustMyCode, cTokens, pTokens);
        }

        #endregion
        #region ApplyChanges

        /// <summary>
        /// Applies the changes in the metadata and the changes in the Microsoft intermediate language (MSIL) code to the running process.
        /// </summary>
        /// <param name="cbMetadata">[in] Size, in bytes, of the delta metadata.</param>
        /// <param name="pbMetadata">[in] Buffer that contains the delta metadata. The address of the buffer is returned from the <see cref="MetaDataEmit.SaveDeltaToMemory"/> method.<para/>
        /// The relative virtual addresses (RVAs) in the metadata should be relative to the start of the MSIL code.</param>
        /// <param name="cbIL">[in] Size, in bytes, of the delta MSIL code.</param>
        /// <param name="pbIL">[in] Buffer that contains the updated MSIL code.</param>
        /// <remarks>
        /// The pbMetadata parameter is in a special delta metadata format (as output by <see cref="MetaDataEmit.SaveDeltaToMemory"/>).
        /// pbMetadata takes previous metadata as a base and describes individual changes to apply to that base. In contrast,
        /// the pbIL[] parameter contains the new MSIL for the updated method, and is meant to completely replace the previous
        /// MSIL for that method When the delta MSIL and the metadata have been created in the debugger’s memory, the debugger
        /// calls ApplyChanges to send the changes into the common language runtime (CLR). The runtime updates its metadata
        /// tables, places the new MSIL into the process, and sets up a just-in-time (JIT) compilation of the new MSIL. When
        /// the changes have been applied, the debugger should call <see cref="MetaDataEmit.ResetENCLog"/> to prepare for
        /// the next editing session. The debugger may then continue the process. Whenever the debugger calls ApplyChanges
        /// on a module that has delta metadata, it should also call <see cref="MetaDataEmit.ApplyEditAndContinue"/> with
        /// the same delta metadata on all of its copies of that module’s metadata except for the copy used to emit the changes.
        /// If a copy of the metadata somehow becomes out-of-sync with the actual metadata, the debugger can always throw away
        /// that copy and obtain a new copy. If the ApplyChanges method fails, the debug session is in an invalid state and
        /// must be restarted.
        /// </remarks>
        public void ApplyChanges(int cbMetadata, IntPtr pbMetadata, int cbIL, IntPtr pbIL)
        {
            TryApplyChanges(cbMetadata, pbMetadata, cbIL, pbIL).ThrowOnNotOK();
        }

        /// <summary>
        /// Applies the changes in the metadata and the changes in the Microsoft intermediate language (MSIL) code to the running process.
        /// </summary>
        /// <param name="cbMetadata">[in] Size, in bytes, of the delta metadata.</param>
        /// <param name="pbMetadata">[in] Buffer that contains the delta metadata. The address of the buffer is returned from the <see cref="MetaDataEmit.SaveDeltaToMemory"/> method.<para/>
        /// The relative virtual addresses (RVAs) in the metadata should be relative to the start of the MSIL code.</param>
        /// <param name="cbIL">[in] Size, in bytes, of the delta MSIL code.</param>
        /// <param name="pbIL">[in] Buffer that contains the updated MSIL code.</param>
        /// <remarks>
        /// The pbMetadata parameter is in a special delta metadata format (as output by <see cref="MetaDataEmit.SaveDeltaToMemory"/>).
        /// pbMetadata takes previous metadata as a base and describes individual changes to apply to that base. In contrast,
        /// the pbIL[] parameter contains the new MSIL for the updated method, and is meant to completely replace the previous
        /// MSIL for that method When the delta MSIL and the metadata have been created in the debugger’s memory, the debugger
        /// calls ApplyChanges to send the changes into the common language runtime (CLR). The runtime updates its metadata
        /// tables, places the new MSIL into the process, and sets up a just-in-time (JIT) compilation of the new MSIL. When
        /// the changes have been applied, the debugger should call <see cref="MetaDataEmit.ResetENCLog"/> to prepare for
        /// the next editing session. The debugger may then continue the process. Whenever the debugger calls ApplyChanges
        /// on a module that has delta metadata, it should also call <see cref="MetaDataEmit.ApplyEditAndContinue"/> with
        /// the same delta metadata on all of its copies of that module’s metadata except for the copy used to emit the changes.
        /// If a copy of the metadata somehow becomes out-of-sync with the actual metadata, the debugger can always throw away
        /// that copy and obtain a new copy. If the ApplyChanges method fails, the debug session is in an invalid state and
        /// must be restarted.
        /// </remarks>
        public HRESULT TryApplyChanges(int cbMetadata, IntPtr pbMetadata, int cbIL, IntPtr pbIL)
        {
            /*HRESULT ApplyChanges([In] int cbMetadata, [In] IntPtr pbMetadata, [In] int cbIL, [In] IntPtr pbIL);*/
            return Raw2.ApplyChanges(cbMetadata, pbMetadata, cbIL, pbIL);
        }

        #endregion
        #region ResolveAssembly

        /// <summary>
        /// Resolves the assembly referenced by the specified metadata token.
        /// </summary>
        /// <param name="tkAssemblyRef">[in] An <see cref="mdToken"/> value that references the assembly.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugAssembly"/> object that represents the assembly.</returns>
        /// <remarks>
        /// If the assembly is not already loaded when ResolveAssembly is called, an <see cref="HRESULT"/> value of CORDBG_E_CANNOT_RESOLVE_ASSEMBLY
        /// is returned.
        /// </remarks>
        public CorDebugAssembly ResolveAssembly(mdToken tkAssemblyRef)
        {
            CorDebugAssembly ppAssemblyResult;
            TryResolveAssembly(tkAssemblyRef, out ppAssemblyResult).ThrowOnNotOK();

            return ppAssemblyResult;
        }

        /// <summary>
        /// Resolves the assembly referenced by the specified metadata token.
        /// </summary>
        /// <param name="tkAssemblyRef">[in] An <see cref="mdToken"/> value that references the assembly.</param>
        /// <param name="ppAssemblyResult">[out] A pointer to the address of an <see cref="ICorDebugAssembly"/> object that represents the assembly.</param>
        /// <remarks>
        /// If the assembly is not already loaded when ResolveAssembly is called, an <see cref="HRESULT"/> value of CORDBG_E_CANNOT_RESOLVE_ASSEMBLY
        /// is returned.
        /// </remarks>
        public HRESULT TryResolveAssembly(mdToken tkAssemblyRef, out CorDebugAssembly ppAssemblyResult)
        {
            /*HRESULT ResolveAssembly([In] mdToken tkAssemblyRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);*/
            ICorDebugAssembly ppAssembly;
            HRESULT hr = Raw2.ResolveAssembly(tkAssemblyRef, out ppAssembly);

            if (hr == HRESULT.S_OK)
                ppAssemblyResult = new CorDebugAssembly(ppAssembly);
            else
                ppAssemblyResult = default(CorDebugAssembly);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugModule3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugModule3 Raw3 => (ICorDebugModule3) Raw;

        #region CreateReaderForInMemorySymbols

        /// <summary>
        /// Creates a debug symbol reader for a dynamic module.
        /// </summary>
        /// <param name="riid">[in] The IID of the COM interface to return. Typically, this is an <see cref="ISymUnmanagedReader"/>.</param>
        /// <returns>[out] Pointer to a pointer to the returned interface.</returns>
        /// <remarks>
        /// This method can also be used to create a symbol reader object for in-memory (non-dynamic) modules, but only after
        /// the symbols are first available (indicated by the <see cref="ICorDebugManagedCallback.UpdateModuleSymbols"/> callback).
        /// This method returns a new reader instance every time it is called (like CComPtrBase). Therefore, the debugger should
        /// cache the result and request a new instance only when the underlying data may have changed (that is, when a <see 
        ///cref="ICorDebugManagedCallback.LoadClass"/> callback is received). Dynamic modules do not have any symbols available
        /// until the first type has been loaded (as indicated by the <see cref="ICorDebugManagedCallback.LoadClass"/> callback).
        /// </remarks>
        public object CreateReaderForInMemorySymbols(Guid riid)
        {
            object ppObj;
            TryCreateReaderForInMemorySymbols(riid, out ppObj).ThrowOnNotOK();

            return ppObj;
        }

        /// <summary>
        /// Creates a debug symbol reader for a dynamic module.
        /// </summary>
        /// <param name="riid">[in] The IID of the COM interface to return. Typically, this is an <see cref="ISymUnmanagedReader"/>.</param>
        /// <param name="ppObj">[out] Pointer to a pointer to the returned interface.</param>
        /// <returns>
        /// * S_OK - Successfully created the reader.
        /// * CORDBG_E_MODULE_LOADED_FROM_DISK - The module is not an in-memory or dynamic module.
        /// * CORDBG_E_SYMBOLS_NOT_AVAILABLE - Symbols have not been supplied by the application or are not yet available.
        /// * E_FAIL (or other E_ return codes) - Unable to create the reader.
        /// </returns>
        /// <remarks>
        /// This method can also be used to create a symbol reader object for in-memory (non-dynamic) modules, but only after
        /// the symbols are first available (indicated by the <see cref="ICorDebugManagedCallback.UpdateModuleSymbols"/> callback).
        /// This method returns a new reader instance every time it is called (like CComPtrBase). Therefore, the debugger should
        /// cache the result and request a new instance only when the underlying data may have changed (that is, when a <see 
        ///cref="ICorDebugManagedCallback.LoadClass"/> callback is received). Dynamic modules do not have any symbols available
        /// until the first type has been loaded (as indicated by the <see cref="ICorDebugManagedCallback.LoadClass"/> callback).
        /// </remarks>
        public HRESULT TryCreateReaderForInMemorySymbols(Guid riid, out object ppObj)
        {
            /*HRESULT CreateReaderForInMemorySymbols(
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface), Out] out object ppObj);*/
            return Raw3.CreateReaderForInMemorySymbols(ref riid, out ppObj);
        }

        #endregion
        #endregion
    }
}

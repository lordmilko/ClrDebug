using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugModule : ComObject<ICorDebugModule>
    {
        public CorDebugModule(ICorDebugModule raw) : base(raw)
        {
        }

        #region ICorDebugModule
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
        #region GetBaseAddress

        public CORDB_ADDRESS BaseAddress
        {
            get
            {
                HRESULT hr;
                CORDB_ADDRESS pAddress;

                if ((hr = TryGetBaseAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        public HRESULT TryGetBaseAddress(out CORDB_ADDRESS pAddress)
        {
            /*HRESULT GetBaseAddress(out CORDB_ADDRESS pAddress);*/
            return Raw.GetBaseAddress(out pAddress);
        }

        #endregion
        #region GetAssembly

        public CorDebugAssembly Assembly
        {
            get
            {
                HRESULT hr;
                CorDebugAssembly ppAssemblyResult;

                if ((hr = TryGetAssembly(out ppAssemblyResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppAssemblyResult;
            }
        }

        public HRESULT TryGetAssembly(out CorDebugAssembly ppAssemblyResult)
        {
            /*HRESULT GetAssembly([MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);*/
            ICorDebugAssembly ppAssembly;
            HRESULT hr = Raw.GetAssembly(out ppAssembly);

            if (hr == HRESULT.S_OK)
                ppAssemblyResult = new CorDebugAssembly(ppAssembly);
            else
                ppAssemblyResult = default(CorDebugAssembly);

            return hr;
        }

        #endregion
        #region GetEditAndContinueSnapshot

        public CorDebugEditAndContinueSnapshot EditAndContinueSnapshot
        {
            get
            {
                HRESULT hr;
                CorDebugEditAndContinueSnapshot ppEditAndContinueSnapshotResult;

                if ((hr = TryGetEditAndContinueSnapshot(out ppEditAndContinueSnapshotResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppEditAndContinueSnapshotResult;
            }
        }

        public HRESULT TryGetEditAndContinueSnapshot(out CorDebugEditAndContinueSnapshot ppEditAndContinueSnapshotResult)
        {
            /*HRESULT GetEditAndContinueSnapshot(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugEditAndContinueSnapshot ppEditAndContinueSnapshot);*/
            ICorDebugEditAndContinueSnapshot ppEditAndContinueSnapshot;
            HRESULT hr = Raw.GetEditAndContinueSnapshot(out ppEditAndContinueSnapshot);

            if (hr == HRESULT.S_OK)
                ppEditAndContinueSnapshotResult = new CorDebugEditAndContinueSnapshot(ppEditAndContinueSnapshot);
            else
                ppEditAndContinueSnapshotResult = default(CorDebugEditAndContinueSnapshot);

            return hr;
        }

        #endregion
        #region GetToken

        public mdModule Token
        {
            get
            {
                HRESULT hr;
                mdModule pToken;

                if ((hr = TryGetToken(out pToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pToken;
            }
        }

        public HRESULT TryGetToken(out mdModule pToken)
        {
            /*HRESULT GetToken(out mdModule pToken);*/
            return Raw.GetToken(out pToken);
        }

        #endregion
        #region IsDynamic

        public int IsDynamic
        {
            get
            {
                HRESULT hr;
                int pDynamic;

                if ((hr = TryIsDynamic(out pDynamic)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pDynamic;
            }
        }

        public HRESULT TryIsDynamic(out int pDynamic)
        {
            /*HRESULT IsDynamic(out int pDynamic);*/
            return Raw.IsDynamic(out pDynamic);
        }

        #endregion
        #region GetSize

        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcBytes;

                if ((hr = TryGetSize(out pcBytes)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcBytes;
            }
        }

        public HRESULT TryGetSize(out uint pcBytes)
        {
            /*HRESULT GetSize(out uint pcBytes);*/
            return Raw.GetSize(out pcBytes);
        }

        #endregion
        #region IsInMemory

        public int IsInMemory
        {
            get
            {
                HRESULT hr;
                int pInMemory;

                if ((hr = TryIsInMemory(out pInMemory)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pInMemory;
            }
        }

        public HRESULT TryIsInMemory(out int pInMemory)
        {
            /*HRESULT IsInMemory(out int pInMemory);*/
            return Raw.IsInMemory(out pInMemory);
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
            /*HRESULT GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName);*/
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
        #region EnableJITDebugging

        public void EnableJITDebugging(int bTrackJITInfo, int bAllowJitOpts)
        {
            HRESULT hr;

            if ((hr = TryEnableJITDebugging(bTrackJITInfo, bAllowJitOpts)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnableJITDebugging(int bTrackJITInfo, int bAllowJitOpts)
        {
            /*HRESULT EnableJITDebugging([In] int bTrackJITInfo, [In] int bAllowJitOpts);*/
            return Raw.EnableJITDebugging(bTrackJITInfo, bAllowJitOpts);
        }

        #endregion
        #region EnableClassLoadCallbacks

        public void EnableClassLoadCallbacks(int bClassLoadCallbacks)
        {
            HRESULT hr;

            if ((hr = TryEnableClassLoadCallbacks(bClassLoadCallbacks)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnableClassLoadCallbacks(int bClassLoadCallbacks)
        {
            /*HRESULT EnableClassLoadCallbacks([In] int bClassLoadCallbacks);*/
            return Raw.EnableClassLoadCallbacks(bClassLoadCallbacks);
        }

        #endregion
        #region GetFunctionFromToken

        public CorDebugFunction GetFunctionFromToken(mdMethodDef methodDef)
        {
            HRESULT hr;
            CorDebugFunction ppFunctionResult;

            if ((hr = TryGetFunctionFromToken(methodDef, out ppFunctionResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppFunctionResult;
        }

        public HRESULT TryGetFunctionFromToken(mdMethodDef methodDef, out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunctionFromToken([In] mdMethodDef methodDef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
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

        public CorDebugFunction GetFunctionFromRVA(ulong rva)
        {
            HRESULT hr;
            CorDebugFunction ppFunctionResult;

            if ((hr = TryGetFunctionFromRVA(rva, out ppFunctionResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppFunctionResult;
        }

        public HRESULT TryGetFunctionFromRVA(ulong rva, out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunctionFromRVA([In] ulong rva, [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
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

        public CorDebugClass GetClassFromToken(mdTypeDef typeDef)
        {
            HRESULT hr;
            CorDebugClass ppClassResult;

            if ((hr = TryGetClassFromToken(typeDef, out ppClassResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppClassResult;
        }

        public HRESULT TryGetClassFromToken(mdTypeDef typeDef, out CorDebugClass ppClassResult)
        {
            /*HRESULT GetClassFromToken([In] mdTypeDef typeDef, [MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);*/
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

        public CorDebugModuleBreakpoint CreateBreakpoint()
        {
            HRESULT hr;
            CorDebugModuleBreakpoint ppBreakpointResult;

            if ((hr = TryCreateBreakpoint(out ppBreakpointResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointResult;
        }

        public HRESULT TryCreateBreakpoint(out CorDebugModuleBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugModuleBreakpoint ppBreakpoint);*/
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

        public void GetMetaDataInterface(Guid riid)
        {
            HRESULT hr;

            if ((hr = TryGetMetaDataInterface(riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetMetaDataInterface(Guid riid)
        {
            /*HRESULT GetMetaDataInterface([In] ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppObj);*/
            object ppObj;

            return Raw.GetMetaDataInterface(ref riid, out ppObj);
        }

        #endregion
        #region GetGlobalVariableValue

        public CorDebugValue GetGlobalVariableValue(mdFieldDef fieldDef)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetGlobalVariableValue(fieldDef, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetGlobalVariableValue(mdFieldDef fieldDef, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetGlobalVariableValue([In] mdFieldDef fieldDef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
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

        public ICorDebugModule2 Raw2 => (ICorDebugModule2) Raw;

        #region GetJITCompilerFlags

        public uint JITCompilerFlags
        {
            get
            {
                HRESULT hr;
                uint pdwFlags;

                if ((hr = TryGetJITCompilerFlags(out pdwFlags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwFlags;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetJITCompilerFlags(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetJITCompilerFlags(out uint pdwFlags)
        {
            /*HRESULT GetJITCompilerFlags(out uint pdwFlags);*/
            return Raw2.GetJITCompilerFlags(out pdwFlags);
        }

        public HRESULT TrySetJITCompilerFlags(uint dwFlags)
        {
            /*HRESULT SetJITCompilerFlags([In] uint dwFlags);*/
            return Raw2.SetJITCompilerFlags(dwFlags);
        }

        #endregion
        #region SetJMCStatus

        public void SetJMCStatus(int bIsJustMyCode, uint cTokens, mdToken[] pTokens)
        {
            HRESULT hr;

            if ((hr = TrySetJMCStatus(bIsJustMyCode, cTokens, pTokens)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetJMCStatus(int bIsJustMyCode, uint cTokens, mdToken[] pTokens)
        {
            /*HRESULT SetJMCStatus([In] int bIsJustMyCode, [In] uint cTokens, [In] mdToken[] pTokens);*/
            return Raw2.SetJMCStatus(bIsJustMyCode, cTokens, pTokens);
        }

        #endregion
        #region ApplyChanges

        public void ApplyChanges(uint cbMetadata, IntPtr pbMetadata, uint cbIL, IntPtr pbIL)
        {
            HRESULT hr;

            if ((hr = TryApplyChanges(cbMetadata, pbMetadata, cbIL, pbIL)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryApplyChanges(uint cbMetadata, IntPtr pbMetadata, uint cbIL, IntPtr pbIL)
        {
            /*HRESULT ApplyChanges([In] uint cbMetadata, [In] IntPtr pbMetadata, [In] uint cbIL, [In] IntPtr pbIL);*/
            return Raw2.ApplyChanges(cbMetadata, pbMetadata, cbIL, pbIL);
        }

        #endregion
        #region ResolveAssembly

        public CorDebugAssembly ResolveAssembly(mdToken tkAssemblyRef)
        {
            HRESULT hr;
            CorDebugAssembly ppAssemblyResult;

            if ((hr = TryResolveAssembly(tkAssemblyRef, out ppAssemblyResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppAssemblyResult;
        }

        public HRESULT TryResolveAssembly(mdToken tkAssemblyRef, out CorDebugAssembly ppAssemblyResult)
        {
            /*HRESULT ResolveAssembly([In] mdToken tkAssemblyRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);*/
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

        public ICorDebugModule3 Raw3 => (ICorDebugModule3) Raw;

        #region CreateReaderForInMemorySymbols

        public void CreateReaderForInMemorySymbols(Guid riid)
        {
            HRESULT hr;

            if ((hr = TryCreateReaderForInMemorySymbols(riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCreateReaderForInMemorySymbols(Guid riid)
        {
            /*HRESULT CreateReaderForInMemorySymbols([In] ref Guid riid, out IntPtr ppObj);*/
            IntPtr ppObj;

            return Raw3.CreateReaderForInMemorySymbols(ref riid, out ppObj);
        }

        #endregion
        #endregion
    }
}
namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides a query context for debug symbols.
    /// </summary>
    /// <remarks>
    /// It is important to call the <see cref="LoadAddress"/> property after creating the IDiaSession object — and the
    /// value passed to the put_loadAddress method must be non-zero — for any virtual address (VA) properties of symbols
    /// to be accessible. The load address comes from whatever program loaded the executable being debugged. For example,
    /// you can call the Win32 function GetModuleInformation to retrieve the load address for the executable, given a handle
    /// to the executable.
    /// </remarks>
    public class DiaSession : ComObject<IDiaSession>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaSession"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaSession(IDiaSession raw) : base(raw)
        {
        }

        #region IDiaSession
        #region LoadAddress

        /// <summary>
        /// Retrieves the load address for the executable file that corresponds to the symbols in this symbol store.
        /// </summary>
        public long LoadAddress
        {
            get
            {
                long pRetVal;
                TryGetLoadAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
            set
            {
                TryPutLoadAddress(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Retrieves the load address for the executable file that corresponds to the symbols in this symbol store.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a virtual address (VA) where an .exe file or .dll file is loaded.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The returned load address is always zero unless specifically set using the <see cref="LoadAddress"/> property.
        /// </remarks>
        public HRESULT TryGetLoadAddress(out long pRetVal)
        {
            /*HRESULT get_loadAddress(
            [Out] out long pRetVal);*/
            return Raw.get_loadAddress(out pRetVal);
        }

        /// <summary>
        /// Sets the load address for the executable file that corresponds to the symbols in this symbol store.
        /// </summary>
        /// <param name="newVal">[in] Load address for the executable file.</param>
        /// <remarks>
        /// Symbol virtual address (VA) properties are computed using the value of this method. Virtual addresses are not calculated
        /// unless this property is set to non-zero.
        /// </remarks>
        public HRESULT TryPutLoadAddress(long newVal)
        {
            /*HRESULT put_loadAddress(
            [In] long NewVal);*/
            return Raw.put_loadAddress(newVal);
        }

        #endregion
        #region GlobalScope

        /// <summary>
        /// Retrieves a reference to the global scope.
        /// </summary>
        public DiaSymbol GlobalScope
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetGlobalScope(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a reference to the global scope.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an <see cref="IDiaSymbol"/> object that represents the global scope.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetGlobalScope(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_globalScope(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_globalScope(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region EnumTables

        /// <summary>
        /// Retrieves an enumerator for all tables contained in the symbol store.
        /// </summary>
        public DiaEnumTables EnumTables
        {
            get
            {
                DiaEnumTables ppEnumTablesResult;
                TryGetEnumTables(out ppEnumTablesResult).ThrowOnNotOK();

                return ppEnumTablesResult;
            }
        }

        /// <summary>
        /// Retrieves an enumerator for all tables contained in the symbol store.
        /// </summary>
        /// <param name="ppEnumTablesResult">[out] Returns an <see cref="IDiaEnumTables"/> object. Use this interface to enumerate the tables in the symbol store.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetEnumTables(out DiaEnumTables ppEnumTablesResult)
        {
            /*HRESULT getEnumTables(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumTables ppEnumTables);*/
            IDiaEnumTables ppEnumTables;
            HRESULT hr = Raw.getEnumTables(out ppEnumTables);

            if (hr == HRESULT.S_OK)
                ppEnumTablesResult = ppEnumTables == null ? null : new DiaEnumTables(ppEnumTables);
            else
                ppEnumTablesResult = default(DiaEnumTables);

            return hr;
        }

        #endregion
        #region SymbolsByAddr

        /// <summary>
        /// Retrieves an enumerator that finds symbols in the order of their addresses.
        /// </summary>
        public DiaEnumSymbolsByAddr SymbolsByAddr
        {
            get
            {
                DiaEnumSymbolsByAddr ppEnumbyAddrResult;
                TryGetSymbolsByAddr(out ppEnumbyAddrResult).ThrowOnNotOK();

                return ppEnumbyAddrResult;
            }
        }

        /// <summary>
        /// Retrieves an enumerator that finds symbols in the order of their addresses.
        /// </summary>
        /// <param name="ppEnumbyAddrResult">[out] Returns an <see cref="IDiaEnumSymbolsByAddr"/> object. Use this interface to search for symbols in the symbol store by memory location.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetSymbolsByAddr(out DiaEnumSymbolsByAddr ppEnumbyAddrResult)
        {
            /*HRESULT getSymbolsByAddr(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbolsByAddr ppEnumbyAddr);*/
            IDiaEnumSymbolsByAddr ppEnumbyAddr;
            HRESULT hr = Raw.getSymbolsByAddr(out ppEnumbyAddr);

            if (hr == HRESULT.S_OK)
                ppEnumbyAddrResult = ppEnumbyAddr == null ? null : new DiaEnumSymbolsByAddr(ppEnumbyAddr);
            else
                ppEnumbyAddrResult = default(DiaEnumSymbolsByAddr);

            return hr;
        }

        #endregion
        #region EnumDebugStreams

        /// <summary>
        /// Retrieves an enumerated sequence of debug data streams.
        /// </summary>
        public DiaEnumDebugStreams EnumDebugStreams
        {
            get
            {
                DiaEnumDebugStreams ppEnumDebugStreamsResult;
                TryGetEnumDebugStreams(out ppEnumDebugStreamsResult).ThrowOnNotOK();

                return ppEnumDebugStreamsResult;
            }
        }

        /// <summary>
        /// Retrieves an enumerated sequence of debug data streams.
        /// </summary>
        /// <param name="ppEnumDebugStreamsResult">[out] Returns an <see cref="IDiaEnumDebugStreams"/> object that contains a list of debug streams.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetEnumDebugStreams(out DiaEnumDebugStreams ppEnumDebugStreamsResult)
        {
            /*HRESULT getEnumDebugStreams(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreams ppEnumDebugStreams);*/
            IDiaEnumDebugStreams ppEnumDebugStreams;
            HRESULT hr = Raw.getEnumDebugStreams(out ppEnumDebugStreams);

            if (hr == HRESULT.S_OK)
                ppEnumDebugStreamsResult = ppEnumDebugStreams == null ? null : new DiaEnumDebugStreams(ppEnumDebugStreams);
            else
                ppEnumDebugStreamsResult = default(DiaEnumDebugStreams);

            return hr;
        }

        #endregion
        #region FuncMDTokenMapSize

        public int FuncMDTokenMapSize
        {
            get
            {
                int pcb;
                TryGetFuncMDTokenMapSize(out pcb).ThrowOnNotOK();

                return pcb;
            }
        }

        public HRESULT TryGetFuncMDTokenMapSize(out int pcb)
        {
            /*HRESULT getFuncMDTokenMapSize(
            [Out] out int pcb);*/
            return Raw.getFuncMDTokenMapSize(out pcb);
        }

        #endregion
        #region FuncMDTokenMap

        public byte[] FuncMDTokenMap
        {
            get
            {
                byte[] pb;
                TryGetFuncMDTokenMap(out pb).ThrowOnNotOK();

                return pb;
            }
        }

        public HRESULT TryGetFuncMDTokenMap(out byte[] pb)
        {
            /*HRESULT getFuncMDTokenMap(
            [In] int cb,
            [Out] out int pcb,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pb);*/
            int cb = 0;
            int pcb;
            pb = null;
            HRESULT hr = Raw.getFuncMDTokenMap(cb, out pcb, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cb = pcb;
            pb = new byte[cb];
            hr = Raw.getFuncMDTokenMap(cb, out pcb, pb);
            fail:
            return hr;
        }

        #endregion
        #region TypeMDTokenMapSize

        public int TypeMDTokenMapSize
        {
            get
            {
                int pcb;
                TryGetTypeMDTokenMapSize(out pcb).ThrowOnNotOK();

                return pcb;
            }
        }

        public HRESULT TryGetTypeMDTokenMapSize(out int pcb)
        {
            /*HRESULT getTypeMDTokenMapSize(
            [Out] out int pcb);*/
            return Raw.getTypeMDTokenMapSize(out pcb);
        }

        #endregion
        #region TypeMDTokenMap

        public byte[] TypeMDTokenMap
        {
            get
            {
                byte[] pb;
                TryGetTypeMDTokenMap(out pb).ThrowOnNotOK();

                return pb;
            }
        }

        public HRESULT TryGetTypeMDTokenMap(out byte[] pb)
        {
            /*HRESULT getTypeMDTokenMap(
            [In] int cb,
            [Out] out int pcb,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pb);*/
            int cb = 0;
            int pcb;
            pb = null;
            HRESULT hr = Raw.getTypeMDTokenMap(cb, out pcb, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cb = pcb;
            pb = new byte[cb];
            hr = Raw.getTypeMDTokenMap(cb, out pcb, pb);
            fail:
            return hr;
        }

        #endregion
        #region Exports

        public DiaEnumSymbols Exports
        {
            get
            {
                DiaEnumSymbols ppResultResult;
                TryGetExports(out ppResultResult).ThrowOnNotOK();

                return ppResultResult;
            }
        }

        public HRESULT TryGetExports(out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT getExports(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.getExports(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region HeapAllocationSites

        public DiaEnumSymbols HeapAllocationSites
        {
            get
            {
                DiaEnumSymbols ppResultResult;
                TryGetHeapAllocationSites(out ppResultResult).ThrowOnNotOK();

                return ppResultResult;
            }
        }

        public HRESULT TryGetHeapAllocationSites(out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT getHeapAllocationSites(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.getHeapAllocationSites(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildren

        /// <summary>
        /// Retrieves all children of a specified parent identifier that match the name and symbol type.
        /// </summary>
        /// <param name="parent">[in] An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult.<para/>
        /// If the parent symbol is a type, then its class children are returned. If this parameter is NULL, then symtag must be set to SymTagExe or SymTagNull, which returns the global scope (.exe file).</param>
        /// <param name="symTag">[in] Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration.<para/>
        /// Set to SymTagNull to retrieve all children.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</returns>
        public DiaEnumSymbols FindChildren(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildren(parent, symTag, name, compareFlags, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves all children of a specified parent identifier that match the name and symbol type.
        /// </summary>
        /// <param name="parent">[in] An <see cref="IDiaSymbol"/> object representing the parent. If this parent symbol is a function, module, or block, then its lexical children are returned in ppResult.<para/>
        /// If the parent symbol is a type, then its class children are returned. If this parameter is NULL, then symtag must be set to SymTagExe or SymTagNull, which returns the global scope (.exe file).</param>
        /// <param name="symTag">[in] Specifies the symbol tag of the children to be retrieved. Values are taken from the <see cref="SymTagEnum"/> enumeration.<para/>
        /// Set to SymTagNull to retrieve all children.</param>
        /// <param name="name">[in] Specifies the name of the children to be retrieved. Set to NULL for all children to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name matching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumSymbols"/> object that contains the list of child symbols retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindChildren(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildren(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildren(parent, symTag, name, compareFlags, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenEx

        public DiaEnumSymbols FindChildrenEx(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenEx(parent, symTag, name, compareFlags, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindChildrenEx(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenEx(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenEx(parent, symTag, name, compareFlags, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenExByAddr

        public DiaEnumSymbols FindChildrenExByAddr(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, int isect, int offset)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenExByAddr(parent, symTag, name, compareFlags, isect, offset, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindChildrenExByAddr(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, int isect, int offset, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenExByAddr(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenExByAddr(parent, symTag, name, compareFlags, isect, offset, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenExByVA

        public DiaEnumSymbols FindChildrenExByVA(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, long va)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenExByVA(parent, symTag, name, compareFlags, va, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindChildrenExByVA(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, long va, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenExByVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenExByVA(parent, symTag, name, compareFlags, va, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindChildrenExByRVA

        public DiaEnumSymbols FindChildrenExByRVA(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, int rva)
        {
            DiaEnumSymbols ppResultResult;
            TryFindChildrenExByRVA(parent, symTag, name, compareFlags, rva, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindChildrenExByRVA(IDiaSymbol parent, SymTagEnum symTag, string name, NameSearchOptions compareFlags, int rva, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findChildrenExByRVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] SymTagEnum symTag,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findChildrenExByRVA(parent, symTag, name, compareFlags, rva, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindSymbolByAddr

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified address.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</returns>
        public DiaSymbol FindSymbolByAddr(int isect, int offset, SymTagEnum symTag)
        {
            DiaSymbol ppSymbolResult;
            TryFindSymbolByAddr(isect, offset, symTag, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified address.
        /// </summary>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindSymbolByAddr(int isect, int offset, SymTagEnum symTag, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT findSymbolByAddr(
            [In] int isect,
            [In] int offset,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.findSymbolByAddr(isect, offset, symTag, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region FindSymbolByRVA

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</returns>
        public DiaSymbol FindSymbolByRVA(int rva, SymTagEnum symTag)
        {
            DiaSymbol ppSymbolResult;
            TryFindSymbolByRVA(rva, symTag, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindSymbolByRVA(int rva, SymTagEnum symTag, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT findSymbolByRVA(
            [In] int rva,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.findSymbolByRVA(rva, symTag, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region FindSymbolByVA

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address.
        /// </summary>
        /// <param name="va">[in] Specifies the virtual address.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</returns>
        public DiaSymbol FindSymbolByVA(long va, SymTagEnum symTag)
        {
            DiaSymbol ppSymbolResult;
            TryFindSymbolByVA(va, symTag, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address.
        /// </summary>
        /// <param name="va">[in] Specifies the virtual address.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindSymbolByVA(long va, SymTagEnum symTag, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT findSymbolByVA(
            [In] long va,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.findSymbolByVA(va, symTag, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region FindSymbolByToken

        /// <summary>
        /// Retrieves the symbol that contains a specified metadata token.
        /// </summary>
        /// <param name="token">[in] Specifies the token.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</returns>
        public DiaSymbol FindSymbolByToken(int token, SymTagEnum symTag)
        {
            DiaSymbol ppSymbolResult;
            TryFindSymbolByToken(token, symTag, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Retrieves the symbol that contains a specified metadata token.
        /// </summary>
        /// <param name="token">[in] Specifies the token.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindSymbolByToken(int token, SymTagEnum symTag, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT findSymbolByToken(
            [In] int token,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.findSymbolByToken(token, symTag, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region SymsAreEquiv

        /// <summary>
        /// Checks to see if two symbols are equivalent.
        /// </summary>
        /// <param name="symbolA">[in] The first <see cref="IDiaSymbol"/> object used in the comparison.</param>
        /// <param name="symbolB">[in] The second IDiaSymbol object used in the comparison.</param>
        public void SymsAreEquiv(IDiaSymbol symbolA, IDiaSymbol symbolB)
        {
            TrySymsAreEquiv(symbolA, symbolB).ThrowOnNotOK();
        }

        /// <summary>
        /// Checks to see if two symbols are equivalent.
        /// </summary>
        /// <param name="symbolA">[in] The first <see cref="IDiaSymbol"/> object used in the comparison.</param>
        /// <param name="symbolB">[in] The second IDiaSymbol object used in the comparison.</param>
        /// <returns>If the symbols are equivalent, returns S_OK; otherwise, returns S_FALSE, the symbols are not equivalent. Otherwise, return an error code.</returns>
        public HRESULT TrySymsAreEquiv(IDiaSymbol symbolA, IDiaSymbol symbolB)
        {
            /*HRESULT symsAreEquiv(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol symbolA,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol symbolB);*/
            return Raw.symsAreEquiv(symbolA, symbolB);
        }

        #endregion
        #region SymbolById

        /// <summary>
        /// Retrieves a symbol by its unique identifier.
        /// </summary>
        /// <param name="id">[in] Unique identifier.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</returns>
        /// <remarks>
        /// The specified identifier is a unique value used internally by the DIA SDK to make all symbols unique. This method
        /// can be used, for example, to retrieve the symbol representing the type of another symbol (see the example).
        /// </remarks>
        public DiaSymbol SymbolById(int id)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolById(id, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Retrieves a symbol by its unique identifier.
        /// </summary>
        /// <param name="id">[in] Unique identifier.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object that represents the symbol retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The specified identifier is a unique value used internally by the DIA SDK to make all symbols unique. This method
        /// can be used, for example, to retrieve the symbol representing the type of another symbol (see the example).
        /// </remarks>
        public HRESULT TrySymbolById(int id, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolById(
            [In] int id,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.symbolById(id, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region FindSymbolByRVAEx

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA) and offset.
        /// </summary>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public FindSymbolByRVAExResult FindSymbolByRVAEx(int rva, SymTagEnum symTag)
        {
            FindSymbolByRVAExResult result;
            TryFindSymbolByRVAEx(rva, symTag, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified relative virtual address (RVA) and offset.
        /// </summary>
        /// <param name="rva">[in] Specifies the RVA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindSymbolByRVAEx(int rva, SymTagEnum symTag, out FindSymbolByRVAExResult result)
        {
            /*HRESULT findSymbolByRVAEx(
            [In] int rva,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol,
            [Out] out int displacement);*/
            IDiaSymbol ppSymbol;
            int displacement;
            HRESULT hr = Raw.findSymbolByRVAEx(rva, symTag, out ppSymbol, out displacement);

            if (hr == HRESULT.S_OK)
                result = new FindSymbolByRVAExResult(ppSymbol == null ? null : new DiaSymbol(ppSymbol), displacement);
            else
                result = default(FindSymbolByRVAExResult);

            return hr;
        }

        #endregion
        #region FindSymbolByVAEx

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address (VA) and offset.
        /// </summary>
        /// <param name="va">[in] Specifies the VA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public FindSymbolByVAExResult FindSymbolByVAEx(long va, SymTagEnum symTag)
        {
            FindSymbolByVAExResult result;
            TryFindSymbolByVAEx(va, symTag, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves a specified symbol type that contains, or is closest to, a specified virtual address (VA) and offset.
        /// </summary>
        /// <param name="va">[in] Specifies the VA.</param>
        /// <param name="symTag">[in] Symbol type to be found. Values are taken from the <see cref="SymTagEnum"/> enumeration.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindSymbolByVAEx(long va, SymTagEnum symTag, out FindSymbolByVAExResult result)
        {
            /*HRESULT findSymbolByVAEx(
            [In] long va,
            [In] SymTagEnum symTag,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol,
            [Out] out int displacement);*/
            IDiaSymbol ppSymbol;
            int displacement;
            HRESULT hr = Raw.findSymbolByVAEx(va, symTag, out ppSymbol, out displacement);

            if (hr == HRESULT.S_OK)
                result = new FindSymbolByVAExResult(ppSymbol == null ? null : new DiaSymbol(ppSymbol), displacement);
            else
                result = default(FindSymbolByVAExResult);

            return hr;
        }

        #endregion
        #region FindFile

        /// <summary>
        /// Retrieves source files by compiland and name.
        /// </summary>
        /// <param name="pCompiland">[in] An <see cref="IDiaSymbol"/> object representing the compiland to be used as a context for the search. Set this parameter to NULL to find source files in all compilands.</param>
        /// <param name="name">[in] Specifies the name of the source file to be retrieved. Set this parameter to NULL for all source files to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumSourceFiles"/> object that contains a list of the source files retrieved.</returns>
        public DiaEnumSourceFiles FindFile(IDiaSymbol pCompiland, string name, NameSearchOptions compareFlags)
        {
            DiaEnumSourceFiles ppResultResult;
            TryFindFile(pCompiland, name, compareFlags, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves source files by compiland and name.
        /// </summary>
        /// <param name="pCompiland">[in] An <see cref="IDiaSymbol"/> object representing the compiland to be used as a context for the search. Set this parameter to NULL to find source files in all compilands.</param>
        /// <param name="name">[in] Specifies the name of the source file to be retrieved. Set this parameter to NULL for all source files to be retrieved.</param>
        /// <param name="compareFlags">[in] Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumSourceFiles"/> object that contains a list of the source files retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindFile(IDiaSymbol pCompiland, string name, NameSearchOptions compareFlags, out DiaEnumSourceFiles ppResultResult)
        {
            /*HRESULT findFile(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol pCompiland,
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] NameSearchOptions compareFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSourceFiles ppResult);*/
            IDiaEnumSourceFiles ppResult;
            HRESULT hr = Raw.findFile(pCompiland, name, compareFlags, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSourceFiles(ppResult);
            else
                ppResultResult = default(DiaEnumSourceFiles);

            return hr;
        }

        #endregion
        #region FindFileById

        /// <summary>
        /// Retrieves a source file by source file identifier.
        /// </summary>
        /// <param name="uniqueId">[in] Specifies the source file identifier.</param>
        /// <returns>[out] Returns an <see cref="IDiaSourceFile"/> object that represents the source file retrieved.</returns>
        /// <remarks>
        /// The source file identifier is a unique value used internally to the DIA SDK to make all source files unique. This
        /// method is typically used internally to the DIA SDK.
        /// </remarks>
        public DiaSourceFile FindFileById(int uniqueId)
        {
            DiaSourceFile ppResultResult;
            TryFindFileById(uniqueId, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves a source file by source file identifier.
        /// </summary>
        /// <param name="uniqueId">[in] Specifies the source file identifier.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaSourceFile"/> object that represents the source file retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The source file identifier is a unique value used internally to the DIA SDK to make all source files unique. This
        /// method is typically used internally to the DIA SDK.
        /// </remarks>
        public HRESULT TryFindFileById(int uniqueId, out DiaSourceFile ppResultResult)
        {
            /*HRESULT findFileById(
            [In] int uniqueId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile ppResult);*/
            IDiaSourceFile ppResult;
            HRESULT hr = Raw.findFileById(uniqueId, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaSourceFile(ppResult);
            else
                ppResultResult = default(DiaSourceFile);

            return hr;
        }

        #endregion
        #region FindLines

        /// <summary>
        /// Retrieves line numbers within specified compiland and source file identifiers.
        /// </summary>
        /// <param name="compiland">[in]An <see cref="IDiaSymbol"/> object representing the compiland. Use this interface as a context in which to search for the line numbers.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object representing the source file in which to search for the line numbers.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers retrieved.</returns>
        public DiaEnumLineNumbers FindLines(IDiaSymbol compiland, IDiaSourceFile file)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindLines(compiland, file, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves line numbers within specified compiland and source file identifiers.
        /// </summary>
        /// <param name="compiland">[in]An <see cref="IDiaSymbol"/> object representing the compiland. Use this interface as a context in which to search for the line numbers.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object representing the source file in which to search for the line numbers.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindLines(IDiaSymbol compiland, IDiaSourceFile file, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findLines(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol compiland,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findLines(compiland, file, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindLinesByAddr

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified address.
        /// </summary>
        /// <param name="seg">[in] Specifies the section component of the specific address.</param>
        /// <param name="offset">[in] Specifies the offset component of the specific address.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</returns>
        public DiaEnumLineNumbers FindLinesByAddr(int seg, int offset, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindLinesByAddr(seg, offset, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified address.
        /// </summary>
        /// <param name="seg">[in] Specifies the section component of the specific address.</param>
        /// <param name="offset">[in] Specifies the offset component of the specific address.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindLinesByAddr(int seg, int offset, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findLinesByAddr(
            [In] int seg,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findLinesByAddr(seg, offset, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindLinesByRVA

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</returns>
        public DiaEnumLineNumbers FindLinesByRVA(int rva, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindLinesByRVA(rva, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the lines in a specified compiland that contain a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindLinesByRVA(int rva, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findLinesByRVA(
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findLinesByRVA(rva, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindLinesByVA

        /// <summary>
        /// Retrieves the line number information for lines contained in a specified virtual address (VA) range.
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</returns>
        public DiaEnumLineNumbers FindLinesByVA(long va, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindLinesByVA(va, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves the line number information for lines contained in a specified virtual address (VA) range.
        /// </summary>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the number of bytes of address range to cover with this query.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of all the line numbers that cover the specified address range.</param>
        public HRESULT TryFindLinesByVA(long va, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findLinesByVA(
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findLinesByVA(va, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindLinesByLinenum

        /// <summary>
        /// Determines the line numbers of the compiland that the specified line number in a source file lies within or near.
        /// </summary>
        /// <param name="compiland">[in] An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be NULL.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object that represents the source file to search in. This parameter cannot be NULL.</param>
        /// <param name="linenum">[in] Specifies a one-based line number.</param>
        /// <param name="column">[in] Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumLineNumbers"/> objta that contains a list of the line numbers retrieved.</returns>
        public DiaEnumLineNumbers FindLinesByLinenum(IDiaSymbol compiland, IDiaSourceFile file, int linenum, int column)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindLinesByLinenum(compiland, file, linenum, column, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Determines the line numbers of the compiland that the specified line number in a source file lies within or near.
        /// </summary>
        /// <param name="compiland">[in] An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be NULL.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object that represents the source file to search in. This parameter cannot be NULL.</param>
        /// <param name="linenum">[in] Specifies a one-based line number.</param>
        /// <param name="column">[in] Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> objta that contains a list of the line numbers retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindLinesByLinenum(IDiaSymbol compiland, IDiaSourceFile file, int linenum, int column, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findLinesByLinenum(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol compiland,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [In] int linenum,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findLinesByLinenum(compiland, file, linenum, column, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInjectedSource

        /// <summary>
        /// Retrieves a list of sources that has been placed into the symbol store by attribute providers or other components of the compilation process.
        /// </summary>
        /// <param name="srcFile">[in] Name of the source file for which to search.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumInjectedSources"/> object that contains a list of all of the injected sources.</returns>
        public DiaEnumInjectedSources FindInjectedSource(string srcFile)
        {
            DiaEnumInjectedSources ppResultResult;
            TryFindInjectedSource(srcFile, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves a list of sources that has been placed into the symbol store by attribute providers or other components of the compilation process.
        /// </summary>
        /// <param name="srcFile">[in] Name of the source file for which to search.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumInjectedSources"/> object that contains a list of all of the injected sources.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInjectedSource(string srcFile, out DiaEnumInjectedSources ppResultResult)
        {
            /*HRESULT findInjectedSource(
            [MarshalAs(UnmanagedType.LPWStr), In] string srcFile,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInjectedSources ppResult);*/
            IDiaEnumInjectedSources ppResult;
            HRESULT hr = Raw.findInjectedSource(srcFile, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumInjectedSources(ppResult);
            else
                ppResultResult = default(DiaEnumInjectedSources);

            return hr;
        }

        #endregion
        #region FindInlineFramesByAddr

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a given address.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <returns>[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</returns>
        public DiaEnumSymbols FindInlineFramesByAddr(IDiaSymbol parent, int isect, int offset)
        {
            DiaEnumSymbols ppResultResult;
            TryFindInlineFramesByAddr(parent, isect, offset, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a given address.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineFramesByAddr(IDiaSymbol parent, int isect, int offset, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findInlineFramesByAddr(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findInlineFramesByAddr(parent, isect, offset, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindInlineFramesByRVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <returns>[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</returns>
        public DiaEnumSymbols FindInlineFramesByRVA(IDiaSymbol parent, int rva)
        {
            DiaEnumSymbols ppResultResult;
            TryFindInlineFramesByRVA(parent, rva, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineFramesByRVA(IDiaSymbol parent, int rva, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findInlineFramesByRVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findInlineFramesByRVA(parent, rva, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindInlineFramesByVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified virtual address (VA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <returns>[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</returns>
        public DiaEnumSymbols FindInlineFramesByVA(IDiaSymbol parent, long va)
        {
            DiaEnumSymbols ppResultResult;
            TryFindInlineFramesByVA(parent, va, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through all of the inline frames on a specified virtual address (VA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumSymbols object that contains the list of frames that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineFramesByVA(IDiaSymbol parent, long va, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findInlineFramesByVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findInlineFramesByVA(parent, va, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindInlineeLines

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLines(IDiaSymbol parent)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLines(parent, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLines(IDiaSymbol parent, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLines(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLines(parent, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineeLinesByAddr

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified address range.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLinesByAddr(IDiaSymbol parent, int isect, int offset, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLinesByAddr(parent, isect, offset, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified address range.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="isect">[in] Specifies the section component of the address.</param>
        /// <param name="offset">[in] Specifies the offset component of the address.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLinesByAddr(IDiaSymbol parent, int isect, int offset, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLinesByAddr(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int isect,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLinesByAddr(parent, isect, offset, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineeLinesByRVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLinesByRVA(IDiaSymbol parent, int rva, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLinesByRVA(parent, rva, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified relative virtual address (RVA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="rva">[in] Specifies the address as an RVA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLinesByRVA(IDiaSymbol parent, int rva, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLinesByRVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLinesByRVA(parent, rva, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineeLinesByVA

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified virtual address (VA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <returns>[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLinesByVA(IDiaSymbol parent, long va, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLinesByVA(parent, va, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, by the specified parent symbol and are contained within the specified virtual address (VA).
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol object representing the parent.</param>
        /// <param name="va">[in] Specifies the address as a VA.</param>
        /// <param name="length">[in] Specifies the address range, in number of bytes, to cover with this query.</param>
        /// <param name="ppResultResult">[out] Holds an IDiaEnumLineNumbers object that contains the list of line numbers that are retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLinesByVA(IDiaSymbol parent, long va, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLinesByVA(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLinesByVA(parent, va, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineeLinesByLinenum

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in the specified source file and line number.
        /// </summary>
        /// <param name="compiland">[in] An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be NULL.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object that represents the source file in which to search. This parameter cannot be NULL.</param>
        /// <param name="linenum">[in] Specifies a one-based line number.</param>
        /// <param name="column">[in] Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</returns>
        public DiaEnumLineNumbers FindInlineeLinesByLinenum(IDiaSymbol compiland, IDiaSourceFile file, int linenum, int column)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindInlineeLinesByLinenum(compiland, file, linenum, column, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all functions that are inlined, directly or indirectly, in the specified source file and line number.
        /// </summary>
        /// <param name="compiland">[in] An <see cref="IDiaSymbol"/> object that represents the compiland in which to search for the line numbers. This parameter cannot be NULL.</param>
        /// <param name="file">[in] An <see cref="IDiaSourceFile"/> object that represents the source file in which to search. This parameter cannot be NULL.</param>
        /// <param name="linenum">[in] Specifies a one-based line number.</param>
        /// <param name="column">[in] Specifies the column number. Use zero to specify all columns. A column is a byte offset into a line.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineeLinesByLinenum(IDiaSymbol compiland, IDiaSourceFile file, int linenum, int column, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findInlineeLinesByLinenum(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol compiland,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [In] int linenum,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findInlineeLinesByLinenum(compiland, file, linenum, column, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInlineesByName

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all inlined functions that match a specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name to use for comparison.</param>
        /// <param name="option">[in] Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <returns>[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</returns>
        public DiaEnumSymbols FindInlineesByName(string name, int option)
        {
            DiaEnumSymbols ppResultResult;
            TryFindInlineesByName(name, option, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Retrieves an enumeration that allows a client to iterate through the line number information of all inlined functions that match a specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name to use for comparison.</param>
        /// <param name="option">[in] Specifies the comparison options applied to name searching. Values from the <see cref="NameSearchOptions"/> enumeration can be used alone or in combination.</param>
        /// <param name="ppResultResult">[out] Returns an <see cref="IDiaEnumLineNumbers"/> object that contains a list of the line numbers that were retrieved.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindInlineesByName(string name, int option, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findInlineesByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] int option,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findInlineesByName(name, option, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindAcceleratorInlineeLinesByLinenum

        public DiaEnumLineNumbers FindAcceleratorInlineeLinesByLinenum(IDiaSymbol parent, IDiaSourceFile file, int linenum, int column)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindAcceleratorInlineeLinesByLinenum(parent, file, linenum, column, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindAcceleratorInlineeLinesByLinenum(IDiaSymbol parent, IDiaSourceFile file, int linenum, int column, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findAcceleratorInlineeLinesByLinenum(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [MarshalAs(UnmanagedType.Interface), In] IDiaSourceFile file,
            [In] int linenum,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findAcceleratorInlineeLinesByLinenum(parent, file, linenum, column, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindSymbolsForAcceleratorPointerTag

        /// <summary>
        /// Returns an enumeration of symbols for the variable that the specified tag value corresponds to in the parent Accelerator stub function.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol that corresponds to the Accelerator stub function to be searched.</param>
        /// <param name="tagValue">[in] The pointer tag value.</param>
        /// <returns>[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</returns>
        public DiaEnumSymbols FindSymbolsForAcceleratorPointerTag(IDiaSymbol parent, int tagValue)
        {
            DiaEnumSymbols ppResultResult;
            TryFindSymbolsForAcceleratorPointerTag(parent, tagValue, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Returns an enumeration of symbols for the variable that the specified tag value corresponds to in the parent Accelerator stub function.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol that corresponds to the Accelerator stub function to be searched.</param>
        /// <param name="tagValue">[in] The pointer tag value.</param>
        /// <param name="ppResultResult">[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryFindSymbolsForAcceleratorPointerTag(IDiaSymbol parent, int tagValue, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findSymbolsForAcceleratorPointerTag(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int tagValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findSymbolsForAcceleratorPointerTag(parent, tagValue, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindSymbolsByRVAForAcceleratorPointerTag

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in a specified parent Accelerator stub function at a specified relative virtual address.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol that corresponds to the Accelerator stub function to be searched.</param>
        /// <param name="tagValue">[in] The pointer tag value.</param>
        /// <param name="rva">[in] The relative virtual address.</param>
        /// <returns>[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</returns>
        /// <remarks>
        /// Call this method only on an IDiaSymbol interface that corresponds to an Accelerator stub function.
        /// </remarks>
        public DiaEnumSymbols FindSymbolsByRVAForAcceleratorPointerTag(IDiaSymbol parent, int tagValue, int rva)
        {
            DiaEnumSymbols ppResultResult;
            TryFindSymbolsByRVAForAcceleratorPointerTag(parent, tagValue, rva, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Given a corresponding tag value, this method returns an enumeration of symbols that are contained in a specified parent Accelerator stub function at a specified relative virtual address.
        /// </summary>
        /// <param name="parent">[in] An IDiaSymbol that corresponds to the Accelerator stub function to be searched.</param>
        /// <param name="tagValue">[in] The pointer tag value.</param>
        /// <param name="rva">[in] The relative virtual address.</param>
        /// <param name="ppResultResult">[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Call this method only on an IDiaSymbol interface that corresponds to an Accelerator stub function.
        /// </remarks>
        public HRESULT TryFindSymbolsByRVAForAcceleratorPointerTag(IDiaSymbol parent, int tagValue, int rva, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findSymbolsByRVAForAcceleratorPointerTag(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol parent,
            [In] int tagValue,
            [In] int rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findSymbolsByRVAForAcceleratorPointerTag(parent, tagValue, rva, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region FindAcceleratorInlineesByName

        /// <summary>
        /// Returns an enumeration of symbols for inline frames corresponding to the specified inline function name.
        /// </summary>
        /// <param name="name">[in] The inlinee function name to be searched.</param>
        /// <param name="option">[in] The name search options to be used when searching for inline frames that correspond to name. For more information, see <see cref="NameSearchOptions"/>.</param>
        /// <returns>[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</returns>
        /// <remarks>
        /// This function searches for inlinees only within Accelerator stub functions. It ignores native C++ procedure records.
        /// </remarks>
        public DiaEnumSymbols FindAcceleratorInlineesByName(string name, int option)
        {
            DiaEnumSymbols ppResultResult;
            TryFindAcceleratorInlineesByName(name, option, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// Returns an enumeration of symbols for inline frames corresponding to the specified inline function name.
        /// </summary>
        /// <param name="name">[in] The inlinee function name to be searched.</param>
        /// <param name="option">[in] The name search options to be used when searching for inline frames that correspond to name. For more information, see <see cref="NameSearchOptions"/>.</param>
        /// <param name="ppResultResult">[out] A pointer to an IDiaEnumSymbols interface pointer that is initialized with the result.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// This function searches for inlinees only within Accelerator stub functions. It ignores native C++ procedure records.
        /// </remarks>
        public HRESULT TryFindAcceleratorInlineesByName(string name, int option, out DiaEnumSymbols ppResultResult)
        {
            /*HRESULT findAcceleratorInlineesByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string name,
            [In] int option,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbols ppResult);*/
            IDiaEnumSymbols ppResult;
            HRESULT hr = Raw.findAcceleratorInlineesByName(name, option, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumSymbols(ppResult);
            else
                ppResultResult = default(DiaEnumSymbols);

            return hr;
        }

        #endregion
        #region AddressForVA

        public AddressForVAResult AddressForVA(long va)
        {
            AddressForVAResult result;
            TryAddressForVA(va, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryAddressForVA(long va, out AddressForVAResult result)
        {
            /*HRESULT addressForVA(
            [In] long va,
            [Out] out int pISect,
            [Out] out int pOffset);*/
            int pISect;
            int pOffset;
            HRESULT hr = Raw.addressForVA(va, out pISect, out pOffset);

            if (hr == HRESULT.S_OK)
                result = new AddressForVAResult(pISect, pOffset);
            else
                result = default(AddressForVAResult);

            return hr;
        }

        #endregion
        #region AddressForRVA

        public AddressForRVAResult AddressForRVA(int rva)
        {
            AddressForRVAResult result;
            TryAddressForRVA(rva, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryAddressForRVA(int rva, out AddressForRVAResult result)
        {
            /*HRESULT addressForRVA(
            [In] int rva,
            [Out] out int pISect,
            [Out] out int pOffset);*/
            int pISect;
            int pOffset;
            HRESULT hr = Raw.addressForRVA(rva, out pISect, out pOffset);

            if (hr == HRESULT.S_OK)
                result = new AddressForRVAResult(pISect, pOffset);
            else
                result = default(AddressForRVAResult);

            return hr;
        }

        #endregion
        #region FindILOffsetsByAddr

        public DiaEnumLineNumbers FindILOffsetsByAddr(int isect, int offset, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindILOffsetsByAddr(isect, offset, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindILOffsetsByAddr(int isect, int offset, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findILOffsetsByAddr(
            [In] int isect,
            [In] int offset,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findILOffsetsByAddr(isect, offset, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindILOffsetsByRVA

        public DiaEnumLineNumbers FindILOffsetsByRVA(int rva, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindILOffsetsByRVA(rva, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindILOffsetsByRVA(int rva, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findILOffsetsByRVA(
            [In] int rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findILOffsetsByRVA(rva, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindILOffsetsByVA

        public DiaEnumLineNumbers FindILOffsetsByVA(long va, int length)
        {
            DiaEnumLineNumbers ppResultResult;
            TryFindILOffsetsByVA(va, length, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindILOffsetsByVA(long va, int length, out DiaEnumLineNumbers ppResultResult)
        {
            /*HRESULT findILOffsetsByVA(
            [In] long va,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumLineNumbers ppResult);*/
            IDiaEnumLineNumbers ppResult;
            HRESULT hr = Raw.findILOffsetsByVA(va, length, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumLineNumbers(ppResult);
            else
                ppResultResult = default(DiaEnumLineNumbers);

            return hr;
        }

        #endregion
        #region FindInputAssemblyFiles

        public DiaEnumInputAssemblyFiles FindInputAssemblyFiles()
        {
            DiaEnumInputAssemblyFiles ppResultResult;
            TryFindInputAssemblyFiles(out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindInputAssemblyFiles(out DiaEnumInputAssemblyFiles ppResultResult)
        {
            /*HRESULT findInputAssemblyFiles(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInputAssemblyFiles ppResult);*/
            IDiaEnumInputAssemblyFiles ppResult;
            HRESULT hr = Raw.findInputAssemblyFiles(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaEnumInputAssemblyFiles(ppResult);
            else
                ppResultResult = default(DiaEnumInputAssemblyFiles);

            return hr;
        }

        #endregion
        #region FindInputAssembly

        public DiaInputAssemblyFile FindInputAssembly(int index)
        {
            DiaInputAssemblyFile ppResultResult;
            TryFindInputAssembly(index, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindInputAssembly(int index, out DiaInputAssemblyFile ppResultResult)
        {
            /*HRESULT findInputAssembly(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);*/
            IDiaInputAssemblyFile ppResult;
            HRESULT hr = Raw.findInputAssembly(index, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaInputAssemblyFile(ppResult);
            else
                ppResultResult = default(DiaInputAssemblyFile);

            return hr;
        }

        #endregion
        #region FindInputAssemblyById

        public DiaInputAssemblyFile FindInputAssemblyById(int uniqueId)
        {
            DiaInputAssemblyFile ppResultResult;
            TryFindInputAssemblyById(uniqueId, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindInputAssemblyById(int uniqueId, out DiaInputAssemblyFile ppResultResult)
        {
            /*HRESULT findInputAssemblyById(
            [In] int uniqueId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);*/
            IDiaInputAssemblyFile ppResult;
            HRESULT hr = Raw.findInputAssemblyById(uniqueId, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaInputAssemblyFile(ppResult);
            else
                ppResultResult = default(DiaInputAssemblyFile);

            return hr;
        }

        #endregion
        #region GetNumberOfFunctionFragments_VA

        public int GetNumberOfFunctionFragments_VA(long vaFunc, int cbFunc)
        {
            int pNumFragments;
            TryGetNumberOfFunctionFragments_VA(vaFunc, cbFunc, out pNumFragments).ThrowOnNotOK();

            return pNumFragments;
        }

        public HRESULT TryGetNumberOfFunctionFragments_VA(long vaFunc, int cbFunc, out int pNumFragments)
        {
            /*HRESULT getNumberOfFunctionFragments_VA(
            [In] long vaFunc,
            [In] int cbFunc,
            [Out] out int pNumFragments);*/
            return Raw.getNumberOfFunctionFragments_VA(vaFunc, cbFunc, out pNumFragments);
        }

        #endregion
        #region GetNumberOfFunctionFragments_RVA

        public int GetNumberOfFunctionFragments_RVA(int rvaFunc, int cbFunc)
        {
            int pNumFragments;
            TryGetNumberOfFunctionFragments_RVA(rvaFunc, cbFunc, out pNumFragments).ThrowOnNotOK();

            return pNumFragments;
        }

        public HRESULT TryGetNumberOfFunctionFragments_RVA(int rvaFunc, int cbFunc, out int pNumFragments)
        {
            /*HRESULT getNumberOfFunctionFragments_RVA(
            [In] int rvaFunc,
            [In] int cbFunc,
            [Out] out int pNumFragments);*/
            return Raw.getNumberOfFunctionFragments_RVA(rvaFunc, cbFunc, out pNumFragments);
        }

        #endregion
        #region GetFunctionFragments_VA

        public GetFunctionFragments_VAResult GetFunctionFragments_VA(long vaFunc, int cbFunc, int cFragments)
        {
            GetFunctionFragments_VAResult result;
            TryGetFunctionFragments_VA(vaFunc, cbFunc, cFragments, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFunctionFragments_VA(long vaFunc, int cbFunc, int cFragments, out GetFunctionFragments_VAResult result)
        {
            /*HRESULT getFunctionFragments_VA(
            [In] long vaFunc,
            [In] int cbFunc,
            [In] int cFragments,
            [Out] out long pVaFragment,
            [Out] out int pLenFragment);*/
            long pVaFragment;
            int pLenFragment;
            HRESULT hr = Raw.getFunctionFragments_VA(vaFunc, cbFunc, cFragments, out pVaFragment, out pLenFragment);

            if (hr == HRESULT.S_OK)
                result = new GetFunctionFragments_VAResult(pVaFragment, pLenFragment);
            else
                result = default(GetFunctionFragments_VAResult);

            return hr;
        }

        #endregion
        #region GetFunctionFragments_RVA

        public GetFunctionFragments_RVAResult GetFunctionFragments_RVA(int rvaFunc, int cbFunc, int cFragments)
        {
            GetFunctionFragments_RVAResult result;
            TryGetFunctionFragments_RVA(rvaFunc, cbFunc, cFragments, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFunctionFragments_RVA(int rvaFunc, int cbFunc, int cFragments, out GetFunctionFragments_RVAResult result)
        {
            /*HRESULT getFunctionFragments_RVA(
            [In] int rvaFunc,
            [In] int cbFunc,
            [In] int cFragments,
            [Out] out int pRvaFragment,
            [Out] out int pLenFragment);*/
            int pRvaFragment;
            int pLenFragment;
            HRESULT hr = Raw.getFunctionFragments_RVA(rvaFunc, cbFunc, cFragments, out pRvaFragment, out pLenFragment);

            if (hr == HRESULT.S_OK)
                result = new GetFunctionFragments_RVAResult(pRvaFragment, pLenFragment);
            else
                result = default(GetFunctionFragments_RVAResult);

            return hr;
        }

        #endregion
        #region FindInputAssemblyFile

        public DiaInputAssemblyFile FindInputAssemblyFile(IDiaSymbol pSymbol)
        {
            DiaInputAssemblyFile ppResultResult;
            TryFindInputAssemblyFile(pSymbol, out ppResultResult).ThrowOnNotOK();

            return ppResultResult;
        }

        public HRESULT TryFindInputAssemblyFile(IDiaSymbol pSymbol, out DiaInputAssemblyFile ppResultResult)
        {
            /*HRESULT findInputAssemblyFile(
            [MarshalAs(UnmanagedType.Interface), In] IDiaSymbol pSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile ppResult);*/
            IDiaInputAssemblyFile ppResult;
            HRESULT hr = Raw.findInputAssemblyFile(pSymbol, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new DiaInputAssemblyFile(ppResult);
            else
                ppResultResult = default(DiaInputAssemblyFile);

            return hr;
        }

        #endregion
        #endregion
    }
}

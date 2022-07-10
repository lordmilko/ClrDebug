using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugSymbols : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugSymbols = new Guid("8c31e98c-983a-48a5-9016-6fe5d667a950");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugSymbolsVtbl* Vtbl => (IDebugSymbolsVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSymbols2Vtbl* Vtbl2 => (IDebugSymbols2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSymbols3Vtbl* Vtbl3 => (IDebugSymbols3Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSymbols4Vtbl* Vtbl4 => (IDebugSymbols4Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSymbols5Vtbl* Vtbl5 => (IDebugSymbols5Vtbl*) base.Vtbl;

        #endregion
        
        public DebugSymbols(IntPtr raw) : base(raw, IID_IDebugSymbols)
        {
        }

        public DebugSymbols(IDebugSymbols raw) : base(raw)
        {
        }

        #region IDebugSymbols
        #region SymbolOptions

        /// <summary>
        /// The GetSymbolOptions method returns the engine's global symbol options.
        /// </summary>
        public SYMOPT SymbolOptions
        {
            get
            {
                SYMOPT options;
                TryGetSymbolOptions(out options).ThrowDbgEngNotOk();

                return options;
            }
            set
            {
                TrySetSymbolOptions(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetSymbolOptions method returns the engine's global symbol options.
        /// </summary>
        /// <param name="options">[out] Receives the symbol options bit-set. For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolOptions(out SYMOPT options)
        {
            InitDelegate(ref getSymbolOptions, Vtbl->GetSymbolOptions);

            /*HRESULT GetSymbolOptions(
            [Out] out SYMOPT Options);*/
            return getSymbolOptions(Raw, out options);
        }

        /// <summary>
        /// The SetSymbolOptions method changes the engine's global symbol options.
        /// </summary>
        /// <param name="options">[in] Specifies the new symbol options. Options is a bit-set; it will replace the existing symbol options. For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method will set the engine's global symbol options to those specified in Options. Unlike <see cref="AddSymbolOptions"/>,
        /// any symbol options not in the bit-set Options will be removed. After the symbol options have been changed, for
        /// each client the engine sends out notification to that client's <see cref="IDebugEventCallbacks"/> by passing the
        /// DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/> method. For more information
        /// about symbols, see Symbols.
        /// </remarks>
        public HRESULT TrySetSymbolOptions(SYMOPT options)
        {
            InitDelegate(ref setSymbolOptions, Vtbl->SetSymbolOptions);

            /*HRESULT SetSymbolOptions(
            [In] SYMOPT Options);*/
            return setSymbolOptions(Raw, options);
        }

        #endregion
        #region NumberModules

        /// <summary>
        /// The GetNumberModules method returns the number of modules in the current process's module list.
        /// </summary>
        public GetNumberModulesResult NumberModules
        {
            get
            {
                GetNumberModulesResult result;
                TryGetNumberModules(out result).ThrowDbgEngNotOk();

                return result;
            }
        }

        /// <summary>
        /// The GetNumberModules method returns the number of modules in the current process's module list.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The list of loaded and unloaded modules is maintained by Windows. The engine caches a copy of this list, but it
        /// may become out of date. <see cref="Reload"/> can be used to synchronize the engine's copy of the list with the
        /// list maintained by Windows. The unloaded modules are not tracked in all versions of Windows. Unloaded modules are
        /// tracked for user-mode targets in Microsoft Windows Server 2003 and later; for kernel-mode targets, the unloaded
        /// modules are tracked in earlier Windows versions as well. When they are tracked they are indexed after the loaded
        /// modules. Unloaded modules can be used to analyze failures caused by an attempt to call unloaded code. For more
        /// information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetNumberModules(out GetNumberModulesResult result)
        {
            InitDelegate(ref getNumberModules, Vtbl->GetNumberModules);
            /*HRESULT GetNumberModules(
            [Out] out uint Loaded,
            [Out] out uint Unloaded);*/
            uint loaded;
            uint unloaded;
            HRESULT hr = getNumberModules(Raw, out loaded, out unloaded);

            if (hr == HRESULT.S_OK)
                result = new GetNumberModulesResult(loaded, unloaded);
            else
                result = default(GetNumberModulesResult);

            return hr;
        }

        #endregion
        #region SymbolPath

        /// <summary>
        /// The GetSymbolPath method returns the symbol path.
        /// </summary>
        public string SymbolPath
        {
            get
            {
                string bufferResult;
                TryGetSymbolPath(out bufferResult).ThrowDbgEngNotOk();

                return bufferResult;
            }
            set
            {
                TrySetSymbolPath(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetSymbolPath method returns the symbol path.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server. If Buffer is NULL, this information is not returned.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public HRESULT TryGetSymbolPath(out string bufferResult)
        {
            InitDelegate(ref getSymbolPath, Vtbl->GetSymbolPath);
            /*HRESULT GetSymbolPath(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint pathSize;
            HRESULT hr = getSymbolPath(Raw, buffer, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) pathSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolPath(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetSymbolPath method sets the symbol path.
        /// </summary>
        /// <param name="path">[in] Specifies the new symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public HRESULT TrySetSymbolPath(string path)
        {
            InitDelegate(ref setSymbolPath, Vtbl->SetSymbolPath);

            /*HRESULT SetSymbolPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);*/
            return setSymbolPath(Raw, path);
        }

        #endregion
        #region ImagePath

        /// <summary>
        /// The GetImagePath method returns the executable image path.
        /// </summary>
        public string ImagePath
        {
            get
            {
                string bufferResult;
                TryGetImagePath(out bufferResult).ThrowDbgEngNotOk();

                return bufferResult;
            }
            set
            {
                TrySetImagePath(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetImagePath method returns the executable image path.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the executable image path. This is a string that contains directories separated by semicolons (;).<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        public HRESULT TryGetImagePath(out string bufferResult)
        {
            InitDelegate(ref getImagePath, Vtbl->GetImagePath);
            /*HRESULT GetImagePath(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint pathSize;
            HRESULT hr = getImagePath(Raw, buffer, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) pathSize;
            buffer = new StringBuilder(bufferSize);
            hr = getImagePath(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetImagePath method sets the executable image path.
        /// </summary>
        /// <param name="path">[in] Specifies the new executable image path. This is a string that contains directories separated by semicolons (;).</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        public HRESULT TrySetImagePath(string path)
        {
            InitDelegate(ref setImagePath, Vtbl->SetImagePath);

            /*HRESULT SetImagePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);*/
            return setImagePath(Raw, path);
        }

        #endregion
        #region SourcePath

        /// <summary>
        /// The GetSourcePath method returns the source path.
        /// </summary>
        public string SourcePath
        {
            get
            {
                string bufferResult;
                TryGetSourcePath(out bufferResult).ThrowDbgEngNotOk();

                return bufferResult;
            }
            set
            {
                TrySetSourcePath(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetSourcePath method returns the source path.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TryGetSourcePath(out string bufferResult)
        {
            InitDelegate(ref getSourcePath, Vtbl->GetSourcePath);
            /*HRESULT GetSourcePath(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint pathSize;
            HRESULT hr = getSourcePath(Raw, buffer, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) pathSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSourcePath(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetSourcePath method sets the source path.
        /// </summary>
        /// <param name="path">[in] Specifies the new source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TrySetSourcePath(string path)
        {
            InitDelegate(ref setSourcePath, Vtbl->SetSourcePath);

            /*HRESULT SetSourcePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);*/
            return setSourcePath(Raw, path);
        }

        #endregion
        #region AddSymbolOptions

        /// <summary>
        /// The AddSymbolOptions method turns on some of the engine's global symbol options.
        /// </summary>
        /// <param name="options">[in] Specifies the symbol options to turns on. Options is a bit-set that will be ORed with the existing symbol options.<para/>
        /// For a description of the bit flags, see Setting Symbol Options.</param>
        /// <remarks>
        /// After the symbol options have been changed, for each client the engine sends out notification to that client's
        /// <see cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about symbols, see Symbols.
        /// </remarks>
        public void AddSymbolOptions(SYMOPT options)
        {
            TryAddSymbolOptions(options).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AddSymbolOptions method turns on some of the engine's global symbol options.
        /// </summary>
        /// <param name="options">[in] Specifies the symbol options to turns on. Options is a bit-set that will be ORed with the existing symbol options.<para/>
        /// For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the symbol options have been changed, for each client the engine sends out notification to that client's
        /// <see cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryAddSymbolOptions(SYMOPT options)
        {
            InitDelegate(ref addSymbolOptions, Vtbl->AddSymbolOptions);

            /*HRESULT AddSymbolOptions(
            [In] SYMOPT Options);*/
            return addSymbolOptions(Raw, options);
        }

        #endregion
        #region RemoveSymbolOptions

        /// <summary>
        /// The RemoveSymbolOptions method turns off some of the engine's global symbol options.
        /// </summary>
        /// <param name="options">[in] Specifies the symbol options to turn off. Options is a bit-set; the new value of the symbol options will equal the old value AND NOT the value of Options.<para/>
        /// For a description of the bit flags, see Setting Symbol Options.</param>
        /// <remarks>
        /// After the symbol options have been changed, for each client the engine sends out notification to that client's
        /// <see cref="IDebugEventCallbacks"/> by it passing the DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about symbols, see Symbols.
        /// </remarks>
        public void RemoveSymbolOptions(SYMOPT options)
        {
            TryRemoveSymbolOptions(options).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The RemoveSymbolOptions method turns off some of the engine's global symbol options.
        /// </summary>
        /// <param name="options">[in] Specifies the symbol options to turn off. Options is a bit-set; the new value of the symbol options will equal the old value AND NOT the value of Options.<para/>
        /// For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the symbol options have been changed, for each client the engine sends out notification to that client's
        /// <see cref="IDebugEventCallbacks"/> by it passing the DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryRemoveSymbolOptions(SYMOPT options)
        {
            InitDelegate(ref removeSymbolOptions, Vtbl->RemoveSymbolOptions);

            /*HRESULT RemoveSymbolOptions(
            [In] SYMOPT Options);*/
            return removeSymbolOptions(Raw, options);
        }

        #endregion
        #region GetNameByOffset

        /// <summary>
        /// The GetNameByOffset method returns the name of the symbol at the specified location in the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol whose name is requested. Offset does not need to specify the base location of the symbol; it only needs to specify a location within the symbol's memory allocation.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public GetNameByOffsetResult GetNameByOffset(ulong offset)
        {
            GetNameByOffsetResult result;
            TryGetNameByOffset(offset, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetNameByOffset method returns the name of the symbol at the specified location in the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol whose name is requested. Offset does not need to specify the base location of the symbol; it only needs to specify a location within the symbol's memory allocation.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetNameByOffset(ulong offset, out GetNameByOffsetResult result)
        {
            InitDelegate(ref getNameByOffset, Vtbl->GetNameByOffset);
            /*HRESULT GetNameByOffset(
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            ulong displacement;
            HRESULT hr = getNameByOffset(Raw, offset, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getNameByOffset(Raw, offset, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByOffsetResult(nameBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetNameByOffsetResult);

            return hr;
        }

        #endregion
        #region GetOffsetByName

        /// <summary>
        /// The GetOffsetByName method returns the location of a symbol identified by name.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to locate. The name may be qualified by a module name (for example, mymodule!main).</param>
        /// <returns>[out] Receives the location in the target's memory address space of the base of the symbol's memory allocation.</returns>
        /// <remarks>
        /// If the name Symbol is not unique and GetOffsetByName finds multiple symbols with that name, then the ambiguity
        /// will be resolved arbitrarily. In this case the value S_FALSE will be returned. <see cref="StartSymbolMatch"/> can
        /// be used to initiate a search to determine which is the desired result. GetNameByOffset does not support pattern
        /// matching (e.g. wildcards). To find a symbol using pattern matching use StartSymbolMatch. If the module name for
        /// the symbol is known, it is best to qualify the symbol name with the module name. Otherwise the engine will search
        /// the symbols for all modules until it finds a match; this can take a long time if it has to load the symbol files
        /// for a lot of modules. If the symbol name is qualified with a module name, the engine only searches the symbols
        /// for that module. For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public ulong GetOffsetByName(string symbol)
        {
            ulong offset;
            TryGetOffsetByName(symbol, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetOffsetByName method returns the location of a symbol identified by name.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to locate. The name may be qualified by a module name (for example, mymodule!main).</param>
        /// <param name="offset">[out] Receives the location in the target's memory address space of the base of the symbol's memory allocation.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the name Symbol is not unique and GetOffsetByName finds multiple symbols with that name, then the ambiguity
        /// will be resolved arbitrarily. In this case the value S_FALSE will be returned. <see cref="StartSymbolMatch"/> can
        /// be used to initiate a search to determine which is the desired result. GetNameByOffset does not support pattern
        /// matching (e.g. wildcards). To find a symbol using pattern matching use StartSymbolMatch. If the module name for
        /// the symbol is known, it is best to qualify the symbol name with the module name. Otherwise the engine will search
        /// the symbols for all modules until it finds a match; this can take a long time if it has to load the symbol files
        /// for a lot of modules. If the symbol name is qualified with a module name, the engine only searches the symbols
        /// for that module. For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetOffsetByName(string symbol, out ulong offset)
        {
            InitDelegate(ref getOffsetByName, Vtbl->GetOffsetByName);

            /*HRESULT GetOffsetByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out ulong Offset);*/
            return getOffsetByName(Raw, symbol, out offset);
        }

        #endregion
        #region GetNearNameByOffset

        /// <summary>
        /// The GetNearNameByOffset method returns the name of a symbol that is located near the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol from which the desired symbol is determined.</param>
        /// <param name="delta">[in] Specifies the relationship between the desired symbol and the symbol located at Offset. If positive, the engine will return the symbol that is Delta symbols after the symbol located at Offset.<para/>
        /// If negative, the engine will return the symbol that is Delta symbols before the symbol located at Offset.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// By increasing or decreasing the value of Delta, these methods can be used to iterate over the target's symbols
        /// starting at a particular location. If Delta is zero, these methods behave the same way as <see cref="GetNameByOffset"/>.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public GetNearNameByOffsetResult GetNearNameByOffset(ulong offset, int delta)
        {
            GetNearNameByOffsetResult result;
            TryGetNearNameByOffset(offset, delta, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetNearNameByOffset method returns the name of a symbol that is located near the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol from which the desired symbol is determined.</param>
        /// <param name="delta">[in] Specifies the relationship between the desired symbol and the symbol located at Offset. If positive, the engine will return the symbol that is Delta symbols after the symbol located at Offset.<para/>
        /// If negative, the engine will return the symbol that is Delta symbols before the symbol located at Offset.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// By increasing or decreasing the value of Delta, these methods can be used to iterate over the target's symbols
        /// starting at a particular location. If Delta is zero, these methods behave the same way as <see cref="GetNameByOffset"/>.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetNearNameByOffset(ulong offset, int delta, out GetNearNameByOffsetResult result)
        {
            InitDelegate(ref getNearNameByOffset, Vtbl->GetNearNameByOffset);
            /*HRESULT GetNearNameByOffset(
            [In] ulong Offset,
            [In] int Delta,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            ulong displacement;
            HRESULT hr = getNearNameByOffset(Raw, offset, delta, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getNearNameByOffset(Raw, offset, delta, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNearNameByOffsetResult(nameBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetNearNameByOffsetResult);

            return hr;
        }

        #endregion
        #region GetLineByOffset

        /// <summary>
        /// The GetLineByOffset method returns the source filename and the line number within the source file of an instruction in the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the instruction for which to return the source file and line number.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public GetLineByOffsetResult GetLineByOffset(ulong offset)
        {
            GetLineByOffsetResult result;
            TryGetLineByOffset(offset, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetLineByOffset method returns the source filename and the line number within the source file of an instruction in the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the instruction for which to return the source file and line number.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetLineByOffset(ulong offset, out GetLineByOffsetResult result)
        {
            InitDelegate(ref getLineByOffset, Vtbl->GetLineByOffset);
            /*HRESULT GetLineByOffset(
            [In] ulong Offset,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);*/
            uint line;
            StringBuilder fileBuffer = null;
            int fileBufferSize = 0;
            uint fileSize;
            ulong displacement;
            HRESULT hr = getLineByOffset(Raw, offset, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileBufferSize = (int) fileSize;
            fileBuffer = new StringBuilder(fileBufferSize);
            hr = getLineByOffset(Raw, offset, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByOffsetResult(line, fileBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetLineByOffsetResult);

            return hr;
        }

        #endregion
        #region GetOffsetByLine

        /// <summary>
        /// The GetOffsetByLine method returns the location of the instruction that corresponds to a specified line in the source code.
        /// </summary>
        /// <param name="line">[in] Specifies the line number in the source file.</param>
        /// <param name="file">[in] Specifies the file name of the source file.</param>
        /// <returns>[out] Receives the location in the target's virtual address space of an instruction for the specified line.</returns>
        /// <remarks>
        /// A line in a source file might correspond to multiple instructions and this method can return any one of these instructions.
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public ulong GetOffsetByLine(uint line, string file)
        {
            ulong offset;
            TryGetOffsetByLine(line, file, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetOffsetByLine method returns the location of the instruction that corresponds to a specified line in the source code.
        /// </summary>
        /// <param name="line">[in] Specifies the line number in the source file.</param>
        /// <param name="file">[in] Specifies the file name of the source file.</param>
        /// <param name="offset">[out] Receives the location in the target's virtual address space of an instruction for the specified line.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// A line in a source file might correspond to multiple instructions and this method can return any one of these instructions.
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetOffsetByLine(uint line, string file, out ulong offset)
        {
            InitDelegate(ref getOffsetByLine, Vtbl->GetOffsetByLine);

            /*HRESULT GetOffsetByLine(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out ulong Offset);*/
            return getOffsetByLine(Raw, line, file, out offset);
        }

        #endregion
        #region GetModuleByIndex

        /// <summary>
        /// The GetModuleByIndex method returns the location of the module with the specified index.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module whose location is requested.</param>
        /// <returns>[out] Receives the location in the target's memory address space of the module.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public ulong GetModuleByIndex(uint index)
        {
            ulong @base;
            TryGetModuleByIndex(index, out @base).ThrowDbgEngNotOk();

            return @base;
        }

        /// <summary>
        /// The GetModuleByIndex method returns the location of the module with the specified index.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module whose location is requested.</param>
        /// <param name="base">[out] Receives the location in the target's memory address space of the module.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleByIndex(uint index, out ulong @base)
        {
            InitDelegate(ref getModuleByIndex, Vtbl->GetModuleByIndex);

            /*HRESULT GetModuleByIndex(
            [In] uint Index,
            [Out] out ulong Base);*/
            return getModuleByIndex(Raw, index, out @base);
        }

        #endregion
        #region GetModuleByModuleName

        /// <summary>
        /// The GetModuleByModuleName method searches through the target's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public GetModuleByModuleNameResult GetModuleByModuleName(string name, uint startIndex)
        {
            GetModuleByModuleNameResult result;
            TryGetModuleByModuleName(name, startIndex, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetModuleByModuleName method searches through the target's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleByModuleName(string name, uint startIndex, out GetModuleByModuleNameResult result)
        {
            InitDelegate(ref getModuleByModuleName, Vtbl->GetModuleByModuleName);
            /*HRESULT GetModuleByModuleName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);*/
            uint index;
            ulong @base;
            HRESULT hr = getModuleByModuleName(Raw, name, startIndex, out index, out @base);

            if (hr == HRESULT.S_OK)
                result = new GetModuleByModuleNameResult(index, @base);
            else
                result = default(GetModuleByModuleNameResult);

            return hr;
        }

        #endregion
        #region GetModuleByOffset

        /// <summary>
        /// The GetModuleByOffset method searches through the target's modules for one whose memory allocation includes the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the target's virtual address space which is inside the desired module's memory allocation -- for example, the address of a symbol belonging to the module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Starting at the specified index, this method returns the first module it finds whose memory allocation address
        /// range includes the specified location. If the target has more than one module whose memory address range includes
        /// this location, then subsequent modules can be found by repeated calls to this method with higher values of StartIndex.
        /// For more information about modules, see Modules.
        /// </remarks>
        public GetModuleByOffsetResult GetModuleByOffset(ulong offset, uint startIndex)
        {
            GetModuleByOffsetResult result;
            TryGetModuleByOffset(offset, startIndex, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetModuleByOffset method searches through the target's modules for one whose memory allocation includes the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the target's virtual address space which is inside the desired module's memory allocation -- for example, the address of a symbol belonging to the module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, this method returns the first module it finds whose memory allocation address
        /// range includes the specified location. If the target has more than one module whose memory address range includes
        /// this location, then subsequent modules can be found by repeated calls to this method with higher values of StartIndex.
        /// For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleByOffset(ulong offset, uint startIndex, out GetModuleByOffsetResult result)
        {
            InitDelegate(ref getModuleByOffset, Vtbl->GetModuleByOffset);
            /*HRESULT GetModuleByOffset(
            [In] ulong Offset,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);*/
            uint index;
            ulong @base;
            HRESULT hr = getModuleByOffset(Raw, offset, startIndex, out index, out @base);

            if (hr == HRESULT.S_OK)
                result = new GetModuleByOffsetResult(index, @base);
            else
                result = default(GetModuleByOffsetResult);

            return hr;
        }

        #endregion
        #region GetModuleNames

        /// <summary>
        /// The GetModuleNames method returns the names of the specified module.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module whose names are requested. If it is set to DEBUG_ANY_ID, the module is specified by Base.</param>
        /// <param name="base">[in] Specifies the base address of the module whose names are requested. This parameter is only used if Index is set to DEBUG_ANY_ID.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public GetModuleNamesResult GetModuleNames(uint index, ulong @base)
        {
            GetModuleNamesResult result;
            TryGetModuleNames(index, @base, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetModuleNames method returns the names of the specified module.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module whose names are requested. If it is set to DEBUG_ANY_ID, the module is specified by Base.</param>
        /// <param name="base">[in] Specifies the base address of the module whose names are requested. This parameter is only used if Index is set to DEBUG_ANY_ID.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleNames(uint index, ulong @base, out GetModuleNamesResult result)
        {
            InitDelegate(ref getModuleNames, Vtbl->GetModuleNames);
            /*HRESULT GetModuleNames(
            [In] uint Index,
            [In] ulong Base,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ImageNameBuffer,
            [In] int ImageNameBufferSize,
            [Out] out uint ImageNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ModuleNameBuffer,
            [In] int ModuleNameBufferSize,
            [Out] out uint ModuleNameSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder LoadedImageNameBuffer,
            [In] int LoadedImageNameBufferSize,
            [Out] out uint LoadedImageNameSize);*/
            StringBuilder imageNameBuffer = null;
            int imageNameBufferSize = 0;
            uint imageNameSize;
            StringBuilder moduleNameBuffer = null;
            int moduleNameBufferSize = 0;
            uint moduleNameSize;
            StringBuilder loadedImageNameBuffer = null;
            int loadedImageNameBufferSize = 0;
            uint loadedImageNameSize;
            HRESULT hr = getModuleNames(Raw, index, @base, imageNameBuffer, imageNameBufferSize, out imageNameSize, moduleNameBuffer, moduleNameBufferSize, out moduleNameSize, loadedImageNameBuffer, loadedImageNameBufferSize, out loadedImageNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            imageNameBufferSize = (int) imageNameSize;
            imageNameBuffer = new StringBuilder(imageNameBufferSize);
            moduleNameBufferSize = (int) moduleNameSize;
            moduleNameBuffer = new StringBuilder(moduleNameBufferSize);
            loadedImageNameBufferSize = (int) loadedImageNameSize;
            loadedImageNameBuffer = new StringBuilder(loadedImageNameBufferSize);
            hr = getModuleNames(Raw, index, @base, imageNameBuffer, imageNameBufferSize, out imageNameSize, moduleNameBuffer, moduleNameBufferSize, out moduleNameSize, loadedImageNameBuffer, loadedImageNameBufferSize, out loadedImageNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetModuleNamesResult(imageNameBuffer.ToString(), moduleNameBuffer.ToString(), loadedImageNameBuffer.ToString());

                return hr;
            }

            fail:
            result = default(GetModuleNamesResult);

            return hr;
        }

        #endregion
        #region GetModuleParameters

        /// <summary>
        /// The GetModuleParameters method returns parameters for modules in the target.
        /// </summary>
        /// <param name="count">[in] Specifies the number of modules whose parameters are desired.</param>
        /// <param name="bases">[in, optional] Specifies an array of locations in the target's virtual address space representing the base address of the modules whose parameters are desired.<para/>
        /// The size of this array is the value of Count. If Bases is NULL, the Start parameter is used to specify the modules by index.</param>
        /// <param name="start">[in] Specifies the index of the first module whose parameters are desired. If Bases is not NULL, this parameter is ignored.</param>
        /// <returns>[out] Receives the parameters. The size of this array is the value of Count. See <see cref="DEBUG_MODULE_PARAMETERS"/>.</returns>
        /// <remarks>
        /// In the cases when partial results are returned, the entries in the array Params corresponding to modules that could
        /// not be found have their Base field set to DEBUG_INVALID_OFFSET. See <see cref="DEBUG_MODULE_PARAMETERS"/>. For
        /// more information about modules, see Modules.
        /// </remarks>
        public DEBUG_MODULE_PARAMETERS[] GetModuleParameters(uint count, ulong[] bases, uint start)
        {
            DEBUG_MODULE_PARAMETERS[] @params;
            TryGetModuleParameters(count, bases, start, out @params).ThrowDbgEngNotOk();

            return @params;
        }

        /// <summary>
        /// The GetModuleParameters method returns parameters for modules in the target.
        /// </summary>
        /// <param name="count">[in] Specifies the number of modules whose parameters are desired.</param>
        /// <param name="bases">[in, optional] Specifies an array of locations in the target's virtual address space representing the base address of the modules whose parameters are desired.<para/>
        /// The size of this array is the value of Count. If Bases is NULL, the Start parameter is used to specify the modules by index.</param>
        /// <param name="start">[in] Specifies the index of the first module whose parameters are desired. If Bases is not NULL, this parameter is ignored.</param>
        /// <param name="params">[out] Receives the parameters. The size of this array is the value of Count. See <see cref="DEBUG_MODULE_PARAMETERS"/>.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In the cases when partial results are returned, the entries in the array Params corresponding to modules that could
        /// not be found have their Base field set to DEBUG_INVALID_OFFSET. See <see cref="DEBUG_MODULE_PARAMETERS"/>. For
        /// more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleParameters(uint count, ulong[] bases, uint start, out DEBUG_MODULE_PARAMETERS[] @params)
        {
            InitDelegate(ref getModuleParameters, Vtbl->GetModuleParameters);
            /*HRESULT GetModuleParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)]
            ulong[] Bases,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_MODULE_PARAMETERS[] Params);*/
            @params = null;
            HRESULT hr = getModuleParameters(Raw, count, bases, start, @params);

            return hr;
        }

        #endregion
        #region GetSymbolModule

        /// <summary>
        /// The GetSymbolModule method returns the base address of module which contains the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to look up. See the Remarks section for details of the syntax of this name.</param>
        /// <returns>[out] Receives the location in the target's memory address space of the base of the module. For more information, see Modules.</returns>
        /// <remarks>
        /// The string Symbol must contain an exclamation point ( ! ). If Symbol is a module-qualified symbol name (for example,
        /// mymodules!main) or if the module name is omitted (for example, !main), the engine will search for this symbol and
        /// return the module in which it is found. If Symbol contains just a module name (for example, mymodule!) the engine
        /// returns the first module with this module name. For more information about symbols, see Symbols.
        /// </remarks>
        public ulong GetSymbolModule(string symbol)
        {
            ulong @base;
            TryGetSymbolModule(symbol, out @base).ThrowDbgEngNotOk();

            return @base;
        }

        /// <summary>
        /// The GetSymbolModule method returns the base address of module which contains the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to look up. See the Remarks section for details of the syntax of this name.</param>
        /// <param name="base">[out] Receives the location in the target's memory address space of the base of the module. For more information, see Modules.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The string Symbol must contain an exclamation point ( ! ). If Symbol is a module-qualified symbol name (for example,
        /// mymodules!main) or if the module name is omitted (for example, !main), the engine will search for this symbol and
        /// return the module in which it is found. If Symbol contains just a module name (for example, mymodule!) the engine
        /// returns the first module with this module name. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolModule(string symbol, out ulong @base)
        {
            InitDelegate(ref getSymbolModule, Vtbl->GetSymbolModule);

            /*HRESULT GetSymbolModule(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out ulong Base);*/
            return getSymbolModule(Raw, symbol, out @base);
        }

        #endregion
        #region GetTypeName

        /// <summary>
        /// The GetTypeName method returns the name of the type symbol specified by its type ID and module.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <returns>[out, optional] Receives the name of the type. If NameBuffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetTypeName(ulong module, uint typeId)
        {
            string nameBufferResult;
            TryGetTypeName(module, typeId, out nameBufferResult).ThrowDbgEngNotOk();

            return nameBufferResult;
        }

        /// <summary>
        /// The GetTypeName method returns the name of the type symbol specified by its type ID and module.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="nameBufferResult">[out, optional] Receives the name of the type. If NameBuffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetTypeName(ulong module, uint typeId, out string nameBufferResult)
        {
            InitDelegate(ref getTypeName, Vtbl->GetTypeName);
            /*HRESULT GetTypeName(
            [In] ulong Module,
            [In] uint TypeId,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            HRESULT hr = getTypeName(Raw, module, typeId, nameBuffer, nameBufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getTypeName(Raw, module, typeId, nameBuffer, nameBufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                nameBufferResult = nameBuffer.ToString();

                return hr;
            }

            fail:
            nameBufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetTypeId

        /// <summary>
        /// The GetTypeId method looks up the specified type and return its type ID.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules. If Name contains a module name, Module is ignored.</param>
        /// <param name="name">[in] Specifies the name of the type whose type ID is desired. If Name is a module-qualified name (for example mymodule!main), the Module parameter is ignored.</param>
        /// <returns>[out] Receives the type ID of the symbol.</returns>
        /// <remarks>
        /// If the specified symbol is a type, these methods return the type ID for that type; otherwise, they return the type
        /// ID for the type of the symbol. A variable whose type was defined using typedef has a type ID that identifies the
        /// original type, not the type created by typedef. In the following example, the type ID of MyInstance corresponds
        /// to the name MyStruct (this correspondence can be seen by passing the type ID to <see cref="GetTypeName"/>): Moreover,
        /// calling these methods for MyStruct and MyType yields type IDs corresponding to MyStruct and MyType, respectively.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public uint GetTypeId(ulong module, string name)
        {
            uint typeId;
            TryGetTypeId(module, name, out typeId).ThrowDbgEngNotOk();

            return typeId;
        }

        /// <summary>
        /// The GetTypeId method looks up the specified type and return its type ID.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules. If Name contains a module name, Module is ignored.</param>
        /// <param name="name">[in] Specifies the name of the type whose type ID is desired. If Name is a module-qualified name (for example mymodule!main), the Module parameter is ignored.</param>
        /// <param name="typeId">[out] Receives the type ID of the symbol.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified symbol is a type, these methods return the type ID for that type; otherwise, they return the type
        /// ID for the type of the symbol. A variable whose type was defined using typedef has a type ID that identifies the
        /// original type, not the type created by typedef. In the following example, the type ID of MyInstance corresponds
        /// to the name MyStruct (this correspondence can be seen by passing the type ID to <see cref="GetTypeName"/>): Moreover,
        /// calling these methods for MyStruct and MyType yields type IDs corresponding to MyStruct and MyType, respectively.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetTypeId(ulong module, string name, out uint typeId)
        {
            InitDelegate(ref getTypeId, Vtbl->GetTypeId);

            /*HRESULT GetTypeId(
            [In] ulong Module,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint TypeId);*/
            return getTypeId(Raw, module, name, out typeId);
        }

        #endregion
        #region GetTypeSize

        /// <summary>
        /// The GetTypeSize method returns the number of bytes of memory an instance of the specified type requires.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module containing the type. For more information, see Modules.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <returns>[out] Receives the number of bytes of memory an instance of the specified type requires.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public uint GetTypeSize(ulong module, uint typeId)
        {
            uint size;
            TryGetTypeSize(module, typeId, out size).ThrowDbgEngNotOk();

            return size;
        }

        /// <summary>
        /// The GetTypeSize method returns the number of bytes of memory an instance of the specified type requires.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module containing the type. For more information, see Modules.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="size">[out] Receives the number of bytes of memory an instance of the specified type requires.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetTypeSize(ulong module, uint typeId, out uint size)
        {
            InitDelegate(ref getTypeSize, Vtbl->GetTypeSize);

            /*HRESULT GetTypeSize(
            [In] ulong Module,
            [In] uint TypeId,
            [Out] out uint Size);*/
            return getTypeSize(Raw, module, typeId, out size);
        }

        #endregion
        #region GetFieldOffset

        /// <summary>
        /// The GetFieldOffset method returns the offset of a field from the base address of an instance of a type.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type containing the field.</param>
        /// <param name="field">[in] Specifies the name of the field whose offset is requested. Subfields may be specified by using a dot-separated path.</param>
        /// <returns>[out] Receives the offset of the specified field from the base memory location of an instance of the type.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the location
        /// of this field relative to the location of MyStruct structure can be found by setting the Field parameter to "MyField.MySubField".
        /// For more information about types, see Types.
        /// </remarks>
        public uint GetFieldOffset(ulong module, uint typeId, string field)
        {
            uint offset;
            TryGetFieldOffset(module, typeId, field, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetFieldOffset method returns the offset of a field from the base address of an instance of a type.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type containing the field.</param>
        /// <param name="field">[in] Specifies the name of the field whose offset is requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="offset">[out] Receives the offset of the specified field from the base memory location of an instance of the type.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the location
        /// of this field relative to the location of MyStruct structure can be found by setting the Field parameter to "MyField.MySubField".
        /// For more information about types, see Types.
        /// </remarks>
        public HRESULT TryGetFieldOffset(ulong module, uint typeId, string field, out uint offset)
        {
            InitDelegate(ref getFieldOffset, Vtbl->GetFieldOffset);

            /*HRESULT GetFieldOffset(
            [In] ulong Module,
            [In] uint TypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out uint Offset);*/
            return getFieldOffset(Raw, module, typeId, field, out offset);
        }

        #endregion
        #region GetSymbolTypeId

        /// <summary>
        /// The GetSymbolTypeId method returns the type ID and module of the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the expression whose type ID is requested. See the Remarks section for details on the syntax of this expression.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The Symbol expression may contain structure fields, pointer dereferencing, and array dereferencing -- for example
        /// my_struct.some_field[0]. For more information about symbols, see Symbols.
        /// </remarks>
        public GetSymbolTypeIdResult GetSymbolTypeId(string symbol)
        {
            GetSymbolTypeIdResult result;
            TryGetSymbolTypeId(symbol, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetSymbolTypeId method returns the type ID and module of the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the expression whose type ID is requested. See the Remarks section for details on the syntax of this expression.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Symbol expression may contain structure fields, pointer dereferencing, and array dereferencing -- for example
        /// my_struct.some_field[0]. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolTypeId(string symbol, out GetSymbolTypeIdResult result)
        {
            InitDelegate(ref getSymbolTypeId, Vtbl->GetSymbolTypeId);
            /*HRESULT GetSymbolTypeId(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out uint TypeId,
            [Out] out ulong Module);*/
            uint typeId;
            ulong module;
            HRESULT hr = getSymbolTypeId(Raw, symbol, out typeId, out module);

            if (hr == HRESULT.S_OK)
                result = new GetSymbolTypeIdResult(typeId, module);
            else
                result = default(GetSymbolTypeIdResult);

            return hr;
        }

        #endregion
        #region GetOffsetTypeId

        /// <summary>
        /// The GetOffsetTypeId method returns the type ID of the symbol closest to the specified memory location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory for the symbol. The symbol closest to this location is used.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public GetOffsetTypeIdResult GetOffsetTypeId(ulong offset)
        {
            GetOffsetTypeIdResult result;
            TryGetOffsetTypeId(offset, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetOffsetTypeId method returns the type ID of the symbol closest to the specified memory location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's memory for the symbol. The symbol closest to this location is used.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetOffsetTypeId(ulong offset, out GetOffsetTypeIdResult result)
        {
            InitDelegate(ref getOffsetTypeId, Vtbl->GetOffsetTypeId);
            /*HRESULT GetOffsetTypeId(
            [In] ulong Offset,
            [Out] out uint TypeId,
            [Out] out ulong Module);*/
            uint typeId;
            ulong module;
            HRESULT hr = getOffsetTypeId(Raw, offset, out typeId, out module);

            if (hr == HRESULT.S_OK)
                result = new GetOffsetTypeIdResult(typeId, module);
            else
                result = default(GetOffsetTypeIdResult);

            return hr;
        }

        #endregion
        #region ReadTypedDataVirtual

        /// <summary>
        /// The ReadTypedDataVirtual method reads the value of a variable in the target's virtual memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the variable to read.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="buffer">[out] Receives the data that is read.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be read.</param>
        /// <returns>[out, optional] Receives the number of bytes that were read. If BytesRead is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The number of bytes this method attempts to read is the smaller of the size of the buffer and the size of the variable.
        /// This is a convenience method. The same result can be obtained by calling <see cref="GetTypeSize"/> and <see cref="DebugDataSpaces.ReadVirtual"/>.
        /// For more information about types, see Types.
        /// </remarks>
        public uint ReadTypedDataVirtual(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadTypedDataVirtual(offset, module, typeId, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadTypedDataVirtual method reads the value of a variable in the target's virtual memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the variable to read.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="buffer">[out] Receives the data that is read.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be read.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes that were read. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The number of bytes this method attempts to read is the smaller of the size of the buffer and the size of the variable.
        /// This is a convenience method. The same result can be obtained by calling <see cref="GetTypeSize"/> and <see cref="DebugDataSpaces.ReadVirtual"/>.
        /// For more information about types, see Types.
        /// </remarks>
        public HRESULT TryReadTypedDataVirtual(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readTypedDataVirtual, Vtbl->ReadTypedDataVirtual);

            /*HRESULT ReadTypedDataVirtual(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readTypedDataVirtual(Raw, offset, module, typeId, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteTypedDataVirtual

        /// <summary>
        /// The WriteTypedDataVirtual method writes data to the target's virtual address space. The number of bytes written is the size of the specified type.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space where the data will be written.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="buffer">[in] Specifies the buffer containing the data to be written.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be written.</param>
        /// <returns>[out, optional] Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This is a convenience method. The same result can be obtained by calling <see cref="GetTypeSize"/> and <see cref="DebugDataSpaces.WriteVirtual"/>.
        /// For more information about types, see Types.
        /// </remarks>
        public uint WriteTypedDataVirtual(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWriteTypedDataVirtual(offset, module, typeId, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WriteTypedDataVirtual method writes data to the target's virtual address space. The number of bytes written is the size of the specified type.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space where the data will be written.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="buffer">[in] Specifies the buffer containing the data to be written.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This is a convenience method. The same result can be obtained by calling <see cref="GetTypeSize"/> and <see cref="DebugDataSpaces.WriteVirtual"/>.
        /// For more information about types, see Types.
        /// </remarks>
        public HRESULT TryWriteTypedDataVirtual(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writeTypedDataVirtual, Vtbl->WriteTypedDataVirtual);

            /*HRESULT WriteTypedDataVirtual(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writeTypedDataVirtual(Raw, offset, module, typeId, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region OutputTypedDataVirtual

        /// <summary>
        /// The OutputTypedDataVirtual method formats the contents of a variable in the target's virtual memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="flags">[in] Specifies the formatting flags. See DEBUG_TYPEOPTS_XXX for possible values.</param>
        /// <remarks>
        /// The output produced by this method is the same as for the debugger command DT. See dt (Display Type). For more
        /// information about types, see Types. For more information about output, see Input and Output.
        /// </remarks>
        public void OutputTypedDataVirtual(DEBUG_OUTCTL outputControl, ulong offset, ulong module, uint typeId, DEBUG_TYPEOPTS flags)
        {
            TryOutputTypedDataVirtual(outputControl, offset, module, typeId, flags).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputTypedDataVirtual method formats the contents of a variable in the target's virtual memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="flags">[in] Specifies the formatting flags. See DEBUG_TYPEOPTS_XXX for possible values.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The output produced by this method is the same as for the debugger command DT. See dt (Display Type). For more
        /// information about types, see Types. For more information about output, see Input and Output.
        /// </remarks>
        public HRESULT TryOutputTypedDataVirtual(DEBUG_OUTCTL outputControl, ulong offset, ulong module, uint typeId, DEBUG_TYPEOPTS flags)
        {
            InitDelegate(ref outputTypedDataVirtual, Vtbl->OutputTypedDataVirtual);

            /*HRESULT OutputTypedDataVirtual(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);*/
            return outputTypedDataVirtual(Raw, outputControl, offset, module, typeId, flags);
        }

        #endregion
        #region ReadTypedDataPhysical

        /// <summary>
        /// The ReadTypedDataPhysical method reads the value of a variable from the target computer's physical memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address in the target computer's memory of the variable to be read.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="buffer">[out] Receives the data that was read.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <returns>[out, optional] Receives the number of bytes that were read. If BytesRead is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The number of bytes this method attempts to read is the
        /// smaller of the size of the buffer and the size of the variable. This is a convenience method. The same result can
        /// be obtained by calling <see cref="GetTypeSize"/> and <see cref="DebugDataSpaces.ReadPhysical"/>. For more information
        /// about types, see Types.
        /// </remarks>
        public uint ReadTypedDataPhysical(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize)
        {
            uint bytesRead;
            TryReadTypedDataPhysical(offset, module, typeId, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOk();

            return bytesRead;
        }

        /// <summary>
        /// The ReadTypedDataPhysical method reads the value of a variable from the target computer's physical memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address in the target computer's memory of the variable to be read.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="buffer">[out] Receives the data that was read.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="bytesRead">[out, optional] Receives the number of bytes that were read. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The number of bytes this method attempts to read is the
        /// smaller of the size of the buffer and the size of the variable. This is a convenience method. The same result can
        /// be obtained by calling <see cref="GetTypeSize"/> and <see cref="DebugDataSpaces.ReadPhysical"/>. For more information
        /// about types, see Types.
        /// </remarks>
        public HRESULT TryReadTypedDataPhysical(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize, out uint bytesRead)
        {
            InitDelegate(ref readTypedDataPhysical, Vtbl->ReadTypedDataPhysical);

            /*HRESULT ReadTypedDataPhysical(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);*/
            return readTypedDataPhysical(Raw, offset, module, typeId, buffer, bufferSize, out bytesRead);
        }

        #endregion
        #region WriteTypedDataPhysical

        /// <summary>
        /// The WriteTypedDataPhysical method writes the value of a variable in the target computer's physical memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="buffer">[in] Specifies the buffer containing the data to be written.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be written.</param>
        /// <returns>[out, optional] Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The number of bytes this method attempts to write is the
        /// smaller of the size of the buffer and the size of the variable. This is a convenience method. The same result can
        /// be obtained by calling <see cref="GetTypeSize"/> and WritePhysical. For more information about types, see Types.
        /// </remarks>
        public uint WriteTypedDataPhysical(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize)
        {
            uint bytesWritten;
            TryWriteTypedDataPhysical(offset, module, typeId, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOk();

            return bytesWritten;
        }

        /// <summary>
        /// The WriteTypedDataPhysical method writes the value of a variable in the target computer's physical memory.
        /// </summary>
        /// <param name="offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="buffer">[in] Specifies the buffer containing the data to be written.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be written.</param>
        /// <param name="bytesWritten">[out, optional] Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The number of bytes this method attempts to write is the
        /// smaller of the size of the buffer and the size of the variable. This is a convenience method. The same result can
        /// be obtained by calling <see cref="GetTypeSize"/> and WritePhysical. For more information about types, see Types.
        /// </remarks>
        public HRESULT TryWriteTypedDataPhysical(ulong offset, ulong module, uint typeId, IntPtr buffer, uint bufferSize, out uint bytesWritten)
        {
            InitDelegate(ref writeTypedDataPhysical, Vtbl->WriteTypedDataPhysical);

            /*HRESULT WriteTypedDataPhysical(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);*/
            return writeTypedDataPhysical(Raw, offset, module, typeId, buffer, bufferSize, out bytesWritten);
        }

        #endregion
        #region OutputTypedDataPhysical

        /// <summary>
        /// The OutputTypedDataPhysical method formats the contents of a variable in the target computer's physical memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="flags">[in] Specifies the bit-set containing the formatting options. See DEBUG_TYPEOPTS_XXX for possible values.</param>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The output produced by this method is the same as for the
        /// debugger command DT. See dt (Display Type). For more information about types, see Types. For information about
        /// output, see Input and Output.
        /// </remarks>
        public void OutputTypedDataPhysical(DEBUG_OUTCTL outputControl, ulong offset, ulong module, uint typeId, DEBUG_TYPEOPTS flags)
        {
            TryOutputTypedDataPhysical(outputControl, offset, module, typeId, flags).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputTypedDataPhysical method formats the contents of a variable in the target computer's physical memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="flags">[in] Specifies the bit-set containing the formatting options. See DEBUG_TYPEOPTS_XXX for possible values.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The output produced by this method is the same as for the
        /// debugger command DT. See dt (Display Type). For more information about types, see Types. For information about
        /// output, see Input and Output.
        /// </remarks>
        public HRESULT TryOutputTypedDataPhysical(DEBUG_OUTCTL outputControl, ulong offset, ulong module, uint typeId, DEBUG_TYPEOPTS flags)
        {
            InitDelegate(ref outputTypedDataPhysical, Vtbl->OutputTypedDataPhysical);

            /*HRESULT OutputTypedDataPhysical(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);*/
            return outputTypedDataPhysical(Raw, outputControl, offset, module, typeId, flags);
        }

        #endregion
        #region GetScope

        /// <summary>
        /// The GetScope method returns information about the current scope.
        /// </summary>
        /// <param name="scopeContext">[out, optional] Receives the current scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer ScopeContext must be large enough to hold this structure.</param>
        /// <param name="scopeContextSize">[in] Specifies the size of the buffer ScopeContext.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public GetScopeResult GetScope(IntPtr scopeContext, uint scopeContextSize)
        {
            GetScopeResult result;
            TryGetScope(scopeContext, scopeContextSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetScope method returns information about the current scope.
        /// </summary>
        /// <param name="scopeContext">[out, optional] Receives the current scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer ScopeContext must be large enough to hold this structure.</param>
        /// <param name="scopeContextSize">[in] Specifies the size of the buffer ScopeContext.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetScope(IntPtr scopeContext, uint scopeContextSize, out GetScopeResult result)
        {
            InitDelegate(ref getScope, Vtbl->GetScope);
            /*HRESULT GetScope(
            [Out] out ulong InstructionOffset,
            [Out] out DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);*/
            ulong instructionOffset;
            DEBUG_STACK_FRAME scopeFrame;
            HRESULT hr = getScope(Raw, out instructionOffset, out scopeFrame, scopeContext, scopeContextSize);

            if (hr == HRESULT.S_OK)
                result = new GetScopeResult(instructionOffset, scopeFrame);
            else
                result = default(GetScopeResult);

            return hr;
        }

        #endregion
        #region SetScope

        /// <summary>
        /// The SetScope method sets the current scope.
        /// </summary>
        /// <param name="instructionOffset">[in] Specifies the location in the process's virtual address space for the scope's current instruction. This is only used if both ScopeFrame and ScopeContext are NULL; otherwise, it is ignored.</param>
        /// <param name="scopeFrame">[in, optional] Specifies the scope's stack frame. For information about this structure, see <see cref="DEBUG_STACK_FRAME"/>.</param>
        /// <param name="scopeContext">[in, optional] Specifies the scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer ScopeContext must be large enough to hold this structure. If ScopeContext is NULL, the current register context is used instead.</param>
        /// <param name="scopeContextSize">[in] Specifies the size of the buffer ScopeContext.</param>
        /// <remarks>
        /// If only InstructionOffset is provided, the scope can be used to look up symbol names; however, the values of these
        /// symbols will not be available. To set the scope to a previous state, ScopeContext must be provided. This is not
        /// always necessary (for example, if you only wish to access the symbols and not the registers). To set the scope
        /// to a frame on the current stack, <see cref="SetScopeFrameByIndex"/> can be used. For more information
        /// about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public void SetScope(ulong instructionOffset, DEBUG_STACK_FRAME scopeFrame, IntPtr scopeContext, uint scopeContextSize)
        {
            TrySetScope(instructionOffset, scopeFrame, scopeContext, scopeContextSize).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The SetScope method sets the current scope.
        /// </summary>
        /// <param name="instructionOffset">[in] Specifies the location in the process's virtual address space for the scope's current instruction. This is only used if both ScopeFrame and ScopeContext are NULL; otherwise, it is ignored.</param>
        /// <param name="scopeFrame">[in, optional] Specifies the scope's stack frame. For information about this structure, see <see cref="DEBUG_STACK_FRAME"/>.</param>
        /// <param name="scopeContext">[in, optional] Specifies the scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer ScopeContext must be large enough to hold this structure. If ScopeContext is NULL, the current register context is used instead.</param>
        /// <param name="scopeContextSize">[in] Specifies the size of the buffer ScopeContext.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If only InstructionOffset is provided, the scope can be used to look up symbol names; however, the values of these
        /// symbols will not be available. To set the scope to a previous state, ScopeContext must be provided. This is not
        /// always necessary (for example, if you only wish to access the symbols and not the registers). To set the scope
        /// to a frame on the current stack, <see cref="SetScopeFrameByIndex"/> can be used. For more information
        /// about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TrySetScope(ulong instructionOffset, DEBUG_STACK_FRAME scopeFrame, IntPtr scopeContext, uint scopeContextSize)
        {
            InitDelegate(ref setScope, Vtbl->SetScope);

            /*HRESULT SetScope(
            [In] ulong InstructionOffset,
            [In] DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);*/
            return setScope(Raw, instructionOffset, scopeFrame, scopeContext, scopeContextSize);
        }

        #endregion
        #region ResetScope

        /// <summary>
        /// The ResetScope method resets the current scope to the default scope of the current thread.
        /// </summary>
        /// <remarks>
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public void ResetScope()
        {
            TryResetScope().ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The ResetScope method resets the current scope to the default scope of the current thread.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryResetScope()
        {
            InitDelegate(ref resetScope, Vtbl->ResetScope);

            /*HRESULT ResetScope();*/
            return resetScope(Raw);
        }

        #endregion
        #region GetScopeSymbolGroup

        /// <summary>
        /// The GetScopeSymbolGroup method returns a symbol group containing the symbols in the current target's scope.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set used to determine which symbols to include in the symbol group. To include all symbols, set Flags to DEBUG_SCOPE_GROUP_ALL.<para/>
        /// The following bit-flags determine which symbols are included.</param>
        /// <param name="update">[in, optional] Specifies a previously created symbol group that will be updated to reflect the current scope. If Update is NULL, a new symbol group interface object is created.</param>
        /// <returns>[out] Receives the symbol group interface object for the current scope. For details on this interface, see <see cref="IDebugSymbolGroup"/></returns>
        /// <remarks>
        /// The Update parameter allows for efficient updates when stepping through code. Instead of creating and populating
        /// a new symbol group, the old symbol group can be updated. For more information about scopes and symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public DebugSymbolGroup GetScopeSymbolGroup(DEBUG_SCOPE_GROUP flags, IDebugSymbolGroup update)
        {
            DebugSymbolGroup symbolsResult;
            TryGetScopeSymbolGroup(flags, update, out symbolsResult).ThrowDbgEngNotOk();

            return symbolsResult;
        }

        /// <summary>
        /// The GetScopeSymbolGroup method returns a symbol group containing the symbols in the current target's scope.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set used to determine which symbols to include in the symbol group. To include all symbols, set Flags to DEBUG_SCOPE_GROUP_ALL.<para/>
        /// The following bit-flags determine which symbols are included.</param>
        /// <param name="update">[in, optional] Specifies a previously created symbol group that will be updated to reflect the current scope. If Update is NULL, a new symbol group interface object is created.</param>
        /// <param name="symbolsResult">[out] Receives the symbol group interface object for the current scope. For details on this interface, see <see cref="IDebugSymbolGroup"/></param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Update parameter allows for efficient updates when stepping through code. Instead of creating and populating
        /// a new symbol group, the old symbol group can be updated. For more information about scopes and symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetScopeSymbolGroup(DEBUG_SCOPE_GROUP flags, IDebugSymbolGroup update, out DebugSymbolGroup symbolsResult)
        {
            InitDelegate(ref getScopeSymbolGroup, Vtbl->GetScopeSymbolGroup);
            /*HRESULT GetScopeSymbolGroup(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugSymbolGroup Update,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup Symbols);*/
            IDebugSymbolGroup symbols;
            HRESULT hr = getScopeSymbolGroup(Raw, flags, update, out symbols);

            if (hr == HRESULT.S_OK)
                symbolsResult = new DebugSymbolGroup(symbols);
            else
                symbolsResult = default(DebugSymbolGroup);

            return hr;
        }

        #endregion
        #region CreateSymbolGroup

        /// <summary>
        /// The CreateSymbolGroup method creates a new symbol group.
        /// </summary>
        /// <returns>[out] Receives an interface pointer for the new <see cref="IDebugSymbolGroup"/> object.</returns>
        /// <remarks>
        /// The newly created symbol group is empty; it does not contain any symbols. Symbols may be added to the symbol group
        /// using <see cref="DebugSymbolGroup.AddSymbol"/>. References to the returned object are managed like other COM objects,
        /// using the IUnknown::AddRef and IUnknown::Release methods. In particular, the IUnknown::Release method must be called
        /// when the returned object is no longer needed. See Using Client Objects for more information about using COM interfaces
        /// in the Debugger Engine API. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public DebugSymbolGroup CreateSymbolGroup()
        {
            DebugSymbolGroup groupResult;
            TryCreateSymbolGroup(out groupResult).ThrowDbgEngNotOk();

            return groupResult;
        }

        /// <summary>
        /// The CreateSymbolGroup method creates a new symbol group.
        /// </summary>
        /// <param name="groupResult">[out] Receives an interface pointer for the new <see cref="IDebugSymbolGroup"/> object.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The newly created symbol group is empty; it does not contain any symbols. Symbols may be added to the symbol group
        /// using <see cref="DebugSymbolGroup.AddSymbol"/>. References to the returned object are managed like other COM objects,
        /// using the IUnknown::AddRef and IUnknown::Release methods. In particular, the IUnknown::Release method must be called
        /// when the returned object is no longer needed. See Using Client Objects for more information about using COM interfaces
        /// in the Debugger Engine API. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryCreateSymbolGroup(out DebugSymbolGroup groupResult)
        {
            InitDelegate(ref createSymbolGroup, Vtbl->CreateSymbolGroup);
            /*HRESULT CreateSymbolGroup(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup Group);*/
            IDebugSymbolGroup group;
            HRESULT hr = createSymbolGroup(Raw, out group);

            if (hr == HRESULT.S_OK)
                groupResult = new DebugSymbolGroup(group);
            else
                groupResult = default(DebugSymbolGroup);

            return hr;
        }

        #endregion
        #region StartSymbolMatch

        /// <summary>
        /// The StartSymbolMatch method initializes a search for symbols whose names match a given pattern.
        /// </summary>
        /// <param name="pattern">[in] Specifies the pattern for which to search. The search will return all symbols whose names match this pattern.<para/>
        /// For details of the syntax of the pattern, see Symbol Syntax and Symbol Matching and String Wildcard Syntax.</param>
        /// <returns>[out] Receives the handle identifying the search. This handle can be passed to <see cref="GetNextSymbolMatch"/> and <see cref="EndSymbolMatch"/>.</returns>
        /// <remarks>
        /// This method initializes a symbol search. The results of the search can be obtained by repeated calls to <see cref="GetNextSymbolMatch"/>.
        /// When all the desired results have been found, use <see cref="EndSymbolMatch"/> to release resources the engine
        /// holds for the search. For more information about symbols, see Symbols.
        /// </remarks>
        public ulong StartSymbolMatch(string pattern)
        {
            ulong handle;
            TryStartSymbolMatch(pattern, out handle).ThrowDbgEngNotOk();

            return handle;
        }

        /// <summary>
        /// The StartSymbolMatch method initializes a search for symbols whose names match a given pattern.
        /// </summary>
        /// <param name="pattern">[in] Specifies the pattern for which to search. The search will return all symbols whose names match this pattern.<para/>
        /// For details of the syntax of the pattern, see Symbol Syntax and Symbol Matching and String Wildcard Syntax.</param>
        /// <param name="handle">[out] Receives the handle identifying the search. This handle can be passed to <see cref="GetNextSymbolMatch"/> and <see cref="EndSymbolMatch"/>.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method initializes a symbol search. The results of the search can be obtained by repeated calls to <see cref="GetNextSymbolMatch"/>.
        /// When all the desired results have been found, use <see cref="EndSymbolMatch"/> to release resources the engine
        /// holds for the search. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryStartSymbolMatch(string pattern, out ulong handle)
        {
            InitDelegate(ref startSymbolMatch, Vtbl->StartSymbolMatch);

            /*HRESULT StartSymbolMatch(
            [In, MarshalAs(UnmanagedType.LPStr)] string Pattern,
            [Out] out ulong Handle);*/
            return startSymbolMatch(Raw, pattern, out handle);
        }

        #endregion
        #region GetNextSymbolMatch

        /// <summary>
        /// The GetNextSymbolMatch method returns the next symbol found in a symbol search.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The search must first be initialized by <see cref="StartSymbolMatch"/>. Once all the desired symbols have been
        /// found, <see cref="EndSymbolMatch"/> can be used to release the resources the engine holds for the search. For more
        /// information about symbols, see Symbols.
        /// </remarks>
        public GetNextSymbolMatchResult GetNextSymbolMatch(ulong handle)
        {
            GetNextSymbolMatchResult result;
            TryGetNextSymbolMatch(handle, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetNextSymbolMatch method returns the next symbol found in a symbol search.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The search must first be initialized by <see cref="StartSymbolMatch"/>. Once all the desired symbols have been
        /// found, <see cref="EndSymbolMatch"/> can be used to release the resources the engine holds for the search. For more
        /// information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetNextSymbolMatch(ulong handle, out GetNextSymbolMatchResult result)
        {
            InitDelegate(ref getNextSymbolMatch, Vtbl->GetNextSymbolMatch);
            /*HRESULT GetNextSymbolMatch(
            [In] ulong Handle,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MatchSize,
            [Out] out ulong Offset);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint matchSize;
            ulong offset;
            HRESULT hr = getNextSymbolMatch(Raw, handle, buffer, bufferSize, out matchSize, out offset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) matchSize;
            buffer = new StringBuilder(bufferSize);
            hr = getNextSymbolMatch(Raw, handle, buffer, bufferSize, out matchSize, out offset);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNextSymbolMatchResult(buffer.ToString(), offset);

                return hr;
            }

            fail:
            result = default(GetNextSymbolMatchResult);

            return hr;
        }

        #endregion
        #region EndSymbolMatch

        /// <summary>
        /// The EndSymbolMatch method releases the resources used by a symbol search.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <remarks>
        /// This method releases the resources held by the engine during a symbol search. After these resources are released,
        /// the handle becomes invalid, so it must not be passed to <see cref="GetNextSymbolMatch"/> after it has been passed
        /// to this method. For more information about symbols, see Symbols.
        /// </remarks>
        public void EndSymbolMatch(ulong handle)
        {
            TryEndSymbolMatch(handle).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The EndSymbolMatch method releases the resources used by a symbol search.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method releases the resources held by the engine during a symbol search. After these resources are released,
        /// the handle becomes invalid, so it must not be passed to <see cref="GetNextSymbolMatch"/> after it has been passed
        /// to this method. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryEndSymbolMatch(ulong handle)
        {
            InitDelegate(ref endSymbolMatch, Vtbl->EndSymbolMatch);

            /*HRESULT EndSymbolMatch(
            [In] ulong Handle);*/
            return endSymbolMatch(Raw, handle);
        }

        #endregion
        #region Reload

        /// <summary>
        /// The Reload method deletes the engine's symbol information for the specified module and reload these symbols as needed.
        /// </summary>
        /// <param name="module">[in] Specifies the module to reload.</param>
        /// <remarks>
        /// This method behaves the same way as the debugger command .reload. The Module parameter is treated the same way
        /// as the arguments to .reload. For example, setting the Module parameter to "/u ntdll.dll" has the same effect as
        /// the command .reload /u ntdll.dll. For more information about symbols, see Symbols.
        /// </remarks>
        public void Reload(string module)
        {
            TryReload(module).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The Reload method deletes the engine's symbol information for the specified module and reload these symbols as needed.
        /// </summary>
        /// <param name="module">[in] Specifies the module to reload.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method behaves the same way as the debugger command .reload. The Module parameter is treated the same way
        /// as the arguments to .reload. For example, setting the Module parameter to "/u ntdll.dll" has the same effect as
        /// the command .reload /u ntdll.dll. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryReload(string module)
        {
            InitDelegate(ref reload, Vtbl->Reload);

            /*HRESULT Reload(
            [In, MarshalAs(UnmanagedType.LPStr)] string Module);*/
            return reload(Raw, module);
        }

        #endregion
        #region AppendSymbolPath

        /// <summary>
        /// The AppendSymbolPath method appends directories to the symbol path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public void AppendSymbolPath(string addition)
        {
            TryAppendSymbolPath(addition).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AppendSymbolPath method appends directories to the symbol path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public HRESULT TryAppendSymbolPath(string addition)
        {
            InitDelegate(ref appendSymbolPath, Vtbl->AppendSymbolPath);

            /*HRESULT AppendSymbolPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);*/
            return appendSymbolPath(Raw, addition);
        }

        #endregion
        #region AppendImagePath

        /// <summary>
        /// The AppendImagePath method appends directories to the executable image path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the executable image path. This is a string that contains directory names separated by semicolons (;).</param>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons (;). These directories are searched in order.
        /// </remarks>
        public void AppendImagePath(string addition)
        {
            TryAppendImagePath(addition).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AppendImagePath method appends directories to the executable image path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the executable image path. This is a string that contains directory names separated by semicolons (;).</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons (;). These directories are searched in order.
        /// </remarks>
        public HRESULT TryAppendImagePath(string addition)
        {
            InitDelegate(ref appendImagePath, Vtbl->AppendImagePath);

            /*HRESULT AppendImagePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);*/
            return appendImagePath(Raw, addition);
        }

        #endregion
        #region GetSourcePathElement

        /// <summary>
        /// The GetSourcePathElement method returns an element from the source path.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the element in the source path that will be returned. The source path is a string that contains elements separated by semicolons (;).<para/>
        /// The index of the first element is zero.</param>
        /// <returns>[out, optional] Receives the source path element. Each source path element can be a directory or a source server.<para/>
        /// If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public string GetSourcePathElement(uint index)
        {
            string bufferResult;
            TryGetSourcePathElement(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSourcePathElement method returns an element from the source path.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the element in the source path that will be returned. The source path is a string that contains elements separated by semicolons (;).<para/>
        /// The index of the first element is zero.</param>
        /// <param name="bufferResult">[out, optional] Receives the source path element. Each source path element can be a directory or a source server.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TryGetSourcePathElement(uint index, out string bufferResult)
        {
            InitDelegate(ref getSourcePathElement, Vtbl->GetSourcePathElement);
            /*HRESULT GetSourcePathElement(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ElementSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint elementSize;
            HRESULT hr = getSourcePathElement(Raw, index, buffer, bufferSize, out elementSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) elementSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSourcePathElement(Raw, index, buffer, bufferSize, out elementSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region AppendSourcePath

        /// <summary>
        /// The AppendSourcePath method appends directories to the source path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public void AppendSourcePath(string addition)
        {
            TryAppendSourcePath(addition).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AppendSourcePath method appends directories to the source path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TryAppendSourcePath(string addition)
        {
            InitDelegate(ref appendSourcePath, Vtbl->AppendSourcePath);

            /*HRESULT AppendSourcePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);*/
            return appendSourcePath(Raw, addition);
        }

        #endregion
        #region FindSourceFile

        /// <summary>
        /// The FindSourceFile method searches the source path for a specified source file.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path.</param>
        /// <param name="file">[in] Specifies the path and file name of the file to search for.</param>
        /// <param name="flags">[in] Specifies the search flags. For a description of these flags, see DEBUG_FIND_SOURCE_XXX. The flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP should not be set.<para/>
        /// The flag DEBUG_FIND_SOURCE_NO_SRCSRV is ignored because this method does not include source servers in the search.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The engine uses the following steps--in order--to search for the file: If the flag DEBUG_FIND_SOURCE_BEST_MATCH
        /// is set, the match with the longest overlap is returned; otherwise, the first match is returned. The first match
        /// found is returned.
        /// </remarks>
        public FindSourceFileResult FindSourceFile(uint startElement, string file, DEBUG_FIND_SOURCE flags)
        {
            FindSourceFileResult result;
            TryFindSourceFile(startElement, file, flags, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The FindSourceFile method searches the source path for a specified source file.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path.</param>
        /// <param name="file">[in] Specifies the path and file name of the file to search for.</param>
        /// <param name="flags">[in] Specifies the search flags. For a description of these flags, see DEBUG_FIND_SOURCE_XXX. The flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP should not be set.<para/>
        /// The flag DEBUG_FIND_SOURCE_NO_SRCSRV is ignored because this method does not include source servers in the search.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine uses the following steps--in order--to search for the file: If the flag DEBUG_FIND_SOURCE_BEST_MATCH
        /// is set, the match with the longest overlap is returned; otherwise, the first match is returned. The first match
        /// found is returned.
        /// </remarks>
        public HRESULT TryFindSourceFile(uint startElement, string file, DEBUG_FIND_SOURCE flags, out FindSourceFileResult result)
        {
            InitDelegate(ref findSourceFile, Vtbl->FindSourceFile);
            /*HRESULT FindSourceFile(
            [In] uint StartElement,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out uint FoundElement,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FoundSize);*/
            uint foundElement;
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint foundSize;
            HRESULT hr = findSourceFile(Raw, startElement, file, flags, out foundElement, buffer, bufferSize, out foundSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) foundSize;
            buffer = new StringBuilder(bufferSize);
            hr = findSourceFile(Raw, startElement, file, flags, out foundElement, buffer, bufferSize, out foundSize);

            if (hr == HRESULT.S_OK)
            {
                result = new FindSourceFileResult(foundElement, buffer.ToString());

                return hr;
            }

            fail:
            result = default(FindSourceFileResult);

            return hr;
        }

        #endregion
        #region GetSourceFileLineOffsets

        /// <summary>
        /// The GetSourceFileLineOffsets method maps each line in a source file to a location in the target's memory.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the file whose lines will be turned into locations in the target's memory. The symbols for each module in the target are queried for this file.<para/>
        /// If the file is not located, the path is dropped and the symbols are queried again.</param>
        /// <returns>[out, optional] Receives the locations in the target's memory that correspond to the lines of the source code. The first entry returned to this array corresponds to the first line of the file, so that Buffer[i] contains the location for line i+1.<para/>
        /// If no symbol information is available for a line, the corresponding entry in Buffer is set to DEBUG_INVALID_OFFSET.<para/>
        /// If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about using the source path, see Using Source Files.
        /// </remarks>
        public ulong[] GetSourceFileLineOffsets(string file)
        {
            ulong[] buffer;
            TryGetSourceFileLineOffsets(file, out buffer).ThrowDbgEngNotOk();

            return buffer;
        }

        /// <summary>
        /// The GetSourceFileLineOffsets method maps each line in a source file to a location in the target's memory.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the file whose lines will be turned into locations in the target's memory. The symbols for each module in the target are queried for this file.<para/>
        /// If the file is not located, the path is dropped and the symbols are queried again.</param>
        /// <param name="buffer">[out, optional] Receives the locations in the target's memory that correspond to the lines of the source code. The first entry returned to this array corresponds to the first line of the file, so that Buffer[i] contains the location for line i+1.<para/>
        /// If no symbol information is available for a line, the corresponding entry in Buffer is set to DEBUG_INVALID_OFFSET.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using the source path, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetSourceFileLineOffsets(string file, out ulong[] buffer)
        {
            InitDelegate(ref getSourceFileLineOffsets, Vtbl->GetSourceFileLineOffsets);
            /*HRESULT GetSourceFileLineOffsets(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Buffer,
            [In] int BufferLines,
            [Out] out uint FileLines);*/
            buffer = null;
            int bufferLines = 0;
            uint fileLines;
            HRESULT hr = getSourceFileLineOffsets(Raw, file, buffer, bufferLines, out fileLines);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferLines = (int) fileLines;
            buffer = new ulong[bufferLines];
            hr = getSourceFileLineOffsets(Raw, file, buffer, bufferLines, out fileLines);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region IDebugSymbols2
        #region TypeOptions

        /// <summary>
        /// The GetTypeOptions method returns the type formatting options for output generated by the engine.
        /// </summary>
        public DEBUG_TYPEOPTS TypeOptions
        {
            get
            {
                DEBUG_TYPEOPTS options;
                TryGetTypeOptions(out options).ThrowDbgEngNotOk();

                return options;
            }
            set
            {
                TrySetTypeOptions(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetTypeOptions method returns the type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[out] Receives the type formatting options. Options is a bit-set; for a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see 
        ///cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TryGetTypeOptions(out DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref getTypeOptions, Vtbl2->GetTypeOptions);

            /*HRESULT GetTypeOptions(
            [Out] out DEBUG_TYPEOPTS Options);*/
            return getTypeOptions(Raw, out options);
        }

        /// <summary>
        /// The SetTypeOptions method changes the type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies the new value for the type formatting options. Options is a bit-set; it will replace the existing options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see 
        ///cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TrySetTypeOptions(DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref setTypeOptions, Vtbl2->SetTypeOptions);

            /*HRESULT SetTypeOptions(
            [In] DEBUG_TYPEOPTS Options);*/
            return setTypeOptions(Raw, options);
        }

        #endregion
        #region GetModuleVersionInformation

        /// <summary>
        /// The GetModuleVersionInformation method returns version information for the specified module.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">[in] Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="buffer">[out, optional] Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <returns>[out, optional] Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</returns>
        /// <remarks>
        /// Module version information is available only for loaded modules and may not be available in all sessions. For more
        /// information about modules, see Modules.
        /// </remarks>
        public uint GetModuleVersionInformation(uint index, ulong @base, string item, IntPtr buffer, uint bufferSize)
        {
            uint verInfoSize;
            TryGetModuleVersionInformation(index, @base, item, buffer, bufferSize, out verInfoSize).ThrowDbgEngNotOk();

            return verInfoSize;
        }

        /// <summary>
        /// The GetModuleVersionInformation method returns version information for the specified module.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">[in] Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="buffer">[out, optional] Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="verInfoSize">[out, optional] Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Module version information is available only for loaded modules and may not be available in all sessions. For more
        /// information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleVersionInformation(uint index, ulong @base, string item, IntPtr buffer, uint bufferSize, out uint verInfoSize)
        {
            InitDelegate(ref getModuleVersionInformation, Vtbl2->GetModuleVersionInformation);

            /*HRESULT GetModuleVersionInformation(
            [In] uint Index,
            [In] ulong Base,
            [In, MarshalAs(UnmanagedType.LPStr)] string Item,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint VerInfoSize);*/
            return getModuleVersionInformation(Raw, index, @base, item, buffer, bufferSize, out verInfoSize);
        }

        #endregion
        #region GetModuleNameString

        /// <summary>
        /// The GetModuleNameString method returns the name of the specified module.
        /// </summary>
        /// <param name="which">[in] Specifies which of the module's names to return, possible values are:</param>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <returns>[out, optional] Receives the name of the module. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public string GetModuleNameString(DEBUG_MODNAME which, uint index, ulong @base)
        {
            string bufferResult;
            TryGetModuleNameString(which, index, @base, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetModuleNameString method returns the name of the specified module.
        /// </summary>
        /// <param name="which">[in] Specifies which of the module's names to return, possible values are:</param>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="bufferResult">[out, optional] Receives the name of the module. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleNameString(DEBUG_MODNAME which, uint index, ulong @base, out string bufferResult)
        {
            InitDelegate(ref getModuleNameString, Vtbl2->GetModuleNameString);
            /*HRESULT GetModuleNameString(
            [In] DEBUG_MODNAME Which,
            [In] uint Index,
            [In] ulong Base,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            uint bufferSize = 0;
            uint nameSize;
            HRESULT hr = getModuleNameString(Raw, which, index, @base, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new StringBuilder((int) bufferSize);
            hr = getModuleNameString(Raw, which, index, @base, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetConstantName

        /// <summary>
        /// The GetConstantName method returns the name of the specified constant.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the constant was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the constant.</param>
        /// <param name="value">[in] Specifies the value of the constant.</param>
        /// <returns>[out, optional] Receives the constant's name. If NameBuffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetConstantName(ulong module, uint typeId, ulong value)
        {
            string bufferResult;
            TryGetConstantName(module, typeId, value, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetConstantName method returns the name of the specified constant.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the constant was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the constant.</param>
        /// <param name="value">[in] Specifies the value of the constant.</param>
        /// <param name="bufferResult">[out, optional] Receives the constant's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetConstantName(ulong module, uint typeId, ulong value, out string bufferResult)
        {
            InitDelegate(ref getConstantName, Vtbl2->GetConstantName);
            /*HRESULT GetConstantName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] ulong Value,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getConstantName(Raw, module, typeId, value, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getConstantName(Raw, module, typeId, value, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetFieldName

        /// <summary>
        /// The GetFieldName method returns the name of a field within a structure.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the structure was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the structure.</param>
        /// <param name="fieldIndex">[in] Specifies the index of the desired field within the structure.</param>
        /// <returns>[out, optional] Receives the field's name. If NameBuffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetFieldName(ulong module, uint typeId, uint fieldIndex)
        {
            string bufferResult;
            TryGetFieldName(module, typeId, fieldIndex, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetFieldName method returns the name of a field within a structure.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the structure was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the structure.</param>
        /// <param name="fieldIndex">[in] Specifies the index of the desired field within the structure.</param>
        /// <param name="bufferResult">[out, optional] Receives the field's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetFieldName(ulong module, uint typeId, uint fieldIndex, out string bufferResult)
        {
            InitDelegate(ref getFieldName, Vtbl2->GetFieldName);
            /*HRESULT GetFieldName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] uint FieldIndex,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getFieldName(Raw, module, typeId, fieldIndex, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getFieldName(Raw, module, typeId, fieldIndex, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region AddTypeOptions

        /// <summary>
        /// The AddTypeOptions method turns on some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies type formatting options to turn on. Options is a bit-set that will be ORed with the existing type formatting options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see 
        ///cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public void AddTypeOptions(DEBUG_TYPEOPTS options)
        {
            TryAddTypeOptions(options).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AddTypeOptions method turns on some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies type formatting options to turn on. Options is a bit-set that will be ORed with the existing type formatting options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see 
        ///cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TryAddTypeOptions(DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref addTypeOptions, Vtbl2->AddTypeOptions);

            /*HRESULT AddTypeOptions(
            [In] DEBUG_TYPEOPTS Options);*/
            return addTypeOptions(Raw, options);
        }

        #endregion
        #region RemoveTypeOptions

        /// <summary>
        /// The RemoveTypeOptions method turns off some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies the type formatting options to turn off. Options is a bit-set; the new value of the options will equal the old value AND NOT the value of Options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see 
        ///cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public void RemoveTypeOptions(DEBUG_TYPEOPTS options)
        {
            TryRemoveTypeOptions(options).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The RemoveTypeOptions method turns off some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies the type formatting options to turn off. Options is a bit-set; the new value of the options will equal the old value AND NOT the value of Options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see 
        ///cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TryRemoveTypeOptions(DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref removeTypeOptions, Vtbl2->RemoveTypeOptions);

            /*HRESULT RemoveTypeOptions(
            [In] DEBUG_TYPEOPTS Options);*/
            return removeTypeOptions(Raw, options);
        }

        #endregion
        #endregion
        #region IDebugSymbols3
        #region SymbolPathWide

        /// <summary>
        /// The GetSymbolPathWide method returns the symbol path.
        /// </summary>
        public string SymbolPathWide
        {
            get
            {
                string bufferResult;
                TryGetSymbolPathWide(out bufferResult).ThrowDbgEngNotOk();

                return bufferResult;
            }
            set
            {
                TrySetSymbolPathWide(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetSymbolPathWide method returns the symbol path.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server. If Buffer is NULL, this information is not returned.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public HRESULT TryGetSymbolPathWide(out string bufferResult)
        {
            InitDelegate(ref getSymbolPathWide, Vtbl3->GetSymbolPathWide);
            /*HRESULT GetSymbolPathWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint pathSize;
            HRESULT hr = getSymbolPathWide(Raw, buffer, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) pathSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolPathWide(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetSymbolPathWide method sets the symbol path.
        /// </summary>
        /// <param name="path">[in] Specifies the new symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public HRESULT TrySetSymbolPathWide(string path)
        {
            InitDelegate(ref setSymbolPathWide, Vtbl3->SetSymbolPathWide);

            /*HRESULT SetSymbolPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);*/
            return setSymbolPathWide(Raw, path);
        }

        #endregion
        #region ImagePathWide

        /// <summary>
        /// The GetImagePathWide method returns the executable image path.
        /// </summary>
        public string ImagePathWide
        {
            get
            {
                string bufferResult;
                TryGetImagePathWide(out bufferResult).ThrowDbgEngNotOk();

                return bufferResult;
            }
            set
            {
                TrySetImagePathWide(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetImagePathWide method returns the executable image path.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the executable image path. This is a string that contains directories separated by semicolons (;).<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        public HRESULT TryGetImagePathWide(out string bufferResult)
        {
            InitDelegate(ref getImagePathWide, Vtbl3->GetImagePathWide);
            /*HRESULT GetImagePathWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint pathSize;
            HRESULT hr = getImagePathWide(Raw, buffer, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) pathSize;
            buffer = new StringBuilder(bufferSize);
            hr = getImagePathWide(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetImagePathWide method sets the executable image path.
        /// </summary>
        /// <param name="path">[in] Specifies the new executable image path. This is a string that contains directories separated by semicolons (;).</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        public HRESULT TrySetImagePathWide(string path)
        {
            InitDelegate(ref setImagePathWide, Vtbl3->SetImagePathWide);

            /*HRESULT SetImagePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);*/
            return setImagePathWide(Raw, path);
        }

        #endregion
        #region SourcePathWide

        /// <summary>
        /// The GetSourcePathWide method returns the source path.
        /// </summary>
        public string SourcePathWide
        {
            get
            {
                string bufferResult;
                TryGetSourcePathWide(out bufferResult).ThrowDbgEngNotOk();

                return bufferResult;
            }
            set
            {
                TrySetSourcePathWide(value).ThrowDbgEngNotOk();
            }
        }

        /// <summary>
        /// The GetSourcePathWide method returns the source path.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Receives the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TryGetSourcePathWide(out string bufferResult)
        {
            InitDelegate(ref getSourcePathWide, Vtbl3->GetSourcePathWide);
            /*HRESULT GetSourcePathWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint pathSize;
            HRESULT hr = getSourcePathWide(Raw, buffer, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) pathSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSourcePathWide(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetSourcePathWide method sets the source path.
        /// </summary>
        /// <param name="path">[in] Specifies the new source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TrySetSourcePathWide(string path)
        {
            InitDelegate(ref setSourcePathWide, Vtbl3->SetSourcePathWide);

            /*HRESULT SetSourcePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);*/
            return setSourcePathWide(Raw, path);
        }

        #endregion
        #region CurrentScopeFrameIndex

        /// <summary>
        /// The GetCurrentScopeFrameIndex method returns the index of the current stack frame in the call stack.
        /// </summary>
        public uint CurrentScopeFrameIndex
        {
            get
            {
                uint index;
                TryGetCurrentScopeFrameIndex(out index).ThrowDbgEngNotOk();

                return index;
            }
        }

        /// <summary>
        /// The GetCurrentScopeFrameIndex method returns the index of the current stack frame in the call stack.
        /// </summary>
        /// <param name="index">[out] Receives the index of the stack frame corresponding to the current scope. The index counts the number of frames from the top of the call stack.<para/>
        /// The frame at the top of the stack, representing the current call, has index zero.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the current scope was set using <see cref="SetScope"/>, Index receives the value of the FrameNumber member of
        /// the DEBUG_STACK_TRACE structure passed to the ScopeFrame parameter of SetScope. For more information about scopes,
        /// see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetCurrentScopeFrameIndex(out uint index)
        {
            InitDelegate(ref getCurrentScopeFrameIndex, Vtbl3->GetCurrentScopeFrameIndex);

            /*HRESULT GetCurrentScopeFrameIndex(
            [Out] out uint Index);*/
            return getCurrentScopeFrameIndex(Raw, out index);
        }

        #endregion
        #region GetNameByOffsetWide

        /// <summary>
        /// The GetNameByOffsetWide method returns the name of the symbol at the specified location in the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol whose name is requested. Offset does not need to specify the base location of the symbol; it only needs to specify a location within the symbol's memory allocation.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public GetNameByOffsetWideResult GetNameByOffsetWide(ulong offset)
        {
            GetNameByOffsetWideResult result;
            TryGetNameByOffsetWide(offset, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetNameByOffsetWide method returns the name of the symbol at the specified location in the target's virtual address space.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol whose name is requested. Offset does not need to specify the base location of the symbol; it only needs to specify a location within the symbol's memory allocation.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetNameByOffsetWide(ulong offset, out GetNameByOffsetWideResult result)
        {
            InitDelegate(ref getNameByOffsetWide, Vtbl3->GetNameByOffsetWide);
            /*HRESULT GetNameByOffsetWide(
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            ulong displacement;
            HRESULT hr = getNameByOffsetWide(Raw, offset, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getNameByOffsetWide(Raw, offset, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByOffsetWideResult(nameBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetNameByOffsetWideResult);

            return hr;
        }

        #endregion
        #region GetOffsetByNameWide

        /// <summary>
        /// The GetOffsetByNameWide method returns the location of a symbol identified by name.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to locate. The name may be qualified by a module name (for example, mymodule!main).</param>
        /// <returns>[out] Receives the location in the target's memory address space of the base of the symbol's memory allocation.</returns>
        /// <remarks>
        /// If the name Symbol is not unique and GetOffsetByName finds multiple symbols with that name, then the ambiguity
        /// will be resolved arbitrarily. In this case the value S_FALSE will be returned. <see cref="StartSymbolMatch"/> can
        /// be used to initiate a search to determine which is the desired result. GetNameByOffset does not support pattern
        /// matching (e.g. wildcards). To find a symbol using pattern matching use StartSymbolMatch. If the module name for
        /// the symbol is known, it is best to qualify the symbol name with the module name. Otherwise the engine will search
        /// the symbols for all modules until it finds a match; this can take a long time if it has to load the symbol files
        /// for a lot of modules. If the symbol name is qualified with a module name, the engine only searches the symbols
        /// for that module. For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public ulong GetOffsetByNameWide(string symbol)
        {
            ulong offset;
            TryGetOffsetByNameWide(symbol, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetOffsetByNameWide method returns the location of a symbol identified by name.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to locate. The name may be qualified by a module name (for example, mymodule!main).</param>
        /// <param name="offset">[out] Receives the location in the target's memory address space of the base of the symbol's memory allocation.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the name Symbol is not unique and GetOffsetByName finds multiple symbols with that name, then the ambiguity
        /// will be resolved arbitrarily. In this case the value S_FALSE will be returned. <see cref="StartSymbolMatch"/> can
        /// be used to initiate a search to determine which is the desired result. GetNameByOffset does not support pattern
        /// matching (e.g. wildcards). To find a symbol using pattern matching use StartSymbolMatch. If the module name for
        /// the symbol is known, it is best to qualify the symbol name with the module name. Otherwise the engine will search
        /// the symbols for all modules until it finds a match; this can take a long time if it has to load the symbol files
        /// for a lot of modules. If the symbol name is qualified with a module name, the engine only searches the symbols
        /// for that module. For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetOffsetByNameWide(string symbol, out ulong offset)
        {
            InitDelegate(ref getOffsetByNameWide, Vtbl3->GetOffsetByNameWide);

            /*HRESULT GetOffsetByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out ulong Offset);*/
            return getOffsetByNameWide(Raw, symbol, out offset);
        }

        #endregion
        #region GetNearNameByOffsetWide

        /// <summary>
        /// The GetNearNameByOffsetWide method returns the name of a symbol that is located near the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol from which the desired symbol is determined.</param>
        /// <param name="delta">[in] Specifies the relationship between the desired symbol and the symbol located at Offset. If positive, the engine will return the symbol that is Delta symbols after the symbol located at Offset.<para/>
        /// If negative, the engine will return the symbol that is Delta symbols before the symbol located at Offset.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// By increasing or decreasing the value of Delta, these methods can be used to iterate over the target's symbols
        /// starting at a particular location. If Delta is zero, these methods behave the same way as <see cref="GetNameByOffset"/>.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public GetNearNameByOffsetWideResult GetNearNameByOffsetWide(ulong offset, int delta)
        {
            GetNearNameByOffsetWideResult result;
            TryGetNearNameByOffsetWide(offset, delta, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetNearNameByOffsetWide method returns the name of a symbol that is located near the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the symbol from which the desired symbol is determined.</param>
        /// <param name="delta">[in] Specifies the relationship between the desired symbol and the symbol located at Offset. If positive, the engine will return the symbol that is Delta symbols after the symbol located at Offset.<para/>
        /// If negative, the engine will return the symbol that is Delta symbols before the symbol located at Offset.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// By increasing or decreasing the value of Delta, these methods can be used to iterate over the target's symbols
        /// starting at a particular location. If Delta is zero, these methods behave the same way as <see cref="GetNameByOffset"/>.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetNearNameByOffsetWide(ulong offset, int delta, out GetNearNameByOffsetWideResult result)
        {
            InitDelegate(ref getNearNameByOffsetWide, Vtbl3->GetNearNameByOffsetWide);
            /*HRESULT GetNearNameByOffsetWide(
            [In] ulong Offset,
            [In] int Delta,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            ulong displacement;
            HRESULT hr = getNearNameByOffsetWide(Raw, offset, delta, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getNearNameByOffsetWide(Raw, offset, delta, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNearNameByOffsetWideResult(nameBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetNearNameByOffsetWideResult);

            return hr;
        }

        #endregion
        #region GetLineByOffsetWide

        /// <summary>
        /// The GetLineByOffsetWide method returns the source filename and the line number within the source file of an instruction in the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the instruction for which to return the source file and line number.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public GetLineByOffsetWideResult GetLineByOffsetWide(ulong offset)
        {
            GetLineByOffsetWideResult result;
            TryGetLineByOffsetWide(offset, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetLineByOffsetWide method returns the source filename and the line number within the source file of an instruction in the target.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the instruction for which to return the source file and line number.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetLineByOffsetWide(ulong offset, out GetLineByOffsetWideResult result)
        {
            InitDelegate(ref getLineByOffsetWide, Vtbl3->GetLineByOffsetWide);
            /*HRESULT GetLineByOffsetWide(
            [In] ulong Offset,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);*/
            uint line;
            StringBuilder fileBuffer = null;
            int fileBufferSize = 0;
            uint fileSize;
            ulong displacement;
            HRESULT hr = getLineByOffsetWide(Raw, offset, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileBufferSize = (int) fileSize;
            fileBuffer = new StringBuilder(fileBufferSize);
            hr = getLineByOffsetWide(Raw, offset, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByOffsetWideResult(line, fileBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetLineByOffsetWideResult);

            return hr;
        }

        #endregion
        #region GetOffsetByLineWide

        /// <summary>
        /// The GetOffsetByLineWide method returns the location of the instruction that corresponds to a specified line in the source code.
        /// </summary>
        /// <param name="line">[in] Specifies the line number in the source file.</param>
        /// <param name="file">[in] Specifies the file name of the source file.</param>
        /// <returns>[out] Receives the location in the target's virtual address space of an instruction for the specified line.</returns>
        /// <remarks>
        /// A line in a source file might correspond to multiple instructions and this method can return any one of these instructions.
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public ulong GetOffsetByLineWide(uint line, string file)
        {
            ulong offset;
            TryGetOffsetByLineWide(line, file, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetOffsetByLineWide method returns the location of the instruction that corresponds to a specified line in the source code.
        /// </summary>
        /// <param name="line">[in] Specifies the line number in the source file.</param>
        /// <param name="file">[in] Specifies the file name of the source file.</param>
        /// <param name="offset">[out] Receives the location in the target's virtual address space of an instruction for the specified line.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// A line in a source file might correspond to multiple instructions and this method can return any one of these instructions.
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetOffsetByLineWide(uint line, string file, out ulong offset)
        {
            InitDelegate(ref getOffsetByLineWide, Vtbl3->GetOffsetByLineWide);

            /*HRESULT GetOffsetByLineWide(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out ulong Offset);*/
            return getOffsetByLineWide(Raw, line, file, out offset);
        }

        #endregion
        #region GetModuleByModuleNameWide

        /// <summary>
        /// The GetModuleByModuleNameWide method searches through the target's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public GetModuleByModuleNameWideResult GetModuleByModuleNameWide(string name, uint startIndex)
        {
            GetModuleByModuleNameWideResult result;
            TryGetModuleByModuleNameWide(name, startIndex, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetModuleByModuleNameWide method searches through the target's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleByModuleNameWide(string name, uint startIndex, out GetModuleByModuleNameWideResult result)
        {
            InitDelegate(ref getModuleByModuleNameWide, Vtbl3->GetModuleByModuleNameWide);
            /*HRESULT GetModuleByModuleNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);*/
            uint index;
            ulong @base;
            HRESULT hr = getModuleByModuleNameWide(Raw, name, startIndex, out index, out @base);

            if (hr == HRESULT.S_OK)
                result = new GetModuleByModuleNameWideResult(index, @base);
            else
                result = default(GetModuleByModuleNameWideResult);

            return hr;
        }

        #endregion
        #region GetSymbolModuleWide

        /// <summary>
        /// The GetSymbolModuleWide method returns the base address of module which contains the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to look up. See the Remarks section for details of the syntax of this name.</param>
        /// <returns>[out] Receives the location in the target's memory address space of the base of the module. For more information, see Modules.</returns>
        /// <remarks>
        /// The string Symbol must contain an exclamation point ( ! ). If Symbol is a module-qualified symbol name (for example,
        /// mymodules!main) or if the module name is omitted (for example, !main), the engine will search for this symbol and
        /// return the module in which it is found. If Symbol contains just a module name (for example, mymodule!) the engine
        /// returns the first module with this module name. For more information about symbols, see Symbols.
        /// </remarks>
        public ulong GetSymbolModuleWide(string symbol)
        {
            ulong @base;
            TryGetSymbolModuleWide(symbol, out @base).ThrowDbgEngNotOk();

            return @base;
        }

        /// <summary>
        /// The GetSymbolModuleWide method returns the base address of module which contains the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the name of the symbol to look up. See the Remarks section for details of the syntax of this name.</param>
        /// <param name="base">[out] Receives the location in the target's memory address space of the base of the module. For more information, see Modules.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The string Symbol must contain an exclamation point ( ! ). If Symbol is a module-qualified symbol name (for example,
        /// mymodules!main) or if the module name is omitted (for example, !main), the engine will search for this symbol and
        /// return the module in which it is found. If Symbol contains just a module name (for example, mymodule!) the engine
        /// returns the first module with this module name. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolModuleWide(string symbol, out ulong @base)
        {
            InitDelegate(ref getSymbolModuleWide, Vtbl3->GetSymbolModuleWide);

            /*HRESULT GetSymbolModuleWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out ulong Base);*/
            return getSymbolModuleWide(Raw, symbol, out @base);
        }

        #endregion
        #region GetTypeNameWide

        /// <summary>
        /// The GetTypeNameWide method returns the name of the type symbol specified by its type ID and module.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <returns>[out, optional] Receives the name of the type. If NameBuffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetTypeNameWide(ulong module, uint typeId)
        {
            string nameBufferResult;
            TryGetTypeNameWide(module, typeId, out nameBufferResult).ThrowDbgEngNotOk();

            return nameBufferResult;
        }

        /// <summary>
        /// The GetTypeNameWide method returns the name of the type symbol specified by its type ID and module.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="nameBufferResult">[out, optional] Receives the name of the type. If NameBuffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetTypeNameWide(ulong module, uint typeId, out string nameBufferResult)
        {
            InitDelegate(ref getTypeNameWide, Vtbl3->GetTypeNameWide);
            /*HRESULT GetTypeNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            HRESULT hr = getTypeNameWide(Raw, module, typeId, nameBuffer, nameBufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getTypeNameWide(Raw, module, typeId, nameBuffer, nameBufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                nameBufferResult = nameBuffer.ToString();

                return hr;
            }

            fail:
            nameBufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetTypeIdWide

        /// <summary>
        /// The GetTypeIdWide method looks up the specified type and return its type ID.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules. If Name contains a module name, Module is ignored.</param>
        /// <param name="name">[in] Specifies the name of the type whose type ID is desired. If Name is a module-qualified name (for example mymodule!main), the Module parameter is ignored.</param>
        /// <returns>[out] Receives the type ID of the symbol.</returns>
        /// <remarks>
        /// If the specified symbol is a type, these methods return the type ID for that type; otherwise, they return the type
        /// ID for the type of the symbol. A variable whose type was defined using typedef has a type ID that identifies the
        /// original type, not the type created by typedef. In the following example, the type ID of MyInstance corresponds
        /// to the name MyStruct (this correspondence can be seen by passing the type ID to <see cref="GetTypeName"/>): Moreover,
        /// calling these methods for MyStruct and MyType yields type IDs corresponding to MyStruct and MyType, respectively.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public uint GetTypeIdWide(ulong module, string name)
        {
            uint typeId;
            TryGetTypeIdWide(module, name, out typeId).ThrowDbgEngNotOk();

            return typeId;
        }

        /// <summary>
        /// The GetTypeIdWide method looks up the specified type and return its type ID.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules. If Name contains a module name, Module is ignored.</param>
        /// <param name="name">[in] Specifies the name of the type whose type ID is desired. If Name is a module-qualified name (for example mymodule!main), the Module parameter is ignored.</param>
        /// <param name="typeId">[out] Receives the type ID of the symbol.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified symbol is a type, these methods return the type ID for that type; otherwise, they return the type
        /// ID for the type of the symbol. A variable whose type was defined using typedef has a type ID that identifies the
        /// original type, not the type created by typedef. In the following example, the type ID of MyInstance corresponds
        /// to the name MyStruct (this correspondence can be seen by passing the type ID to <see cref="GetTypeName"/>): Moreover,
        /// calling these methods for MyStruct and MyType yields type IDs corresponding to MyStruct and MyType, respectively.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        public HRESULT TryGetTypeIdWide(ulong module, string name, out uint typeId)
        {
            InitDelegate(ref getTypeIdWide, Vtbl3->GetTypeIdWide);

            /*HRESULT GetTypeIdWide(
            [In] ulong Module,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint TypeId);*/
            return getTypeIdWide(Raw, module, name, out typeId);
        }

        #endregion
        #region GetFieldOffsetWide

        /// <summary>
        /// The GetFieldOffsetWide method returns the offset of a field from the base address of an instance of a type.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type containing the field.</param>
        /// <param name="field">[in] Specifies the name of the field whose offset is requested. Subfields may be specified by using a dot-separated path.</param>
        /// <returns>[out] Receives the offset of the specified field from the base memory location of an instance of the type.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the location
        /// of this field relative to the location of MyStruct structure can be found by setting the Field parameter to "MyField.MySubField".
        /// For more information about types, see Types.
        /// </remarks>
        public uint GetFieldOffsetWide(ulong module, uint typeId, string field)
        {
            uint offset;
            TryGetFieldOffsetWide(module, typeId, field, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetFieldOffsetWide method returns the offset of a field from the base address of an instance of a type.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type containing the field.</param>
        /// <param name="field">[in] Specifies the name of the field whose offset is requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="offset">[out] Receives the offset of the specified field from the base memory location of an instance of the type.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the location
        /// of this field relative to the location of MyStruct structure can be found by setting the Field parameter to "MyField.MySubField".
        /// For more information about types, see Types.
        /// </remarks>
        public HRESULT TryGetFieldOffsetWide(ulong module, uint typeId, string field, out uint offset)
        {
            InitDelegate(ref getFieldOffsetWide, Vtbl3->GetFieldOffsetWide);

            /*HRESULT GetFieldOffsetWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out uint Offset);*/
            return getFieldOffsetWide(Raw, module, typeId, field, out offset);
        }

        #endregion
        #region GetSymbolTypeIdWide

        /// <summary>
        /// The GetSymbolTypeIdWide method returns the type ID and module of the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the expression whose type ID is requested. See the Remarks section for details on the syntax of this expression.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The Symbol expression may contain structure fields, pointer dereferencing, and array dereferencing -- for example
        /// my_struct.some_field[0]. For more information about symbols, see Symbols.
        /// </remarks>
        public GetSymbolTypeIdWideResult GetSymbolTypeIdWide(string symbol)
        {
            GetSymbolTypeIdWideResult result;
            TryGetSymbolTypeIdWide(symbol, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetSymbolTypeIdWide method returns the type ID and module of the specified symbol.
        /// </summary>
        /// <param name="symbol">[in] Specifies the expression whose type ID is requested. See the Remarks section for details on the syntax of this expression.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Symbol expression may contain structure fields, pointer dereferencing, and array dereferencing -- for example
        /// my_struct.some_field[0]. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolTypeIdWide(string symbol, out GetSymbolTypeIdWideResult result)
        {
            InitDelegate(ref getSymbolTypeIdWide, Vtbl3->GetSymbolTypeIdWide);
            /*HRESULT GetSymbolTypeIdWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out uint TypeId,
            [Out] out ulong Module);*/
            uint typeId;
            ulong module;
            HRESULT hr = getSymbolTypeIdWide(Raw, symbol, out typeId, out module);

            if (hr == HRESULT.S_OK)
                result = new GetSymbolTypeIdWideResult(typeId, module);
            else
                result = default(GetSymbolTypeIdWideResult);

            return hr;
        }

        #endregion
        #region GetScopeSymbolGroup2

        /// <summary>
        /// The GetScopeSymbolGroup2 method returns a symbol group containing the symbols in the current target's scope.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set used to determine which symbols to include in the symbol group. To include all symbols, set Flags to DEBUG_SCOPE_GROUP_ALL.<para/>
        /// The following bit-flags determine which symbols are included.</param>
        /// <param name="update">[in, optional] Specifies a previously created symbol group that will be updated to reflect the current scope. If Update is NULL, a new symbol group interface object is created.</param>
        /// <returns>[out] Receives the symbol group interface object for the current scope. For details on this interface, see <see cref="IDebugSymbolGroup"/></returns>
        /// <remarks>
        /// The Update parameter allows for efficient updates when stepping through code. Instead of creating and populating
        /// a new symbol group, the old symbol group can be updated. For more information about scopes and symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public DebugSymbolGroup GetScopeSymbolGroup2(DEBUG_SCOPE_GROUP flags, IDebugSymbolGroup2 update)
        {
            DebugSymbolGroup symbolsResult;
            TryGetScopeSymbolGroup2(flags, update, out symbolsResult).ThrowDbgEngNotOk();

            return symbolsResult;
        }

        /// <summary>
        /// The GetScopeSymbolGroup2 method returns a symbol group containing the symbols in the current target's scope.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set used to determine which symbols to include in the symbol group. To include all symbols, set Flags to DEBUG_SCOPE_GROUP_ALL.<para/>
        /// The following bit-flags determine which symbols are included.</param>
        /// <param name="update">[in, optional] Specifies a previously created symbol group that will be updated to reflect the current scope. If Update is NULL, a new symbol group interface object is created.</param>
        /// <param name="symbolsResult">[out] Receives the symbol group interface object for the current scope. For details on this interface, see <see cref="IDebugSymbolGroup"/></param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Update parameter allows for efficient updates when stepping through code. Instead of creating and populating
        /// a new symbol group, the old symbol group can be updated. For more information about scopes and symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetScopeSymbolGroup2(DEBUG_SCOPE_GROUP flags, IDebugSymbolGroup2 update, out DebugSymbolGroup symbolsResult)
        {
            InitDelegate(ref getScopeSymbolGroup2, Vtbl3->GetScopeSymbolGroup2);
            /*HRESULT GetScopeSymbolGroup2(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugSymbolGroup2 Update,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup2 Symbols);*/
            IDebugSymbolGroup2 symbols;
            HRESULT hr = getScopeSymbolGroup2(Raw, flags, update, out symbols);

            if (hr == HRESULT.S_OK)
                symbolsResult = new DebugSymbolGroup(symbols);
            else
                symbolsResult = default(DebugSymbolGroup);

            return hr;
        }

        #endregion
        #region CreateSymbolGroup2

        /// <summary>
        /// The CreateSymbolGroup2 method creates a new symbol group.
        /// </summary>
        /// <returns>[out] Receives an interface pointer for the new <see cref="IDebugSymbolGroup"/> object.</returns>
        /// <remarks>
        /// The newly created symbol group is empty; it does not contain any symbols. Symbols may be added to the symbol group
        /// using <see cref="DebugSymbolGroup.AddSymbol"/>. References to the returned object are managed like other COM objects,
        /// using the IUnknown::AddRef and IUnknown::Release methods. In particular, the IUnknown::Release method must be called
        /// when the returned object is no longer needed. See Using Client Objects for more information about using COM interfaces
        /// in the Debugger Engine API. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public DebugSymbolGroup CreateSymbolGroup2()
        {
            DebugSymbolGroup groupResult;
            TryCreateSymbolGroup2(out groupResult).ThrowDbgEngNotOk();

            return groupResult;
        }

        /// <summary>
        /// The CreateSymbolGroup2 method creates a new symbol group.
        /// </summary>
        /// <param name="groupResult">[out] Receives an interface pointer for the new <see cref="IDebugSymbolGroup"/> object.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The newly created symbol group is empty; it does not contain any symbols. Symbols may be added to the symbol group
        /// using <see cref="DebugSymbolGroup.AddSymbol"/>. References to the returned object are managed like other COM objects,
        /// using the IUnknown::AddRef and IUnknown::Release methods. In particular, the IUnknown::Release method must be called
        /// when the returned object is no longer needed. See Using Client Objects for more information about using COM interfaces
        /// in the Debugger Engine API. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryCreateSymbolGroup2(out DebugSymbolGroup groupResult)
        {
            InitDelegate(ref createSymbolGroup2, Vtbl3->CreateSymbolGroup2);
            /*HRESULT CreateSymbolGroup2(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup2 Group);*/
            IDebugSymbolGroup2 group;
            HRESULT hr = createSymbolGroup2(Raw, out group);

            if (hr == HRESULT.S_OK)
                groupResult = new DebugSymbolGroup(group);
            else
                groupResult = default(DebugSymbolGroup);

            return hr;
        }

        #endregion
        #region StartSymbolMatchWide

        /// <summary>
        /// The StartSymbolMatchWide method initializes a search for symbols whose names match a given pattern.
        /// </summary>
        /// <param name="pattern">[in] Specifies the pattern for which to search. The search will return all symbols whose names match this pattern.<para/>
        /// For details of the syntax of the pattern, see Symbol Syntax and Symbol Matching and String Wildcard Syntax.</param>
        /// <returns>[out] Receives the handle identifying the search. This handle can be passed to <see cref="GetNextSymbolMatch"/> and <see cref="EndSymbolMatch"/>.</returns>
        /// <remarks>
        /// This method initializes a symbol search. The results of the search can be obtained by repeated calls to <see cref="GetNextSymbolMatch"/>.
        /// When all the desired results have been found, use <see cref="EndSymbolMatch"/> to release resources the engine
        /// holds for the search. For more information about symbols, see Symbols.
        /// </remarks>
        public ulong StartSymbolMatchWide(string pattern)
        {
            ulong handle;
            TryStartSymbolMatchWide(pattern, out handle).ThrowDbgEngNotOk();

            return handle;
        }

        /// <summary>
        /// The StartSymbolMatchWide method initializes a search for symbols whose names match a given pattern.
        /// </summary>
        /// <param name="pattern">[in] Specifies the pattern for which to search. The search will return all symbols whose names match this pattern.<para/>
        /// For details of the syntax of the pattern, see Symbol Syntax and Symbol Matching and String Wildcard Syntax.</param>
        /// <param name="handle">[out] Receives the handle identifying the search. This handle can be passed to <see cref="GetNextSymbolMatch"/> and <see cref="EndSymbolMatch"/>.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method initializes a symbol search. The results of the search can be obtained by repeated calls to <see cref="GetNextSymbolMatch"/>.
        /// When all the desired results have been found, use <see cref="EndSymbolMatch"/> to release resources the engine
        /// holds for the search. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryStartSymbolMatchWide(string pattern, out ulong handle)
        {
            InitDelegate(ref startSymbolMatchWide, Vtbl3->StartSymbolMatchWide);

            /*HRESULT StartSymbolMatchWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Pattern,
            [Out] out ulong Handle);*/
            return startSymbolMatchWide(Raw, pattern, out handle);
        }

        #endregion
        #region GetNextSymbolMatchWide

        /// <summary>
        /// The GetNextSymbolMatchWide method returns the next symbol found in a symbol search.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The search must first be initialized by <see cref="StartSymbolMatch"/>. Once all the desired symbols have been
        /// found, <see cref="EndSymbolMatch"/> can be used to release the resources the engine holds for the search. For more
        /// information about symbols, see Symbols.
        /// </remarks>
        public GetNextSymbolMatchWideResult GetNextSymbolMatchWide(ulong handle)
        {
            GetNextSymbolMatchWideResult result;
            TryGetNextSymbolMatchWide(handle, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetNextSymbolMatchWide method returns the next symbol found in a symbol search.
        /// </summary>
        /// <param name="handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The search must first be initialized by <see cref="StartSymbolMatch"/>. Once all the desired symbols have been
        /// found, <see cref="EndSymbolMatch"/> can be used to release the resources the engine holds for the search. For more
        /// information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetNextSymbolMatchWide(ulong handle, out GetNextSymbolMatchWideResult result)
        {
            InitDelegate(ref getNextSymbolMatchWide, Vtbl3->GetNextSymbolMatchWide);
            /*HRESULT GetNextSymbolMatchWide(
            [In] ulong Handle,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MatchSize,
            [Out] out ulong Offset);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint matchSize;
            ulong offset;
            HRESULT hr = getNextSymbolMatchWide(Raw, handle, buffer, bufferSize, out matchSize, out offset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) matchSize;
            buffer = new StringBuilder(bufferSize);
            hr = getNextSymbolMatchWide(Raw, handle, buffer, bufferSize, out matchSize, out offset);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNextSymbolMatchWideResult(buffer.ToString(), offset);

                return hr;
            }

            fail:
            result = default(GetNextSymbolMatchWideResult);

            return hr;
        }

        #endregion
        #region ReloadWide

        /// <summary>
        /// The ReloadWide method deletes the engine's symbol information for the specified module and reload these symbols as needed.
        /// </summary>
        /// <param name="module">[in] Specifies the module to reload.</param>
        /// <remarks>
        /// This method behaves the same way as the debugger command .reload. The Module parameter is treated the same way
        /// as the arguments to .reload. For example, setting the Module parameter to "/u ntdll.dll" has the same effect as
        /// the command .reload /u ntdll.dll. For more information about symbols, see Symbols.
        /// </remarks>
        public void ReloadWide(string module)
        {
            TryReloadWide(module).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The ReloadWide method deletes the engine's symbol information for the specified module and reload these symbols as needed.
        /// </summary>
        /// <param name="module">[in] Specifies the module to reload.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method behaves the same way as the debugger command .reload. The Module parameter is treated the same way
        /// as the arguments to .reload. For example, setting the Module parameter to "/u ntdll.dll" has the same effect as
        /// the command .reload /u ntdll.dll. For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryReloadWide(string module)
        {
            InitDelegate(ref reloadWide, Vtbl3->ReloadWide);

            /*HRESULT ReloadWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Module);*/
            return reloadWide(Raw, module);
        }

        #endregion
        #region AppendSymbolPathWide

        /// <summary>
        /// The AppendSymbolPathWide method appends directories to the symbol path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public void AppendSymbolPathWide(string addition)
        {
            TryAppendSymbolPathWide(addition).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AppendSymbolPathWide method appends directories to the symbol path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        public HRESULT TryAppendSymbolPathWide(string addition)
        {
            InitDelegate(ref appendSymbolPathWide, Vtbl3->AppendSymbolPathWide);

            /*HRESULT AppendSymbolPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);*/
            return appendSymbolPathWide(Raw, addition);
        }

        #endregion
        #region AppendImagePathWide

        /// <summary>
        /// The AppendImagePathWide method appends directories to the executable image path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the executable image path. This is a string that contains directory names separated by semicolons (;).</param>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons (;). These directories are searched in order.
        /// </remarks>
        public void AppendImagePathWide(string addition)
        {
            TryAppendImagePathWide(addition).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AppendImagePathWide method appends directories to the executable image path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the executable image path. This is a string that contains directory names separated by semicolons (;).</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons (;). These directories are searched in order.
        /// </remarks>
        public HRESULT TryAppendImagePathWide(string addition)
        {
            InitDelegate(ref appendImagePathWide, Vtbl3->AppendImagePathWide);

            /*HRESULT AppendImagePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);*/
            return appendImagePathWide(Raw, addition);
        }

        #endregion
        #region GetSourcePathElementWide

        /// <summary>
        /// The GetSourcePathElementWide method returns an element from the source path.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the element in the source path that will be returned. The source path is a string that contains elements separated by semicolons (;).<para/>
        /// The index of the first element is zero.</param>
        /// <returns>[out, optional] Receives the source path element. Each source path element can be a directory or a source server.<para/>
        /// If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public string GetSourcePathElementWide(uint index)
        {
            string bufferResult;
            TryGetSourcePathElementWide(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSourcePathElementWide method returns an element from the source path.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the element in the source path that will be returned. The source path is a string that contains elements separated by semicolons (;).<para/>
        /// The index of the first element is zero.</param>
        /// <param name="bufferResult">[out, optional] Receives the source path element. Each source path element can be a directory or a source server.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TryGetSourcePathElementWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getSourcePathElementWide, Vtbl3->GetSourcePathElementWide);
            /*HRESULT GetSourcePathElementWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ElementSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint elementSize;
            HRESULT hr = getSourcePathElementWide(Raw, index, buffer, bufferSize, out elementSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) elementSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSourcePathElementWide(Raw, index, buffer, bufferSize, out elementSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region AppendSourcePathWide

        /// <summary>
        /// The AppendSourcePathWide method appends directories to the source path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public void AppendSourcePathWide(string addition)
        {
            TryAppendSourcePathWide(addition).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AppendSourcePathWide method appends directories to the source path.
        /// </summary>
        /// <param name="addition">[in] Specifies the directories to append to the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        public HRESULT TryAppendSourcePathWide(string addition)
        {
            InitDelegate(ref appendSourcePathWide, Vtbl3->AppendSourcePathWide);

            /*HRESULT AppendSourcePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);*/
            return appendSourcePathWide(Raw, addition);
        }

        #endregion
        #region FindSourceFileWide

        /// <summary>
        /// The FindSourceFileWide method searches the source path for a specified source file.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path.</param>
        /// <param name="file">[in] Specifies the path and file name of the file to search for.</param>
        /// <param name="flags">[in] Specifies the search flags. For a description of these flags, see DEBUG_FIND_SOURCE_XXX. The flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP should not be set.<para/>
        /// The flag DEBUG_FIND_SOURCE_NO_SRCSRV is ignored because this method does not include source servers in the search.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The engine uses the following steps--in order--to search for the file: If the flag DEBUG_FIND_SOURCE_BEST_MATCH
        /// is set, the match with the longest overlap is returned; otherwise, the first match is returned. The first match
        /// found is returned.
        /// </remarks>
        public FindSourceFileWideResult FindSourceFileWide(uint startElement, string file, DEBUG_FIND_SOURCE flags)
        {
            FindSourceFileWideResult result;
            TryFindSourceFileWide(startElement, file, flags, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The FindSourceFileWide method searches the source path for a specified source file.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path.</param>
        /// <param name="file">[in] Specifies the path and file name of the file to search for.</param>
        /// <param name="flags">[in] Specifies the search flags. For a description of these flags, see DEBUG_FIND_SOURCE_XXX. The flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP should not be set.<para/>
        /// The flag DEBUG_FIND_SOURCE_NO_SRCSRV is ignored because this method does not include source servers in the search.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine uses the following steps--in order--to search for the file: If the flag DEBUG_FIND_SOURCE_BEST_MATCH
        /// is set, the match with the longest overlap is returned; otherwise, the first match is returned. The first match
        /// found is returned.
        /// </remarks>
        public HRESULT TryFindSourceFileWide(uint startElement, string file, DEBUG_FIND_SOURCE flags, out FindSourceFileWideResult result)
        {
            InitDelegate(ref findSourceFileWide, Vtbl3->FindSourceFileWide);
            /*HRESULT FindSourceFileWide(
            [In] uint StartElement,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out uint FoundElement,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FoundSize);*/
            uint foundElement;
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint foundSize;
            HRESULT hr = findSourceFileWide(Raw, startElement, file, flags, out foundElement, buffer, bufferSize, out foundSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) foundSize;
            buffer = new StringBuilder(bufferSize);
            hr = findSourceFileWide(Raw, startElement, file, flags, out foundElement, buffer, bufferSize, out foundSize);

            if (hr == HRESULT.S_OK)
            {
                result = new FindSourceFileWideResult(foundElement, buffer.ToString());

                return hr;
            }

            fail:
            result = default(FindSourceFileWideResult);

            return hr;
        }

        #endregion
        #region GetSourceFileLineOffsetsWide

        /// <summary>
        /// The GetSourceFileLineOffsetsWide method maps each line in a source file to a location in the target's memory.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the file whose lines will be turned into locations in the target's memory. The symbols for each module in the target are queried for this file.<para/>
        /// If the file is not located, the path is dropped and the symbols are queried again.</param>
        /// <returns>[out, optional] Receives the locations in the target's memory that correspond to the lines of the source code. The first entry returned to this array corresponds to the first line of the file, so that Buffer[i] contains the location for line i+1.<para/>
        /// If no symbol information is available for a line, the corresponding entry in Buffer is set to DEBUG_INVALID_OFFSET.<para/>
        /// If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about using the source path, see Using Source Files.
        /// </remarks>
        public ulong[] GetSourceFileLineOffsetsWide(string file)
        {
            ulong[] buffer;
            TryGetSourceFileLineOffsetsWide(file, out buffer).ThrowDbgEngNotOk();

            return buffer;
        }

        /// <summary>
        /// The GetSourceFileLineOffsetsWide method maps each line in a source file to a location in the target's memory.
        /// </summary>
        /// <param name="file">[in] Specifies the name of the file whose lines will be turned into locations in the target's memory. The symbols for each module in the target are queried for this file.<para/>
        /// If the file is not located, the path is dropped and the symbols are queried again.</param>
        /// <param name="buffer">[out, optional] Receives the locations in the target's memory that correspond to the lines of the source code. The first entry returned to this array corresponds to the first line of the file, so that Buffer[i] contains the location for line i+1.<para/>
        /// If no symbol information is available for a line, the corresponding entry in Buffer is set to DEBUG_INVALID_OFFSET.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using the source path, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetSourceFileLineOffsetsWide(string file, out ulong[] buffer)
        {
            InitDelegate(ref getSourceFileLineOffsetsWide, Vtbl3->GetSourceFileLineOffsetsWide);
            /*HRESULT GetSourceFileLineOffsetsWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Buffer,
            [In] int BufferLines,
            [Out] out uint FileLines);*/
            buffer = null;
            int bufferLines = 0;
            uint fileLines;
            HRESULT hr = getSourceFileLineOffsetsWide(Raw, file, buffer, bufferLines, out fileLines);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferLines = (int) fileLines;
            buffer = new ulong[bufferLines];
            hr = getSourceFileLineOffsetsWide(Raw, file, buffer, bufferLines, out fileLines);
            fail:
            return hr;
        }

        #endregion
        #region GetModuleVersionInformationWide

        /// <summary>
        /// The GetModuleVersionInformationWide method returns version information for the specified module.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">[in] Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="buffer">[out, optional] Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <returns>[out, optional] Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</returns>
        /// <remarks>
        /// Module version information is available only for loaded modules and may not be available in all sessions. For more
        /// information about modules, see Modules.
        /// </remarks>
        public uint GetModuleVersionInformationWide(uint index, ulong @base, string item, IntPtr buffer, int bufferSize)
        {
            uint verInfoSize;
            TryGetModuleVersionInformationWide(index, @base, item, buffer, bufferSize, out verInfoSize).ThrowDbgEngNotOk();

            return verInfoSize;
        }

        /// <summary>
        /// The GetModuleVersionInformationWide method returns version information for the specified module.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="item">[in] Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="buffer">[out, optional] Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="verInfoSize">[out, optional] Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Module version information is available only for loaded modules and may not be available in all sessions. For more
        /// information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleVersionInformationWide(uint index, ulong @base, string item, IntPtr buffer, int bufferSize, out uint verInfoSize)
        {
            InitDelegate(ref getModuleVersionInformationWide, Vtbl3->GetModuleVersionInformationWide);

            /*HRESULT GetModuleVersionInformationWide(
            [In] uint Index,
            [In] ulong Base,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Item,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint VerInfoSize);*/
            return getModuleVersionInformationWide(Raw, index, @base, item, buffer, bufferSize, out verInfoSize);
        }

        #endregion
        #region GetModuleNameStringWide

        /// <summary>
        /// The GetModuleNameStringWide method returns the name of the specified module.
        /// </summary>
        /// <param name="which">[in] Specifies which of the module's names to return, possible values are:</param>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <returns>[out, optional] Receives the name of the module. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public string GetModuleNameStringWide(DEBUG_MODNAME which, uint index, ulong @base)
        {
            string bufferResult;
            TryGetModuleNameStringWide(which, index, @base, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetModuleNameStringWide method returns the name of the specified module.
        /// </summary>
        /// <param name="which">[in] Specifies which of the module's names to return, possible values are:</param>
        /// <param name="index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="bufferResult">[out, optional] Receives the name of the module. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleNameStringWide(DEBUG_MODNAME which, uint index, ulong @base, out string bufferResult)
        {
            InitDelegate(ref getModuleNameStringWide, Vtbl3->GetModuleNameStringWide);
            /*HRESULT GetModuleNameStringWide(
            [In] DEBUG_MODNAME Which,
            [In] uint Index,
            [In] ulong Base,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getModuleNameStringWide(Raw, which, index, @base, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getModuleNameStringWide(Raw, which, index, @base, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetConstantNameWide

        /// <summary>
        /// The GetConstantNameWide method returns the name of the specified constant.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the constant was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the constant.</param>
        /// <param name="value">[in] Specifies the value of the constant.</param>
        /// <returns>[out, optional] Receives the constant's name. If NameBuffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetConstantNameWide(ulong module, uint typeId, ulong value)
        {
            string bufferResult;
            TryGetConstantNameWide(module, typeId, value, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetConstantNameWide method returns the name of the specified constant.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the constant was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the constant.</param>
        /// <param name="value">[in] Specifies the value of the constant.</param>
        /// <param name="bufferResult">[out, optional] Receives the constant's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetConstantNameWide(ulong module, uint typeId, ulong value, out string bufferResult)
        {
            InitDelegate(ref getConstantNameWide, Vtbl3->GetConstantNameWide);
            /*HRESULT GetConstantNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In] ulong Value,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getConstantNameWide(Raw, module, typeId, value, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getConstantNameWide(Raw, module, typeId, value, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetFieldNameWide

        /// <summary>
        /// The GetFieldNameWide method returns the name of a field within a structure.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the structure was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the structure.</param>
        /// <param name="fieldIndex">[in] Specifies the index of the desired field within the structure.</param>
        /// <returns>[out, optional] Receives the field's name. If NameBuffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetFieldNameWide(ulong module, uint typeId, uint fieldIndex)
        {
            string bufferResult;
            TryGetFieldNameWide(module, typeId, fieldIndex, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetFieldNameWide method returns the name of a field within a structure.
        /// </summary>
        /// <param name="module">[in] Specifies the base address of the module in which the structure was defined.</param>
        /// <param name="typeId">[in] Specifies the type ID of the structure.</param>
        /// <param name="fieldIndex">[in] Specifies the index of the desired field within the structure.</param>
        /// <param name="bufferResult">[out, optional] Receives the field's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetFieldNameWide(ulong module, uint typeId, uint fieldIndex, out string bufferResult)
        {
            InitDelegate(ref getFieldNameWide, Vtbl3->GetFieldNameWide);
            /*HRESULT GetFieldNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In] uint FieldIndex,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getFieldNameWide(Raw, module, typeId, fieldIndex, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getFieldNameWide(Raw, module, typeId, fieldIndex, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region IsManagedModule

        /// <summary>
        /// Checks whether the engine is using manageddebugging support when it retrieves informationfor a module.
        /// </summary>
        /// <param name="index">[in] The index of a module.</param>
        /// <param name="base">[in] The base of the module.</param>
        /// <remarks>
        /// It can be expensive to run this check.
        /// </remarks>
        public bool IsManagedModule(uint index, ulong @base)
        {
            HRESULT hr = TryIsManagedModule(index, @base);
            hr.ThrowDbgEngNotOk();

            return hr == HRESULT.S_OK;
        }

        /// <summary>
        /// Checks whether the engine is using manageddebugging support when it retrieves informationfor a module.
        /// </summary>
        /// <param name="index">[in] The index of a module.</param>
        /// <param name="base">[in] The base of the module.</param>
        /// <returns>IDebugSymbols3::IsManagedModule returns a value of S_OK if the engine is using manageddebugging support when it retrieves informationfor a module.</returns>
        /// <remarks>
        /// It can be expensive to run this check.
        /// </remarks>
        public HRESULT TryIsManagedModule(uint index, ulong @base)
        {
            InitDelegate(ref isManagedModule, Vtbl3->IsManagedModule);

            /*HRESULT IsManagedModule(
            [In] uint Index,
            [In] ulong Base);*/
            return isManagedModule(Raw, index, @base);
        }

        #endregion
        #region GetModuleByModuleName2

        /// <summary>
        /// The GetModuleByModuleName2 method searches through the process's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options used when searching for the module with the specified name. Flags may contain the following bit-flags:</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public GetModuleByModuleName2Result GetModuleByModuleName2(string name, uint startIndex, DEBUG_GETMOD flags)
        {
            GetModuleByModuleName2Result result;
            TryGetModuleByModuleName2(name, startIndex, flags, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetModuleByModuleName2 method searches through the process's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options used when searching for the module with the specified name. Flags may contain the following bit-flags:</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleByModuleName2(string name, uint startIndex, DEBUG_GETMOD flags, out GetModuleByModuleName2Result result)
        {
            InitDelegate(ref getModuleByModuleName2, Vtbl3->GetModuleByModuleName2);
            /*HRESULT GetModuleByModuleName2(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base);*/
            uint index;
            ulong @base;
            HRESULT hr = getModuleByModuleName2(Raw, name, startIndex, flags, out index, out @base);

            if (hr == HRESULT.S_OK)
                result = new GetModuleByModuleName2Result(index, @base);
            else
                result = default(GetModuleByModuleName2Result);

            return hr;
        }

        #endregion
        #region GetModuleByModuleName2Wide

        /// <summary>
        /// The GetModuleByModuleName2Wide method searches through the process's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options used when searching for the module with the specified name. Flags may contain the following bit-flags:</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public GetModuleByModuleName2WideResult GetModuleByModuleName2Wide(string name, uint startIndex, DEBUG_GETMOD flags)
        {
            GetModuleByModuleName2WideResult result;
            TryGetModuleByModuleName2Wide(name, startIndex, flags, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetModuleByModuleName2Wide method searches through the process's modules for one with the specified name.
        /// </summary>
        /// <param name="name">[in] Specifies the name of the desired module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options used when searching for the module with the specified name. Flags may contain the following bit-flags:</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleByModuleName2Wide(string name, uint startIndex, DEBUG_GETMOD flags, out GetModuleByModuleName2WideResult result)
        {
            InitDelegate(ref getModuleByModuleName2Wide, Vtbl3->GetModuleByModuleName2Wide);
            /*HRESULT GetModuleByModuleName2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base);*/
            uint index;
            ulong @base;
            HRESULT hr = getModuleByModuleName2Wide(Raw, name, startIndex, flags, out index, out @base);

            if (hr == HRESULT.S_OK)
                result = new GetModuleByModuleName2WideResult(index, @base);
            else
                result = default(GetModuleByModuleName2WideResult);

            return hr;
        }

        #endregion
        #region GetModuleByOffset2

        /// <summary>
        /// The GetModuleByOffset2 method searches through the process's modules for one whose memory allocation includes the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the target's virtual address space which is inside the desired module's memory allocation -- for example, the address of a symbol belonging to the module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options used when searching for the module with the specified location. Flags may contain the following bit-flags:</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Starting at the specified index, this method returns the first module it finds whose memory allocation address
        /// range includes the specified location. If the target has more than one module whose memory address range includes
        /// this location, then subsequent modules can be found by repeated calls to this method with higher values of StartIndex.
        /// For more information about modules, see Modules.
        /// </remarks>
        public GetModuleByOffset2Result GetModuleByOffset2(ulong offset, uint startIndex, DEBUG_GETMOD flags)
        {
            GetModuleByOffset2Result result;
            TryGetModuleByOffset2(offset, startIndex, flags, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetModuleByOffset2 method searches through the process's modules for one whose memory allocation includes the specified location.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the target's virtual address space which is inside the desired module's memory allocation -- for example, the address of a symbol belonging to the module.</param>
        /// <param name="startIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options used when searching for the module with the specified location. Flags may contain the following bit-flags:</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, this method returns the first module it finds whose memory allocation address
        /// range includes the specified location. If the target has more than one module whose memory address range includes
        /// this location, then subsequent modules can be found by repeated calls to this method with higher values of StartIndex.
        /// For more information about modules, see Modules.
        /// </remarks>
        public HRESULT TryGetModuleByOffset2(ulong offset, uint startIndex, DEBUG_GETMOD flags, out GetModuleByOffset2Result result)
        {
            InitDelegate(ref getModuleByOffset2, Vtbl3->GetModuleByOffset2);
            /*HRESULT GetModuleByOffset2(
            [In] ulong Offset,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base);*/
            uint index;
            ulong @base;
            HRESULT hr = getModuleByOffset2(Raw, offset, startIndex, flags, out index, out @base);

            if (hr == HRESULT.S_OK)
                result = new GetModuleByOffset2Result(index, @base);
            else
                result = default(GetModuleByOffset2Result);

            return hr;
        }

        #endregion
        #region AddSyntheticModule

        /// <summary>
        /// The AddSyntheticModule method adds a synthetic module to the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic module.</param>
        /// <param name="imagePath">[in] Specifies the image name of the synthetic module. This is the name that will be returned as the name of the executable file for the synthetic module.<para/>
        /// The full path should be included if known.</param>
        /// <param name="moduleName">[in] Specifies the module name for the synthetic module.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHMOD_DEFAULT.</param>
        /// <remarks>
        /// The memory region of the synthetic module, described by the Base and Size parameters, must not overlap the memory
        /// region of any other module. If all the modules are reloaded - for example, by calling <see cref="Reload"/> with
        /// the Module parameter set to an empty string - all synthetic modules will be discarded. For more information about
        /// synthetic modules, see Synthetic Modules.
        /// </remarks>
        public void AddSyntheticModule(ulong @base, uint size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            TryAddSyntheticModule(@base, size, imagePath, moduleName, flags).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AddSyntheticModule method adds a synthetic module to the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic module.</param>
        /// <param name="imagePath">[in] Specifies the image name of the synthetic module. This is the name that will be returned as the name of the executable file for the synthetic module.<para/>
        /// The full path should be included if known.</param>
        /// <param name="moduleName">[in] Specifies the module name for the synthetic module.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHMOD_DEFAULT.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The memory region of the synthetic module, described by the Base and Size parameters, must not overlap the memory
        /// region of any other module. If all the modules are reloaded - for example, by calling <see cref="Reload"/> with
        /// the Module parameter set to an empty string - all synthetic modules will be discarded. For more information about
        /// synthetic modules, see Synthetic Modules.
        /// </remarks>
        public HRESULT TryAddSyntheticModule(ulong @base, uint size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            InitDelegate(ref addSyntheticModule, Vtbl3->AddSyntheticModule);

            /*HRESULT AddSyntheticModule(
            [In] ulong Base,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);*/
            return addSyntheticModule(Raw, @base, size, imagePath, moduleName, flags);
        }

        #endregion
        #region AddSyntheticModuleWide

        /// <summary>
        /// The AddSyntheticModuleWide method adds a synthetic module to the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic module.</param>
        /// <param name="imagePath">[in] Specifies the image name of the synthetic module. This is the name that will be returned as the name of the executable file for the synthetic module.<para/>
        /// The full path should be included if known.</param>
        /// <param name="moduleName">[in] Specifies the module name for the synthetic module.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHMOD_DEFAULT.</param>
        /// <remarks>
        /// The memory region of the synthetic module, described by the Base and Size parameters, must not overlap the memory
        /// region of any other module. If all the modules are reloaded - for example, by calling <see cref="Reload"/> with
        /// the Module parameter set to an empty string - all synthetic modules will be discarded. For more information about
        /// synthetic modules, see Synthetic Modules.
        /// </remarks>
        public void AddSyntheticModuleWide(ulong @base, uint size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            TryAddSyntheticModuleWide(@base, size, imagePath, moduleName, flags).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AddSyntheticModuleWide method adds a synthetic module to the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic module.</param>
        /// <param name="imagePath">[in] Specifies the image name of the synthetic module. This is the name that will be returned as the name of the executable file for the synthetic module.<para/>
        /// The full path should be included if known.</param>
        /// <param name="moduleName">[in] Specifies the module name for the synthetic module.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHMOD_DEFAULT.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The memory region of the synthetic module, described by the Base and Size parameters, must not overlap the memory
        /// region of any other module. If all the modules are reloaded - for example, by calling <see cref="Reload"/> with
        /// the Module parameter set to an empty string - all synthetic modules will be discarded. For more information about
        /// synthetic modules, see Synthetic Modules.
        /// </remarks>
        public HRESULT TryAddSyntheticModuleWide(ulong @base, uint size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            InitDelegate(ref addSyntheticModuleWide, Vtbl3->AddSyntheticModuleWide);

            /*HRESULT AddSyntheticModuleWide(
            [In] ulong Base,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);*/
            return addSyntheticModuleWide(Raw, @base, size, imagePath, moduleName, flags);
        }

        #endregion
        #region RemoveSyntheticModule

        /// <summary>
        /// The RemoveSyntheticModule method removes a synthetic module from the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <remarks>
        /// If all the modules are reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the empty string - all synthetic modules will be discarded. For more information about synthetic modules, see Synthetic
        /// Modules.
        /// </remarks>
        public void RemoveSyntheticModule(ulong @base)
        {
            TryRemoveSyntheticModule(@base).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The RemoveSyntheticModule method removes a synthetic module from the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If all the modules are reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the empty string - all synthetic modules will be discarded. For more information about synthetic modules, see Synthetic
        /// Modules.
        /// </remarks>
        public HRESULT TryRemoveSyntheticModule(ulong @base)
        {
            InitDelegate(ref removeSyntheticModule, Vtbl3->RemoveSyntheticModule);

            /*HRESULT RemoveSyntheticModule(
            [In] ulong Base);*/
            return removeSyntheticModule(Raw, @base);
        }

        #endregion
        #region SetScopeFrameByIndex

        /// <summary>
        /// The SetScopeFrameByIndex method sets the current scope to the scope of one of the frames on the call stack.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the stack frame from which to set the scope. The index counts the number of frames from the top of the call stack.<para/>
        /// The frame at the top of the stack, representing the current call, has index zero.</param>
        /// <remarks>
        /// When an event occurs and the debugger engine breaks into a target, the scope is set to the current function call
        /// (the function that was executing when the event occurred). Calling this method with Index set to one will change
        /// the current scope to the caller of the current function; with Index set to two, the scope is changed to the caller's
        /// caller, and so on. For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public void SetScopeFrameByIndex(uint index)
        {
            TrySetScopeFrameByIndex(index).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The SetScopeFrameByIndex method sets the current scope to the scope of one of the frames on the call stack.
        /// </summary>
        /// <param name="index">[in] Specifies the index of the stack frame from which to set the scope. The index counts the number of frames from the top of the call stack.<para/>
        /// The frame at the top of the stack, representing the current call, has index zero.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When an event occurs and the debugger engine breaks into a target, the scope is set to the current function call
        /// (the function that was executing when the event occurred). Calling this method with Index set to one will change
        /// the current scope to the caller of the current function; with Index set to two, the scope is changed to the caller's
        /// caller, and so on. For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TrySetScopeFrameByIndex(uint index)
        {
            InitDelegate(ref setScopeFrameByIndex, Vtbl3->SetScopeFrameByIndex);

            /*HRESULT SetScopeFrameByIndex(
            [In] uint Index);*/
            return setScopeFrameByIndex(Raw, index);
        }

        #endregion
        #region SetScopeFromJitDebugInfo

        /// <summary>
        /// Recovers just-in-time (JIT) debugging information and sets currentdebugger scope context based on that information.
        /// </summary>
        /// <param name="outputControl">[in] An output control.</param>
        /// <param name="infoOffset">[in] An offset for the debugging information.</param>
        public void SetScopeFromJitDebugInfo(uint outputControl, ulong infoOffset)
        {
            TrySetScopeFromJitDebugInfo(outputControl, infoOffset).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// Recovers just-in-time (JIT) debugging information and sets currentdebugger scope context based on that information.
        /// </summary>
        /// <param name="outputControl">[in] An output control.</param>
        /// <param name="infoOffset">[in] An offset for the debugging information.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. The method gets JUT debugging information from a specified address from the debugging target, and then sets the currentdebugger scope context from that information.<para/>
        /// This method is equivalent to '.jdinfo' command.</returns>
        public HRESULT TrySetScopeFromJitDebugInfo(uint outputControl, ulong infoOffset)
        {
            InitDelegate(ref setScopeFromJitDebugInfo, Vtbl3->SetScopeFromJitDebugInfo);

            /*HRESULT SetScopeFromJitDebugInfo(
            [In] uint OutputControl,
            [In] ulong InfoOffset);*/
            return setScopeFromJitDebugInfo(Raw, outputControl, infoOffset);
        }

        #endregion
        #region SetScopeFromStoredEvent

        /// <summary>
        /// The SetScopeFromStoredEvent method sets the current scope to the scope of the stored event.
        /// </summary>
        /// <remarks>
        /// Currently only user-mode Minidumps can contain a stored event. The new scope is printed to the debugger console.
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public void SetScopeFromStoredEvent()
        {
            TrySetScopeFromStoredEvent().ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The SetScopeFromStoredEvent method sets the current scope to the scope of the stored event.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Currently only user-mode Minidumps can contain a stored event. The new scope is printed to the debugger console.
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TrySetScopeFromStoredEvent()
        {
            InitDelegate(ref setScopeFromStoredEvent, Vtbl3->SetScopeFromStoredEvent);

            /*HRESULT SetScopeFromStoredEvent();*/
            return setScopeFromStoredEvent(Raw);
        }

        #endregion
        #region OutputSymbolByOffset

        /// <summary>
        /// The OutputSymbolByOffset method looks up a symbol by address and prints the symbol name and other symbol information to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Specifies the flags used to determine what information is printed with the symbol. The following flags can be present: This allows the Offset parameter to specify any address within the symbol's memory allocation - not just the base address.</param>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the symbol to be printed.</param>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public void OutputSymbolByOffset(uint outputControl, DEBUG_OUTSYM flags, ulong offset)
        {
            TryOutputSymbolByOffset(outputControl, flags, offset).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputSymbolByOffset method looks up a symbol by address and prints the symbol name and other symbol information to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Specifies the flags used to determine what information is printed with the symbol. The following flags can be present: This allows the Offset parameter to specify any address within the symbol's memory allocation - not just the base address.</param>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the symbol to be printed.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryOutputSymbolByOffset(uint outputControl, DEBUG_OUTSYM flags, ulong offset)
        {
            InitDelegate(ref outputSymbolByOffset, Vtbl3->OutputSymbolByOffset);

            /*HRESULT OutputSymbolByOffset(
            [In] uint OutputControl,
            [In] DEBUG_OUTSYM Flags,
            [In] ulong Offset);*/
            return outputSymbolByOffset(Raw, outputControl, flags, offset);
        }

        #endregion
        #region GetFunctionEntryByOffset

        /// <summary>
        /// The GetFunctionEntryByOffset method returns the function entry information for a function.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the current process's virtual address space of the function's implementation. This is the value returned in the Offset parameter of <see cref="GetNextSymbolMatch"/> and <see cref="DebugSymbolGroup.GetSymbolOffset"/>, and the value of the Offset field in the <see cref="DEBUG_SYMBOL_ENTRY"/> structure.</param>
        /// <param name="flags">[in] Specifies a bit-flag which alters the behavior of this method. If the bit DEBUG_GETFNENT_RAW_ENTRY_ONLY is not set, the engine will provide artificial entries for well known cases.<para/>
        /// If this bit is set the artificial entries are not used.</param>
        /// <param name="buffer">[out, optional] Receives the function entry information. If the effective processor is an x86, this is the FPO_DATA structure for the function.<para/>
        /// For all other architectures, this is the IMAGE_FUNCTION_ENTRY structure for that architecture.</param>
        /// <param name="bufferSize">[in] Specifies the size of the buffer Buffer.</param>
        /// <returns>[out, optional] Specifies the size of the function entry information.</returns>
        /// <remarks>
        /// The structures FPO_DATA and IMAGE_FUNCTION_ENTRY are documented in "Image Help Library" which is included in Debugging
        /// Tools For Windows in the DbgHelp.chm file.
        /// </remarks>
        public uint GetFunctionEntryByOffset(ulong offset, DEBUG_GETFNENT flags, IntPtr buffer, uint bufferSize)
        {
            uint bufferNeeded;
            TryGetFunctionEntryByOffset(offset, flags, buffer, bufferSize, out bufferNeeded).ThrowDbgEngNotOk();

            return bufferNeeded;
        }

        /// <summary>
        /// The GetFunctionEntryByOffset method returns the function entry information for a function.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the current process's virtual address space of the function's implementation. This is the value returned in the Offset parameter of <see cref="GetNextSymbolMatch"/> and <see cref="DebugSymbolGroup.GetSymbolOffset"/>, and the value of the Offset field in the <see cref="DEBUG_SYMBOL_ENTRY"/> structure.</param>
        /// <param name="flags">[in] Specifies a bit-flag which alters the behavior of this method. If the bit DEBUG_GETFNENT_RAW_ENTRY_ONLY is not set, the engine will provide artificial entries for well known cases.<para/>
        /// If this bit is set the artificial entries are not used.</param>
        /// <param name="buffer">[out, optional] Receives the function entry information. If the effective processor is an x86, this is the FPO_DATA structure for the function.<para/>
        /// For all other architectures, this is the IMAGE_FUNCTION_ENTRY structure for that architecture.</param>
        /// <param name="bufferSize">[in] Specifies the size of the buffer Buffer.</param>
        /// <param name="bufferNeeded">[out, optional] Specifies the size of the function entry information.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The structures FPO_DATA and IMAGE_FUNCTION_ENTRY are documented in "Image Help Library" which is included in Debugging
        /// Tools For Windows in the DbgHelp.chm file.
        /// </remarks>
        public HRESULT TryGetFunctionEntryByOffset(ulong offset, DEBUG_GETFNENT flags, IntPtr buffer, uint bufferSize, out uint bufferNeeded)
        {
            InitDelegate(ref getFunctionEntryByOffset, Vtbl3->GetFunctionEntryByOffset);

            /*HRESULT GetFunctionEntryByOffset(
            [In] ulong Offset,
            [In] DEBUG_GETFNENT Flags,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BufferNeeded);*/
            return getFunctionEntryByOffset(Raw, offset, flags, buffer, bufferSize, out bufferNeeded);
        }

        #endregion
        #region GetFieldTypeAndOffset

        /// <summary>
        /// The GetFieldTypeAndOffset method returns the type of a field and its offset within a container.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="containerTypeId">[in] Specifies the type ID for the container's type. Examples of containers include structures, unions, and classes.</param>
        /// <param name="field">[in] Specifies the name of the field whose type and offset are requested. Subfields may be specified by using a dot-separated path.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the type
        /// of this field and its location relative to the location of MyStruct structure can be found by passing "MyField.MySubField"
        /// as the Field parameter to this method. For more information about types, see Types. For more information about
        /// symbols, see Symbols.
        /// </remarks>
        public GetFieldTypeAndOffsetResult GetFieldTypeAndOffset(ulong module, uint containerTypeId, string field)
        {
            GetFieldTypeAndOffsetResult result;
            TryGetFieldTypeAndOffset(module, containerTypeId, field, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetFieldTypeAndOffset method returns the type of a field and its offset within a container.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="containerTypeId">[in] Specifies the type ID for the container's type. Examples of containers include structures, unions, and classes.</param>
        /// <param name="field">[in] Specifies the name of the field whose type and offset are requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the type
        /// of this field and its location relative to the location of MyStruct structure can be found by passing "MyField.MySubField"
        /// as the Field parameter to this method. For more information about types, see Types. For more information about
        /// symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetFieldTypeAndOffset(ulong module, uint containerTypeId, string field, out GetFieldTypeAndOffsetResult result)
        {
            InitDelegate(ref getFieldTypeAndOffset, Vtbl3->GetFieldTypeAndOffset);
            /*HRESULT GetFieldTypeAndOffset(
            [In] ulong Module,
            [In] uint ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out uint FieldTypeId,
            [Out] out uint Offset);*/
            uint fieldTypeId;
            uint offset;
            HRESULT hr = getFieldTypeAndOffset(Raw, module, containerTypeId, field, out fieldTypeId, out offset);

            if (hr == HRESULT.S_OK)
                result = new GetFieldTypeAndOffsetResult(fieldTypeId, offset);
            else
                result = default(GetFieldTypeAndOffsetResult);

            return hr;
        }

        #endregion
        #region GetFieldTypeAndOffsetWide

        /// <summary>
        /// The GetFieldTypeAndOffsetWide method returns the type of a field and its offset within a container.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="containerTypeId">[in] Specifies the type ID for the container's type. Examples of containers include structures, unions, and classes.</param>
        /// <param name="field">[in] Specifies the name of the field whose type and offset are requested. Subfields may be specified by using a dot-separated path.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the type
        /// of this field and its location relative to the location of MyStruct structure can be found by passing "MyField.MySubField"
        /// as the Field parameter to this method. For more information about types, see Types. For more information about
        /// symbols, see Symbols.
        /// </remarks>
        public GetFieldTypeAndOffsetWideResult GetFieldTypeAndOffsetWide(ulong module, uint containerTypeId, string field)
        {
            GetFieldTypeAndOffsetWideResult result;
            TryGetFieldTypeAndOffsetWide(module, containerTypeId, field, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetFieldTypeAndOffsetWide method returns the type of a field and its offset within a container.
        /// </summary>
        /// <param name="module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="containerTypeId">[in] Specifies the type ID for the container's type. Examples of containers include structures, unions, and classes.</param>
        /// <param name="field">[in] Specifies the name of the field whose type and offset are requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the type
        /// of this field and its location relative to the location of MyStruct structure can be found by passing "MyField.MySubField"
        /// as the Field parameter to this method. For more information about types, see Types. For more information about
        /// symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetFieldTypeAndOffsetWide(ulong module, uint containerTypeId, string field, out GetFieldTypeAndOffsetWideResult result)
        {
            InitDelegate(ref getFieldTypeAndOffsetWide, Vtbl3->GetFieldTypeAndOffsetWide);
            /*HRESULT GetFieldTypeAndOffsetWide(
            [In] ulong Module,
            [In] uint ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out uint FieldTypeId,
            [Out] out uint Offset);*/
            uint fieldTypeId;
            uint offset;
            HRESULT hr = getFieldTypeAndOffsetWide(Raw, module, containerTypeId, field, out fieldTypeId, out offset);

            if (hr == HRESULT.S_OK)
                result = new GetFieldTypeAndOffsetWideResult(fieldTypeId, offset);
            else
                result = default(GetFieldTypeAndOffsetWideResult);

            return hr;
        }

        #endregion
        #region AddSyntheticSymbol

        /// <summary>
        /// The AddSyntheticSymbol method adds a synthetic symbol to a module in the current process.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the synthetic symbol.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic symbol.</param>
        /// <param name="name">[in] Specifies the name of the synthetic symbol.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHSYM_DEFAULT.</param>
        /// <returns>[out, optional] Receives the <see cref="DEBUG_MODULE_AND_ID"/> structure that identifies the synthetic symbol. If Id is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The location of the synthetic symbol must not be the same as the location of another symbol. If the module containing
        /// a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the name of the module - the synthetic symbol will be discarded. For more information about synthetic symbols,
        /// see Synthetic Symbols.
        /// </remarks>
        public DEBUG_MODULE_AND_ID AddSyntheticSymbol(ulong offset, uint size, string name, DEBUG_ADDSYNTHSYM flags)
        {
            DEBUG_MODULE_AND_ID id;
            TryAddSyntheticSymbol(offset, size, name, flags, out id).ThrowDbgEngNotOk();

            return id;
        }

        /// <summary>
        /// The AddSyntheticSymbol method adds a synthetic symbol to a module in the current process.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the synthetic symbol.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic symbol.</param>
        /// <param name="name">[in] Specifies the name of the synthetic symbol.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHSYM_DEFAULT.</param>
        /// <param name="id">[out, optional] Receives the <see cref="DEBUG_MODULE_AND_ID"/> structure that identifies the synthetic symbol. If Id is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The location of the synthetic symbol must not be the same as the location of another symbol. If the module containing
        /// a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the name of the module - the synthetic symbol will be discarded. For more information about synthetic symbols,
        /// see Synthetic Symbols.
        /// </remarks>
        public HRESULT TryAddSyntheticSymbol(ulong offset, uint size, string name, DEBUG_ADDSYNTHSYM flags, out DEBUG_MODULE_AND_ID id)
        {
            InitDelegate(ref addSyntheticSymbol, Vtbl3->AddSyntheticSymbol);

            /*HRESULT AddSyntheticSymbol(
            [In] ulong Offset,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);*/
            return addSyntheticSymbol(Raw, offset, size, name, flags, out id);
        }

        #endregion
        #region AddSyntheticSymbolWide

        /// <summary>
        /// The AddSyntheticSymbolWide method adds a synthetic symbol to a module in the current process.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the synthetic symbol.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic symbol.</param>
        /// <param name="name">[in] Specifies the name of the synthetic symbol.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHSYM_DEFAULT.</param>
        /// <returns>[out, optional] Receives the <see cref="DEBUG_MODULE_AND_ID"/> structure that identifies the synthetic symbol. If Id is NULL, this information is not returned.</returns>
        /// <remarks>
        /// The location of the synthetic symbol must not be the same as the location of another symbol. If the module containing
        /// a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the name of the module - the synthetic symbol will be discarded. For more information about synthetic symbols,
        /// see Synthetic Symbols.
        /// </remarks>
        public DEBUG_MODULE_AND_ID AddSyntheticSymbolWide(ulong offset, uint size, string name, DEBUG_ADDSYNTHSYM flags)
        {
            DEBUG_MODULE_AND_ID id;
            TryAddSyntheticSymbolWide(offset, size, name, flags, out id).ThrowDbgEngNotOk();

            return id;
        }

        /// <summary>
        /// The AddSyntheticSymbolWide method adds a synthetic symbol to a module in the current process.
        /// </summary>
        /// <param name="offset">[in] Specifies the location in the process's virtual address space of the synthetic symbol.</param>
        /// <param name="size">[in] Specifies the size in bytes of the synthetic symbol.</param>
        /// <param name="name">[in] Specifies the name of the synthetic symbol.</param>
        /// <param name="flags">[in] Set to DEBUG_ADDSYNTHSYM_DEFAULT.</param>
        /// <param name="id">[out, optional] Receives the <see cref="DEBUG_MODULE_AND_ID"/> structure that identifies the synthetic symbol. If Id is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The location of the synthetic symbol must not be the same as the location of another symbol. If the module containing
        /// a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the name of the module - the synthetic symbol will be discarded. For more information about synthetic symbols,
        /// see Synthetic Symbols.
        /// </remarks>
        public HRESULT TryAddSyntheticSymbolWide(ulong offset, uint size, string name, DEBUG_ADDSYNTHSYM flags, out DEBUG_MODULE_AND_ID id)
        {
            InitDelegate(ref addSyntheticSymbolWide, Vtbl3->AddSyntheticSymbolWide);

            /*HRESULT AddSyntheticSymbolWide(
            [In] ulong Offset,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);*/
            return addSyntheticSymbolWide(Raw, offset, size, name, flags, out id);
        }

        #endregion
        #region RemoveSyntheticSymbol

        /// <summary>
        /// The RemoveSyntheticSymbol method removes a synthetic symbol from a module in the current process.
        /// </summary>
        /// <param name="id">[in] Specifies the synthetic symbol to remove. This must be the same value returned in the Id parameter of <see cref="AddSyntheticSymbol"/>.<para/>
        /// See <see cref="DEBUG_MODULE_AND_ID"/> for details about the type of this parameter.</param>
        /// <remarks>
        /// If the module containing a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the
        /// Module parameter set to the name of the module - the synthetic symbol will be discarded. For more information about
        /// synthetic symbols, see Synthetic Symbols.
        /// </remarks>
        public void RemoveSyntheticSymbol(DEBUG_MODULE_AND_ID id)
        {
            TryRemoveSyntheticSymbol(id).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The RemoveSyntheticSymbol method removes a synthetic symbol from a module in the current process.
        /// </summary>
        /// <param name="id">[in] Specifies the synthetic symbol to remove. This must be the same value returned in the Id parameter of <see cref="AddSyntheticSymbol"/>.<para/>
        /// See <see cref="DEBUG_MODULE_AND_ID"/> for details about the type of this parameter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the module containing a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the
        /// Module parameter set to the name of the module - the synthetic symbol will be discarded. For more information about
        /// synthetic symbols, see Synthetic Symbols.
        /// </remarks>
        public HRESULT TryRemoveSyntheticSymbol(DEBUG_MODULE_AND_ID id)
        {
            InitDelegate(ref removeSyntheticSymbol, Vtbl3->RemoveSyntheticSymbol);

            /*HRESULT RemoveSyntheticSymbol(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id);*/
            return removeSyntheticSymbol(Raw, id);
        }

        #endregion
        #region GetSymbolEntriesByOffset

        /// <summary>
        /// The GetSymbolEntriesByOffset method returns the symbols which are located at a specified address.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the process's memory address space within the desired symbol's range. Not all symbols have a known range, so, for best results, use the base address of the symbol.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public GetSymbolEntriesByOffsetResult GetSymbolEntriesByOffset(ulong offset, uint flags)
        {
            GetSymbolEntriesByOffsetResult result;
            TryGetSymbolEntriesByOffset(offset, flags, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetSymbolEntriesByOffset method returns the symbols which are located at a specified address.
        /// </summary>
        /// <param name="offset">[in] Specifies a location in the process's memory address space within the desired symbol's range. Not all symbols have a known range, so, for best results, use the base address of the symbol.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolEntriesByOffset(ulong offset, uint flags, out GetSymbolEntriesByOffsetResult result)
        {
            InitDelegate(ref getSymbolEntriesByOffset, Vtbl3->GetSymbolEntriesByOffset);
            /*HRESULT GetSymbolEntriesByOffset(
            [In] ulong Offset,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Displacements,
            [In] uint IdsCount,
            [Out] out uint Entries);*/
            DEBUG_MODULE_AND_ID[] ids = null;
            ulong[] displacements = null;
            uint idsCount = 0;
            uint entries;
            HRESULT hr = getSymbolEntriesByOffset(Raw, offset, flags, ids, displacements, idsCount, out entries);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            idsCount = entries;
            displacements = new ulong[(int) idsCount];
            hr = getSymbolEntriesByOffset(Raw, offset, flags, ids, displacements, idsCount, out entries);

            if (hr == HRESULT.S_OK)
            {
                result = new GetSymbolEntriesByOffsetResult(ids, displacements);

                return hr;
            }

            fail:
            result = default(GetSymbolEntriesByOffsetResult);

            return hr;
        }

        #endregion
        #region GetSymbolEntriesByName

        /// <summary>
        /// The GetSymbolEntriesByName method returns the symbols whose names match a given pattern.
        /// </summary>
        /// <param name="symbol">[in] Specifies the pattern used to determine which symbols to return. This method returns the symbols whose name matches the string wildcard syntax pattern Symbol.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <returns>[out, optional] Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public DEBUG_MODULE_AND_ID[] GetSymbolEntriesByName(string symbol, uint flags)
        {
            DEBUG_MODULE_AND_ID[] ids;
            TryGetSymbolEntriesByName(symbol, flags, out ids).ThrowDbgEngNotOk();

            return ids;
        }

        /// <summary>
        /// The GetSymbolEntriesByName method returns the symbols whose names match a given pattern.
        /// </summary>
        /// <param name="symbol">[in] Specifies the pattern used to determine which symbols to return. This method returns the symbols whose name matches the string wildcard syntax pattern Symbol.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="ids">[out, optional] Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolEntriesByName(string symbol, uint flags, out DEBUG_MODULE_AND_ID[] ids)
        {
            InitDelegate(ref getSymbolEntriesByName, Vtbl3->GetSymbolEntriesByName);
            /*HRESULT GetSymbolEntriesByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids,
            [In] uint IdsCount,
            [Out] out uint Entries);*/
            ids = null;
            uint idsCount = 0;
            uint entries;
            HRESULT hr = getSymbolEntriesByName(Raw, symbol, flags, ids, idsCount, out entries);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            idsCount = entries;
            ids = new DEBUG_MODULE_AND_ID[(int) idsCount];
            hr = getSymbolEntriesByName(Raw, symbol, flags, ids, idsCount, out entries);
            fail:
            return hr;
        }

        #endregion
        #region GetSymbolEntriesByNameWide

        /// <summary>
        /// The GetSymbolEntriesByNameWide method returns the symbols whose names match a given pattern.
        /// </summary>
        /// <param name="symbol">[in] Specifies the pattern used to determine which symbols to return. This method returns the symbols whose name matches the string wildcard syntax pattern Symbol.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <returns>[out, optional] Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public DEBUG_MODULE_AND_ID[] GetSymbolEntriesByNameWide(string symbol, uint flags)
        {
            DEBUG_MODULE_AND_ID[] ids;
            TryGetSymbolEntriesByNameWide(symbol, flags, out ids).ThrowDbgEngNotOk();

            return ids;
        }

        /// <summary>
        /// The GetSymbolEntriesByNameWide method returns the symbols whose names match a given pattern.
        /// </summary>
        /// <param name="symbol">[in] Specifies the pattern used to determine which symbols to return. This method returns the symbols whose name matches the string wildcard syntax pattern Symbol.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="ids">[out, optional] Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolEntriesByNameWide(string symbol, uint flags, out DEBUG_MODULE_AND_ID[] ids)
        {
            InitDelegate(ref getSymbolEntriesByNameWide, Vtbl3->GetSymbolEntriesByNameWide);
            /*HRESULT GetSymbolEntriesByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids,
            [In] uint IdsCount,
            [Out] out uint Entries);*/
            ids = null;
            uint idsCount = 0;
            uint entries;
            HRESULT hr = getSymbolEntriesByNameWide(Raw, symbol, flags, ids, idsCount, out entries);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            idsCount = entries;
            ids = new DEBUG_MODULE_AND_ID[(int) idsCount];
            hr = getSymbolEntriesByNameWide(Raw, symbol, flags, ids, idsCount, out entries);
            fail:
            return hr;
        }

        #endregion
        #region GetSymbolEntryByToken

        /// <summary>
        /// Looks up a symbol by using a managed metadata token.
        /// </summary>
        /// <param name="moduleBase">[in] The base of the module.</param>
        /// <param name="token">[in] The token to use to look up the symbol.</param>
        /// <returns>[out] A pointer to the module as a <see cref="DEBUG_MODULE_AND_ID"/> structure.</returns>
        public DEBUG_MODULE_AND_ID GetSymbolEntryByToken(ulong moduleBase, uint token)
        {
            DEBUG_MODULE_AND_ID id;
            TryGetSymbolEntryByToken(moduleBase, token, out id).ThrowDbgEngNotOk();

            return id;
        }

        /// <summary>
        /// Looks up a symbol by using a managed metadata token.
        /// </summary>
        /// <param name="moduleBase">[in] The base of the module.</param>
        /// <param name="token">[in] The token to use to look up the symbol.</param>
        /// <param name="id">[out] A pointer to the module as a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSymbolEntryByToken(ulong moduleBase, uint token, out DEBUG_MODULE_AND_ID id)
        {
            InitDelegate(ref getSymbolEntryByToken, Vtbl3->GetSymbolEntryByToken);

            /*HRESULT GetSymbolEntryByToken(
            [In] ulong ModuleBase,
            [In] uint Token,
            [Out] out DEBUG_MODULE_AND_ID Id);*/
            return getSymbolEntryByToken(Raw, moduleBase, token, out id);
        }

        #endregion
        #region GetSymbolEntryInformation

        /// <summary>
        /// The GetSymbolEntryInformation method returns the symbol entry information for a symbol.
        /// </summary>
        /// <param name="id">[in] Specifies the module and symbol ID of the desired symbol. For details on this structure, see <see cref="DEBUG_MODULE_AND_ID"/>.</param>
        /// <returns>[out] Receives the symbol entry information for the symbol. For details on this structure, see <see cref="DEBUG_SYMBOL_ENTRY"/>.</returns>
        /// <remarks>
        /// For details on the symbol entry information, see Scopes and Symbol Groups.
        /// </remarks>
        public DEBUG_SYMBOL_ENTRY GetSymbolEntryInformation(DEBUG_MODULE_AND_ID id)
        {
            DEBUG_SYMBOL_ENTRY info;
            TryGetSymbolEntryInformation(id, out info).ThrowDbgEngNotOk();

            return info;
        }

        /// <summary>
        /// The GetSymbolEntryInformation method returns the symbol entry information for a symbol.
        /// </summary>
        /// <param name="id">[in] Specifies the module and symbol ID of the desired symbol. For details on this structure, see <see cref="DEBUG_MODULE_AND_ID"/>.</param>
        /// <param name="info">[out] Receives the symbol entry information for the symbol. For details on this structure, see <see cref="DEBUG_SYMBOL_ENTRY"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For details on the symbol entry information, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolEntryInformation(DEBUG_MODULE_AND_ID id, out DEBUG_SYMBOL_ENTRY info)
        {
            InitDelegate(ref getSymbolEntryInformation, Vtbl3->GetSymbolEntryInformation);

            /*HRESULT GetSymbolEntryInformation(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [Out] out DEBUG_SYMBOL_ENTRY Info);*/
            return getSymbolEntryInformation(Raw, ref id, out info);
        }

        #endregion
        #region GetSymbolEntryString

        /// <summary>
        /// The GetSymbolEntryString method returns string information for the specified symbol.
        /// </summary>
        /// <param name="id">[in] Specifies the symbols whose memory regions are being requested. The <see cref="DEBUG_MODULE_AND_ID"/> structure contains the module containing the symbol and the symbol ID of the symbol within the module.</param>
        /// <param name="which">[in] Specifies the index of the desired string. Often this is zero, as most symbols contain just one string (their name).<para/>
        /// But some symbols may contain more than one string -- for example, annotation symbols.</param>
        /// <returns>[out, optional] Receives the name of the symbol. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetSymbolEntryString(DEBUG_MODULE_AND_ID id, uint which)
        {
            string bufferResult;
            TryGetSymbolEntryString(id, which, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolEntryString method returns string information for the specified symbol.
        /// </summary>
        /// <param name="id">[in] Specifies the symbols whose memory regions are being requested. The <see cref="DEBUG_MODULE_AND_ID"/> structure contains the module containing the symbol and the symbol ID of the symbol within the module.</param>
        /// <param name="which">[in] Specifies the index of the desired string. Often this is zero, as most symbols contain just one string (their name).<para/>
        /// But some symbols may contain more than one string -- for example, annotation symbols.</param>
        /// <param name="bufferResult">[out, optional] Receives the name of the symbol. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolEntryString(DEBUG_MODULE_AND_ID id, uint which, out string bufferResult)
        {
            InitDelegate(ref getSymbolEntryString, Vtbl3->GetSymbolEntryString);
            /*HRESULT GetSymbolEntryString(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint stringSize;
            HRESULT hr = getSymbolEntryString(Raw, id, which, buffer, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) stringSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolEntryString(Raw, id, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSymbolEntryStringWide

        /// <summary>
        /// The GetSymbolEntryStringWide method returns string information for the specified symbol.
        /// </summary>
        /// <param name="id">[in] Specifies the symbols whose memory regions are being requested. The <see cref="DEBUG_MODULE_AND_ID"/> structure contains the module containing the symbol and the symbol ID of the symbol within the module.</param>
        /// <param name="which">[in] Specifies the index of the desired string. Often this is zero, as most symbols contain just one string (their name).<para/>
        /// But some symbols may contain more than one string -- for example, annotation symbols.</param>
        /// <returns>[out, optional] Receives the name of the symbol. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public string GetSymbolEntryStringWide(DEBUG_MODULE_AND_ID id, uint which)
        {
            string bufferResult;
            TryGetSymbolEntryStringWide(id, which, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolEntryStringWide method returns string information for the specified symbol.
        /// </summary>
        /// <param name="id">[in] Specifies the symbols whose memory regions are being requested. The <see cref="DEBUG_MODULE_AND_ID"/> structure contains the module containing the symbol and the symbol ID of the symbol within the module.</param>
        /// <param name="which">[in] Specifies the index of the desired string. Often this is zero, as most symbols contain just one string (their name).<para/>
        /// But some symbols may contain more than one string -- for example, annotation symbols.</param>
        /// <param name="bufferResult">[out, optional] Receives the name of the symbol. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        public HRESULT TryGetSymbolEntryStringWide(DEBUG_MODULE_AND_ID id, uint which, out string bufferResult)
        {
            InitDelegate(ref getSymbolEntryStringWide, Vtbl3->GetSymbolEntryStringWide);
            /*HRESULT GetSymbolEntryStringWide(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint stringSize;
            HRESULT hr = getSymbolEntryStringWide(Raw, id, which, buffer, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) stringSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolEntryStringWide(Raw, id, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSymbolEntryOffsetRegions

        /// <summary>
        /// Returns all the memory regions known to be associatedwith a symbol.
        /// </summary>
        /// <param name="id">[in] The ID of a module as a pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] The memory regions associated with the symbol.</returns>
        public DEBUG_OFFSET_REGION[] GetSymbolEntryOffsetRegions(DEBUG_MODULE_AND_ID id, uint flags)
        {
            DEBUG_OFFSET_REGION[] regions;
            TryGetSymbolEntryOffsetRegions(id, flags, out regions).ThrowDbgEngNotOk();

            return regions;
        }

        /// <summary>
        /// Returns all the memory regions known to be associatedwith a symbol.
        /// </summary>
        /// <param name="id">[in] The ID of a module as a pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="regions">[out] The memory regions associated with the symbol.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This function returns all known memory regions that associatedwith a specified symbol.<para/>
        /// Simple symbols have a single region that starts from their base. More complicated regions, such as functions that have multiple code areas, can have an arbitrarilylarge number of regions.<para/>
        /// The quality of information returned is highlydependent on the symbolic information available.</returns>
        public HRESULT TryGetSymbolEntryOffsetRegions(DEBUG_MODULE_AND_ID id, uint flags, out DEBUG_OFFSET_REGION[] regions)
        {
            InitDelegate(ref getSymbolEntryOffsetRegions, Vtbl3->GetSymbolEntryOffsetRegions);
            /*HRESULT GetSymbolEntryOffsetRegions(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_OFFSET_REGION[] Regions,
            [In] uint RegionsCount,
            [Out] out uint RegionsAvail);*/
            regions = null;
            uint regionsCount = 0;
            uint regionsAvail;
            HRESULT hr = getSymbolEntryOffsetRegions(Raw, id, flags, regions, regionsCount, out regionsAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            regionsCount = regionsAvail;
            regions = new DEBUG_OFFSET_REGION[(int) regionsCount];
            hr = getSymbolEntryOffsetRegions(Raw, id, flags, regions, regionsCount, out regionsAvail);
            fail:
            return hr;
        }

        #endregion
        #region GetSymbolEntryBySymbolEntry

        /// <summary>
        /// Allows navigation within thesymbol entry hierarchy.
        /// </summary>
        /// <param name="fromId">[in] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the input ID.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the output ID.</returns>
        public DEBUG_MODULE_AND_ID GetSymbolEntryBySymbolEntry(DEBUG_MODULE_AND_ID fromId, uint flags)
        {
            DEBUG_MODULE_AND_ID toId;
            TryGetSymbolEntryBySymbolEntry(fromId, flags, out toId).ThrowDbgEngNotOk();

            return toId;
        }

        /// <summary>
        /// Allows navigation within thesymbol entry hierarchy.
        /// </summary>
        /// <param name="fromId">[in] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the input ID.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="toId">[out] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the output ID.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSymbolEntryBySymbolEntry(DEBUG_MODULE_AND_ID fromId, uint flags, out DEBUG_MODULE_AND_ID toId)
        {
            InitDelegate(ref getSymbolEntryBySymbolEntry, Vtbl3->GetSymbolEntryBySymbolEntry);

            /*HRESULT GetSymbolEntryBySymbolEntry(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID FromId,
            [In] uint Flags,
            [Out] out DEBUG_MODULE_AND_ID ToId);*/
            return getSymbolEntryBySymbolEntry(Raw, fromId, flags, out toId);
        }

        #endregion
        #region GetSourceEntriesByOffset

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory by using an offset.
        /// </summary>
        /// <param name="offset">[in] The offset of the entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to a returned entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</returns>
        public DEBUG_SYMBOL_SOURCE_ENTRY[] GetSourceEntriesByOffset(ulong offset, uint flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY[] entries;
            TryGetSourceEntriesByOffset(offset, flags, out entries).ThrowDbgEngNotOk();

            return entries;
        }

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory by using an offset.
        /// </summary>
        /// <param name="offset">[in] The offset of the entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="entries">[out] A pointer to a returned entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSourceEntriesByOffset(ulong offset, uint flags, out DEBUG_SYMBOL_SOURCE_ENTRY[] entries)
        {
            InitDelegate(ref getSourceEntriesByOffset, Vtbl3->GetSourceEntriesByOffset);
            /*HRESULT GetSourceEntriesByOffset(
            [In] ulong Offset,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail);*/
            entries = null;
            uint entriesCount = 0;
            uint entriesAvail;
            HRESULT hr = getSourceEntriesByOffset(Raw, offset, flags, entries, entriesCount, out entriesAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            entriesCount = entriesAvail;
            entries = new DEBUG_SYMBOL_SOURCE_ENTRY[(int) entriesCount];
            hr = getSourceEntriesByOffset(Raw, offset, flags, entries, entriesCount, out entriesAvail);
            fail:
            return hr;
        }

        #endregion
        #region GetSourceEntriesByLine

        /// <summary>
        /// The GetSourceEntriesByLine method queries symbol information and returns locations in the target's memory that correspond to lines in a source file.
        /// </summary>
        /// <param name="line">[in] Specifies the line in the source file for which to query. The number for the first line is 1.</param>
        /// <param name="file">[in] Specifies the source file. The symbols for each module in the target are queried for this file.</param>
        /// <param name="flags">[in] Specifies bit flags that control the behavior of this method. Flags can be any combination of values from the following table.<para/>
        /// If this option is not set, the debugger engine will load the symbols for all modules until it finds the file specified in File.<para/>
        /// To use the default set of flags, set Flags to DEBUG_GSEL_DEFAULT. This has all the flags in the previous table turned off.</param>
        /// <returns>[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for. Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        public DEBUG_SYMBOL_SOURCE_ENTRY[] GetSourceEntriesByLine(uint line, string file, uint flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY[] entries;
            TryGetSourceEntriesByLine(line, file, flags, out entries).ThrowDbgEngNotOk();

            return entries;
        }

        /// <summary>
        /// The GetSourceEntriesByLine method queries symbol information and returns locations in the target's memory that correspond to lines in a source file.
        /// </summary>
        /// <param name="line">[in] Specifies the line in the source file for which to query. The number for the first line is 1.</param>
        /// <param name="file">[in] Specifies the source file. The symbols for each module in the target are queried for this file.</param>
        /// <param name="flags">[in] Specifies bit flags that control the behavior of this method. Flags can be any combination of values from the following table.<para/>
        /// If this option is not set, the debugger engine will load the symbols for all modules until it finds the file specified in File.<para/>
        /// To use the default set of flags, set Flags to DEBUG_GSEL_DEFAULT. This has all the flags in the previous table turned off.</param>
        /// <param name="entries">[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for. Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetSourceEntriesByLine(uint line, string file, uint flags, out DEBUG_SYMBOL_SOURCE_ENTRY[] entries)
        {
            InitDelegate(ref getSourceEntriesByLine, Vtbl3->GetSourceEntriesByLine);
            /*HRESULT GetSourceEntriesByLine(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail);*/
            entries = null;
            uint entriesCount = 0;
            uint entriesAvail;
            HRESULT hr = getSourceEntriesByLine(Raw, line, file, flags, entries, entriesCount, out entriesAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            entriesCount = entriesAvail;
            entries = new DEBUG_SYMBOL_SOURCE_ENTRY[(int) entriesCount];
            hr = getSourceEntriesByLine(Raw, line, file, flags, entries, entriesCount, out entriesAvail);
            fail:
            return hr;
        }

        #endregion
        #region GetSourceEntriesByLineWide

        /// <summary>
        /// The GetSourceEntriesByLineWide method queries symbol information and returns locations in the target's memory that correspond to lines in a source file.
        /// </summary>
        /// <param name="line">[in] Specifies the line in the source file for which to query. The number for the first line is 1.</param>
        /// <param name="file">[in] Specifies the source file. The symbols for each module in the target are queried for this file.</param>
        /// <param name="flags">[in] Specifies bit flags that control the behavior of this method. Flags can be any combination of values from the following table.<para/>
        /// If this option is not set, the debugger engine will load the symbols for all modules until it finds the file specified in File.<para/>
        /// To use the default set of flags, set Flags to DEBUG_GSEL_DEFAULT. This has all the flags in the previous table turned off.</param>
        /// <returns>[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for. Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        public DEBUG_SYMBOL_SOURCE_ENTRY[] GetSourceEntriesByLineWide(uint line, string file, uint flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY[] entries;
            TryGetSourceEntriesByLineWide(line, file, flags, out entries).ThrowDbgEngNotOk();

            return entries;
        }

        /// <summary>
        /// The GetSourceEntriesByLineWide method queries symbol information and returns locations in the target's memory that correspond to lines in a source file.
        /// </summary>
        /// <param name="line">[in] Specifies the line in the source file for which to query. The number for the first line is 1.</param>
        /// <param name="file">[in] Specifies the source file. The symbols for each module in the target are queried for this file.</param>
        /// <param name="flags">[in] Specifies bit flags that control the behavior of this method. Flags can be any combination of values from the following table.<para/>
        /// If this option is not set, the debugger engine will load the symbols for all modules until it finds the file specified in File.<para/>
        /// To use the default set of flags, set Flags to DEBUG_GSEL_DEFAULT. This has all the flags in the previous table turned off.</param>
        /// <param name="entries">[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for. Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetSourceEntriesByLineWide(uint line, string file, uint flags, out DEBUG_SYMBOL_SOURCE_ENTRY[] entries)
        {
            InitDelegate(ref getSourceEntriesByLineWide, Vtbl3->GetSourceEntriesByLineWide);
            /*HRESULT GetSourceEntriesByLineWide(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail);*/
            entries = null;
            uint entriesCount = 0;
            uint entriesAvail;
            HRESULT hr = getSourceEntriesByLineWide(Raw, line, file, flags, entries, entriesCount, out entriesAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            entriesCount = entriesAvail;
            entries = new DEBUG_SYMBOL_SOURCE_ENTRY[(int) entriesCount];
            hr = getSourceEntriesByLineWide(Raw, line, file, flags, entries, entriesCount, out entriesAvail);
            fail:
            return hr;
        }

        #endregion
        #region GetSourceEntryString

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="which">[in] A value that determines which types to return.</param>
        /// <returns>[out] A pointer to a string buffer for the results.</returns>
        public string GetSourceEntryString(DEBUG_SYMBOL_SOURCE_ENTRY entry, uint which)
        {
            string bufferResult;
            TryGetSourceEntryString(entry, which, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="which">[in] A value that determines which types to return.</param>
        /// <param name="bufferResult">[out] A pointer to a string buffer for the results.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This method can return multiple results for a source lookup.<para/>
        /// This allows for all possible results to be returned.</returns>
        public HRESULT TryGetSourceEntryString(DEBUG_SYMBOL_SOURCE_ENTRY entry, uint which, out string bufferResult)
        {
            InitDelegate(ref getSourceEntryString, Vtbl3->GetSourceEntryString);
            /*HRESULT GetSourceEntryString(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint stringSize;
            HRESULT hr = getSourceEntryString(Raw, entry, which, buffer, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) stringSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSourceEntryString(Raw, entry, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSourceEntryStringWide

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="which">[in] A value that determines which types to return.</param>
        /// <returns>[out] A pointer to a Unicode character string buffer for the results.</returns>
        public string GetSourceEntryStringWide(DEBUG_SYMBOL_SOURCE_ENTRY entry, uint which)
        {
            string bufferResult;
            TryGetSourceEntryStringWide(entry, which, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="which">[in] A value that determines which types to return.</param>
        /// <param name="bufferResult">[out] A pointer to a Unicode character string buffer for the results.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This method can return multiple results for a source lookup.<para/>
        /// This allows for all possible results to be returned.</returns>
        public HRESULT TryGetSourceEntryStringWide(DEBUG_SYMBOL_SOURCE_ENTRY entry, uint which, out string bufferResult)
        {
            InitDelegate(ref getSourceEntryStringWide, Vtbl3->GetSourceEntryStringWide);
            /*HRESULT GetSourceEntryStringWide(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint stringSize;
            HRESULT hr = getSourceEntryStringWide(Raw, entry, which, buffer, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) stringSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSourceEntryStringWide(Raw, entry, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = buffer.ToString();

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSourceEntryOffsetRegions

        /// <summary>
        /// Returns all memory regions known to be associatedwith a source entry.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] The memory regions associated with the source entry.</returns>
        public DEBUG_OFFSET_REGION[] GetSourceEntryOffsetRegions(DEBUG_SYMBOL_SOURCE_ENTRY entry, uint flags)
        {
            DEBUG_OFFSET_REGION[] regions;
            TryGetSourceEntryOffsetRegions(entry, flags, out regions).ThrowDbgEngNotOk();

            return regions;
        }

        /// <summary>
        /// Returns all memory regions known to be associatedwith a source entry.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="regions">[out] The memory regions associated with the source entry.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This function returns all known memory regions that associatedwith a specified source entry.<para/>
        /// Simple symbols have a single region that starts from their base. More complicated regions, such as functions that have multiple code areas, can have an arbitrarilylarge number of regions.</returns>
        public HRESULT TryGetSourceEntryOffsetRegions(DEBUG_SYMBOL_SOURCE_ENTRY entry, uint flags, out DEBUG_OFFSET_REGION[] regions)
        {
            InitDelegate(ref getSourceEntryOffsetRegions, Vtbl3->GetSourceEntryOffsetRegions);
            /*HRESULT GetSourceEntryOffsetRegions(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_OFFSET_REGION[] Regions,
            [In] uint RegionsCount,
            [Out] out uint RegionsAvail);*/
            regions = null;
            uint regionsCount = 0;
            uint regionsAvail;
            HRESULT hr = getSourceEntryOffsetRegions(Raw, entry, flags, regions, regionsCount, out regionsAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            regionsCount = regionsAvail;
            regions = new DEBUG_OFFSET_REGION[(int) regionsCount];
            hr = getSourceEntryOffsetRegions(Raw, entry, flags, regions, regionsCount, out regionsAvail);
            fail:
            return hr;
        }

        #endregion
        #region GetSourceEntryBySourceEntry

        /// <summary>
        /// Allows navigation within thesource entries.
        /// </summary>
        /// <param name="fromEntry">[in] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the input entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the output entry.</returns>
        public DEBUG_SYMBOL_SOURCE_ENTRY GetSourceEntryBySourceEntry(DEBUG_SYMBOL_SOURCE_ENTRY fromEntry, uint flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY toEntry;
            TryGetSourceEntryBySourceEntry(fromEntry, flags, out toEntry).ThrowDbgEngNotOk();

            return toEntry;
        }

        /// <summary>
        /// Allows navigation within thesource entries.
        /// </summary>
        /// <param name="fromEntry">[in] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the input entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="toEntry">[out] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the output entry.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSourceEntryBySourceEntry(DEBUG_SYMBOL_SOURCE_ENTRY fromEntry, uint flags, out DEBUG_SYMBOL_SOURCE_ENTRY toEntry)
        {
            InitDelegate(ref getSourceEntryBySourceEntry, Vtbl3->GetSourceEntryBySourceEntry);

            /*HRESULT GetSourceEntryBySourceEntry(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY FromEntry,
            [In] uint Flags,
            [Out] out DEBUG_SYMBOL_SOURCE_ENTRY ToEntry);*/
            return getSourceEntryBySourceEntry(Raw, fromEntry, flags, out toEntry);
        }

        #endregion
        #endregion
        #region IDebugSymbols4
        #region GetScopeEx

        /// <summary>
        /// Gets the scope as an extended frame structure.
        /// </summary>
        /// <param name="scopeContext">[out] A pointer to the scope context returned.</param>
        /// <param name="scopeContextSize">[in] The size of the scope context.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetScopeExResult GetScopeEx(IntPtr scopeContext, uint scopeContextSize)
        {
            GetScopeExResult result;
            TryGetScopeEx(scopeContext, scopeContextSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// Gets the scope as an extended frame structure.
        /// </summary>
        /// <param name="scopeContext">[out] A pointer to the scope context returned.</param>
        /// <param name="scopeContextSize">[in] The size of the scope context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetScopeEx(IntPtr scopeContext, uint scopeContextSize, out GetScopeExResult result)
        {
            InitDelegate(ref getScopeEx, Vtbl4->GetScopeEx);
            /*HRESULT GetScopeEx(
            [Out] out ulong InstructionOffset,
            [Out] out DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);*/
            ulong instructionOffset;
            DEBUG_STACK_FRAME_EX scopeFrame;
            HRESULT hr = getScopeEx(Raw, out instructionOffset, out scopeFrame, scopeContext, scopeContextSize);

            if (hr == HRESULT.S_OK)
                result = new GetScopeExResult(instructionOffset, scopeFrame);
            else
                result = default(GetScopeExResult);

            return hr;
        }

        #endregion
        #region SetScopeEx

        /// <summary>
        /// Sets the scope as an extended frame structure.
        /// </summary>
        /// <param name="instructionOffset">[in] The offset of the instruction for the scope.</param>
        /// <param name="scopeFrame">[in, optional] The scope frame to set as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.</param>
        /// <param name="scopeContext">[in] A pointer to a scope context.</param>
        /// <param name="scopeContextSize">[in] The size of the scope context.</param>
        public void SetScopeEx(ulong instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame, IntPtr scopeContext, uint scopeContextSize)
        {
            TrySetScopeEx(instructionOffset, scopeFrame, scopeContext, scopeContextSize).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// Sets the scope as an extended frame structure.
        /// </summary>
        /// <param name="instructionOffset">[in] The offset of the instruction for the scope.</param>
        /// <param name="scopeFrame">[in, optional] The scope frame to set as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.</param>
        /// <param name="scopeContext">[in] A pointer to a scope context.</param>
        /// <param name="scopeContextSize">[in] The size of the scope context.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySetScopeEx(ulong instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame, IntPtr scopeContext, uint scopeContextSize)
        {
            InitDelegate(ref setScopeEx, Vtbl4->SetScopeEx);

            /*HRESULT SetScopeEx(
            [In] ulong InstructionOffset,
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);*/
            return setScopeEx(Raw, instructionOffset, scopeFrame, scopeContext, scopeContextSize);
        }

        #endregion
        #region GetNameByInlineContext

        /// <summary>
        /// Gets a name by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the name.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetNameByInlineContextResult GetNameByInlineContext(ulong offset, uint inlineContext)
        {
            GetNameByInlineContextResult result;
            TryGetNameByInlineContext(offset, inlineContext, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// Gets a name by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the name.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetNameByInlineContext(ulong offset, uint inlineContext, out GetNameByInlineContextResult result)
        {
            InitDelegate(ref getNameByInlineContext, Vtbl4->GetNameByInlineContext);
            /*HRESULT GetNameByInlineContext(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            ulong displacement;
            HRESULT hr = getNameByInlineContext(Raw, offset, inlineContext, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getNameByInlineContext(Raw, offset, inlineContext, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByInlineContextResult(nameBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetNameByInlineContextResult);

            return hr;
        }

        #endregion
        #region GetNameByInlineContextWide

        /// <summary>
        /// Gets a name by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the inline context.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetNameByInlineContextWideResult GetNameByInlineContextWide(ulong offset, uint inlineContext)
        {
            GetNameByInlineContextWideResult result;
            TryGetNameByInlineContextWide(offset, inlineContext, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// Gets a name by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the inline context.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetNameByInlineContextWide(ulong offset, uint inlineContext, out GetNameByInlineContextWideResult result)
        {
            InitDelegate(ref getNameByInlineContextWide, Vtbl4->GetNameByInlineContextWide);
            /*HRESULT GetNameByInlineContextWide(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);*/
            StringBuilder nameBuffer = null;
            int nameBufferSize = 0;
            uint nameSize;
            ulong displacement;
            HRESULT hr = getNameByInlineContextWide(Raw, offset, inlineContext, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = (int) nameSize;
            nameBuffer = new StringBuilder(nameBufferSize);
            hr = getNameByInlineContextWide(Raw, offset, inlineContext, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByInlineContextWideResult(nameBuffer.ToString(), displacement);

                return hr;
            }

            fail:
            result = default(GetNameByInlineContextWideResult);

            return hr;
        }

        #endregion
        #region GetLineByInlineContext

        /// <summary>
        /// Gets a line by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the line.</param>
        /// <param name="fileBufferSize">[in] The size of the file buffer.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLineByInlineContextResult GetLineByInlineContext(ulong offset, int fileBufferSize)
        {
            GetLineByInlineContextResult result;
            TryGetLineByInlineContext(offset, fileBufferSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// Gets a line by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the line.</param>
        /// <param name="fileBufferSize">[in] The size of the file buffer.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetLineByInlineContext(ulong offset, int fileBufferSize, out GetLineByInlineContextResult result)
        {
            InitDelegate(ref getLineByInlineContext, Vtbl4->GetLineByInlineContext);
            /*HRESULT GetLineByInlineContext(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);*/
            uint inlineContext = 0;
            uint line;
            StringBuilder fileBuffer = null;
            uint fileSize;
            ulong displacement;
            HRESULT hr = getLineByInlineContext(Raw, offset, inlineContext, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            inlineContext = line;
            fileBuffer = new StringBuilder((int) inlineContext);
            hr = getLineByInlineContext(Raw, offset, inlineContext, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByInlineContextResult(fileBuffer.ToString(), fileSize, displacement);

                return hr;
            }

            fail:
            result = default(GetLineByInlineContextResult);

            return hr;
        }

        #endregion
        #region GetLineByInlineContextWide

        /// <summary>
        /// Gets a line by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the line.</param>
        /// <param name="fileBufferSize">[in] The size of the file buffer.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLineByInlineContextWideResult GetLineByInlineContextWide(ulong offset, int fileBufferSize)
        {
            GetLineByInlineContextWideResult result;
            TryGetLineByInlineContextWide(offset, fileBufferSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// Gets a line by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the line.</param>
        /// <param name="fileBufferSize">[in] The size of the file buffer.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetLineByInlineContextWide(ulong offset, int fileBufferSize, out GetLineByInlineContextWideResult result)
        {
            InitDelegate(ref getLineByInlineContextWide, Vtbl4->GetLineByInlineContextWide);
            /*HRESULT GetLineByInlineContextWide(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);*/
            uint inlineContext = 0;
            uint line;
            StringBuilder fileBuffer = null;
            uint fileSize;
            ulong displacement;
            HRESULT hr = getLineByInlineContextWide(Raw, offset, inlineContext, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            inlineContext = line;
            fileBuffer = new StringBuilder((int) inlineContext);
            hr = getLineByInlineContextWide(Raw, offset, inlineContext, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByInlineContextWideResult(fileBuffer.ToString(), fileSize, displacement);

                return hr;
            }

            fail:
            result = default(GetLineByInlineContextWideResult);

            return hr;
        }

        #endregion
        #region OutputSymbolByInlineContext

        /// <summary>
        /// Specifies an output symbol by using an inline context.
        /// </summary>
        /// <param name="outputControl">[in] An output control.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="offset">[in] An offset.</param>
        /// <param name="inlineContext">[in] An inline context.</param>
        public void OutputSymbolByInlineContext(uint outputControl, uint flags, ulong offset, uint inlineContext)
        {
            TryOutputSymbolByInlineContext(outputControl, flags, offset, inlineContext).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// Specifies an output symbol by using an inline context.
        /// </summary>
        /// <param name="outputControl">[in] An output control.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="offset">[in] An offset.</param>
        /// <param name="inlineContext">[in] An inline context.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryOutputSymbolByInlineContext(uint outputControl, uint flags, ulong offset, uint inlineContext)
        {
            InitDelegate(ref outputSymbolByInlineContext, Vtbl4->OutputSymbolByInlineContext);

            /*HRESULT OutputSymbolByInlineContext(
            [In] uint OutputControl,
            [In] uint Flags,
            [In] ulong Offset,
            [In] uint InlineContext);*/
            return outputSymbolByInlineContext(Raw, outputControl, flags, offset, inlineContext);
        }

        #endregion
        #endregion
        #region IDebugSymbols5
        #region GetCurrentScopeFrameIndexEx

        /// <summary>
        /// Gets the index of the current frame.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to an index that this function gets.</returns>
        public uint GetCurrentScopeFrameIndexEx(DEBUG_FRAME flags)
        {
            uint index;
            TryGetCurrentScopeFrameIndexEx(flags, out index).ThrowDbgEngNotOk();

            return index;
        }

        /// <summary>
        /// Gets the index of the current frame.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="index">[out] A pointer to an index that this function gets.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetCurrentScopeFrameIndexEx(DEBUG_FRAME flags, out uint index)
        {
            InitDelegate(ref getCurrentScopeFrameIndexEx, Vtbl5->GetCurrentScopeFrameIndexEx);

            /*HRESULT GetCurrentScopeFrameIndexEx(
            [In] DEBUG_FRAME Flags,
            [Out] out uint Index);*/
            return getCurrentScopeFrameIndexEx(Raw, flags, out index);
        }

        #endregion
        #region SetScopeFrameByIndexEx

        /// <summary>
        /// Sets the current frame by using an index.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="index">[in] An index by which to set the frame.</param>
        public void SetScopeFrameByIndexEx(DEBUG_FRAME flags, uint index)
        {
            TrySetScopeFrameByIndexEx(flags, index).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// Sets the current frame by using an index.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="index">[in] An index by which to set the frame.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySetScopeFrameByIndexEx(DEBUG_FRAME flags, uint index)
        {
            InitDelegate(ref setScopeFrameByIndexEx, Vtbl5->SetScopeFrameByIndexEx);

            /*HRESULT SetScopeFrameByIndexEx(
            [In] DEBUG_FRAME Flags,
            [In] uint Index);*/
            return setScopeFrameByIndexEx(Raw, flags, index);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugSymbols

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolOptionsDelegate getSymbolOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSymbolOptionsDelegate setSymbolOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberModulesDelegate getNumberModules;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolPathDelegate getSymbolPath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSymbolPathDelegate setSymbolPath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetImagePathDelegate getImagePath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetImagePathDelegate setImagePath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourcePathDelegate getSourcePath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSourcePathDelegate setSourcePath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSymbolOptionsDelegate addSymbolOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveSymbolOptionsDelegate removeSymbolOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameByOffsetDelegate getNameByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetByNameDelegate getOffsetByName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNearNameByOffsetDelegate getNearNameByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLineByOffsetDelegate getLineByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetByLineDelegate getOffsetByLine;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleByIndexDelegate getModuleByIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleByModuleNameDelegate getModuleByModuleName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleByOffsetDelegate getModuleByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleNamesDelegate getModuleNames;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleParametersDelegate getModuleParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolModuleDelegate getSymbolModule;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTypeNameDelegate getTypeName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTypeIdDelegate getTypeId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTypeSizeDelegate getTypeSize;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFieldOffsetDelegate getFieldOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolTypeIdDelegate getSymbolTypeId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetTypeIdDelegate getOffsetTypeId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadTypedDataVirtualDelegate readTypedDataVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteTypedDataVirtualDelegate writeTypedDataVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputTypedDataVirtualDelegate outputTypedDataVirtual;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadTypedDataPhysicalDelegate readTypedDataPhysical;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteTypedDataPhysicalDelegate writeTypedDataPhysical;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputTypedDataPhysicalDelegate outputTypedDataPhysical;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetScopeDelegate getScope;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetScopeDelegate setScope;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ResetScopeDelegate resetScope;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetScopeSymbolGroupDelegate getScopeSymbolGroup;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateSymbolGroupDelegate createSymbolGroup;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartSymbolMatchDelegate startSymbolMatch;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNextSymbolMatchDelegate getNextSymbolMatch;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EndSymbolMatchDelegate endSymbolMatch;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReloadDelegate reload;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendSymbolPathDelegate appendSymbolPath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendImagePathDelegate appendImagePath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourcePathElementDelegate getSourcePathElement;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendSourcePathDelegate appendSourcePath;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FindSourceFileDelegate findSourceFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceFileLineOffsetsDelegate getSourceFileLineOffsets;

        #endregion
        #region IDebugSymbols2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTypeOptionsDelegate getTypeOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetTypeOptionsDelegate setTypeOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleVersionInformationDelegate getModuleVersionInformation;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleNameStringDelegate getModuleNameString;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetConstantNameDelegate getConstantName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFieldNameDelegate getFieldName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddTypeOptionsDelegate addTypeOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveTypeOptionsDelegate removeTypeOptions;

        #endregion
        #region IDebugSymbols3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolPathWideDelegate getSymbolPathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSymbolPathWideDelegate setSymbolPathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetImagePathWideDelegate getImagePathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetImagePathWideDelegate setImagePathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourcePathWideDelegate getSourcePathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetSourcePathWideDelegate setSourcePathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentScopeFrameIndexDelegate getCurrentScopeFrameIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameByOffsetWideDelegate getNameByOffsetWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetByNameWideDelegate getOffsetByNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNearNameByOffsetWideDelegate getNearNameByOffsetWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLineByOffsetWideDelegate getLineByOffsetWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetByLineWideDelegate getOffsetByLineWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleByModuleNameWideDelegate getModuleByModuleNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolModuleWideDelegate getSymbolModuleWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTypeNameWideDelegate getTypeNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTypeIdWideDelegate getTypeIdWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFieldOffsetWideDelegate getFieldOffsetWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolTypeIdWideDelegate getSymbolTypeIdWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetScopeSymbolGroup2Delegate getScopeSymbolGroup2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateSymbolGroup2Delegate createSymbolGroup2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartSymbolMatchWideDelegate startSymbolMatchWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNextSymbolMatchWideDelegate getNextSymbolMatchWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReloadWideDelegate reloadWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendSymbolPathWideDelegate appendSymbolPathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendImagePathWideDelegate appendImagePathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourcePathElementWideDelegate getSourcePathElementWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AppendSourcePathWideDelegate appendSourcePathWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FindSourceFileWideDelegate findSourceFileWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceFileLineOffsetsWideDelegate getSourceFileLineOffsetsWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleVersionInformationWideDelegate getModuleVersionInformationWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleNameStringWideDelegate getModuleNameStringWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetConstantNameWideDelegate getConstantNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFieldNameWideDelegate getFieldNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IsManagedModuleDelegate isManagedModule;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleByModuleName2Delegate getModuleByModuleName2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleByModuleName2WideDelegate getModuleByModuleName2Wide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetModuleByOffset2Delegate getModuleByOffset2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSyntheticModuleDelegate addSyntheticModule;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSyntheticModuleWideDelegate addSyntheticModuleWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveSyntheticModuleDelegate removeSyntheticModule;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetScopeFrameByIndexDelegate setScopeFrameByIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetScopeFromJitDebugInfoDelegate setScopeFromJitDebugInfo;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetScopeFromStoredEventDelegate setScopeFromStoredEvent;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputSymbolByOffsetDelegate outputSymbolByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFunctionEntryByOffsetDelegate getFunctionEntryByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFieldTypeAndOffsetDelegate getFieldTypeAndOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFieldTypeAndOffsetWideDelegate getFieldTypeAndOffsetWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSyntheticSymbolDelegate addSyntheticSymbol;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSyntheticSymbolWideDelegate addSyntheticSymbolWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveSyntheticSymbolDelegate removeSyntheticSymbol;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntriesByOffsetDelegate getSymbolEntriesByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntriesByNameDelegate getSymbolEntriesByName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntriesByNameWideDelegate getSymbolEntriesByNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntryByTokenDelegate getSymbolEntryByToken;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntryInformationDelegate getSymbolEntryInformation;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntryStringDelegate getSymbolEntryString;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntryStringWideDelegate getSymbolEntryStringWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntryOffsetRegionsDelegate getSymbolEntryOffsetRegions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntryBySymbolEntryDelegate getSymbolEntryBySymbolEntry;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceEntriesByOffsetDelegate getSourceEntriesByOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceEntriesByLineDelegate getSourceEntriesByLine;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceEntriesByLineWideDelegate getSourceEntriesByLineWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceEntryStringDelegate getSourceEntryString;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceEntryStringWideDelegate getSourceEntryStringWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceEntryOffsetRegionsDelegate getSourceEntryOffsetRegions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceEntryBySourceEntryDelegate getSourceEntryBySourceEntry;

        #endregion
        #region IDebugSymbols4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetScopeExDelegate getScopeEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetScopeExDelegate setScopeEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameByInlineContextDelegate getNameByInlineContext;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNameByInlineContextWideDelegate getNameByInlineContextWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLineByInlineContextDelegate getLineByInlineContext;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLineByInlineContextWideDelegate getLineByInlineContextWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputSymbolByInlineContextDelegate outputSymbolByInlineContext;

        #endregion
        #region IDebugSymbols5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentScopeFrameIndexExDelegate getCurrentScopeFrameIndexEx;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetScopeFrameByIndexExDelegate setScopeFrameByIndexEx;

        #endregion
        #endregion
        #region Delegates
        #region IDebugSymbols

        private delegate HRESULT GetSymbolOptionsDelegate(IntPtr self, [Out] out SYMOPT Options);
        private delegate HRESULT SetSymbolOptionsDelegate(IntPtr self, [In] SYMOPT Options);
        private delegate HRESULT GetNumberModulesDelegate(IntPtr self, [Out] out uint Loaded, [Out] out uint Unloaded);
        private delegate HRESULT GetSymbolPathDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint PathSize);
        private delegate HRESULT SetSymbolPathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path);
        private delegate HRESULT GetImagePathDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint PathSize);
        private delegate HRESULT SetImagePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path);
        private delegate HRESULT GetSourcePathDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint PathSize);
        private delegate HRESULT SetSourcePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path);
        private delegate HRESULT AddSymbolOptionsDelegate(IntPtr self, [In] SYMOPT Options);
        private delegate HRESULT RemoveSymbolOptionsDelegate(IntPtr self, [In] SYMOPT Options);
        private delegate HRESULT GetNameByOffsetDelegate(IntPtr self, [In] ulong Offset, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong Displacement);
        private delegate HRESULT GetOffsetByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [Out] out ulong Offset);
        private delegate HRESULT GetNearNameByOffsetDelegate(IntPtr self, [In] ulong Offset, [In] int Delta, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong Displacement);
        private delegate HRESULT GetLineByOffsetDelegate(IntPtr self, [In] ulong Offset, [Out] out uint Line, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer, [In] int FileBufferSize, [Out] out uint FileSize, [Out] out ulong Displacement);
        private delegate HRESULT GetOffsetByLineDelegate(IntPtr self, [In] uint Line, [In, MarshalAs(UnmanagedType.LPStr)] string File, [Out] out ulong Offset);
        private delegate HRESULT GetModuleByIndexDelegate(IntPtr self, [In] uint Index, [Out] out ulong Base);
        private delegate HRESULT GetModuleByModuleNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [In] uint StartIndex, [Out] out uint Index, [Out] out ulong Base);
        private delegate HRESULT GetModuleByOffsetDelegate(IntPtr self, [In] ulong Offset, [In] uint StartIndex, [Out] out uint Index, [Out] out ulong Base);
        private delegate HRESULT GetModuleNamesDelegate(IntPtr self, [In] uint Index, [In] ulong Base, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ImageNameBuffer, [In] int ImageNameBufferSize, [Out] out uint ImageNameSize, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ModuleNameBuffer, [In] int ModuleNameBufferSize, [Out] out uint ModuleNameSize, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder LoadedImageNameBuffer, [In] int LoadedImageNameBufferSize, [Out] out uint LoadedImageNameSize);
        private delegate HRESULT GetModuleParametersDelegate(IntPtr self, [In] uint Count, [In, MarshalAs(UnmanagedType.LPArray)] ulong[] Bases, [In] uint Start, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_PARAMETERS[] Params);
        private delegate HRESULT GetSymbolModuleDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [Out] out ulong Base);
        private delegate HRESULT GetTypeNameDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetTypeIdDelegate(IntPtr self, [In] ulong Module, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [Out] out uint TypeId);
        private delegate HRESULT GetTypeSizeDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [Out] out uint Size);
        private delegate HRESULT GetFieldOffsetDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [In, MarshalAs(UnmanagedType.LPStr)] string Field, [Out] out uint Offset);
        private delegate HRESULT GetSymbolTypeIdDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [Out] out uint TypeId, [Out] out ulong Module);
        private delegate HRESULT GetOffsetTypeIdDelegate(IntPtr self, [In] ulong Offset, [Out] out uint TypeId, [Out] out ulong Module);
        private delegate HRESULT ReadTypedDataVirtualDelegate(IntPtr self, [In] ulong Offset, [In] ulong Module, [In] uint TypeId, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WriteTypedDataVirtualDelegate(IntPtr self, [In] ulong Offset, [In] ulong Module, [In] uint TypeId, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT OutputTypedDataVirtualDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] ulong Offset, [In] ulong Module, [In] uint TypeId, [In] DEBUG_TYPEOPTS Flags);
        private delegate HRESULT ReadTypedDataPhysicalDelegate(IntPtr self, [In] ulong Offset, [In] ulong Module, [In] uint TypeId, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesRead);
        private delegate HRESULT WriteTypedDataPhysicalDelegate(IntPtr self, [In] ulong Offset, [In] ulong Module, [In] uint TypeId, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BytesWritten);
        private delegate HRESULT OutputTypedDataPhysicalDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] ulong Offset, [In] ulong Module, [In] uint TypeId, [In] DEBUG_TYPEOPTS Flags);
        private delegate HRESULT GetScopeDelegate(IntPtr self, [Out] out ulong InstructionOffset, [Out] out DEBUG_STACK_FRAME ScopeFrame, [In] IntPtr ScopeContext, [In] uint ScopeContextSize);
        private delegate HRESULT SetScopeDelegate(IntPtr self, [In] ulong InstructionOffset, [In] DEBUG_STACK_FRAME ScopeFrame, [In] IntPtr ScopeContext, [In] uint ScopeContextSize);
        private delegate HRESULT ResetScopeDelegate(IntPtr self);
        private delegate HRESULT GetScopeSymbolGroupDelegate(IntPtr self, [In] DEBUG_SCOPE_GROUP Flags, [In, MarshalAs(UnmanagedType.Interface)] IDebugSymbolGroup Update, [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup Symbols);
        private delegate HRESULT CreateSymbolGroupDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup Group);
        private delegate HRESULT StartSymbolMatchDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Pattern, [Out] out ulong Handle);
        private delegate HRESULT GetNextSymbolMatchDelegate(IntPtr self, [In] ulong Handle, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint MatchSize, [Out] out ulong Offset);
        private delegate HRESULT EndSymbolMatchDelegate(IntPtr self, [In] ulong Handle);
        private delegate HRESULT ReloadDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Module);
        private delegate HRESULT AppendSymbolPathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Addition);
        private delegate HRESULT AppendImagePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Addition);
        private delegate HRESULT GetSourcePathElementDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint ElementSize);
        private delegate HRESULT AppendSourcePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Addition);
        private delegate HRESULT FindSourceFileDelegate(IntPtr self, [In] uint StartElement, [In, MarshalAs(UnmanagedType.LPStr)] string File, [In] DEBUG_FIND_SOURCE Flags, [Out] out uint FoundElement, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint FoundSize);
        private delegate HRESULT GetSourceFileLineOffsetsDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string File, [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Buffer, [In] int BufferLines, [Out] out uint FileLines);

        #endregion
        #region IDebugSymbols2

        private delegate HRESULT GetTypeOptionsDelegate(IntPtr self, [Out] out DEBUG_TYPEOPTS Options);
        private delegate HRESULT SetTypeOptionsDelegate(IntPtr self, [In] DEBUG_TYPEOPTS Options);
        private delegate HRESULT GetModuleVersionInformationDelegate(IntPtr self, [In] uint Index, [In] ulong Base, [In, MarshalAs(UnmanagedType.LPStr)] string Item, [Out] IntPtr Buffer, [In] uint BufferSize, [Out] out uint VerInfoSize);
        private delegate HRESULT GetModuleNameStringDelegate(IntPtr self, [In] DEBUG_MODNAME Which, [In] uint Index, [In] ulong Base, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] uint BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetConstantNameDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [In] ulong Value, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetFieldNameDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [In] uint FieldIndex, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT AddTypeOptionsDelegate(IntPtr self, [In] DEBUG_TYPEOPTS Options);
        private delegate HRESULT RemoveTypeOptionsDelegate(IntPtr self, [In] DEBUG_TYPEOPTS Options);

        #endregion
        #region IDebugSymbols3

        private delegate HRESULT GetSymbolPathWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint PathSize);
        private delegate HRESULT SetSymbolPathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path);
        private delegate HRESULT GetImagePathWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint PathSize);
        private delegate HRESULT SetImagePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path);
        private delegate HRESULT GetSourcePathWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint PathSize);
        private delegate HRESULT SetSourcePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path);
        private delegate HRESULT GetCurrentScopeFrameIndexDelegate(IntPtr self, [Out] out uint Index);
        private delegate HRESULT GetNameByOffsetWideDelegate(IntPtr self, [In] ulong Offset, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong Displacement);
        private delegate HRESULT GetOffsetByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [Out] out ulong Offset);
        private delegate HRESULT GetNearNameByOffsetWideDelegate(IntPtr self, [In] ulong Offset, [In] int Delta, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong Displacement);
        private delegate HRESULT GetLineByOffsetWideDelegate(IntPtr self, [In] ulong Offset, [Out] out uint Line, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FileBuffer, [In] int FileBufferSize, [Out] out uint FileSize, [Out] out ulong Displacement);
        private delegate HRESULT GetOffsetByLineWideDelegate(IntPtr self, [In] uint Line, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [Out] out ulong Offset);
        private delegate HRESULT GetModuleByModuleNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [In] uint StartIndex, [Out] out uint Index, [Out] out ulong Base);
        private delegate HRESULT GetSymbolModuleWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [Out] out ulong Base);
        private delegate HRESULT GetTypeNameWideDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetTypeIdWideDelegate(IntPtr self, [In] ulong Module, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [Out] out uint TypeId);
        private delegate HRESULT GetFieldOffsetWideDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [In, MarshalAs(UnmanagedType.LPWStr)] string Field, [Out] out uint Offset);
        private delegate HRESULT GetSymbolTypeIdWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [Out] out uint TypeId, [Out] out ulong Module);
        private delegate HRESULT GetScopeSymbolGroup2Delegate(IntPtr self, [In] DEBUG_SCOPE_GROUP Flags, [In, MarshalAs(UnmanagedType.Interface)] IDebugSymbolGroup2 Update, [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup2 Symbols);
        private delegate HRESULT CreateSymbolGroup2Delegate(IntPtr self, [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup2 Group);
        private delegate HRESULT StartSymbolMatchWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Pattern, [Out] out ulong Handle);
        private delegate HRESULT GetNextSymbolMatchWideDelegate(IntPtr self, [In] ulong Handle, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint MatchSize, [Out] out ulong Offset);
        private delegate HRESULT ReloadWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Module);
        private delegate HRESULT AppendSymbolPathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);
        private delegate HRESULT AppendImagePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);
        private delegate HRESULT GetSourcePathElementWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint ElementSize);
        private delegate HRESULT AppendSourcePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);
        private delegate HRESULT FindSourceFileWideDelegate(IntPtr self, [In] uint StartElement, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [In] DEBUG_FIND_SOURCE Flags, [Out] out uint FoundElement, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint FoundSize);
        private delegate HRESULT GetSourceFileLineOffsetsWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Buffer, [In] int BufferLines, [Out] out uint FileLines);
        private delegate HRESULT GetModuleVersionInformationWideDelegate(IntPtr self, [In] uint Index, [In] ulong Base, [In, MarshalAs(UnmanagedType.LPWStr)] string Item, [In] IntPtr Buffer, [In] int BufferSize, [Out] out uint VerInfoSize);
        private delegate HRESULT GetModuleNameStringWideDelegate(IntPtr self, [In] DEBUG_MODNAME Which, [In] uint Index, [In] ulong Base, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetConstantNameWideDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [In] ulong Value, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetFieldNameWideDelegate(IntPtr self, [In] ulong Module, [In] uint TypeId, [In] uint FieldIndex, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT IsManagedModuleDelegate(IntPtr self, [In] uint Index, [In] ulong Base);
        private delegate HRESULT GetModuleByModuleName2Delegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [In] uint StartIndex, [In] DEBUG_GETMOD Flags, [Out] out uint Index, [Out] out ulong Base);
        private delegate HRESULT GetModuleByModuleName2WideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [In] uint StartIndex, [In] DEBUG_GETMOD Flags, [Out] out uint Index, [Out] out ulong Base);
        private delegate HRESULT GetModuleByOffset2Delegate(IntPtr self, [In] ulong Offset, [In] uint StartIndex, [In] DEBUG_GETMOD Flags, [Out] out uint Index, [Out] out ulong Base);
        private delegate HRESULT AddSyntheticModuleDelegate(IntPtr self, [In] ulong Base, [In] uint Size, [In, MarshalAs(UnmanagedType.LPStr)] string ImagePath, [In, MarshalAs(UnmanagedType.LPStr)] string ModuleName, [In] DEBUG_ADDSYNTHMOD Flags);
        private delegate HRESULT AddSyntheticModuleWideDelegate(IntPtr self, [In] ulong Base, [In] uint Size, [In, MarshalAs(UnmanagedType.LPWStr)] string ImagePath, [In, MarshalAs(UnmanagedType.LPWStr)] string ModuleName, [In] DEBUG_ADDSYNTHMOD Flags);
        private delegate HRESULT RemoveSyntheticModuleDelegate(IntPtr self, [In] ulong Base);
        private delegate HRESULT SetScopeFrameByIndexDelegate(IntPtr self, [In] uint Index);
        private delegate HRESULT SetScopeFromJitDebugInfoDelegate(IntPtr self, [In] uint OutputControl, [In] ulong InfoOffset);
        private delegate HRESULT SetScopeFromStoredEventDelegate(IntPtr self);
        private delegate HRESULT OutputSymbolByOffsetDelegate(IntPtr self, [In] uint OutputControl, [In] DEBUG_OUTSYM Flags, [In] ulong Offset);
        private delegate HRESULT GetFunctionEntryByOffsetDelegate(IntPtr self, [In] ulong Offset, [In] DEBUG_GETFNENT Flags, [In] IntPtr Buffer, [In] uint BufferSize, [Out] out uint BufferNeeded);
        private delegate HRESULT GetFieldTypeAndOffsetDelegate(IntPtr self, [In] ulong Module, [In] uint ContainerTypeId, [In, MarshalAs(UnmanagedType.LPStr)] string Field, [Out] out uint FieldTypeId, [Out] out uint Offset);
        private delegate HRESULT GetFieldTypeAndOffsetWideDelegate(IntPtr self, [In] ulong Module, [In] uint ContainerTypeId, [In, MarshalAs(UnmanagedType.LPWStr)] string Field, [Out] out uint FieldTypeId, [Out] out uint Offset);
        private delegate HRESULT AddSyntheticSymbolDelegate(IntPtr self, [In] ulong Offset, [In] uint Size, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [In] DEBUG_ADDSYNTHSYM Flags, [Out] out DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT AddSyntheticSymbolWideDelegate(IntPtr self, [In] ulong Offset, [In] uint Size, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [In] DEBUG_ADDSYNTHSYM Flags, [Out] out DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT RemoveSyntheticSymbolDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT GetSymbolEntriesByOffsetDelegate(IntPtr self, [In] ulong Offset, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids, [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Displacements, [In] uint IdsCount, [Out] out uint Entries);
        private delegate HRESULT GetSymbolEntriesByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids, [In] uint IdsCount, [Out] out uint Entries);
        private delegate HRESULT GetSymbolEntriesByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids, [In] uint IdsCount, [Out] out uint Entries);
        private delegate HRESULT GetSymbolEntryByTokenDelegate(IntPtr self, [In] ulong ModuleBase, [In] uint Token, [Out] out DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT GetSymbolEntryInformationDelegate(IntPtr self, [In] ref DEBUG_MODULE_AND_ID Id, [Out] out DEBUG_SYMBOL_ENTRY Info);
        private delegate HRESULT GetSymbolEntryStringDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id, [In] uint Which, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint StringSize);
        private delegate HRESULT GetSymbolEntryStringWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id, [In] uint Which, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint StringSize);
        private delegate HRESULT GetSymbolEntryOffsetRegionsDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_OFFSET_REGION[] Regions, [In] uint RegionsCount, [Out] out uint RegionsAvail);
        private delegate HRESULT GetSymbolEntryBySymbolEntryDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID FromId, [In] uint Flags, [Out] out DEBUG_MODULE_AND_ID ToId);
        private delegate HRESULT GetSourceEntriesByOffsetDelegate(IntPtr self, [In] ulong Offset, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries, [In] uint EntriesCount, [Out] out uint EntriesAvail);
        private delegate HRESULT GetSourceEntriesByLineDelegate(IntPtr self, [In] uint Line, [In, MarshalAs(UnmanagedType.LPStr)] string File, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries, [In] uint EntriesCount, [Out] out uint EntriesAvail);
        private delegate HRESULT GetSourceEntriesByLineWideDelegate(IntPtr self, [In] uint Line, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries, [In] uint EntriesCount, [Out] out uint EntriesAvail);
        private delegate HRESULT GetSourceEntryStringDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry, [In] uint Which, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint StringSize);
        private delegate HRESULT GetSourceEntryStringWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry, [In] uint Which, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint StringSize);
        private delegate HRESULT GetSourceEntryOffsetRegionsDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry, [In] uint Flags, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_OFFSET_REGION[] Regions, [In] uint RegionsCount, [Out] out uint RegionsAvail);
        private delegate HRESULT GetSourceEntryBySourceEntryDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY FromEntry, [In] uint Flags, [Out] out DEBUG_SYMBOL_SOURCE_ENTRY ToEntry);

        #endregion
        #region IDebugSymbols4

        private delegate HRESULT GetScopeExDelegate(IntPtr self, [Out] out ulong InstructionOffset, [Out] out DEBUG_STACK_FRAME_EX ScopeFrame, [In] IntPtr ScopeContext, [In] uint ScopeContextSize);
        private delegate HRESULT SetScopeExDelegate(IntPtr self, [In] ulong InstructionOffset, [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_STACK_FRAME_EX ScopeFrame, [In] IntPtr ScopeContext, [In] uint ScopeContextSize);
        private delegate HRESULT GetNameByInlineContextDelegate(IntPtr self, [In] ulong Offset, [In] uint InlineContext, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong Displacement);
        private delegate HRESULT GetNameByInlineContextWideDelegate(IntPtr self, [In] ulong Offset, [In] uint InlineContext, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer, [In] int NameBufferSize, [Out] out uint NameSize, [Out] out ulong Displacement);
        private delegate HRESULT GetLineByInlineContextDelegate(IntPtr self, [In] ulong Offset, [In] uint InlineContext, [Out] out uint Line, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer, [In] int FileBufferSize, [Out] out uint FileSize, [Out] out ulong Displacement);
        private delegate HRESULT GetLineByInlineContextWideDelegate(IntPtr self, [In] ulong Offset, [In] uint InlineContext, [Out] out uint Line, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FileBuffer, [In] int FileBufferSize, [Out] out uint FileSize, [Out] out ulong Displacement);
        private delegate HRESULT OutputSymbolByInlineContextDelegate(IntPtr self, [In] uint OutputControl, [In] uint Flags, [In] ulong Offset, [In] uint InlineContext);

        #endregion
        #region IDebugSymbols5

        private delegate HRESULT GetCurrentScopeFrameIndexExDelegate(IntPtr self, [In] DEBUG_FRAME Flags, [Out] out uint Index);
        private delegate HRESULT SetScopeFrameByIndexExDelegate(IntPtr self, [In] DEBUG_FRAME Flags, [In] uint Index);

        #endregion
        #endregion
    }
}

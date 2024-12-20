﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;
using static ClrDebug.Extensions;

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
                TryGetSymbolOptions(out options).ThrowDbgEngNotOK();

                return options;
            }
            set
            {
                TrySetSymbolOptions(value).ThrowDbgEngNotOK();
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
                TryGetNumberModules(out result).ThrowDbgEngNotOK();

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
            [Out] out int Loaded,
            [Out] out int Unloaded);*/
            int loaded;
            int unloaded;
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
                TryGetSymbolPath(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetSymbolPath(value).ThrowDbgEngNotOK();
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
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);*/
            char[] buffer;
            int bufferSize = 0;
            int pathSize;
            HRESULT hr = getSymbolPath(Raw, null, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = pathSize;
            buffer = new char[bufferSize];
            hr = getSymbolPath(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, pathSize);

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
                TryGetImagePath(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetImagePath(value).ThrowDbgEngNotOK();
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
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);*/
            char[] buffer;
            int bufferSize = 0;
            int pathSize;
            HRESULT hr = getImagePath(Raw, null, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = pathSize;
            buffer = new char[bufferSize];
            hr = getImagePath(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, pathSize);

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
                TryGetSourcePath(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetSourcePath(value).ThrowDbgEngNotOK();
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
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);*/
            char[] buffer;
            int bufferSize = 0;
            int pathSize;
            HRESULT hr = getSourcePath(Raw, null, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = pathSize;
            buffer = new char[bufferSize];
            hr = getSourcePath(Raw, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, pathSize);

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
            TryAddSymbolOptions(options).ThrowDbgEngNotOK();
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
            TryRemoveSymbolOptions(options).ThrowDbgEngNotOK();
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
        public GetNameByOffsetResult GetNameByOffset(long offset)
        {
            GetNameByOffsetResult result;
            TryGetNameByOffset(offset, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetNameByOffset(long offset, out GetNameByOffsetResult result)
        {
            InitDelegate(ref getNameByOffset, Vtbl->GetNameByOffset);
            /*HRESULT GetNameByOffset(
            [In] long Offset,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long displacement;
            HRESULT hr = getNameByOffset(Raw, offset, null, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getNameByOffset(Raw, offset, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByOffsetResult(CreateString(nameBuffer, nameSize), displacement);

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
        public long GetOffsetByName(string symbol)
        {
            long offset;
            TryGetOffsetByName(symbol, out offset).ThrowDbgEngNotOK();

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
        public HRESULT TryGetOffsetByName(string symbol, out long offset)
        {
            InitDelegate(ref getOffsetByName, Vtbl->GetOffsetByName);

            /*HRESULT GetOffsetByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out long Offset);*/
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
        public GetNearNameByOffsetResult GetNearNameByOffset(long offset, int delta)
        {
            GetNearNameByOffsetResult result;
            TryGetNearNameByOffset(offset, delta, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetNearNameByOffset(long offset, int delta, out GetNearNameByOffsetResult result)
        {
            InitDelegate(ref getNearNameByOffset, Vtbl->GetNearNameByOffset);
            /*HRESULT GetNearNameByOffset(
            [In] long Offset,
            [In] int Delta,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long displacement;
            HRESULT hr = getNearNameByOffset(Raw, offset, delta, null, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getNearNameByOffset(Raw, offset, delta, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNearNameByOffsetResult(CreateString(nameBuffer, nameSize), displacement);

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
        public GetLineByOffsetResult GetLineByOffset(long offset)
        {
            GetLineByOffsetResult result;
            TryGetLineByOffset(offset, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetLineByOffset(long offset, out GetLineByOffsetResult result)
        {
            InitDelegate(ref getLineByOffset, Vtbl->GetLineByOffset);
            /*HRESULT GetLineByOffset(
            [In] long Offset,
            [Out] out int Line,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] FileBuffer,
            [In] int FileBufferSize,
            [Out] out int FileSize,
            [Out] out long Displacement);*/
            int line;
            char[] fileBuffer;
            int fileBufferSize = 0;
            int fileSize;
            long displacement;
            HRESULT hr = getLineByOffset(Raw, offset, out line, null, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileBufferSize = fileSize;
            fileBuffer = new char[fileBufferSize];
            hr = getLineByOffset(Raw, offset, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByOffsetResult(line, CreateString(fileBuffer, fileSize), displacement);

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
        public long GetOffsetByLine(int line, string file)
        {
            long offset;
            TryGetOffsetByLine(line, file, out offset).ThrowDbgEngNotOK();

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
        public HRESULT TryGetOffsetByLine(int line, string file, out long offset)
        {
            InitDelegate(ref getOffsetByLine, Vtbl->GetOffsetByLine);

            /*HRESULT GetOffsetByLine(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out long Offset);*/
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
        public long GetModuleByIndex(int index)
        {
            long @base;
            TryGetModuleByIndex(index, out @base).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleByIndex(int index, out long @base)
        {
            InitDelegate(ref getModuleByIndex, Vtbl->GetModuleByIndex);

            /*HRESULT GetModuleByIndex(
            [In] int Index,
            [Out] out long Base);*/
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
        public GetModuleByModuleNameResult GetModuleByModuleName(string name, int startIndex)
        {
            GetModuleByModuleNameResult result;
            TryGetModuleByModuleName(name, startIndex, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleByModuleName(string name, int startIndex, out GetModuleByModuleNameResult result)
        {
            InitDelegate(ref getModuleByModuleName, Vtbl->GetModuleByModuleName);
            /*HRESULT GetModuleByModuleName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] int StartIndex,
            [Out] out int Index,
            [Out] out long Base);*/
            int index;
            long @base;
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
        public GetModuleByOffsetResult GetModuleByOffset(long offset, int startIndex)
        {
            GetModuleByOffsetResult result;
            TryGetModuleByOffset(offset, startIndex, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleByOffset(long offset, int startIndex, out GetModuleByOffsetResult result)
        {
            InitDelegate(ref getModuleByOffset, Vtbl->GetModuleByOffset);
            /*HRESULT GetModuleByOffset(
            [In] long Offset,
            [In] int StartIndex,
            [Out] out int Index,
            [Out] out long Base);*/
            int index;
            long @base;
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
        public GetModuleNamesResult GetModuleNames(int index, long @base)
        {
            GetModuleNamesResult result;
            TryGetModuleNames(index, @base, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleNames(int index, long @base, out GetModuleNamesResult result)
        {
            InitDelegate(ref getModuleNames, Vtbl->GetModuleNames);
            /*HRESULT GetModuleNames(
            [In] int Index,
            [In] long Base,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] ImageNameBuffer,
            [In] int ImageNameBufferSize,
            [Out] out int ImageNameSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 6)] char[] ModuleNameBuffer,
            [In] int ModuleNameBufferSize,
            [Out] out int ModuleNameSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 9)] char[] LoadedImageNameBuffer,
            [In] int LoadedImageNameBufferSize,
            [Out] out int LoadedImageNameSize);*/
            char[] imageNameBuffer;
            int imageNameBufferSize = 0;
            int imageNameSize;
            char[] moduleNameBuffer;
            int moduleNameBufferSize = 0;
            int moduleNameSize;
            char[] loadedImageNameBuffer;
            int loadedImageNameBufferSize = 0;
            int loadedImageNameSize;
            HRESULT hr = getModuleNames(Raw, index, @base, null, imageNameBufferSize, out imageNameSize, null, moduleNameBufferSize, out moduleNameSize, null, loadedImageNameBufferSize, out loadedImageNameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            imageNameBufferSize = imageNameSize;
            imageNameBuffer = new char[imageNameBufferSize];
            moduleNameBufferSize = moduleNameSize;
            moduleNameBuffer = new char[moduleNameBufferSize];
            loadedImageNameBufferSize = loadedImageNameSize;
            loadedImageNameBuffer = new char[loadedImageNameBufferSize];
            hr = getModuleNames(Raw, index, @base, imageNameBuffer, imageNameBufferSize, out imageNameSize, moduleNameBuffer, moduleNameBufferSize, out moduleNameSize, loadedImageNameBuffer, loadedImageNameBufferSize, out loadedImageNameSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetModuleNamesResult(CreateString(imageNameBuffer, imageNameSize), CreateString(moduleNameBuffer, moduleNameSize), CreateString(loadedImageNameBuffer, loadedImageNameSize));

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
        public DEBUG_MODULE_PARAMETERS[] GetModuleParameters(int count, long[] bases, int start)
        {
            DEBUG_MODULE_PARAMETERS[] @params;
            TryGetModuleParameters(count, bases, start, out @params).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleParameters(int count, long[] bases, int start, out DEBUG_MODULE_PARAMETERS[] @params)
        {
            InitDelegate(ref getModuleParameters, Vtbl->GetModuleParameters);
            /*HRESULT GetModuleParameters(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] long[] Bases,
            [In] int Start,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_MODULE_PARAMETERS[] Params);*/
            @params = new DEBUG_MODULE_PARAMETERS[count];
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
        public long GetSymbolModule(string symbol)
        {
            long @base;
            TryGetSymbolModule(symbol, out @base).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSymbolModule(string symbol, out long @base)
        {
            InitDelegate(ref getSymbolModule, Vtbl->GetSymbolModule);

            /*HRESULT GetSymbolModule(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out long Base);*/
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
        public string GetTypeName(long module, int typeId)
        {
            string nameBufferResult;
            TryGetTypeName(module, typeId, out nameBufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetTypeName(long module, int typeId, out string nameBufferResult)
        {
            InitDelegate(ref getTypeName, Vtbl->GetTypeName);
            /*HRESULT GetTypeName(
            [In] long Module,
            [In] int TypeId,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            HRESULT hr = getTypeName(Raw, module, typeId, null, nameBufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getTypeName(Raw, module, typeId, nameBuffer, nameBufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                nameBufferResult = CreateString(nameBuffer, nameSize);

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
        public int GetTypeId(long module, string name)
        {
            int typeId;
            TryGetTypeId(module, name, out typeId).ThrowDbgEngNotOK();

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
        public HRESULT TryGetTypeId(long module, string name, out int typeId)
        {
            InitDelegate(ref getTypeId, Vtbl->GetTypeId);

            /*HRESULT GetTypeId(
            [In] long Module,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out int TypeId);*/
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
        public int GetTypeSize(long module, int typeId)
        {
            int size;
            TryGetTypeSize(module, typeId, out size).ThrowDbgEngNotOK();

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
        public HRESULT TryGetTypeSize(long module, int typeId, out int size)
        {
            InitDelegate(ref getTypeSize, Vtbl->GetTypeSize);

            /*HRESULT GetTypeSize(
            [In] long Module,
            [In] int TypeId,
            [Out] out int Size);*/
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
        public int GetFieldOffset(long module, int typeId, string field)
        {
            int offset;
            TryGetFieldOffset(module, typeId, field, out offset).ThrowDbgEngNotOK();

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
        public HRESULT TryGetFieldOffset(long module, int typeId, string field, out int offset)
        {
            InitDelegate(ref getFieldOffset, Vtbl->GetFieldOffset);

            /*HRESULT GetFieldOffset(
            [In] long Module,
            [In] int TypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out int Offset);*/
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
            TryGetSymbolTypeId(symbol, out result).ThrowDbgEngNotOK();

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
            [Out] out int TypeId,
            [Out] out long Module);*/
            int typeId;
            long module;
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
        public GetOffsetTypeIdResult GetOffsetTypeId(long offset)
        {
            GetOffsetTypeIdResult result;
            TryGetOffsetTypeId(offset, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetOffsetTypeId(long offset, out GetOffsetTypeIdResult result)
        {
            InitDelegate(ref getOffsetTypeId, Vtbl->GetOffsetTypeId);
            /*HRESULT GetOffsetTypeId(
            [In] long Offset,
            [Out] out int TypeId,
            [Out] out long Module);*/
            int typeId;
            long module;
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
        public int ReadTypedDataVirtual(long offset, long module, int typeId, IntPtr buffer, int bufferSize)
        {
            int bytesRead;
            TryReadTypedDataVirtual(offset, module, typeId, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOK();

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
        public HRESULT TryReadTypedDataVirtual(long offset, long module, int typeId, IntPtr buffer, int bufferSize, out int bytesRead)
        {
            InitDelegate(ref readTypedDataVirtual, Vtbl->ReadTypedDataVirtual);

            /*HRESULT ReadTypedDataVirtual(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);*/
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
        public int WriteTypedDataVirtual(long offset, long module, int typeId, IntPtr buffer, int bufferSize)
        {
            int bytesWritten;
            TryWriteTypedDataVirtual(offset, module, typeId, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOK();

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
        public HRESULT TryWriteTypedDataVirtual(long offset, long module, int typeId, IntPtr buffer, int bufferSize, out int bytesWritten)
        {
            InitDelegate(ref writeTypedDataVirtual, Vtbl->WriteTypedDataVirtual);

            /*HRESULT WriteTypedDataVirtual(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);*/
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
        /// <param name="flags">[in] Specifies the formatting flags.</param>
        /// <remarks>
        /// The output produced by this method is the same as for the debugger command DT. See dt (Display Type). For more
        /// information about types, see Types. For more information about output, see Input and Output.
        /// </remarks>
        public void OutputTypedDataVirtual(DEBUG_OUTCTL outputControl, long offset, long module, int typeId, DEBUG_OUTTYPE flags)
        {
            TryOutputTypedDataVirtual(outputControl, offset, module, typeId, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputTypedDataVirtual method formats the contents of a variable in the target's virtual memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="offset">[in] Specifies the location in the target's virtual address space of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type.</param>
        /// <param name="flags">[in] Specifies the formatting flags.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The output produced by this method is the same as for the debugger command DT. See dt (Display Type). For more
        /// information about types, see Types. For more information about output, see Input and Output.
        /// </remarks>
        public HRESULT TryOutputTypedDataVirtual(DEBUG_OUTCTL outputControl, long offset, long module, int typeId, DEBUG_OUTTYPE flags)
        {
            InitDelegate(ref outputTypedDataVirtual, Vtbl->OutputTypedDataVirtual);

            /*HRESULT OutputTypedDataVirtual(
            [In] DEBUG_OUTCTL OutputControl,
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] DEBUG_OUTTYPE Flags);*/
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
        public int ReadTypedDataPhysical(long offset, long module, int typeId, IntPtr buffer, int bufferSize)
        {
            int bytesRead;
            TryReadTypedDataPhysical(offset, module, typeId, buffer, bufferSize, out bytesRead).ThrowDbgEngNotOK();

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
        public HRESULT TryReadTypedDataPhysical(long offset, long module, int typeId, IntPtr buffer, int bufferSize, out int bytesRead)
        {
            InitDelegate(ref readTypedDataPhysical, Vtbl->ReadTypedDataPhysical);

            /*HRESULT ReadTypedDataPhysical(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);*/
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
        public int WriteTypedDataPhysical(long offset, long module, int typeId, IntPtr buffer, int bufferSize)
        {
            int bytesWritten;
            TryWriteTypedDataPhysical(offset, module, typeId, buffer, bufferSize, out bytesWritten).ThrowDbgEngNotOK();

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
        public HRESULT TryWriteTypedDataPhysical(long offset, long module, int typeId, IntPtr buffer, int bufferSize, out int bytesWritten)
        {
            InitDelegate(ref writeTypedDataPhysical, Vtbl->WriteTypedDataPhysical);

            /*HRESULT WriteTypedDataPhysical(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);*/
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
        /// <param name="flags">[in] Specifies the bit-set containing the formatting options.</param>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The output produced by this method is the same as for the
        /// debugger command DT. See dt (Display Type). For more information about types, see Types. For information about
        /// output, see Input and Output.
        /// </remarks>
        public void OutputTypedDataPhysical(DEBUG_OUTCTL outputControl, long offset, long module, int typeId, DEBUG_OUTTYPE flags)
        {
            TryOutputTypedDataPhysical(outputControl, offset, module, typeId, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputTypedDataPhysical method formats the contents of a variable in the target computer's physical memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="typeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="flags">[in] Specifies the bit-set containing the formatting options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The output produced by this method is the same as for the
        /// debugger command DT. See dt (Display Type). For more information about types, see Types. For information about
        /// output, see Input and Output.
        /// </remarks>
        public HRESULT TryOutputTypedDataPhysical(DEBUG_OUTCTL outputControl, long offset, long module, int typeId, DEBUG_OUTTYPE flags)
        {
            InitDelegate(ref outputTypedDataPhysical, Vtbl->OutputTypedDataPhysical);

            /*HRESULT OutputTypedDataPhysical(
            [In] DEBUG_OUTCTL OutputControl,
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] DEBUG_OUTTYPE Flags);*/
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
        public GetScopeResult GetScope(IntPtr scopeContext, int scopeContextSize)
        {
            GetScopeResult result;
            TryGetScope(scopeContext, scopeContextSize, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetScope(IntPtr scopeContext, int scopeContextSize, out GetScopeResult result)
        {
            InitDelegate(ref getScope, Vtbl->GetScope);
            /*HRESULT GetScope(
            [Out] out long InstructionOffset,
            [Out] out DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] int ScopeContextSize);*/
            long instructionOffset;
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
        public void SetScope(long instructionOffset, DEBUG_STACK_FRAME scopeFrame, IntPtr scopeContext, int scopeContextSize)
        {
            TrySetScope(instructionOffset, scopeFrame, scopeContext, scopeContextSize).ThrowDbgEngNotOK();
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
        public HRESULT TrySetScope(long instructionOffset, DEBUG_STACK_FRAME scopeFrame, IntPtr scopeContext, int scopeContextSize)
        {
            InitDelegate(ref setScope, Vtbl->SetScope);

            /*HRESULT SetScope(
            [In] long InstructionOffset,
            [In] ref DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] int ScopeContextSize);*/
            return setScope(Raw, instructionOffset, ref scopeFrame, scopeContext, scopeContextSize);
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
            TryResetScope().ThrowDbgEngNotOK();
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
        public DebugSymbolGroup GetScopeSymbolGroup(DEBUG_SCOPE_GROUP flags, IntPtr update)
        {
            DebugSymbolGroup symbolsResult;
            TryGetScopeSymbolGroup(flags, update, out symbolsResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetScopeSymbolGroup(DEBUG_SCOPE_GROUP flags, IntPtr update, out DebugSymbolGroup symbolsResult)
        {
            InitDelegate(ref getScopeSymbolGroup, Vtbl->GetScopeSymbolGroup);
            /*HRESULT GetScopeSymbolGroup(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, ComAliasName("IDebugSymbolGroup")] IntPtr Update,
            [Out, ComAliasName("IDebugSymbolGroup")] out IntPtr Symbols);*/
            IntPtr symbols;
            HRESULT hr = getScopeSymbolGroup(Raw, flags, update, out symbols);

            if (hr == HRESULT.S_OK)
                symbolsResult = symbols == IntPtr.Zero ? null : new DebugSymbolGroup(symbols);
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
            TryCreateSymbolGroup(out groupResult).ThrowDbgEngNotOK();

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
            [Out, ComAliasName("IDebugSymbolGroup")] out IntPtr Group);*/
            IntPtr group;
            HRESULT hr = createSymbolGroup(Raw, out group);

            if (hr == HRESULT.S_OK)
                groupResult = group == IntPtr.Zero ? null : new DebugSymbolGroup(group);
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
        public long StartSymbolMatch(string pattern)
        {
            long handle;
            TryStartSymbolMatch(pattern, out handle).ThrowDbgEngNotOK();

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
        public HRESULT TryStartSymbolMatch(string pattern, out long handle)
        {
            InitDelegate(ref startSymbolMatch, Vtbl->StartSymbolMatch);

            /*HRESULT StartSymbolMatch(
            [In, MarshalAs(UnmanagedType.LPStr)] string Pattern,
            [Out] out long Handle);*/
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
        public GetNextSymbolMatchResult GetNextSymbolMatch(long handle)
        {
            GetNextSymbolMatchResult result;
            TryGetNextSymbolMatch(handle, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetNextSymbolMatch(long handle, out GetNextSymbolMatchResult result)
        {
            InitDelegate(ref getNextSymbolMatch, Vtbl->GetNextSymbolMatch);
            /*HRESULT GetNextSymbolMatch(
            [In] long Handle,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int MatchSize,
            [Out] out long Offset);*/
            char[] buffer;
            int bufferSize = 0;
            int matchSize;
            long offset;
            HRESULT hr = getNextSymbolMatch(Raw, handle, null, bufferSize, out matchSize, out offset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = matchSize;
            buffer = new char[bufferSize];
            hr = getNextSymbolMatch(Raw, handle, buffer, bufferSize, out matchSize, out offset);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNextSymbolMatchResult(CreateString(buffer, matchSize), offset);

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
        public void EndSymbolMatch(long handle)
        {
            TryEndSymbolMatch(handle).ThrowDbgEngNotOK();
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
        public HRESULT TryEndSymbolMatch(long handle)
        {
            InitDelegate(ref endSymbolMatch, Vtbl->EndSymbolMatch);

            /*HRESULT EndSymbolMatch(
            [In] long Handle);*/
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
            TryReload(module).ThrowDbgEngNotOK();
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
            TryAppendSymbolPath(addition).ThrowDbgEngNotOK();
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
            TryAppendImagePath(addition).ThrowDbgEngNotOK();
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
        public string GetSourcePathElement(int index)
        {
            string bufferResult;
            TryGetSourcePathElement(index, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSourcePathElement(int index, out string bufferResult)
        {
            InitDelegate(ref getSourcePathElement, Vtbl->GetSourcePathElement);
            /*HRESULT GetSourcePathElement(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ElementSize);*/
            char[] buffer;
            int bufferSize = 0;
            int elementSize;
            HRESULT hr = getSourcePathElement(Raw, index, null, bufferSize, out elementSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = elementSize;
            buffer = new char[bufferSize];
            hr = getSourcePathElement(Raw, index, buffer, bufferSize, out elementSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, elementSize);

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
            TryAppendSourcePath(addition).ThrowDbgEngNotOK();
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
        public FindSourceFileResult FindSourceFile(int startElement, string file, DEBUG_FIND_SOURCE flags)
        {
            FindSourceFileResult result;
            TryFindSourceFile(startElement, file, flags, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryFindSourceFile(int startElement, string file, DEBUG_FIND_SOURCE flags, out FindSourceFileResult result)
        {
            InitDelegate(ref findSourceFile, Vtbl->FindSourceFile);
            /*HRESULT FindSourceFile(
            [In] int StartElement,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out int FoundElement,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);*/
            int foundElement;
            char[] buffer;
            int bufferSize = 0;
            int foundSize;
            HRESULT hr = findSourceFile(Raw, startElement, file, flags, out foundElement, null, bufferSize, out foundSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = foundSize;
            buffer = new char[bufferSize];
            hr = findSourceFile(Raw, startElement, file, flags, out foundElement, buffer, bufferSize, out foundSize);

            if (hr == HRESULT.S_OK)
            {
                result = new FindSourceFileResult(foundElement, CreateString(buffer, foundSize));

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
        public long[] GetSourceFileLineOffsets(string file)
        {
            long[] buffer;
            TryGetSourceFileLineOffsets(file, out buffer).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSourceFileLineOffsets(string file, out long[] buffer)
        {
            InitDelegate(ref getSourceFileLineOffsets, Vtbl->GetSourceFileLineOffsets);
            /*HRESULT GetSourceFileLineOffsets(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] Buffer,
            [In] int BufferLines,
            [Out] out int FileLines);*/
            buffer = null;
            int bufferLines = 0;
            int fileLines;
            HRESULT hr = getSourceFileLineOffsets(Raw, file, null, bufferLines, out fileLines);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferLines = fileLines;
            buffer = new long[bufferLines];
            hr = getSourceFileLineOffsets(Raw, file, buffer, bufferLines, out fileLines);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region IDebugSymbols2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr raw2;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IntPtr Raw2
        {
            get
            {
                InitInterface(typeof(IDebugSymbols2).GUID, ref raw2);

                return raw2;
            }
        }

        #region TypeOptions

        /// <summary>
        /// The GetTypeOptions method returns the type formatting options for output generated by the engine.
        /// </summary>
        public DEBUG_TYPEOPTS TypeOptions
        {
            get
            {
                DEBUG_TYPEOPTS options;
                TryGetTypeOptions(out options).ThrowDbgEngNotOK();

                return options;
            }
            set
            {
                TrySetTypeOptions(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetTypeOptions method returns the type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[out] Receives the type formatting options. Options is a bit-set; for a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TryGetTypeOptions(out DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref getTypeOptions, Vtbl2->GetTypeOptions);

            /*HRESULT GetTypeOptions(
            [Out] out DEBUG_TYPEOPTS Options);*/
            return getTypeOptions(Raw2, out options);
        }

        /// <summary>
        /// The SetTypeOptions method changes the type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies the new value for the type formatting options. Options is a bit-set; it will replace the existing options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TrySetTypeOptions(DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref setTypeOptions, Vtbl2->SetTypeOptions);

            /*HRESULT SetTypeOptions(
            [In] DEBUG_TYPEOPTS Options);*/
            return setTypeOptions(Raw2, options);
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
        public int GetModuleVersionInformation(int index, long @base, string item, IntPtr buffer, int bufferSize)
        {
            int verInfoSize;
            TryGetModuleVersionInformation(index, @base, item, buffer, bufferSize, out verInfoSize).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleVersionInformation(int index, long @base, string item, IntPtr buffer, int bufferSize, out int verInfoSize)
        {
            InitDelegate(ref getModuleVersionInformation, Vtbl2->GetModuleVersionInformation);

            /*HRESULT GetModuleVersionInformation(
            [In] int Index,
            [In] long Base,
            [In, MarshalAs(UnmanagedType.LPStr)] string Item,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int VerInfoSize);*/
            return getModuleVersionInformation(Raw2, index, @base, item, buffer, bufferSize, out verInfoSize);
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
        public string GetModuleNameString(DEBUG_MODNAME which, int index, long @base)
        {
            string bufferResult;
            TryGetModuleNameString(which, index, @base, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleNameString(DEBUG_MODNAME which, int index, long @base, out string bufferResult)
        {
            InitDelegate(ref getModuleNameString, Vtbl2->GetModuleNameString);
            /*HRESULT GetModuleNameString(
            [In] DEBUG_MODNAME Which,
            [In] int Index,
            [In] long Base,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            HRESULT hr = getModuleNameString(Raw2, which, index, @base, null, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getModuleNameString(Raw2, which, index, @base, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, nameSize);

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
        public string GetConstantName(long module, int typeId, long value)
        {
            string bufferResult;
            TryGetConstantName(module, typeId, value, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetConstantName(long module, int typeId, long value, out string bufferResult)
        {
            InitDelegate(ref getConstantName, Vtbl2->GetConstantName);
            /*HRESULT GetConstantName(
            [In] long Module,
            [In] int TypeId,
            [In] long Value,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            HRESULT hr = getConstantName(Raw2, module, typeId, value, null, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getConstantName(Raw2, module, typeId, value, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, nameSize);

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
        public string GetFieldName(long module, int typeId, int fieldIndex)
        {
            string bufferResult;
            TryGetFieldName(module, typeId, fieldIndex, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetFieldName(long module, int typeId, int fieldIndex, out string bufferResult)
        {
            InitDelegate(ref getFieldName, Vtbl2->GetFieldName);
            /*HRESULT GetFieldName(
            [In] long Module,
            [In] int TypeId,
            [In] int FieldIndex,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            HRESULT hr = getFieldName(Raw2, module, typeId, fieldIndex, null, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getFieldName(Raw2, module, typeId, fieldIndex, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, nameSize);

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
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public void AddTypeOptions(DEBUG_TYPEOPTS options)
        {
            TryAddTypeOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AddTypeOptions method turns on some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies type formatting options to turn on. Options is a bit-set that will be ORed with the existing type formatting options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TryAddTypeOptions(DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref addTypeOptions, Vtbl2->AddTypeOptions);

            /*HRESULT AddTypeOptions(
            [In] DEBUG_TYPEOPTS Options);*/
            return addTypeOptions(Raw2, options);
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
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public void RemoveTypeOptions(DEBUG_TYPEOPTS options)
        {
            TryRemoveTypeOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveTypeOptions method turns off some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="options">[in] Specifies the type formatting options to turn off. Options is a bit-set; the new value of the options will equal the old value AND NOT the value of Options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        public HRESULT TryRemoveTypeOptions(DEBUG_TYPEOPTS options)
        {
            InitDelegate(ref removeTypeOptions, Vtbl2->RemoveTypeOptions);

            /*HRESULT RemoveTypeOptions(
            [In] DEBUG_TYPEOPTS Options);*/
            return removeTypeOptions(Raw2, options);
        }

        #endregion
        #endregion
        #region IDebugSymbols3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr raw3;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IntPtr Raw3
        {
            get
            {
                InitInterface(typeof(IDebugSymbols3).GUID, ref raw3);

                return raw3;
            }
        }

        #region SymbolPathWide

        /// <summary>
        /// The GetSymbolPathWide method returns the symbol path.
        /// </summary>
        public string SymbolPathWide
        {
            get
            {
                string bufferResult;
                TryGetSymbolPathWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetSymbolPathWide(value).ThrowDbgEngNotOK();
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
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);*/
            char[] buffer;
            int bufferSize = 0;
            int pathSize;
            HRESULT hr = getSymbolPathWide(Raw3, null, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = pathSize;
            buffer = new char[bufferSize];
            hr = getSymbolPathWide(Raw3, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, pathSize);

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
            return setSymbolPathWide(Raw3, path);
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
                TryGetImagePathWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetImagePathWide(value).ThrowDbgEngNotOK();
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
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);*/
            char[] buffer;
            int bufferSize = 0;
            int pathSize;
            HRESULT hr = getImagePathWide(Raw3, null, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = pathSize;
            buffer = new char[bufferSize];
            hr = getImagePathWide(Raw3, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, pathSize);

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
            return setImagePathWide(Raw3, path);
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
                TryGetSourcePathWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetSourcePathWide(value).ThrowDbgEngNotOK();
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
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);*/
            char[] buffer;
            int bufferSize = 0;
            int pathSize;
            HRESULT hr = getSourcePathWide(Raw3, null, bufferSize, out pathSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = pathSize;
            buffer = new char[bufferSize];
            hr = getSourcePathWide(Raw3, buffer, bufferSize, out pathSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, pathSize);

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
            return setSourcePathWide(Raw3, path);
        }

        #endregion
        #region CurrentScopeFrameIndex

        /// <summary>
        /// The GetCurrentScopeFrameIndex method returns the index of the current stack frame in the call stack.
        /// </summary>
        public int CurrentScopeFrameIndex
        {
            get
            {
                int index;
                TryGetCurrentScopeFrameIndex(out index).ThrowDbgEngNotOK();

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
        public HRESULT TryGetCurrentScopeFrameIndex(out int index)
        {
            InitDelegate(ref getCurrentScopeFrameIndex, Vtbl3->GetCurrentScopeFrameIndex);

            /*HRESULT GetCurrentScopeFrameIndex(
            [Out] out int Index);*/
            return getCurrentScopeFrameIndex(Raw3, out index);
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
        public GetNameByOffsetWideResult GetNameByOffsetWide(long offset)
        {
            GetNameByOffsetWideResult result;
            TryGetNameByOffsetWide(offset, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetNameByOffsetWide(long offset, out GetNameByOffsetWideResult result)
        {
            InitDelegate(ref getNameByOffsetWide, Vtbl3->GetNameByOffsetWide);
            /*HRESULT GetNameByOffsetWide(
            [In] long Offset,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long displacement;
            HRESULT hr = getNameByOffsetWide(Raw3, offset, null, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getNameByOffsetWide(Raw3, offset, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByOffsetWideResult(CreateString(nameBuffer, nameSize), displacement);

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
        public long GetOffsetByNameWide(string symbol)
        {
            long offset;
            TryGetOffsetByNameWide(symbol, out offset).ThrowDbgEngNotOK();

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
        public HRESULT TryGetOffsetByNameWide(string symbol, out long offset)
        {
            InitDelegate(ref getOffsetByNameWide, Vtbl3->GetOffsetByNameWide);

            /*HRESULT GetOffsetByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out long Offset);*/
            return getOffsetByNameWide(Raw3, symbol, out offset);
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
        public GetNearNameByOffsetWideResult GetNearNameByOffsetWide(long offset, int delta)
        {
            GetNearNameByOffsetWideResult result;
            TryGetNearNameByOffsetWide(offset, delta, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetNearNameByOffsetWide(long offset, int delta, out GetNearNameByOffsetWideResult result)
        {
            InitDelegate(ref getNearNameByOffsetWide, Vtbl3->GetNearNameByOffsetWide);
            /*HRESULT GetNearNameByOffsetWide(
            [In] long Offset,
            [In] int Delta,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long displacement;
            HRESULT hr = getNearNameByOffsetWide(Raw3, offset, delta, null, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getNearNameByOffsetWide(Raw3, offset, delta, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNearNameByOffsetWideResult(CreateString(nameBuffer, nameSize), displacement);

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
        public GetLineByOffsetWideResult GetLineByOffsetWide(long offset)
        {
            GetLineByOffsetWideResult result;
            TryGetLineByOffsetWide(offset, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetLineByOffsetWide(long offset, out GetLineByOffsetWideResult result)
        {
            InitDelegate(ref getLineByOffsetWide, Vtbl3->GetLineByOffsetWide);
            /*HRESULT GetLineByOffsetWide(
            [In] long Offset,
            [Out] out int Line,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] FileBuffer,
            [In] int FileBufferSize,
            [Out] out int FileSize,
            [Out] out long Displacement);*/
            int line;
            char[] fileBuffer;
            int fileBufferSize = 0;
            int fileSize;
            long displacement;
            HRESULT hr = getLineByOffsetWide(Raw3, offset, out line, null, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileBufferSize = fileSize;
            fileBuffer = new char[fileBufferSize];
            hr = getLineByOffsetWide(Raw3, offset, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByOffsetWideResult(line, CreateString(fileBuffer, fileSize), displacement);

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
        public long GetOffsetByLineWide(int line, string file)
        {
            long offset;
            TryGetOffsetByLineWide(line, file, out offset).ThrowDbgEngNotOK();

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
        public HRESULT TryGetOffsetByLineWide(int line, string file, out long offset)
        {
            InitDelegate(ref getOffsetByLineWide, Vtbl3->GetOffsetByLineWide);

            /*HRESULT GetOffsetByLineWide(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out long Offset);*/
            return getOffsetByLineWide(Raw3, line, file, out offset);
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
        public GetModuleByModuleNameWideResult GetModuleByModuleNameWide(string name, int startIndex)
        {
            GetModuleByModuleNameWideResult result;
            TryGetModuleByModuleNameWide(name, startIndex, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleByModuleNameWide(string name, int startIndex, out GetModuleByModuleNameWideResult result)
        {
            InitDelegate(ref getModuleByModuleNameWide, Vtbl3->GetModuleByModuleNameWide);
            /*HRESULT GetModuleByModuleNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] int StartIndex,
            [Out] out int Index,
            [Out] out long Base);*/
            int index;
            long @base;
            HRESULT hr = getModuleByModuleNameWide(Raw3, name, startIndex, out index, out @base);

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
        public long GetSymbolModuleWide(string symbol)
        {
            long @base;
            TryGetSymbolModuleWide(symbol, out @base).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSymbolModuleWide(string symbol, out long @base)
        {
            InitDelegate(ref getSymbolModuleWide, Vtbl3->GetSymbolModuleWide);

            /*HRESULT GetSymbolModuleWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out long Base);*/
            return getSymbolModuleWide(Raw3, symbol, out @base);
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
        public string GetTypeNameWide(long module, int typeId)
        {
            string nameBufferResult;
            TryGetTypeNameWide(module, typeId, out nameBufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetTypeNameWide(long module, int typeId, out string nameBufferResult)
        {
            InitDelegate(ref getTypeNameWide, Vtbl3->GetTypeNameWide);
            /*HRESULT GetTypeNameWide(
            [In] long Module,
            [In] int TypeId,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            HRESULT hr = getTypeNameWide(Raw3, module, typeId, null, nameBufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getTypeNameWide(Raw3, module, typeId, nameBuffer, nameBufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                nameBufferResult = CreateString(nameBuffer, nameSize);

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
        public int GetTypeIdWide(long module, string name)
        {
            int typeId;
            TryGetTypeIdWide(module, name, out typeId).ThrowDbgEngNotOK();

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
        public HRESULT TryGetTypeIdWide(long module, string name, out int typeId)
        {
            InitDelegate(ref getTypeIdWide, Vtbl3->GetTypeIdWide);

            /*HRESULT GetTypeIdWide(
            [In] long Module,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out int TypeId);*/
            return getTypeIdWide(Raw3, module, name, out typeId);
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
        public int GetFieldOffsetWide(long module, int typeId, string field)
        {
            int offset;
            TryGetFieldOffsetWide(module, typeId, field, out offset).ThrowDbgEngNotOK();

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
        public HRESULT TryGetFieldOffsetWide(long module, int typeId, string field, out int offset)
        {
            InitDelegate(ref getFieldOffsetWide, Vtbl3->GetFieldOffsetWide);

            /*HRESULT GetFieldOffsetWide(
            [In] long Module,
            [In] int TypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out int Offset);*/
            return getFieldOffsetWide(Raw3, module, typeId, field, out offset);
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
            TryGetSymbolTypeIdWide(symbol, out result).ThrowDbgEngNotOK();

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
            [Out] out int TypeId,
            [Out] out long Module);*/
            int typeId;
            long module;
            HRESULT hr = getSymbolTypeIdWide(Raw3, symbol, out typeId, out module);

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
        public DebugSymbolGroup GetScopeSymbolGroup2(DEBUG_SCOPE_GROUP flags, IntPtr update)
        {
            DebugSymbolGroup symbolsResult;
            TryGetScopeSymbolGroup2(flags, update, out symbolsResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetScopeSymbolGroup2(DEBUG_SCOPE_GROUP flags, IntPtr update, out DebugSymbolGroup symbolsResult)
        {
            InitDelegate(ref getScopeSymbolGroup2, Vtbl3->GetScopeSymbolGroup2);
            /*HRESULT GetScopeSymbolGroup2(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, ComAliasName("IDebugSymbolGroup2")] IntPtr Update,
            [Out, ComAliasName("IDebugSymbolGroup2")] out IntPtr Symbols);*/
            IntPtr symbols;
            HRESULT hr = getScopeSymbolGroup2(Raw3, flags, update, out symbols);

            if (hr == HRESULT.S_OK)
                symbolsResult = symbols == IntPtr.Zero ? null : new DebugSymbolGroup(symbols);
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
            TryCreateSymbolGroup2(out groupResult).ThrowDbgEngNotOK();

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
            [Out, ComAliasName("IDebugSymbolGroup2")] out IntPtr Group);*/
            IntPtr group;
            HRESULT hr = createSymbolGroup2(Raw3, out group);

            if (hr == HRESULT.S_OK)
                groupResult = group == IntPtr.Zero ? null : new DebugSymbolGroup(group);
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
        public long StartSymbolMatchWide(string pattern)
        {
            long handle;
            TryStartSymbolMatchWide(pattern, out handle).ThrowDbgEngNotOK();

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
        public HRESULT TryStartSymbolMatchWide(string pattern, out long handle)
        {
            InitDelegate(ref startSymbolMatchWide, Vtbl3->StartSymbolMatchWide);

            /*HRESULT StartSymbolMatchWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Pattern,
            [Out] out long Handle);*/
            return startSymbolMatchWide(Raw3, pattern, out handle);
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
        public GetNextSymbolMatchWideResult GetNextSymbolMatchWide(long handle)
        {
            GetNextSymbolMatchWideResult result;
            TryGetNextSymbolMatchWide(handle, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetNextSymbolMatchWide(long handle, out GetNextSymbolMatchWideResult result)
        {
            InitDelegate(ref getNextSymbolMatchWide, Vtbl3->GetNextSymbolMatchWide);
            /*HRESULT GetNextSymbolMatchWide(
            [In] long Handle,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int MatchSize,
            [Out] out long Offset);*/
            char[] buffer;
            int bufferSize = 0;
            int matchSize;
            long offset;
            HRESULT hr = getNextSymbolMatchWide(Raw3, handle, null, bufferSize, out matchSize, out offset);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = matchSize;
            buffer = new char[bufferSize];
            hr = getNextSymbolMatchWide(Raw3, handle, buffer, bufferSize, out matchSize, out offset);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNextSymbolMatchWideResult(CreateString(buffer, matchSize), offset);

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
            TryReloadWide(module).ThrowDbgEngNotOK();
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
            return reloadWide(Raw3, module);
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
            TryAppendSymbolPathWide(addition).ThrowDbgEngNotOK();
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
            return appendSymbolPathWide(Raw3, addition);
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
            TryAppendImagePathWide(addition).ThrowDbgEngNotOK();
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
            return appendImagePathWide(Raw3, addition);
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
        public string GetSourcePathElementWide(int index)
        {
            string bufferResult;
            TryGetSourcePathElementWide(index, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSourcePathElementWide(int index, out string bufferResult)
        {
            InitDelegate(ref getSourcePathElementWide, Vtbl3->GetSourcePathElementWide);
            /*HRESULT GetSourcePathElementWide(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ElementSize);*/
            char[] buffer;
            int bufferSize = 0;
            int elementSize;
            HRESULT hr = getSourcePathElementWide(Raw3, index, null, bufferSize, out elementSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = elementSize;
            buffer = new char[bufferSize];
            hr = getSourcePathElementWide(Raw3, index, buffer, bufferSize, out elementSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, elementSize);

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
            TryAppendSourcePathWide(addition).ThrowDbgEngNotOK();
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
            return appendSourcePathWide(Raw3, addition);
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
        public FindSourceFileWideResult FindSourceFileWide(int startElement, string file, DEBUG_FIND_SOURCE flags)
        {
            FindSourceFileWideResult result;
            TryFindSourceFileWide(startElement, file, flags, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryFindSourceFileWide(int startElement, string file, DEBUG_FIND_SOURCE flags, out FindSourceFileWideResult result)
        {
            InitDelegate(ref findSourceFileWide, Vtbl3->FindSourceFileWide);
            /*HRESULT FindSourceFileWide(
            [In] int StartElement,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out int FoundElement,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 5)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);*/
            int foundElement;
            char[] buffer;
            int bufferSize = 0;
            int foundSize;
            HRESULT hr = findSourceFileWide(Raw3, startElement, file, flags, out foundElement, null, bufferSize, out foundSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = foundSize;
            buffer = new char[bufferSize];
            hr = findSourceFileWide(Raw3, startElement, file, flags, out foundElement, buffer, bufferSize, out foundSize);

            if (hr == HRESULT.S_OK)
            {
                result = new FindSourceFileWideResult(foundElement, CreateString(buffer, foundSize));

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
        public long[] GetSourceFileLineOffsetsWide(string file)
        {
            long[] buffer;
            TryGetSourceFileLineOffsetsWide(file, out buffer).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSourceFileLineOffsetsWide(string file, out long[] buffer)
        {
            InitDelegate(ref getSourceFileLineOffsetsWide, Vtbl3->GetSourceFileLineOffsetsWide);
            /*HRESULT GetSourceFileLineOffsetsWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] Buffer,
            [In] int BufferLines,
            [Out] out int FileLines);*/
            buffer = null;
            int bufferLines = 0;
            int fileLines;
            HRESULT hr = getSourceFileLineOffsetsWide(Raw3, file, null, bufferLines, out fileLines);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferLines = fileLines;
            buffer = new long[bufferLines];
            hr = getSourceFileLineOffsetsWide(Raw3, file, buffer, bufferLines, out fileLines);
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
        public int GetModuleVersionInformationWide(int index, long @base, string item, IntPtr buffer, int bufferSize)
        {
            int verInfoSize;
            TryGetModuleVersionInformationWide(index, @base, item, buffer, bufferSize, out verInfoSize).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleVersionInformationWide(int index, long @base, string item, IntPtr buffer, int bufferSize, out int verInfoSize)
        {
            InitDelegate(ref getModuleVersionInformationWide, Vtbl3->GetModuleVersionInformationWide);

            /*HRESULT GetModuleVersionInformationWide(
            [In] int Index,
            [In] long Base,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Item,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int VerInfoSize);*/
            return getModuleVersionInformationWide(Raw3, index, @base, item, buffer, bufferSize, out verInfoSize);
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
        public string GetModuleNameStringWide(DEBUG_MODNAME which, int index, long @base)
        {
            string bufferResult;
            TryGetModuleNameStringWide(which, index, @base, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleNameStringWide(DEBUG_MODNAME which, int index, long @base, out string bufferResult)
        {
            InitDelegate(ref getModuleNameStringWide, Vtbl3->GetModuleNameStringWide);
            /*HRESULT GetModuleNameStringWide(
            [In] DEBUG_MODNAME Which,
            [In] int Index,
            [In] long Base,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            HRESULT hr = getModuleNameStringWide(Raw3, which, index, @base, null, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getModuleNameStringWide(Raw3, which, index, @base, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, nameSize);

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
        public string GetConstantNameWide(long module, int typeId, long value)
        {
            string bufferResult;
            TryGetConstantNameWide(module, typeId, value, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetConstantNameWide(long module, int typeId, long value, out string bufferResult)
        {
            InitDelegate(ref getConstantNameWide, Vtbl3->GetConstantNameWide);
            /*HRESULT GetConstantNameWide(
            [In] long Module,
            [In] int TypeId,
            [In] long Value,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            HRESULT hr = getConstantNameWide(Raw3, module, typeId, value, null, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getConstantNameWide(Raw3, module, typeId, value, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, nameSize);

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
        public string GetFieldNameWide(long module, int typeId, int fieldIndex)
        {
            string bufferResult;
            TryGetFieldNameWide(module, typeId, fieldIndex, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetFieldNameWide(long module, int typeId, int fieldIndex, out string bufferResult)
        {
            InitDelegate(ref getFieldNameWide, Vtbl3->GetFieldNameWide);
            /*HRESULT GetFieldNameWide(
            [In] long Module,
            [In] int TypeId,
            [In] int FieldIndex,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            HRESULT hr = getFieldNameWide(Raw3, module, typeId, fieldIndex, null, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getFieldNameWide(Raw3, module, typeId, fieldIndex, buffer, bufferSize, out nameSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, nameSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region IsManagedModule

        /// <summary>
        /// Checks whether the engine is using managed debugging support when it retrieves information for a module.
        /// </summary>
        /// <param name="index">[in] The index of a module.</param>
        /// <param name="base">[in] The base of the module.</param>
        /// <remarks>
        /// It can be expensive to run this check.
        /// </remarks>
        public bool IsManagedModule(int index, long @base)
        {
            HRESULT hr = TryIsManagedModule(index, @base);
            hr.ThrowDbgEngFailed();

            return hr == HRESULT.S_OK;
        }

        /// <summary>
        /// Checks whether the engine is using managed debugging support when it retrieves information for a module.
        /// </summary>
        /// <param name="index">[in] The index of a module.</param>
        /// <param name="base">[in] The base of the module.</param>
        /// <returns>IDebugSymbols3::IsManagedModule returns a value of S_OK if the engine is using managed debugging support when it retrieves information for a module.</returns>
        /// <remarks>
        /// It can be expensive to run this check.
        /// </remarks>
        public HRESULT TryIsManagedModule(int index, long @base)
        {
            InitDelegate(ref isManagedModule, Vtbl3->IsManagedModule);

            /*HRESULT IsManagedModule(
            [In] int Index,
            [In] long Base);*/
            return isManagedModule(Raw3, index, @base);
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
        public GetModuleByModuleName2Result GetModuleByModuleName2(string name, int startIndex, DEBUG_GETMOD flags)
        {
            GetModuleByModuleName2Result result;
            TryGetModuleByModuleName2(name, startIndex, flags, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleByModuleName2(string name, int startIndex, DEBUG_GETMOD flags, out GetModuleByModuleName2Result result)
        {
            InitDelegate(ref getModuleByModuleName2, Vtbl3->GetModuleByModuleName2);
            /*HRESULT GetModuleByModuleName2(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] int StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out int Index,
            [Out] out long Base);*/
            int index;
            long @base;
            HRESULT hr = getModuleByModuleName2(Raw3, name, startIndex, flags, out index, out @base);

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
        public GetModuleByModuleName2WideResult GetModuleByModuleName2Wide(string name, int startIndex, DEBUG_GETMOD flags)
        {
            GetModuleByModuleName2WideResult result;
            TryGetModuleByModuleName2Wide(name, startIndex, flags, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleByModuleName2Wide(string name, int startIndex, DEBUG_GETMOD flags, out GetModuleByModuleName2WideResult result)
        {
            InitDelegate(ref getModuleByModuleName2Wide, Vtbl3->GetModuleByModuleName2Wide);
            /*HRESULT GetModuleByModuleName2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] int StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out int Index,
            [Out] out long Base);*/
            int index;
            long @base;
            HRESULT hr = getModuleByModuleName2Wide(Raw3, name, startIndex, flags, out index, out @base);

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
        public GetModuleByOffset2Result GetModuleByOffset2(long offset, int startIndex, DEBUG_GETMOD flags)
        {
            GetModuleByOffset2Result result;
            TryGetModuleByOffset2(offset, startIndex, flags, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetModuleByOffset2(long offset, int startIndex, DEBUG_GETMOD flags, out GetModuleByOffset2Result result)
        {
            InitDelegate(ref getModuleByOffset2, Vtbl3->GetModuleByOffset2);
            /*HRESULT GetModuleByOffset2(
            [In] long Offset,
            [In] int StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out int Index,
            [Out] out long Base);*/
            int index;
            long @base;
            HRESULT hr = getModuleByOffset2(Raw3, offset, startIndex, flags, out index, out @base);

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
        public void AddSyntheticModule(long @base, int size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            TryAddSyntheticModule(@base, size, imagePath, moduleName, flags).ThrowDbgEngNotOK();
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
        public HRESULT TryAddSyntheticModule(long @base, int size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            InitDelegate(ref addSyntheticModule, Vtbl3->AddSyntheticModule);

            /*HRESULT AddSyntheticModule(
            [In] long Base,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);*/
            return addSyntheticModule(Raw3, @base, size, imagePath, moduleName, flags);
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
        public void AddSyntheticModuleWide(long @base, int size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            TryAddSyntheticModuleWide(@base, size, imagePath, moduleName, flags).ThrowDbgEngNotOK();
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
        public HRESULT TryAddSyntheticModuleWide(long @base, int size, string imagePath, string moduleName, DEBUG_ADDSYNTHMOD flags)
        {
            InitDelegate(ref addSyntheticModuleWide, Vtbl3->AddSyntheticModuleWide);

            /*HRESULT AddSyntheticModuleWide(
            [In] long Base,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);*/
            return addSyntheticModuleWide(Raw3, @base, size, imagePath, moduleName, flags);
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
        public void RemoveSyntheticModule(long @base)
        {
            TryRemoveSyntheticModule(@base).ThrowDbgEngNotOK();
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
        public HRESULT TryRemoveSyntheticModule(long @base)
        {
            InitDelegate(ref removeSyntheticModule, Vtbl3->RemoveSyntheticModule);

            /*HRESULT RemoveSyntheticModule(
            [In] long Base);*/
            return removeSyntheticModule(Raw3, @base);
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
        public void SetScopeFrameByIndex(int index)
        {
            TrySetScopeFrameByIndex(index).ThrowDbgEngNotOK();
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
        public HRESULT TrySetScopeFrameByIndex(int index)
        {
            InitDelegate(ref setScopeFrameByIndex, Vtbl3->SetScopeFrameByIndex);

            /*HRESULT SetScopeFrameByIndex(
            [In] int Index);*/
            return setScopeFrameByIndex(Raw3, index);
        }

        #endregion
        #region SetScopeFromJitDebugInfo

        /// <summary>
        /// Recovers just-in-time (JIT) debugging information and sets current debugger scope context based on that information.
        /// </summary>
        /// <param name="outputControl">[in] An output control.</param>
        /// <param name="infoOffset">[in] An offset for the debugging information.</param>
        public void SetScopeFromJitDebugInfo(int outputControl, long infoOffset)
        {
            TrySetScopeFromJitDebugInfo(outputControl, infoOffset).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Recovers just-in-time (JIT) debugging information and sets current debugger scope context based on that information.
        /// </summary>
        /// <param name="outputControl">[in] An output control.</param>
        /// <param name="infoOffset">[in] An offset for the debugging information.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. The method gets JUT debugging information from a specified address from the debugging target, and then sets the current debugger scope context from that information.<para/>
        /// This method is equivalent to '.jdinfo' command.</returns>
        public HRESULT TrySetScopeFromJitDebugInfo(int outputControl, long infoOffset)
        {
            InitDelegate(ref setScopeFromJitDebugInfo, Vtbl3->SetScopeFromJitDebugInfo);

            /*HRESULT SetScopeFromJitDebugInfo(
            [In] int OutputControl,
            [In] long InfoOffset);*/
            return setScopeFromJitDebugInfo(Raw3, outputControl, infoOffset);
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
            TrySetScopeFromStoredEvent().ThrowDbgEngNotOK();
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
            return setScopeFromStoredEvent(Raw3);
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
        public void OutputSymbolByOffset(int outputControl, DEBUG_OUTSYM flags, long offset)
        {
            TryOutputSymbolByOffset(outputControl, flags, offset).ThrowDbgEngNotOK();
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
        public HRESULT TryOutputSymbolByOffset(int outputControl, DEBUG_OUTSYM flags, long offset)
        {
            InitDelegate(ref outputSymbolByOffset, Vtbl3->OutputSymbolByOffset);

            /*HRESULT OutputSymbolByOffset(
            [In] int OutputControl,
            [In] DEBUG_OUTSYM Flags,
            [In] long Offset);*/
            return outputSymbolByOffset(Raw3, outputControl, flags, offset);
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
        public int GetFunctionEntryByOffset(long offset, DEBUG_GETFNENT flags, IntPtr buffer, int bufferSize)
        {
            int bufferNeeded;
            TryGetFunctionEntryByOffset(offset, flags, buffer, bufferSize, out bufferNeeded).ThrowDbgEngNotOK();

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
        public HRESULT TryGetFunctionEntryByOffset(long offset, DEBUG_GETFNENT flags, IntPtr buffer, int bufferSize, out int bufferNeeded)
        {
            InitDelegate(ref getFunctionEntryByOffset, Vtbl3->GetFunctionEntryByOffset);

            /*HRESULT GetFunctionEntryByOffset(
            [In] long Offset,
            [In] DEBUG_GETFNENT Flags,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BufferNeeded);*/
            return getFunctionEntryByOffset(Raw3, offset, flags, buffer, bufferSize, out bufferNeeded);
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
        public GetFieldTypeAndOffsetResult GetFieldTypeAndOffset(long module, int containerTypeId, string field)
        {
            GetFieldTypeAndOffsetResult result;
            TryGetFieldTypeAndOffset(module, containerTypeId, field, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetFieldTypeAndOffset(long module, int containerTypeId, string field, out GetFieldTypeAndOffsetResult result)
        {
            InitDelegate(ref getFieldTypeAndOffset, Vtbl3->GetFieldTypeAndOffset);
            /*HRESULT GetFieldTypeAndOffset(
            [In] long Module,
            [In] int ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out int FieldTypeId,
            [Out] out int Offset);*/
            int fieldTypeId;
            int offset;
            HRESULT hr = getFieldTypeAndOffset(Raw3, module, containerTypeId, field, out fieldTypeId, out offset);

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
        public GetFieldTypeAndOffsetWideResult GetFieldTypeAndOffsetWide(long module, int containerTypeId, string field)
        {
            GetFieldTypeAndOffsetWideResult result;
            TryGetFieldTypeAndOffsetWide(module, containerTypeId, field, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetFieldTypeAndOffsetWide(long module, int containerTypeId, string field, out GetFieldTypeAndOffsetWideResult result)
        {
            InitDelegate(ref getFieldTypeAndOffsetWide, Vtbl3->GetFieldTypeAndOffsetWide);
            /*HRESULT GetFieldTypeAndOffsetWide(
            [In] long Module,
            [In] int ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out int FieldTypeId,
            [Out] out int Offset);*/
            int fieldTypeId;
            int offset;
            HRESULT hr = getFieldTypeAndOffsetWide(Raw3, module, containerTypeId, field, out fieldTypeId, out offset);

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
        public DEBUG_MODULE_AND_ID AddSyntheticSymbol(long offset, int size, string name, DEBUG_ADDSYNTHSYM flags)
        {
            DEBUG_MODULE_AND_ID id;
            TryAddSyntheticSymbol(offset, size, name, flags, out id).ThrowDbgEngNotOK();

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
        public HRESULT TryAddSyntheticSymbol(long offset, int size, string name, DEBUG_ADDSYNTHSYM flags, out DEBUG_MODULE_AND_ID id)
        {
            InitDelegate(ref addSyntheticSymbol, Vtbl3->AddSyntheticSymbol);

            /*HRESULT AddSyntheticSymbol(
            [In] long Offset,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);*/
            return addSyntheticSymbol(Raw3, offset, size, name, flags, out id);
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
        public DEBUG_MODULE_AND_ID AddSyntheticSymbolWide(long offset, int size, string name, DEBUG_ADDSYNTHSYM flags)
        {
            DEBUG_MODULE_AND_ID id;
            TryAddSyntheticSymbolWide(offset, size, name, flags, out id).ThrowDbgEngNotOK();

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
        public HRESULT TryAddSyntheticSymbolWide(long offset, int size, string name, DEBUG_ADDSYNTHSYM flags, out DEBUG_MODULE_AND_ID id)
        {
            InitDelegate(ref addSyntheticSymbolWide, Vtbl3->AddSyntheticSymbolWide);

            /*HRESULT AddSyntheticSymbolWide(
            [In] long Offset,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);*/
            return addSyntheticSymbolWide(Raw3, offset, size, name, flags, out id);
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
            TryRemoveSyntheticSymbol(id).ThrowDbgEngNotOK();
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
            [In] ref DEBUG_MODULE_AND_ID Id);*/
            return removeSyntheticSymbol(Raw3, ref id);
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
        public GetSymbolEntriesByOffsetResult GetSymbolEntriesByOffset(long offset, int flags)
        {
            GetSymbolEntriesByOffsetResult result;
            TryGetSymbolEntriesByOffset(offset, flags, out result).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSymbolEntriesByOffset(long offset, int flags, out GetSymbolEntriesByOffsetResult result)
        {
            InitDelegate(ref getSymbolEntriesByOffset, Vtbl3->GetSymbolEntriesByOffset);
            /*HRESULT GetSymbolEntriesByOffset(
            [In] long Offset,
            [In] int Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_MODULE_AND_ID[] Ids,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] long[] Displacements,
            [In] int IdsCount,
            [Out] out int Entries);*/
            DEBUG_MODULE_AND_ID[] ids;
            long[] displacements;
            int idsCount = 0;
            int entries;
            HRESULT hr = getSymbolEntriesByOffset(Raw3, offset, flags, null, null, idsCount, out entries);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            idsCount = entries;
            displacements = new long[idsCount];
            ids = new DEBUG_MODULE_AND_ID[idsCount];
            hr = getSymbolEntriesByOffset(Raw3, offset, flags, ids, displacements, idsCount, out entries);

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
        public DEBUG_MODULE_AND_ID[] GetSymbolEntriesByName(string symbol, int flags)
        {
            DEBUG_MODULE_AND_ID[] ids;
            TryGetSymbolEntriesByName(symbol, flags, out ids).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSymbolEntriesByName(string symbol, int flags, out DEBUG_MODULE_AND_ID[] ids)
        {
            InitDelegate(ref getSymbolEntriesByName, Vtbl3->GetSymbolEntriesByName);
            /*HRESULT GetSymbolEntriesByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [In] int Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_MODULE_AND_ID[] Ids,
            [In] int IdsCount,
            [Out] out int Entries);*/
            ids = null;
            int idsCount = 0;
            int entries;
            HRESULT hr = getSymbolEntriesByName(Raw3, symbol, flags, null, idsCount, out entries);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            idsCount = entries;
            ids = new DEBUG_MODULE_AND_ID[idsCount];
            hr = getSymbolEntriesByName(Raw3, symbol, flags, ids, idsCount, out entries);
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
        public DEBUG_MODULE_AND_ID[] GetSymbolEntriesByNameWide(string symbol, int flags)
        {
            DEBUG_MODULE_AND_ID[] ids;
            TryGetSymbolEntriesByNameWide(symbol, flags, out ids).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSymbolEntriesByNameWide(string symbol, int flags, out DEBUG_MODULE_AND_ID[] ids)
        {
            InitDelegate(ref getSymbolEntriesByNameWide, Vtbl3->GetSymbolEntriesByNameWide);
            /*HRESULT GetSymbolEntriesByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [In] int Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_MODULE_AND_ID[] Ids,
            [In] int IdsCount,
            [Out] out int Entries);*/
            ids = null;
            int idsCount = 0;
            int entries;
            HRESULT hr = getSymbolEntriesByNameWide(Raw3, symbol, flags, null, idsCount, out entries);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            idsCount = entries;
            ids = new DEBUG_MODULE_AND_ID[idsCount];
            hr = getSymbolEntriesByNameWide(Raw3, symbol, flags, ids, idsCount, out entries);
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
        public DEBUG_MODULE_AND_ID GetSymbolEntryByToken(long moduleBase, mdToken token)
        {
            DEBUG_MODULE_AND_ID id;
            TryGetSymbolEntryByToken(moduleBase, token, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// Looks up a symbol by using a managed metadata token.
        /// </summary>
        /// <param name="moduleBase">[in] The base of the module.</param>
        /// <param name="token">[in] The token to use to look up the symbol.</param>
        /// <param name="id">[out] A pointer to the module as a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSymbolEntryByToken(long moduleBase, mdToken token, out DEBUG_MODULE_AND_ID id)
        {
            InitDelegate(ref getSymbolEntryByToken, Vtbl3->GetSymbolEntryByToken);

            /*HRESULT GetSymbolEntryByToken(
            [In] long ModuleBase,
            [In] mdToken Token,
            [Out] out DEBUG_MODULE_AND_ID Id);*/
            return getSymbolEntryByToken(Raw3, moduleBase, token, out id);
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
            TryGetSymbolEntryInformation(id, out info).ThrowDbgEngNotOK();

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
            return getSymbolEntryInformation(Raw3, ref id, out info);
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
        public string GetSymbolEntryString(DEBUG_MODULE_AND_ID id, int which)
        {
            string bufferResult;
            TryGetSymbolEntryString(id, which, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSymbolEntryString(DEBUG_MODULE_AND_ID id, int which, out string bufferResult)
        {
            InitDelegate(ref getSymbolEntryString, Vtbl3->GetSymbolEntryString);
            /*HRESULT GetSymbolEntryString(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [In] int Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            char[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = getSymbolEntryString(Raw3, ref id, which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new char[bufferSize];
            hr = getSymbolEntryString(Raw3, ref id, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

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
        public string GetSymbolEntryStringWide(DEBUG_MODULE_AND_ID id, int which)
        {
            string bufferResult;
            TryGetSymbolEntryStringWide(id, which, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSymbolEntryStringWide(DEBUG_MODULE_AND_ID id, int which, out string bufferResult)
        {
            InitDelegate(ref getSymbolEntryStringWide, Vtbl3->GetSymbolEntryStringWide);
            /*HRESULT GetSymbolEntryStringWide(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [In] int Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            char[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = getSymbolEntryStringWide(Raw3, ref id, which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new char[bufferSize];
            hr = getSymbolEntryStringWide(Raw3, ref id, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSymbolEntryOffsetRegions

        /// <summary>
        /// Returns all the memory regions known to be associated with a symbol.
        /// </summary>
        /// <param name="id">[in] The ID of a module as a pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] The memory regions associated with the symbol.</returns>
        public DEBUG_OFFSET_REGION[] GetSymbolEntryOffsetRegions(DEBUG_MODULE_AND_ID id, int flags)
        {
            DEBUG_OFFSET_REGION[] regions;
            TryGetSymbolEntryOffsetRegions(id, flags, out regions).ThrowDbgEngNotOK();

            return regions;
        }

        /// <summary>
        /// Returns all the memory regions known to be associated with a symbol.
        /// </summary>
        /// <param name="id">[in] The ID of a module as a pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="regions">[out] The memory regions associated with the symbol.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This function returns all known memory regions that associated with a specified symbol.<para/>
        /// Simple symbols have a single region that starts from their base. More complicated regions, such as functions that have multiple code areas, can have an arbitrarily large number of regions.<para/>
        /// The quality of information returned is highly dependent on the symbolic information available.</returns>
        public HRESULT TryGetSymbolEntryOffsetRegions(DEBUG_MODULE_AND_ID id, int flags, out DEBUG_OFFSET_REGION[] regions)
        {
            InitDelegate(ref getSymbolEntryOffsetRegions, Vtbl3->GetSymbolEntryOffsetRegions);
            /*HRESULT GetSymbolEntryOffsetRegions(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [In] int Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_OFFSET_REGION[] Regions,
            [In] int RegionsCount,
            [Out] out int RegionsAvail);*/
            regions = null;
            int regionsCount = 0;
            int regionsAvail;
            HRESULT hr = getSymbolEntryOffsetRegions(Raw3, ref id, flags, null, regionsCount, out regionsAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            regionsCount = regionsAvail;
            regions = new DEBUG_OFFSET_REGION[regionsCount];
            hr = getSymbolEntryOffsetRegions(Raw3, ref id, flags, regions, regionsCount, out regionsAvail);
            fail:
            return hr;
        }

        #endregion
        #region GetSymbolEntryBySymbolEntry

        /// <summary>
        /// Allows navigation within the symbol entry hierarchy.
        /// </summary>
        /// <param name="fromId">[in] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the input ID.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the output ID.</returns>
        public DEBUG_MODULE_AND_ID GetSymbolEntryBySymbolEntry(DEBUG_MODULE_AND_ID fromId, int flags)
        {
            DEBUG_MODULE_AND_ID toId;
            TryGetSymbolEntryBySymbolEntry(fromId, flags, out toId).ThrowDbgEngNotOK();

            return toId;
        }

        /// <summary>
        /// Allows navigation within the symbol entry hierarchy.
        /// </summary>
        /// <param name="fromId">[in] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the input ID.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="toId">[out] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the output ID.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSymbolEntryBySymbolEntry(DEBUG_MODULE_AND_ID fromId, int flags, out DEBUG_MODULE_AND_ID toId)
        {
            InitDelegate(ref getSymbolEntryBySymbolEntry, Vtbl3->GetSymbolEntryBySymbolEntry);

            /*HRESULT GetSymbolEntryBySymbolEntry(
            [In] ref DEBUG_MODULE_AND_ID FromId,
            [In] int Flags,
            [Out] out DEBUG_MODULE_AND_ID ToId);*/
            return getSymbolEntryBySymbolEntry(Raw3, ref fromId, flags, out toId);
        }

        #endregion
        #region GetSourceEntriesByOffset

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory by using an offset.
        /// </summary>
        /// <param name="offset">[in] The offset of the entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to a returned entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</returns>
        public DEBUG_SYMBOL_SOURCE_ENTRY[] GetSourceEntriesByOffset(long offset, int flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY[] entries;
            TryGetSourceEntriesByOffset(offset, flags, out entries).ThrowDbgEngNotOK();

            return entries;
        }

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory by using an offset.
        /// </summary>
        /// <param name="offset">[in] The offset of the entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="entries">[out] A pointer to a returned entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSourceEntriesByOffset(long offset, int flags, out DEBUG_SYMBOL_SOURCE_ENTRY[] entries)
        {
            InitDelegate(ref getSourceEntriesByOffset, Vtbl3->GetSourceEntriesByOffset);
            /*HRESULT GetSourceEntriesByOffset(
            [In] long Offset,
            [In] int Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] int EntriesCount,
            [Out] out int EntriesAvail);*/
            entries = null;
            int entriesCount = 0;
            int entriesAvail;
            HRESULT hr = getSourceEntriesByOffset(Raw3, offset, flags, null, entriesCount, out entriesAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            entriesCount = entriesAvail;
            entries = new DEBUG_SYMBOL_SOURCE_ENTRY[entriesCount];
            hr = getSourceEntriesByOffset(Raw3, offset, flags, entries, entriesCount, out entriesAvail);
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
        /// <returns>[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for.<para/>
        /// Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        public DEBUG_SYMBOL_SOURCE_ENTRY[] GetSourceEntriesByLine(int line, string file, DEBUG_GSEL flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY[] entries;
            TryGetSourceEntriesByLine(line, file, flags, out entries).ThrowDbgEngNotOK();

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
        /// <param name="entries">[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for.<para/>
        /// Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetSourceEntriesByLine(int line, string file, DEBUG_GSEL flags, out DEBUG_SYMBOL_SOURCE_ENTRY[] entries)
        {
            InitDelegate(ref getSourceEntriesByLine, Vtbl3->GetSourceEntriesByLine);
            /*HRESULT GetSourceEntriesByLine(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_GSEL Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] int EntriesCount,
            [Out] out int EntriesAvail);*/
            entries = null;
            int entriesCount = 0;
            int entriesAvail;
            HRESULT hr = getSourceEntriesByLine(Raw3, line, file, flags, null, entriesCount, out entriesAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            entriesCount = entriesAvail;
            entries = new DEBUG_SYMBOL_SOURCE_ENTRY[entriesCount];
            hr = getSourceEntriesByLine(Raw3, line, file, flags, entries, entriesCount, out entriesAvail);
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
        public DEBUG_SYMBOL_SOURCE_ENTRY[] GetSourceEntriesByLineWide(int line, string file, DEBUG_GSEL flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY[] entries;
            TryGetSourceEntriesByLineWide(line, file, flags, out entries).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSourceEntriesByLineWide(int line, string file, DEBUG_GSEL flags, out DEBUG_SYMBOL_SOURCE_ENTRY[] entries)
        {
            InitDelegate(ref getSourceEntriesByLineWide, Vtbl3->GetSourceEntriesByLineWide);
            /*HRESULT GetSourceEntriesByLineWide(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_GSEL Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] int EntriesCount,
            [Out] out int EntriesAvail);*/
            entries = null;
            int entriesCount = 0;
            int entriesAvail;
            HRESULT hr = getSourceEntriesByLineWide(Raw3, line, file, flags, null, entriesCount, out entriesAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            entriesCount = entriesAvail;
            entries = new DEBUG_SYMBOL_SOURCE_ENTRY[entriesCount];
            hr = getSourceEntriesByLineWide(Raw3, line, file, flags, entries, entriesCount, out entriesAvail);
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
        public string GetSourceEntryString(DEBUG_SYMBOL_SOURCE_ENTRY entry, int which)
        {
            string bufferResult;
            TryGetSourceEntryString(entry, which, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSourceEntryString(DEBUG_SYMBOL_SOURCE_ENTRY entry, int which, out string bufferResult)
        {
            InitDelegate(ref getSourceEntryString, Vtbl3->GetSourceEntryString);
            /*HRESULT GetSourceEntryString(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] int Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            char[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = getSourceEntryString(Raw3, ref entry, which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new char[bufferSize];
            hr = getSourceEntryString(Raw3, ref entry, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

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
        public string GetSourceEntryStringWide(DEBUG_SYMBOL_SOURCE_ENTRY entry, int which)
        {
            string bufferResult;
            TryGetSourceEntryStringWide(entry, which, out bufferResult).ThrowDbgEngNotOK();

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
        public HRESULT TryGetSourceEntryStringWide(DEBUG_SYMBOL_SOURCE_ENTRY entry, int which, out string bufferResult)
        {
            InitDelegate(ref getSourceEntryStringWide, Vtbl3->GetSourceEntryStringWide);
            /*HRESULT GetSourceEntryStringWide(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] int Which,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            char[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = getSourceEntryStringWide(Raw3, ref entry, which, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new char[bufferSize];
            hr = getSourceEntryStringWide(Raw3, ref entry, which, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetSourceEntryOffsetRegions

        /// <summary>
        /// Returns all memory regions known to be associated with a source entry.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] The memory regions associated with the source entry.</returns>
        public DEBUG_OFFSET_REGION[] GetSourceEntryOffsetRegions(DEBUG_SYMBOL_SOURCE_ENTRY entry, int flags)
        {
            DEBUG_OFFSET_REGION[] regions;
            TryGetSourceEntryOffsetRegions(entry, flags, out regions).ThrowDbgEngNotOK();

            return regions;
        }

        /// <summary>
        /// Returns all memory regions known to be associated with a source entry.
        /// </summary>
        /// <param name="entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="regions">[out] The memory regions associated with the source entry.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This function returns all known memory regions that associated with a specified source entry.<para/>
        /// Simple symbols have a single region that starts from their base. More complicated regions, such as functions that have multiple code areas, can have an arbitrarily large number of regions.</returns>
        public HRESULT TryGetSourceEntryOffsetRegions(DEBUG_SYMBOL_SOURCE_ENTRY entry, int flags, out DEBUG_OFFSET_REGION[] regions)
        {
            InitDelegate(ref getSourceEntryOffsetRegions, Vtbl3->GetSourceEntryOffsetRegions);
            /*HRESULT GetSourceEntryOffsetRegions(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] int Flags,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_OFFSET_REGION[] Regions,
            [In] int RegionsCount,
            [Out] out int RegionsAvail);*/
            regions = null;
            int regionsCount = 0;
            int regionsAvail;
            HRESULT hr = getSourceEntryOffsetRegions(Raw3, ref entry, flags, null, regionsCount, out regionsAvail);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            regionsCount = regionsAvail;
            regions = new DEBUG_OFFSET_REGION[regionsCount];
            hr = getSourceEntryOffsetRegions(Raw3, ref entry, flags, regions, regionsCount, out regionsAvail);
            fail:
            return hr;
        }

        #endregion
        #region GetSourceEntryBySourceEntry

        /// <summary>
        /// Allows navigation within the source entries.
        /// </summary>
        /// <param name="fromEntry">[in] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the input entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the output entry.</returns>
        public DEBUG_SYMBOL_SOURCE_ENTRY GetSourceEntryBySourceEntry(DEBUG_SYMBOL_SOURCE_ENTRY fromEntry, int flags)
        {
            DEBUG_SYMBOL_SOURCE_ENTRY toEntry;
            TryGetSourceEntryBySourceEntry(fromEntry, flags, out toEntry).ThrowDbgEngNotOK();

            return toEntry;
        }

        /// <summary>
        /// Allows navigation within the source entries.
        /// </summary>
        /// <param name="fromEntry">[in] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the input entry.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="toEntry">[out] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the output entry.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetSourceEntryBySourceEntry(DEBUG_SYMBOL_SOURCE_ENTRY fromEntry, int flags, out DEBUG_SYMBOL_SOURCE_ENTRY toEntry)
        {
            InitDelegate(ref getSourceEntryBySourceEntry, Vtbl3->GetSourceEntryBySourceEntry);

            /*HRESULT GetSourceEntryBySourceEntry(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY FromEntry,
            [In] int Flags,
            [Out] out DEBUG_SYMBOL_SOURCE_ENTRY ToEntry);*/
            return getSourceEntryBySourceEntry(Raw3, ref fromEntry, flags, out toEntry);
        }

        #endregion
        #endregion
        #region IDebugSymbols4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr raw4;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IntPtr Raw4
        {
            get
            {
                InitInterface(typeof(IDebugSymbols4).GUID, ref raw4);

                return raw4;
            }
        }

        #region GetScopeEx

        /// <summary>
        /// Gets the scope as an extended frame structure.
        /// </summary>
        /// <param name="scopeContext">[out] A pointer to the scope context returned.</param>
        /// <param name="scopeContextSize">[in] The size of the scope context.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetScopeExResult GetScopeEx(IntPtr scopeContext, int scopeContextSize)
        {
            GetScopeExResult result;
            TryGetScopeEx(scopeContext, scopeContextSize, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Gets the scope as an extended frame structure.
        /// </summary>
        /// <param name="scopeContext">[out] A pointer to the scope context returned.</param>
        /// <param name="scopeContextSize">[in] The size of the scope context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetScopeEx(IntPtr scopeContext, int scopeContextSize, out GetScopeExResult result)
        {
            InitDelegate(ref getScopeEx, Vtbl4->GetScopeEx);
            /*HRESULT GetScopeEx(
            [Out] out long InstructionOffset,
            [Out] out DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] int ScopeContextSize);*/
            long instructionOffset;
            DEBUG_STACK_FRAME_EX scopeFrame;
            HRESULT hr = getScopeEx(Raw4, out instructionOffset, out scopeFrame, scopeContext, scopeContextSize);

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
        public void SetScopeEx(long instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame, IntPtr scopeContext, int scopeContextSize)
        {
            TrySetScopeEx(instructionOffset, scopeFrame, scopeContext, scopeContextSize).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Sets the scope as an extended frame structure.
        /// </summary>
        /// <param name="instructionOffset">[in] The offset of the instruction for the scope.</param>
        /// <param name="scopeFrame">[in, optional] The scope frame to set as a <see cref="DEBUG_STACK_FRAME_EX"/> structure.</param>
        /// <param name="scopeContext">[in] A pointer to a scope context.</param>
        /// <param name="scopeContextSize">[in] The size of the scope context.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySetScopeEx(long instructionOffset, DEBUG_STACK_FRAME_EX scopeFrame, IntPtr scopeContext, int scopeContextSize)
        {
            InitDelegate(ref setScopeEx, Vtbl4->SetScopeEx);

            /*HRESULT SetScopeEx(
            [In] long InstructionOffset,
            [In] ref DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] int ScopeContextSize);*/
            return setScopeEx(Raw4, instructionOffset, ref scopeFrame, scopeContext, scopeContextSize);
        }

        #endregion
        #region GetNameByInlineContext

        /// <summary>
        /// Gets a name by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the name.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetNameByInlineContextResult GetNameByInlineContext(long offset, int inlineContext)
        {
            GetNameByInlineContextResult result;
            TryGetNameByInlineContext(offset, inlineContext, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Gets a name by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the name.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetNameByInlineContext(long offset, int inlineContext, out GetNameByInlineContextResult result)
        {
            InitDelegate(ref getNameByInlineContext, Vtbl4->GetNameByInlineContext);
            /*HRESULT GetNameByInlineContext(
            [In] long Offset,
            [In] int InlineContext,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long displacement;
            HRESULT hr = getNameByInlineContext(Raw4, offset, inlineContext, null, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getNameByInlineContext(Raw4, offset, inlineContext, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByInlineContextResult(CreateString(nameBuffer, nameSize), displacement);

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
        public GetNameByInlineContextWideResult GetNameByInlineContextWide(long offset, int inlineContext)
        {
            GetNameByInlineContextWideResult result;
            TryGetNameByInlineContextWide(offset, inlineContext, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Gets a name by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the inline context.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetNameByInlineContextWide(long offset, int inlineContext, out GetNameByInlineContextWideResult result)
        {
            InitDelegate(ref getNameByInlineContextWide, Vtbl4->GetNameByInlineContextWide);
            /*HRESULT GetNameByInlineContextWide(
            [In] long Offset,
            [In] int InlineContext,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);*/
            char[] nameBuffer;
            int nameBufferSize = 0;
            int nameSize;
            long displacement;
            HRESULT hr = getNameByInlineContextWide(Raw4, offset, inlineContext, null, nameBufferSize, out nameSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            nameBufferSize = nameSize;
            nameBuffer = new char[nameBufferSize];
            hr = getNameByInlineContextWide(Raw4, offset, inlineContext, nameBuffer, nameBufferSize, out nameSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetNameByInlineContextWideResult(CreateString(nameBuffer, nameSize), displacement);

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
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLineByInlineContextResult GetLineByInlineContext(long offset, int inlineContext)
        {
            GetLineByInlineContextResult result;
            TryGetLineByInlineContext(offset, inlineContext, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Gets a line by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the line.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetLineByInlineContext(long offset, int inlineContext, out GetLineByInlineContextResult result)
        {
            InitDelegate(ref getLineByInlineContext, Vtbl4->GetLineByInlineContext);
            /*HRESULT GetLineByInlineContext(
            [In] long Offset,
            [In] int InlineContext,
            [Out] out int Line,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] FileBuffer,
            [In] int FileBufferSize,
            [Out] out int FileSize,
            [Out] out long Displacement);*/
            int line;
            char[] fileBuffer;
            int fileBufferSize = 0;
            int fileSize;
            long displacement;
            HRESULT hr = getLineByInlineContext(Raw4, offset, inlineContext, out line, null, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileBufferSize = fileSize;
            fileBuffer = new char[fileBufferSize];
            hr = getLineByInlineContext(Raw4, offset, inlineContext, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByInlineContextResult(line, CreateString(fileBuffer, fileSize), displacement);

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
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLineByInlineContextWideResult GetLineByInlineContextWide(long offset, int inlineContext)
        {
            GetLineByInlineContextWideResult result;
            TryGetLineByInlineContextWide(offset, inlineContext, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Gets a line by inline context.
        /// </summary>
        /// <param name="offset">[in] An offset for the line.</param>
        /// <param name="inlineContext">[in] The inline context.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetLineByInlineContextWide(long offset, int inlineContext, out GetLineByInlineContextWideResult result)
        {
            InitDelegate(ref getLineByInlineContextWide, Vtbl4->GetLineByInlineContextWide);
            /*HRESULT GetLineByInlineContextWide(
            [In] long Offset,
            [In] int InlineContext,
            [Out] out int Line,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] FileBuffer,
            [In] int FileBufferSize,
            [Out] out int FileSize,
            [Out] out long Displacement);*/
            int line;
            char[] fileBuffer;
            int fileBufferSize = 0;
            int fileSize;
            long displacement;
            HRESULT hr = getLineByInlineContextWide(Raw4, offset, inlineContext, out line, null, fileBufferSize, out fileSize, out displacement);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileBufferSize = fileSize;
            fileBuffer = new char[fileBufferSize];
            hr = getLineByInlineContextWide(Raw4, offset, inlineContext, out line, fileBuffer, fileBufferSize, out fileSize, out displacement);

            if (hr == HRESULT.S_OK)
            {
                result = new GetLineByInlineContextWideResult(line, CreateString(fileBuffer, fileSize), displacement);

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
        public void OutputSymbolByInlineContext(int outputControl, int flags, long offset, int inlineContext)
        {
            TryOutputSymbolByInlineContext(outputControl, flags, offset, inlineContext).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Specifies an output symbol by using an inline context.
        /// </summary>
        /// <param name="outputControl">[in] An output control.</param>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="offset">[in] An offset.</param>
        /// <param name="inlineContext">[in] An inline context.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryOutputSymbolByInlineContext(int outputControl, int flags, long offset, int inlineContext)
        {
            InitDelegate(ref outputSymbolByInlineContext, Vtbl4->OutputSymbolByInlineContext);

            /*HRESULT OutputSymbolByInlineContext(
            [In] int OutputControl,
            [In] int Flags,
            [In] long Offset,
            [In] int InlineContext);*/
            return outputSymbolByInlineContext(Raw4, outputControl, flags, offset, inlineContext);
        }

        #endregion
        #endregion
        #region IDebugSymbols5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr raw5;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IntPtr Raw5
        {
            get
            {
                InitInterface(typeof(IDebugSymbols5).GUID, ref raw5);

                return raw5;
            }
        }

        #region GetCurrentScopeFrameIndexEx

        /// <summary>
        /// Gets the index of the current frame.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <returns>[out] A pointer to an index that this function gets.</returns>
        public int GetCurrentScopeFrameIndexEx(DEBUG_FRAME flags)
        {
            int index;
            TryGetCurrentScopeFrameIndexEx(flags, out index).ThrowDbgEngNotOK();

            return index;
        }

        /// <summary>
        /// Gets the index of the current frame.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="index">[out] A pointer to an index that this function gets.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetCurrentScopeFrameIndexEx(DEBUG_FRAME flags, out int index)
        {
            InitDelegate(ref getCurrentScopeFrameIndexEx, Vtbl5->GetCurrentScopeFrameIndexEx);

            /*HRESULT GetCurrentScopeFrameIndexEx(
            [In] DEBUG_FRAME Flags,
            [Out] out int Index);*/
            return getCurrentScopeFrameIndexEx(Raw5, flags, out index);
        }

        #endregion
        #region SetScopeFrameByIndexEx

        /// <summary>
        /// Sets the current frame by using an index.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="index">[in] An index by which to set the frame.</param>
        public void SetScopeFrameByIndexEx(DEBUG_FRAME flags, int index)
        {
            TrySetScopeFrameByIndexEx(flags, index).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Sets the current frame by using an index.
        /// </summary>
        /// <param name="flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="index">[in] An index by which to set the frame.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySetScopeFrameByIndexEx(DEBUG_FRAME flags, int index)
        {
            InitDelegate(ref setScopeFrameByIndexEx, Vtbl5->SetScopeFrameByIndexEx);

            /*HRESULT SetScopeFrameByIndexEx(
            [In] DEBUG_FRAME Flags,
            [In] int Index);*/
            return setScopeFrameByIndexEx(Raw5, flags, index);
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
        private delegate HRESULT GetNumberModulesDelegate(IntPtr self, [Out] out int Loaded, [Out] out int Unloaded);
        private delegate HRESULT GetSymbolPathDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PathSize);
        private delegate HRESULT SetSymbolPathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path);
        private delegate HRESULT GetImagePathDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PathSize);
        private delegate HRESULT SetImagePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path);
        private delegate HRESULT GetSourcePathDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PathSize);
        private delegate HRESULT SetSourcePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Path);
        private delegate HRESULT AddSymbolOptionsDelegate(IntPtr self, [In] SYMOPT Options);
        private delegate HRESULT RemoveSymbolOptionsDelegate(IntPtr self, [In] SYMOPT Options);
        private delegate HRESULT GetNameByOffsetDelegate(IntPtr self, [In] long Offset, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize, [Out] out long Displacement);
        private delegate HRESULT GetOffsetByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [Out] out long Offset);
        private delegate HRESULT GetNearNameByOffsetDelegate(IntPtr self, [In] long Offset, [In] int Delta, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize, [Out] out long Displacement);
        private delegate HRESULT GetLineByOffsetDelegate(IntPtr self, [In] long Offset, [Out] out int Line, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] FileBuffer, [In] int FileBufferSize, [Out] out int FileSize, [Out] out long Displacement);
        private delegate HRESULT GetOffsetByLineDelegate(IntPtr self, [In] int Line, [In, MarshalAs(UnmanagedType.LPStr)] string File, [Out] out long Offset);
        private delegate HRESULT GetModuleByIndexDelegate(IntPtr self, [In] int Index, [Out] out long Base);
        private delegate HRESULT GetModuleByModuleNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [In] int StartIndex, [Out] out int Index, [Out] out long Base);
        private delegate HRESULT GetModuleByOffsetDelegate(IntPtr self, [In] long Offset, [In] int StartIndex, [Out] out int Index, [Out] out long Base);
        private delegate HRESULT GetModuleNamesDelegate(IntPtr self, [In] int Index, [In] long Base, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] ImageNameBuffer, [In] int ImageNameBufferSize, [Out] out int ImageNameSize, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 6)] char[] ModuleNameBuffer, [In] int ModuleNameBufferSize, [Out] out int ModuleNameSize, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 9)] char[] LoadedImageNameBuffer, [In] int LoadedImageNameBufferSize, [Out] out int LoadedImageNameSize);
        private delegate HRESULT GetModuleParametersDelegate(IntPtr self, [In] int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] long[] Bases, [In] int Start, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_MODULE_PARAMETERS[] Params);
        private delegate HRESULT GetSymbolModuleDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [Out] out long Base);
        private delegate HRESULT GetTypeNameDelegate(IntPtr self, [In] long Module, [In] int TypeId, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize);
        private delegate HRESULT GetTypeIdDelegate(IntPtr self, [In] long Module, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [Out] out int TypeId);
        private delegate HRESULT GetTypeSizeDelegate(IntPtr self, [In] long Module, [In] int TypeId, [Out] out int Size);
        private delegate HRESULT GetFieldOffsetDelegate(IntPtr self, [In] long Module, [In] int TypeId, [In, MarshalAs(UnmanagedType.LPStr)] string Field, [Out] out int Offset);
        private delegate HRESULT GetSymbolTypeIdDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [Out] out int TypeId, [Out] out long Module);
        private delegate HRESULT GetOffsetTypeIdDelegate(IntPtr self, [In] long Offset, [Out] out int TypeId, [Out] out long Module);
        private delegate HRESULT ReadTypedDataVirtualDelegate(IntPtr self, [In] long Offset, [In] long Module, [In] int TypeId, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out int BytesRead);
        private delegate HRESULT WriteTypedDataVirtualDelegate(IntPtr self, [In] long Offset, [In] long Module, [In] int TypeId, [In] IntPtr Buffer, [In] int BufferSize, [Out] out int BytesWritten);
        private delegate HRESULT OutputTypedDataVirtualDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] long Offset, [In] long Module, [In] int TypeId, [In] DEBUG_OUTTYPE Flags);
        private delegate HRESULT ReadTypedDataPhysicalDelegate(IntPtr self, [In] long Offset, [In] long Module, [In] int TypeId, [In] IntPtr Buffer, [In] int BufferSize, [Out] out int BytesRead);
        private delegate HRESULT WriteTypedDataPhysicalDelegate(IntPtr self, [In] long Offset, [In] long Module, [In] int TypeId, [In] IntPtr Buffer, [In] int BufferSize, [Out] out int BytesWritten);
        private delegate HRESULT OutputTypedDataPhysicalDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] long Offset, [In] long Module, [In] int TypeId, [In] DEBUG_OUTTYPE Flags);
        private delegate HRESULT GetScopeDelegate(IntPtr self, [Out] out long InstructionOffset, [Out] out DEBUG_STACK_FRAME ScopeFrame, [In] IntPtr ScopeContext, [In] int ScopeContextSize);
        private delegate HRESULT SetScopeDelegate(IntPtr self, [In] long InstructionOffset, [In] ref DEBUG_STACK_FRAME ScopeFrame, [In] IntPtr ScopeContext, [In] int ScopeContextSize);
        private delegate HRESULT ResetScopeDelegate(IntPtr self);
        private delegate HRESULT GetScopeSymbolGroupDelegate(IntPtr self, [In] DEBUG_SCOPE_GROUP Flags, [In, ComAliasName("IDebugSymbolGroup")] IntPtr Update, [Out, ComAliasName("IDebugSymbolGroup")] out IntPtr Symbols);
        private delegate HRESULT CreateSymbolGroupDelegate(IntPtr self, [Out, ComAliasName("IDebugSymbolGroup")] out IntPtr Group);
        private delegate HRESULT StartSymbolMatchDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Pattern, [Out] out long Handle);
        private delegate HRESULT GetNextSymbolMatchDelegate(IntPtr self, [In] long Handle, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer, [In] int BufferSize, [Out] out int MatchSize, [Out] out long Offset);
        private delegate HRESULT EndSymbolMatchDelegate(IntPtr self, [In] long Handle);
        private delegate HRESULT ReloadDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Module);
        private delegate HRESULT AppendSymbolPathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Addition);
        private delegate HRESULT AppendImagePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Addition);
        private delegate HRESULT GetSourcePathElementDelegate(IntPtr self, [In] int Index, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer, [In] int BufferSize, [Out] out int ElementSize);
        private delegate HRESULT AppendSourcePathDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Addition);
        private delegate HRESULT FindSourceFileDelegate(IntPtr self, [In] int StartElement, [In, MarshalAs(UnmanagedType.LPStr)] string File, [In] DEBUG_FIND_SOURCE Flags, [Out] out int FoundElement, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] char[] Buffer, [In] int BufferSize, [Out] out int FoundSize);
        private delegate HRESULT GetSourceFileLineOffsetsDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string File, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] Buffer, [In] int BufferLines, [Out] out int FileLines);

        #endregion
        #region IDebugSymbols2

        private delegate HRESULT GetTypeOptionsDelegate(IntPtr self, [Out] out DEBUG_TYPEOPTS Options);
        private delegate HRESULT SetTypeOptionsDelegate(IntPtr self, [In] DEBUG_TYPEOPTS Options);
        private delegate HRESULT GetModuleVersionInformationDelegate(IntPtr self, [In] int Index, [In] long Base, [In, MarshalAs(UnmanagedType.LPStr)] string Item, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out int VerInfoSize);
        private delegate HRESULT GetModuleNameStringDelegate(IntPtr self, [In] DEBUG_MODNAME Which, [In] int Index, [In] long Base, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize);
        private delegate HRESULT GetConstantNameDelegate(IntPtr self, [In] long Module, [In] int TypeId, [In] long Value, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize);
        private delegate HRESULT GetFieldNameDelegate(IntPtr self, [In] long Module, [In] int TypeId, [In] int FieldIndex, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize);
        private delegate HRESULT AddTypeOptionsDelegate(IntPtr self, [In] DEBUG_TYPEOPTS Options);
        private delegate HRESULT RemoveTypeOptionsDelegate(IntPtr self, [In] DEBUG_TYPEOPTS Options);

        #endregion
        #region IDebugSymbols3

        private delegate HRESULT GetSymbolPathWideDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PathSize);
        private delegate HRESULT SetSymbolPathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path);
        private delegate HRESULT GetImagePathWideDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PathSize);
        private delegate HRESULT SetImagePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path);
        private delegate HRESULT GetSourcePathWideDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PathSize);
        private delegate HRESULT SetSourcePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Path);
        private delegate HRESULT GetCurrentScopeFrameIndexDelegate(IntPtr self, [Out] out int Index);
        private delegate HRESULT GetNameByOffsetWideDelegate(IntPtr self, [In] long Offset, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize, [Out] out long Displacement);
        private delegate HRESULT GetOffsetByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [Out] out long Offset);
        private delegate HRESULT GetNearNameByOffsetWideDelegate(IntPtr self, [In] long Offset, [In] int Delta, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize, [Out] out long Displacement);
        private delegate HRESULT GetLineByOffsetWideDelegate(IntPtr self, [In] long Offset, [Out] out int Line, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] FileBuffer, [In] int FileBufferSize, [Out] out int FileSize, [Out] out long Displacement);
        private delegate HRESULT GetOffsetByLineWideDelegate(IntPtr self, [In] int Line, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [Out] out long Offset);
        private delegate HRESULT GetModuleByModuleNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [In] int StartIndex, [Out] out int Index, [Out] out long Base);
        private delegate HRESULT GetSymbolModuleWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [Out] out long Base);
        private delegate HRESULT GetTypeNameWideDelegate(IntPtr self, [In] long Module, [In] int TypeId, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize);
        private delegate HRESULT GetTypeIdWideDelegate(IntPtr self, [In] long Module, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [Out] out int TypeId);
        private delegate HRESULT GetFieldOffsetWideDelegate(IntPtr self, [In] long Module, [In] int TypeId, [In, MarshalAs(UnmanagedType.LPWStr)] string Field, [Out] out int Offset);
        private delegate HRESULT GetSymbolTypeIdWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [Out] out int TypeId, [Out] out long Module);
        private delegate HRESULT GetScopeSymbolGroup2Delegate(IntPtr self, [In] DEBUG_SCOPE_GROUP Flags, [In, ComAliasName("IDebugSymbolGroup2")] IntPtr Update, [Out, ComAliasName("IDebugSymbolGroup2")] out IntPtr Symbols);
        private delegate HRESULT CreateSymbolGroup2Delegate(IntPtr self, [Out, ComAliasName("IDebugSymbolGroup2")] out IntPtr Group);
        private delegate HRESULT StartSymbolMatchWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Pattern, [Out] out long Handle);
        private delegate HRESULT GetNextSymbolMatchWideDelegate(IntPtr self, [In] long Handle, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer, [In] int BufferSize, [Out] out int MatchSize, [Out] out long Offset);
        private delegate HRESULT ReloadWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Module);
        private delegate HRESULT AppendSymbolPathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);
        private delegate HRESULT AppendImagePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);
        private delegate HRESULT GetSourcePathElementWideDelegate(IntPtr self, [In] int Index, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer, [In] int BufferSize, [Out] out int ElementSize);
        private delegate HRESULT AppendSourcePathWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);
        private delegate HRESULT FindSourceFileWideDelegate(IntPtr self, [In] int StartElement, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [In] DEBUG_FIND_SOURCE Flags, [Out] out int FoundElement, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 5)] char[] Buffer, [In] int BufferSize, [Out] out int FoundSize);
        private delegate HRESULT GetSourceFileLineOffsetsWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] Buffer, [In] int BufferLines, [Out] out int FileLines);
        private delegate HRESULT GetModuleVersionInformationWideDelegate(IntPtr self, [In] int Index, [In] long Base, [In, MarshalAs(UnmanagedType.LPWStr)] string Item, [In] IntPtr Buffer, [In] int BufferSize, [Out] out int VerInfoSize);
        private delegate HRESULT GetModuleNameStringWideDelegate(IntPtr self, [In] DEBUG_MODNAME Which, [In] int Index, [In] long Base, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize);
        private delegate HRESULT GetConstantNameWideDelegate(IntPtr self, [In] long Module, [In] int TypeId, [In] long Value, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize);
        private delegate HRESULT GetFieldNameWideDelegate(IntPtr self, [In] long Module, [In] int TypeId, [In] int FieldIndex, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize);
        private delegate HRESULT IsManagedModuleDelegate(IntPtr self, [In] int Index, [In] long Base);
        private delegate HRESULT GetModuleByModuleName2Delegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [In] int StartIndex, [In] DEBUG_GETMOD Flags, [Out] out int Index, [Out] out long Base);
        private delegate HRESULT GetModuleByModuleName2WideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [In] int StartIndex, [In] DEBUG_GETMOD Flags, [Out] out int Index, [Out] out long Base);
        private delegate HRESULT GetModuleByOffset2Delegate(IntPtr self, [In] long Offset, [In] int StartIndex, [In] DEBUG_GETMOD Flags, [Out] out int Index, [Out] out long Base);
        private delegate HRESULT AddSyntheticModuleDelegate(IntPtr self, [In] long Base, [In] int Size, [In, MarshalAs(UnmanagedType.LPStr)] string ImagePath, [In, MarshalAs(UnmanagedType.LPStr)] string ModuleName, [In] DEBUG_ADDSYNTHMOD Flags);
        private delegate HRESULT AddSyntheticModuleWideDelegate(IntPtr self, [In] long Base, [In] int Size, [In, MarshalAs(UnmanagedType.LPWStr)] string ImagePath, [In, MarshalAs(UnmanagedType.LPWStr)] string ModuleName, [In] DEBUG_ADDSYNTHMOD Flags);
        private delegate HRESULT RemoveSyntheticModuleDelegate(IntPtr self, [In] long Base);
        private delegate HRESULT SetScopeFrameByIndexDelegate(IntPtr self, [In] int Index);
        private delegate HRESULT SetScopeFromJitDebugInfoDelegate(IntPtr self, [In] int OutputControl, [In] long InfoOffset);
        private delegate HRESULT SetScopeFromStoredEventDelegate(IntPtr self);
        private delegate HRESULT OutputSymbolByOffsetDelegate(IntPtr self, [In] int OutputControl, [In] DEBUG_OUTSYM Flags, [In] long Offset);
        private delegate HRESULT GetFunctionEntryByOffsetDelegate(IntPtr self, [In] long Offset, [In] DEBUG_GETFNENT Flags, [In] IntPtr Buffer, [In] int BufferSize, [Out] out int BufferNeeded);
        private delegate HRESULT GetFieldTypeAndOffsetDelegate(IntPtr self, [In] long Module, [In] int ContainerTypeId, [In, MarshalAs(UnmanagedType.LPStr)] string Field, [Out] out int FieldTypeId, [Out] out int Offset);
        private delegate HRESULT GetFieldTypeAndOffsetWideDelegate(IntPtr self, [In] long Module, [In] int ContainerTypeId, [In, MarshalAs(UnmanagedType.LPWStr)] string Field, [Out] out int FieldTypeId, [Out] out int Offset);
        private delegate HRESULT AddSyntheticSymbolDelegate(IntPtr self, [In] long Offset, [In] int Size, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [In] DEBUG_ADDSYNTHSYM Flags, [Out] out DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT AddSyntheticSymbolWideDelegate(IntPtr self, [In] long Offset, [In] int Size, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [In] DEBUG_ADDSYNTHSYM Flags, [Out] out DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT RemoveSyntheticSymbolDelegate(IntPtr self, [In] ref DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT GetSymbolEntriesByOffsetDelegate(IntPtr self, [In] long Offset, [In] int Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_MODULE_AND_ID[] Ids, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] long[] Displacements, [In] int IdsCount, [Out] out int Entries);
        private delegate HRESULT GetSymbolEntriesByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Symbol, [In] int Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_MODULE_AND_ID[] Ids, [In] int IdsCount, [Out] out int Entries);
        private delegate HRESULT GetSymbolEntriesByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol, [In] int Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_MODULE_AND_ID[] Ids, [In] int IdsCount, [Out] out int Entries);
        private delegate HRESULT GetSymbolEntryByTokenDelegate(IntPtr self, [In] long ModuleBase, [In] mdToken Token, [Out] out DEBUG_MODULE_AND_ID Id);
        private delegate HRESULT GetSymbolEntryInformationDelegate(IntPtr self, [In] ref DEBUG_MODULE_AND_ID Id, [Out] out DEBUG_SYMBOL_ENTRY Info);
        private delegate HRESULT GetSymbolEntryStringDelegate(IntPtr self, [In] ref DEBUG_MODULE_AND_ID Id, [In] int Which, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] Buffer, [In] int BufferSize, [Out] out int StringSize);
        private delegate HRESULT GetSymbolEntryStringWideDelegate(IntPtr self, [In] ref DEBUG_MODULE_AND_ID Id, [In] int Which, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer, [In] int BufferSize, [Out] out int StringSize);
        private delegate HRESULT GetSymbolEntryOffsetRegionsDelegate(IntPtr self, [In] ref DEBUG_MODULE_AND_ID Id, [In] int Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_OFFSET_REGION[] Regions, [In] int RegionsCount, [Out] out int RegionsAvail);
        private delegate HRESULT GetSymbolEntryBySymbolEntryDelegate(IntPtr self, [In] ref DEBUG_MODULE_AND_ID FromId, [In] int Flags, [Out] out DEBUG_MODULE_AND_ID ToId);
        private delegate HRESULT GetSourceEntriesByOffsetDelegate(IntPtr self, [In] long Offset, [In] int Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries, [In] int EntriesCount, [Out] out int EntriesAvail);
        private delegate HRESULT GetSourceEntriesByLineDelegate(IntPtr self, [In] int Line, [In, MarshalAs(UnmanagedType.LPStr)] string File, [In] DEBUG_GSEL Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries, [In] int EntriesCount, [Out] out int EntriesAvail);
        private delegate HRESULT GetSourceEntriesByLineWideDelegate(IntPtr self, [In] int Line, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [In] DEBUG_GSEL Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries, [In] int EntriesCount, [Out] out int EntriesAvail);
        private delegate HRESULT GetSourceEntryStringDelegate(IntPtr self, [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry, [In] int Which, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] Buffer, [In] int BufferSize, [Out] out int StringSize);
        private delegate HRESULT GetSourceEntryStringWideDelegate(IntPtr self, [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry, [In] int Which, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer, [In] int BufferSize, [Out] out int StringSize);
        private delegate HRESULT GetSourceEntryOffsetRegionsDelegate(IntPtr self, [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry, [In] int Flags, [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_OFFSET_REGION[] Regions, [In] int RegionsCount, [Out] out int RegionsAvail);
        private delegate HRESULT GetSourceEntryBySourceEntryDelegate(IntPtr self, [In] ref DEBUG_SYMBOL_SOURCE_ENTRY FromEntry, [In] int Flags, [Out] out DEBUG_SYMBOL_SOURCE_ENTRY ToEntry);

        #endregion
        #region IDebugSymbols4

        private delegate HRESULT GetScopeExDelegate(IntPtr self, [Out] out long InstructionOffset, [Out] out DEBUG_STACK_FRAME_EX ScopeFrame, [In] IntPtr ScopeContext, [In] int ScopeContextSize);
        private delegate HRESULT SetScopeExDelegate(IntPtr self, [In] long InstructionOffset, [In] ref DEBUG_STACK_FRAME_EX ScopeFrame, [In] IntPtr ScopeContext, [In] int ScopeContextSize);
        private delegate HRESULT GetNameByInlineContextDelegate(IntPtr self, [In] long Offset, [In] int InlineContext, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize, [Out] out long Displacement);
        private delegate HRESULT GetNameByInlineContextWideDelegate(IntPtr self, [In] long Offset, [In] int InlineContext, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer, [In] int NameBufferSize, [Out] out int NameSize, [Out] out long Displacement);
        private delegate HRESULT GetLineByInlineContextDelegate(IntPtr self, [In] long Offset, [In] int InlineContext, [Out] out int Line, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] FileBuffer, [In] int FileBufferSize, [Out] out int FileSize, [Out] out long Displacement);
        private delegate HRESULT GetLineByInlineContextWideDelegate(IntPtr self, [In] long Offset, [In] int InlineContext, [Out] out int Line, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] FileBuffer, [In] int FileBufferSize, [Out] out int FileSize, [Out] out long Displacement);
        private delegate HRESULT OutputSymbolByInlineContextDelegate(IntPtr self, [In] int OutputControl, [In] int Flags, [In] long Offset, [In] int InlineContext);

        #endregion
        #region IDebugSymbols5

        private delegate HRESULT GetCurrentScopeFrameIndexExDelegate(IntPtr self, [In] DEBUG_FRAME Flags, [Out] out int Index);
        private delegate HRESULT SetScopeFrameByIndexExDelegate(IntPtr self, [In] DEBUG_FRAME Flags, [In] int Index);

        #endregion
        #endregion

        protected override void ReleaseSubInterfaces()
        {
            ReleaseInterface(ref raw2);
            ReleaseInterface(ref raw3);
            ReleaseInterface(ref raw4);
            ReleaseInterface(ref raw5);
        }
    }
}

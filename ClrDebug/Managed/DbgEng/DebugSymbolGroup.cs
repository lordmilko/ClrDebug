using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugSymbolGroup : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugSymbolGroup = new Guid("f2528316-0f1a-4431-aeed-11d096e1e2ab");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugSymbolGroupVtbl* Vtbl => (IDebugSymbolGroupVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugSymbolGroup2Vtbl* Vtbl2 => (IDebugSymbolGroup2Vtbl*) base.Vtbl;

        #endregion
        
        public DebugSymbolGroup(IntPtr raw) : base(raw, IID_IDebugSymbolGroup)
        {
        }

        public DebugSymbolGroup(IDebugSymbolGroup raw) : base(raw)
        {
        }

        #region IDebugSymbolGroup
        #region NumberSymbols

        /// <summary>
        /// The GetNumberSymbols method returns the number of symbols that are contained in a symbol group.
        /// </summary>
        public uint NumberSymbols
        {
            get
            {
                uint number;
                TryGetNumberSymbols(out number).ThrowDbgEngNotOk();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberSymbols method returns the number of symbols that are contained in a symbol group.
        /// </summary>
        /// <param name="number">[out] The number of symbols that are contained in this symbol group.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// Each symbol in a symbol group is identified by an index. This index is a number between zero and the number that
        /// is returned to Number minus one. Every time that a symbol is added or removed from the symbol group, the index
        /// of all of the symbols in the group might change. For more information about symbol groups, see Scopes and Symbol
        /// Groups.
        /// </remarks>
        public HRESULT TryGetNumberSymbols(out uint number)
        {
            InitDelegate(ref getNumberSymbols, Vtbl->GetNumberSymbols);

            /*HRESULT GetNumberSymbols(
            [Out] out uint Number);*/
            return getNumberSymbols(Raw, out number);
        }

        #endregion
        #region AddSymbol

        /// <summary>
        /// The AddSymbol method adds a symbol to a symbol group.
        /// </summary>
        /// <param name="name">[in] The symbol's name. Name is examined as an expression to determine the symbol's type. This expression can include pointer, array, and structure dereferencing (for example, *my_pointer, my_array[1], or my_struct.some_field).</param>
        /// <param name="index">[in, out] The index of the entry in the symbol group. When you are calling AddSymbol or <see cref="AddSymbolWide"/>, Index should point to the index of the symbol that you want.<para/>
        /// Or, if Index points to DEBUG_ANY_ID, the symbol is appended to the end of the list. When this method returns, Index points to the actual index of the symbol.<para/>
        /// The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <remarks>
        /// The symbol name in Name is evaluated by the C++ expression evaluator and can contain any C++ expression (for example,
        /// x+y). If the index that you want is less than the size of the symbol group, the new symbol is added at the desired
        /// index. If the desired index is larger than the size of the symbol group, the new symbol is added to the end of
        /// the list (as in the case of DEBUG_ANY_ID). For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void AddSymbol(string name, ref uint index)
        {
            TryAddSymbol(name, ref index).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AddSymbol method adds a symbol to a symbol group.
        /// </summary>
        /// <param name="name">[in] The symbol's name. Name is examined as an expression to determine the symbol's type. This expression can include pointer, array, and structure dereferencing (for example, *my_pointer, my_array[1], or my_struct.some_field).</param>
        /// <param name="index">[in, out] The index of the entry in the symbol group. When you are calling AddSymbol or <see cref="AddSymbolWide"/>, Index should point to the index of the symbol that you want.<para/>
        /// Or, if Index points to DEBUG_ANY_ID, the symbol is appended to the end of the list. When this method returns, Index points to the actual index of the symbol.<para/>
        /// The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The symbol name in Name is evaluated by the C++ expression evaluator and can contain any C++ expression (for example,
        /// x+y). If the index that you want is less than the size of the symbol group, the new symbol is added at the desired
        /// index. If the desired index is larger than the size of the symbol group, the new symbol is added to the end of
        /// the list (as in the case of DEBUG_ANY_ID). For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryAddSymbol(string name, ref uint index)
        {
            InitDelegate(ref addSymbol, Vtbl->AddSymbol);

            /*HRESULT AddSymbol(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In, Out] ref uint Index);*/
            return addSymbol(Raw, name, ref index);
        }

        #endregion
        #region RemoveSymbolByName

        /// <summary>
        /// The RemoveSymbolByName method removes the specified symbol from a symbol group.
        /// </summary>
        /// <param name="name">[in] The name of the symbol to remove from the symbol group.</param>
        /// <remarks>
        /// When a symbol is removed, the indexes of the symbols that remain in the symbol group might change. For more information
        /// about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void RemoveSymbolByName(string name)
        {
            TryRemoveSymbolByName(name).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The RemoveSymbolByName method removes the specified symbol from a symbol group.
        /// </summary>
        /// <param name="name">[in] The name of the symbol to remove from the symbol group.</param>
        /// <returns>RemoveSymbolByName might return one of the following values: This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// When a symbol is removed, the indexes of the symbols that remain in the symbol group might change. For more information
        /// about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryRemoveSymbolByName(string name)
        {
            InitDelegate(ref removeSymbolByName, Vtbl->RemoveSymbolByName);

            /*HRESULT RemoveSymbolByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name);*/
            return removeSymbolByName(Raw, name);
        }

        #endregion
        #region RemoveSymbolsByIndex

        public void RemoveSymbolsByIndex(uint index)
        {
            TryRemoveSymbolsByIndex(index).ThrowDbgEngNotOk();
        }

        public HRESULT TryRemoveSymbolsByIndex(uint index)
        {
            InitDelegate(ref removeSymbolsByIndex, Vtbl->RemoveSymbolsByIndex);

            /*HRESULT RemoveSymbolsByIndex(
            [In] uint Index);*/
            return removeSymbolsByIndex(Raw, index);
        }

        #endregion
        #region GetSymbolName

        /// <summary>
        /// The GetSymbolName method returns the name of a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out, optional] The symbol name. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public string GetSymbolName(uint index)
        {
            string bufferResult;
            TryGetSymbolName(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolName method returns the name of a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="bufferResult">[out, optional] The symbol name. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolName(uint index, out string bufferResult)
        {
            InitDelegate(ref getSymbolName, Vtbl->GetSymbolName);
            /*HRESULT GetSymbolName(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getSymbolName(Raw, index, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolName(Raw, index, buffer, bufferSize, out nameSize);

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
        #region GetSymbolParameters

        /// <summary>
        /// The GetSymbolParameters method returns the symbol parameters that describe the specified symbols in a symbol group.
        /// </summary>
        /// <param name="start">[in] The index in the symbol group of the first symbol whose parameters you want. The index of a symbol is an identification number.<para/>
        /// This number ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="count">[in] The number of symbol parameters that you want.</param>
        /// <returns>[out] The symbol parameters. This array must hold at least Count elements. For a description of these parameters, see <see cref="DEBUG_SYMBOL_PARAMETERS"/>.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public DEBUG_SYMBOL_PARAMETERS[] GetSymbolParameters(uint start, uint count)
        {
            DEBUG_SYMBOL_PARAMETERS[] @params;
            TryGetSymbolParameters(start, count, out @params).ThrowDbgEngNotOk();

            return @params;
        }

        /// <summary>
        /// The GetSymbolParameters method returns the symbol parameters that describe the specified symbols in a symbol group.
        /// </summary>
        /// <param name="start">[in] The index in the symbol group of the first symbol whose parameters you want. The index of a symbol is an identification number.<para/>
        /// This number ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="count">[in] The number of symbol parameters that you want.</param>
        /// <param name="params">[out] The symbol parameters. This array must hold at least Count elements. For a description of these parameters, see <see cref="DEBUG_SYMBOL_PARAMETERS"/>.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolParameters(uint start, uint count, out DEBUG_SYMBOL_PARAMETERS[] @params)
        {
            InitDelegate(ref getSymbolParameters, Vtbl->GetSymbolParameters);
            /*HRESULT GetSymbolParameters(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            DEBUG_SYMBOL_PARAMETERS[] Params);*/
            @params = null;
            HRESULT hr = getSymbolParameters(Raw, start, count, @params);

            return hr;
        }

        #endregion
        #region ExpandSymbol

        /// <summary>
        /// The ExpandSymbol method adds or removes the children of a symbol from a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose children will be added or removed. The index of a symbol is an identification number.<para/>
        /// The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="expand">[in] A Boolean value that specifies whether to add or remove the symbols children from the symbol group. If Expand is true, the children are added.<para/>
        /// If Expand is false, the children are removed.</param>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void ExpandSymbol(uint index, bool expand)
        {
            TryExpandSymbol(index, expand).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The ExpandSymbol method adds or removes the children of a symbol from a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose children will be added or removed. The index of a symbol is an identification number.<para/>
        /// The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="expand">[in] A Boolean value that specifies whether to add or remove the symbols children from the symbol group. If Expand is true, the children are added.<para/>
        /// If Expand is false, the children are removed.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryExpandSymbol(uint index, bool expand)
        {
            InitDelegate(ref expandSymbol, Vtbl->ExpandSymbol);

            /*HRESULT ExpandSymbol(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.Bool)] bool Expand);*/
            return expandSymbol(Raw, index, expand);
        }

        #endregion
        #region OutputSymbols

        /// <summary>
        /// The OutputSymbols method prints the specified symbols to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] The output control to use when printing the symbols' information. For more information about possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="flags">[in] The flags that determine what information is printed for each symbol. By default, the output includes the symbol's name, offset, value, and type.<para/>
        /// The format for the output is as follows: NameNAMEOffsetOFFValueVALUETypeTYPE You can use the following bit flags to suppress the output of one of these pieces of information together with the corresponding marker.</param>
        /// <param name="start">[in] The index of the first symbol in the symbol group to print. The index of a symbol is an identification number.<para/>
        /// This number ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="count">[in] The number of symbols to print.</param>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void OutputSymbols(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT_SYMBOLS flags, uint start, uint count)
        {
            TryOutputSymbols(outputControl, flags, start, count).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputSymbols method prints the specified symbols to the debugger console.
        /// </summary>
        /// <param name="outputControl">[in] The output control to use when printing the symbols' information. For more information about possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="flags">[in] The flags that determine what information is printed for each symbol. By default, the output includes the symbol's name, offset, value, and type.<para/>
        /// The format for the output is as follows: NameNAMEOffsetOFFValueVALUETypeTYPE You can use the following bit flags to suppress the output of one of these pieces of information together with the corresponding marker.</param>
        /// <param name="start">[in] The index of the first symbol in the symbol group to print. The index of a symbol is an identification number.<para/>
        /// This number ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="count">[in] The number of symbols to print.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryOutputSymbols(DEBUG_OUTCTL outputControl, DEBUG_OUTPUT_SYMBOLS flags, uint start, uint count)
        {
            InitDelegate(ref outputSymbols, Vtbl->OutputSymbols);

            /*HRESULT OutputSymbols(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT_SYMBOLS Flags,
            [In] uint Start,
            [In] uint Count);*/
            return outputSymbols(Raw, outputControl, flags, start, count);
        }

        #endregion
        #region WriteSymbol

        /// <summary>
        /// The WriteSymbol methods set the value of the specified symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value will be changed. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="value">[in] A C++ expression that is evaluated to give the symbol's new value.</param>
        /// <remarks>
        /// The WriteSymbol method can change symbols only if the symbols are stored in a register or memory location that
        /// the debugger engine knowns and if they have not had their type changed to an extension by using the <see cref="OutputAsType"/>
        /// method. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void WriteSymbol(uint index, string value)
        {
            TryWriteSymbol(index, value).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The WriteSymbol methods set the value of the specified symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value will be changed. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="value">[in] A C++ expression that is evaluated to give the symbol's new value.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The WriteSymbol method can change symbols only if the symbols are stored in a register or memory location that
        /// the debugger engine knowns and if they have not had their type changed to an extension by using the <see cref="OutputAsType"/>
        /// method. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryWriteSymbol(uint index, string value)
        {
            InitDelegate(ref writeSymbol, Vtbl->WriteSymbol);

            /*HRESULT WriteSymbol(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Value);*/
            return writeSymbol(Raw, index, value);
        }

        #endregion
        #region OutputAsType

        /// <summary>
        /// The OutputAsType method changes the type of a symbol in a symbol group. The symbol's entry is updated to represent the new type.
        /// </summary>
        /// <param name="index">[in] The index of the entry in this symbol group. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="type">[in] The name of the type of the symbol that you want. If the name begins with an exclamation mark (!), the name is treated as an extension.<para/>
        /// For more information about how to use an extension as a type, see the Remarks section.</param>
        /// <remarks>
        /// Because the children of the new entry type might differ from the children of the old entry type, the OutputAsType
        /// method removes all of the children of the entry from the symbol group. You can add the children back by using the
        /// <see cref="ExpandSymbol"/> method. If Type is an extension, the address of the symbol is passed to the extension.
        /// Every line of output from the extension becomes a child symbol of the specified symbol. These child symbols are
        /// text and you cannot manipulate them in any way. For example, if the name of a variable is @$teb, you can change
        /// its type to !teb. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void OutputAsType(uint index, string type)
        {
            TryOutputAsType(index, type).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputAsType method changes the type of a symbol in a symbol group. The symbol's entry is updated to represent the new type.
        /// </summary>
        /// <param name="index">[in] The index of the entry in this symbol group. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="type">[in] The name of the type of the symbol that you want. If the name begins with an exclamation mark (!), the name is treated as an extension.<para/>
        /// For more information about how to use an extension as a type, see the Remarks section.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// Because the children of the new entry type might differ from the children of the old entry type, the OutputAsType
        /// method removes all of the children of the entry from the symbol group. You can add the children back by using the
        /// <see cref="ExpandSymbol"/> method. If Type is an extension, the address of the symbol is passed to the extension.
        /// Every line of output from the extension becomes a child symbol of the specified symbol. These child symbols are
        /// text and you cannot manipulate them in any way. For example, if the name of a variable is @$teb, you can change
        /// its type to !teb. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryOutputAsType(uint index, string type)
        {
            InitDelegate(ref outputAsType, Vtbl->OutputAsType);

            /*HRESULT OutputAsType(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Type);*/
            return outputAsType(Raw, index, type);
        }

        #endregion
        #endregion
        #region IDebugSymbolGroup2
        #region AddSymbolWide

        /// <summary>
        /// The AddSymbolWide method adds a symbol to a symbol group.
        /// </summary>
        /// <param name="name">[in] The symbol's name. Name is examined as an expression to determine the symbol's type. This expression can include pointer, array, and structure dereferencing (for example, *my_pointer, my_array[1], or my_struct.some_field).</param>
        /// <param name="index">[in, out] The index of the entry in the symbol group. When you are calling <see cref="AddSymbol"/> or AddSymbolWide, Index should point to the index of the symbol that you want.<para/>
        /// Or, if Index points to DEBUG_ANY_ID, the symbol is appended to the end of the list. When this method returns, Index points to the actual index of the symbol.<para/>
        /// The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <remarks>
        /// The symbol name in Name is evaluated by the C++ expression evaluator and can contain any C++ expression (for example,
        /// x+y). If the index that you want is less than the size of the symbol group, the new symbol is added at the desired
        /// index. If the desired index is larger than the size of the symbol group, the new symbol is added to the end of
        /// the list (as in the case of DEBUG_ANY_ID). For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void AddSymbolWide(string name, ref uint index)
        {
            TryAddSymbolWide(name, ref index).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The AddSymbolWide method adds a symbol to a symbol group.
        /// </summary>
        /// <param name="name">[in] The symbol's name. Name is examined as an expression to determine the symbol's type. This expression can include pointer, array, and structure dereferencing (for example, *my_pointer, my_array[1], or my_struct.some_field).</param>
        /// <param name="index">[in, out] The index of the entry in the symbol group. When you are calling <see cref="AddSymbol"/> or AddSymbolWide, Index should point to the index of the symbol that you want.<para/>
        /// Or, if Index points to DEBUG_ANY_ID, the symbol is appended to the end of the list. When this method returns, Index points to the actual index of the symbol.<para/>
        /// The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The symbol name in Name is evaluated by the C++ expression evaluator and can contain any C++ expression (for example,
        /// x+y). If the index that you want is less than the size of the symbol group, the new symbol is added at the desired
        /// index. If the desired index is larger than the size of the symbol group, the new symbol is added to the end of
        /// the list (as in the case of DEBUG_ANY_ID). For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryAddSymbolWide(string name, ref uint index)
        {
            InitDelegate(ref addSymbolWide, Vtbl2->AddSymbolWide);

            /*HRESULT AddSymbolWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In, Out] ref uint Index);*/
            return addSymbolWide(Raw, name, ref index);
        }

        #endregion
        #region RemoveSymbolByNameWide

        /// <summary>
        /// The RemoveSymbolByNameWide method removes the specified symbol from a symbol group.
        /// </summary>
        /// <param name="name">[in] The name of the symbol to remove from the symbol group.</param>
        /// <remarks>
        /// When a symbol is removed, the indexes of the symbols that remain in the symbol group might change. For more information
        /// about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void RemoveSymbolByNameWide(string name)
        {
            TryRemoveSymbolByNameWide(name).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The RemoveSymbolByNameWide method removes the specified symbol from a symbol group.
        /// </summary>
        /// <param name="name">[in] The name of the symbol to remove from the symbol group.</param>
        /// <returns>RemoveSymbolByNameWide might return one of the following values: This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// When a symbol is removed, the indexes of the symbols that remain in the symbol group might change. For more information
        /// about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryRemoveSymbolByNameWide(string name)
        {
            InitDelegate(ref removeSymbolByNameWide, Vtbl2->RemoveSymbolByNameWide);

            /*HRESULT RemoveSymbolByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name);*/
            return removeSymbolByNameWide(Raw, name);
        }

        #endregion
        #region GetSymbolNameWide

        /// <summary>
        /// The GetSymbolNameWide method returns the name of a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out, optional] The symbol name. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public string GetSymbolNameWide(uint index)
        {
            string bufferResult;
            TryGetSymbolNameWide(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolNameWide method returns the name of a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="bufferResult">[out, optional] The symbol name. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolNameWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getSymbolNameWide, Vtbl2->GetSymbolNameWide);
            /*HRESULT GetSymbolNameWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getSymbolNameWide(Raw, index, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolNameWide(Raw, index, buffer, bufferSize, out nameSize);

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
        #region WriteSymbolWide

        /// <summary>
        /// The WriteSymbolWide method sets the value of the specified symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value will be changed. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="value">[in] A C++ expression that is evaluated to give the symbol's new value.</param>
        /// <remarks>
        /// This method can change symbols only if the symbols are stored in a register or memory location that the debugger
        /// engine knowns and if they have not had their type changed to an extension by using the <see cref="OutputAsType"/>
        /// method. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void WriteSymbolWide(uint index, string value)
        {
            TryWriteSymbolWide(index, value).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The WriteSymbolWide method sets the value of the specified symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value will be changed. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="value">[in] A C++ expression that is evaluated to give the symbol's new value.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// This method can change symbols only if the symbols are stored in a register or memory location that the debugger
        /// engine knowns and if they have not had their type changed to an extension by using the <see cref="OutputAsType"/>
        /// method. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryWriteSymbolWide(uint index, string value)
        {
            InitDelegate(ref writeSymbolWide, Vtbl2->WriteSymbolWide);

            /*HRESULT WriteSymbolWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Value);*/
            return writeSymbolWide(Raw, index, value);
        }

        #endregion
        #region OutputAsTypeWide

        /// <summary>
        /// The OutputAsTypeWide method changes the type of a symbol in a symbol group. The symbol's entry is updated to represent the new type.
        /// </summary>
        /// <param name="index">[in] The index of the entry in this symbol group. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="type">[in] The name of the type of the symbol that you want. If the name begins with an exclamation mark (!), the name is treated as an extension.<para/>
        /// For more information about how to use an extension as a type, see the Remarks section.</param>
        /// <remarks>
        /// Because the children of the new entry type might differ from the children of the old entry type, the OutputAsTypeWide
        /// method removes all of the children of the entry from the symbol group. You can add the children back by using the
        /// <see cref="ExpandSymbol"/> method. If Type is an extension, the address of the symbol is passed to the extension.
        /// Every line of output from the extension becomes a child symbol of the specified symbol. These child symbols are
        /// text and you cannot manipulate them in any way. For example, if the name of a variable is @$teb, you can change
        /// its type to !teb. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public void OutputAsTypeWide(uint index, string type)
        {
            TryOutputAsTypeWide(index, type).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The OutputAsTypeWide method changes the type of a symbol in a symbol group. The symbol's entry is updated to represent the new type.
        /// </summary>
        /// <param name="index">[in] The index of the entry in this symbol group. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="type">[in] The name of the type of the symbol that you want. If the name begins with an exclamation mark (!), the name is treated as an extension.<para/>
        /// For more information about how to use an extension as a type, see the Remarks section.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// Because the children of the new entry type might differ from the children of the old entry type, the OutputAsTypeWide
        /// method removes all of the children of the entry from the symbol group. You can add the children back by using the
        /// <see cref="ExpandSymbol"/> method. If Type is an extension, the address of the symbol is passed to the extension.
        /// Every line of output from the extension becomes a child symbol of the specified symbol. These child symbols are
        /// text and you cannot manipulate them in any way. For example, if the name of a variable is @$teb, you can change
        /// its type to !teb. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryOutputAsTypeWide(uint index, string type)
        {
            InitDelegate(ref outputAsTypeWide, Vtbl2->OutputAsTypeWide);

            /*HRESULT OutputAsTypeWide(
            [In] uint Index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Type);*/
            return outputAsTypeWide(Raw, index, type);
        }

        #endregion
        #region GetSymbolTypeName

        /// <summary>
        /// The GetSymbolTypeName methods return the name of the specified symbol's type.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose type name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out, optional] The name of the symbol's type. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public string GetSymbolTypeName(uint index)
        {
            string bufferResult;
            TryGetSymbolTypeName(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolTypeName methods return the name of the specified symbol's type.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose type name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="bufferResult">[out, optional] The name of the symbol's type. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolTypeName(uint index, out string bufferResult)
        {
            InitDelegate(ref getSymbolTypeName, Vtbl2->GetSymbolTypeName);
            /*HRESULT GetSymbolTypeName(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getSymbolTypeName(Raw, index, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolTypeName(Raw, index, buffer, bufferSize, out nameSize);

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
        #region GetSymbolTypeNameWide

        /// <summary>
        /// The GetSymbolTypeNameWide method returns the name of the specified symbol's type.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose type name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out, optional] The name of the symbol's type. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public string GetSymbolTypeNameWide(uint index)
        {
            string bufferResult;
            TryGetSymbolTypeNameWide(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolTypeNameWide method returns the name of the specified symbol's type.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose type name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="bufferResult">[out, optional] The name of the symbol's type. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolTypeNameWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getSymbolTypeNameWide, Vtbl2->GetSymbolTypeNameWide);
            /*HRESULT GetSymbolTypeNameWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getSymbolTypeNameWide(Raw, index, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolTypeNameWide(Raw, index, buffer, bufferSize, out nameSize);

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
        #region GetSymbolSize

        /// <summary>
        /// The GetSymbolSize method returns the size of a symbol's value.
        /// </summary>
        /// <param name="index">[in] The index of the symbol to remove. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out] The size, in bytes, of the symbol's value. This information might not be available. If this information is not available, Size is set to zero.<para/>
        /// For some symbols (for example, a function's code), the data might be split over multiple regions. In this situation, Size is not meaningful.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public uint GetSymbolSize(uint index)
        {
            uint size;
            TryGetSymbolSize(index, out size).ThrowDbgEngNotOk();

            return size;
        }

        /// <summary>
        /// The GetSymbolSize method returns the size of a symbol's value.
        /// </summary>
        /// <param name="index">[in] The index of the symbol to remove. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="size">[out] The size, in bytes, of the symbol's value. This information might not be available. If this information is not available, Size is set to zero.<para/>
        /// For some symbols (for example, a function's code), the data might be split over multiple regions. In this situation, Size is not meaningful.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolSize(uint index, out uint size)
        {
            InitDelegate(ref getSymbolSize, Vtbl2->GetSymbolSize);

            /*HRESULT GetSymbolSize(
            [In] uint Index,
            [Out] out uint Size);*/
            return getSymbolSize(Raw, index, out size);
        }

        #endregion
        #region GetSymbolOffset

        /// <summary>
        /// The GetSymbolOffset method retrieves the location in the process's virtual address space of a symbol in a symbol group, if the symbol has an absolute address.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose address you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out] The location in the process's virtual address space of the symbol.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public ulong GetSymbolOffset(uint index)
        {
            ulong offset;
            TryGetSymbolOffset(index, out offset).ThrowDbgEngNotOk();

            return offset;
        }

        /// <summary>
        /// The GetSymbolOffset method retrieves the location in the process's virtual address space of a symbol in a symbol group, if the symbol has an absolute address.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose address you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="offset">[out] The location in the process's virtual address space of the symbol.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolOffset(uint index, out ulong offset)
        {
            InitDelegate(ref getSymbolOffset, Vtbl2->GetSymbolOffset);

            /*HRESULT GetSymbolOffset(
            [In] uint Index,
            [Out] out ulong Offset);*/
            return getSymbolOffset(Raw, index, out offset);
        }

        #endregion
        #region GetSymbolRegister

        /// <summary>
        /// The GetSymbolRegister method returns the register that contains the value or a pointer to the value of a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol to return the register for. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out] The index of the register that contains the value or a pointer to the value of the symbol.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups. For more information about registers and
        /// the register index, see Registers.
        /// </remarks>
        public uint GetSymbolRegister(uint index)
        {
            uint register;
            TryGetSymbolRegister(index, out register).ThrowDbgEngNotOk();

            return register;
        }

        /// <summary>
        /// The GetSymbolRegister method returns the register that contains the value or a pointer to the value of a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol to return the register for. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="register">[out] The index of the register that contains the value or a pointer to the value of the symbol.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups. For more information about registers and
        /// the register index, see Registers.
        /// </remarks>
        public HRESULT TryGetSymbolRegister(uint index, out uint register)
        {
            InitDelegate(ref getSymbolRegister, Vtbl2->GetSymbolRegister);

            /*HRESULT GetSymbolRegister(
            [In] uint Index,
            [Out] out uint Register);*/
            return getSymbolRegister(Raw, index, out register);
        }

        #endregion
        #region GetSymbolValueText

        /// <summary>
        /// The GetSymbolValueText method returns a string that represents the value of a symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out, optional] The value of the symbol as a string. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// If you added the symbol to the symbol group by using the <see cref="AddSymbol"/> method, the string that is returned
        /// to Buffer is the name of the symbol that is passed to AddSymbol. For more information about symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public string GetSymbolValueText(uint index)
        {
            string bufferResult;
            TryGetSymbolValueText(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolValueText method returns a string that represents the value of a symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="bufferResult">[out, optional] The value of the symbol as a string. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If you added the symbol to the symbol group by using the <see cref="AddSymbol"/> method, the string that is returned
        /// to Buffer is the name of the symbol that is passed to AddSymbol. For more information about symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolValueText(uint index, out string bufferResult)
        {
            InitDelegate(ref getSymbolValueText, Vtbl2->GetSymbolValueText);
            /*HRESULT GetSymbolValueText(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getSymbolValueText(Raw, index, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolValueText(Raw, index, buffer, bufferSize, out nameSize);

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
        #region GetSymbolValueTextWide

        /// <summary>
        /// The GetSymbolValueTextWide method returns a string that represents the value of a symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out, optional] The value of the symbol as a string. If Buffer is NULL, this information is not returned.</returns>
        /// <remarks>
        /// If you added the symbol to the symbol group by using the <see cref="AddSymbol"/> method, the string that is returned
        /// to Buffer is the name of the symbol that is passed to AddSymbol. For more information about symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public string GetSymbolValueTextWide(uint index)
        {
            string bufferResult;
            TryGetSymbolValueTextWide(index, out bufferResult).ThrowDbgEngNotOk();

            return bufferResult;
        }

        /// <summary>
        /// The GetSymbolValueTextWide method returns a string that represents the value of a symbol.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose value you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="bufferResult">[out, optional] The value of the symbol as a string. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If you added the symbol to the symbol group by using the <see cref="AddSymbol"/> method, the string that is returned
        /// to Buffer is the name of the symbol that is passed to AddSymbol. For more information about symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolValueTextWide(uint index, out string bufferResult)
        {
            InitDelegate(ref getSymbolValueTextWide, Vtbl2->GetSymbolValueTextWide);
            /*HRESULT GetSymbolValueTextWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);*/
            StringBuilder buffer = null;
            int bufferSize = 0;
            uint nameSize;
            HRESULT hr = getSymbolValueTextWide(Raw, index, buffer, bufferSize, out nameSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = (int) nameSize;
            buffer = new StringBuilder(bufferSize);
            hr = getSymbolValueTextWide(Raw, index, buffer, bufferSize, out nameSize);

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
        #region GetSymbolEntryInformation

        /// <summary>
        /// The GetSymbolEntryInformation method returns information about a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose information iyou want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>[out] The information about the symbol. For more information about this structure, see <see cref="DEBUG_SYMBOL_ENTRY"/>.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public DEBUG_SYMBOL_ENTRY GetSymbolEntryInformation(uint index)
        {
            DEBUG_SYMBOL_ENTRY info;
            TryGetSymbolEntryInformation(index, out info).ThrowDbgEngNotOk();

            return info;
        }

        /// <summary>
        /// The GetSymbolEntryInformation method returns information about a symbol in a symbol group.
        /// </summary>
        /// <param name="index">[in] The index of the symbol whose information iyou want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="info">[out] The information about the symbol. For more information about this structure, see <see cref="DEBUG_SYMBOL_ENTRY"/>.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetSymbolEntryInformation(uint index, out DEBUG_SYMBOL_ENTRY info)
        {
            InitDelegate(ref getSymbolEntryInformation, Vtbl2->GetSymbolEntryInformation);

            /*HRESULT GetSymbolEntryInformation(
            [In] uint Index,
            [Out] out DEBUG_SYMBOL_ENTRY Info);*/
            return getSymbolEntryInformation(Raw, index, out info);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugSymbolGroup

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberSymbolsDelegate getNumberSymbols;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSymbolDelegate addSymbol;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveSymbolByNameDelegate removeSymbolByName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveSymbolsByIndexDelegate removeSymbolsByIndex;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolNameDelegate getSymbolName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolParametersDelegate getSymbolParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ExpandSymbolDelegate expandSymbol;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputSymbolsDelegate outputSymbols;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteSymbolDelegate writeSymbol;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputAsTypeDelegate outputAsType;

        #endregion
        #region IDebugSymbolGroup2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSymbolWideDelegate addSymbolWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveSymbolByNameWideDelegate removeSymbolByNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolNameWideDelegate getSymbolNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteSymbolWideDelegate writeSymbolWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputAsTypeWideDelegate outputAsTypeWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolTypeNameDelegate getSymbolTypeName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolTypeNameWideDelegate getSymbolTypeNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolSizeDelegate getSymbolSize;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolOffsetDelegate getSymbolOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolRegisterDelegate getSymbolRegister;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolValueTextDelegate getSymbolValueText;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolValueTextWideDelegate getSymbolValueTextWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolEntryInformationDelegate getSymbolEntryInformation;

        #endregion
        #endregion
        #region Delegates
        #region IDebugSymbolGroup

        private delegate HRESULT GetNumberSymbolsDelegate(IntPtr self, [Out] out uint Number);
        private delegate HRESULT AddSymbolDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name, [In, Out] ref uint Index);
        private delegate HRESULT RemoveSymbolByNameDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Name);
        private delegate HRESULT RemoveSymbolsByIndexDelegate(IntPtr self, [In] uint Index);
        private delegate HRESULT GetSymbolNameDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetSymbolParametersDelegate(IntPtr self, [In] uint Start, [In] uint Count, [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_PARAMETERS[] Params);
        private delegate HRESULT ExpandSymbolDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.Bool)] bool Expand);
        private delegate HRESULT OutputSymbolsDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] DEBUG_OUTPUT_SYMBOLS Flags, [In] uint Start, [In] uint Count);
        private delegate HRESULT WriteSymbolDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPStr)] string Value);
        private delegate HRESULT OutputAsTypeDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPStr)] string Type);

        #endregion
        #region IDebugSymbolGroup2

        private delegate HRESULT AddSymbolWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name, [In, Out] ref uint Index);
        private delegate HRESULT RemoveSymbolByNameWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Name);
        private delegate HRESULT GetSymbolNameWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT WriteSymbolWideDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPWStr)] string Value);
        private delegate HRESULT OutputAsTypeWideDelegate(IntPtr self, [In] uint Index, [In, MarshalAs(UnmanagedType.LPWStr)] string Type);
        private delegate HRESULT GetSymbolTypeNameDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetSymbolTypeNameWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetSymbolSizeDelegate(IntPtr self, [In] uint Index, [Out] out uint Size);
        private delegate HRESULT GetSymbolOffsetDelegate(IntPtr self, [In] uint Index, [Out] out ulong Offset);
        private delegate HRESULT GetSymbolRegisterDelegate(IntPtr self, [In] uint Index, [Out] out uint Register);
        private delegate HRESULT GetSymbolValueTextDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetSymbolValueTextWideDelegate(IntPtr self, [In] uint Index, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out uint NameSize);
        private delegate HRESULT GetSymbolEntryInformationDelegate(IntPtr self, [In] uint Index, [Out] out DEBUG_SYMBOL_ENTRY Info);

        #endregion
        #endregion
    }
}

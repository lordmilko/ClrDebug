using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("f2528316-0f1a-4431-aeed-11d096e1e2ab")]
    [ComImport]
    public interface IDebugSymbolGroup
    {
        /// <summary>
        /// The GetNumberSymbols method returns the number of symbols that are contained in a symbol group.
        /// </summary>
        /// <param name="Number">[out] The number of symbols that are contained in this symbol group.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// Each symbol in a symbol group is identified by an index. This index is a number between zero and the number that
        /// is returned to Number minus one. Every time that a symbol is added or removed from the symbol group, the index
        /// of all of the symbols in the group might change. For more information about symbol groups, see Scopes and Symbol
        /// Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNumberSymbols(
            [Out] out int Number);

        /// <summary>
        /// The AddSymbol method adds a symbol to a symbol group.
        /// </summary>
        /// <param name="Name">[in] The symbol's name. Name is examined as an expression to determine the symbol's type. This expression can include pointer, array, and structure dereferencing (for example, *my_pointer, my_array[1], or my_struct.some_field).</param>
        /// <param name="Index">[in, out] The index of the entry in the symbol group. When you are calling AddSymbol or <see cref="IDebugSymbolGroup2.AddSymbolWide"/>, Index should point to the index of the symbol that you want.<para/>
        /// Or, if Index points to DEBUG_ANY_ID, the symbol is appended to the end of the list. When this method returns, Index points to the actual index of the symbol.<para/>
        /// The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The symbol name in Name is evaluated by the C++ expression evaluator and can contain any C++ expression (for example,
        /// x+y). If the index that you want is less than the size of the symbol group, the new symbol is added at the desired
        /// index. If the desired index is larger than the size of the symbol group, the new symbol is added to the end of
        /// the list (as in the case of DEBUG_ANY_ID). For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT AddSymbol(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In, Out] ref int Index);

        /// <summary>
        /// The RemoveSymbolByName method removes the specified symbol from a symbol group.
        /// </summary>
        /// <param name="Name">[in] The name of the symbol to remove from the symbol group.</param>
        /// <returns>RemoveSymbolByName might return one of the following values: This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// When a symbol is removed, the indexes of the symbols that remain in the symbol group might change. For more information
        /// about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT RemoveSymbolByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name);

        [PreserveSig]
        HRESULT RemoveSymbolsByIndex(
            [In] int Index);

        /// <summary>
        /// The GetSymbolName method returns the name of a symbol in a symbol group.
        /// </summary>
        /// <param name="Index">[in] The index of the symbol whose name you want. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="Buffer">[out, optional] The symbol name. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] The size of the buffer that Buffer points to. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] The size of the symbol name. This size includes the space for the '\0' terminating character. If NameSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolName(
            [In] int Index,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetSymbolParameters method returns the symbol parameters that describe the specified symbols in a symbol group.
        /// </summary>
        /// <param name="Start">[in] The index in the symbol group of the first symbol whose parameters you want. The index of a symbol is an identification number.<para/>
        /// This number ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="Count">[in] The number of symbol parameters that you want.</param>
        /// <param name="Params">[out] The symbol parameters. This array must hold at least Count elements. For a description of these parameters, see <see cref="DEBUG_SYMBOL_PARAMETERS"/>.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolParameters(
            [In] int Start,
            [In] int Count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DEBUG_SYMBOL_PARAMETERS[] Params);

        /// <summary>
        /// The ExpandSymbol method adds or removes the children of a symbol from a symbol group.
        /// </summary>
        /// <param name="Index">[in] The index of the symbol whose children will be added or removed. The index of a symbol is an identification number.<para/>
        /// The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="Expand">[in] A Boolean value that specifies whether to add or remove the symbols children from the symbol group. If Expand is true, the children are added.<para/>
        /// If Expand is false, the children are removed.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT ExpandSymbol(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.Bool)] bool Expand);

        /// <summary>
        /// The OutputSymbols method prints the specified symbols to the debugger console.
        /// </summary>
        /// <param name="OutputControl">[in] The output control to use when printing the symbols' information. For more information about possible values, see DEBUG_OUTCTL_XXX.<para/>
        /// For more information about output, see Input and Output.</param>
        /// <param name="Flags">[in] The flags that determine what information is printed for each symbol. By default, the output includes the symbol's name, offset, value, and type.<para/>
        /// The format for the output is as follows: NameNAMEOffsetOFFValueVALUETypeTYPE You can use the following bit flags to suppress the output of one of these pieces of information together with the corresponding marker.</param>
        /// <param name="Start">[in] The index of the first symbol in the symbol group to print. The index of a symbol is an identification number.<para/>
        /// This number ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="Count">[in] The number of symbols to print.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT OutputSymbols(
            [In] DEBUG_OUTCTL OutputControl,
            [In] DEBUG_OUTPUT_SYMBOLS Flags,
            [In] int Start,
            [In] int Count);

        /// <summary>
        /// The WriteSymbol methods set the value of the specified symbol.
        /// </summary>
        /// <param name="Index">[in] The index of the symbol whose value will be changed. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="Value">[in] A C++ expression that is evaluated to give the symbol's new value.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The WriteSymbol method can change symbols only if the symbols are stored in a register or memory location that
        /// the debugger engine knowns and if they have not had their type changed to an extension by using the <see cref="OutputAsType"/>
        /// method. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT WriteSymbol(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Value);

        /// <summary>
        /// The OutputAsType method changes the type of a symbol in a symbol group. The symbol's entry is updated to represent the new type.
        /// </summary>
        /// <param name="Index">[in] The index of the entry in this symbol group. The index of a symbol is an identification number. The index ranges from zero through the number of symbols in the symbol group minus one.</param>
        /// <param name="Type">[in] The name of the type of the symbol that you want. If the name begins with an exclamation mark (!), the name is treated as an extension.<para/>
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
        [PreserveSig]
        HRESULT OutputAsType(
            [In] int Index,
            [In, MarshalAs(UnmanagedType.LPStr)] string Type);
    }
}

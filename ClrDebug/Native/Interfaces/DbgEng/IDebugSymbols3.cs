using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("f02fbecc-50ac-4f36-9ad9-c975e8f32ff8")]
    [ComImport]
    public interface IDebugSymbols3 : IDebugSymbols2
    {
        #region IDebugSymbols

        /// <summary>
        /// The GetSymbolOptions method returns the engine's global symbol options.
        /// </summary>
        /// <param name="Options">[out] Receives the symbol options bit-set. For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSymbolOptions(
            [Out] out SYMOPT Options);

        /// <summary>
        /// The AddSymbolOptions method turns on some of the engine's global symbol options.
        /// </summary>
        /// <param name="Options">[in] Specifies the symbol options to turns on. Options is a bit-set that will be ORed with the existing symbol options.<para/>
        /// For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the symbol options have been changed, for each client the engine sends out notification to that client's
        /// <see cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddSymbolOptions(
            [In] SYMOPT Options);

        /// <summary>
        /// The RemoveSymbolOptions method turns off some of the engine's global symbol options.
        /// </summary>
        /// <param name="Options">[in] Specifies the symbol options to turn off. Options is a bit-set; the new value of the symbol options will equal the old value AND NOT the value of Options.<para/>
        /// For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the symbol options have been changed, for each client the engine sends out notification to that client's
        /// <see cref="IDebugEventCallbacks"/> by it passing the DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT RemoveSymbolOptions(
            [In] SYMOPT Options);

        /// <summary>
        /// The SetSymbolOptions method changes the engine's global symbol options.
        /// </summary>
        /// <param name="Options">[in] Specifies the new symbol options. Options is a bit-set; it will replace the existing symbol options. For a description of the bit flags, see Setting Symbol Options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method will set the engine's global symbol options to those specified in Options. Unlike <see cref="AddSymbolOptions"/>,
        /// any symbol options not in the bit-set Options will be removed. After the symbol options have been changed, for
        /// each client the engine sends out notification to that client's <see cref="IDebugEventCallbacks"/> by passing the
        /// DEBUG_CES_SYMBOL_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/> method. For more information
        /// about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetSymbolOptions(
            [In] SYMOPT Options);

        /// <summary>
        /// The GetNameByOffset method returns the name of the symbol at the specified location in the target's virtual address space.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the symbol whose name is requested. Offset does not need to specify the base location of the symbol; it only needs to specify a location within the symbol's memory allocation.</param>
        /// <param name="NameBuffer">[out, optional] Receives the symbol's name. The name is qualified by the module to which the symbol belongs (for example, mymodule!main).<para/>
        /// If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the symbol's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="Displacement">[out, optional] Receives the difference between the value of Offset and the base location of the symbol. If Displacement is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNameByOffset(
            [In] long Offset,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);

        /// <summary>
        /// The GetOffsetByName method returns the location of a symbol identified by name.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the name of the symbol to locate. The name may be qualified by a module name (for example, mymodule!main).</param>
        /// <param name="Offset">[out] Receives the location in the target's memory address space of the base of the symbol's memory allocation.</param>
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
        [PreserveSig]
        new HRESULT GetOffsetByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out long Offset);

        /// <summary>
        /// The GetNearNameByOffset method returns the name of a symbol that is located near the specified location.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the symbol from which the desired symbol is determined.</param>
        /// <param name="Delta">[in] Specifies the relationship between the desired symbol and the symbol located at Offset. If positive, the engine will return the symbol that is Delta symbols after the symbol located at Offset.<para/>
        /// If negative, the engine will return the symbol that is Delta symbols before the symbol located at Offset.</param>
        /// <param name="NameBuffer">[out, optional] Receives the symbol's name. The name is qualified by the module to which the symbol belongs (for example, mymodule!main).<para/>
        /// If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the symbol's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="Displacement">[out, optional] Receives the difference between the value of Offset and the location in the target's memory address space of the symbol.<para/>
        /// If Displacement is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// By increasing or decreasing the value of Delta, these methods can be used to iterate over the target's symbols
        /// starting at a particular location. If Delta is zero, these methods behave the same way as <see cref="GetNameByOffset"/>.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNearNameByOffset(
            [In] long Offset,
            [In] int Delta,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);

        /// <summary>
        /// The GetLineByOffset method returns the source filename and the line number within the source file of an instruction in the target.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the instruction for which to return the source file and line number.</param>
        /// <param name="Line">[out, optional] Receives the line number within the source file of the instruction specified by Offset. If Line is NULL, this information is not returned.</param>
        /// <param name="FileBuffer">[out, optional] Receives the file name of the file that contains the instruction specified by Offset. If FileBuffer is NULL, this information is not returned.</param>
        /// <param name="FileBufferSize">[in] Specifies the size, in characters, of the FileBuffer buffer.</param>
        /// <param name="FileSize">[out, optional] Specifies the size, in characters, of the source filename. If FileSize is NULL, this information is not returned.</param>
        /// <param name="Displacement">[out, optional] Receives the difference between the location specified in Offset and the location of the first instruction of the returned line.<para/>
        /// If Displacement is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetLineByOffset(
            [In] long Offset,
            [Out] out int Line,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] FileBuffer,
            [In] int FileBufferSize,
            [Out] out int FileSize,
            [Out] out long Displacement);

        /// <summary>
        /// The GetOffsetByLine method returns the location of the instruction that corresponds to a specified line in the source code.
        /// </summary>
        /// <param name="Line">[in] Specifies the line number in the source file.</param>
        /// <param name="File">[in] Specifies the file name of the source file.</param>
        /// <param name="Offset">[out] Receives the location in the target's virtual address space of an instruction for the specified line.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// A line in a source file might correspond to multiple instructions and this method can return any one of these instructions.
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetOffsetByLine(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out long Offset);

        /// <summary>
        /// The GetNumberModules method returns the number of modules in the current process's module list.
        /// </summary>
        /// <param name="Loaded">[out] Receives the number of loaded modules in the current process's module list.</param>
        /// <param name="Unloaded">[out] Receives the number of unloaded modules in the current process's module list. This number will be zero if the version of Microsoft Windows running on the target computer does not track unloaded modules.</param>
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
        [PreserveSig]
        new HRESULT GetNumberModules(
            [Out] out int Loaded,
            [Out] out int Unloaded);

        /// <summary>
        /// The GetModuleByIndex method returns the location of the module with the specified index.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the module whose location is requested.</param>
        /// <param name="Base">[out] Receives the location in the target's memory address space of the module.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetModuleByIndex(
            [In] int Index,
            [Out] out long Base);

        /// <summary>
        /// The GetModuleByModuleName method searches through the target's modules for one with the specified name.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the desired module.</param>
        /// <param name="StartIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="Index">[out, optional] Receives the index of the first module with the name Name. If Index is NULL, this information is not returned.</param>
        /// <param name="Base">[out, optional] Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetModuleByModuleName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] int StartIndex,
            [Out] out int Index,
            [Out] out long Base);

        /// <summary>
        /// The GetModuleByOffset method searches through the target's modules for one whose memory allocation includes the specified location.
        /// </summary>
        /// <param name="Offset">[in] Specifies a location in the target's virtual address space which is inside the desired module's memory allocation -- for example, the address of a symbol belonging to the module.</param>
        /// <param name="StartIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="Index">[out, optional] Receives the index of the module. If Index is NULL, this information is not returned.</param>
        /// <param name="Base">[out, optional] Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, this method returns the first module it finds whose memory allocation address
        /// range includes the specified location. If the target has more than one module whose memory address range includes
        /// this location, then subsequent modules can be found by repeated calls to this method with higher values of StartIndex.
        /// For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetModuleByOffset(
            [In] long Offset,
            [In] int StartIndex,
            [Out] out int Index,
            [Out] out long Base);

        /// <summary>
        /// The GetModuleNames method returns the names of the specified module.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the module whose names are requested. If it is set to DEBUG_ANY_ID, the module is specified by Base.</param>
        /// <param name="Base">[in] Specifies the base address of the module whose names are requested. This parameter is only used if Index is set to DEBUG_ANY_ID.</param>
        /// <param name="ImageNameBuffer">[out, optional] Receives the image name of the module. If ImageNameBuffer is NULL, this information is not returned.</param>
        /// <param name="ImageNameBufferSize">[in] Specifies the size in characters of the buffer ImageNameBuffer in characters. This size includes the space for the '\0' terminating character.</param>
        /// <param name="ImageNameSize">[out, optional] Receives the size in characters of the image name. This size includes the space for the '\0' terminating character.<para/>
        /// If ImageNameSize is NULL, this information is not returned.</param>
        /// <param name="ModuleNameBuffer">[out, optional] Receives the module name of the module. This size includes the space for the '\0' terminating character.<para/>
        /// If ModuleNameBuffer is NULL, this information is not returned.</param>
        /// <param name="ModuleNameBufferSize">[in] Specifies the size in characters of the buffer ModuleNameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="ModuleNameSize">[out, optional] Receives the size in characters of the module name. This size includes the space for the '\0' terminating character.<para/>
        /// If ModuleNameSize is NULL, this information is not returned.</param>
        /// <param name="LoadedImageNameBuffer">[out, optional] Receives the loaded image name of the module. If LoadedImageNameBuffer is NULL, this information is not returned.</param>
        /// <param name="LoadedImageNameBufferSize">[in] Specifies the size in characters of the buffer LoadedImageNameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="LoadedImageNameSize">[out, optional] Receives the size in characters of the loaded image name. This size includes the space for the '\0' terminating character.<para/>
        /// If LoadedImageNameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetModuleNames(
            [In] int Index,
            [In] long Base,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] ImageNameBuffer,
            [In] int ImageNameBufferSize,
            [Out] out int ImageNameSize,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 6)] char[] ModuleNameBuffer,
            [In] int ModuleNameBufferSize,
            [Out] out int ModuleNameSize,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 9)] char[] LoadedImageNameBuffer,
            [In] int LoadedImageNameBufferSize,
            [Out] out int LoadedImageNameSize);

        /// <summary>
        /// The GetModuleParameters method returns parameters for modules in the target.
        /// </summary>
        /// <param name="Count">[in] Specifies the number of modules whose parameters are desired.</param>
        /// <param name="Bases">[in, optional] Specifies an array of locations in the target's virtual address space representing the base address of the modules whose parameters are desired.<para/>
        /// The size of this array is the value of Count. If Bases is NULL, the Start parameter is used to specify the modules by index.</param>
        /// <param name="Start">[in] Specifies the index of the first module whose parameters are desired. If Bases is not NULL, this parameter is ignored.</param>
        /// <param name="Params">[out] Receives the parameters. The size of this array is the value of Count. See <see cref="DEBUG_MODULE_PARAMETERS"/>.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In the cases when partial results are returned, the entries in the array Params corresponding to modules that could
        /// not be found have their Base field set to DEBUG_INVALID_OFFSET. See <see cref="DEBUG_MODULE_PARAMETERS"/>. For
        /// more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetModuleParameters(
            [In] int Count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] long[] Bases,
            [In] int Start,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DEBUG_MODULE_PARAMETERS[] Params);

        /// <summary>
        /// The GetSymbolModule method returns the base address of module which contains the specified symbol.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the name of the symbol to look up. See the Remarks section for details of the syntax of this name.</param>
        /// <param name="Base">[out] Receives the location in the target's memory address space of the base of the module. For more information, see Modules.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The string Symbol must contain an exclamation point ( ! ). If Symbol is a module-qualified symbol name (for example,
        /// mymodules!main) or if the module name is omitted (for example, !main), the engine will search for this symbol and
        /// return the module in which it is found. If Symbol contains just a module name (for example, mymodule!) the engine
        /// returns the first module with this module name. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSymbolModule(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out long Base);

        /// <summary>
        /// The GetTypeName method returns the name of the type symbol specified by its type ID and module.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type.</param>
        /// <param name="NameBuffer">[out, optional] Receives the name of the type. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the type's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetTypeName(
            [In] long Module,
            [In] int TypeId,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetTypeId method looks up the specified type and return its type ID.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules. If Name contains a module name, Module is ignored.</param>
        /// <param name="Name">[in] Specifies the name of the type whose type ID is desired. If Name is a module-qualified name (for example mymodule!main), the Module parameter is ignored.</param>
        /// <param name="TypeId">[out] Receives the type ID of the symbol.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified symbol is a type, these methods return the type ID for that type; otherwise, they return the type
        /// ID for the type of the symbol. A variable whose type was defined using typedef has a type ID that identifies the
        /// original type, not the type created by typedef. In the following example, the type ID of MyInstance corresponds
        /// to the name MyStruct (this correspondence can be seen by passing the type ID to <see cref="GetTypeName"/>): Moreover,
        /// calling these methods for MyStruct and MyType yields type IDs corresponding to MyStruct and MyType, respectively.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetTypeId(
            [In] long Module,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out int TypeId);

        /// <summary>
        /// The GetTypeSize method returns the number of bytes of memory an instance of the specified type requires.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module containing the type. For more information, see Modules.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type.</param>
        /// <param name="Size">[out] Receives the number of bytes of memory an instance of the specified type requires.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetTypeSize(
            [In] long Module,
            [In] int TypeId,
            [Out] out int Size);

        /// <summary>
        /// The GetFieldOffset method returns the offset of a field from the base address of an instance of a type.
        /// </summary>
        /// <param name="Module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type containing the field.</param>
        /// <param name="Field">[in] Specifies the name of the field whose offset is requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="Offset">[out] Receives the offset of the specified field from the base memory location of an instance of the type.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the location
        /// of this field relative to the location of MyStruct structure can be found by setting the Field parameter to "MyField.MySubField".
        /// For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetFieldOffset(
            [In] long Module,
            [In] int TypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out int Offset);

        /// <summary>
        /// The GetSymbolTypeId method returns the type ID and module of the specified symbol.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the expression whose type ID is requested. See the Remarks section for details on the syntax of this expression.</param>
        /// <param name="TypeId">[out] Receives the type ID.</param>
        /// <param name="Module">[out, optional] Receives the base address of the module containing the symbol. For more information, see Modules.<para/>
        /// If Module is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Symbol expression may contain structure fields, pointer dereferencing, and array dereferencing -- for example
        /// my_struct.some_field[0]. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSymbolTypeId(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out int TypeId,
            [Out] out long Module);

        /// <summary>
        /// The GetOffsetTypeId method returns the type ID of the symbol closest to the specified memory location.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's memory for the symbol. The symbol closest to this location is used.</param>
        /// <param name="TypeId">[out] Receives the type ID of the symbol.</param>
        /// <param name="Module">[out, optional] Specifies the location in the target's memory address space of the base of the module to which the symbol belongs.<para/>
        /// For more information, see Modules. If Module is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetOffsetTypeId(
            [In] long Offset,
            [Out] out int TypeId,
            [Out] out long Module);

        /// <summary>
        /// The ReadTypedDataVirtual method reads the value of a variable in the target's virtual memory.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the variable to read.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type.</param>
        /// <param name="Buffer">[out] Receives the data that is read.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be read.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes that were read. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The number of bytes this method attempts to read is the smaller of the size of the buffer and the size of the variable.
        /// This is a convenience method. The same result can be obtained by calling <see cref="GetTypeSize"/> and <see cref="IDebugDataSpaces.ReadVirtual"/>.
        /// For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT ReadTypedDataVirtual(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WriteTypedDataVirtual method writes data to the target's virtual address space. The number of bytes written is the size of the specified type.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space where the data will be written.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type.</param>
        /// <param name="Buffer">[in] Specifies the buffer containing the data to be written.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This is a convenience method. The same result can be obtained by calling <see cref="GetTypeSize"/> and <see cref="IDebugDataSpaces.WriteVirtual"/>.
        /// For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT WriteTypedDataVirtual(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The OutputTypedDataVirtual method formats the contents of a variable in the target's virtual memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the variable.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type.</param>
        /// <param name="Flags">[in] Specifies the formatting flags.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The output produced by this method is the same as for the debugger command DT. See dt (Display Type). For more
        /// information about types, see Types. For more information about output, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputTypedDataVirtual(
            [In] DEBUG_OUTCTL OutputControl,
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] DEBUG_OUTTYPE Flags);

        /// <summary>
        /// The ReadTypedDataPhysical method reads the value of a variable from the target computer's physical memory.
        /// </summary>
        /// <param name="Offset">[in] Specifies the physical address in the target computer's memory of the variable to be read.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="Buffer">[out] Receives the data that was read.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes that will be read.</param>
        /// <param name="BytesRead">[out, optional] Receives the number of bytes that were read. If BytesRead is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The number of bytes this method attempts to read is the
        /// smaller of the size of the buffer and the size of the variable. This is a convenience method. The same result can
        /// be obtained by calling <see cref="GetTypeSize"/> and <see cref="IDebugDataSpaces.ReadPhysical"/>. For more information
        /// about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT ReadTypedDataPhysical(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesRead);

        /// <summary>
        /// The WriteTypedDataPhysical method writes the value of a variable in the target computer's physical memory.
        /// </summary>
        /// <param name="Offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="Buffer">[in] Specifies the buffer containing the data to be written.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the buffer Buffer. This is the maximum number of bytes to be written.</param>
        /// <param name="BytesWritten">[out, optional] Receives the number of bytes that were written. If BytesWritten is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The number of bytes this method attempts to write is the
        /// smaller of the size of the buffer and the size of the variable. This is a convenience method. The same result can
        /// be obtained by calling <see cref="GetTypeSize"/> and WritePhysical. For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT WriteTypedDataPhysical(
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BytesWritten);

        /// <summary>
        /// The OutputTypedDataPhysical method formats the contents of a variable in the target computer's physical memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="Offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="Flags">[in] Specifies the bit-set containing the formatting options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The output produced by this method is the same as for the
        /// debugger command DT. See dt (Display Type). For more information about types, see Types. For information about
        /// output, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputTypedDataPhysical(
            [In] DEBUG_OUTCTL OutputControl,
            [In] long Offset,
            [In] long Module,
            [In] int TypeId,
            [In] DEBUG_OUTTYPE Flags);

        /// <summary>
        /// The GetScope method returns information about the current scope.
        /// </summary>
        /// <param name="InstructionOffset">[out, optional] Receives the location in the process's virtual address space of the current scope's current instruction.</param>
        /// <param name="ScopeFrame">[out, optional] Receives the <see cref="DEBUG_STACK_FRAME"/> structure representing the current scope's stack frame.</param>
        /// <param name="ScopeContext">[out, optional] Receives the current scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer ScopeContext must be large enough to hold this structure.</param>
        /// <param name="ScopeContextSize">[in] Specifies the size of the buffer ScopeContext.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetScope(
            [Out] out long InstructionOffset,
            [Out] out DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] int ScopeContextSize);

        /// <summary>
        /// The SetScope method sets the current scope.
        /// </summary>
        /// <param name="InstructionOffset">[in] Specifies the location in the process's virtual address space for the scope's current instruction. This is only used if both ScopeFrame and ScopeContext are NULL; otherwise, it is ignored.</param>
        /// <param name="ScopeFrame">[in, optional] Specifies the scope's stack frame. For information about this structure, see <see cref="DEBUG_STACK_FRAME"/>.</param>
        /// <param name="ScopeContext">[in, optional] Specifies the scope's thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer ScopeContext must be large enough to hold this structure. If ScopeContext is NULL, the current register context is used instead.</param>
        /// <param name="ScopeContextSize">[in] Specifies the size of the buffer ScopeContext.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If only InstructionOffset is provided, the scope can be used to look up symbol names; however, the values of these
        /// symbols will not be available. To set the scope to a previous state, ScopeContext must be provided. This is not
        /// always necessary (for example, if you only wish to access the symbols and not the registers). To set the scope
        /// to a frame on the current stack, <see cref="SetScopeFrameByIndex"/> can be used. For more information about scopes,
        /// see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetScope(
            [In] long InstructionOffset,
            [In] ref DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] int ScopeContextSize);

        /// <summary>
        /// The ResetScope method resets the current scope to the default scope of the current thread.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT ResetScope();

        /// <summary>
        /// The GetScopeSymbolGroup method returns a symbol group containing the symbols in the current target's scope.
        /// </summary>
        /// <param name="Flags">[in] Specifies a bit-set used to determine which symbols to include in the symbol group. To include all symbols, set Flags to DEBUG_SCOPE_GROUP_ALL.<para/>
        /// The following bit-flags determine which symbols are included.</param>
        /// <param name="Update">[in, optional] Specifies a previously created symbol group that will be updated to reflect the current scope. If Update is NULL, a new symbol group interface object is created.</param>
        /// <param name="Symbols">[out] Receives the symbol group interface object for the current scope. For details on this interface, see <see cref="IDebugSymbolGroup"/></param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Update parameter allows for efficient updates when stepping through code. Instead of creating and populating
        /// a new symbol group, the old symbol group can be updated. For more information about scopes and symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetScopeSymbolGroup(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, ComAliasName("IDebugSymbolGroup")] IntPtr Update,
            [Out, ComAliasName("IDebugSymbolGroup")] out IntPtr Symbols);

        /// <summary>
        /// The CreateSymbolGroup method creates a new symbol group.
        /// </summary>
        /// <param name="Group">[out] Receives an interface pointer for the new <see cref="IDebugSymbolGroup"/> object.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The newly created symbol group is empty; it does not contain any symbols. Symbols may be added to the symbol group
        /// using <see cref="IDebugSymbolGroup.AddSymbol"/>. References to the returned object are managed like other COM objects,
        /// using the IUnknown::AddRef and IUnknown::Release methods. In particular, the IUnknown::Release method must be called
        /// when the returned object is no longer needed. See Using Client Objects for more information about using COM interfaces
        /// in the Debugger Engine API. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT CreateSymbolGroup(
            [Out, ComAliasName("IDebugSymbolGroup")] out IntPtr Group);

        /// <summary>
        /// The StartSymbolMatch method initializes a search for symbols whose names match a given pattern.
        /// </summary>
        /// <param name="Pattern">[in] Specifies the pattern for which to search. The search will return all symbols whose names match this pattern.<para/>
        /// For details of the syntax of the pattern, see Symbol Syntax and Symbol Matching and String Wildcard Syntax.</param>
        /// <param name="Handle">[out] Receives the handle identifying the search. This handle can be passed to <see cref="GetNextSymbolMatch"/> and <see cref="EndSymbolMatch"/>.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method initializes a symbol search. The results of the search can be obtained by repeated calls to <see cref="GetNextSymbolMatch"/>.
        /// When all the desired results have been found, use <see cref="EndSymbolMatch"/> to release resources the engine
        /// holds for the search. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT StartSymbolMatch(
            [In, MarshalAs(UnmanagedType.LPStr)] string Pattern,
            [Out] out long Handle);

        /// <summary>
        /// The GetNextSymbolMatch method returns the next symbol found in a symbol search.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the symbol. If Buffer is NULL, the same symbol will be returned again next time one of these methods are called (with the same handle); this can be used to determine the size of the name of the symbol.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="MatchSize">[out, optional] Receives the size in characters of the name of the symbol. This size includes the space for the '\0' terminating character.<para/>
        /// If MatchSize is NULL, this information is not returned.</param>
        /// <param name="Offset">[out, optional] Receives the location in the target's virtual address space of the symbol. If Offset is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The search must first be initialized by <see cref="StartSymbolMatch"/>. Once all the desired symbols have been
        /// found, <see cref="EndSymbolMatch"/> can be used to release the resources the engine holds for the search. For more
        /// information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetNextSymbolMatch(
            [In] long Handle,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int MatchSize,
            [Out] out long Offset);

        /// <summary>
        /// The EndSymbolMatch method releases the resources used by a symbol search.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method releases the resources held by the engine during a symbol search. After these resources are released,
        /// the handle becomes invalid, so it must not be passed to <see cref="GetNextSymbolMatch"/> after it has been passed
        /// to this method. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT EndSymbolMatch(
            [In] long Handle);

        /// <summary>
        /// The Reload method deletes the engine's symbol information for the specified module and reload these symbols as needed.
        /// </summary>
        /// <param name="Module">[in] Specifies the module to reload.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method behaves the same way as the debugger command .reload. The Module parameter is treated the same way
        /// as the arguments to .reload. For example, setting the Module parameter to "/u ntdll.dll" has the same effect as
        /// the command .reload /u ntdll.dll. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT Reload(
            [In, MarshalAs(UnmanagedType.LPStr)] string Module);

        /// <summary>
        /// The GetSymbolPath method returns the symbol path.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="PathSize">[out, optional] Receives the size, in characters, of the symbol path.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSymbolPath(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);

        /// <summary>
        /// The SetSymbolPath method sets the symbol path.
        /// </summary>
        /// <param name="Path">[in] Specifies the new symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetSymbolPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);

        /// <summary>
        /// The AppendSymbolPath method appends directories to the symbol path.
        /// </summary>
        /// <param name="Addition">[in] Specifies the directories to append to the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        [PreserveSig]
        new HRESULT AppendSymbolPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);

        /// <summary>
        /// The GetImagePath method returns the executable image path.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the executable image path. This is a string that contains directories separated by semicolons (;).<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="PathSize">[out, optional] Receives the size, in characters, of the executable image path.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetImagePath(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);

        /// <summary>
        /// The SetImagePath method sets the executable image path.
        /// </summary>
        /// <param name="Path">[in] Specifies the new executable image path. This is a string that contains directories separated by semicolons (;).</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetImagePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);

        /// <summary>
        /// The AppendImagePath method appends directories to the executable image path.
        /// </summary>
        /// <param name="Addition">[in] Specifies the directories to append to the executable image path. This is a string that contains directory names separated by semicolons (;).</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons (;). These directories are searched in order.
        /// </remarks>
        [PreserveSig]
        new HRESULT AppendImagePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);

        /// <summary>
        /// The GetSourcePath method returns the source path.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="PathSize">[out, optional] Receives the size, in characters, of the source path.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSourcePath(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);

        /// <summary>
        /// The GetSourcePathElement method returns an element from the source path.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the element in the source path that will be returned. The source path is a string that contains elements separated by semicolons (;).<para/>
        /// The index of the first element is zero.</param>
        /// <param name="Buffer">[out, optional] Receives the source path element. Each source path element can be a directory or a source server.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="ElementSize">[out, optional] Receives the size, in characters, of the source path element.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSourcePathElement(
            [In] int Index,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ElementSize);

        /// <summary>
        /// The SetSourcePath method sets the source path.
        /// </summary>
        /// <param name="Path">[in] Specifies the new source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetSourcePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);

        /// <summary>
        /// The AppendSourcePath method appends directories to the source path.
        /// </summary>
        /// <param name="Addition">[in] Specifies the directories to append to the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        new HRESULT AppendSourcePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);

        /// <summary>
        /// The FindSourceFile method searches the source path for a specified source file.
        /// </summary>
        /// <param name="StartElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path.</param>
        /// <param name="File">[in] Specifies the path and file name of the file to search for.</param>
        /// <param name="Flags">[in] Specifies the search flags. For a description of these flags, see DEBUG_FIND_SOURCE_XXX. The flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP should not be set.<para/>
        /// The flag DEBUG_FIND_SOURCE_NO_SRCSRV is ignored because this method does not include source servers in the search.</param>
        /// <param name="FoundElement">[out, optional] Receives the index of the element within the source path that contains the file. If the file was found directly on the filing system (not using the source path) then -1 is returned to FoundElement.<para/>
        /// If FoundElement is NULL, this information is not returned.</param>
        /// <param name="Buffer">[out, optional] Receives the path and name of the found file. If the flag DEBUG_FIND_SOURCE_FULL_PATH is set, this is the full canonical path name for the file.<para/>
        /// Otherwise, it is the concatenation of the directory in the source path with the tail of File that was used to find the file.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="FoundSize">[out, optional] Specifies the size, in characters, of the name of the file. If FoundSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine uses the following steps--in order--to search for the file: If the flag DEBUG_FIND_SOURCE_BEST_MATCH
        /// is set, the match with the longest overlap is returned; otherwise, the first match is returned. The first match
        /// found is returned.
        /// </remarks>
        [PreserveSig]
        new HRESULT FindSourceFile(
            [In] int StartElement,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);

        /// <summary>
        /// The GetSourceFileLineOffsets method maps each line in a source file to a location in the target's memory.
        /// </summary>
        /// <param name="File">[in] Specifies the name of the file whose lines will be turned into locations in the target's memory. The symbols for each module in the target are queried for this file.<para/>
        /// If the file is not located, the path is dropped and the symbols are queried again.</param>
        /// <param name="Buffer">[out, optional] Receives the locations in the target's memory that correspond to the lines of the source code. The first entry returned to this array corresponds to the first line of the file, so that Buffer[i] contains the location for line i+1.<para/>
        /// If no symbol information is available for a line, the corresponding entry in Buffer is set to DEBUG_INVALID_OFFSET.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferLines">[in] Specifies the number of PULONG64 objects that the Buffer array can hold.</param>
        /// <param name="FileLines">[out, optional] Receives the number of lines in the source file specified by File.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using the source path, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSourceFileLineOffsets(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] Buffer,
            [In] int BufferLines,
            [Out] out int FileLines);

        #endregion
        #region IDebugSymbols2

        /// <summary>
        /// The GetModuleVersionInformation method returns version information for the specified module.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="Base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="Item">[in] Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="Buffer">[out, optional] Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="VerInfoSize">[out, optional] Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Module version information is available only for loaded modules and may not be available in all sessions. For more
        /// information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetModuleVersionInformation(
            [In] int Index,
            [In] long Base,
            [In, MarshalAs(UnmanagedType.LPStr)] string Item,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int VerInfoSize);

        /// <summary>
        /// The GetModuleNameString method returns the name of the specified module.
        /// </summary>
        /// <param name="Which">[in] Specifies which of the module's names to return, possible values are:</param>
        /// <param name="Index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="Base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the module. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the module's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetModuleNameString(
            [In] DEBUG_MODNAME Which,
            [In] int Index,
            [In] long Base,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetConstantName method returns the name of the specified constant.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module in which the constant was defined.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the constant.</param>
        /// <param name="Value">[in] Specifies the value of the constant.</param>
        /// <param name="Buffer">[out, optional] Receives the constant's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the constant's name. This size includes the space for the '\0' terminating character.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetConstantName(
            [In] long Module,
            [In] int TypeId,
            [In] long Value,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetFieldName method returns the name of a field within a structure.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module in which the structure was defined.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the structure.</param>
        /// <param name="FieldIndex">[in] Specifies the index of the desired field within the structure.</param>
        /// <param name="Buffer">[out, optional] Receives the field's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the field's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetFieldName(
            [In] long Module,
            [In] int TypeId,
            [In] int FieldIndex,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetTypeOptions method returns the type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="Options">[out] Receives the type formatting options. Options is a bit-set; for a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetTypeOptions(
            [Out] out DEBUG_TYPEOPTS Options);

        /// <summary>
        /// The AddTypeOptions method turns on some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="Options">[in] Specifies type formatting options to turn on. Options is a bit-set that will be ORed with the existing type formatting options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        /// <summary>
        /// The RemoveTypeOptions method turns off some type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="Options">[in] Specifies the type formatting options to turn off. Options is a bit-set; the new value of the options will equal the old value AND NOT the value of Options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT RemoveTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        /// <summary>
        /// The SetTypeOptions method changes the type formatting options for output generated by the engine.
        /// </summary>
        /// <param name="Options">[in] Specifies the new value for the type formatting options. Options is a bit-set; it will replace the existing options.<para/>
        /// For a description of the bit flags, see DEBUG_TYPEOPTS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// After the type options have been changed, for each client the engine sends out notification to that client's <see
        /// cref="IDebugEventCallbacks"/> by passing the DEBUG_CES_TYPE_OPTIONS flag to the <see cref="IDebugEventCallbacks.ChangeSymbolState"/>
        /// method. For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        #endregion
        #region IDebugSymbols3

        /// <summary>
        /// The GetNameByOffsetWide method returns the name of the symbol at the specified location in the target's virtual address space.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the symbol whose name is requested. Offset does not need to specify the base location of the symbol; it only needs to specify a location within the symbol's memory allocation.</param>
        /// <param name="NameBuffer">[out, optional] Receives the symbol's name. The name is qualified by the module to which the symbol belongs (for example, mymodule!main).<para/>
        /// If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the symbol's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="Displacement">[out, optional] Receives the difference between the value of Offset and the base location of the symbol. If Displacement is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNameByOffsetWide(
            [In] long Offset,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);

        /// <summary>
        /// The GetOffsetByNameWide method returns the location of a symbol identified by name.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the name of the symbol to locate. The name may be qualified by a module name (for example, mymodule!main).</param>
        /// <param name="Offset">[out] Receives the location in the target's memory address space of the base of the symbol's memory allocation.</param>
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
        [PreserveSig]
        HRESULT GetOffsetByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out long Offset);

        /// <summary>
        /// The GetNearNameByOffsetWide method returns the name of a symbol that is located near the specified location.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the symbol from which the desired symbol is determined.</param>
        /// <param name="Delta">[in] Specifies the relationship between the desired symbol and the symbol located at Offset. If positive, the engine will return the symbol that is Delta symbols after the symbol located at Offset.<para/>
        /// If negative, the engine will return the symbol that is Delta symbols before the symbol located at Offset.</param>
        /// <param name="NameBuffer">[out, optional] Receives the symbol's name. The name is qualified by the module to which the symbol belongs (for example, mymodule!main).<para/>
        /// If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the symbol's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <param name="Displacement">[out, optional] Receives the difference between the value of Offset and the location in the target's memory address space of the symbol.<para/>
        /// If Displacement is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// By increasing or decreasing the value of Delta, these methods can be used to iterate over the target's symbols
        /// starting at a particular location. If Delta is zero, these methods behave the same way as <see cref="GetNameByOffset"/>.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNearNameByOffsetWide(
            [In] long Offset,
            [In] int Delta,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize,
            [Out] out long Displacement);

        /// <summary>
        /// The GetLineByOffsetWide method returns the source filename and the line number within the source file of an instruction in the target.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the instruction for which to return the source file and line number.</param>
        /// <param name="Line">[out, optional] Receives the line number within the source file of the instruction specified by Offset. If Line is NULL, this information is not returned.</param>
        /// <param name="FileBuffer">[out, optional] Receives the file name of the file that contains the instruction specified by Offset. If FileBuffer is NULL, this information is not returned.</param>
        /// <param name="FileBufferSize">[in] Specifies the size, in characters, of the FileBuffer buffer.</param>
        /// <param name="FileSize">[out, optional] Specifies the size, in characters, of the source filename. If FileSize is NULL, this information is not returned.</param>
        /// <param name="Displacement">[out, optional] Receives the difference between the location specified in Offset and the location of the first instruction of the returned line.<para/>
        /// If Displacement is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        HRESULT GetLineByOffsetWide(
            [In] long Offset,
            [Out] out int Line,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] FileBuffer,
            [In] int FileBufferSize,
            [Out] out int FileSize,
            [Out] out long Displacement);

        /// <summary>
        /// The GetOffsetByLineWide method returns the location of the instruction that corresponds to a specified line in the source code.
        /// </summary>
        /// <param name="Line">[in] Specifies the line number in the source file.</param>
        /// <param name="File">[in] Specifies the file name of the source file.</param>
        /// <param name="Offset">[out] Receives the location in the target's virtual address space of an instruction for the specified line.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// A line in a source file might correspond to multiple instructions and this method can return any one of these instructions.
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        HRESULT GetOffsetByLineWide(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out long Offset);

        /// <summary>
        /// The GetModuleByModuleNameWide method searches through the target's modules for one with the specified name.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the desired module.</param>
        /// <param name="StartIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="Index">[out, optional] Receives the index of the first module with the name Name. If Index is NULL, this information is not returned.</param>
        /// <param name="Base">[out, optional] Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleByModuleNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] int StartIndex,
            [Out] out int Index,
            [Out] out long Base);

        /// <summary>
        /// The GetSymbolModuleWide method returns the base address of module which contains the specified symbol.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the name of the symbol to look up. See the Remarks section for details of the syntax of this name.</param>
        /// <param name="Base">[out] Receives the location in the target's memory address space of the base of the module. For more information, see Modules.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The string Symbol must contain an exclamation point ( ! ). If Symbol is a module-qualified symbol name (for example,
        /// mymodules!main) or if the module name is omitted (for example, !main), the engine will search for this symbol and
        /// return the module in which it is found. If Symbol contains just a module name (for example, mymodule!) the engine
        /// returns the first module with this module name. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolModuleWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out long Base);

        /// <summary>
        /// The GetTypeNameWide method returns the name of the type symbol specified by its type ID and module.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type.</param>
        /// <param name="NameBuffer">[out, optional] Receives the name of the type. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="NameBufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the type's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTypeNameWide(
            [In] long Module,
            [In] int TypeId,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] NameBuffer,
            [In] int NameBufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetTypeIdWide method looks up the specified type and return its type ID.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module to which the type belongs. For more information, see Modules. If Name contains a module name, Module is ignored.</param>
        /// <param name="Name">[in] Specifies the name of the type whose type ID is desired. If Name is a module-qualified name (for example mymodule!main), the Module parameter is ignored.</param>
        /// <param name="TypeId">[out] Receives the type ID of the symbol.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the specified symbol is a type, these methods return the type ID for that type; otherwise, they return the type
        /// ID for the type of the symbol. A variable whose type was defined using typedef has a type ID that identifies the
        /// original type, not the type created by typedef. In the following example, the type ID of MyInstance corresponds
        /// to the name MyStruct (this correspondence can be seen by passing the type ID to <see cref="GetTypeName"/>): Moreover,
        /// calling these methods for MyStruct and MyType yields type IDs corresponding to MyStruct and MyType, respectively.
        /// For more information about symbols and symbol names, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTypeIdWide(
            [In] long Module,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out int TypeId);

        /// <summary>
        /// The GetFieldOffsetWide method returns the offset of a field from the base address of an instance of a type.
        /// </summary>
        /// <param name="Module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type containing the field.</param>
        /// <param name="Field">[in] Specifies the name of the field whose offset is requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="Offset">[out] Receives the offset of the specified field from the base memory location of an instance of the type.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the location
        /// of this field relative to the location of MyStruct structure can be found by setting the Field parameter to "MyField.MySubField".
        /// For more information about types, see Types.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFieldOffsetWide(
            [In] long Module,
            [In] int TypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out int Offset);

        /// <summary>
        /// The GetSymbolTypeIdWide method returns the type ID and module of the specified symbol.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the expression whose type ID is requested. See the Remarks section for details on the syntax of this expression.</param>
        /// <param name="TypeId">[out] Receives the type ID.</param>
        /// <param name="Module">[out, optional] Receives the base address of the module containing the symbol. For more information, see Modules.<para/>
        /// If Module is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Symbol expression may contain structure fields, pointer dereferencing, and array dereferencing -- for example
        /// my_struct.some_field[0]. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolTypeIdWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out int TypeId,
            [Out] out long Module);

        /// <summary>
        /// The GetScopeSymbolGroup2 method returns a symbol group containing the symbols in the current target's scope.
        /// </summary>
        /// <param name="Flags">[in] Specifies a bit-set used to determine which symbols to include in the symbol group. To include all symbols, set Flags to DEBUG_SCOPE_GROUP_ALL.<para/>
        /// The following bit-flags determine which symbols are included.</param>
        /// <param name="Update">[in, optional] Specifies a previously created symbol group that will be updated to reflect the current scope. If Update is NULL, a new symbol group interface object is created.</param>
        /// <param name="Symbols">[out] Receives the symbol group interface object for the current scope. For details on this interface, see <see cref="IDebugSymbolGroup"/></param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Update parameter allows for efficient updates when stepping through code. Instead of creating and populating
        /// a new symbol group, the old symbol group can be updated. For more information about scopes and symbol groups, see
        /// Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT GetScopeSymbolGroup2(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, ComAliasName("IDebugSymbolGroup2")] IntPtr Update,
            [Out, ComAliasName("IDebugSymbolGroup2")] out IntPtr Symbols);

        /// <summary>
        /// The CreateSymbolGroup2 method creates a new symbol group.
        /// </summary>
        /// <param name="Group">[out] Receives an interface pointer for the new <see cref="IDebugSymbolGroup"/> object.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The newly created symbol group is empty; it does not contain any symbols. Symbols may be added to the symbol group
        /// using <see cref="IDebugSymbolGroup.AddSymbol"/>. References to the returned object are managed like other COM objects,
        /// using the IUnknown::AddRef and IUnknown::Release methods. In particular, the IUnknown::Release method must be called
        /// when the returned object is no longer needed. See Using Client Objects for more information about using COM interfaces
        /// in the Debugger Engine API. For more information about symbol groups, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateSymbolGroup2(
            [Out, ComAliasName("IDebugSymbolGroup2")] out IntPtr Group);

        /// <summary>
        /// The StartSymbolMatchWide method initializes a search for symbols whose names match a given pattern.
        /// </summary>
        /// <param name="Pattern">[in] Specifies the pattern for which to search. The search will return all symbols whose names match this pattern.<para/>
        /// For details of the syntax of the pattern, see Symbol Syntax and Symbol Matching and String Wildcard Syntax.</param>
        /// <param name="Handle">[out] Receives the handle identifying the search. This handle can be passed to <see cref="GetNextSymbolMatch"/> and <see cref="EndSymbolMatch"/>.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method initializes a symbol search. The results of the search can be obtained by repeated calls to <see cref="GetNextSymbolMatch"/>.
        /// When all the desired results have been found, use <see cref="EndSymbolMatch"/> to release resources the engine
        /// holds for the search. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT StartSymbolMatchWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Pattern,
            [Out] out long Handle);

        /// <summary>
        /// The GetNextSymbolMatchWide method returns the next symbol found in a symbol search.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle returned by <see cref="StartSymbolMatch"/> when the search was initialized.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the symbol. If Buffer is NULL, the same symbol will be returned again next time one of these methods are called (with the same handle); this can be used to determine the size of the name of the symbol.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="MatchSize">[out, optional] Receives the size in characters of the name of the symbol. This size includes the space for the '\0' terminating character.<para/>
        /// If MatchSize is NULL, this information is not returned.</param>
        /// <param name="Offset">[out, optional] Receives the location in the target's virtual address space of the symbol. If Offset is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The search must first be initialized by <see cref="StartSymbolMatch"/>. Once all the desired symbols have been
        /// found, <see cref="EndSymbolMatch"/> can be used to release the resources the engine holds for the search. For more
        /// information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNextSymbolMatchWide(
            [In] long Handle,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int MatchSize,
            [Out] out long Offset);

        /// <summary>
        /// The ReloadWide method deletes the engine's symbol information for the specified module and reload these symbols as needed.
        /// </summary>
        /// <param name="Module">[in] Specifies the module to reload.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method behaves the same way as the debugger command .reload. The Module parameter is treated the same way
        /// as the arguments to .reload. For example, setting the Module parameter to "/u ntdll.dll" has the same effect as
        /// the command .reload /u ntdll.dll. For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT ReloadWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Module);

        /// <summary>
        /// The GetSymbolPathWide method returns the symbol path.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="PathSize">[out, optional] Receives the size, in characters, of the symbol path.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolPathWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);

        /// <summary>
        /// The SetSymbolPathWide method sets the symbol path.
        /// </summary>
        /// <param name="Path">[in] Specifies the new symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        [PreserveSig]
        HRESULT SetSymbolPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);

        /// <summary>
        /// The AppendSymbolPathWide method appends directories to the symbol path.
        /// </summary>
        /// <param name="Addition">[in] Specifies the directories to append to the symbol path. This is a string that contains symbol path elements separated by semicolons (;).<para/>
        /// Each symbol path element can specify either a directory or a symbol server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about manipulating the symbol path, see Using Symbols. For an overview of the symbol path
        /// and its syntax, see Symbol Path.
        /// </remarks>
        [PreserveSig]
        HRESULT AppendSymbolPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);

        /// <summary>
        /// The GetImagePathWide method returns the executable image path.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the executable image path. This is a string that contains directories separated by semicolons (;).<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="PathSize">[out, optional] Receives the size, in characters, of the executable image path.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        [PreserveSig]
        HRESULT GetImagePathWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);

        /// <summary>
        /// The SetImagePathWide method sets the executable image path.
        /// </summary>
        /// <param name="Path">[in] Specifies the new executable image path. This is a string that contains directories separated by semicolons (;).</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons. These directories are searched in order.
        /// </remarks>
        [PreserveSig]
        HRESULT SetImagePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);

        /// <summary>
        /// The AppendImagePathWide method appends directories to the executable image path.
        /// </summary>
        /// <param name="Addition">[in] Specifies the directories to append to the executable image path. This is a string that contains directory names separated by semicolons (;).</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The executable image path is used by the engine when searching for executable images. The executable image path
        /// can consist of several directories separated by semicolons (;). These directories are searched in order.
        /// </remarks>
        [PreserveSig]
        HRESULT AppendImagePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);

        /// <summary>
        /// The GetSourcePathWide method returns the source path.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="PathSize">[out, optional] Receives the size, in characters, of the source path.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSourcePathWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PathSize);

        /// <summary>
        /// The GetSourcePathElementWide method returns an element from the source path.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the element in the source path that will be returned. The source path is a string that contains elements separated by semicolons (;).<para/>
        /// The index of the first element is zero.</param>
        /// <param name="Buffer">[out, optional] Receives the source path element. Each source path element can be a directory or a source server.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="ElementSize">[out, optional] Receives the size, in characters, of the source path element.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSourcePathElementWide(
            [In] int Index,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ElementSize);

        /// <summary>
        /// The SetSourcePathWide method sets the source path.
        /// </summary>
        /// <param name="Path">[in] Specifies the new source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        HRESULT SetSourcePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);

        /// <summary>
        /// The AppendSourcePathWide method appends directories to the source path.
        /// </summary>
        /// <param name="Addition">[in] Specifies the directories to append to the source path. This is a string that contains source path elements separated by semicolons (;).<para/>
        /// Each source path element can specify either a directory or a source server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The source path is used by the engine when searching for source files. For more information about manipulating
        /// the source path, see Using Source Files. For an overview of the source path and its syntax, see Source Path.
        /// </remarks>
        [PreserveSig]
        HRESULT AppendSourcePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);

        /// <summary>
        /// The FindSourceFileWide method searches the source path for a specified source file.
        /// </summary>
        /// <param name="StartElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path.</param>
        /// <param name="File">[in] Specifies the path and file name of the file to search for.</param>
        /// <param name="Flags">[in] Specifies the search flags. For a description of these flags, see DEBUG_FIND_SOURCE_XXX. The flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP should not be set.<para/>
        /// The flag DEBUG_FIND_SOURCE_NO_SRCSRV is ignored because this method does not include source servers in the search.</param>
        /// <param name="FoundElement">[out, optional] Receives the index of the element within the source path that contains the file. If the file was found directly on the filing system (not using the source path) then -1 is returned to FoundElement.<para/>
        /// If FoundElement is NULL, this information is not returned.</param>
        /// <param name="Buffer">[out, optional] Receives the path and name of the found file. If the flag DEBUG_FIND_SOURCE_FULL_PATH is set, this is the full canonical path name for the file.<para/>
        /// Otherwise, it is the concatenation of the directory in the source path with the tail of File that was used to find the file.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in characters, of the Buffer buffer.</param>
        /// <param name="FoundSize">[out, optional] Specifies the size, in characters, of the name of the file. If FoundSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine uses the following steps--in order--to search for the file: If the flag DEBUG_FIND_SOURCE_BEST_MATCH
        /// is set, the match with the longest overlap is returned; otherwise, the first match is returned. The first match
        /// found is returned.
        /// </remarks>
        [PreserveSig]
        HRESULT FindSourceFileWide(
            [In] int StartElement,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 5)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);

        /// <summary>
        /// The GetSourceFileLineOffsetsWide method maps each line in a source file to a location in the target's memory.
        /// </summary>
        /// <param name="File">[in] Specifies the name of the file whose lines will be turned into locations in the target's memory. The symbols for each module in the target are queried for this file.<para/>
        /// If the file is not located, the path is dropped and the symbols are queried again.</param>
        /// <param name="Buffer">[out, optional] Receives the locations in the target's memory that correspond to the lines of the source code. The first entry returned to this array corresponds to the first line of the file, so that Buffer[i] contains the location for line i+1.<para/>
        /// If no symbol information is available for a line, the corresponding entry in Buffer is set to DEBUG_INVALID_OFFSET.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferLines">[in] Specifies the number of PULONG64 objects that the Buffer array can hold.</param>
        /// <param name="FileLines">[out, optional] Receives the number of lines in the source file specified by File.</param>
        /// <returns>This method can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about using the source path, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSourceFileLineOffsetsWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] long[] Buffer,
            [In] int BufferLines,
            [Out] out int FileLines);

        /// <summary>
        /// The GetModuleVersionInformationWide method returns version information for the specified module.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="Base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="Item">[in] Specifies the version information being requested. This string corresponds to the lpSubBlock parameter of the function VerQueryValue.<para/>
        /// For details on the VerQueryValue function, see the Platform SDK.</param>
        /// <param name="Buffer">[out, optional] Receives the requested version information. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="VerInfoSize">[out, optional] Receives the size in characters of the version information. This size includes the space for the '\0' terminating character.<para/>
        /// If VerInfoSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Module version information is available only for loaded modules and may not be available in all sessions. For more
        /// information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleVersionInformationWide(
            [In] int Index,
            [In] long Base,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Item,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int VerInfoSize);

        /// <summary>
        /// The GetModuleNameStringWide method returns the name of the specified module.
        /// </summary>
        /// <param name="Which">[in] Specifies which of the module's names to return, possible values are:</param>
        /// <param name="Index">[in] Specifies the index of the module. If it is set to DEBUG_ANY_ID, the Base parameter is used to specify the location of the module instead.</param>
        /// <param name="Base">[in] If Index is DEBUG_ANY_ID, specifies the location in the target's memory address space of the base of the module.<para/>
        /// Otherwise it is ignored.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the module. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the module's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleNameStringWide(
            [In] DEBUG_MODNAME Which,
            [In] int Index,
            [In] long Base,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetConstantNameWide method returns the name of the specified constant.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module in which the constant was defined.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the constant.</param>
        /// <param name="Value">[in] Specifies the value of the constant.</param>
        /// <param name="Buffer">[out, optional] Receives the constant's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the constant's name. This size includes the space for the '\0' terminating character.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetConstantNameWide(
            [In] long Module,
            [In] int TypeId,
            [In] long Value,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// The GetFieldNameWide method returns the name of a field within a structure.
        /// </summary>
        /// <param name="Module">[in] Specifies the base address of the module in which the structure was defined.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the structure.</param>
        /// <param name="FieldIndex">[in] Specifies the index of the desired field within the structure.</param>
        /// <param name="Buffer">[out, optional] Receives the field's name. If NameBuffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer NameBuffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="NameSize">[out, optional] Receives the size in characters of the field's name. This size includes the space for the '\0' terminating character.<para/>
        /// If NameSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFieldNameWide(
            [In] long Module,
            [In] int TypeId,
            [In] int FieldIndex,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize);

        /// <summary>
        /// Checks whether the engine is using manageddebugging support when it retrieves information for a module.
        /// </summary>
        /// <param name="Index">[in] The index of a module.</param>
        /// <param name="Base">[in] The base of the module.</param>
        /// <returns>IDebugSymbols3::IsManagedModule returns a value of S_OK if the engine is using manageddebugging support when it retrieves information for a module.</returns>
        /// <remarks>
        /// It can be expensive to run this check.
        /// </remarks>
        [PreserveSig]
        HRESULT IsManagedModule(
            [In] int Index,
            [In] long Base);

        /// <summary>
        /// The GetModuleByModuleName2 method searches through the process's modules for one with the specified name.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the desired module.</param>
        /// <param name="StartIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="Flags">[in] Specifies a bit-set containing options used when searching for the module with the specified name. Flags may contain the following bit-flags:</param>
        /// <param name="Index">[out, optional] Receives the index of the first module with the name Name. If Index is NULL, this information is not returned.</param>
        /// <param name="Base">[out, optional] Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleByModuleName2(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] int StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out int Index,
            [Out] out long Base);

        /// <summary>
        /// The GetModuleByModuleName2Wide method searches through the process's modules for one with the specified name.
        /// </summary>
        /// <param name="Name">[in] Specifies the name of the desired module.</param>
        /// <param name="StartIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="Flags">[in] Specifies a bit-set containing options used when searching for the module with the specified name. Flags may contain the following bit-flags:</param>
        /// <param name="Index">[out, optional] Receives the index of the first module with the name Name. If Index is NULL, this information is not returned.</param>
        /// <param name="Base">[out, optional] Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, these methods return the first module they find with the specified name. If the
        /// target has more than one module with this name, then subsequent modules can be found by repeated calls to these
        /// methods with higher values of StartIndex. For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleByModuleName2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] int StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out int Index,
            [Out] out long Base);

        /// <summary>
        /// The GetModuleByOffset2 method searches through the process's modules for one whose memory allocation includes the specified location.
        /// </summary>
        /// <param name="Offset">[in] Specifies a location in the target's virtual address space which is inside the desired module's memory allocation -- for example, the address of a symbol belonging to the module.</param>
        /// <param name="StartIndex">[in] Specifies the index to start searching from.</param>
        /// <param name="Flags">[in] Specifies a bit-set containing options used when searching for the module with the specified location. Flags may contain the following bit-flags:</param>
        /// <param name="Index">[out, optional] Receives the index of the module. If Index is NULL, this information is not returned.</param>
        /// <param name="Base">[out, optional] Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Starting at the specified index, this method returns the first module it finds whose memory allocation address
        /// range includes the specified location. If the target has more than one module whose memory address range includes
        /// this location, then subsequent modules can be found by repeated calls to this method with higher values of StartIndex.
        /// For more information about modules, see Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT GetModuleByOffset2(
            [In] long Offset,
            [In] int StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out int Index,
            [Out] out long Base);

        /// <summary>
        /// The AddSyntheticModule method adds a synthetic module to the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="Base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <param name="Size">[in] Specifies the size in bytes of the synthetic module.</param>
        /// <param name="ImagePath">[in] Specifies the image name of the synthetic module. This is the name that will be returned as the name of the executable file for the synthetic module.<para/>
        /// The full path should be included if known.</param>
        /// <param name="ModuleName">[in] Specifies the module name for the synthetic module.</param>
        /// <param name="Flags">[in] Set to DEBUG_ADDSYNTHMOD_DEFAULT.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The memory region of the synthetic module, described by the Base and Size parameters, must not overlap the memory
        /// region of any other module. If all the modules are reloaded - for example, by calling <see cref="Reload"/> with
        /// the Module parameter set to an empty string - all synthetic modules will be discarded. For more information about
        /// synthetic modules, see Synthetic Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT AddSyntheticModule(
            [In] long Base,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);

        /// <summary>
        /// The AddSyntheticModuleWide method adds a synthetic module to the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="Base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <param name="Size">[in] Specifies the size in bytes of the synthetic module.</param>
        /// <param name="ImagePath">[in] Specifies the image name of the synthetic module. This is the name that will be returned as the name of the executable file for the synthetic module.<para/>
        /// The full path should be included if known.</param>
        /// <param name="ModuleName">[in] Specifies the module name for the synthetic module.</param>
        /// <param name="Flags">[in] Set to DEBUG_ADDSYNTHMOD_DEFAULT.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The memory region of the synthetic module, described by the Base and Size parameters, must not overlap the memory
        /// region of any other module. If all the modules are reloaded - for example, by calling <see cref="Reload"/> with
        /// the Module parameter set to an empty string - all synthetic modules will be discarded. For more information about
        /// synthetic modules, see Synthetic Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT AddSyntheticModuleWide(
            [In] long Base,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);

        /// <summary>
        /// The RemoveSyntheticModule method removes a synthetic module from the module list the debugger maintains for the current process.
        /// </summary>
        /// <param name="Base">[in] Specifies the location in the process's virtual address space of the base of the synthetic module.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If all the modules are reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the empty string - all synthetic modules will be discarded. For more information about synthetic modules, see Synthetic
        /// Modules.
        /// </remarks>
        [PreserveSig]
        HRESULT RemoveSyntheticModule(
            [In] long Base);

        /// <summary>
        /// The GetCurrentScopeFrameIndex method returns the index of the current stack frame in the call stack.
        /// </summary>
        /// <param name="Index">[out] Receives the index of the stack frame corresponding to the current scope. The index counts the number of frames from the top of the call stack.<para/>
        /// The frame at the top of the stack, representing the current call, has index zero.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the current scope was set using <see cref="SetScope"/>, Index receives the value of the FrameNumber member of
        /// the DEBUG_STACK_TRACE structure passed to the ScopeFrame parameter of SetScope. For more information about scopes,
        /// see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentScopeFrameIndex(
            [Out] out int Index);

        /// <summary>
        /// The SetScopeFrameByIndex method sets the current scope to the scope of one of the frames on the call stack.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the stack frame from which to set the scope. The index counts the number of frames from the top of the call stack.<para/>
        /// The frame at the top of the stack, representing the current call, has index zero.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When an event occurs and the debugger engine breaks into a target, the scope is set to the current function call
        /// (the function that was executing when the event occurred). Calling this method with Index set to one will change
        /// the current scope to the caller of the current function; with Index set to two, the scope is changed to the caller's
        /// caller, and so on. For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT SetScopeFrameByIndex(
            [In] int Index);

        /// <summary>
        /// Recovers just-in-time (JIT) debugging information and sets currentdebugger scope context based on that information.
        /// </summary>
        /// <param name="OutputControl">[in] An output control.</param>
        /// <param name="InfoOffset">[in] An offset for the debugging information.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. The method gets JUT debugging information from a specified address from the debugging target, and then sets the currentdebugger scope context from that information.<para/>
        /// This method is equivalent to '.jdinfo' command.</returns>
        [PreserveSig]
        HRESULT SetScopeFromJitDebugInfo(
            [In] int OutputControl,
            [In] long InfoOffset);

        /// <summary>
        /// The SetScopeFromStoredEvent method sets the current scope to the scope of the stored event.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Currently only user-mode Minidumps can contain a stored event. The new scope is printed to the debugger console.
        /// For more information about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT SetScopeFromStoredEvent();

        /// <summary>
        /// The OutputSymbolByOffset method looks up a symbol by address and prints the symbol name and other symbol information to the debugger console.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="Flags">[in] Specifies the flags used to determine what information is printed with the symbol. The following flags can be present: This allows the Offset parameter to specify any address within the symbol's memory allocation - not just the base address.</param>
        /// <param name="Offset">[in] Specifies the location in the process's virtual address space of the symbol to be printed.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT OutputSymbolByOffset(
            [In] int OutputControl,
            [In] DEBUG_OUTSYM Flags,
            [In] long Offset);

        /// <summary>
        /// The GetFunctionEntryByOffset method returns the function entry information for a function.
        /// </summary>
        /// <param name="Offset">[in] Specifies a location in the current process's virtual address space of the function's implementation. This is the value returned in the Offset parameter of <see cref="GetNextSymbolMatch"/> and <see cref="IDebugSymbolGroup2.GetSymbolOffset"/>, and the value of the Offset field in the <see cref="DEBUG_SYMBOL_ENTRY"/> structure.</param>
        /// <param name="Flags">[in] Specifies a bit-flag which alters the behavior of this method. If the bit DEBUG_GETFNENT_RAW_ENTRY_ONLY is not set, the engine will provide artificial entries for well known cases.<para/>
        /// If this bit is set the artificial entries are not used.</param>
        /// <param name="Buffer">[out, optional] Receives the function entry information. If the effective processor is an x86, this is the FPO_DATA structure for the function.<para/>
        /// For all other architectures, this is the IMAGE_FUNCTION_ENTRY structure for that architecture.</param>
        /// <param name="BufferSize">[in] Specifies the size of the buffer Buffer.</param>
        /// <param name="BufferNeeded">[out, optional] Specifies the size of the function entry information.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The structures FPO_DATA and IMAGE_FUNCTION_ENTRY are documented in "Image Help Library" which is included in Debugging
        /// Tools For Windows in the DbgHelp.chm file.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFunctionEntryByOffset(
            [In] long Offset,
            [In] DEBUG_GETFNENT Flags,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int BufferNeeded);

        /// <summary>
        /// The GetFieldTypeAndOffset method returns the type of a field and its offset within a container.
        /// </summary>
        /// <param name="Module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="ContainerTypeId">[in] Specifies the type ID for the container's type. Examples of containers include structures, unions, and classes.</param>
        /// <param name="Field">[in] Specifies the name of the field whose type and offset are requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="FieldTypeId">[out, optional] Receives the type ID of the field.</param>
        /// <param name="Offset">[out, optional] Receives the offset of the field Field from the base memory location of an instance of the container.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the type
        /// of this field and its location relative to the location of MyStruct structure can be found by passing "MyField.MySubField"
        /// as the Field parameter to this method. For more information about types, see Types. For more information about
        /// symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFieldTypeAndOffset(
            [In] long Module,
            [In] int ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out int FieldTypeId,
            [Out] out int Offset);

        /// <summary>
        /// The GetFieldTypeAndOffsetWide method returns the type of a field and its offset within a container.
        /// </summary>
        /// <param name="Module">[in] Specifies the module containing the types of both the container and the field.</param>
        /// <param name="ContainerTypeId">[in] Specifies the type ID for the container's type. Examples of containers include structures, unions, and classes.</param>
        /// <param name="Field">[in] Specifies the name of the field whose type and offset are requested. Subfields may be specified by using a dot-separated path.</param>
        /// <param name="FieldTypeId">[out, optional] Receives the type ID of the field.</param>
        /// <param name="Offset">[out, optional] Receives the offset of the field Field from the base memory location of an instance of the container.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// An example of a dot-separated path for the Field parameter is as follows. Suppose the MyStruct structure contains
        /// a field MyField of type MySubStruct, and the MySubStruct structure contains the field MySubField. Then the type
        /// of this field and its location relative to the location of MyStruct structure can be found by passing "MyField.MySubField"
        /// as the Field parameter to this method. For more information about types, see Types. For more information about
        /// symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFieldTypeAndOffsetWide(
            [In] long Module,
            [In] int ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out int FieldTypeId,
            [Out] out int Offset);

        /// <summary>
        /// The AddSyntheticSymbol method adds a synthetic symbol to a module in the current process.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the process's virtual address space of the synthetic symbol.</param>
        /// <param name="Size">[in] Specifies the size in bytes of the synthetic symbol.</param>
        /// <param name="Name">[in] Specifies the name of the synthetic symbol.</param>
        /// <param name="Flags">[in] Set to DEBUG_ADDSYNTHSYM_DEFAULT.</param>
        /// <param name="Id">[out, optional] Receives the <see cref="DEBUG_MODULE_AND_ID"/> structure that identifies the synthetic symbol. If Id is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The location of the synthetic symbol must not be the same as the location of another symbol. If the module containing
        /// a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the name of the module - the synthetic symbol will be discarded. For more information about synthetic symbols,
        /// see Synthetic Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT AddSyntheticSymbol(
            [In] long Offset,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);

        /// <summary>
        /// The AddSyntheticSymbolWide method adds a synthetic symbol to a module in the current process.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the process's virtual address space of the synthetic symbol.</param>
        /// <param name="Size">[in] Specifies the size in bytes of the synthetic symbol.</param>
        /// <param name="Name">[in] Specifies the name of the synthetic symbol.</param>
        /// <param name="Flags">[in] Set to DEBUG_ADDSYNTHSYM_DEFAULT.</param>
        /// <param name="Id">[out, optional] Receives the <see cref="DEBUG_MODULE_AND_ID"/> structure that identifies the synthetic symbol. If Id is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The location of the synthetic symbol must not be the same as the location of another symbol. If the module containing
        /// a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the Module parameter set to
        /// the name of the module - the synthetic symbol will be discarded. For more information about synthetic symbols,
        /// see Synthetic Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT AddSyntheticSymbolWide(
            [In] long Offset,
            [In] int Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);

        /// <summary>
        /// The RemoveSyntheticSymbol method removes a synthetic symbol from a module in the current process.
        /// </summary>
        /// <param name="Id">[in] Specifies the synthetic symbol to remove. This must be the same value returned in the Id parameter of <see cref="AddSyntheticSymbol"/>.<para/>
        /// See <see cref="DEBUG_MODULE_AND_ID"/> for details about the type of this parameter.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If the module containing a synthetic symbol is reloaded - for example, by calling <see cref="Reload"/> with the
        /// Module parameter set to the name of the module - the synthetic symbol will be discarded. For more information about
        /// synthetic symbols, see Synthetic Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT RemoveSyntheticSymbol(
            [In] ref DEBUG_MODULE_AND_ID Id);

        /// <summary>
        /// The GetSymbolEntriesByOffset method returns the symbols which are located at a specified address.
        /// </summary>
        /// <param name="Offset">[in] Specifies a location in the process's memory address space within the desired symbol's range. Not all symbols have a known range, so, for best results, use the base address of the symbol.</param>
        /// <param name="Flags">[in] Set to zero.</param>
        /// <param name="Ids">[out, optional] Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.</param>
        /// <param name="Displacements">[out, optional] Receives the differences between the base addresses of the found symbols and the given address according to the symbol's range.</param>
        /// <param name="IdsCount">[in] Specifies the number of entries that the arrays Ids and Displacements can hold.</param>
        /// <param name="Entries">[out, optional] Receives the number of symbols located at Offset. If Entries is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolEntriesByOffset(
            [In] long Offset,
            [In] int Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_MODULE_AND_ID[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] long[] Displacements,
            [In] int IdsCount,
            [Out] out int Entries);

        /// <summary>
        /// The GetSymbolEntriesByName method returns the symbols whose names match a given pattern.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the pattern used to determine which symbols to return. This method returns the symbols whose name matches the string wildcard syntax pattern Symbol.</param>
        /// <param name="Flags">[in] Set to zero.</param>
        /// <param name="Ids">[out, optional] Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.</param>
        /// <param name="IdsCount">[in] Specifies the number of entries that the array Ids can hold.</param>
        /// <param name="Entries">[out, optional] Receives the number of symbols whose names match the pattern Symbol. If entries is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolEntriesByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [In] int Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_MODULE_AND_ID[] Ids,
            [In] int IdsCount,
            [Out] out int Entries);

        /// <summary>
        /// The GetSymbolEntriesByNameWide method returns the symbols whose names match a given pattern.
        /// </summary>
        /// <param name="Symbol">[in] Specifies the pattern used to determine which symbols to return. This method returns the symbols whose name matches the string wildcard syntax pattern Symbol.</param>
        /// <param name="Flags">[in] Set to zero.</param>
        /// <param name="Ids">[out, optional] Receives the symbols. This is an array of IdsCount entries of type <see cref="DEBUG_MODULE_AND_ID"/>.<para/>
        /// If Ids is NULL, this information is not returned.</param>
        /// <param name="IdsCount">[in] Specifies the number of entries that the array Ids can hold.</param>
        /// <param name="Entries">[out, optional] Receives the number of symbols whose names match the pattern Symbol. If entries is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolEntriesByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [In] int Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_MODULE_AND_ID[] Ids,
            [In] int IdsCount,
            [Out] out int Entries);

        /// <summary>
        /// Looks up a symbol by using a managed metadata token.
        /// </summary>
        /// <param name="ModuleBase">[in] The base of the module.</param>
        /// <param name="Token">[in] The token to use to look up the symbol.</param>
        /// <param name="Id">[out] A pointer to the module as a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT GetSymbolEntryByToken(
            [In] long ModuleBase,
            [In] int Token,
            [Out] out DEBUG_MODULE_AND_ID Id);

        /// <summary>
        /// The GetSymbolEntryInformation method returns the symbol entry information for a symbol.
        /// </summary>
        /// <param name="Id">[in] Specifies the module and symbol ID of the desired symbol. For details on this structure, see <see cref="DEBUG_MODULE_AND_ID"/>.</param>
        /// <param name="Info">[out] Receives the symbol entry information for the symbol. For details on this structure, see <see cref="DEBUG_SYMBOL_ENTRY"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For details on the symbol entry information, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolEntryInformation(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [Out] out DEBUG_SYMBOL_ENTRY Info);

        /// <summary>
        /// The GetSymbolEntryString method returns string information for the specified symbol.
        /// </summary>
        /// <param name="Id">[in] Specifies the symbols whose memory regions are being requested. The <see cref="DEBUG_MODULE_AND_ID"/> structure contains the module containing the symbol and the symbol ID of the symbol within the module.</param>
        /// <param name="Which">[in] Specifies the index of the desired string. Often this is zero, as most symbols contain just one string (their name).<para/>
        /// But some symbols may contain more than one string -- for example, annotation symbols.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the symbol. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="StringSize">[out, optional] Receives the size in characters of the symbol's name. This size includes the space for the '\0' terminating character.<para/>
        /// If StringSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolEntryString(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [In] int Which,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);

        /// <summary>
        /// The GetSymbolEntryStringWide method returns string information for the specified symbol.
        /// </summary>
        /// <param name="Id">[in] Specifies the symbols whose memory regions are being requested. The <see cref="DEBUG_MODULE_AND_ID"/> structure contains the module containing the symbol and the symbol ID of the symbol within the module.</param>
        /// <param name="Which">[in] Specifies the index of the desired string. Often this is zero, as most symbols contain just one string (their name).<para/>
        /// But some symbols may contain more than one string -- for example, annotation symbols.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the symbol. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="StringSize">[out, optional] Receives the size in characters of the symbol's name. This size includes the space for the '\0' terminating character.<para/>
        /// If StringSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about symbols, see Symbols.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSymbolEntryStringWide(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [In] int Which,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);

        /// <summary>
        /// Returns all the memory regions known to be associated with a symbol.
        /// </summary>
        /// <param name="Id">[in] The ID of a module as a pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure.</param>
        /// <param name="Flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="Regions">[out] The memory regions associated with the symbol.</param>
        /// <param name="RegionsCount">[in] The number of regions associated with the symbol.</param>
        /// <param name="RegionsAvail">[out, optional] A pointer to the number of regions available to the symbol.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This function returns all known memory regions that associated with a specified symbol.<para/>
        /// Simple symbols have a single region that starts from their base. More complicated regions, such as functions that have multiple code areas, can have an arbitrarilylarge number of regions.<para/>
        /// The quality of information returned is highlydependent on the symbolic information available.</returns>
        [PreserveSig]
        HRESULT GetSymbolEntryOffsetRegions(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [In] int Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_OFFSET_REGION[] Regions,
            [In] int RegionsCount,
            [Out] out int RegionsAvail);

        /// <summary>
        /// Allows navigation within thesymbol entry hierarchy.
        /// </summary>
        /// <param name="FromId">[in] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the input ID.</param>
        /// <param name="Flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="ToId">[out] A pointer to a <see cref="DEBUG_MODULE_AND_ID"/> structure as the output ID.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT GetSymbolEntryBySymbolEntry(
            [In] ref DEBUG_MODULE_AND_ID FromId,
            [In] int Flags,
            [Out] out DEBUG_MODULE_AND_ID ToId);

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory by using an offset.
        /// </summary>
        /// <param name="Offset">[in] The offset of the entry.</param>
        /// <param name="Flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="Entries">[out] A pointer to a returned entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="EntriesCount">[in] The number of entries.</param>
        /// <param name="EntriesAvail">[out, optional] A pointer to the number of entries available.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT GetSourceEntriesByOffset(
            [In] long Offset,
            [In] int Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] int EntriesCount,
            [Out] out int EntriesAvail);

        /// <summary>
        /// The GetSourceEntriesByLine method queries symbol information and returns locations in the target's memory that correspond to lines in a source file.
        /// </summary>
        /// <param name="Line">[in] Specifies the line in the source file for which to query. The number for the first line is 1.</param>
        /// <param name="File">[in] Specifies the source file. The symbols for each module in the target are queried for this file.</param>
        /// <param name="Flags">[in] Specifies bit flags that control the behavior of this method. Flags can be any combination of values from the following table.<para/>
        /// If this option is not set, the debugger engine will load the symbols for all modules until it finds the file specified in File.<para/>
        /// To use the default set of flags, set Flags to DEBUG_GSEL_DEFAULT. This has all the flags in the previous table turned off.</param>
        /// <param name="Entries">[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for. Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</param>
        /// <param name="EntriesCount">[in] Specifies the number of entries in the Entries array.</param>
        /// <param name="EntriesAvail">[out, optional] Receives the number of locations that match the query found in the target's memory.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSourceEntriesByLine(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_GSEL Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] int EntriesCount,
            [Out] out int EntriesAvail);

        /// <summary>
        /// The GetSourceEntriesByLineWide method queries symbol information and returns locations in the target's memory that correspond to lines in a source file.
        /// </summary>
        /// <param name="Line">[in] Specifies the line in the source file for which to query. The number for the first line is 1.</param>
        /// <param name="File">[in] Specifies the source file. The symbols for each module in the target are queried for this file.</param>
        /// <param name="Flags">[in] Specifies bit flags that control the behavior of this method. Flags can be any combination of values from the following table.<para/>
        /// If this option is not set, the debugger engine will load the symbols for all modules until it finds the file specified in File.<para/>
        /// To use the default set of flags, set Flags to DEBUG_GSEL_DEFAULT. This has all the flags in the previous table turned off.</param>
        /// <param name="Entries">[out, optional] Receives the locations in the target's memory that correspond to the source lines queried for. Each entry in this array is of type <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> and contains the source line number along with a location in the target's memory.</param>
        /// <param name="EntriesCount">[in] Specifies the number of entries in the Entries array.</param>
        /// <param name="EntriesAvail">[out, optional] Receives the number of locations that match the query found in the target's memory.</param>
        /// <returns>These methods can also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods can be used by debugger applications to fetch locations in the target's memory for setting breakpoints
        /// or matching source code with disassembled instructions. For example, setting the flags DEBUG_GSEL_ALLOW_HIGHER
        /// and DEBUG_GSEL_NEAREST_ONLY will return the target's memory location for the first piece of code starting at the
        /// specified line. For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSourceEntriesByLineWide(
            [In] int Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_GSEL Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] int EntriesCount,
            [Out] out int EntriesAvail);

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory.
        /// </summary>
        /// <param name="Entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="Which">[in] A value that determines which types to return.</param>
        /// <param name="Buffer">[out] A pointer to a string buffer for the results.</param>
        /// <param name="BufferSize">[in] The size of the buffer.</param>
        /// <param name="StringSize">[out, optional] Pointer to the size of the string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This method can return multiple results for a source lookup.<para/>
        /// This allows for all possible results to be returned.</returns>
        [PreserveSig]
        HRESULT GetSourceEntryString(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] int Which,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);

        /// <summary>
        /// Queries symbol information and returns locations in the target's memory.
        /// </summary>
        /// <param name="Entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="Which">[in] A value that determines which types to return.</param>
        /// <param name="Buffer">[out] A pointer to a Unicode character string buffer for the results.</param>
        /// <param name="BufferSize">[in] The size of the buffer.</param>
        /// <param name="StringSize">[out, optional] Pointer to the size of the string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This method can return multiple results for a source lookup.<para/>
        /// This allows for all possible results to be returned.</returns>
        [PreserveSig]
        HRESULT GetSourceEntryStringWide(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] int Which,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);

        /// <summary>
        /// Returns all memory regions known to be associated with a source entry.
        /// </summary>
        /// <param name="Entry">[in] An entry as a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> structure.</param>
        /// <param name="Flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="Regions">[out] The memory regions associated with the source entry.</param>
        /// <param name="RegionsCount">[in] The number of regions associated with the entry.</param>
        /// <param name="RegionsAvail">[out, optional] A pointer to the number of regions available to the entry.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This function returns all known memory regions that associated with a specified source entry.<para/>
        /// Simple symbols have a single region that starts from their base. More complicated regions, such as functions that have multiple code areas, can have an arbitrarilylarge number of regions.</returns>
        [PreserveSig]
        HRESULT GetSourceEntryOffsetRegions(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] int Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEBUG_OFFSET_REGION[] Regions,
            [In] int RegionsCount,
            [Out] out int RegionsAvail);

        /// <summary>
        /// Allows navigation within the source entries.
        /// </summary>
        /// <param name="FromEntry">[in] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the input entry.</param>
        /// <param name="Flags">[in] A bit-set that contains options that affect the behavior of this method.</param>
        /// <param name="ToEntry">[out] A pointer to a <see cref="DEBUG_SYMBOL_SOURCE_ENTRY"/> as the output entry.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT GetSourceEntryBySourceEntry(
            [In] ref DEBUG_SYMBOL_SOURCE_ENTRY FromEntry,
            [In] int Flags,
            [Out] out DEBUG_SYMBOL_SOURCE_ENTRY ToEntry);

        #endregion
    }
}

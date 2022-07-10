using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3a707211-afdd-4495-ad4f-56fecdf8163f")]
    [ComImport]
    public interface IDebugSymbols2 : IDebugSymbols
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
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

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
            [Out] out ulong Offset);

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
            [In] ulong Offset,
            [In] int Delta,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

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
            [In] ulong Offset,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);

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
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out ulong Offset);

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
            [Out] out uint Loaded,
            [Out] out uint Unloaded);

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
            [In] uint Index,
            [Out] out ulong Base);

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
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

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
            [In] ulong Offset,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

        /// <summary>
        /// The GetModuleNames method returns the names of the specified module.
        /// </summary>
        /// <param name="Index">[in] Specifies the index of the module whose names are requested. If it is set to DEBUG_ANY_ID, the module is specified by Base.</param>
        /// <param name="Base">[in] Specifies the base address of the module whose names are requested. This parameter is only used if Index is set to DEBUG_ANY_ID.</param>
        /// <param name="ImageNameBuffer">[out, optional] Receives the image name of the module. If ImageNameBuffer is NULL, this information is not returned.</param>
        /// <param name="ImageNameBufferSize">[in] Specifies the size in characters of the buffer ImageNameBuffer in characters. This size includes the space for the '\0' terminating character.</param>
        /// <param name="ImageNameSize">[out, optional] Receives the size in characters of the image name. This size includes the space for the '\0' terminating character.<para/>
        /// If ImageNameSize is NULL, this information is not returned.</param>
        /// <param name="ModuleNameBuffer">[out, optional] Receives the module name of the module. If ModuleNameBuffer is NULL, this information is not returned.</param>
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
            [Out] out uint LoadedImageNameSize);

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
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] ulong[] Bases,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_PARAMETERS[] Params);

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
            [Out] out ulong Base);

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
            [In] ulong Module,
            [In] uint TypeId,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize);

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
            [In] ulong Module,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint TypeId);

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
            [In] ulong Module,
            [In] uint TypeId,
            [Out] out uint Size);

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
            [In] ulong Module,
            [In] uint TypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out uint Offset);

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
            [Out] out uint TypeId,
            [Out] out ulong Module);

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
            [In] ulong Offset,
            [Out] out uint TypeId,
            [Out] out ulong Module);

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
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

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
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        /// The OutputTypedDataVirtual method formats the contents of a variable in the target's virtual memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the variable.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type.</param>
        /// <param name="Flags">[in] Specifies the formatting flags. See DEBUG_TYPEOPTS_XXX for possible values.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The output produced by this method is the same as for the debugger command DT. See dt (Display Type). For more
        /// information about types, see Types. For more information about output, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputTypedDataVirtual(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);

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
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

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
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        /// The OutputTypedDataPhysical method formats the contents of a variable in the target computer's physical memory, and then sends this to the output callbacks.
        /// </summary>
        /// <param name="OutputControl">[in] Specifies the output control used to determine which output callbacks can receive the output. See DEBUG_OUTCTL_XXX for possible values.</param>
        /// <param name="Offset">[in] Specifies the physical address in the target computer's memory of the variable.</param>
        /// <param name="Module">[in] Specifies the base address of the module containing the type of the variable.</param>
        /// <param name="TypeId">[in] Specifies the type ID of the type of the variable.</param>
        /// <param name="Flags">[in] Specifies the bit-set containing the formatting options. See DEBUG_TYPEOPTS_XXX for possible values.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel mode debugging. The output produced by this method is the same as for the
        /// debugger command DT. See dt (Display Type). For more information about types, see Types. For information about
        /// output, see Input and Output.
        /// </remarks>
        [PreserveSig]
        new HRESULT OutputTypedDataPhysical(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);

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
            [Out] out ulong InstructionOffset,
            [Out] out DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

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
        /// to a frame on the current stack, <see cref="IDebugSymbols3.SetScopeFrameByIndex"/> can be used. For more information
        /// about scopes, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetScope(
            [In] ulong InstructionOffset,
            [In] DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

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
            [Out] out ulong Handle);

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
            [In] ulong Handle,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MatchSize,
            [Out] out ulong Offset);

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
            [In] ulong Handle);

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
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

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
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

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
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

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
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ElementSize);

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
            [In] uint StartElement,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out uint FoundElement,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FoundSize);

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
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Buffer,
            [In] int BufferLines,
            [Out] out uint FileLines);

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
        HRESULT GetModuleVersionInformation(
            [In] uint Index,
            [In] ulong Base,
            [In, MarshalAs(UnmanagedType.LPStr)] string Item,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint VerInfoSize);

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
        HRESULT GetModuleNameString(
            [In] DEBUG_MODNAME Which,
            [In] uint Index,
            [In] ulong Base,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint NameSize);

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
        HRESULT GetConstantName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] ulong Value,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

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
        HRESULT GetFieldName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] uint FieldIndex,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

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
        HRESULT GetTypeOptions(
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
        HRESULT AddTypeOptions(
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
        HRESULT RemoveTypeOptions(
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
        HRESULT SetTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        #endregion
    }
}

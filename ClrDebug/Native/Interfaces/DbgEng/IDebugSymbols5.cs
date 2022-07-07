using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("c65fa83e-1e69-475e-8e0e-b5d79e9cc17e")]
    [ComImport]
    public interface IDebugSymbols5 : IDebugSymbols4
    {
        #region IDebugSymbols

        [PreserveSig]
        new HRESULT GetSymbolOptions(
            [Out] out SYMOPT Options);

        [PreserveSig]
        new HRESULT AddSymbolOptions(
            [In] SYMOPT Options);

        [PreserveSig]
        new HRESULT RemoveSymbolOptions(
            [In] SYMOPT Options);

        [PreserveSig]
        new HRESULT SetSymbolOptions(
            [In] SYMOPT Options);

        [PreserveSig]
        new HRESULT GetNameByOffset(
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetOffsetByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetNearNameByOffset(
            [In] ulong Offset,
            [In] int Delta,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetLineByOffset(
            [In] ulong Offset,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetOffsetByLine(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetNumberModules(
            [Out] out uint Loaded,
            [Out] out uint Unloaded);

        [PreserveSig]
        new HRESULT GetModuleByIndex(
            [In] uint Index,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT GetModuleByModuleName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT GetModuleByOffset(
            [In] ulong Offset,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

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

        [PreserveSig]
        new HRESULT GetModuleParameters(
            [In] uint Count,
            [In, MarshalAs(UnmanagedType.LPArray)] ulong[] Bases,
            [In] uint Start,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_PARAMETERS[] Params);

        [PreserveSig]
        new HRESULT GetSymbolModule(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT GetTypeName(
            [In] ulong Module,
            [In] uint TypeId,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetTypeId(
            [In] ulong Module,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [Out] out uint TypeId);

        [PreserveSig]
        new HRESULT GetTypeSize(
            [In] ulong Module,
            [In] uint TypeId,
            [Out] out uint Size);

        [PreserveSig]
        new HRESULT GetFieldOffset(
            [In] ulong Module,
            [In] uint TypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out uint Offset);

        [PreserveSig]
        new HRESULT GetSymbolTypeId(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [Out] out uint TypeId,
            [Out] out ulong Module);

        [PreserveSig]
        new HRESULT GetOffsetTypeId(
            [In] ulong Offset,
            [Out] out uint TypeId,
            [Out] out ulong Module);

        [PreserveSig]
        new HRESULT ReadTypedDataVirtual(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WriteTypedDataVirtual(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT OutputTypedDataVirtual(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);

        [PreserveSig]
        new HRESULT ReadTypedDataPhysical(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        [PreserveSig]
        new HRESULT WriteTypedDataPhysical(
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        [PreserveSig]
        new HRESULT OutputTypedDataPhysical(
            [In] DEBUG_OUTCTL OutputControl,
            [In] ulong Offset,
            [In] ulong Module,
            [In] uint TypeId,
            [In] DEBUG_TYPEOPTS Flags);

        [PreserveSig]
        new HRESULT GetScope(
            [Out] out ulong InstructionOffset,
            [Out] out DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

        [PreserveSig]
        new HRESULT SetScope(
            [In] ulong InstructionOffset,
            [In] DEBUG_STACK_FRAME ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

        [PreserveSig]
        new HRESULT ResetScope();

        [PreserveSig]
        new HRESULT GetScopeSymbolGroup(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugSymbolGroup Update,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup Symbols);

        [PreserveSig]
        new HRESULT CreateSymbolGroup(
            [Out, MarshalAs(UnmanagedType.Interface)]
            out IDebugSymbolGroup Group);

        [PreserveSig]
        new HRESULT StartSymbolMatch(
            [In, MarshalAs(UnmanagedType.LPStr)] string Pattern,
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT GetNextSymbolMatch(
            [In] ulong Handle,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MatchSize,
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT EndSymbolMatch(
            [In] ulong Handle);

        [PreserveSig]
        new HRESULT Reload(
            [In, MarshalAs(UnmanagedType.LPStr)] string Module);

        [PreserveSig]
        new HRESULT GetSymbolPath(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        [PreserveSig]
        new HRESULT SetSymbolPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);

        [PreserveSig]
        new HRESULT AppendSymbolPath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);

        [PreserveSig]
        new HRESULT GetImagePath(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        [PreserveSig]
        new HRESULT SetImagePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);

        [PreserveSig]
        new HRESULT AppendImagePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);

        [PreserveSig]
        new HRESULT GetSourcePath(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        [PreserveSig]
        new HRESULT GetSourcePathElement(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ElementSize);

        [PreserveSig]
        new HRESULT SetSourcePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Path);

        [PreserveSig]
        new HRESULT AppendSourcePath(
            [In, MarshalAs(UnmanagedType.LPStr)] string Addition);

        [PreserveSig]
        new HRESULT FindSourceFile(
            [In] uint StartElement,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out uint FoundElement,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FoundSize);

        [PreserveSig]
        new HRESULT GetSourceFileLineOffsets(
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Buffer,
            [In] int BufferLines,
            [Out] out uint FileLines);

        #endregion
        #region IDebugSymbols2

        [PreserveSig]
        new HRESULT GetModuleVersionInformation(
            [In] uint Index,
            [In] ulong Base,
            [In, MarshalAs(UnmanagedType.LPStr)] string Item,
            [Out] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint VerInfoSize);

        [PreserveSig]
        new HRESULT GetModuleNameString(
            [In] DEBUG_MODNAME Which,
            [In] uint Index,
            [In] ulong Base,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetConstantName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] ulong Value,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetFieldName(
            [In] ulong Module,
            [In] uint TypeId,
            [In] uint FieldIndex,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetTypeOptions(
            [Out] out DEBUG_TYPEOPTS Options);

        [PreserveSig]
        new HRESULT AddTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        [PreserveSig]
        new HRESULT RemoveTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        [PreserveSig]
        new HRESULT SetTypeOptions(
            [In] DEBUG_TYPEOPTS Options);

        #endregion
        #region IDebugSymbols3

        [PreserveSig]
        new HRESULT GetNameByOffsetWide(
            [In] ulong Offset,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetOffsetByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetNearNameByOffsetWide(
            [In] ulong Offset,
            [In] int Delta,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetLineByOffsetWide(
            [In] ulong Offset,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetOffsetByLineWide(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetModuleByModuleNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] uint StartIndex,
            [Out] out uint Index,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT GetSymbolModuleWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT GetTypeNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetTypeIdWide(
            [In] ulong Module,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [Out] out uint TypeId);

        [PreserveSig]
        new HRESULT GetFieldOffsetWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out uint Offset);

        [PreserveSig]
        new HRESULT GetSymbolTypeIdWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [Out] out uint TypeId,
            [Out] out ulong Module);

        [PreserveSig]
        new HRESULT GetScopeSymbolGroup2(
            [In] DEBUG_SCOPE_GROUP Flags,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugSymbolGroup2 Update,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup2 Symbols);

        [PreserveSig]
        new HRESULT CreateSymbolGroup2(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugSymbolGroup2 Group);

        [PreserveSig]
        new HRESULT StartSymbolMatchWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Pattern,
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT GetNextSymbolMatchWide(
            [In] ulong Handle,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint MatchSize,
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT ReloadWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Module);

        [PreserveSig]
        new HRESULT GetSymbolPathWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        [PreserveSig]
        new HRESULT SetSymbolPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);

        [PreserveSig]
        new HRESULT AppendSymbolPathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);

        [PreserveSig]
        new HRESULT GetImagePathWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        [PreserveSig]
        new HRESULT SetImagePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);

        [PreserveSig]
        new HRESULT AppendImagePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);

        [PreserveSig]
        new HRESULT GetSourcePathWide(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint PathSize);

        [PreserveSig]
        new HRESULT GetSourcePathElementWide(
            [In] uint Index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ElementSize);

        [PreserveSig]
        new HRESULT SetSourcePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Path);

        [PreserveSig]
        new HRESULT AppendSourcePathWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Addition);

        [PreserveSig]
        new HRESULT FindSourceFileWide(
            [In] uint StartElement,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] out uint FoundElement,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint FoundSize);

        [PreserveSig]
        new HRESULT GetSourceFileLineOffsetsWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Buffer,
            [In] int BufferLines,
            [Out] out uint FileLines);

        [PreserveSig]
        new HRESULT GetModuleVersionInformationWide(
            [In] uint Index,
            [In] ulong Base,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Item,
            [In] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out uint VerInfoSize);

        [PreserveSig]
        new HRESULT GetModuleNameStringWide(
            [In] DEBUG_MODNAME Which,
            [In] uint Index,
            [In] ulong Base,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetConstantNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In] ulong Value,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT GetFieldNameWide(
            [In] ulong Module,
            [In] uint TypeId,
            [In] uint FieldIndex,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint NameSize);

        [PreserveSig]
        new HRESULT IsManagedModule(
            [In] uint Index,
            [In] ulong Base);

        [PreserveSig]
        new HRESULT GetModuleByModuleName2(
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT GetModuleByModuleName2Wide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT GetModuleByOffset2(
            [In] ulong Offset,
            [In] uint StartIndex,
            [In] DEBUG_GETMOD Flags,
            [Out] out uint Index,
            [Out] out ulong Base);

        [PreserveSig]
        new HRESULT AddSyntheticModule(
            [In] ulong Base,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);

        [PreserveSig]
        new HRESULT AddSyntheticModuleWide(
            [In] ulong Base,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ImagePath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ModuleName,
            [In] DEBUG_ADDSYNTHMOD Flags);

        [PreserveSig]
        new HRESULT RemoveSyntheticModule(
            [In] ulong Base);

        [PreserveSig]
        new HRESULT GetCurrentScopeFrameIndex(
            [Out] out uint Index);

        [PreserveSig]
        new HRESULT SetScopeFrameByIndex(
            [In] uint Index);

        [PreserveSig]
        new HRESULT SetScopeFromJitDebugInfo(
            [In] uint OutputControl,
            [In] ulong InfoOffset);

        [PreserveSig]
        new HRESULT SetScopeFromStoredEvent();

        [PreserveSig]
        new HRESULT OutputSymbolByOffset(
            [In] uint OutputControl,
            [In] DEBUG_OUTSYM Flags,
            [In] ulong Offset);

        [PreserveSig]
        new HRESULT GetFunctionEntryByOffset(
            [In] ulong Offset,
            [In] DEBUG_GETFNENT Flags,
            [In] IntPtr Buffer,
            [In] uint BufferSize,
            [Out] out uint BufferNeeded);

        [PreserveSig]
        new HRESULT GetFieldTypeAndOffset(
            [In] ulong Module,
            [In] uint ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPStr)] string Field,
            [Out] out uint FieldTypeId,
            [Out] out uint Offset);

        [PreserveSig]
        new HRESULT GetFieldTypeAndOffsetWide(
            [In] ulong Module,
            [In] uint ContainerTypeId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Field,
            [Out] out uint FieldTypeId,
            [Out] out uint Offset);

        [PreserveSig]
        new HRESULT AddSyntheticSymbol(
            [In] ulong Offset,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);

        [PreserveSig]
        new HRESULT AddSyntheticSymbolWide(
            [In] ulong Offset,
            [In] uint Size,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Name,
            [In] DEBUG_ADDSYNTHSYM Flags,
            [Out] out DEBUG_MODULE_AND_ID Id);

        [PreserveSig]
        new HRESULT RemoveSyntheticSymbol(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id);

        [PreserveSig]
        new HRESULT GetSymbolEntriesByOffset(
            [In] ulong Offset,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray)] ulong[] Displacements,
            [In] uint IdsCount,
            [Out] out uint Entries);

        [PreserveSig]
        new HRESULT GetSymbolEntriesByName(
            [In, MarshalAs(UnmanagedType.LPStr)] string Symbol,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids,
            [In] uint IdsCount,
            [Out] out uint Entries);

        [PreserveSig]
        new HRESULT GetSymbolEntriesByNameWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Symbol,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_MODULE_AND_ID[] Ids,
            [In] uint IdsCount,
            [Out] out uint Entries);

        [PreserveSig]
        new HRESULT GetSymbolEntryByToken(
            [In] ulong ModuleBase,
            [In] uint Token,
            [Out] out DEBUG_MODULE_AND_ID Id);

        [PreserveSig]
        new HRESULT GetSymbolEntryInformation(
            [In] ref DEBUG_MODULE_AND_ID Id,
            [Out] out DEBUG_SYMBOL_ENTRY Info);

        [PreserveSig]
        new HRESULT GetSymbolEntryString(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        new HRESULT GetSymbolEntryStringWide(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        new HRESULT GetSymbolEntryOffsetRegions(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID Id,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_OFFSET_REGION[] Regions,
            [In] uint RegionsCount,
            [Out] out uint RegionsAvail);

        [PreserveSig]
        new HRESULT GetSymbolEntryBySymbolEntry(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_MODULE_AND_ID FromId,
            [In] uint Flags,
            [Out] out DEBUG_MODULE_AND_ID ToId);

        [PreserveSig]
        new HRESULT GetSourceEntriesByOffset(
            [In] ulong Offset,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail);

        [PreserveSig]
        new HRESULT GetSourceEntriesByLine(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail);

        [PreserveSig]
        new HRESULT GetSourceEntriesByLineWide(
            [In] uint Line,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_SYMBOL_SOURCE_ENTRY[] Entries,
            [In] uint EntriesCount,
            [Out] out uint EntriesAvail);

        [PreserveSig]
        new HRESULT GetSourceEntryString(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        new HRESULT GetSourceEntryStringWide(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Which,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint StringSize);

        [PreserveSig]
        new HRESULT GetSourceEntryOffsetRegions(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY Entry,
            [In] uint Flags,
            [Out, MarshalAs(UnmanagedType.LPArray)] DEBUG_OFFSET_REGION[] Regions,
            [In] uint RegionsCount,
            [Out] out uint RegionsAvail);

        [PreserveSig]
        new HRESULT GetSourceEntryBySourceEntry(
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_SYMBOL_SOURCE_ENTRY FromEntry,
            [In] uint Flags,
            [Out] out DEBUG_SYMBOL_SOURCE_ENTRY ToEntry);

        #endregion
        #region IDebugSymbols4

        [PreserveSig]
        new HRESULT GetScopeEx(
            [Out] out ulong InstructionOffset,
            [Out] out DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

        [PreserveSig]
        new HRESULT SetScopeEx(
            [In] ulong InstructionOffset,
            [In, MarshalAs(UnmanagedType.LPStruct)] DEBUG_STACK_FRAME_EX ScopeFrame,
            [In] IntPtr ScopeContext,
            [In] uint ScopeContextSize);

        [PreserveSig]
        new HRESULT GetNameByInlineContext(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetNameByInlineContextWide(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder NameBuffer,
            [In] int NameBufferSize,
            [Out] out uint NameSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetLineByInlineContext(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT GetLineByInlineContextWide(
            [In] ulong Offset,
            [In] uint InlineContext,
            [Out] out uint Line,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder FileBuffer,
            [In] int FileBufferSize,
            [Out] out uint FileSize,
            [Out] out ulong Displacement);

        [PreserveSig]
        new HRESULT OutputSymbolByInlineContext(
            [In] uint OutputControl,
            [In] uint Flags,
            [In] ulong Offset,
            [In] uint InlineContext);

        #endregion
        #region IDebugSymbols5

        [PreserveSig]
        HRESULT GetCurrentScopeFrameIndexEx(
            [In] DEBUG_FRAME Flags,
            [Out] out uint Index);

        [PreserveSig]
        HRESULT SetScopeFrameByIndexEx(
            [In] DEBUG_FRAME Flags,
            [In] uint Index);

        #endregion
    }
}

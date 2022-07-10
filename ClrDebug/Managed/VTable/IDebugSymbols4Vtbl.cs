﻿using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IDebugSymbols4Vtbl
    {
        public readonly IntPtr GetSymbolOptions;
        public readonly IntPtr AddSymbolOptions;
        public readonly IntPtr RemoveSymbolOptions;
        public readonly IntPtr SetSymbolOptions;
        public readonly IntPtr GetNameByOffset;
        public readonly IntPtr GetOffsetByName;
        public readonly IntPtr GetNearNameByOffset;
        public readonly IntPtr GetLineByOffset;
        public readonly IntPtr GetOffsetByLine;
        public readonly IntPtr GetNumberModules;
        public readonly IntPtr GetModuleByIndex;
        public readonly IntPtr GetModuleByModuleName;
        public readonly IntPtr GetModuleByOffset;
        public readonly IntPtr GetModuleNames;
        public readonly IntPtr GetModuleParameters;
        public readonly IntPtr GetSymbolModule;
        public readonly IntPtr GetTypeName;
        public readonly IntPtr GetTypeId;
        public readonly IntPtr GetTypeSize;
        public readonly IntPtr GetFieldOffset;
        public readonly IntPtr GetSymbolTypeId;
        public readonly IntPtr GetOffsetTypeId;
        public readonly IntPtr ReadTypedDataVirtual;
        public readonly IntPtr WriteTypedDataVirtual;
        public readonly IntPtr OutputTypedDataVirtual;
        public readonly IntPtr ReadTypedDataPhysical;
        public readonly IntPtr WriteTypedDataPhysical;
        public readonly IntPtr OutputTypedDataPhysical;
        public readonly IntPtr GetScope;
        public readonly IntPtr SetScope;
        public readonly IntPtr ResetScope;
        public readonly IntPtr GetScopeSymbolGroup;
        public readonly IntPtr CreateSymbolGroup;
        public readonly IntPtr StartSymbolMatch;
        public readonly IntPtr GetNextSymbolMatch;
        public readonly IntPtr EndSymbolMatch;
        public readonly IntPtr Reload;
        public readonly IntPtr GetSymbolPath;
        public readonly IntPtr SetSymbolPath;
        public readonly IntPtr AppendSymbolPath;
        public readonly IntPtr GetImagePath;
        public readonly IntPtr SetImagePath;
        public readonly IntPtr AppendImagePath;
        public readonly IntPtr GetSourcePath;
        public readonly IntPtr GetSourcePathElement;
        public readonly IntPtr SetSourcePath;
        public readonly IntPtr AppendSourcePath;
        public readonly IntPtr FindSourceFile;
        public readonly IntPtr GetSourceFileLineOffsets;
        public readonly IntPtr GetModuleVersionInformation;
        public readonly IntPtr GetModuleNameString;
        public readonly IntPtr GetConstantName;
        public readonly IntPtr GetFieldName;
        public readonly IntPtr GetTypeOptions;
        public readonly IntPtr AddTypeOptions;
        public readonly IntPtr RemoveTypeOptions;
        public readonly IntPtr SetTypeOptions;
        public readonly IntPtr GetNameByOffsetWide;
        public readonly IntPtr GetOffsetByNameWide;
        public readonly IntPtr GetNearNameByOffsetWide;
        public readonly IntPtr GetLineByOffsetWide;
        public readonly IntPtr GetOffsetByLineWide;
        public readonly IntPtr GetModuleByModuleNameWide;
        public readonly IntPtr GetSymbolModuleWide;
        public readonly IntPtr GetTypeNameWide;
        public readonly IntPtr GetTypeIdWide;
        public readonly IntPtr GetFieldOffsetWide;
        public readonly IntPtr GetSymbolTypeIdWide;
        public readonly IntPtr GetScopeSymbolGroup2;
        public readonly IntPtr CreateSymbolGroup2;
        public readonly IntPtr StartSymbolMatchWide;
        public readonly IntPtr GetNextSymbolMatchWide;
        public readonly IntPtr ReloadWide;
        public readonly IntPtr GetSymbolPathWide;
        public readonly IntPtr SetSymbolPathWide;
        public readonly IntPtr AppendSymbolPathWide;
        public readonly IntPtr GetImagePathWide;
        public readonly IntPtr SetImagePathWide;
        public readonly IntPtr AppendImagePathWide;
        public readonly IntPtr GetSourcePathWide;
        public readonly IntPtr GetSourcePathElementWide;
        public readonly IntPtr SetSourcePathWide;
        public readonly IntPtr AppendSourcePathWide;
        public readonly IntPtr FindSourceFileWide;
        public readonly IntPtr GetSourceFileLineOffsetsWide;
        public readonly IntPtr GetModuleVersionInformationWide;
        public readonly IntPtr GetModuleNameStringWide;
        public readonly IntPtr GetConstantNameWide;
        public readonly IntPtr GetFieldNameWide;
        public readonly IntPtr IsManagedModule;
        public readonly IntPtr GetModuleByModuleName2;
        public readonly IntPtr GetModuleByModuleName2Wide;
        public readonly IntPtr GetModuleByOffset2;
        public readonly IntPtr AddSyntheticModule;
        public readonly IntPtr AddSyntheticModuleWide;
        public readonly IntPtr RemoveSyntheticModule;
        public readonly IntPtr GetCurrentScopeFrameIndex;
        public readonly IntPtr SetScopeFrameByIndex;
        public readonly IntPtr SetScopeFromJitDebugInfo;
        public readonly IntPtr SetScopeFromStoredEvent;
        public readonly IntPtr OutputSymbolByOffset;
        public readonly IntPtr GetFunctionEntryByOffset;
        public readonly IntPtr GetFieldTypeAndOffset;
        public readonly IntPtr GetFieldTypeAndOffsetWide;
        public readonly IntPtr AddSyntheticSymbol;
        public readonly IntPtr AddSyntheticSymbolWide;
        public readonly IntPtr RemoveSyntheticSymbol;
        public readonly IntPtr GetSymbolEntriesByOffset;
        public readonly IntPtr GetSymbolEntriesByName;
        public readonly IntPtr GetSymbolEntriesByNameWide;
        public readonly IntPtr GetSymbolEntryByToken;
        public readonly IntPtr GetSymbolEntryInformation;
        public readonly IntPtr GetSymbolEntryString;
        public readonly IntPtr GetSymbolEntryStringWide;
        public readonly IntPtr GetSymbolEntryOffsetRegions;
        public readonly IntPtr GetSymbolEntryBySymbolEntry;
        public readonly IntPtr GetSourceEntriesByOffset;
        public readonly IntPtr GetSourceEntriesByLine;
        public readonly IntPtr GetSourceEntriesByLineWide;
        public readonly IntPtr GetSourceEntryString;
        public readonly IntPtr GetSourceEntryStringWide;
        public readonly IntPtr GetSourceEntryOffsetRegions;
        public readonly IntPtr GetSourceEntryBySourceEntry;
        public readonly IntPtr GetScopeEx;
        public readonly IntPtr SetScopeEx;
        public readonly IntPtr GetNameByInlineContext;
        public readonly IntPtr GetNameByInlineContextWide;
        public readonly IntPtr GetLineByInlineContext;
        public readonly IntPtr GetLineByInlineContextWide;
        public readonly IntPtr OutputSymbolByInlineContext;
    }
}

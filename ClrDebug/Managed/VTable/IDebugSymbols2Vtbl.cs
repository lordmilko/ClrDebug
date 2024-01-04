using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugSymbols2Vtbl
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
    }
}

using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugBreakpoint2Vtbl
    {
        public readonly IntPtr GetId;
        public new readonly IntPtr GetType;
        public readonly IntPtr GetAdder;
        public readonly IntPtr GetFlags;
        public readonly IntPtr AddFlags;
        public readonly IntPtr RemoveFlags;
        public readonly IntPtr SetFlags;
        public readonly IntPtr GetOffset;
        public readonly IntPtr SetOffset;
        public readonly IntPtr GetDataParameters;
        public readonly IntPtr SetDataParameters;
        public readonly IntPtr GetPassCount;
        public readonly IntPtr SetPassCount;
        public readonly IntPtr GetCurrentPassCount;
        public readonly IntPtr GetMatchThreadId;
        public readonly IntPtr SetMatchThreadId;
        public readonly IntPtr GetCommand;
        public readonly IntPtr SetCommand;
        public readonly IntPtr GetOffsetExpression;
        public readonly IntPtr SetOffsetExpression;
        public readonly IntPtr GetParameters;
        public readonly IntPtr GetCommandWide;
        public readonly IntPtr SetCommandWide;
        public readonly IntPtr GetOffsetExpressionWide;
        public readonly IntPtr SetOffsetExpressionWide;
    }
}

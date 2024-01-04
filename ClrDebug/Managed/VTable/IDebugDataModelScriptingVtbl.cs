using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugDataModelScriptingVtbl
    {
        public readonly IntPtr GetProviders;
        public readonly IntPtr GetScriptTemplateContent;
        public readonly IntPtr CreateScript;
    }
}

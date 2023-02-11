using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("moduleId = {moduleId.ToString(),nq}, methodId = {methodId.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_METHOD
    {
        public ModuleID moduleId;
        public mdMethodDef methodId;
    }
}

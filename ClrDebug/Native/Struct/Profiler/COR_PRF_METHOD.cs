using System.Runtime.InteropServices;

namespace ClrDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_METHOD
    {
        public ModuleID moduleId;
        public mdMethodDef methodId;
    }
}

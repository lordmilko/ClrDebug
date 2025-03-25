using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OMFTypeFlags
    {
        public byte sig;
        public byte unused1;
        public byte unused2;
        public byte unused3;
    }
}

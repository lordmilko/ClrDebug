using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CLR_DEBUGGING_VERSION
    {
        public ushort wStructVersion;
        public ushort wMajor;
        public ushort wMinor;
        public ushort wBuild;
        public ushort wRevision;
    }
}
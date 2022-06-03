using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct _COR_VERSION
    {
        public uint dwMajor;
        public uint dwMinor;
        public uint dwBuild;
        public uint dwSubBuild;
    }
}
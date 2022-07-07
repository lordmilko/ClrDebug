using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_CREATE_PROCESS_OPTIONS
    {
        public DEBUG_CREATE_PROCESS CreateFlags;
        public DEBUG_ECREATE_PROCESS EngCreateFlags;
        public uint VerifierFlags;
        public uint Reserved;
    }
}
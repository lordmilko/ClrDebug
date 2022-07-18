using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PHYSICAL_MEMORY_DESCRIPTOR64
    {
        public int NumberOfRuns;
        public ulong NumberOfPages;

        public PHYSICAL_MEMORY_RUN64* Run;
    }
}

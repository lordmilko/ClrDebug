using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PHYSICAL_MEMORY_DESCRIPTOR32
    {
        public int NumberOfRuns;
        public int NumberOfPages;

        public PHYSICAL_MEMORY_RUN32* Run;
    }
}

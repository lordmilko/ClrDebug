using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("NumberOfRuns = {NumberOfRuns}, NumberOfPages = {NumberOfPages}, Run = {Run}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PHYSICAL_MEMORY_DESCRIPTOR32
    {
        public int NumberOfRuns;
        public int NumberOfPages;
        public PHYSICAL_MEMORY_RUN32* Run;
    }
}

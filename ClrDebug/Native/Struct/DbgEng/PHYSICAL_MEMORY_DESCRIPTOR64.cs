using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("NumberOfRuns = {NumberOfRuns}, NumberOfPages = {NumberOfPages}, Run = {Run}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PHYSICAL_MEMORY_DESCRIPTOR64
    {
        public int NumberOfRuns;
        public long NumberOfPages;
        public PHYSICAL_MEMORY_RUN64* Run;
    }
}

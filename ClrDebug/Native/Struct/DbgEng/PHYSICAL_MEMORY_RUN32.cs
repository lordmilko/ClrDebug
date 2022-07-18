using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PHYSICAL_MEMORY_RUN32
    {
        int BasePage;
        int PageCount;
    }
}
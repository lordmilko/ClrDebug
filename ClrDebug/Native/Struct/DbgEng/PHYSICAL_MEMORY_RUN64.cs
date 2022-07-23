using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PHYSICAL_MEMORY_RUN64
    {
        long BasePage;
        long PageCount;
    }
}
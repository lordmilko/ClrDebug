using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("BasePage = {BasePage}, PageCount = {PageCount}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct PHYSICAL_MEMORY_RUN64
    {
        long BasePage;
        long PageCount;
    }
}

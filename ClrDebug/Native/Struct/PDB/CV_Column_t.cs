using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("offColumnStart = {offColumnStart}, offColumnEnd = {offColumnEnd}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_Column_t
    {
        //This is the only place CV_columnpos_t is used, so i don't think it warrants its own typedef
        public short offColumnStart;
        public short offColumnEnd;
    }
}

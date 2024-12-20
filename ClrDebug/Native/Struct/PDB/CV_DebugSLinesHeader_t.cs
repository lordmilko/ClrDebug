using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("offCon = {offCon.ToString(),nq}, segCon = {segCon}, flags = {flags}, cbCon = {cbCon.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_DebugSLinesHeader_t
    {
        public CV_off32_t offCon;
        public short segCon;
        public CV_LINES flags;
        public CV_off32_t cbCon;
    }
}

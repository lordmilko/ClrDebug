using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("type = {type.ToString(),nq}, cbLen = {cbLen.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_DebugSSubsectionHeader_t
    {
        public DEBUG_S_SUBSECTION_TYPE type;
        public CV_off32_t cbLen;
    }
}

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("offFile = {offFile.ToString(),nq}, nLines = {nLines.ToString(),nq}, cbBlock = {cbBlock.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_DebugSLinesFileBlockHeader_t
    {
        public CV_off32_t offFile;
        public CV_off32_t nLines;
        public CV_off32_t cbBlock;
        // CV_Line_t      lines[nLines];
        // CV_Column_t    columns[nColumns];
    }
}

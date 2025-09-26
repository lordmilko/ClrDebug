using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("offFile = {offFile.ToString(),nq}, nLines = {nLines.ToString(),nq}, cbBlock = {cbBlock.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_DebugSLinesFileBlockHeader_t
    {
        /* This field returns the relative offset of the CV_FileCheckSum record of this file
         * from the beginning of DEBUG_S_FILECHKSMS. PDB1 creates a mapping from the index of
         * the file in the CV_FileCheckSum[] and converts to and from this when you call
         * EnumLines::GetLinesColumns/ Mod1::QueryFileNameInfo */
        public CV_off32_t offFile;

        public CV_off32_t nLines;
        public CV_off32_t cbBlock;
        // CV_Line_t      lines[nLines];
        // CV_Column_t    columns[nColumns];
    }
}

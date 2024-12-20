using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, offsetBase = {offsetBase.ToString(),nq}, sectBase = {sectBase}, switchType = {switchType}, offsetBranch = {offsetBranch.ToString(),nq}, offsetTable = {offsetTable.ToString(),nq}, sectBranch = {sectBranch}, sectTable = {sectTable}, cEntries = {cEntries}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ARMSWITCHTABLE
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_ARMSWITCHTABLE
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Section-relative offset to the base for switch offsets
        /// </summary>
        public CV_uoff32_t offsetBase;

        /// <summary>
        /// Section index of the base for switch offsets
        /// </summary>
        public short sectBase;

        /// <summary>
        /// type of each entry
        /// </summary>
        public short switchType; //todo: enum?

        /// <summary>
        /// Section-relative offset to the table branch instruction
        /// </summary>
        public CV_uoff32_t offsetBranch;

        /// <summary>
        /// Section-relative offset to the start of the table
        /// </summary>
        public CV_uoff32_t offsetTable;

        /// <summary>
        /// Section index of the table branch instruction
        /// </summary>
        public short sectBranch;

        /// <summary>
        /// Section index of the table
        /// </summary>
        public short sectTable;

        /// <summary>
        /// number of switch table entries
        /// </summary>
        public int cEntries;
    }
}

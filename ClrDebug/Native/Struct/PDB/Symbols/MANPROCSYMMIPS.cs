using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, pParent = {pParent}, pEnd = {pEnd}, pNext = {pNext}, len = {len}, DbgStart = {DbgStart}, DbgEnd = {DbgEnd}, regSave = {regSave}, fpSave = {fpSave}, intOff = {intOff.ToString(),nq}, fpOff = {fpOff.ToString(),nq}, token = {token.ToString(),nq}, off = {off.ToString(),nq}, seg = {seg}, retReg = {retReg}, frameReg = {frameReg}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct MANPROCSYMMIPS
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_GMANPROCMIPS or S_LMANPROCMIPS
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// pointer to the parent
        /// </summary>
        public int pParent;

        /// <summary>
        /// pointer to this blocks end
        /// </summary>
        public int pEnd;

        /// <summary>
        /// pointer to next symbol
        /// </summary>
        public int pNext;

        /// <summary>
        /// Proc length
        /// </summary>
        public int len;

        /// <summary>
        /// Debug start offset
        /// </summary>
        public int DbgStart;

        /// <summary>
        /// Debug end offset
        /// </summary>
        public int DbgEnd;

        /// <summary>
        /// int register save mask
        /// </summary>
        public int regSave;

        /// <summary>
        /// fp register save mask
        /// </summary>
        public int fpSave;

        /// <summary>
        /// int register save offset
        /// </summary>
        public CV_uoff32_t intOff;

        /// <summary>
        /// fp register save offset
        /// </summary>
        public CV_uoff32_t fpOff;

        /// <summary>
        /// COM+ token type
        /// </summary>
        public mdToken token; //Modelled as CV_tkn_t by PDB1
        public CV_uoff32_t off;
        public short seg;

        /// <summary>
        /// Register return value is in
        /// </summary>
        public byte retReg;

        /// <summary>
        /// Frame pointer register
        /// </summary>
        public byte frameReg;

        /// <summary>
        /// optional name field
        /// </summary>
        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}

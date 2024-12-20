using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, framesize = {framesize}, off = {off.ToString(),nq}, reg = {reg}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SLINK32
    {
        /// <summary>
        /// record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_SLINK32
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// frame size of parent procedure
        /// </summary>
        public int framesize;

        /// <summary>
        /// signed offset where the static link was saved relative to the value of reg
        /// </summary>
        public CV_off32_t off;

        public short reg; //todo: enum?
    }
}

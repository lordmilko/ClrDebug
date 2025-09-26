using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    //This type is in dia.h as "FPODATA" but isn't explicitly referenced anywhere.
    //It seems it's really just meant to be the FPO_DATA type

    [DebuggerDisplay("ulOffStart = {ulOffStart}, cbProcSize = {cbProcSize}, cdwLocals = {cdwLocals}, cdwParams = {cdwParams}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct FPO_DATA
    {
        /// <summary>
        /// offset 1st byte of function code
        /// </summary>
        public int ulOffStart;

        /// <summary>
        /// # bytes in function
        /// </summary>
        public int cbProcSize;

        /// <summary>
        /// # bytes in locals/4
        /// </summary>
        public int cdwLocals;

        /// <summary>
        /// # bytes in params/4
        /// </summary>
        public short cdwParams;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private ushort flags;

        /// <summary>
        /// # bytes in prolog
        /// </summary>
        public byte cbProlog
        {
            get => (byte) (flags & 0x00FF);
            set => flags = (ushort) ((flags & 0xFF00) | (value & 0x00FF));
        }

        /// <summary>
        /// # regs saved
        /// </summary>
        public byte cbRegs
        {
            get => (byte) ((flags >> 8) & 0x07);
            set => flags = (ushort) ((flags & 0xF8FF) | ((value & 0x07) << 8));
        }

        /// <summary>
        /// TRUE if SEH in func
        /// </summary>
        public bool fHasSEH
        {
            get => (flags & 0x0800) != 0;
            set => flags = (ushort) (value ? (flags | 0x0800) : (flags & ~0x0800));
        }

        /// <summary>
        /// TRUE if EBP has been allocated
        /// </summary>
        public bool fUseBP
        {
            get => (flags & 0x1000) != 0;
            set => flags = (ushort) (value ? (flags | 0x1000) : (flags & ~0x1000));
        }

        /// <summary>
        /// reserved for future use
        /// </summary>
        public bool reserved
        {
            get => (flags & 0x2000) != 0;
            set => flags = (ushort) (value ? (flags | 0x2000) : (flags & ~0x2000));
        }

        /// <summary>
        /// frame type
        /// </summary>
        public byte cbFrame
        {
            get => (byte) ((flags >> 14) & 0x03);
            set => flags = (ushort) ((flags & 0x3FFF) | ((value & 0x03) << 14));
        }
    }
}

using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, discarded = {discarded.ToString(),nq}, reserved = {reserved}, discardedData = {discardedData}, fileid = {fileid}, linenum = {linenum}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct DISCARDEDSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_DISCARDED
        /// </summary>
        public SYM_ENUM_e rectyp;

        #region BitField

        /// <summary>
        /// CV_DISCARDED_e
        /// </summary>
        public CV_DISCARDED_e discarded
        {
            get => (CV_DISCARDED_e) GetBits(discardedData, 0, 8); //0-7
            set => SetBits(ref discardedData, 0, 8, (int) value);
        }

        /// <summary>
        /// Unused
        /// </summary>
        public int reserved
        {
            get => GetBits(discardedData, 8, 24); //8-31
            set => SetBits(ref discardedData, 8, 24, value);
        }

        public int discardedData;

        #endregion

        /// <summary>
        /// First FILEID if line number info present
        /// </summary>
        public int fileid;

        /// <summary>
        /// First line number
        /// </summary>
        public int linenum;

        /// <summary>
        /// Original record(s) with invalid type indices
        /// </summary>
        public fixed byte data[1];
    }
}

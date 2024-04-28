using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Line flags (data present)
    /// </summary>
    [DebuggerDisplay("offset = {offset}, linenumStart = {linenumStart}, deltaLineEnd = {deltaLineEnd}, fStatement = {fStatement}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_Line_t
    {
        /// <summary>
        /// Offset to start of code bytes for line number
        /// </summary>
        public int offset;

        #region BitField

        /// <summary>
        /// line where statement/expression starts
        /// </summary>
        public int linenumStart
        {
            get => GetBits(data, 0, 24); //0-23
            set => SetBits(ref data, 0, 24, value);
        }

        /// <summary>
        /// delta to line where statement ends (optional)
        /// </summary>
        public int deltaLineEnd
        {
            get => GetBits(data, 24, 7); //24-30
            set => SetBits(ref data, 24, 7, value);
        }

        /// <summary>
        /// true if a statement linenumber, else an expression line num
        /// </summary>
        public bool fStatement
        {
            get => GetBitFlag(data, 31);
            set => SetBitFlag(ref data, 31, value);
        }

        public int data;

        #endregion
    }
}

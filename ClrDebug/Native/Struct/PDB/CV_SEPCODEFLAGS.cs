using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// flag bitfields for separated code attributes
    /// </summary>
    [DebuggerDisplay("fIsLexicalScope = {fIsLexicalScope}, fReturnsToParent = {fReturnsToParent}, pad = {pad}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_SEPCODEFLAGS
    {
        /// <summary>
        /// S_SEPCODE doubles as lexical scope
        /// </summary>
        public bool fIsLexicalScope
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// code frag returns to parent
        /// </summary>
        public bool fReturnsToParent
        {
            get => GetBitFlag(flags, 1);
            set => SetBitFlag(ref flags, 1, value);
        }

        /// <summary>
        /// must be zero
        /// </summary>
        public int pad
        {
            get => GetBits(flags, 2, 30); //2-31
            set => SetBits(ref flags, 2, 30, value);
        }

        public int flags;
    }
}

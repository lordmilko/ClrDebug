using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// enumeration for LF_MODIFIER values
    /// </summary>
    [DebuggerDisplay("MOD_const = {MOD_const}, MOD_volatile = {MOD_volatile}, MOD_unaligned = {MOD_unaligned}, MOD_unused = {MOD_unused}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CV_modifier_t
    {
        public bool MOD_const
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        public bool MOD_volatile
        {
            get => GetBitFlag(flags, 1);
            set => SetBitFlag(ref flags, 1, value);
        }

        public bool MOD_unaligned
        {
            get => GetBitFlag(flags, 2);
            set => SetBitFlag(ref flags, 2, value);
        }

        public short MOD_unused
        {
            get => GetBits(flags, 3, 13); //3-15
            set => SetBits(ref flags, 3, 13, value);
        }

        public short flags;
    }
}

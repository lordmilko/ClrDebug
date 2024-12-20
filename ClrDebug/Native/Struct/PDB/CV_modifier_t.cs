using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// enumeration for LF_MODIFIER values
    /// </summary>
    [DebuggerDisplay("MOD_const = {MOD_const}, MOD_volatile = {MOD_volatile}, MOD_unaligned = {MOD_unaligned}, MOD_unused = {MOD_unused}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
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

        private short flags;

        public static implicit operator CV_modifier_t(short value) => new CV_modifier_t {flags = value};
        public static implicit operator short(CV_modifier_t value) => value.flags;
    }
}

using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// function flags
    /// </summary>
    [DebuggerDisplay("cxxreturnudt = {cxxreturnudt}, ctor = {ctor}, ctorvbase = {ctorvbase}, unused = {unused}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_funcattr_t
    {
        /// <summary>
        /// true if C++ style ReturnUDT
        /// </summary>
        public bool cxxreturnudt
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// true if func is an instance constructor
        /// </summary>
        public bool ctor
        {
            get => GetBitFlag(flags, 1);
            set => SetBitFlag(ref flags, 1, value);
        }

        /// <summary>
        /// true if func is an instance constructor of a class with virtual bases
        /// </summary>
        public bool ctorvbase
        {
            get => GetBitFlag(flags, 2);
            set => SetBitFlag(ref flags, 2, value);
        }

        /// <summary>
        /// unused
        /// </summary>
        public byte unused
        {
            get => GetBits(flags, 3, 5); //3-7
            set => SetBits(ref flags, 3, 5, value);
        }

        private byte flags;

        public static implicit operator CV_funcattr_t(byte value) => new CV_funcattr_t { flags = value };
        public static implicit operator byte(CV_funcattr_t value) => value.flags;
    }
}

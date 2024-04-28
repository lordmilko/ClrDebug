using System.Diagnostics;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("cstyle = {cstyle}, rsclean = {rsclean}, unused = {unused}, flags = {flags}")]
    public struct CV_GENERIC_FLAG
    {
        /// <summary>
        /// true push varargs right to left
        /// </summary>
        public bool cstyle
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// true if returnee stack cleanup
        /// </summary>
        public bool rsclean
        {
            get => GetBitFlag(flags, 1);
            set => SetBitFlag(ref flags, 1, value);
        }

        /// <summary>
        /// unused
        /// </summary>
        public short unused
        {
            get => GetBits(flags, 2, 14); //2-15
            set => SetBits(ref flags, 2, 14, value);
        }

        public short flags;
    }
}

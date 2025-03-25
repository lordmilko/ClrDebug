using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("maybe = {maybe}, padding = {padding}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CV_RANGEATTR
    {
        /// <summary>
        /// May have no user name on one of control flow path.
        /// </summary>
        public bool maybe
        {
            get => GetBitFlag(data, 0);
            set => SetBitFlag(ref data, 0, value);
        }

        /// <summary>
        /// Padding for future use.
        /// </summary>
        public short padding
        {
            get => GetBits(data, 1, 15); //1-15
            set => SetBits(ref data, 1, 15, value);
        }

        public short data;
    }
}

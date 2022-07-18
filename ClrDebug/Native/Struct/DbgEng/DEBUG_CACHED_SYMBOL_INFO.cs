using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines information about cached symbols.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_CACHED_SYMBOL_INFO
    {
        /// <summary>
        /// A module base.
        /// </summary>
        public ulong ModBase;

        /// <summary>
        /// An argument value.
        /// </summary>
        public ulong Arg1;

        /// <summary>
        /// An argument value.
        /// </summary>
        public ulong Arg2;

        /// <summary>
        /// An ID.
        /// </summary>
        public uint Id;

        /// <summary>
        /// An argument value.
        /// </summary>
        public uint Arg3;
    }
}
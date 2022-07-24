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
        public long ModBase;

        /// <summary>
        /// An argument value.
        /// </summary>
        public long Arg1;

        /// <summary>
        /// An argument value.
        /// </summary>
        public long Arg2;

        /// <summary>
        /// An ID.
        /// </summary>
        public int Id;

        /// <summary>
        /// An argument value.
        /// </summary>
        public int Arg3;
    }
}

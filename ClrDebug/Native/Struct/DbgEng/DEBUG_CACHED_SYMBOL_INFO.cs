using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines information about cached symbols.
    /// </summary>
    [DebuggerDisplay("ModBase = {ModBase}, Arg1 = {Arg1}, Arg2 = {Arg2}, Id = {Id}, Arg3 = {Arg3}")]
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

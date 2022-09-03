using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines information about text completions to get.
    /// </summary>
    [DebuggerDisplay("Flags = {Flags.ToString(),nq}, ReplaceIndex = {ReplaceIndex}, MatchCount = {MatchCount}, Reserved1 = {Reserved1}, Reserved2 = {Reserved2}, Reserved3 = {Reserved3}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_GET_TEXT_COMPLETIONS_OUT
    {
        /// <summary>
        /// Flags. Valid flag values include the following:
        /// </summary>
        public DEBUG_GET_TEXT_COMPLETIONS Flags;

        /// <summary>
        /// The index of the replace location.
        /// </summary>
        public int ReplaceIndex;

        /// <summary>
        /// Count value of matches.
        /// </summary>
        public int MatchCount;

        /// <summary>
        /// Reserved.
        /// </summary>
        public int Reserved1;

        /// <summary>
        /// Reserved.
        /// </summary>
        public long Reserved2;
        public long Reserved3;

        //Completions follow.
        //Completion data is zero-terminated strings ended by a final zero double-terminator.
    }
}

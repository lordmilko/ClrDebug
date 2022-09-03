using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines information about text completions to get.
    /// </summary>
    [DebuggerDisplay("Flags = {Flags.ToString(),nq}, MatchCountLimit = {MatchCountLimit}, Reserved0 = {Reserved0}, Reserved1 = {Reserved1}, Reserved2 = {Reserved2}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_GET_TEXT_COMPLETIONS_IN
    {
        /// <summary>
        /// Flags. Valid flag values include the following:
        /// </summary>
        public DEBUG_GET_TEXT_COMPLETIONS Flags;

        /// <summary>
        /// The limit of matches.
        /// </summary>
        public int MatchCountLimit;
        public long Reserved0;
        public long Reserved1;
        public long Reserved2;

        //Input text string follows
    }
}

using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetNameByInlineContextWide"/> method.
    /// </summary>
    [DebuggerDisplay("NameBuffer = {NameBuffer}, Displacement = {Displacement}")]
    public struct GetNameByInlineContextWideResult
    {
        /// <summary>
        /// A pointer an output buffer for a Unicode character string.
        /// </summary>
        public string NameBuffer { get; }

        /// <summary>
        /// A pointer to the displacement value of the name.
        /// </summary>
        public long Displacement { get; }

        public GetNameByInlineContextWideResult(string nameBuffer, long displacement)
        {
            NameBuffer = nameBuffer;
            Displacement = displacement;
        }
    }
}

using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetNameByInlineContext"/> method.
    /// </summary>
    [DebuggerDisplay("NameBuffer = {NameBuffer}, Displacement = {Displacement}")]
    public struct GetNameByInlineContextResult
    {
        /// <summary>
        /// A pointer an output buffer.
        /// </summary>
        public string NameBuffer { get; }

        /// <summary>
        /// A pointer to the displacement value of the name.
        /// </summary>
        public long Displacement { get; }

        public GetNameByInlineContextResult(string nameBuffer, long displacement)
        {
            NameBuffer = nameBuffer;
            Displacement = displacement;
        }
    }
}

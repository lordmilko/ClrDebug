using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetNameByOffsetWide"/> method.
    /// </summary>
    [DebuggerDisplay("NameBuffer = {NameBuffer}, Displacement = {Displacement}")]
    public struct GetNameByOffsetWideResult
    {
        /// <summary>
        /// Receives the symbol's name. The name is qualified by the module to which the symbol belongs (for example, mymodule!main).<para/>
        /// If NameBuffer is NULL, this information is not returned.
        /// </summary>
        public string NameBuffer { get; }

        /// <summary>
        /// Receives the difference between the value of Offset and the base location of the symbol. If Displacement is NULL, this information is not returned.
        /// </summary>
        public ulong Displacement { get; }

        public GetNameByOffsetWideResult(string nameBuffer, ulong displacement)
        {
            NameBuffer = nameBuffer;
            Displacement = displacement;
        }
    }
}

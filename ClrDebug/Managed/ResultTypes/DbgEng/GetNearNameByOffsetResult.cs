using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetNearNameByOffset"/> method.
    /// </summary>
    [DebuggerDisplay("NameBuffer = {NameBuffer}, Displacement = {Displacement}")]
    public struct GetNearNameByOffsetResult
    {
        /// <summary>
        /// Receives the symbol's name. The name is qualified by the module to which the symbol belongs (for example, mymodule!main).<para/>
        /// If NameBuffer is NULL, this information is not returned.
        /// </summary>
        public string NameBuffer { get; }

        /// <summary>
        /// Receives the difference between the value of Offset and the location in the target's memory address space of the symbol.<para/>
        /// If Displacement is NULL, this information is not returned.
        /// </summary>
        public ulong Displacement { get; }

        public GetNearNameByOffsetResult(string nameBuffer, ulong displacement)
        {
            NameBuffer = nameBuffer;
            Displacement = displacement;
        }
    }
}

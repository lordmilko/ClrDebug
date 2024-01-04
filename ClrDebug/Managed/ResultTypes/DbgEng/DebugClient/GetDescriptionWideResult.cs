using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugRegisters.GetDescriptionWide"/> method.
    /// </summary>
    [DebuggerDisplay("NameBuffer = {NameBuffer}, Desc = {Desc.ToString(),nq}")]
    public struct GetDescriptionWideResult
    {
        /// <summary>
        /// Specifies the buffer in which to store the name of the register. If NameBuffer is NULL, this information is not returned.
        /// </summary>
        public string NameBuffer { get; }

        /// <summary>
        /// Receives the description of the register. See <see cref="DEBUG_REGISTER_DESCRIPTION"/> for more details.
        /// </summary>
        public DEBUG_REGISTER_DESCRIPTION Desc { get; }

        public GetDescriptionWideResult(string nameBuffer, DEBUG_REGISTER_DESCRIPTION desc)
        {
            NameBuffer = nameBuffer;
            Desc = desc;
        }
    }
}

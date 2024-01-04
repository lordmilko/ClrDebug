using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetManagedStatusWide"/> method.
    /// </summary>
    [DebuggerDisplay("Flags = {Flags.ToString(),nq}, String = {String}")]
    public struct GetManagedStatusWideResult
    {
        /// <summary>
        /// A pointer to flags from the debugging APIs.
        /// </summary>
        public DEBUG_MANAGED Flags { get; }

        /// <summary>
        /// A pointer to a Unicode character string from the debugging APIs.
        /// </summary>
        public string String { get; }

        public GetManagedStatusWideResult(DEBUG_MANAGED flags, string @string)
        {
            Flags = flags;
            String = @string;
        }
    }
}

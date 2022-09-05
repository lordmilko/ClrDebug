using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ComStream.CopyTo"/> method.
    /// </summary>
    [DebuggerDisplay("pcbRead = {pcbRead.ToString(),nq}, pcbWritten = {pcbWritten.ToString(),nq}")]
    public struct CopyToResult
    {
        public ULARGE_INTEGER pcbRead { get; }

        public ULARGE_INTEGER pcbWritten { get; }

        public CopyToResult(ULARGE_INTEGER pcbRead, ULARGE_INTEGER pcbWritten)
        {
            this.pcbRead = pcbRead;
            this.pcbWritten = pcbWritten;
        }
    }
}

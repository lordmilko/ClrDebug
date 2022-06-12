using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="Stream.RemoteCopyTo"/> method.
    /// </summary>
    [DebuggerDisplay("pcbRead = {pcbRead}, pcbWritten = {pcbWritten}")]
    public struct RemoteCopyToResult
    {
        public ULARGE_INTEGER pcbRead { get; }

        public ULARGE_INTEGER pcbWritten { get; }

        public RemoteCopyToResult(ULARGE_INTEGER pcbRead, ULARGE_INTEGER pcbWritten)
        {
            this.pcbRead = pcbRead;
            this.pcbWritten = pcbWritten;
        }
    }
}
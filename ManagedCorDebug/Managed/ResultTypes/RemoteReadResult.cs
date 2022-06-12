using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SequentialStream.RemoteRead"/> method.
    /// </summary>
    [DebuggerDisplay("pv = {pv}, pcbRead = {pcbRead}")]
    public struct RemoteReadResult
    {
        public byte pv { get; }

        public int pcbRead { get; }

        public RemoteReadResult(byte pv, int pcbRead)
        {
            this.pv = pv;
            this.pcbRead = pcbRead;
        }
    }
}
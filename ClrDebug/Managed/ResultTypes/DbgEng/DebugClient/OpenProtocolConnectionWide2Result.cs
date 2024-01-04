using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugClientInternal.OpenProtocolConnectionWide2"/> method.
    /// </summary>
    [DebuggerDisplay("connectionKind = {connectionKind.ToString(),nq}, systemId = {systemId}, server = {server}")]
    public struct OpenProtocolConnectionWide2Result
    {
        public ProtocolConnectionKind connectionKind { get; }

        public int systemId { get; }

        public long server { get; }

        public OpenProtocolConnectionWide2Result(ProtocolConnectionKind connectionKind, int systemId, long server)
        {
            this.connectionKind = connectionKind;
            this.systemId = systemId;
            this.server = server;
        }
    }
}

using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.GetFieldByToken2"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, type = {type.ToString(),nq}, flags = {flags}")]
    public struct GetFieldByToken2Result
    {
        public string nameBuf { get; }

        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public GetFieldByToken2Result(string nameBuf, XCLRDataTypeDefinition type, int flags)
        {
            this.nameBuf = nameBuf;
            this.type = type;
            this.flags = flags;
        }
    }
}
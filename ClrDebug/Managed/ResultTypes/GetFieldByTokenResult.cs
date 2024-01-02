using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.GetFieldByToken"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, type = {type?.ToString(),nq}, flags = {flags.ToString(),nq}")]
    public struct GetFieldByTokenResult
    {
        public string nameBuf { get; }

        public XCLRDataTypeDefinition type { get; }

        public CLRDataValueFlag flags { get; }

        public GetFieldByTokenResult(string nameBuf, XCLRDataTypeDefinition type, CLRDataValueFlag flags)
        {
            this.nameBuf = nameBuf;
            this.type = type;
            this.flags = flags;
        }
    }
}

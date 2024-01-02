using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumField"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, type = {type?.ToString(),nq}, flags = {flags.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct EnumFieldResult
    {
        public string nameBuf { get; }

        public XCLRDataTypeDefinition type { get; }

        public CLRDataFieldFlag flags { get; }

        public mdFieldDef token { get; }

        public EnumFieldResult(string nameBuf, XCLRDataTypeDefinition type, CLRDataFieldFlag flags, mdFieldDef token)
        {
            this.nameBuf = nameBuf;
            this.type = type;
            this.flags = flags;
            this.token = token;
        }
    }
}

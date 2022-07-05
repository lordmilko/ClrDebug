using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumFieldByName"/> method.
    /// </summary>
    [DebuggerDisplay("type = {type.ToString(),nq}, flags = {flags.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct EnumFieldByNameResult
    {
        public XCLRDataTypeDefinition type { get; }

        public CLRDataFieldFlag flags { get; }

        public mdFieldDef token { get; }

        public EnumFieldByNameResult(XCLRDataTypeDefinition type, CLRDataFieldFlag flags, mdFieldDef token)
        {
            this.type = type;
            this.flags = flags;
            this.token = token;
        }
    }
}

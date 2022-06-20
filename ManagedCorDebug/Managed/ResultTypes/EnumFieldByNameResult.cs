using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumFieldByName"/> method.
    /// </summary>
    [DebuggerDisplay("type = {type.ToString(),nq}, flags = {flags}, token = {token.ToString(),nq}")]
    public struct EnumFieldByNameResult
    {
        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public mdFieldDef token { get; }

        public EnumFieldByNameResult(XCLRDataTypeDefinition type, int flags, mdFieldDef token)
        {
            this.type = type;
            this.flags = flags;
            this.token = token;
        }
    }
}
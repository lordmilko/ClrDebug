using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumField"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, type = {type}, flags = {flags}, token = {token}")]
    public struct EnumFieldResult
    {
        public string nameBuf { get; }

        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public mdFieldDef token { get; }

        public EnumFieldResult(string nameBuf, XCLRDataTypeDefinition type, int flags, mdFieldDef token)
        {
            this.nameBuf = nameBuf;
            this.type = type;
            this.flags = flags;
            this.token = token;
        }
    }
}
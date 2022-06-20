using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumField"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field.ToString(),nq}, nameBuf = {nameBuf}, token = {token.ToString(),nq}")]
    public struct XCLRDataValue_EnumFieldResult
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumFieldResult(XCLRDataValue field, string nameBuf, mdFieldDef token)
        {
            this.field = field;
            this.nameBuf = nameBuf;
            this.token = token;
        }
    }
}
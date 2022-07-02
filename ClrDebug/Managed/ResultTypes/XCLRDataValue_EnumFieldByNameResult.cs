using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumFieldByName"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct XCLRDataValue_EnumFieldByNameResult
    {
        public XCLRDataValue field { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumFieldByNameResult(XCLRDataValue field, mdFieldDef token)
        {
            this.field = field;
            this.token = token;
        }
    }
}
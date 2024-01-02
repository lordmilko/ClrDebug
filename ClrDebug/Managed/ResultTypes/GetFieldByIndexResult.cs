using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetFieldByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field?.ToString(),nq}, nameBuf = {nameBuf}, token = {token.ToString(),nq}")]
    public struct GetFieldByIndexResult
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public mdFieldDef token { get; }

        public GetFieldByIndexResult(XCLRDataValue field, string nameBuf, mdFieldDef token)
        {
            this.field = field;
            this.nameBuf = nameBuf;
            this.token = token;
        }
    }
}

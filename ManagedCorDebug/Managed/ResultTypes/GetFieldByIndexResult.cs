using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetFieldByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field}, nameBuf = {nameBuf}, token = {token}")]
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
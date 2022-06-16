using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.GetStaticFieldByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field}, nameBuf = {nameBuf}, token = {token}")]
    public struct GetStaticFieldByIndexResult
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public mdFieldDef token { get; }

        public GetStaticFieldByIndexResult(XCLRDataValue field, string nameBuf, mdFieldDef token)
        {
            this.field = field;
            this.nameBuf = nameBuf;
            this.token = token;
        }
    }
}
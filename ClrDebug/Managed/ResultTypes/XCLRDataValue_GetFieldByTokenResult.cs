using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetFieldByToken"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field?.ToString(),nq}, nameBuf = {nameBuf}")]
    public struct XCLRDataValue_GetFieldByTokenResult
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public XCLRDataValue_GetFieldByTokenResult(XCLRDataValue field, string nameBuf)
        {
            this.field = field;
            this.nameBuf = nameBuf;
        }
    }
}

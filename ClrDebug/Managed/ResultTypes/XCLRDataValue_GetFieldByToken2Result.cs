using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetFieldByToken2"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field.ToString(),nq}, nameBuf = {nameBuf}")]
    public struct XCLRDataValue_GetFieldByToken2Result
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public XCLRDataValue_GetFieldByToken2Result(XCLRDataValue field, string nameBuf)
        {
            this.field = field;
            this.nameBuf = nameBuf;
        }
    }
}
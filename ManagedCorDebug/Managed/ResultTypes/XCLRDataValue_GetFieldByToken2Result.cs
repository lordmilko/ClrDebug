using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetFieldByToken2"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field}, nameBuf = {nameBuf}")]
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
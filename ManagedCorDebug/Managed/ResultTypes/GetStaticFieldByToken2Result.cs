using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.GetStaticFieldByToken2"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field}, nameBuf = {nameBuf}")]
    public struct GetStaticFieldByToken2Result
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public GetStaticFieldByToken2Result(XCLRDataValue field, string nameBuf)
        {
            this.field = field;
            this.nameBuf = nameBuf;
        }
    }
}
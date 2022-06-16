using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.GetStaticFieldByToken"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field}, nameBuf = {nameBuf}")]
    public struct GetStaticFieldByTokenResult
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public GetStaticFieldByTokenResult(XCLRDataValue field, string nameBuf)
        {
            this.field = field;
            this.nameBuf = nameBuf;
        }
    }
}
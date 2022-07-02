using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.GetDataByAddress"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, value = {value.ToString(),nq}, displacement = {displacement.ToString(),nq}")]
    public struct GetDataByAddressResult
    {
        public string nameBuf { get; }

        public XCLRDataValue value { get; }

        public CLRDATA_ADDRESS displacement { get; }

        public GetDataByAddressResult(string nameBuf, XCLRDataValue value, CLRDATA_ADDRESS displacement)
        {
            this.nameBuf = nameBuf;
            this.value = value;
            this.displacement = displacement;
        }
    }
}
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.GetRuntimeNameByAddress"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, displacement = {displacement.ToString(),nq}")]
    public struct GetRuntimeNameByAddressResult
    {
        public string nameBuf { get; }

        public CLRDATA_ADDRESS displacement { get; }

        public GetRuntimeNameByAddressResult(string nameBuf, CLRDATA_ADDRESS displacement)
        {
            this.nameBuf = nameBuf;
            this.displacement = displacement;
        }
    }
}
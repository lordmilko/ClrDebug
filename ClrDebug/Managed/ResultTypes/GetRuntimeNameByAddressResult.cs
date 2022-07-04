using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.GetRuntimeNameByAddress"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, displacement = {displacement.ToString(),nq}")]
    public struct GetRuntimeNameByAddressResult
    {
        /// <summary>
        /// [out, size_is(bufLen)] The input buffer of length bufLen that stores the runtime name.
        /// </summary>
        public string nameBuf { get; }

        /// <summary>
        /// A CLRDATA_ADDRESS pointer to the code offset of the returned symbol.
        /// </summary>
        public CLRDATA_ADDRESS displacement { get; }

        public GetRuntimeNameByAddressResult(string nameBuf, CLRDATA_ADDRESS displacement)
        {
            this.nameBuf = nameBuf;
            this.displacement = displacement;
        }
    }
}

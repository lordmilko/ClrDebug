using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataMethodInstance.GetAddressRangesByILOffset"/> method.
    /// </summary>
    [DebuggerDisplay("rangesNeeded = {rangesNeeded}, addressRanges = {addressRanges}")]
    public struct GetAddressRangesByILOffsetResult
    {
        public int rangesNeeded { get; }

        public CLRDATA_ADDRESS_RANGE addressRanges { get; }

        public GetAddressRangesByILOffsetResult(int rangesNeeded, CLRDATA_ADDRESS_RANGE addressRanges)
        {
            this.rangesNeeded = rangesNeeded;
            this.addressRanges = addressRanges;
        }
    }
}
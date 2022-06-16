using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetLocationByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("flags = {flags}, arg = {arg}")]
    public struct GetLocationByIndexResult
    {
        public int flags { get; }

        public CLRDATA_ADDRESS arg { get; }

        public GetLocationByIndexResult(int flags, CLRDATA_ADDRESS arg)
        {
            this.flags = flags;
            this.arg = arg;
        }
    }
}
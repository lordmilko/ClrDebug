using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetLocationByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("flags = {flags.ToString(),nq}, arg = {arg.ToString(),nq}")]
    public struct GetLocationByIndexResult
    {
        public ClrDataValueLocationFlag flags { get; }

        public CLRDATA_ADDRESS arg { get; }

        public GetLocationByIndexResult(ClrDataValueLocationFlag flags, CLRDATA_ADDRESS arg)
        {
            this.flags = flags;
            this.arg = arg;
        }
    }
}

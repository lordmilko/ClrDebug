using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataFrame.GetArgumentByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("arg = {arg}, name = {name}")]
    public struct GetArgumentByIndexResult
    {
        public XCLRDataValue arg { get; }

        public string name { get; }

        public GetArgumentByIndexResult(XCLRDataValue arg, string name)
        {
            this.arg = arg;
            this.name = name;
        }
    }
}
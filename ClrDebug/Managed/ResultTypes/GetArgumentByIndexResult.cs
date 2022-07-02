using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataFrame.GetArgumentByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("arg = {arg.ToString(),nq}, name = {name}")]
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
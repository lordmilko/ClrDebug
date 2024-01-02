using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataFrame.GetLocalVariableByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("localVariable = {localVariable?.ToString(),nq}, name = {name}")]
    public struct GetLocalVariableByIndexResult
    {
        public XCLRDataValue localVariable { get; }

        public string name { get; }

        public GetLocalVariableByIndexResult(XCLRDataValue localVariable, string name)
        {
            this.localVariable = localVariable;
            this.name = name;
        }
    }
}

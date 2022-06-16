using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataFrame.GetLocalVariableByIndex"/> method.
    /// </summary>
    [DebuggerDisplay("localVariable = {localVariable}, name = {name}")]
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
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugVariableSymbol.GetValue"/> method.
    /// </summary>
    [DebuggerDisplay("pcbValue = {pcbValue}, pValue = {pValue}")]
    public struct GetValueResult
    {
        /// <summary>
        /// [out] The number of bytes actually written to the pValue buffer.
        /// </summary>
        public int pcbValue { get; }

        /// <summary>
        /// [out] A byte array that contains the value of the variable.
        /// </summary>
        public byte[] pValue { get; }

        public GetValueResult(int pcbValue, byte[] pValue)
        {
            this.pcbValue = pcbValue;
            this.pValue = pValue;
        }
    }
}
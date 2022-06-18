using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedMethod.GetParameters"/> method.
    /// </summary>
    [DebuggerDisplay("pcParams = {pcParams}, @params = {@params}")]
    public struct GetParametersResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size of the buffer that is required to contain the parameters.
        /// </summary>
        public int pcParams { get; }

        /// <summary>
        /// A pointer to the buffer that receives the parameters.
        /// </summary>
        public ISymUnmanagedVariable[] @params { get; }

        public GetParametersResult(int pcParams, ISymUnmanagedVariable[] @params)
        {
            this.pcParams = pcParams;
            this.@params = @params;
        }
    }
}
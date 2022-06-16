using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetFailedAssemblyData"/> method.
    /// </summary>
    [DebuggerDisplay("pContext = {pContext}, pResult = {pResult}")]
    public struct GetFailedAssemblyDataResult
    {
        public int pContext { get; }

        public HRESULT pResult { get; }

        public GetFailedAssemblyDataResult(int pContext, HRESULT pResult)
        {
            this.pContext = pContext;
            this.pResult = pResult;
        }
    }
}
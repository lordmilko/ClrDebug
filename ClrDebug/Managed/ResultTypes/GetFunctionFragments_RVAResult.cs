using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.GetFunctionFragments_RVA"/> method.
    /// </summary>
    [DebuggerDisplay("pRvaFragment = {pRvaFragment}, pLenFragment = {pLenFragment}")]
    public struct GetFunctionFragments_RVAResult
    {
        public int pRvaFragment { get; }

        public int pLenFragment { get; }

        public GetFunctionFragments_RVAResult(int pRvaFragment, int pLenFragment)
        {
            this.pRvaFragment = pRvaFragment;
            this.pLenFragment = pLenFragment;
        }
    }
}

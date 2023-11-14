using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaSession.GetFunctionFragments_VA"/> method.
    /// </summary>
    [DebuggerDisplay("pVaFragment = {pVaFragment}, pLenFragment = {pLenFragment}")]
    public struct GetFunctionFragments_VAResult
    {
        public long pVaFragment { get; }

        public int pLenFragment { get; }

        public GetFunctionFragments_VAResult(long pVaFragment, int pLenFragment)
        {
            this.pVaFragment = pVaFragment;
            this.pLenFragment = pLenFragment;
        }
    }
}

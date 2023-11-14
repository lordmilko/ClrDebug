using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaStackWalkHelper.FunctionFragmentsForVA"/> method.
    /// </summary>
    [DebuggerDisplay("pVaFragment = {pVaFragment}, pLenFragment = {pLenFragment}")]
    public struct FunctionFragmentsForVAResult
    {
        public long pVaFragment { get; }

        public int pLenFragment { get; }

        public FunctionFragmentsForVAResult(long pVaFragment, int pLenFragment)
        {
            this.pVaFragment = pVaFragment;
            this.pLenFragment = pLenFragment;
        }
    }
}

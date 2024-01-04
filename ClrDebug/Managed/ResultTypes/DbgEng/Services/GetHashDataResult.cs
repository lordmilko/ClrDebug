using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSourceFile.GetHashData"/> method.
    /// </summary>
    [DebuggerDisplay("pHashData = {pHashData}, pHashAlgorithm = {pHashAlgorithm.ToString(),nq}")]
    public struct GetHashDataResult
    {
        public byte[] pHashData { get; }

        public SvcHashAlgorithm pHashAlgorithm { get; }

        public GetHashDataResult(byte[] pHashData, SvcHashAlgorithm pHashAlgorithm)
        {
            this.pHashData = pHashData;
            this.pHashAlgorithm = pHashAlgorithm;
        }
    }
}

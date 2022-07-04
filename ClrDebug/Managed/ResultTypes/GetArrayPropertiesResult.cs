using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.GetArrayProperties"/> method.
    /// </summary>
    [DebuggerDisplay("rank = {rank}, totalElements = {totalElements}, dims = {dims}, bases = {bases}")]
    public struct GetArrayPropertiesResult
    {
        public int[] rank { get; }

        public int totalElements { get; }

        public int[] dims { get; }

        public int[] bases { get; }

        public GetArrayPropertiesResult(int[] rank, int totalElements, int[] dims, int[] bases)
        {
            this.rank = rank;
            this.totalElements = totalElements;
            this.dims = dims;
            this.bases = bases;
        }
    }
}

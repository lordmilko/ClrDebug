using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetCodeRange"/> method.
    /// </summary>
    [DebuggerDisplay("pCodeStartAddress = {pCodeStartAddress}, pCodeSize = {pCodeSize}")]
    public struct GetCodeRangeResult
    {
        /// <summary>
        /// [out] A pointer to the starting address of the method.
        /// </summary>
        public int pCodeStartAddress { get; }

        /// <summary>
        /// A pointer to the method code size (the number of bytes of the method's code).
        /// </summary>
        public int pCodeSize { get; }

        public GetCodeRangeResult(int pCodeStartAddress, int pCodeSize)
        {
            this.pCodeStartAddress = pCodeStartAddress;
            this.pCodeSize = pCodeSize;
        }
    }
}
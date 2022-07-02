using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugDataTarget.GetImageFromPointer"/> method.
    /// </summary>
    [DebuggerDisplay("pImageBase = {pImageBase.ToString(),nq}, pSize = {pSize}")]
    public struct GetImageFromPointerResult
    {
        /// <summary>
        /// A <see cref="CORDB_ADDRESS"/> value that represents the module's base address.
        /// </summary>
        public CORDB_ADDRESS pImageBase { get; }

        /// <summary>
        /// A pointer to the module size.
        /// </summary>
        public int pSize { get; }

        public GetImageFromPointerResult(CORDB_ADDRESS pImageBase, int pSize)
        {
            this.pImageBase = pImageBase;
            this.pSize = pSize;
        }
    }
}
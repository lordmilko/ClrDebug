using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugSymbolProvider.GetFrameProps"/> method.
    /// </summary>
    [DebuggerDisplay("pCodeStartRva = {pCodeStartRva}, pParentFrameStartRva = {pParentFrameStartRva}")]
    public struct GetFramePropsResult
    {
        /// <summary>
        /// A pointer to the method's starting relative virtual address.
        /// </summary>
        public int pCodeStartRva { get; }

        /// <summary>
        /// A pointer to the frame's starting relative virtual address.
        /// </summary>
        public int pParentFrameStartRva { get; }

        public GetFramePropsResult(int pCodeStartRva, int pParentFrameStartRva)
        {
            this.pCodeStartRva = pCodeStartRva;
            this.pParentFrameStartRva = pParentFrameStartRva;
        }
    }
}

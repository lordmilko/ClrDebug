using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSecurityConfiguration.GetPointerAuthenticationMask"/> method.
    /// </summary>
    [DebuggerDisplay("pDataMask = {pDataMask}, pInstructionMask = {pInstructionMask}")]
    public struct GetPointerAuthenticationMaskResult
    {
        public long pDataMask { get; }

        public long pInstructionMask { get; }

        public GetPointerAuthenticationMaskResult(long pDataMask, long pInstructionMask)
        {
            this.pDataMask = pDataMask;
            this.pInstructionMask = pInstructionMask;
        }
    }
}

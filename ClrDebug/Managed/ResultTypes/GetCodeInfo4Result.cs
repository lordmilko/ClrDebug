using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetCodeInfo4"/> method.
    /// </summary>
    [DebuggerDisplay("pcCodeInfos = {pcCodeInfos}, codeInfos = {codeInfos}")]
    public struct GetCodeInfo4Result
    {
        /// <summary>
        /// A pointer to the total number of <see cref="COR_PRF_CODE_INFO"/> structures available.
        /// </summary>
        public int pcCodeInfos { get; }

        /// <summary>
        /// A caller-provided buffer. After the method returns, it contains an array of COR_PRF_CODE_INFO structures, each of which describes a block of native code.
        /// </summary>
        public COR_PRF_CODE_INFO[] codeInfos { get; }

        public GetCodeInfo4Result(int pcCodeInfos, COR_PRF_CODE_INFO[] codeInfos)
        {
            this.pcCodeInfos = pcCodeInfos;
            this.codeInfos = codeInfos;
        }
    }
}

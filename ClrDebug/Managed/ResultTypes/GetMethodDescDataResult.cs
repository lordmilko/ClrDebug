using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetMethodDescData"/> method.
    /// </summary>
    [DebuggerDisplay("data = {data.ToString(),nq}, rgRevertedRejitData = {rgRevertedRejitData}")]
    public struct GetMethodDescDataResult
    {
        /// <summary>
        /// The data associated with the MethodDesc as returned from the internal APIs.
        /// </summary>
        public DacpMethodDescData data { get; }

        /// <summary>
        /// The data associated with the reverted rejit versions as returned from the internal APIs.
        /// </summary>
        public DacpReJitData[] rgRevertedRejitData { get; }

        public GetMethodDescDataResult(DacpMethodDescData data, DacpReJitData[] rgRevertedRejitData)
        {
            this.data = data;
            this.rgRevertedRejitData = rgRevertedRejitData;
        }
    }
}

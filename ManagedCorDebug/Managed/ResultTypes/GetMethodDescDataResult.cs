using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetMethodDescData"/> method.
    /// </summary>
    [DebuggerDisplay("data = {data}, rgRevertedRejitData = {rgRevertedRejitData}")]
    public struct GetMethodDescDataResult
    {
        public DacpMethodDescData data { get; }

        public DacpReJitData[] rgRevertedRejitData { get; }

        public GetMethodDescDataResult(DacpMethodDescData data, DacpReJitData[] rgRevertedRejitData)
        {
            this.data = data;
            this.rgRevertedRejitData = rgRevertedRejitData;
        }
    }
}
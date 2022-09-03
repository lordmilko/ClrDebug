using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ComTypeLib.FindName"/> method.
    /// </summary>
    [DebuggerDisplay("ppTInfo = {ppTInfo}, rgMemId = {rgMemId}, pcFound = {pcFound}")]
    public struct FindNameResult
    {
        /// <summary>
        /// When this method returns, contains an array of pointers to the type descriptions that contain the name specified in szNameBuf. This parameter is passed uninitialized.
        /// </summary>
        public ITypeInfo[] ppTInfo { get; }

        /// <summary>
        /// An array of the <see langword="MEMBERID"/> 's of the found items; rgMemId[i] is the <see langword="MEMBERID"/> that indexes into the type description specified by ppTInfo[i]. Cannot be <see langword="null"/>.
        /// </summary>
        public int[] rgMemId { get; }

        /// <summary>On entry, indicates how many instances to look for. For example, pcFound = 1 can be called to find the first occurrence. The search stops when one instance is found.
        /// On exit, indicates the number of instances that were found. If the <see langword="in"/> and <see langword="out"/> values of pcFound are identical, there might be more type descriptions that contain the name.
        /// </summary>
        public short pcFound { get; }

        public FindNameResult(ITypeInfo[] ppTInfo, int[] rgMemId, short pcFound)
        {
            this.ppTInfo = ppTInfo;
            this.rgMemId = rgMemId;
            this.pcFound = pcFound;
        }
    }
}

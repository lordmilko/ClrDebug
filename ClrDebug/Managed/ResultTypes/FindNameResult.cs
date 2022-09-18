using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ComTypeLib.FindName"/> method.
    /// </summary>
    [DebuggerDisplay("ppTInfo = {ppTInfo}, rgMemId = {rgMemId}")]
    public struct FindNameResult
    {
        /// <summary>
        /// When this method returns, contains an array of pointers to the type descriptions that contain the name specified in szNameBuf. This parameter is passed uninitialized.
        /// </summary>
        public TypeInfo[] ppTInfo { get; }

        /// <summary>
        /// An array of the <see langword="MEMBERID"/> 's of the found items; rgMemId[i] is the <see langword="MEMBERID"/> that indexes into the type description specified by ppTInfo[i]. Cannot be <see langword="null"/>.
        /// </summary>
        public int[] rgMemId { get; }

        public FindNameResult(TypeInfo[] ppTInfo, int[] rgMemId)
        {
            this.ppTInfo = ppTInfo;
            this.rgMemId = rgMemId;
        }
    }
}

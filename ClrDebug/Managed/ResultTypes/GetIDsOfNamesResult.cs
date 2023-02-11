using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeInfo.GetIDsOfNames"/> method.
    /// </summary>
    [DebuggerDisplay("rgszNames = {rgszNames}, pMemId = {pMemId}")]
    public struct GetIDsOfNamesResult
    {
        /// <summary>
        /// An array of names to map.
        /// </summary>
        public string[] rgszNames { get; }

        /// <summary>
        /// When this method returns, contains a reference to an array in which name mappings are placed. This parameter is passed uninitialized.
        /// </summary>
        public int[] pMemId { get; }

        public GetIDsOfNamesResult(string[] rgszNames, int[] pMemId)
        {
            this.rgszNames = rgszNames;
            this.pMemId = pMemId;
        }
    }
}

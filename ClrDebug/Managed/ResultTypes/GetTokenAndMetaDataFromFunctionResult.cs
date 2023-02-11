using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetTokenAndMetaDataFromFunction"/> method.
    /// </summary>
    [DebuggerDisplay("ppImport = {ppImport}, pToken = {pToken.ToString(),nq}")]
    public struct GetTokenAndMetaDataFromFunctionResult
    {
        /// <summary>
        /// A pointer to the address of the metadata interface instance that can be used against the token for the specified function.
        /// </summary>
        public object ppImport { get; }

        /// <summary>
        /// A pointer to the metadata token for the specified function.
        /// </summary>
        public mdToken pToken { get; }

        public GetTokenAndMetaDataFromFunctionResult(object ppImport, mdToken pToken)
        {
            this.ppImport = ppImport;
            this.pToken = pToken;
        }
    }
}

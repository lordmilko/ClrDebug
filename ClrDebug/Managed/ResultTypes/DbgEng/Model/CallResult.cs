using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelMethod.Call"/> method.
    /// </summary>
    [DebuggerDisplay("ppResult = {ppResult?.ToString(),nq}, ppMetadata = {ppMetadata?.ToString(),nq}")]
    public struct CallResult
    {
        /// <summary>
        /// The return value of the call. In the event that the call semantically returns nothing, a boxed no value object will be returned.<para/>
        /// Should the call fail (as indicated by a failing HRESULT), optional extended error information may be present here.
        /// </summary>
        public ModelObject ppResult { get; }

        /// <summary>
        /// Optional metadata about the call result may be placed here.
        /// </summary>
        public KeyStore ppMetadata { get; }

        public CallResult(ModelObject ppResult, KeyStore ppMetadata)
        {
            this.ppResult = ppResult;
            this.ppMetadata = ppMetadata;
        }
    }
}

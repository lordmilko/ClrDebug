using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Describes the fields necessary to configure an EventPipe provider.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_EVENTPIPE_PROVIDER_CONFIG structure is used by the <see cref="ICorProfilerInfo12.EventPipeAddProviderToSession"/>
    /// method to indicate the configuration for the provider being added to the session.
    /// </remarks>
    [DebuggerDisplay("providerName = {providerName}, keywords = {keywords.ToString(),nq}, loggingLevel = {loggingLevel.ToString(),nq}, filterData = {filterData}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public partial struct COR_PRF_EVENTPIPE_PROVIDER_CONFIG
    {
        //From genanalysis.cpp
        public enum Keyword : long
        {
            /// <summary>
            /// This keyword is necessary for the type names
            /// </summary>
            GCHeapAndTypeNamesKeyword = 0x00001000000,

            /// <summary>
            /// This keyword is necessary for the generation range data.
            /// </summary>
            GCHeapSurvivalAndMovementKeyword = 0x00000400000,

            /// <summary>
            /// This keyword is necessary for enabling walking the heap
            /// </summary>
            GCHeapDumpKeyword = 0x00000100000,

            /// <summary>
            /// This keyword is necessary for enabling BulkType events
            /// </summary>
            TypeKeyword = 0x00000080000
        }

        /// <summary>
        /// The name of the provider to enable.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string providerName;

        /// <summary>
        /// The keywords to enable on the provider.
        /// </summary>
        public Keyword keywords;

        /// <summary>
        /// The level to enable on the provider.
        /// </summary>
        public COR_PRF_EVENTPIPE_LEVEL loggingLevel;

        /// <summary>
        /// A wide character string containing the filterdata to use when enabling the provider.<para/>
        /// filterData expects a semicolon delimited string that defines key value pairs
        /// such as "key1=value1;key2=value2;". Quotes can be used to escape the '=' and ';'
        /// characters.<para/>These key value pairs will be passed in the enable callback to event
        /// providers.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string filterData;
    }
}

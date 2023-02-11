using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetAppDomainInfo"/> method.
    /// </summary>
    [DebuggerDisplay("szName = {szName}, pProcessId = {pProcessId.ToString(),nq}")]
    public struct GetAppDomainInfoResult
    {
        /// <summary>
        /// A caller-provided wide character buffer. When the method returns, szName will contain the full or partial application domain name.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// A pointer to the ID of the process that contains the application domain.
        /// </summary>
        public ProcessID pProcessId { get; }

        public GetAppDomainInfoResult(string szName, ProcessID pProcessId)
        {
            this.szName = szName;
            this.pProcessId = pProcessId;
        }
    }
}

using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetAppDomainsContainingModule"/> method.
    /// </summary>
    [DebuggerDisplay("pcAppDomainIds = {pcAppDomainIds}, appDomainIds = {appDomainIds.ToString(),nq}")]
    public struct GetAppDomainsContainingModuleResult
    {
        /// <summary>
        /// A pointer to the total number of returned elements.
        /// </summary>
        public int pcAppDomainIds { get; }

        /// <summary>
        /// An array of application domain ID values.
        /// </summary>
        public AppDomainID appDomainIds { get; }

        public GetAppDomainsContainingModuleResult(int pcAppDomainIds, AppDomainID appDomainIds)
        {
            this.pcAppDomainIds = pcAppDomainIds;
            this.appDomainIds = appDomainIds;
        }
    }
}

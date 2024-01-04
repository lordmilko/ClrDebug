using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="HostDataModelAccess.DataModel"/> property.
    /// </summary>
    [DebuggerDisplay("manager = {manager?.ToString(),nq}, host = {host?.ToString(),nq}")]
    public struct GetDataModelResult
    {
        /// <summary>
        /// An interface to the data model manager is returned here.
        /// </summary>
        public DataModelManager manager { get; }

        /// <summary>
        /// The core interface of the debug host is returned here.
        /// </summary>
        public DebugHost host { get; }

        public GetDataModelResult(DataModelManager manager, DebugHost host)
        {
            this.manager = manager;
            this.host = host;
        }
    }
}

using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetScopeProps"/> method.
    /// </summary>
    [DebuggerDisplay("szName = {szName}, pmvid = {pmvid}")]
    public struct GetScopePropsResult
    {
        /// <summary>
        /// [out] A buffer for the assembly or module name.
        /// </summary>
        public string szName { get; }

        /// <summary>
        /// [out, optional] A pointer to a GUID that uniquely identifies the version of the assembly or module.
        /// </summary>
        public Guid pmvid { get; }

        public GetScopePropsResult(string szName, Guid pmvid)
        {
            this.szName = szName;
            this.pmvid = pmvid;
        }
    }
}
using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ComTypeLib.CustData"/> property.
    /// </summary>
    [DebuggerDisplay("guid = {guid.ToString(),nq}, pVarVal = {pVarVal}")]
    public struct GetCustDataResult
    {
        /// <summary>
        /// A <see cref="Guid"/>, passed by reference, that is used to identify the data.
        /// </summary>
        public Guid guid { get; }

        /// <summary>
        /// When this method returns, contains an object that specifies where to put the retrieved data. This parameter is passed uninitialized.
        /// </summary>
        public object pVarVal { get; }

        public GetCustDataResult(Guid guid, object pVarVal)
        {
            this.guid = guid;
            this.pVarVal = pVarVal;
        }
    }
}

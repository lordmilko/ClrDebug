using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeInfo.CreateInstance"/> method.
    /// </summary>
    [DebuggerDisplay("riid = {riid.ToString(),nq}, ppvObj = {ppvObj}")]
    public struct CreateInstanceResult
    {
        /// <summary>
        /// The IID of the interface that the caller uses to communicate with the resulting object.
        /// </summary>
        public Guid riid { get; }

        /// <summary>
        /// When this method returns, contains a reference to the created object. This parameter is passed uninitialized.
        /// </summary>
        public object ppvObj { get; }

        public CreateInstanceResult(Guid riid, object ppvObj)
        {
            this.riid = riid;
            this.ppvObj = ppvObj;
        }
    }
}

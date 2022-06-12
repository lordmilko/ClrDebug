using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataDispenserEx.OpenScopeOnITypeInfo"/> method.
    /// </summary>
    [DebuggerDisplay("riid = {riid}, ppIUnk = {ppIUnk}")]
    public struct OpenScopeOnITypeInfoResult
    {
        /// <summary>
        /// [in] The desired interface.
        /// </summary>
        public Guid riid { get; }

        /// <summary>
        /// [out] Pointer to a pointer to the returned interface.
        /// </summary>
        public object ppIUnk { get; }

        public OpenScopeOnITypeInfoResult(Guid riid, object ppIUnk)
        {
            this.riid = riid;
            this.ppIUnk = ppIUnk;
        }
    }
}
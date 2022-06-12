using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataDispenserEx.OpenScopeOnITypeInfo"/> method.
    /// </summary>
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
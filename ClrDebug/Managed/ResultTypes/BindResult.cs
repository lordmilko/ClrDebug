using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeComp.Bind"/> method.
    /// </summary>
    [DebuggerDisplay("ppTInfo = {ppTInfo.ToString(),nq}, pDescKind = {pDescKind.ToString(),nq}, pBindPtr = {pBindPtr.ToString(),nq}")]
    public struct BindResult
    {
        /// <summary>
        /// When this method returns, contains a reference to the type description that contains the item to which it is bound, if a FUNCDESC or VARDESC was returned. This parameter is passed uninitialized.
        /// </summary>
        public TypeInfo ppTInfo { get; }

        /// <summary>
        /// When this method returns, contains a reference to a DESCKIND enumerator that indicates whether the name bound-to is a VARDESC, FUNCDESC, or TYPECOMP. This parameter is passed uninitialized.
        /// </summary>
        public DESCKIND pDescKind { get; }

        /// <summary>
        /// When this method returns, contains a reference to the bound-to VARDESC, FUNCDESC, or ITypeComp interface. This parameter is passed uninitialized.
        /// </summary>
        public BINDPTR pBindPtr { get; }

        public BindResult(TypeInfo ppTInfo, DESCKIND pDescKind, BINDPTR pBindPtr)
        {
            this.ppTInfo = ppTInfo;
            this.pDescKind = pDescKind;
            this.pBindPtr = pBindPtr;
        }
    }
}

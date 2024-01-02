using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeComp.BindType"/> method.
    /// </summary>
    [DebuggerDisplay("ppTInfo = {ppTInfo?.ToString(),nq}, ppTComp = {ppTComp?.ToString(),nq}")]
    public struct BindTypeResult
    {
        /// <summary>
        /// When this method returns, contains a reference to an ITypeInfo of the type to which szName was bound. This parameter is passed uninitialized.
        /// </summary>
        public TypeInfo ppTInfo { get; }

        /// <summary>
        /// When this method returns, contains a reference to an ITypeComp variable. This parameter is passed uninitialized.
        /// </summary>
        public TypeComp ppTComp { get; }

        public BindTypeResult(TypeInfo ppTInfo, TypeComp ppTComp)
        {
            this.ppTInfo = ppTInfo;
            this.ppTComp = ppTComp;
        }
    }
}

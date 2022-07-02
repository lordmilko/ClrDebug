using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetGenericParamProps"/> method.
    /// </summary>
    [DebuggerDisplay("pulParamSeq = {pulParamSeq}, pdwParamFlags = {pdwParamFlags.ToString(),nq}, ptOwner = {ptOwner.ToString(),nq}, reserved = {reserved}, wzname = {wzname}")]
    public struct GetGenericParamPropsResult
    {
        /// <summary>
        /// The ordinal position of the Type parameter in the parent constructor or method.
        /// </summary>
        public int pulParamSeq { get; }

        /// <summary>
        /// A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the Type for the generic parameter.
        /// </summary>
        public CorGenericParamAttr pdwParamFlags { get; }

        /// <summary>
        /// A TypeDef or MethodDef token that represents the owner of the parameter.
        /// </summary>
        public mdToken ptOwner { get; }

        /// <summary>
        /// Reserved for future extensibility.
        /// </summary>
        public int reserved { get; }

        /// <summary>
        /// The name of the generic parameter.
        /// </summary>
        public string wzname { get; }

        public GetGenericParamPropsResult(int pulParamSeq, CorGenericParamAttr pdwParamFlags, mdToken ptOwner, int reserved, string wzname)
        {
            this.pulParamSeq = pulParamSeq;
            this.pdwParamFlags = pdwParamFlags;
            this.ptOwner = ptOwner;
            this.reserved = reserved;
            this.wzname = wzname;
        }
    }
}
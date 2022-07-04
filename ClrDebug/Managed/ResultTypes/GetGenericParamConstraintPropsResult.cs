using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetGenericParamConstraintProps"/> method.
    /// </summary>
    [DebuggerDisplay("ptGenericParam = {ptGenericParam.ToString(),nq}, ptkConstraintType = {ptkConstraintType.ToString(),nq}")]
    public struct GetGenericParamConstraintPropsResult
    {
        /// <summary>
        /// A pointer to the token that represents the generic parameter that is constrained.
        /// </summary>
        public mdGenericParam ptGenericParam { get; }

        /// <summary>
        /// A pointer to a TypeDef, TypeRef, or TypeSpec token that represents a constraint on ptGenericParam.
        /// </summary>
        public mdToken ptkConstraintType { get; }

        public GetGenericParamConstraintPropsResult(mdGenericParam ptGenericParam, mdToken ptkConstraintType)
        {
            this.ptGenericParam = ptGenericParam;
            this.ptkConstraintType = ptkConstraintType;
        }
    }
}

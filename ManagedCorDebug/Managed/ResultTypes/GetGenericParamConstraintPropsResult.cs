using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetGenericParamConstraintProps"/> method.
    /// </summary>
    [DebuggerDisplay("ptGenericParam = {ptGenericParam}, ptkConstraintType = {ptkConstraintType}")]
    public struct GetGenericParamConstraintPropsResult
    {
        /// <summary>
        /// [out] A pointer to the token that represents the generic parameter that is constrained.
        /// </summary>
        public mdGenericParam ptGenericParam { get; }

        /// <summary>
        /// [out] A pointer to a TypeDef, TypeRef, or TypeSpec token that represents a constraint on ptGenericParam.
        /// </summary>
        public mdToken ptkConstraintType { get; }

        public GetGenericParamConstraintPropsResult(mdGenericParam ptGenericParam, mdToken ptkConstraintType)
        {
            this.ptGenericParam = ptGenericParam;
            this.ptkConstraintType = ptkConstraintType;
        }
    }
}
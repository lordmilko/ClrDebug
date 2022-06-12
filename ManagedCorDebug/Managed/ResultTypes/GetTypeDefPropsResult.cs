using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetTypeDefProps"/> method.
    /// </summary>
    [DebuggerDisplay("szTypeDef = {szTypeDef}, pdwTypeDefFlags = {pdwTypeDefFlags}, ptkExtends = {ptkExtends}")]
    public struct GetTypeDefPropsResult
    {
        /// <summary>
        /// [out] A buffer containing the type name.
        /// </summary>
        public string szTypeDef { get; }

        /// <summary>
        /// [out] A pointer to any flags that modify the type definition. This value is a bitmask from the <see cref="CorTypeAttr"/> enumeration.
        /// </summary>
        public CorTypeAttr pdwTypeDefFlags { get; }

        /// <summary>
        /// [out] A TypeDef or TypeRef metadata token that represents the base type of the requested type.
        /// </summary>
        public mdToken ptkExtends { get; }

        public GetTypeDefPropsResult(string szTypeDef, CorTypeAttr pdwTypeDefFlags, mdToken ptkExtends)
        {
            this.szTypeDef = szTypeDef;
            this.pdwTypeDefFlags = pdwTypeDefFlags;
            this.ptkExtends = ptkExtends;
        }
    }
}
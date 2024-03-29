﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetTypeDefProps"/> method.
    /// </summary>
    [DebuggerDisplay("szTypeDef = {szTypeDef}, pdwTypeDefFlags = {pdwTypeDefFlags.ToString(),nq}, ptkExtends = {ptkExtends.ToString(),nq}")]
    public struct GetTypeDefPropsResult
    {
        /// <summary>
        /// A buffer containing the type name.
        /// </summary>
        public string szTypeDef { get; }

        /// <summary>
        /// A pointer to any flags that modify the type definition. This value is a bitmask from the <see cref="CorTypeAttr"/> enumeration.
        /// </summary>
        public CorTypeAttr pdwTypeDefFlags { get; }

        /// <summary>
        /// A TypeDef or TypeRef metadata token that represents the base type of the requested type.
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

using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumPermissionSets"/> method.
    /// </summary>
    public struct EnumPermissionSetsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the Permission tokens.
        /// </summary>
        public mdPermission[] rPermission { get; }

        /// <summary>
        /// [out] The number of Permission tokens returned in rPermission.
        /// </summary>
        public int pcTokens { get; }

        public EnumPermissionSetsResult(IntPtr phEnum, mdPermission[] rPermission, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rPermission = rPermission;
            this.pcTokens = pcTokens;
        }
    }
}
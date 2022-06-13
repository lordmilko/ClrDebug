using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumPermissionSets"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rPermission = {rPermission}, pcTokens = {pcTokens}")]
    public struct EnumPermissionSetsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the Permission tokens.
        /// </summary>
        public mdPermission[] rPermission { get; }

        /// <summary>
        /// The number of Permission tokens returned in rPermission.
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
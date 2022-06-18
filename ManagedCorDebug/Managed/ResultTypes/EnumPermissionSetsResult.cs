using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumPermissionSets"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rPermission = {rPermission}")]
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

        public EnumPermissionSetsResult(IntPtr phEnum, mdPermission[] rPermission)
        {
            this.phEnum = phEnum;
            this.rPermission = rPermission;
        }
    }
}
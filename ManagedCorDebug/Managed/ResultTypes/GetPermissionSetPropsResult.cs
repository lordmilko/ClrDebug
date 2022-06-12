using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetPermissionSetProps"/> method.
    /// </summary>
    [DebuggerDisplay("pdwAction = {pdwAction}, ppvPermission = {ppvPermission}, pcbPermission = {pcbPermission}")]
    public struct GetPermissionSetPropsResult
    {
        /// <summary>
        /// [out] A pointer to the permission set.
        /// </summary>
        public int pdwAction { get; }

        /// <summary>
        /// [out] A pointer to the binary metadata signature of the permission set.
        /// </summary>
        public IntPtr ppvPermission { get; }

        /// <summary>
        /// [out] The size in bytes of ppvPermission.
        /// </summary>
        public int pcbPermission { get; }

        public GetPermissionSetPropsResult(int pdwAction, IntPtr ppvPermission, int pcbPermission)
        {
            this.pdwAction = pdwAction;
            this.ppvPermission = ppvPermission;
            this.pcbPermission = pcbPermission;
        }
    }
}
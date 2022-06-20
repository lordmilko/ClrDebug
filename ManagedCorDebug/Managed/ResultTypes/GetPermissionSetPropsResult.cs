using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetPermissionSetProps"/> method.
    /// </summary>
    [DebuggerDisplay("pdwAction = {pdwAction.ToString(),nq}, ppvPermission = {ppvPermission.ToString(),nq}, pcbPermission = {pcbPermission}")]
    public struct GetPermissionSetPropsResult
    {
        /// <summary>
        /// A pointer to the permission set.
        /// </summary>
        public CorDeclSecurity pdwAction { get; }

        /// <summary>
        /// A pointer to the binary metadata signature of the permission set.
        /// </summary>
        public IntPtr ppvPermission { get; }

        /// <summary>
        /// The size in bytes of ppvPermission.
        /// </summary>
        public int pcbPermission { get; }

        public GetPermissionSetPropsResult(CorDeclSecurity pdwAction, IntPtr ppvPermission, int pcbPermission)
        {
            this.pdwAction = pdwAction;
            this.ppvPermission = ppvPermission;
            this.pcbPermission = pcbPermission;
        }
    }
}
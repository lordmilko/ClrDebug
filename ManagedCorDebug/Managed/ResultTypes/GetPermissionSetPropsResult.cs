using System;

namespace ManagedCorDebug
{
    public struct GetPermissionSetPropsResult
    {
        public int PdwAction { get; }

        public IntPtr PpvPermission { get; }

        public int PcbPermission { get; }

        public GetPermissionSetPropsResult(int pdwAction, IntPtr ppvPermission, int pcbPermission)
        {
            PdwAction = pdwAction;
            PpvPermission = ppvPermission;
            PcbPermission = pcbPermission;
        }
    }
}
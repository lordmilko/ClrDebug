using System;

namespace ManagedCorDebug
{
    public struct GetPermissionSetPropsResult
    {
        public uint PdwAction { get; }

        public IntPtr PpvPermission { get; }

        public uint PcbPermission { get; }

        public GetPermissionSetPropsResult(uint pdwAction, IntPtr ppvPermission, uint pcbPermission)
        {
            PdwAction = pdwAction;
            PpvPermission = ppvPermission;
            PcbPermission = pcbPermission;
        }
    }
}
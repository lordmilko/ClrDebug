using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("StructSize = {StructSize}, ServiceGuid = {ServiceGuid.ToString(),nq}, PrimaryCondition = {PrimaryCondition.ToString(),nq}, SecondaryCondition = {SecondaryCondition.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcConditionalServiceInformation
    {
        public int StructSize;
        public Guid ServiceGuid;
        public Guid PrimaryCondition;
        public Guid SecondaryCondition;
    }
}

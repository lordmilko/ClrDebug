using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcConditionalServiceInformation
    {
        public int StructSize;
        public Guid ServiceGuid;
        public Guid PrimaryCondition;
        public Guid SecondaryCondition;
    }
}

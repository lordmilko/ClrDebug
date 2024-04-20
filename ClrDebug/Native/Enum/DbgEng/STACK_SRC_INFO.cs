using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public struct STACK_SRC_INFO
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ImagePath;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string ModuleName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string Function;

        public int Displacement;
        public int Row;
        public int Column;
    }
}

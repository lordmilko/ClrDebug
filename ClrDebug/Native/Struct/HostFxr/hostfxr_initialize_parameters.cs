using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public partial struct hostfxr_initialize_parameters
    {
        public IntPtr size;

        [MarshalAs(UnmanagedType.LPTStr)]
        public string host_path;

        [MarshalAs(UnmanagedType.LPTStr)]
        public string dotnet_root;
    }
}

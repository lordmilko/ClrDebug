using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("size = {size.ToString(),nq}, host_path = {host_path}, dotnet_root = {dotnet_root}")]
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

using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Parameters for <see cref="get_hostfxr_path_fn"/> 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public partial struct get_hostfxr_parameters
    {
        /// <summary>
        /// Size of the struct. This is used for versioning.
        /// </summary>
        public IntPtr size;

        /// <summary>
        /// Path to the component's assembly.<para/>
        /// If specified, hostfxr is located as if the assembly_path is the apphost.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string assembly_path;

        /// <summary>
        /// Path to directory containing the dotnet executable.<para/>
        /// If specified, hostfxr is located as if an application is started using
        /// 'dotnet app.dll', which means it will be searched for under the dotnet_root
        /// path and the assembly_path is ignored.
        /// </summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string dotnet_root;
    }
}

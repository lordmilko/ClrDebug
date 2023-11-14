using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("size = {size.ToString(),nq}, name = {name}, version = {version}, path = {path}")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct hostfxr_dotnet_environment_framework_info
    {
        public IntPtr size;

        //All strings UTF16 on Windows, UTF8 on Unix
        public IntPtr name;
        public IntPtr version;
        public IntPtr path;

        internal HostFxrDotnetEnvironmentFrameworkInfo ToManaged()
        {
            return new HostFxrDotnetEnvironmentFrameworkInfo
            {
                size = size,
                name = CrossPlatformStringMarshaller.ConvertToManaged(name),
                version = CrossPlatformStringMarshaller.ConvertToManaged(version),
                path = CrossPlatformStringMarshaller.ConvertToManaged(path)
            };
        }
    }

    [DebuggerDisplay("size = {size.ToString(),nq}, name = {name}, version = {version}, path = {path}")]
    public struct HostFxrDotnetEnvironmentFrameworkInfo
    {
        public IntPtr size;
        public string name;
        public string version;
        public string path;
    }
}

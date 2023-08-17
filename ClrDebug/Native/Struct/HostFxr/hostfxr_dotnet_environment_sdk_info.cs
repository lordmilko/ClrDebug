using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct hostfxr_dotnet_environment_sdk_info
    {
        public IntPtr size;

        //All strings UTF16 on Windows, UTF8 on Unix
        public IntPtr version;
        public IntPtr path;

        internal HostFxrDotnetEnvironmentSdkInfo ToManaged()
        {
            return new HostFxrDotnetEnvironmentSdkInfo
            {
                size = size,
                version = CrossPlatformStringMarshaller.ConvertToManaged(version),
                path = CrossPlatformStringMarshaller.ConvertToManaged(path)
            };
        }
    }

    public struct HostFxrDotnetEnvironmentSdkInfo
    {
        public IntPtr size;
        public string version;
        public string path;
    }
}

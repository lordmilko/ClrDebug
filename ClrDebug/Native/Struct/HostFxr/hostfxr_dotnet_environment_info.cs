using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public unsafe struct hostfxr_dotnet_environment_info
    {
        public IntPtr size;

        public IntPtr hostfxr_version;
        public IntPtr hostfxr_commit_hash;

        public IntPtr sdk_count;
        public hostfxr_dotnet_environment_sdk_info* sdks;

        public IntPtr framework_count;
        public hostfxr_dotnet_environment_framework_info* frameworks;

        internal HostFxrDotnetEnvironmentInfo ToManaged()
        {
            return new HostFxrDotnetEnvironmentInfo
            {
                size = size,
                hostfxr_version = CrossPlatformStringMarshaller.ConvertToManaged(hostfxr_version),
                hostfxr_commit_hash = CrossPlatformStringMarshaller.ConvertToManaged(hostfxr_commit_hash),

                sdk_count = sdk_count,

                sdks = (IntPtr) sdks != IntPtr.Zero ? sdks->ToManaged() : default,

                framework_count = framework_count,
                frameworks = (IntPtr) frameworks != IntPtr.Zero ? frameworks->ToManaged() : default
            };
        }
    }

    public struct HostFxrDotnetEnvironmentInfo
    {
        public IntPtr size;
        public string hostfxr_version;
        public string hostfxr_commit_hash;

        public IntPtr sdk_count;
        public HostFxrDotnetEnvironmentSdkInfo sdks;

        public IntPtr framework_count;
        public HostFxrDotnetEnvironmentFrameworkInfo frameworks;
    }
}

using System.Runtime.InteropServices;

namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Gets the <see cref="ICLRRuntimeInfo"/> interface that corresponds to the common language runtime version that is running in the current process.
        /// </summary>
        /// <param name="metaHost">The <see cref="CLRMetaHost"/> that is used to retrieve the runtime.</param>
        /// <returns>A <see cref="CLRRuntimeInfo"/> object for the common language runtime version that is running in the current process.</returns>
        public static CLRRuntimeInfo GetRuntime(this CLRMetaHost metaHost) =>
            GetRuntime(metaHost, RuntimeEnvironment.GetSystemVersion());

        /// <summary>
        /// Gets the <see cref="ICLRRuntimeInfo"/> interface that corresponds to a particular version of the common language runtime (CLR).
        /// </summary>
        /// <param name="metaHost">The <see cref="CLRMetaHost"/> that is used to retrieve the runtime.</param>
        /// <param name="version">[in] The .NET Framework compilation version stored in the metadata, in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.<para/>
        /// Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.X", where X depends on the build number installed.</param>
        /// <returns>A <see cref="CLRRuntimeInfo"/> object for the specified common language runtime version.</returns>
        public static CLRRuntimeInfo GetRuntime(this CLRMetaHost metaHost, string version) =>
            new CLRRuntimeInfo((ICLRRuntimeInfo) metaHost.GetRuntime(version, typeof(ICLRRuntimeInfo).GUID));
    }
}

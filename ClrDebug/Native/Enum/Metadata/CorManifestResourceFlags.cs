using System;

namespace ClrDebug
{
    /// <summary>
    /// Indicates the visibility of resources encoded in an assembly manifest.
    /// </summary>
    [Flags]
    public enum CorManifestResourceFlags : uint
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        mrVisibilityMask = 0x0007,

        /// <summary>
        /// The resources are public.
        /// </summary>
        mrPublic = 0x0001,     // The Resource is exported from the Assembly.

        /// <summary>
        /// The resources are private.
        /// </summary>
        mrPrivate = 0x0002,     // The Resource is private to the Assembly.
    }
}
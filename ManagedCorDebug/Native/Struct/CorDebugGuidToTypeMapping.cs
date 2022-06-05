using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Maps a Windows Runtime GUID to its corresponding ICorDebugType object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CorDebugGuidToTypeMapping
    {
        /// <summary>
        /// The GUID of the cached Windows Runtime type.
        /// </summary>
        public Guid iid;

        /// <summary>
        /// A pointer to an ICorDebugType object that provides information about the cached type.
        /// </summary>
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugType pType;
    }
}
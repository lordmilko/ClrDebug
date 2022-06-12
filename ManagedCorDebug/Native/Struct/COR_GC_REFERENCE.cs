using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains information about an object that is to be garbage-collected.
    /// </summary>
    /// <remarks>
    /// The type field is a <see cref="CorGCReferenceType"/> enumeration value that indicates where the reference came
    /// from. A particular <see cref="COR_GC_REFERENCE"/> value can reflect any of the following kinds of managed objects: The extraData
    /// field contains extra data depending on the source (or type) of the reference. Possible values are:
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_GC_REFERENCE
    {
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugAppDomain Domain;
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugValue Location;

        /// <summary>
        /// A <see cref="CorGCReferenceType"/> enumeration value that indicates where the root came from. For more information, see the Remarks section.
        /// </summary>
        public CorGCReferenceType type;
        public long ExtraData;
    }
}
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Contains information about an object that is to be garbage-collected.
    /// </summary>
    /// <remarks>
    /// The type field is a <see cref="CorGCReferenceType"/> enumeration value that indicates where the reference came
    /// from. A particular <see cref="COR_GC_REFERENCE"/> value can reflect any of the following kinds of managed objects: The extraData
    /// field contains extra data depending on the source (or type) of the reference. Possible values are:
    /// </remarks>
    [DebuggerDisplay("Domain = {Domain?.ToString(),nq}, Location = {Location?.ToString(),nq}, type = {type.ToString(),nq}, ExtraData = {ExtraData}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public partial struct COR_GC_REFERENCE
    {
        [MarshalAs(UnmanagedType.Interface)]
        public ICorDebugAppDomain Domain;

        [MarshalAs(UnmanagedType.Interface)]
        public ICorDebugValue Location;

        /// <summary>
        /// A <see cref="CorGCReferenceType"/> enumeration value that indicates where the root came from. For more information, see the Remarks section.
        /// </summary>
        public CorGCReferenceType type;
        public long ExtraData;
    }
}

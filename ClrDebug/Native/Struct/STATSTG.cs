using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug
{
    /// <summary>
    /// The STATSTG structure contains statistical data about an open storage, stream, or byte-array object.
    /// This structure is used in the <see cref="IEnumSTATSTG"/>, ILockBytes, <see cref="IStorage"/>, and <see cref="IStream"/> interfaces.
    /// </summary>
    [DebuggerDisplay("pwcsName = {pwcsName}, type = {type}, cbSize = {cbSize.ToString(),nq}, mtime = {mtime.ToString(),nq}, ctime = {ctime.ToString(),nq}, atime = {atime.ToString(),nq}, grfMode = {grfMode}, grfLocksSupported = {grfLocksSupported}, clsid = {clsid.ToString(),nq}, grfStateBits = {grfStateBits}, reserved = {reserved}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public partial struct STATSTG
    {
        /// <summary>
        /// A pointer to a NULL-terminated Unicode string that contains the name. Space for this string is allocated by the method called and freed by the caller
        /// (for more information, see CoTaskMemFree). To not return this member, specify the STATFLAG_NONAME value when you call a method that returns a STATSTG
        /// structure, except for calls to <see cref="IEnumSTATSTG.Next"/>, which provides no way to specify this value.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwcsName;

        /// <summary>
        /// Indicates the type of storage object. This is one of the values from the STGTY enumeration.
        /// </summary>
        public STGTY type;

        /// <summary>
        /// Specifies the size, in bytes, of the stream or byte array.
        /// </summary>
        public ULARGE_INTEGER cbSize;

        /// <summary>
        /// Indicates the last modification time for this storage, stream, or byte array.
        /// </summary>
        public FILETIME mtime;

        /// <summary>
        /// Indicates the creation time for this storage, stream, or byte array.
        /// </summary>
        public FILETIME ctime;

        /// <summary>
        /// Indicates the last access time for this storage, stream, or byte array.
        /// </summary>
        public FILETIME atime;

        /// <summary>
        /// Indicates the access mode specified when the object was opened. This member is only valid in calls to Stat methods.
        /// </summary>
        public int grfMode;

        /// <summary>
        /// Indicates the types of region locking supported by the stream or byte array. For more information about the values available,
        /// see the LOCKTYPE enumeration. This member is not used for storage objects.
        /// </summary>
        public int grfLocksSupported;

        /// <summary>
        /// Indicates the class identifier for the storage object; set to CLSID_NULL for new storage objects. This member is not used for streams or byte arrays.
        /// </summary>
        public Guid clsid;

        /// <summary>
        /// Indicates the current state bits of the storage object; that is, the value most recently set by the <see cref="IStorage.SetStateBits"/> method.
        /// This member is not valid for streams or byte arrays.
        /// </summary>
        public int grfStateBits;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public int reserved;
    }
}

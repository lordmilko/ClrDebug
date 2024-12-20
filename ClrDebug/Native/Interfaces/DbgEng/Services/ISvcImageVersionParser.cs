using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An optional QI off an ISvcImageParser. This parses any version data on the image.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D9351812-532F-48DC-8FA7-8D0D64E1441D")]
    [ComImport]
    public interface ISvcImageVersionParser
    {
        /// <summary>
        /// Returns a string representation of the version of the image the parser was created for. If such version information does not exist for the given file type, E_NOT_SET can be returned.<para/>
        /// A provider should always attempt to map some semantic onto VersionGeneric. VersionFile/VersionProduct has specific meaning for Windows and may or may not for other platforms.
        /// </summary>
        [PreserveSig]
        HRESULT GetVersionString(
            [In] VersionKind kind,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersion);

        /// <summary>
        /// Returns a numeric representation of the version of the image the parser was created for. If such version information does not exist for the given file type, E_NOT_SET can be returned.<para/>
        /// If the given version request cannot be mapped to 4 numeric a.b.c.d values, this can return E_NOTIMPL. If the given version request maps to less than 4 numeric values, non-existant values should always be set to zero.
        /// </summary>
        [PreserveSig]
        HRESULT GetVersionNumber(
            [In] VersionKind kind,
            [Out] out long p1,
            [Out] out long p2,
            [Out] out long p3,
            [Out] out long p4);

        /// <summary>
        /// Gets additional information stamped into the version record for a particular platform. The version data string can be identified by either GUID or by name.<para/>
        /// The other argument should be nullptr. An unrecognized string/GUID should return E_NOT_SET.
        /// </summary>
        [PreserveSig]
        HRESULT GetVersionDataString(
            [In] Guid pVersionDataIdentifierGuid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString);
    }
}

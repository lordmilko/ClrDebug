using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4EA0C43F-8378-43D9-BE1C-E698F5508E58")]
    [ComImport]
    public interface ISvcImageVersionParser2 : ISvcImageVersionParser
    {
        /// <summary>
        /// Returns a string representation of the version of the image the parser was created for. If such version information does not exist for the given file type, E_NOT_SET can be returned.<para/>
        /// A provider should always attempt to map some semantic onto VersionGeneric. VersionFile/VersionProduct has specific meaning for Windows and may or may not for other platforms.
        /// </summary>
        [PreserveSig]
        new HRESULT GetVersionString(
            [In] VersionKind kind,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersion);

        /// <summary>
        /// Returns a numeric representation of the version of the image the parser was created for. If such version information does not exist for the given file type, E_NOT_SET can be returned.<para/>
        /// If the given version request cannot be mapped to 4 numeric a.b.c.d values, this can return E_NOTIMPL. If the given version request maps to less than 4 numeric values, non-existant values should always be set to zero.
        /// </summary>
        [PreserveSig]
        new HRESULT GetVersionNumber(
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
        new HRESULT GetVersionDataString(
            [In] Guid pVersionDataIdentifierGuid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString);
        
        [PreserveSig]
        HRESULT EnumerateVersionData(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageVersionDataEnumerator enumerator);
    }
}

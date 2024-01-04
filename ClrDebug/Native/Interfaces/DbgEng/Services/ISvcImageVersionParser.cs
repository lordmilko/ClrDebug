using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D9351812-532F-48DC-8FA7-8D0D64E1441D")]
    [ComImport]
    public interface ISvcImageVersionParser
    {
        [PreserveSig]
        HRESULT GetVersionString(
            [In] VersionKind kind,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersion);
        
        [PreserveSig]
        HRESULT GetVersionNumber(
            [In] VersionKind kind,
            [Out] out long p1,
            [Out] out long p2,
            [Out] out long p3,
            [Out] out long p4);
        
        [PreserveSig]
        HRESULT GetVersionDataString(
            [In] Guid pVersionDataIdentifierGuid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString);
    }
}

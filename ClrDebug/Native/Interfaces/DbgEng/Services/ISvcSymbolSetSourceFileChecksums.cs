using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("078BB523-7C08-4390-8FA5-921A4A0D5E07")]
    [ComImport]
    public interface ISvcSymbolSetSourceFileChecksums
    {
        [PreserveSig]
        HRESULT GetLegacySourceFileChecksumInformation(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [Out] out SvcChecksumKind pChecksumKind,
            [Out] out int pChecksumSize);
        
        [PreserveSig]
        HRESULT GetLegacySourceFileChecksum(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [Out] out SvcChecksumKind pChecksumKind,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pChecksum,
            [In] int checksumSize,
            [Out] out int pActualBytesWritten);
    }
}

using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("91DC29CD-F06E-46FE-8C5F-AC6787B79C6E")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcSymbolCompilationUnitSources
    {
        /// <summary>
        /// Enumerates all of the source files which contribute to this compilation unit.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateSourceFiles(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFileEnumerator sourceFileEnum);
    }
}

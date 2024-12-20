using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("14C37CAC-496D-4916-AF75-02345E27DA3E")]
    [ComImport]
    public interface ISvcSymbolCompilationUnit
    {
        /// <summary>
        /// Gets the primary source file of the CU, if available.
        /// </summary>
        [PreserveSig]
        HRESULT GetPrimarySource(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile primarySourceFile);

        /// <summary>
        /// Gets the language of the CU, if available. If there are multiple versions (e.g.: C++03, C++07, C++11, C++17, etc...), the version field can optionally indicate such.<para/>
        /// If the version is not available, the return value is static_cast&lt;ULONG&gt;(-1).
        /// </summary>
        [PreserveSig]
        HRESULT GetLanguage(
            [Out] out SvcSourceLanguage language,
            [Out] out int version);

        /// <summary>
        /// Gets the producer / compiler identification string for the CU, if available.
        /// </summary>
        [PreserveSig]
        HRESULT GetProducer(
            [Out, MarshalAs(UnmanagedType.BStr)] out string producerString);
    }
}

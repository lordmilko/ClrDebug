using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a "simple interface" around the enumeration of source files that contribute to a particular binary and their association to compilation units / compilands.<para/>
    /// This is an optional interface for symbol sets to implement.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FFD73BA2-D7E9-442D-ADA6-4EF1B07D951F")]
    [ComImport]
    public interface ISvcSymbolSetSimpleSourceFileInformation
    {
        /// <summary>
        /// Gets a source file by its unique identifier.
        /// </summary>
        [PreserveSig]
        HRESULT GetSourceFileById(
            [In] long id,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFile sourceFile);

        /// <summary>
        /// Enumerates all of the source files which contribute to the image.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateSourceFiles(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] ref SvcSymbolSearchInfo pSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSourceFileEnumerator sourceFileEnum);
    }
}

using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a source file that contributes to the code in a binary.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("073DE56A-473E-4A8A-A059-DA7A185B2F90")]
    [ComImport]
    public interface ISvcSourceFile
    {
        /// <summary>
        /// Gets a unique identifier for the source file.
        /// </summary>
        [PreserveSig]
        long GetId();

        /// <summary>
        /// Gets the name of the source file.
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);

        /// <summary>
        /// Gets the path of the source file.
        /// </summary>
        [PreserveSig]
        HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string path);

        /// <summary>
        /// Gets the size of the source file hash stored in symbolic information. If the symbolic information has no source file hash, this should return zero.
        /// </summary>
        [PreserveSig]
        long GetHashDataSize();

        /// <summary>
        /// Gets the hash data associated with the source file. If there is no such information stored in the symbolic information, this will return E_NOT_SET.
        /// </summary>
        [PreserveSig]
        HRESULT GetHashData(
            [In] long hashDataSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pHashData,
            [Out] out SvcHashAlgorithm pHashAlgorithm);

        /// <summary>
        /// Gets all the compilation units which reference this particular source file.
        /// </summary>
        [PreserveSig]
        HRESULT GetCompilationUnits(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator cuEnumerator);
    }
}

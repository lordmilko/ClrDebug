using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D9F5A718-E130-46C2-AECD-D66C557027B8")]
    [ComImport]
    public interface ISvcDebugSourceFileInformation
    {
        /// <summary>
        /// Gets the name of the underlying file.
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string fileName);

        /// <summary>
        /// Gets the path of the underlying file.
        /// </summary>
        [PreserveSig]
        HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string filePath);

        /// <summary>
        /// Gets the size of the underlying file.
        /// </summary>
        [PreserveSig]
        HRESULT GetSize(
            [Out] out long fileSize);
    }
}

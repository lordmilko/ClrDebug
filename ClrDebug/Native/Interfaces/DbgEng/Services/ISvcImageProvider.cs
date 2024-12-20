using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a mechanism by which the original binary image for a module/image mapped into the debug target can be located from the limited information available from the debug target.<para/>
    /// A given debug target may, for example, represent a minidump which only has image headers or a core file which only has a subset of the image pages mapped into the core.<para/>
    /// This interface will attempt to find the original image file and return a file abstraction over it such that the entire module/image is available for debugging.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("76D4EDDF-282E-4381-8389-6FA9EEB067C2")]
    [ComImport]
    public interface ISvcImageProvider
    {
        /// <summary>
        /// Locate the file for a given image within the target.
        /// </summary>
        [PreserveSig]
        HRESULT LocateImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule image,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcDebugSourceFile ppFile);
    }
}

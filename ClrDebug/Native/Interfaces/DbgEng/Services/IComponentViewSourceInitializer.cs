using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8CE08C3C-A860-4604-B73E-06813B5380F8")]
    [ComImport]
    public interface IComponentViewSourceInitializer
    {
        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_VIEWSOURCE component.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager);
    }
}

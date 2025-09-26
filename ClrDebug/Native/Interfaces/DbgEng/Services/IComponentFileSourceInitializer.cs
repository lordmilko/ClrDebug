using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C0D44DDA-6D7D-4B07-923C-68242BEB9E20")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IComponentFileSourceInitializer
    {
        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_FILESOURCE component by opening a file at the given path. This method will fail if no such file exists or it cannot be opened.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.LPWStr)] string filePath);
    }
}

using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides methods to do a stack walk using information in the .pdb file.
    /// </summary>
    /// <remarks>
    /// This interface is used to obtain a list of stack frames for a loaded module. Each of the methods is passed an <see
    /// cref="IDiaStackWalkHelper"/> object (implemented by the client application) which provides the necessary information
    /// to create the list of stack frames. This interface is obtained by calling the CoCreateInstance method with the
    /// class identifier CLSID_DiaStackWalker and the interface ID of IID_IDiaStackWalker. The example shows how this interface
    /// is obtained.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5485216B-A54C-469F-9670-52B24D5229BB")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaStackWalker
    {
        [PreserveSig]
        HRESULT getEnumFrames(
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);

        [PreserveSig]
        HRESULT getEnumFrames2(
            [In] CV_CPU_TYPE_e cpuid,
            [MarshalAs(UnmanagedType.Interface), In] IDiaStackWalkHelper pHelper,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumStackFrames ppenum);
    }
}

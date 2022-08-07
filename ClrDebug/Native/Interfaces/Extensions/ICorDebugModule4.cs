using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FF8B8EAF-25CD-4316-8859-84416DE4402E")]
    [ComImport]
    public interface ICorDebugModule4
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsMappedLayout(out bool pIsMapped);
    }
}

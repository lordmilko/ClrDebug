using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5F696509-452F-4436-A3FE-4D11FE7E2347")]
    [ComImport]
    public interface ICorDebugCode2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCodeChunks([In] uint cbufSize, out uint pcnumChunks, [MarshalAs(UnmanagedType.LPArray), Out] CodeChunkInfo[] chunks);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCompilerFlags(out CorDebugJITCompilerFlags pdwFlags);
    }
}
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5F696509-452F-4436-A3FE-4D11FE7E2347")]
    [ComImport]
    public interface ICorDebugCode2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCodeChunks([In] uint cbufSize, out uint pcnumChunks, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugCode2 chunks);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCompilerFlags(out CorDebugJITCompilerFlags pdwFlags);
    }
}
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("F9801807-4764-4330-9E67-4F685094165E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugSymbolProvider2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetGenericDictionaryInfo([MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFrameProps([In] uint codeRva, out uint pCodeStartRva, out uint pParentFrameStartRva);
    }
}
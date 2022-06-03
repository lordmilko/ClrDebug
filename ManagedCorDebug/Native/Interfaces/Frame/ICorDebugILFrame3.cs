using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("9A9E2ED6-04DF-4FE0-BB50-CAB64126AD24")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugILFrame3
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetReturnValueForILOffset(uint ilOffset,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppReturnValue);
    }
}
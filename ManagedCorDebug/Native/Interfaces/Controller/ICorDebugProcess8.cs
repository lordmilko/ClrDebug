using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("2E6F28C1-85EB-4141-80AD-0A90944B9639")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess8
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableExceptionCallbacksOutsideOfMyCode([In] int enableExceptionsOutsideOfJMC);
    }
}
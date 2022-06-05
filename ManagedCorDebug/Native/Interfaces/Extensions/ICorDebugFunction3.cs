using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions]<para/>
    /// Logically extends the ICorDebugFunction interface to provide access to code from a ReJIT request.
    /// </summary>
    [Guid("09B70F28-E465-482D-99E0-81A165EB0532")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugFunction3
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetActiveReJitRequestILCode([MarshalAs(UnmanagedType.Interface)] ref ICorDebugILCode ppReJitedILCode);
    }
}
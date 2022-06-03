using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("46586093-D3F5-4DB6-ACDB-955BCE228C15")]
    [ComImport]
    public interface ICorDebugILCode2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetLocalVarSigToken(out uint pmdSig);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetInstrumentedILMap([In] uint cMap, out uint pcMap, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugILCode2 map);
    }
}
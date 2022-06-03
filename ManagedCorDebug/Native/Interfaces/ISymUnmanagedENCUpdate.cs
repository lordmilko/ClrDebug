using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("E502D2DD-8671-4338-8F2A-FC08229628C4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedENCUpdate
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateSymbolStore2([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] ref _SYMLINEDELTA pDeltaLines, [In] uint cDeltaLines);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocalVariableCount([In] uint mdMethodToken, out uint pcLocals);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetLocalVariables(
            [In] uint mdMethodToken,
            [In] uint cLocals,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedENCUpdate rgLocals,
            out uint pceltFetched);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void InitializeForEnc();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateMethodLines([In] uint mdMethodToken, [In] ref int pDeltas, [In] uint cDeltas);
    }
}
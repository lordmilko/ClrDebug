using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("B01FAFEB-C450-3A4D-BEEC-B4CEEC01E006")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedDocumentWriter
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetSource([In] uint sourceSize, [In] ref byte source);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetCheckSum([In] Guid algorithmId, [In] uint checkSumSize, [In] ref byte checkSum);
    }
}
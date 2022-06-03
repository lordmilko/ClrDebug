using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("FC073774-1739-4232-BD56-A027294BEC15")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedAsyncMethodPropertiesWriter
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineKickoffMethod([In] uint kickoffMethod);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineCatchHandlerILOffset([In] uint catchHandlerOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DefineAsyncStepInfo(
            [In] uint count,
            [In] ref uint yieldOffsets,
            [In] ref uint breakpointOffset,
            [In] ref uint breakpointMethod);
    }
}
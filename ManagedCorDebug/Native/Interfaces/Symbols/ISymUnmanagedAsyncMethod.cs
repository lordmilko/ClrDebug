using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// This interface is the reading complement to <see cref="ISymUnmanagedAsyncMethodPropertiesWriter"/>.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B20D55B3-532E-4906-87E7-25BD5734ABD2")]
    [ComImport]
    public interface ISymUnmanagedAsyncMethod
    {
        /// <summary>
        /// Checks if the method has async information or not.<para/>
        /// If this method returns FALSE then it is invalid to call any other methods in this interface. They will all return E_UNEXPECTED in this case.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsAsyncMethod();

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineKickoffMethod"/>.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetKickoffMethod();

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT HasCatchHandlerILOffset();

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCatchHandlerILOffset();

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAsyncStepInfoCount();

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAsyncStepInfo(
            [In] uint cStepInfo,
            out uint pcStepInfo,
            [In] ref uint yieldOffsets,
            [In] ref uint breakpointOffset,
            [In] ref uint breakpointMethod);
    }
}
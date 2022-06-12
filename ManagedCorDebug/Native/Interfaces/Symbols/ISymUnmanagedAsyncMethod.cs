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
        /// Checks if the method has async information or not. If this method returns FALSE then it is invalid to call any other methods in this interface.<para/>
        /// They will all return E_UNEXPECTED in this case.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsAsyncMethod();

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineKickoffMethod"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetKickoffMethod([Out] out mdToken kickoffMethod);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT HasCatchHandlerILOffset();

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCatchHandlerILOffset([Out] out int pRetVal);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAsyncStepInfoCount([Out] out int pRetVal);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAsyncStepInfo(
            [In] int cStepInfo,
            out int pcStepInfo,
            [In, Out] ref int[] yieldOffsets,
            [In, Out] ref int[] breakpointOffset,
            [In, Out] ref int[] breakpointMethod);
    }
}
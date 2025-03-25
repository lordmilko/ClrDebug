﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// This interface is the reading complement to <see cref="ISymUnmanagedAsyncMethodPropertiesWriter"/>.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B20D55B3-532E-4906-87E7-25BD5734ABD2")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedAsyncMethod
    {
        /// <summary>
        /// Checks if the method has async information or not. If this method returns FALSE then it is invalid to call any other methods in this interface.<para/>
        /// They will all return E_UNEXPECTED in this case.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT IsAsyncMethod(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineKickoffMethod"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT GetKickoffMethod(
            [Out] out mdMethodDef kickoffMethod);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT HasCatchHandlerILOffset(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT GetCatchHandlerILOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT GetAsyncStepInfoCount(
            [Out] out int pRetVal);

        /// <summary>
        /// See <see cref="ISymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT GetAsyncStepInfo(
            [In] int cStepInfo,
            [Out] out int pcStepInfo,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] yieldOffsets,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointOffset,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] mdMethodDef[] breakpointMethod);
    }
}

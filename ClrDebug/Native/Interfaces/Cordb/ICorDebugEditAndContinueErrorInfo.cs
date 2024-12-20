﻿using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// <see cref="ICorDebugEditAndContinueErrorInfo"/> is obsolete. Do not use this interface.
    /// </summary>
    [Guid("8D600D41-F4F6-4CB3-B7EC-7BD164944036")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugEditAndContinueErrorInfo
    {
        /// <summary>
        /// GetModule is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GetModule(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        /// <summary>
        /// GetToken is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GetToken(
            [Out] out mdToken pToken);

        /// <summary>
        /// GetErrorCode is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GetErrorCode(
            [Out] out HRESULT pHr);

        /// <summary>
        /// GetString is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        HRESULT GetString(
            [In] int cchString,
            [Out] out int pcchString,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szString);
    }
}

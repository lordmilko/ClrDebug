﻿using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a callback mechanism for reporting errors during the metadata merge.
    /// </summary>
    [Guid("B81FF171-20F3-11d2-8DCC-00A0C9B09C19")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IMetaDataError
    {
        /// <summary>
        /// Provides notification of errors that occur during the metadata merge.
        /// </summary>
        /// <param name="hrError">[in] The <see cref="HRESULT"/> error value returned to the calling method.</param>
        /// <param name="token">[in] The metadata token of the code object that was being merged when the error occurred.</param>
        [PreserveSig]
        HRESULT OnError(
            [In] HRESULT hrError,
            [In] mdToken token);
    }
}

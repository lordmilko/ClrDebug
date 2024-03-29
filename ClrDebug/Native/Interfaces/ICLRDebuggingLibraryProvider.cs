﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Includes the <see cref="ProvideLibrary"/> method, which gets a library provider callback interface that allows common language runtime version-specific debugging libraries to be located and loaded on demand.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3151C08D-4D09-4F9B-8838-2880BF18FE51")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICLRDebuggingLibraryProvider
    {
        /// <summary>
        /// Gets a library provider callback interface that allows common language runtime (CLR) version-specific debugging libraries to be located and loaded on demand.
        /// </summary>
        /// <param name="pwszFileName">[in] The name of the module being requested.</param>
        /// <param name="dwTimestamp">[in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage">[in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <param name="phModule">[out] The handle to the requested module.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// ProvideLibrary allows the debugger to provide modules that are needed for debugging specific CLR files such as
        /// mscordbi.dll and mscordacwks.dll. The module handles have to remain valid until a call to the <see cref="ICLRDebugging.CanUnloadNow"/>
        /// method indicates that they may be freed, at which point it is the caller’s responsibility to free the handles.
        /// The debugger may use any available means to locate or procure the debugging module.
        /// </remarks>
        [PreserveSig]
        HRESULT ProvideLibrary(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwszFileName,
            [In] int dwTimestamp,
            [In] int dwSizeOfImage,
            [Out] out IntPtr phModule);
    }
}

﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Logically extends the <see cref="ICorDebugDataTarget"/> interface to provide information about loaded modules.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D05E60C3-848C-4E7D-894E-623320FF6AFA")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugDataTarget3
    {
        /// <summary>
        /// Gets a list of the modules that have been loaded so far.
        /// </summary>
        /// <param name="cRequestedModules">[in] The number of modules for which information is requested.</param>
        /// <param name="pcFetchedModules">[out] A pointer to the number of modules about which information was returned.</param>
        /// <param name="pLoadedModules">[out] A pointer to an array of <see cref="ICorDebugLoadedModule"/> objects that provide information about loaded modules.</param>
        [PreserveSig]
        HRESULT GetLoadedModules(
            [In] int cRequestedModules,
            [Out] out int pcFetchedModules,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ICorDebugLoadedModule[] pLoadedModules);
    }
}

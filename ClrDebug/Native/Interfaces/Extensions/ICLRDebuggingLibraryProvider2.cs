using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Includes the <see cref="ProvideLibrary2"/> method, which allows the debugger to provide a path to a version-specific debugging library.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E04E2FF1-DCFD-45D5-BCD1-16FFF2FAF7BA")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICLRDebuggingLibraryProvider2
    {
        /// <summary>
        /// Allows the debugger to provide a path to a version-specific common language runtime (CLR) debugging library.
        /// </summary>
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="dwTimestamp"> [in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage"> [in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <param name="ppResolvedModulePath">[out] This is a null terminated path to the module dll. On Windows it should be allocated with CoTaskMemAlloc.<para/>
        /// On Unix it should be allocated with malloc. Failure leaves it untouched. See security note below!<para/>
        /// Note that <see cref="Marshal.AllocCoTaskMem(int)"/> and <see cref="Marshal.StringToCoTaskMemUni(string)"/> on Unix both use malloc internally.
        /// </param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// ProvideLibrary2 allows the debugger to provide modules that are needed for debugging specific CLR files such as
        /// mscordbi.dll and mscordacwks.dll. The debugger may use any available means to locate or procure the debugging module.
        /// </remarks>
        [PreserveSig]
        HRESULT ProvideLibrary2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [In] int dwTimestamp,
            [In] int dwSizeOfImage,
            [Out] out IntPtr ppResolvedModulePath);
    }
}

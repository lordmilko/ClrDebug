using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Includes the <see cref="ProvideLibrary"/> method, which gets a library provider callback interface that allows common language runtime version-specific debugging libraries to be located and loaded on demand.
    /// </summary>
    public class CLRDebuggingLibraryProvider : ComObject<ICLRDebuggingLibraryProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRDebuggingLibraryProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRDebuggingLibraryProvider(ICLRDebuggingLibraryProvider raw) : base(raw)
        {
        }

        #region ICLRDebuggingLibraryProvider
        #region ProvideLibrary

        /// <summary>
        /// Gets a library provider callback interface that allows common language runtime (CLR) version-specific debugging libraries to be located and loaded on demand.
        /// </summary>
        /// <param name="pwszFileName">[in] The name of the module being requested.</param>
        /// <param name="dwTimestamp">[in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage">[in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <returns>[out] The handle to the requested module.</returns>
        /// <remarks>
        /// ProvideLibrary allows the debugger to provide modules that are needed for debugging specific CLR files such as
        /// mscordbi.dll and mscordacwks.dll. The module handles have to remain valid until a call to the <see cref="CLRDebugging.CanUnloadNow"/>
        /// method indicates that they may be freed, at which point it is the caller’s responsibility to free the handles.
        /// The debugger may use any available means to locate or procure the debugging module.
        /// </remarks>
        public IntPtr ProvideLibrary(string pwszFileName, int dwTimestamp, int dwSizeOfImage)
        {
            IntPtr phModule;
            TryProvideLibrary(pwszFileName, dwTimestamp, dwSizeOfImage, out phModule).ThrowOnNotOK();

            return phModule;
        }

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
        /// mscordbi.dll and mscordacwks.dll. The module handles have to remain valid until a call to the <see cref="CLRDebugging.CanUnloadNow"/>
        /// method indicates that they may be freed, at which point it is the caller’s responsibility to free the handles.
        /// The debugger may use any available means to locate or procure the debugging module.
        /// </remarks>
        public HRESULT TryProvideLibrary(string pwszFileName, int dwTimestamp, int dwSizeOfImage, out IntPtr phModule)
        {
            /*HRESULT ProvideLibrary(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwszFileName,
            [In] int dwTimestamp,
            [In] int dwSizeOfImage,
            [Out] out IntPtr phModule);*/
            return Raw.ProvideLibrary(pwszFileName, dwTimestamp, dwSizeOfImage, out phModule);
        }

        #endregion
        #endregion
        #region ICLRDebuggingLibraryProvider2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICLRDebuggingLibraryProvider2 Raw2 => (ICLRDebuggingLibraryProvider2) Raw;

        #region ProvideLibrary2

        /// <summary>
        /// Allows the debugger to provide a path to a version-specific common language runtime (CLR) debugging library.
        /// </summary>
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="dwTimestamp"> [in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage"> [in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <returns>[out] This is a null terminated path to the module dll. On Windows it should be allocated with CoTaskMemAlloc.<para/>
        /// On Unix it should be allocated with malloc. Failure leaves it untouched. See security note below!<para/>
        /// Note that <see cref="Marshal.AllocCoTaskMem(int)"/> and <see cref="Marshal.StringToCoTaskMemUni(string)"/> on Unix both use malloc internally.
        /// </returns>
        /// <remarks>
        /// ProvideLibrary2 allows the debugger to provide modules that are needed for debugging specific CLR files such as
        /// mscordbi.dll and mscordacwks.dll. The debugger may use any available means to locate or procure the debugging module.
        /// </remarks>
        public IntPtr ProvideLibrary2(string pwszFileName, int dwTimestamp, int dwSizeOfImage)
        {
            IntPtr ppResolvedModulePath;
            TryProvideLibrary2(pwszFileName, dwTimestamp, dwSizeOfImage, out ppResolvedModulePath).ThrowOnNotOK();

            return ppResolvedModulePath;
        }

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
        public HRESULT TryProvideLibrary2(string pwszFileName, int dwTimestamp, int dwSizeOfImage, out IntPtr ppResolvedModulePath)
        {
            /*HRESULT ProvideLibrary2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [In] int dwTimestamp,
            [In] int dwSizeOfImage,
            [Out] out IntPtr ppResolvedModulePath);*/
            return Raw2.ProvideLibrary2(pwszFileName, dwTimestamp, dwSizeOfImage, out ppResolvedModulePath);
        }

        #endregion
        #endregion
        #region ICLRDebuggingLibraryProvider3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICLRDebuggingLibraryProvider3 Raw3 => (ICLRDebuggingLibraryProvider3) Raw;

        #region ProvideWindowsLibrary

        /// <summary>
        /// Gets a library provider callback interface that allows common language runtime (CLR) version-specific debugging libraries to be located and loaded on demand.
        /// </summary>
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="pwszRuntimeModule"> [in] The runtime or single-file module path.</param>
        /// <param name="indexType"> [in] The type of index information (dwTimestamp/dwSizeOfImage) provided. See <see cref="LIBRARY_PROVIDER_INDEX_TYPE"/> enum.</param>
        /// <param name="dwTimestamp"> [in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage"> [in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <returns>[out] This is a null terminated path to the module dll. On Windows it should be allocated with CoTaskMemAlloc.<para/>
        /// On Unix it should be allocated with malloc. Failure leaves it untouched. See security note below!<para/>
        /// Note that <see cref="Marshal.AllocCoTaskMem(int)"/> and <see cref="Marshal.StringToCoTaskMemUni(string)"/> on Unix both use malloc internally.</returns>
        /// <remarks>
        /// ProvideWindowsLibrary allows the debugger to provide modules that are needed for debugging specific CLR files such
        /// as mscordbi.dll and mscordacwks.dll. The debugger may use any available means to locate or procure the debugging
        /// module.
        /// </remarks>
        public IntPtr ProvideWindowsLibrary(string pwszFileName, string pwszRuntimeModule, LIBRARY_PROVIDER_INDEX_TYPE indexType, int dwTimestamp, int dwSizeOfImage)
        {
            IntPtr ppResolvedModulePath;
            TryProvideWindowsLibrary(pwszFileName, pwszRuntimeModule, indexType, dwTimestamp, dwSizeOfImage, out ppResolvedModulePath).ThrowOnNotOK();

            return ppResolvedModulePath;
        }

        /// <summary>
        /// Gets a library provider callback interface that allows common language runtime (CLR) version-specific debugging libraries to be located and loaded on demand.
        /// </summary>
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="pwszRuntimeModule"> [in] The runtime or single-file module path.</param>
        /// <param name="indexType"> [in] The type of index information (dwTimestamp/dwSizeOfImage) provided. See <see cref="LIBRARY_PROVIDER_INDEX_TYPE"/> enum.</param>
        /// <param name="dwTimestamp"> [in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage"> [in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <param name="ppResolvedModulePath">[out] This is a null terminated path to the module dll. On Windows it should be allocated with CoTaskMemAlloc.<para/>
        /// On Unix it should be allocated with malloc. Failure leaves it untouched. See security note below!<para/>
        /// Note that <see cref="Marshal.AllocCoTaskMem(int)"/> and <see cref="Marshal.StringToCoTaskMemUni(string)"/> on Unix both use malloc internally.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// ProvideWindowsLibrary allows the debugger to provide modules that are needed for debugging specific CLR files such
        /// as mscordbi.dll and mscordacwks.dll. The debugger may use any available means to locate or procure the debugging
        /// module.
        /// </remarks>
        public HRESULT TryProvideWindowsLibrary(string pwszFileName, string pwszRuntimeModule, LIBRARY_PROVIDER_INDEX_TYPE indexType, int dwTimestamp, int dwSizeOfImage, out IntPtr ppResolvedModulePath)
        {
            /*HRESULT ProvideWindowsLibrary(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszRuntimeModule,
            [In] LIBRARY_PROVIDER_INDEX_TYPE indexType,
            [In] int dwTimestamp,
            [In] int dwSizeOfImage,
            [Out] out IntPtr ppResolvedModulePath);*/
            return Raw3.ProvideWindowsLibrary(pwszFileName, pwszRuntimeModule, indexType, dwTimestamp, dwSizeOfImage, out ppResolvedModulePath);
        }

        #endregion
        #region ProvideUnixLibrary

        /// <summary>
        /// Allows the debugger to provide a path to a version-specific common language runtime (CLR) debugging library on macOS and Linux.
        /// </summary>
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="pwszRuntimeModule"> [in] The runtime or single-file module path.</param>
        /// <param name="indexType"> [in] The type of index information (pBuildId) provided. See <see cref="LIBRARY_PROVIDER_INDEX_TYPE"/> enum.</param>
        /// <param name="pbBuildId"> [in] The Linux or macOS module build id. Can be null if something went wrong retrieving the build id.</param>
        /// <param name="iBuildIdSize"> [in] The number of bytes in the pbBuildId array. Can be 0 if something went wrong retrieving the build id.</param>
        /// <returns>[out] This is a null terminated path to the module dll. On Windows it should be allocated with CoTaskMemAlloc. On Unix it should be allocated with malloc.<para/>
        /// Failure leaves it untouched. See security note below!<para/>
        /// Note that <see cref="Marshal.AllocCoTaskMem(int)"/> and <see cref="Marshal.StringToCoTaskMemUni(string)"/> on Unix both use malloc internally.</returns>
        /// <remarks>
        /// ProvideUnixLibrary allows the debugger to provide modules that are needed for debugging specific CLR files such
        /// as mscordbi.dll and mscordacwks.dll. The debugger may use any available means to locate or procure the debugging
        /// module.
        /// </remarks>
        public IntPtr ProvideUnixLibrary(string pwszFileName, string pwszRuntimeModule, LIBRARY_PROVIDER_INDEX_TYPE indexType, byte[] pbBuildId, int iBuildIdSize)
        {
            IntPtr ppResolvedModulePath;
            TryProvideUnixLibrary(pwszFileName, pwszRuntimeModule, indexType, pbBuildId, iBuildIdSize, out ppResolvedModulePath).ThrowOnNotOK();

            return ppResolvedModulePath;
        }

        /// <summary>
        /// Allows the debugger to provide a path to a version-specific common language runtime (CLR) debugging library on macOS and Linux.
        /// </summary>
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="pwszRuntimeModule"> [in] The runtime or single-file module path.</param>
        /// <param name="indexType"> [in] The type of index information (pBuildId) provided. See <see cref="LIBRARY_PROVIDER_INDEX_TYPE"/> enum.</param>
        /// <param name="pbBuildId"> [in] The Linux or macOS module build id. Can be null if something went wrong retrieving the build id.</param>
        /// <param name="iBuildIdSize"> [in] The number of bytes in the pbBuildId array. Can be 0 if something went wrong retrieving the build id.</param>
        /// <param name="ppResolvedModulePath">[out] This is a null terminated path to the module dll. On Windows it should be allocated with CoTaskMemAlloc. On Unix it should be allocated with malloc.<para/>
        /// Failure leaves it untouched. See security note below!<para/>
        /// Note that <see cref="Marshal.AllocCoTaskMem(int)"/> and <see cref="Marshal.StringToCoTaskMemUni(string)"/> on Unix both use malloc internally.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// ProvideUnixLibrary allows the debugger to provide modules that are needed for debugging specific CLR files such
        /// as mscordbi.dll and mscordacwks.dll. The debugger may use any available means to locate or procure the debugging
        /// module.
        /// </remarks>
        public HRESULT TryProvideUnixLibrary(string pwszFileName, string pwszRuntimeModule, LIBRARY_PROVIDER_INDEX_TYPE indexType, byte[] pbBuildId, int iBuildIdSize, out IntPtr ppResolvedModulePath)
        {
            /*HRESULT ProvideUnixLibrary(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszRuntimeModule,
            [In] LIBRARY_PROVIDER_INDEX_TYPE indexType,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pbBuildId,
            [In] int iBuildIdSize,
            [Out] out IntPtr ppResolvedModulePath);*/
            return Raw3.ProvideUnixLibrary(pwszFileName, pwszRuntimeModule, indexType, pbBuildId, iBuildIdSize, out ppResolvedModulePath);
        }

        #endregion
        #endregion
    }
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Includes callback methods that allow common language runtime version-specific debugging libraries to be located and loaded on demand for .NET Core regular and single-file applications.<para/>
    /// This interface is required by the RegisterForRuntimeStartup3 and CreateDebuggingInterfaceFromVersion3 methods. It is supported by the <see cref="ICLRDebugging.OpenVirtualProcess"/> method aquired with dbgshim's CLRCreateInstance API.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DE3AAB18-46A0-48B4-BF0D-2C336E69EA1B")]
    [ComImport]
    public interface ICLRDebuggingLibraryProvider3
    {
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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ProvideWindowsLibrary(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszRuntimeModule,
            [In] LIBRARY_PROVIDER_INDEX_TYPE indexType,
            [In] int dwTimestamp,
            [In] int dwSizeOfImage,
            [Out] out IntPtr ppResolvedModulePath);

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ProvideUnixLibrary(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszRuntimeModule,
            [In] LIBRARY_PROVIDER_INDEX_TYPE indexType,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pbBuildId,
            [In] int iBuildIdSize,
            [Out] out IntPtr ppResolvedModulePath);
    }
}

using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="dwTimestamp"> [in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage"> [in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <returns> [out] The handle to the requested module.</returns>
        /// <remarks>
        /// ProvideLibrary allows the debugger to provide modules that are needed for debugging specific CLR files such as
        /// mscordbi.dll and mscordacwks.dll. The module handles have to remain valid until a call to the <see cref="CLRDebugging.CanUnloadNow"/>
        /// method indicates that they may be freed, at which point it is the caller’s responsibility to free the handles.
        /// The debugger may use any available means to locate or procure the debugging module.
        /// </remarks>
        public IntPtr ProvideLibrary(string pwszFileName, int dwTimestamp, int dwSizeOfImage)
        {
            HRESULT hr;
            IntPtr phModule;

            if ((hr = TryProvideLibrary(pwszFileName, dwTimestamp, dwSizeOfImage, out phModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return phModule;
        }

        /// <summary>
        /// Gets a library provider callback interface that allows common language runtime (CLR) version-specific debugging libraries to be located and loaded on demand.
        /// </summary>
        /// <param name="pwszFileName"> [in] The name of the module being requested.</param>
        /// <param name="dwTimestamp"> [in] The date time stamp stored in the COFF file header of PE files.</param>
        /// <param name="dwSizeOfImage"> [in] The SizeOfImage field stored in the COFF optional file header of PE files.</param>
        /// <param name="phModule"> [out] The handle to the requested module.</param>
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
            out IntPtr phModule);*/
            return Raw.ProvideLibrary(pwszFileName, dwTimestamp, dwSizeOfImage, out phModule);
        }

        #endregion
        #endregion
    }
}
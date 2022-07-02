using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides metadata information to the debugger.
    /// </summary>
    [Guid("7CEF8BA9-2EF7-42BF-973F-4171474F87D9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugMetaDataLocator
    {
        /// <summary>
        /// Asks the debugger to return the full path to a module whose metadata is needed to complete an operation the debugger requested.
        /// </summary>
        /// <param name="wszImagePath">[in] A null-terminated string that represents the full path to the file. If the full path is not available, the name and extension of the file (filename.extension).</param>
        /// <param name="dwImageTimeStamp">[in] The time stamp from the image's PE file headers. This parameter can potentially be used for a symbol server (SymSrv) lookup.</param>
        /// <param name="dwImageSize">[in] The image size from PE file headers. This parameter can potentially be used for a SymSrv lookup.</param>
        /// <param name="cchPathBuffer">[in] The character count in wszPathBuffer.</param>
        /// <param name="pcchPathBuffer">[out] The count of WCHARs written to wszPathBuffer. If the method returns E_NOT_SUFFICIENT_BUFFER, contains the count of WCHARs needed to store the path.</param>
        /// <param name="wszPathBuffer">[out] Pointer to a buffer into which the debugger will copy the full path of the file that contains the requested metadata.<para/>
        /// The ofReadOnly flag from the <see cref="CorOpenFlags"/> enumeration is used to request read-only access to the metadata in this file.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure. All other failure HRESULTs indicate that the file is not retrievable.
        /// 
        /// | HRESULT                 | Description                                                                                                                                                                                                                                                    |
        /// | ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                    | The method completed successfully. wszPathBuffer contains the full path to the file and is null-terminated.                                                                                                                                                    |
        /// | E_NOT_SUFFICIENT_BUFFER | The current size of wszPathBuffer is not sufficient to hold the full path. In this case, pcchPathBuffer contains the needed count of WCHARs, including the terminating null character, and GetMetaData is called a second time with the requested buffer size. |
        /// </returns>
        /// <remarks>
        /// If wszImagePath contains a full path for a module from a dump, it specifies the path from the computer where the
        /// dump was collected. The file may not exist at this location, or an incorrect file with the same name may be stored
        /// on the path.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMetaData(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszImagePath,
            [In] int dwImageTimeStamp,
            [In] int dwImageSize,
            [In] int cchPathBuffer,
            [Out] out int pcchPathBuffer,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder wszPathBuffer);
    }
}
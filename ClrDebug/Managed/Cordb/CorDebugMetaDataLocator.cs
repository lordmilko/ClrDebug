using static ClrDebug.Extensions;

namespace ClrDebug
{
    /// <summary>
    /// Provides metadata information to the debugger.<para/>
    /// This interface may be implemented by your <see cref="ICorDebugDataTarget"/> to tell the CLR how metadata interfaces
    /// should be retrieved.
    /// </summary>
    public class CorDebugMetaDataLocator : ComObject<ICorDebugMetaDataLocator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugMetaDataLocator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugMetaDataLocator(ICorDebugMetaDataLocator raw) : base(raw)
        {
        }

        #region ICorDebugMetaDataLocator
        #region GetMetaData

        /// <summary>
        /// Asks the debugger to return the full path to a module whose metadata is needed to complete an operation the debugger requested.
        /// </summary>
        /// <param name="wszImagePath">[in] A null-terminated string that represents the full path to the file. If the full path is not available, the name and extension of the file (filename.extension).</param>
        /// <param name="dwImageTimeStamp">[in] The time stamp from the image's PE file headers. This parameter can potentially be used for a symbol server (SymSrv) lookup.</param>
        /// <param name="dwImageSize">[in] The image size from PE file headers. This parameter can potentially be used for a SymSrv lookup.</param>
        /// <returns>[out] Pointer to a buffer into which the debugger will copy the full path of the file that contains the requested metadata.<para/>
        /// The ofReadOnly flag from the <see cref="CorOpenFlags"/> enumeration is used to request read-only access to the metadata in this file.</returns>
        /// <remarks>
        /// If wszImagePath contains a full path for a module from a dump, it specifies the path from the computer where the
        /// dump was collected. The file may not exist at this location, or an incorrect file with the same name may be stored
        /// on the path.
        /// </remarks>
        public string GetMetaData(string wszImagePath, int dwImageTimeStamp, int dwImageSize)
        {
            string wszPathBufferResult;
            TryGetMetaData(wszImagePath, dwImageTimeStamp, dwImageSize, out wszPathBufferResult).ThrowOnNotOK();

            return wszPathBufferResult;
        }

        /// <summary>
        /// Asks the debugger to return the full path to a module whose metadata is needed to complete an operation the debugger requested.
        /// </summary>
        /// <param name="wszImagePath">[in] A null-terminated string that represents the full path to the file. If the full path is not available, the name and extension of the file (filename.extension).</param>
        /// <param name="dwImageTimeStamp">[in] The time stamp from the image's PE file headers. This parameter can potentially be used for a symbol server (SymSrv) lookup.</param>
        /// <param name="dwImageSize">[in] The image size from PE file headers. This parameter can potentially be used for a SymSrv lookup.</param>
        /// <param name="wszPathBufferResult">[out] Pointer to a buffer into which the debugger will copy the full path of the file that contains the requested metadata.<para/>
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
        public HRESULT TryGetMetaData(string wszImagePath, int dwImageTimeStamp, int dwImageSize, out string wszPathBufferResult)
        {
            /*HRESULT GetMetaData(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszImagePath,
            [In] int dwImageTimeStamp,
            [In] int dwImageSize,
            [In] int cchPathBuffer,
            [Out] out int pcchPathBuffer,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), SRI.Out] char[] wszPathBuffer);*/
            int cchPathBuffer = 0;
            int pcchPathBuffer;
            char[] wszPathBuffer;
            HRESULT hr = Raw.GetMetaData(wszImagePath, dwImageTimeStamp, dwImageSize, cchPathBuffer, out pcchPathBuffer, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchPathBuffer = pcchPathBuffer;
            wszPathBuffer = new char[cchPathBuffer];
            hr = Raw.GetMetaData(wszImagePath, dwImageTimeStamp, dwImageSize, cchPathBuffer, out pcchPathBuffer, wszPathBuffer);

            if (hr == HRESULT.S_OK)
            {
                wszPathBufferResult = CreateString(wszPathBuffer, pcchPathBuffer);

                return hr;
            }

            fail:
            wszPathBufferResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}

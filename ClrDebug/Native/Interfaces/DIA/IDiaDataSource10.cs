using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides the file name and error code for the last load error for fastlink PDBs.
    /// </summary>
    /// <param name="pvContext">[in] The context that was passed into the call to the IDiaDataSourceEx::setPfnMiniPDBErrorCallback2 method.</param>
    /// <param name="dwErrorCode">[in] The error code describing the particular error. Although typed as a DWORD this is really a HRESULT. The most common values are E_PDB_CORRUPT, E_DIA_COFF_ACCESS, and E_DIA_COMP_PDB_ACCESS.</param>
    /// <param name="szObjOrPdb">[in] The name of the OBJ or PDB file that is related to the error.</param>
    /// <param name="szLib">[in] If szObjOrPdb refers to an OBJ file within a LIB file, this is the name of the LIB. Otherwise it is nullptr.</param>
    /// <returns>The return value is ignored.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate HRESULT PFNMINIPDBERRORCALLBACK2(
        [In] IntPtr pvContext,
        [In] HRESULT dwErrorCode,
        [In, MarshalAs(UnmanagedType.LPWStr)] string szObjOrPdb,
        [In, MarshalAs(UnmanagedType.LPWStr)] string szLib);

    public delegate int setPfnMiniPDBNHBuildStatusCallbackUnknownDelegate(
        [In] IntPtr a,
        [In] long b);

    [Guid("5C7E382A-93B4-4677-A6B5-CC28C3ACCB96")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaDataSource10 : IDiaDataSource3
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Retrieves the file name for the last load error.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a string that contains the .pdb file name associated with the last load error.</param>
        /// <returns>Returns the last error code caused by a load operation. Returns E_INVALIDARG if the pRetVal parameter is NULL.</returns>
        [PreserveSig]
        new HRESULT get_lastError(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        /// <summary>
        /// Opens and prepares a program database (.pdb) file as a debug data source.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method loads the debug data directly from a .pdb file. To validate the .pdb file against specific criteria,
        /// use the <see cref="loadAndValidateDataFromPdb"/> method. To gain access to the data load process (through a callback
        /// mechanism), use the <see cref="loadDataForExe"/> method. To load a .pdb file directly from memory, use the <see
        /// cref="loadDataFromIStream"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT loadDataFromPdb(
            [MarshalAs(UnmanagedType.LPWStr), In] string pdbPath);

        /// <summary>
        /// Opens and verifies that the program database (.pdb) file matches the signature information provided, and prepares the .pdb file as a debug data source.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <param name="pcsig70">[in] The GUID signature to verify against the .pdb file signature. Only .pdb files in Visual C++ and later have GUID signatures.</param>
        /// <param name="sig">[in] The 32-bit signature to verify against the .pdb file signature.</param>
        /// <param name="age">[in] Age value to verify. The age does not necessarily correspond to any known time value, it is used to determine if a .pdb file is out of sync with a corresponding .exe file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// A .pdb file contains both signature and age values. These values are replicated in the .exe or .dll file that matches
        /// the .pdb file. Before preparing the data source, this method verifies that the named .pdb file's signature and
        /// age match the values provided. To load a .pdb file without validation, use the <see cref="loadDataFromPdb"/> method.
        /// To gain access to the data load process (through a callback mechanism), use the <see cref="loadDataForExe"/> method.
        /// To load a .pdb file directly from memory, use the <see cref="loadDataFromIStream"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT loadAndValidateDataFromPdb(
            [MarshalAs(UnmanagedType.LPWStr), In] string pdbPath,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid pcsig70,
            [In] int sig,
            [In] int age);

        /// <summary>
        /// Opens and prepares the debug data associated with the .exe/.dll file.
        /// </summary>
        /// <param name="executable">[in] Path to the .exe or .dll file.</param>
        /// <param name="searchPath">[in] Alternate path to search for debug data.</param>
        /// <param name="pCallback">[in] An IUnknown interface for an object that supports a debug callback interface, such as the <see cref="IDiaLoadCallback"/>, <see cref="IDiaLoadCallback2"/>, the <see cref="IDiaReadExeAtOffsetCallback"/>, and/or the <see cref="IDiaReadExeAtRVACallback"/> interfaces.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows some of the possible error codes for this method.</returns>
        /// <remarks>
        /// The debug header of the .exe/.dll file names the associated debug data location. If you are loading debug data
        /// from a symbol server, symsrv.dll must be present in the same directory where either the user’s application or msdia140.dll
        /// is installed, or it must be present in the system directory. This method reads the debug header and then searches
        /// for and prepares the debug data. The progress of the search may, optionally, be reported and controlled through
        /// callbacks. For example, the <see cref="IDiaLoadCallback.NotifyDebugDir"/> is invoked when the IDiaDataSource::loadDataForExe
        /// method finds and processes a debug directory. The <see cref="IDiaReadExeAtOffsetCallback"/> and <see cref="IDiaReadExeAtRVACallback"/>
        /// interfaces allow the client application to provide alternative methods for reading data from the executable file
        /// when the file cannot be accessed directly through standard file I/O. To load a .pdb file without validation, use
        /// the <see cref="loadDataFromPdb"/> method. To validate the .pdb file against specific criteria, use the <see cref="loadAndValidateDataFromPdb"/>
        /// method. To load a .pdb file directly from memory, use the <see cref="loadDataFromIStream"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT loadDataForExe(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);

        /// <summary>
        /// Prepares the debug data stored in a program database (.pdb) file accessed through an in-memory data stream.
        /// </summary>
        /// <param name="pIStream">[in] An IStream object representing the data stream to use.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method allows the debug data for an executable to be obtained from memory through an IStream object. To load
        /// a .pdb file without validation, use the <see cref="loadDataFromPdb"/> method. To validate the .pdb file against
        /// specific criteria, use the <see cref="loadAndValidateDataFromPdb"/> method. To gain access to the data load process
        /// (through a callback mechanism), use the <see cref="loadDataForExe"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT loadDataFromIStream(
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);

        /// <summary>
        /// Opens a session for querying symbols.
        /// </summary>
        /// <param name="ppSession">[out] Returns an <see cref="IDiaSession"/> object representing the open session.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method opens an <see cref="IDiaSession"/> object for a data source. IDiaSession objects implement queries
        /// into the data source. A session manages one address space for each set of debug symbols. If the .exe or .dll file
        /// described by the data source symbols is active in multiple address ranges (for example, because multiple processes
        /// have it loaded), then one session for each address range should be used.
        /// </remarks>
        [PreserveSig]
        new HRESULT openSession(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSession ppSession);

        [PreserveSig]
        new HRESULT loadDataFromCodeViewInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [In] int cbCvInfo,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbCvInfo,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);

        [PreserveSig]
        new HRESULT loadDataFromMiscInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [In] int timeStampExe,
            [In] int timeStampDbg,
            [In] int sizeOfExe,
            [In] int cbMiscInfo,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] pbMiscInfo,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);

        //Gets the PDB1 object that is being used internally. Use with ClrDebug.PDB1.
        [PreserveSig]
        new HRESULT getRawPDBPtr(
            [Out] out IntPtr pppdb);

        [PreserveSig]
        new HRESULT loadDataFromRawPDBPtr(
            [In] IntPtr ppdb);

        //Documentation has these two as part of IDiaDataSourceEx, however their suggests vtbl positions do not match
        //what is actually listed in the vtbl

        /// <summary>
        /// Retrieves the size, in bytes, of the named stream.
        /// </summary>
        /// <param name="stream">[in] The name of the stream within the debug information.</param>
        /// <param name="pcb">[out] The size in bytes of the named stream.</param>
        /// <returns>If successful, returns S_OK. If the named stream does not exist within the PDB, the API might fail, or it i might return a length of 0.</returns>
        /// <remarks>
        /// Program Databases are made up of multiple streams of data. Some of those streams are named. You can use this method to gather information about these named streams.
        /// To get the data of the stream, use the <see cref="getStreamRawData"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT getStreamSize(
            [MarshalAs(UnmanagedType.LPWStr), In] string stream,
            [Out] out int pcb);

        //The documentation suggests there's 5 parameters: stream, cbOffset, cbRead, pcbRead, pbData, but IDA says otherwise

        /// <summary>
        /// Retrieves the raw bytes of the named stream.
        /// </summary>
        /// <param name="stream">[in] The name of the stream within the debug information.</param>
        /// <param name="cbRead">[in] The number of bytes to retrieve.</param>
        /// <param name="pbData">[out] The location to store the read data. On input must be at least cbRead bytes in size. Upon successful return *pcbRead bytes will be valid.</param>
        /// <returns>If successful, returns S_OK. If the named stream does not exist within the PDB, the API might fail, or it might return a length of 0.</returns>
        /// <remarks>
        /// Program Databases are made up of multiple streams of data. Some of those streams are named. You can use this method to gather information about these named streams.
        /// To get the size of the stream, use the <see cref="getStreamSize"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT getStreamRawData(
            [MarshalAs(UnmanagedType.LPWStr), In] string stream,
            [In] int cbRead,
            [Out] IntPtr pbData);
#endif

        //https://learn.microsoft.com/en-us/visualstudio/debugger/debug-interface-access/idiadatasourceex?view=vs-2022

        //Parameter names have been deduced from the non-Ex versions each method extends.
        //Unknown parameters are prefixed with an underscore

        /// <summary>
        /// Opens and prepares a program database (.pdb) file as a debug data source with optional record prefetching.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <param name="fPdbPrefetching">[in] If set to TRUE, adjacent debug records are prefetched into memory, potentially replacing many smaller file I/O operations with fewer,
        /// larger operations, and thus improving overall throughput as those records are subsequently accessed, at the expense of potentially increased memory usage.
        /// If set to FALSE, this behaves identically to IDiaDataSource::loadDataFromPdb. If set to some other value, behavior is unspecified.</param>
        /// <returns>
        /// If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.
        ///
        /// | HRESULT         | Description                                                                 |
        /// | --------------- | --------------------------------------------------------------------------- |
        /// | E_PDB_NOT_FOUND | Failed to open the file, or determined that the file has an invalid format. |
        /// | E_PDB_FORMAT    | Attempted to access a file with an incompatible or unsupported format.      |
        /// | E_INVALIDARG    | Invalid parameter.                                                          |
        /// | E_UNEXPECTED    | Data source has already been prepared.                                      |
        /// </returns>
        /// <remarks>
        /// This method loads the debug data directly from a .pdb file. To validate the.pdb file against specific criteria, use the <see cref="loadAndValidateDataFromPdbEx"/> method.
        /// To gain access to the data load process (through a callback mechanism), use the <see cref="loadDataForExeEx"/> method. To load a .pdb file directly from memory, use the
        /// <see cref="loadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT loadDataFromPdbEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching);

        /// <summary>
        /// Opens and verifies that the program database (.pdb) file matches the signature information provided, and prepares the .pdb file as a debug data source, with optional record prefetching.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <param name="pcsig70">[in] The globally unique identifier (GUID) signature to verify against the .pdb file signature. Only .pdb files in Visual C++ and later have GUID signatures.</param>
        /// <param name="sig">[in] The 32-bit signature to verify against the .pdb file signature.</param>
        /// <param name="age">[in] Age value to verify. The age does not necessarily correspond to any known time value, it is used to determine whether a .pdb file is out of sync with a corresponding .exe file.</param>
        /// <param name="fPdbPrefetching">[in] If set to TRUE, adjacent debug records are prefetched into memory, potentially replacing many smaller file I/O operations with fewer, larger operations, and thus improving
        /// overall throughput as those records are subsequently accessed, at the expense of potentially increased memory usage. If set to FALSE, this behaves identically to IDiaDataSource::loadAndValidateDataFromPdb.
        /// If set to some other value, behavior is unspecified.</param>
        /// <returns>
        /// If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.
        ///
        /// | HRESULT           | Description                                                 |
        /// | ----------------- | ----------------------------------------------------------- |
        /// | E_PDB_NOT_FOUND   | Failed to open the file, or the file has an invalid format. |
        /// | E_PDB_FORMAT      | Attempted to access a file with an obsolete format.         |
        /// | E_PDB_INVALID_SIG | Signature does not match.                                   |
        /// | E_PDB_INVALID_AGE | Age does not match.                                         |
        /// | E_INVALIDARG      | Invalid parameter.                                          |
        /// | E_UNEXPECTED      | The data source has already been prepared.                  |
        /// </returns>
        /// <remarks>
        /// A .pdb file contains both signature and age values. These values are replicated in the .exe or .dll file that matches the .pdb file. Before preparing the data source,
        /// this method verifies that the named .pdb file's signature and age match the values provided. To load a .pdb file without validation, use the <see cref="loadDataFromPdbEx"/>
        /// method. To gain access to the data load process (through a callback mechanism), use the <see cref="loadDataForExeEx"/> method. To load a .pdb file directly from memory,
        /// use the <see cref="loadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT loadAndValidateDataFromPdbEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid pcsig70,
            [In] int sig,
            [In] int age,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching);

        /// <summary>
        /// Opens and prepares the debug data associated with the .exe/.dll file, with optional record prefetching.
        /// </summary>
        /// <param name="executable">[in] Path to the .exe or .dll file.</param>
        /// <param name="searchPath">[in] Alternate path to search for debug data. Multiple paths should be semicolon delimited. Paths may contain a trailing \.</param>
        /// <param name="pCallback">[in] An IUnknown interface for an object that supports a debug callback interface, such as the IDiaLoadCallback, IDiaLoadCallback2, the IDiaReadExeAtOffsetCallback,
        /// and/or the IDiaReadExeAtRVACallback interfaces.</param>
        /// <param name="fPdbPrefetching">[in] If set to TRUE, adjacent debug records are prefetched into memory, potentially replacing many smaller file I/O operations with fewer, larger operations, and thus
        /// improving overall throughput as those records are subsequently accessed, at the expense of potentially increased memory usage. If set to FALSE, this behaves identically to IDiaDataSource::loadDataForExe.
        /// If set to some other value, behavior is unspecified.</param>
        /// <returns>
        /// If successful, returns S_OK; otherwise, returns an error code. The following table shows some of the possible error codes for this method.
        ///
        /// | HRESULT           | Description                                                 |
        /// | ----------------- | ----------------------------------------------------------- |
        /// | E_PDB_NOT_FOUND   | Failed to open the file, or the file has an invalid format. |
        /// | E_PDB_FORMAT      | Attempted to access a file with an obsolete format.         |
        /// | E_PDB_INVALID_SIG | Signature does not match.                                   |
        /// | E_PDB_INVALID_AGE | Age does not match.                                         |
        /// | E_INVALIDARG      | Invalid parameter.                                          |
        /// | E_UNEXPECTED      | Data source has already been prepared.                      |
        /// </returns>
        /// <remarks>
        /// The debug header of the .exe/.dll file names the associated debug data location. If you are loading debug data from a symbol server, symsrv.dll must be present in the same directory where either the user's
        /// application or msdia140.dll is installed, or it must be present in the system directory. This method reads the debug header and then searches for and prepares the debug data.The progress of the search may,
        /// optionally, be reported and controlled through callbacks.For example, the <see cref="IDiaLoadCallback.NotifyDebugDir"/> is invoked when the <see cref="loadDataForExeEx"/> method finds and processes a debug directory.
        /// The <see cref="IDiaReadExeAtOffsetCallback"/> and <see cref="IDiaReadExeAtRVACallback"/> interfaces allow the client application to provide alternative methods for reading data from the executable file when the file cannot be accessed
        /// directly through standard file I/O. To load a .pdb file without validation, use the <see cref="loadDataFromPdbEx"/> method. To validate the.pdb file against specific criteria, use the <see cref="loadAndValidateDataFromPdbEx"/>
        /// method. To load a .pdb file directly from memory, use the <see cref="loadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT loadDataForExeEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching); //Calls PDB1::EnablePrefetching

        /// <summary>
        /// Prepares the debug data stored in a program database (.pdb) file accessed through a potentially in-memory data stream, with optional record prefetching.
        /// </summary>
        /// <param name="pIStream">[in] An <see cref="IStream"/> object representing the data stream to use.</param>
        /// <param name="fPdbPrefetching">[in] If set to TRUE, adjacent debug records are prefetched into memory, potentially replacing many smaller file I/O operations with fewer, larger operations, and thus
        /// improving overall throughput as those records are subsequently accessed, at the expense of potentially increased memory usage. If set to FALSE, this behaves identically to <see cref="loadDataFromIStream"/>.
        /// If set to some other value, behavior is unspecified.</param>
        /// <returns>
        /// If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.
        ///
        /// | HRESULT           | Description                                         |
        /// | ----------------- | ----------------------------------------------------|
        /// | E_PDB_FORMAT      | Attempted to access a file with an obsolete format. |
        /// | E_INVALIDARG      | Invalid parameter.                                  |
        /// | E_UNEXPECTED      | Data source has already been prepared.              |
        /// </returns>
        /// <remarks>
        /// This method allows the debug data for an executable to be obtained from memory through an IStream object. To load a .pdb file without validation, use the <see cref="loadDataFromPdbEx"/> method.
        /// To validate the .pdb file against specific criteria, use the <see cref="loadAndValidateDataFromPdbEx"/> method. To gain access to the data load process (through a callback mechanism),
        /// use the <see cref="loadDataForExeEx"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT loadDataFromIStreamEx(
            [In, MarshalAs(UnmanagedType.Interface)] IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching);

        [PreserveSig]
        HRESULT _Missing1(); //Maybe ValidatePdb? Method is not present. Documentation says it should be _after_ setPfnMiniPDBErrorCallback2 but vtbl says otherwise

        [PreserveSig]
        HRESULT setPfnMiniPDBErrorCallback2(
            IntPtr pvContext,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] PFNMINIPDBERRORCALLBACK2 pfn);

        [PreserveSig]
        HRESULT setPfnMiniPDBNHBuildStatusCallback(
            [In] IntPtr _a,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] setPfnMiniPDBNHBuildStatusCallbackUnknownDelegate _b);

        [PreserveSig]
        HRESULT loadDataFromPdbEx2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);

        [PreserveSig]
        HRESULT loadAndValidateDataFromPdbEx2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid pcsig70,
            [In] int sig, //The symbols say its a ulong, but they say the same thing about loadAndValidateDataFromPdb.sig
            [In] int age, //Same as above
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);

        [PreserveSig]
        HRESULT loadDataForExeEx2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode); //Specifies the mode for LOCATOR::SetPdbOpenMode. Passed to PDB::OpenValidate4. Default mode in loadDataForExeEx2 is "rd". Default mode if "d" not specified is "r" (from LOCATOR ctor). If false, mode is "r" = pdbRead. "d" is a new open mode, can't see where it's used

        [PreserveSig]
        HRESULT loadDataFromIStreamEx2(
            [In, MarshalAs(UnmanagedType.Interface)] IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);

        [PreserveSig]
        HRESULT loadDataFromCodeViewInfoEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] int cbCvInfo, //The symbols say its a ulong, but they say the same thing about loadDataFromCodeViewInfo.cbCvInfo too
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbCvInfo,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);

        [PreserveSig]
        HRESULT VSDebuggerPreloadPDBDone();

        [PreserveSig]
        HRESULT loadDataForExeEx3(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode,
            [In, MarshalAs(UnmanagedType.Bool)] bool _searchInBinaryDirectoryOnly); //passed to LOCATOR::SetSearchInBinaryDirectoryOnly

        [PreserveSig]
        HRESULT usePdb(
            [In] IntPtr _ppdb); //Sets the PDB1 that can also be retrieved with getRawPDBPtr

        [PreserveSig]
        HRESULT loadDataFromCodeViewInfoHelper(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] int cbCvInfo, //The symbols say its a ulong, but they say the same thing about loadDataFromCodeViewInfo.cbCvInfo too
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbCvInfo,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.LPStr)] string _pdbOpenMode); //e.g. "r", "rd", etc
    }
}

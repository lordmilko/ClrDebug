using System;
using System.Diagnostics;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Initiates access to a source of debugging symbols.
    /// </summary>
    /// <remarks>
    /// A call to one of the load methods of the IDiaDataSource interface opens the symbol source. A successful call to
    /// the <see cref="OpenSession"/> method returns an <see cref="IDiaSession"/> interface that supports querying the
    /// data source. If the load method returns a file-related error then the <see cref="LastError"/> property return
    /// value contains the file name associated with the error. This interface is obtained by calling the CoCreateInstance
    /// function with the class identifier CLSID_DiaSource and the interface ID of IID_IDiaDataSource. The example shows
    /// how this interface is obtained.
    /// </remarks>
    public class DiaDataSource : ComObject<IDiaDataSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaDataSource"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaDataSource(IDiaDataSource raw) : base(raw)
        {
        }

        #region IDiaDataSource
        #region LastError

        /// <summary>
        /// Retrieves the file name for the last load error.
        /// </summary>
        public string LastError
        {
            get
            {
                string pRetVal;
                TryGetLastError(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the file name for the last load error.
        /// </summary>
        /// <param name="pRetVal">[out] Returns a string that contains the .pdb file name associated with the last load error.</param>
        /// <returns>Returns the last error code caused by a load operation. Returns E_INVALIDARG if the pRetVal parameter is NULL.</returns>
        public HRESULT TryGetLastError(out string pRetVal)
        {
            /*HRESULT get_lastError(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_lastError(out pRetVal);
        }

        #endregion
        #region LoadDataFromPdb

        /// <summary>
        /// Opens and prepares a program database (.pdb) file as a debug data source.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <remarks>
        /// This method loads the debug data directly from a .pdb file. To validate the .pdb file against specific criteria,
        /// use the <see cref="LoadAndValidateDataFromPdb"/> method. To gain access to the data load process (through a callback
        /// mechanism), use the <see cref="LoadDataForExe"/> method. To load a .pdb file directly from memory, use the <see
        /// cref="LoadDataFromIStream"/> method.
        /// </remarks>
        public void LoadDataFromPdb(string pdbPath)
        {
            TryLoadDataFromPdb(pdbPath).ThrowOnNotOK();
        }

        /// <summary>
        /// Opens and prepares a program database (.pdb) file as a debug data source.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method loads the debug data directly from a .pdb file. To validate the .pdb file against specific criteria,
        /// use the <see cref="LoadAndValidateDataFromPdb"/> method. To gain access to the data load process (through a callback
        /// mechanism), use the <see cref="LoadDataForExe"/> method. To load a .pdb file directly from memory, use the <see
        /// cref="LoadDataFromIStream"/> method.
        /// </remarks>
        public HRESULT TryLoadDataFromPdb(string pdbPath)
        {
            /*HRESULT loadDataFromPdb(
            [MarshalAs(UnmanagedType.LPWStr), In] string pdbPath);*/
            return Raw.loadDataFromPdb(pdbPath);
        }

        #endregion
        #region LoadAndValidateDataFromPdb

        /// <summary>
        /// Opens and verifies that the program database (.pdb) file matches the signature information provided, and prepares the .pdb file as a debug data source.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <param name="pcsig70">[in] The GUID signature to verify against the .pdb file signature. Only .pdb files in Visual C++ and later have GUID signatures.</param>
        /// <param name="sig">[in] The 32-bit signature to verify against the .pdb file signature.</param>
        /// <param name="age">[in] Age value to verify. The age does not necessarily correspond to any known time value, it is used to determine if a .pdb file is out of sync with a corresponding .exe file.</param>
        /// <remarks>
        /// A .pdb file contains both signature and age values. These values are replicated in the .exe or .dll file that matches
        /// the .pdb file. Before preparing the data source, this method verifies that the named .pdb file's signature and
        /// age match the values provided. To load a .pdb file without validation, use the <see cref="LoadDataFromPdb"/> method.
        /// To gain access to the data load process (through a callback mechanism), use the <see cref="LoadDataForExe"/> method.
        /// To load a .pdb file directly from memory, use the <see cref="LoadDataFromIStream"/> method.
        /// </remarks>
        public void LoadAndValidateDataFromPdb(string pdbPath, Guid pcsig70, int sig, int age)
        {
            TryLoadAndValidateDataFromPdb(pdbPath, pcsig70, sig, age).ThrowOnNotOK();
        }

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
        /// age match the values provided. To load a .pdb file without validation, use the <see cref="LoadDataFromPdb"/> method.
        /// To gain access to the data load process (through a callback mechanism), use the <see cref="LoadDataForExe"/> method.
        /// To load a .pdb file directly from memory, use the <see cref="LoadDataFromIStream"/> method.
        /// </remarks>
        public HRESULT TryLoadAndValidateDataFromPdb(string pdbPath, Guid pcsig70, int sig, int age)
        {
            /*HRESULT loadAndValidateDataFromPdb(
            [MarshalAs(UnmanagedType.LPWStr), In] string pdbPath,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pcsig70,
            [In] int sig,
            [In] int age);*/
            return Raw.loadAndValidateDataFromPdb(pdbPath, pcsig70, sig, age);
        }

        #endregion
        #region LoadDataForExe

        /// <summary>
        /// Opens and prepares the debug data associated with the .exe/.dll file.
        /// </summary>
        /// <param name="executable">[in] Path to the .exe or .dll file.</param>
        /// <param name="searchPath">[in] Alternate path to search for debug data.</param>
        /// <param name="pCallback">[in] An IUnknown interface for an object that supports a debug callback interface, such as the <see cref="IDiaLoadCallback"/>, <see cref="IDiaLoadCallback2"/>, the <see cref="IDiaReadExeAtOffsetCallback"/>, and/or the <see cref="IDiaReadExeAtRVACallback"/> interfaces.</param>
        /// <remarks>
        /// The debug header of the .exe/.dll file names the associated debug data location. If you are loading debug data
        /// from a symbol server, symsrv.dll must be present in the same directory where either the user’s application or msdia140.dll
        /// is installed, or it must be present in the system directory. This method reads the debug header and then searches
        /// for and prepares the debug data. The progress of the search may, optionally, be reported and controlled through
        /// callbacks. For example, the <see cref="IDiaLoadCallback.NotifyDebugDir"/> is invoked when the IDiaDataSource::loadDataForExe
        /// method finds and processes a debug directory. The <see cref="IDiaReadExeAtOffsetCallback"/> and <see cref="IDiaReadExeAtRVACallback"/>
        /// interfaces allow the client application to provide alternative methods for reading data from the executable file
        /// when the file cannot be accessed directly through standard file I/O. To load a .pdb file without validation, use
        /// the <see cref="LoadDataFromPdb"/> method. To validate the .pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdb"/>
        /// method. To load a .pdb file directly from memory, use the <see cref="LoadDataFromIStream"/> method.
        /// </remarks>
        public void LoadDataForExe(string executable, string searchPath, object pCallback)
        {
            TryLoadDataForExe(executable, searchPath, pCallback).ThrowOnNotOK();
        }

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
        /// the <see cref="LoadDataFromPdb"/> method. To validate the .pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdb"/>
        /// method. To load a .pdb file directly from memory, use the <see cref="LoadDataFromIStream"/> method.
        /// </remarks>
        public HRESULT TryLoadDataForExe(string executable, string searchPath, object pCallback)
        {
            /*HRESULT loadDataForExe(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);*/
            return Raw.loadDataForExe(executable, searchPath, pCallback);
        }

        #endregion
        #region LoadDataFromIStream

        /// <summary>
        /// Prepares the debug data stored in a program database (.pdb) file accessed through an in-memory data stream.
        /// </summary>
        /// <param name="pIStream">[in] An IStream object representing the data stream to use.</param>
        /// <remarks>
        /// This method allows the debug data for an executable to be obtained from memory through an IStream object. To load
        /// a .pdb file without validation, use the <see cref="LoadDataFromPdb"/> method. To validate the .pdb file against
        /// specific criteria, use the <see cref="LoadAndValidateDataFromPdb"/> method. To gain access to the data load process
        /// (through a callback mechanism), use the <see cref="LoadDataForExe"/> method.
        /// </remarks>
        public void LoadDataFromIStream(IStream pIStream)
        {
            TryLoadDataFromIStream(pIStream).ThrowOnNotOK();
        }

        /// <summary>
        /// Prepares the debug data stored in a program database (.pdb) file accessed through an in-memory data stream.
        /// </summary>
        /// <param name="pIStream">[in] An IStream object representing the data stream to use.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method allows the debug data for an executable to be obtained from memory through an IStream object. To load
        /// a .pdb file without validation, use the <see cref="LoadDataFromPdb"/> method. To validate the .pdb file against
        /// specific criteria, use the <see cref="LoadAndValidateDataFromPdb"/> method. To gain access to the data load process
        /// (through a callback mechanism), use the <see cref="LoadDataForExe"/> method.
        /// </remarks>
        public HRESULT TryLoadDataFromIStream(IStream pIStream)
        {
            /*HRESULT loadDataFromIStream(
            [MarshalAs(UnmanagedType.Interface), In] IStream pIStream);*/
            return Raw.loadDataFromIStream(pIStream);
        }

        #endregion
        #region OpenSession

        /// <summary>
        /// Opens a session for querying symbols.
        /// </summary>
        /// <returns>[out] Returns an <see cref="IDiaSession"/> object representing the open session.</returns>
        /// <remarks>
        /// This method opens an <see cref="IDiaSession"/> object for a data source. IDiaSession objects implement queries
        /// into the data source. A session manages one address space for each set of debug symbols. If the .exe or .dll file
        /// described by the data source symbols is active in multiple address ranges (for example, because multiple processes
        /// have it loaded), then one session for each address range should be used.
        /// </remarks>
        public DiaSession OpenSession()
        {
            DiaSession ppSessionResult;
            TryOpenSession(out ppSessionResult).ThrowOnNotOK();

            return ppSessionResult;
        }

        /// <summary>
        /// Opens a session for querying symbols.
        /// </summary>
        /// <param name="ppSessionResult">[out] Returns an <see cref="IDiaSession"/> object representing the open session.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method opens an <see cref="IDiaSession"/> object for a data source. IDiaSession objects implement queries
        /// into the data source. A session manages one address space for each set of debug symbols. If the .exe or .dll file
        /// described by the data source symbols is active in multiple address ranges (for example, because multiple processes
        /// have it loaded), then one session for each address range should be used.
        /// </remarks>
        public HRESULT TryOpenSession(out DiaSession ppSessionResult)
        {
            /*HRESULT openSession(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSession ppSession);*/
            IDiaSession ppSession;
            HRESULT hr = Raw.openSession(out ppSession);

            if (hr == HRESULT.S_OK)
                ppSessionResult = ppSession == null ? null : new DiaSession(ppSession);
            else
                ppSessionResult = default(DiaSession);

            return hr;
        }

        #endregion
        #region LoadDataFromCodeViewInfo

        public void LoadDataFromCodeViewInfo(string executable, string searchPath, int cbCvInfo, byte[] pbCvInfo, object pCallback)
        {
            TryLoadDataFromCodeViewInfo(executable, searchPath, cbCvInfo, pbCvInfo, pCallback).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataFromCodeViewInfo(string executable, string searchPath, int cbCvInfo, byte[] pbCvInfo, object pCallback)
        {
            /*HRESULT loadDataFromCodeViewInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [In] int cbCvInfo,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbCvInfo,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);*/
            return Raw.loadDataFromCodeViewInfo(executable, searchPath, cbCvInfo, pbCvInfo, pCallback);
        }

        #endregion
        #region LoadDataFromMiscInfo

        public void LoadDataFromMiscInfo(string executable, string searchPath, int timeStampExe, int timeStampDbg, int sizeOfExe, int cbMiscInfo, byte[] pbMiscInfo, object pCallback)
        {
            TryLoadDataFromMiscInfo(executable, searchPath, timeStampExe, timeStampDbg, sizeOfExe, cbMiscInfo, pbMiscInfo, pCallback).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataFromMiscInfo(string executable, string searchPath, int timeStampExe, int timeStampDbg, int sizeOfExe, int cbMiscInfo, byte[] pbMiscInfo, object pCallback)
        {
            /*HRESULT loadDataFromMiscInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [In] int timeStampExe,
            [In] int timeStampDbg,
            [In] int sizeOfExe,
            [In] int cbMiscInfo,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] pbMiscInfo,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);*/
            return Raw.loadDataFromMiscInfo(executable, searchPath, timeStampExe, timeStampDbg, sizeOfExe, cbMiscInfo, pbMiscInfo, pCallback);
        }

        #endregion
        #endregion
        #region IDiaDataSource2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaDataSource2 Raw2 => (IDiaDataSource2) Raw;

        #region RawPDBPtr

        public IntPtr RawPDBPtr
        {
            get
            {
                IntPtr pppdb;
                TryGetRawPDBPtr(out pppdb).ThrowOnNotOK();

                return pppdb;
            }
        }

        public HRESULT TryGetRawPDBPtr(out IntPtr pppdb)
        {
            /*HRESULT getRawPDBPtr(
            [Out] out IntPtr pppdb);*/
            return Raw2.getRawPDBPtr(out pppdb);
        }

        #endregion
        #region LoadDataFromRawPDBPtr

        public void LoadDataFromRawPDBPtr(IntPtr ppdb)
        {
            TryLoadDataFromRawPDBPtr(ppdb).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataFromRawPDBPtr(IntPtr ppdb)
        {
            /*HRESULT loadDataFromRawPDBPtr(
            [In] IntPtr ppdb);*/
            return Raw2.loadDataFromRawPDBPtr(ppdb);
        }

        #endregion
        #endregion
        #region IDiaDataSource3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaDataSource3 Raw3 => (IDiaDataSource3) Raw;

        #region GetStreamSize

        /// <summary>
        /// Retrieves the size, in bytes, of the named stream.
        /// </summary>
        /// <param name="stream">[in] The name of the stream within the debug information.</param>
        /// <returns>[out] The size in bytes of the named stream.</returns>
        /// <remarks>
        /// Program Databases are made up of multiple streams of data. Some of those streams are named. You can use this method to gather information about these named streams.
        /// To get the data of the stream, use the <see cref="GetStreamRawData"/> method.
        /// </remarks>
        public int GetStreamSize(string stream)
        {
            int pcb;
            TryGetStreamSize(stream, out pcb).ThrowOnNotOK();

            return pcb;
        }

        /// <summary>
        /// Retrieves the size, in bytes, of the named stream.
        /// </summary>
        /// <param name="stream">[in] The name of the stream within the debug information.</param>
        /// <param name="pcb">[out] The size in bytes of the named stream.</param>
        /// <returns>If successful, returns S_OK. If the named stream does not exist within the PDB, the API might fail, or it i might return a length of 0.</returns>
        /// <remarks>
        /// Program Databases are made up of multiple streams of data. Some of those streams are named. You can use this method to gather information about these named streams.
        /// To get the data of the stream, use the <see cref="GetStreamRawData"/> method.
        /// </remarks>
        public HRESULT TryGetStreamSize(string stream, out int pcb)
        {
            /*HRESULT getStreamSize(
            [MarshalAs(UnmanagedType.LPWStr), In] string stream,
            [Out] out int pcb);*/
            return Raw3.getStreamSize(stream, out pcb);
        }

        #endregion
        #region GetStreamRawData

        /// <summary>
        /// Retrieves the raw bytes of the named stream.
        /// </summary>
        /// <param name="stream">[in] The name of the stream within the debug information.</param>
        /// <param name="cbRead">[in] The number of bytes to retrieve.</param>
        /// <param name="pbData">[out] The location to store the read data. On input must be at least cbRead bytes in size. Upon successful return *pcbRead bytes will be valid.</param>
        /// <remarks>
        /// Program Databases are made up of multiple streams of data. Some of those streams are named. You can use this method to gather information about these named streams.
        /// To get the size of the stream, use the <see cref="GetStreamSize"/> method.
        /// </remarks>
        public void GetStreamRawData(string stream, int cbRead, IntPtr pbData)
        {
            TryGetStreamRawData(stream, cbRead, pbData).ThrowOnNotOK();
        }

        /// <summary>
        /// Retrieves the raw bytes of the named stream.
        /// </summary>
        /// <param name="stream">[in] The name of the stream within the debug information.</param>
        /// <param name="cbRead">[in] The number of bytes to retrieve.</param>
        /// <param name="pbData">[out] The location to store the read data. On input must be at least cbRead bytes in size. Upon successful return *pcbRead bytes will be valid.</param>
        /// <returns>If successful, returns S_OK. If the named stream does not exist within the PDB, the API might fail, or it might return a length of 0.</returns>
        /// <remarks>
        /// Program Databases are made up of multiple streams of data. Some of those streams are named. You can use this method to gather information about these named streams.
        /// To get the size of the stream, use the <see cref="GetStreamSize"/> method.
        /// </remarks>
        public HRESULT TryGetStreamRawData(string stream, int cbRead, IntPtr pbData)
        {
            /*HRESULT getStreamRawData(
            [MarshalAs(UnmanagedType.LPWStr), In] string stream,
            [In] int cbRead,
            [Out] IntPtr pbData);*/
            return Raw3.getStreamRawData(stream, cbRead, pbData);
        }

        #endregion
        #endregion
        #region IDiaDataSource10

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaDataSource10 Raw10 => (IDiaDataSource10) Raw;

        #region LoadDataFromPdbEx

        /// <summary>
        /// Opens and prepares a program database (.pdb) file as a debug data source with optional record prefetching.
        /// </summary>
        /// <param name="pdbPath">[in] The path to the .pdb file.</param>
        /// <param name="fPdbPrefetching">[in] If set to TRUE, adjacent debug records are prefetched into memory, potentially replacing many smaller file I/O operations with fewer,
        /// larger operations, and thus improving overall throughput as those records are subsequently accessed, at the expense of potentially increased memory usage.
        /// If set to FALSE, this behaves identically to IDiaDataSource::loadDataFromPdb. If set to some other value, behavior is unspecified.</param>
        /// <remarks>
        /// This method loads the debug data directly from a .pdb file. To validate the.pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdbEx"/> method.
        /// To gain access to the data load process (through a callback mechanism), use the <see cref="LoadDataForExeEx"/> method. To load a .pdb file directly from memory, use the
        /// <see cref="LoadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        public void LoadDataFromPdbEx(string pdbPath, bool fPdbPrefetching)
        {
            TryLoadDataFromPdbEx(pdbPath, fPdbPrefetching).ThrowOnNotOK();
        }

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
        /// This method loads the debug data directly from a .pdb file. To validate the.pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdbEx"/> method.
        /// To gain access to the data load process (through a callback mechanism), use the <see cref="LoadDataForExeEx"/> method. To load a .pdb file directly from memory, use the
        /// <see cref="LoadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        public HRESULT TryLoadDataFromPdbEx(string pdbPath, bool fPdbPrefetching)
        {
            /*HRESULT loadDataFromPdbEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching);*/
            return Raw10.loadDataFromPdbEx(pdbPath, fPdbPrefetching);
        }

        #endregion
        #region LoadAndValidateDataFromPdbEx

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
        /// <remarks>
        /// A .pdb file contains both signature and age values. These values are replicated in the .exe or .dll file that matches the .pdb file. Before preparing the data source,
        /// this method verifies that the named .pdb file's signature and age match the values provided. To load a .pdb file without validation, use the <see cref="LoadDataFromPdbEx"/>
        /// method. To gain access to the data load process (through a callback mechanism), use the <see cref="LoadDataForExeEx"/> method. To load a .pdb file directly from memory,
        /// use the <see cref="LoadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        public void LoadAndValidateDataFromPdbEx(string pdbPath, Guid pcsig70, int sig, int age, bool fPdbPrefetching)
        {
            TryLoadAndValidateDataFromPdbEx(pdbPath, pcsig70, sig, age, fPdbPrefetching).ThrowOnNotOK();
        }

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
        /// this method verifies that the named .pdb file's signature and age match the values provided. To load a .pdb file without validation, use the <see cref="LoadDataFromPdbEx"/>
        /// method. To gain access to the data load process (through a callback mechanism), use the <see cref="LoadDataForExeEx"/> method. To load a .pdb file directly from memory,
        /// use the <see cref="LoadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        public HRESULT TryLoadAndValidateDataFromPdbEx(string pdbPath, Guid pcsig70, int sig, int age, bool fPdbPrefetching)
        {
            /*HRESULT loadAndValidateDataFromPdbEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pcsig70,
            [In] int sig,
            [In] int age,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching);*/
            return Raw10.loadAndValidateDataFromPdbEx(pdbPath, pcsig70, sig, age, fPdbPrefetching);
        }

        #endregion
        #region LoadDataForExeEx

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
        /// <remarks>
        /// The debug header of the .exe/.dll file names the associated debug data location. If you are loading debug data from a symbol server, symsrv.dll must be present in the same directory where either the user's
        /// application or msdia140.dll is installed, or it must be present in the system directory. This method reads the debug header and then searches for and prepares the debug data.The progress of the search may,
        /// optionally, be reported and controlled through callbacks.For example, the <see cref="IDiaLoadCallback.NotifyDebugDir"/> is invoked when the <see cref="LoadDataForExeEx"/> method finds and processes a debug directory.
        /// The <see cref="IDiaReadExeAtOffsetCallback"/> and <see cref="IDiaReadExeAtRVACallback"/> interfaces allow the client application to provide alternative methods for reading data from the executable file when the file cannot be accessed
        /// directly through standard file I/O. To load a .pdb file without validation, use the <see cref="LoadDataFromPdbEx"/> method. To validate the.pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdbEx"/>
        /// method. To load a .pdb file directly from memory, use the <see cref="LoadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        public void LoadDataForExeEx(string executable, string searchPath, object pCallback, bool fPdbPrefetching)
        {
            TryLoadDataForExeEx(executable, searchPath, pCallback, fPdbPrefetching).ThrowOnNotOK();
        }

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
        /// optionally, be reported and controlled through callbacks.For example, the <see cref="IDiaLoadCallback.NotifyDebugDir"/> is invoked when the <see cref="LoadDataForExeEx"/> method finds and processes a debug directory.
        /// The <see cref="IDiaReadExeAtOffsetCallback"/> and <see cref="IDiaReadExeAtRVACallback"/> interfaces allow the client application to provide alternative methods for reading data from the executable file when the file cannot be accessed
        /// directly through standard file I/O. To load a .pdb file without validation, use the <see cref="LoadDataFromPdbEx"/> method. To validate the.pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdbEx"/>
        /// method. To load a .pdb file directly from memory, use the <see cref="LoadDataFromIStreamEx"/> method. To validate a .pdb file without loading it, use the <see cref="ValidatePdb"/> method.
        /// </remarks>
        public HRESULT TryLoadDataForExeEx(string executable, string searchPath, object pCallback, bool fPdbPrefetching)
        {
            /*HRESULT loadDataForExeEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching);*/
            return Raw10.loadDataForExeEx(executable, searchPath, pCallback, fPdbPrefetching);
        }

        #endregion
        #region LoadDataFromIStreamEx

        /// <summary>
        /// Prepares the debug data stored in a program database (.pdb) file accessed through a potentially in-memory data stream, with optional record prefetching.
        /// </summary>
        /// <param name="pIStream">[in] An <see cref="IStream"/> object representing the data stream to use.</param>
        /// <param name="fPdbPrefetching">[in] If set to TRUE, adjacent debug records are prefetched into memory, potentially replacing many smaller file I/O operations with fewer, larger operations, and thus
        /// improving overall throughput as those records are subsequently accessed, at the expense of potentially increased memory usage. If set to FALSE, this behaves identically to <see cref="LoadDataFromIStream"/>.
        /// If set to some other value, behavior is unspecified.</param>
        /// <remarks>
        /// This method allows the debug data for an executable to be obtained from memory through an IStream object. To load a .pdb file without validation, use the <see cref="LoadDataFromPdbEx"/> method.
        /// To validate the .pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdbEx"/> method. To gain access to the data load process (through a callback mechanism),
        /// use the <see cref="LoadDataForExeEx"/> method.
        /// </remarks>
        public void LoadDataFromIStreamEx(IStream pIStream, bool fPdbPrefetching)
        {
            TryLoadDataFromIStreamEx(pIStream, fPdbPrefetching).ThrowOnNotOK();
        }

        /// <summary>
        /// Prepares the debug data stored in a program database (.pdb) file accessed through a potentially in-memory data stream, with optional record prefetching.
        /// </summary>
        /// <param name="pIStream">[in] An <see cref="IStream"/> object representing the data stream to use.</param>
        /// <param name="fPdbPrefetching">[in] If set to TRUE, adjacent debug records are prefetched into memory, potentially replacing many smaller file I/O operations with fewer, larger operations, and thus
        /// improving overall throughput as those records are subsequently accessed, at the expense of potentially increased memory usage. If set to FALSE, this behaves identically to <see cref="LoadDataFromIStream"/>.
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
        /// This method allows the debug data for an executable to be obtained from memory through an IStream object. To load a .pdb file without validation, use the <see cref="LoadDataFromPdbEx"/> method.
        /// To validate the .pdb file against specific criteria, use the <see cref="LoadAndValidateDataFromPdbEx"/> method. To gain access to the data load process (through a callback mechanism),
        /// use the <see cref="LoadDataForExeEx"/> method.
        /// </remarks>
        public HRESULT TryLoadDataFromIStreamEx(IStream pIStream, bool fPdbPrefetching)
        {
            /*HRESULT loadDataFromIStreamEx(
            [In, MarshalAs(UnmanagedType.Interface)] IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching);*/
            return Raw10.loadDataFromIStreamEx(pIStream, fPdbPrefetching);
        }

        #endregion
        #region _Missing1

        public void _Missing1()
        {
            Try_Missing1().ThrowOnNotOK();
        }

        public HRESULT Try_Missing1()
        {
            /*HRESULT _Missing1();*/
            return Raw10._Missing1();
        }

        #endregion
        #region SetPfnMiniPDBErrorCallback2

        public void SetPfnMiniPDBErrorCallback2(IntPtr pvContext, PFNMINIPDBERRORCALLBACK2 pfn)
        {
            TrySetPfnMiniPDBErrorCallback2(pvContext, pfn).ThrowOnNotOK();
        }

        public HRESULT TrySetPfnMiniPDBErrorCallback2(IntPtr pvContext, PFNMINIPDBERRORCALLBACK2 pfn)
        {
            /*HRESULT setPfnMiniPDBErrorCallback2(
            IntPtr pvContext,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] PFNMINIPDBERRORCALLBACK2 pfn);*/
            return Raw10.setPfnMiniPDBErrorCallback2(pvContext, pfn);
        }

        #endregion
        #region SetPfnMiniPDBNHBuildStatusCallback

        public void SetPfnMiniPDBNHBuildStatusCallback(IntPtr _a, setPfnMiniPDBNHBuildStatusCallbackUnknownDelegate _b)
        {
            TrySetPfnMiniPDBNHBuildStatusCallback(_a, _b).ThrowOnNotOK();
        }

        public HRESULT TrySetPfnMiniPDBNHBuildStatusCallback(IntPtr _a, setPfnMiniPDBNHBuildStatusCallbackUnknownDelegate _b)
        {
            /*HRESULT setPfnMiniPDBNHBuildStatusCallback(
            [In] IntPtr _a,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] setPfnMiniPDBNHBuildStatusCallbackUnknownDelegate _b);*/
            return Raw10.setPfnMiniPDBNHBuildStatusCallback(_a, _b);
        }

        #endregion
        #region LoadDataFromPdbEx2

        public void LoadDataFromPdbEx2(string pdbPath, bool fPdbPrefetching, bool _rdMode)
        {
            TryLoadDataFromPdbEx2(pdbPath, fPdbPrefetching, _rdMode).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataFromPdbEx2(string pdbPath, bool fPdbPrefetching, bool _rdMode)
        {
            /*HRESULT loadDataFromPdbEx2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);*/
            return Raw10.loadDataFromPdbEx2(pdbPath, fPdbPrefetching, _rdMode);
        }

        #endregion
        #region LoadAndValidateDataFromPdbEx2

        public void LoadAndValidateDataFromPdbEx2(string pdbPath, Guid pcsig70, int sig, int age, bool fPdbPrefetching, bool _rdMode)
        {
            TryLoadAndValidateDataFromPdbEx2(pdbPath, pcsig70, sig, age, fPdbPrefetching, _rdMode).ThrowOnNotOK();
        }

        public HRESULT TryLoadAndValidateDataFromPdbEx2(string pdbPath, Guid pcsig70, int sig, int age, bool fPdbPrefetching, bool _rdMode)
        {
            /*HRESULT loadAndValidateDataFromPdbEx2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pdbPath,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pcsig70,
            [In] int sig, //The symbols say its a ulong, but they say the same thing about loadAndValidateDataFromPdb.sig
            [In] int age, //Same as above
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);*/
            return Raw10.loadAndValidateDataFromPdbEx2(pdbPath, pcsig70, sig, age, fPdbPrefetching, _rdMode);
        }

        #endregion
        #region LoadDataForExeEx2

        public void LoadDataForExeEx2(string executable, string searchPath, object pCallback, bool fPdbPrefetching, bool _rdMode)
        {
            TryLoadDataForExeEx2(executable, searchPath, pCallback, fPdbPrefetching, _rdMode).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataForExeEx2(string executable, string searchPath, object pCallback, bool fPdbPrefetching, bool _rdMode)
        {
            /*HRESULT loadDataForExeEx2(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);*/
            return Raw10.loadDataForExeEx2(executable, searchPath, pCallback, fPdbPrefetching, _rdMode);
        }

        #endregion
        #region LoadDataFromIStreamEx2

        public void LoadDataFromIStreamEx2(IStream pIStream, bool fPdbPrefetching, bool _rdMode)
        {
            TryLoadDataFromIStreamEx2(pIStream, fPdbPrefetching, _rdMode).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataFromIStreamEx2(IStream pIStream, bool fPdbPrefetching, bool _rdMode)
        {
            /*HRESULT loadDataFromIStreamEx2(
            [In, MarshalAs(UnmanagedType.Interface)] IStream pIStream,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);*/
            return Raw10.loadDataFromIStreamEx2(pIStream, fPdbPrefetching, _rdMode);
        }

        #endregion
        #region LoadDataFromCodeViewInfoEx

        public void LoadDataFromCodeViewInfoEx(string executable, string searchPath, int cbCvInfo, byte[] pbCvInfo, object pCallback, bool _rdMode)
        {
            TryLoadDataFromCodeViewInfoEx(executable, searchPath, cbCvInfo, pbCvInfo, pCallback, _rdMode).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataFromCodeViewInfoEx(string executable, string searchPath, int cbCvInfo, byte[] pbCvInfo, object pCallback, bool _rdMode)
        {
            /*HRESULT loadDataFromCodeViewInfoEx(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] int cbCvInfo, //The symbols say its a ulong, but they say the same thing about loadDataFromCodeViewInfo.cbCvInfo too
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbCvInfo,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode);*/
            return Raw10.loadDataFromCodeViewInfoEx(executable, searchPath, cbCvInfo, pbCvInfo, pCallback, _rdMode);
        }

        #endregion
        #region VSDebuggerPreloadPDBDone

        public void VSDebuggerPreloadPDBDone()
        {
            TryVSDebuggerPreloadPDBDone().ThrowOnNotOK();
        }

        public HRESULT TryVSDebuggerPreloadPDBDone()
        {
            /*HRESULT VSDebuggerPreloadPDBDone();*/
            return Raw10.VSDebuggerPreloadPDBDone();
        }

        #endregion
        #region LoadDataForExeEx3

        public void LoadDataForExeEx3(string executable, string searchPath, object pCallback, bool fPdbPrefetching, bool _rdMode, bool _searchInBinaryDirectoryOnly)
        {
            TryLoadDataForExeEx3(executable, searchPath, pCallback, fPdbPrefetching, _rdMode, _searchInBinaryDirectoryOnly).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataForExeEx3(string executable, string searchPath, object pCallback, bool fPdbPrefetching, bool _rdMode, bool _searchInBinaryDirectoryOnly)
        {
            /*HRESULT loadDataForExeEx3(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.Bool)] bool fPdbPrefetching,
            [In, MarshalAs(UnmanagedType.Bool)] bool _rdMode,
            [In, MarshalAs(UnmanagedType.Bool)] bool _searchInBinaryDirectoryOnly);*/
            return Raw10.loadDataForExeEx3(executable, searchPath, pCallback, fPdbPrefetching, _rdMode, _searchInBinaryDirectoryOnly);
        }

        #endregion
        #region UsePdb

        public void UsePdb(IntPtr _ppdb)
        {
            TryUsePdb(_ppdb).ThrowOnNotOK();
        }

        public HRESULT TryUsePdb(IntPtr _ppdb)
        {
            /*HRESULT usePdb(
            [In] IntPtr _ppdb);*/
            return Raw10.usePdb(_ppdb);
        }

        #endregion
        #region LoadDataFromCodeViewInfoHelper

        public void LoadDataFromCodeViewInfoHelper(string executable, string searchPath, int cbCvInfo, byte[] pbCvInfo, object pCallback, string _pdbOpenMode)
        {
            TryLoadDataFromCodeViewInfoHelper(executable, searchPath, cbCvInfo, pbCvInfo, pCallback, _pdbOpenMode).ThrowOnNotOK();
        }

        public HRESULT TryLoadDataFromCodeViewInfoHelper(string executable, string searchPath, int cbCvInfo, byte[] pbCvInfo, object pCallback, string _pdbOpenMode)
        {
            /*HRESULT loadDataFromCodeViewInfoHelper(
            [In, MarshalAs(UnmanagedType.LPWStr)] string executable,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [In] int cbCvInfo, //The symbols say its a ulong, but they say the same thing about loadDataFromCodeViewInfo.cbCvInfo too
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbCvInfo,
            [In, MarshalAs(UnmanagedType.Interface)] object pCallback,
            [In, MarshalAs(UnmanagedType.LPStr)] string _pdbOpenMode);*/
            return Raw10.loadDataFromCodeViewInfoHelper(executable, searchPath, cbCvInfo, pbCvInfo, pCallback, _pdbOpenMode);
        }

        #endregion
        #endregion
    }
}

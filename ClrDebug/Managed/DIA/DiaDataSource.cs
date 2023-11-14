using System;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Initiates access to a source of debugging symbols.
    /// </summary>
    /// <remarks>
    /// A call to one of the load methods of the IDiaDataSource interface opens the symbol source. A successful call to
    /// the IDiaDataSource method returns an IDiaSession interface that supports querying the data source. If the load
    /// method returns a file-related error then the IDiaDataSource method return value contains the file name associated
    /// with the error. This interface is obtained by calling the CoCreateInstance function with the class identifier CLSID_DiaSource
    /// and the interface ID of IID_IDiaDataSource. The example shows how this interface is obtained.
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
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);*/
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
        /// use the IDiaDataSource method. To gain access to the data load process (through a callback mechanism), use the
        /// IDiaDataSource method. To load a .pdb file directly from memory, use the IDiaDataSource method.
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
        /// use the IDiaDataSource method. To gain access to the data load process (through a callback mechanism), use the
        /// IDiaDataSource method. To load a .pdb file directly from memory, use the IDiaDataSource method.
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
        /// age match the values provided. To load a .pdb file without validation, use the IDiaDataSource method. To gain access
        /// to the data load process (through a callback mechanism), use the IDiaDataSource method. To load a .pdb file directly
        /// from memory, use the IDiaDataSource method.
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
        /// age match the values provided. To load a .pdb file without validation, use the IDiaDataSource method. To gain access
        /// to the data load process (through a callback mechanism), use the IDiaDataSource method. To load a .pdb file directly
        /// from memory, use the IDiaDataSource method.
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
        /// <param name="pCallback">[in] An IUnknown interface for an object that supports a debug callback interface, such as the IDiaLoadCallback, IDiaLoadCallback2, the IDiaReadExeAtOffsetCallback, and/or the IDiaReadExeAtRVACallback interfaces.</param>
        /// <remarks>
        /// The debug header of the .exe/.dll file names the associated debug data location. If you are loading debug data
        /// from a symbol server, symsrv.dll must be present in the same directory where either the user’s application or msdia140.dll
        /// is installed, or it must be present in the system directory. This method reads the debug header and then searches
        /// for and prepares the debug data. The progress of the search may, optionally, be reported and controlled through
        /// callbacks. For example, the IDiaLoadCallback is invoked when the IDiaDataSource::loadDataForExe method finds and
        /// processes a debug directory. The IDiaReadExeAtOffsetCallback and IDiaReadExeAtRVACallback interfaces allow the
        /// client application to provide alternative methods for reading data from the executable file when the file cannot
        /// be accessed directly through standard file I/O. To load a .pdb file without validation, use the IDiaDataSource
        /// method. To validate the .pdb file against specific criteria, use the IDiaDataSource method. To load a .pdb file
        /// directly from memory, use the IDiaDataSource method.
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
        /// <param name="pCallback">[in] An IUnknown interface for an object that supports a debug callback interface, such as the IDiaLoadCallback, IDiaLoadCallback2, the IDiaReadExeAtOffsetCallback, and/or the IDiaReadExeAtRVACallback interfaces.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows some of the possible error codes for this method.</returns>
        /// <remarks>
        /// The debug header of the .exe/.dll file names the associated debug data location. If you are loading debug data
        /// from a symbol server, symsrv.dll must be present in the same directory where either the user’s application or msdia140.dll
        /// is installed, or it must be present in the system directory. This method reads the debug header and then searches
        /// for and prepares the debug data. The progress of the search may, optionally, be reported and controlled through
        /// callbacks. For example, the IDiaLoadCallback is invoked when the IDiaDataSource::loadDataForExe method finds and
        /// processes a debug directory. The IDiaReadExeAtOffsetCallback and IDiaReadExeAtRVACallback interfaces allow the
        /// client application to provide alternative methods for reading data from the executable file when the file cannot
        /// be accessed directly through standard file I/O. To load a .pdb file without validation, use the IDiaDataSource
        /// method. To validate the .pdb file against specific criteria, use the IDiaDataSource method. To load a .pdb file
        /// directly from memory, use the IDiaDataSource method.
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
        /// a .pdb file without validation, use the IDiaDataSource method. To validate the .pdb file against specific criteria,
        /// use the IDiaDataSource method. To gain access to the data load process (through a callback mechanism), use the
        /// IDiaDataSource method.
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
        /// a .pdb file without validation, use the IDiaDataSource method. To validate the .pdb file against specific criteria,
        /// use the IDiaDataSource method. To gain access to the data load process (through a callback mechanism), use the
        /// IDiaDataSource method.
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
        /// <returns>[out] Returns an IDiaSession object representing the open session.</returns>
        /// <remarks>
        /// This method opens an IDiaSession object for a data source. IDiaSession objects implement queries into the data
        /// source. A session manages one address space for each set of debug symbols. If the .exe or .dll file described by
        /// the data source symbols is active in multiple address ranges (for example, because multiple processes have it loaded),
        /// then one session for each address range should be used.
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
        /// <param name="ppSessionResult">[out] Returns an IDiaSession object representing the open session.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. The following table shows the possible return values for this method.</returns>
        /// <remarks>
        /// This method opens an IDiaSession object for a data source. IDiaSession objects implement queries into the data
        /// source. A session manages one address space for each set of debug symbols. If the .exe or .dll file described by
        /// the data source symbols is active in multiple address ranges (for example, because multiple processes have it loaded),
        /// then one session for each address range should be used.
        /// </remarks>
        public HRESULT TryOpenSession(out DiaSession ppSessionResult)
        {
            /*HRESULT openSession(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSession ppSession);*/
            IDiaSession ppSession;
            HRESULT hr = Raw.openSession(out ppSession);

            if (hr == HRESULT.S_OK)
                ppSessionResult = new DiaSession(ppSession);
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
    }
}

using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An (<see cref="IDebugHostSymbol"/> derived) interface to a particular module.
    /// </summary>
    public class DebugHostModule : DebugHostSymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostModule"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostModule(IDebugHostModule raw) : base(raw)
        {
        }

        #region IDebugHostModule

        public new IDebugHostModule Raw => (IDebugHostModule) base.Raw;

        #region BaseLocation

        /// <summary>
        /// The GetBaseLocation method returns the base load address of the module as a location structure. The returned location structure for a module will typically refer to a virtual address.
        /// </summary>
        public Location BaseLocation
        {
            get
            {
                Location moduleBaseLocation;
                TryGetBaseLocation(out moduleBaseLocation).ThrowDbgEngNotOK();

                return moduleBaseLocation;
            }
        }

        /// <summary>
        /// The GetBaseLocation method returns the base load address of the module as a location structure. The returned location structure for a module will typically refer to a virtual address.
        /// </summary>
        /// <param name="moduleBaseLocation">The loading address of the base of the module in memory is returned here as a location structure. Typically, this refers to a virtual address.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetBaseLocation(out Location moduleBaseLocation)
        {
            /*HRESULT GetBaseLocation(
            [Out] out Location moduleBaseLocation);*/
            return Raw.GetBaseLocation(out moduleBaseLocation);
        }

        #endregion
        #region Version

        /// <summary>
        /// The GetVersion method returns version information about the module (assuming that such information can successfully be read out of the headers).<para/>
        /// If a given version is requested (via a non-nullptr output pointer) and it cannot be read, an appropriate error code will be returned from the method call.
        /// </summary>
        public GetVersionResult Version
        {
            get
            {
                GetVersionResult result;
                TryGetVersion(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetVersion method returns version information about the module (assuming that such information can successfully be read out of the headers).<para/>
        /// If a given version is requested (via a non-nullptr output pointer) and it cannot be read, an appropriate error code will be returned from the method call.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetVersion(out GetVersionResult result)
        {
            /*HRESULT GetVersion(
            [Out] out long fileVersion,
            [Out] out long productVersion);*/
            long fileVersion;
            long productVersion;
            HRESULT hr = Raw.GetVersion(out fileVersion, out productVersion);

            if (hr == HRESULT.S_OK)
                result = new GetVersionResult(fileVersion, productVersion);
            else
                result = default(GetVersionResult);

            return hr;
        }

        #endregion
        #region GetImageName

        /// <summary>
        /// The GetImageName method returns the image name of the module. Depending on the value of the allowPath argument, the returned image name may or may not include the full path to the image.
        /// </summary>
        /// <param name="allowPath">If true, indicates that the full path to the module may be included in the output. Whether such path is or is not included is up to the specific debug host and the manner in which the module was loaded.<para/>
        /// If false, indicates that only the image name of the module will be included in the output.</param>
        /// <returns>The image name (or full path) of the module will be returned here as an allocated string. The caller is responsible for calling SysFreeString to free the string after use.</returns>
        public string GetImageName(bool allowPath)
        {
            string imageName;
            TryGetImageName(allowPath, out imageName).ThrowDbgEngNotOK();

            return imageName;
        }

        /// <summary>
        /// The GetImageName method returns the image name of the module. Depending on the value of the allowPath argument, the returned image name may or may not include the full path to the image.
        /// </summary>
        /// <param name="allowPath">If true, indicates that the full path to the module may be included in the output. Whether such path is or is not included is up to the specific debug host and the manner in which the module was loaded.<para/>
        /// If false, indicates that only the image name of the module will be included in the output.</param>
        /// <param name="imageName">The image name (or full path) of the module will be returned here as an allocated string. The caller is responsible for calling SysFreeString to free the string after use.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetImageName(bool allowPath, out string imageName)
        {
            /*HRESULT GetImageName(
            [In, MarshalAs(UnmanagedType.U1)] bool allowPath,
            [Out, MarshalAs(UnmanagedType.BStr)] out string imageName);*/
            return Raw.GetImageName(allowPath, out imageName);
        }

        #endregion
        #region FindTypeByName

        /// <summary>
        /// The FindTypeByName method finds a type defined within the module by the type name and returns a type symbol for it.<para/>
        /// This method may return a valid <see cref="IDebugHostType"/> which would never be returned via explicit recursion of children of the module.<para/>
        /// The debug host may allow creation of derivative types -- types not ever used within the module itself but derived from types that are.<para/>
        /// As an example, if the structure MyStruct is defined in the symbols of the module but the type MyStruct ** is never used, the FindTypeByName method may legitimately return a type symbol for MyStruct ** despite that type name never explicitly appearing in the symbols for the module.<para/>
        /// Many debug hosts will make an explicit attempt to contextualize the type name which is passed to the FindTypeByName method and find a matching type within the symbolic information according to the rules of the language and not a raw comparison against symbol names.<para/>
        /// In the event that a debug host is unable to do this, it will fall back to raw comparison against symbol names.
        /// </summary>
        /// <param name="typeName">The language type to find in the symbolic information for the module. The type may also be derived from (e.g.: be a pointer to or an array of) a type found in the symbolic information of the module.</param>
        /// <returns>A type symbol for the found type will be returned here.</returns>
        public DebugHostType FindTypeByName(string typeName)
        {
            DebugHostType typeResult;
            TryFindTypeByName(typeName, out typeResult).ThrowDbgEngNotOK();

            return typeResult;
        }

        /// <summary>
        /// The FindTypeByName method finds a type defined within the module by the type name and returns a type symbol for it.<para/>
        /// This method may return a valid <see cref="IDebugHostType"/> which would never be returned via explicit recursion of children of the module.<para/>
        /// The debug host may allow creation of derivative types -- types not ever used within the module itself but derived from types that are.<para/>
        /// As an example, if the structure MyStruct is defined in the symbols of the module but the type MyStruct ** is never used, the FindTypeByName method may legitimately return a type symbol for MyStruct ** despite that type name never explicitly appearing in the symbols for the module.<para/>
        /// Many debug hosts will make an explicit attempt to contextualize the type name which is passed to the FindTypeByName method and find a matching type within the symbolic information according to the rules of the language and not a raw comparison against symbol names.<para/>
        /// In the event that a debug host is unable to do this, it will fall back to raw comparison against symbol names.
        /// </summary>
        /// <param name="typeName">The language type to find in the symbolic information for the module. The type may also be derived from (e.g.: be a pointer to or an array of) a type found in the symbolic information of the module.</param>
        /// <param name="typeResult">A type symbol for the found type will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryFindTypeByName(string typeName, out DebugHostType typeResult)
        {
            /*HRESULT FindTypeByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string typeName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);*/
            IDebugHostType type;
            HRESULT hr = Raw.FindTypeByName(typeName, out type);

            if (hr == HRESULT.S_OK)
                typeResult = type == null ? null : new DebugHostType(type);
            else
                typeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #region FindSymbolByRVA

        /// <summary>
        /// The FindSymbolByRVA method will find a single matching symbol at the given relative virtual address within the module.<para/>
        /// If there is not a single symbol at the supplied RVA (e.g.: there are multiple matches), an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="rva">The relative virtual address (offset) within the module for which to locate a matching symbol in the symbolic information for the module.</param>
        /// <returns>The found symbol will be returned here.</returns>
        public DebugHostSymbol FindSymbolByRVA(long rva)
        {
            DebugHostSymbol symbolResult;
            TryFindSymbolByRVA(rva, out symbolResult).ThrowDbgEngNotOK();

            return symbolResult;
        }

        /// <summary>
        /// The FindSymbolByRVA method will find a single matching symbol at the given relative virtual address within the module.<para/>
        /// If there is not a single symbol at the supplied RVA (e.g.: there are multiple matches), an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="rva">The relative virtual address (offset) within the module for which to locate a matching symbol in the symbolic information for the module.</param>
        /// <param name="symbolResult">The found symbol will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryFindSymbolByRVA(long rva, out DebugHostSymbol symbolResult)
        {
            /*HRESULT FindSymbolByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);*/
            IDebugHostSymbol symbol;
            HRESULT hr = Raw.FindSymbolByRVA(rva, out symbol);

            if (hr == HRESULT.S_OK)
                symbolResult = DebugHostSymbol.New(symbol);
            else
                symbolResult = default(DebugHostSymbol);

            return hr;
        }

        #endregion
        #region FindSymbolByName

        /// <summary>
        /// The FindSymbolByName method will find a single global symbol of the given name within the module. If there is not a single symbol matching the given name, an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="symbolName">The name of the symbol to locate within the symbolic information for the module.</param>
        /// <returns>The found symbol will be returned here.</returns>
        public DebugHostSymbol FindSymbolByName(string symbolName)
        {
            DebugHostSymbol symbolResult;
            TryFindSymbolByName(symbolName, out symbolResult).ThrowDbgEngNotOK();

            return symbolResult;
        }

        /// <summary>
        /// The FindSymbolByName method will find a single global symbol of the given name within the module. If there is not a single symbol matching the given name, an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="symbolName">The name of the symbol to locate within the symbolic information for the module.</param>
        /// <param name="symbolResult">The found symbol will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryFindSymbolByName(string symbolName, out DebugHostSymbol symbolResult)
        {
            /*HRESULT FindSymbolByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string symbolName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);*/
            IDebugHostSymbol symbol;
            HRESULT hr = Raw.FindSymbolByName(symbolName, out symbol);

            if (hr == HRESULT.S_OK)
                symbolResult = DebugHostSymbol.New(symbol);
            else
                symbolResult = default(DebugHostSymbol);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostModule2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new IDebugHostModule2 Raw2 => (IDebugHostModule2) Raw;

        #region FindContainingSymbolByRVA

        /// <summary>
        /// The FindSymbolByRVA method will find a single matching symbol at the given relative virtual address within the module.<para/>
        /// If there is not a single symbol at the supplied RVA (e.g.: there are multiple matches), an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="rva">The relative virtual address (offset) within the module for which to locate a matching symbol in the symbolic information for the module.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public FindContainingSymbolByRVAResult FindContainingSymbolByRVA(long rva)
        {
            FindContainingSymbolByRVAResult result;
            TryFindContainingSymbolByRVA(rva, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The FindSymbolByRVA method will find a single matching symbol at the given relative virtual address within the module.<para/>
        /// If there is not a single symbol at the supplied RVA (e.g.: there are multiple matches), an error will be returned by this method.<para/>
        /// Note that this method will prefer returning a private symbol over a symbol in the publics table.
        /// </summary>
        /// <param name="rva">The relative virtual address (offset) within the module for which to locate a matching symbol in the symbolic information for the module.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryFindContainingSymbolByRVA(long rva, out FindContainingSymbolByRVAResult result)
        {
            /*HRESULT FindContainingSymbolByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol,
            [Out] out long offset);*/
            IDebugHostSymbol symbol;
            long offset;
            HRESULT hr = Raw2.FindContainingSymbolByRVA(rva, out symbol, out offset);

            if (hr == HRESULT.S_OK)
                result = new FindContainingSymbolByRVAResult(DebugHostSymbol.New(symbol), offset);
            else
                result = default(FindContainingSymbolByRVAResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostModule3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new IDebugHostModule3 Raw3 => (IDebugHostModule3) Raw;

        #region Range

        public GetRangeResult Range
        {
            get
            {
                GetRangeResult result;
                TryGetRange(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetRange(out GetRangeResult result)
        {
            /*HRESULT GetRange(
            [Out] out Location moduleStart,
            [Out] out Location moduleEnd);*/
            Location moduleStart;
            Location moduleEnd;
            HRESULT hr = Raw3.GetRange(out moduleStart, out moduleEnd);

            if (hr == HRESULT.S_OK)
                result = new GetRangeResult(moduleStart, moduleEnd);
            else
                result = default(GetRangeResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostModule4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostModule4 Raw4 => (IDebugHostModule4) Raw;

        #region FindTypeByName2

        public DebugHostType FindTypeByName2(IDebugHostSymbol pEnclosingSymbol, string typeName)
        {
            DebugHostType typeResult;
            TryFindTypeByName2(pEnclosingSymbol, typeName, out typeResult).ThrowDbgEngNotOK();

            return typeResult;
        }

        public HRESULT TryFindTypeByName2(IDebugHostSymbol pEnclosingSymbol, string typeName, out DebugHostType typeResult)
        {
            /*HRESULT FindTypeByName2(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostSymbol pEnclosingSymbol,
            [In, MarshalAs(UnmanagedType.LPWStr)] string typeName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType type);*/
            IDebugHostType type;
            HRESULT hr = Raw4.FindTypeByName2(pEnclosingSymbol, typeName, out type);

            if (hr == HRESULT.S_OK)
                typeResult = type == null ? null : new DebugHostType(type);
            else
                typeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostModule5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostModule5 Raw5 => (IDebugHostModule5) Raw;

        #region PrimaryCompilerInformation

        public GetPrimaryCompilerInformationResult PrimaryCompilerInformation
        {
            get
            {
                GetPrimaryCompilerInformationResult result;
                TryGetPrimaryCompilerInformation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetPrimaryCompilerInformation(out GetPrimaryCompilerInformationResult result)
        {
            /*HRESULT GetPrimaryCompilerInformation(
            [Out] out KnownCompiler pCompilerId,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pPrimaryCompilerString);*/
            KnownCompiler pCompilerId;
            string pPrimaryCompilerString;
            HRESULT hr = Raw5.GetPrimaryCompilerInformation(out pCompilerId, out pPrimaryCompilerString);

            if (hr == HRESULT.S_OK)
                result = new GetPrimaryCompilerInformationResult(pCompilerId, pPrimaryCompilerString);
            else
                result = default(GetPrimaryCompilerInformationResult);

            return hr;
        }

        #endregion
        #endregion
    }
}

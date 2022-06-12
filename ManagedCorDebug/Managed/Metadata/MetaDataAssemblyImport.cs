using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to access and examine the contents of an assembly manifest.
    /// </summary>
    public class MetaDataAssemblyImport : ComObject<IMetaDataAssemblyImport>
    {
        public MetaDataAssemblyImport(IMetaDataAssemblyImport raw) : base(raw)
        {
        }

        #region IMetaDataAssemblyImport
        #region GetAssemblyFromScope

        /// <summary>
        /// Gets a pointer to the assembly in the current scope.
        /// </summary>
        public mdAssembly AssemblyFromScope
        {
            get
            {
                HRESULT hr;
                mdAssembly ptkAssembly;

                if ((hr = TryGetAssemblyFromScope(out ptkAssembly)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ptkAssembly;
            }
        }

        /// <summary>
        /// Gets a pointer to the assembly in the current scope.
        /// </summary>
        /// <param name="ptkAssembly">[out] A pointer to the retrieved <see cref="mdAssembly"/> token that identifies the assembly.</param>
        public HRESULT TryGetAssemblyFromScope(out mdAssembly ptkAssembly)
        {
            /*HRESULT GetAssemblyFromScope(
            [Out] out mdAssembly ptkAssembly);*/
            return Raw.GetAssemblyFromScope(out ptkAssembly);
        }

        #endregion
        #region GetAssemblyProps

        /// <summary>
        /// Gets the set of properties for the assembly with the specified metadata signature.
        /// </summary>
        /// <param name="mda">[in]. The <see cref="mdAssembly"/> metadata token that represents the assembly for which to get the properties.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetAssemblyPropsResult GetAssemblyProps(mdAssembly mda)
        {
            HRESULT hr;
            GetAssemblyPropsResult result;

            if ((hr = TryGetAssemblyProps(mda, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the set of properties for the assembly with the specified metadata signature.
        /// </summary>
        /// <param name="mda">[in]. The <see cref="mdAssembly"/> metadata token that represents the assembly for which to get the properties.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetAssemblyProps(mdAssembly mda, out GetAssemblyPropsResult result)
        {
            /*HRESULT GetAssemblyProps(
            [In] mdAssembly mda,
            [Out] out IntPtr ppbPublicKey,
            [Out] out int pcbPublicKey,
            [Out] out int pulHashAlgId,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out ASSEMBLYMETADATA pMetaData,
            [Out] out CorAssemblyFlags pdwAssemblyFlags);*/
            IntPtr ppbPublicKey;
            int pcbPublicKey;
            int pulHashAlgId;
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            ASSEMBLYMETADATA pMetaData;
            CorAssemblyFlags pdwAssemblyFlags;
            HRESULT hr = Raw.GetAssemblyProps(mda, out ppbPublicKey, out pcbPublicKey, out pulHashAlgId, szName, cchName, out pchName, out pMetaData, out pdwAssemblyFlags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetAssemblyProps(mda, out ppbPublicKey, out pcbPublicKey, out pulHashAlgId, szName, cchName, out pchName, out pMetaData, out pdwAssemblyFlags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetAssemblyPropsResult(ppbPublicKey, pcbPublicKey, pulHashAlgId, szName.ToString(), pMetaData, pdwAssemblyFlags);

                return hr;
            }

            fail:
            result = default(GetAssemblyPropsResult);

            return hr;
        }

        #endregion
        #region GetAssemblyRefProps

        /// <summary>
        /// Gets the set of properties for the assembly reference with the specified metadata signature.
        /// </summary>
        /// <param name="mdar">[in] The <see cref="mdAssemblyRef"/> metadata token that represents the assembly reference for which to get the properties.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetAssemblyRefPropsResult GetAssemblyRefProps(mdAssemblyRef mdar)
        {
            HRESULT hr;
            GetAssemblyRefPropsResult result;

            if ((hr = TryGetAssemblyRefProps(mdar, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the set of properties for the assembly reference with the specified metadata signature.
        /// </summary>
        /// <param name="mdar">[in] The <see cref="mdAssemblyRef"/> metadata token that represents the assembly reference for which to get the properties.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns S_OK if it succeeds; otherwise, it returns one of the error codes defined in the Winerror.h header file.</returns>
        public HRESULT TryGetAssemblyRefProps(mdAssemblyRef mdar, out GetAssemblyRefPropsResult result)
        {
            /*HRESULT GetAssemblyRefProps(
            [In] mdAssemblyRef mdar,
            [Out] IntPtr ppbPublicKeyOrToken,
            [Out] out int pcbPublicKeyOrToken,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out ASSEMBLYMETADATA pMetaData,
            [Out] IntPtr ppbHashValue,
            [Out] out int pcbHashValue,
            [Out] out CorAssemblyFlags pdwAssemblyFlags);*/
            IntPtr ppbPublicKeyOrToken = default(IntPtr);
            int pcbPublicKeyOrToken;
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            ASSEMBLYMETADATA pMetaData;
            IntPtr ppbHashValue = default(IntPtr);
            int pcbHashValue;
            CorAssemblyFlags pdwAssemblyFlags;
            HRESULT hr = Raw.GetAssemblyRefProps(mdar, ppbPublicKeyOrToken, out pcbPublicKeyOrToken, szName, cchName, out pchName, out pMetaData, ppbHashValue, out pcbHashValue, out pdwAssemblyFlags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetAssemblyRefProps(mdar, ppbPublicKeyOrToken, out pcbPublicKeyOrToken, szName, cchName, out pchName, out pMetaData, ppbHashValue, out pcbHashValue, out pdwAssemblyFlags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetAssemblyRefPropsResult(ppbPublicKeyOrToken, pcbPublicKeyOrToken, szName.ToString(), pMetaData, ppbHashValue, pcbHashValue, pdwAssemblyFlags);

                return hr;
            }

            fail:
            result = default(GetAssemblyRefPropsResult);

            return hr;
        }

        #endregion
        #region GetFileProps

        /// <summary>
        /// Gets the properties of the file with the specified metadata signature.
        /// </summary>
        /// <param name="mdf">[in] The <see cref="mdFile"/> metadata token that represents the file for which to get the properties.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetFilePropsResult GetFileProps(mdFile mdf)
        {
            HRESULT hr;
            GetFilePropsResult result;

            if ((hr = TryGetFileProps(mdf, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the properties of the file with the specified metadata signature.
        /// </summary>
        /// <param name="mdf">[in] The <see cref="mdFile"/> metadata token that represents the file for which to get the properties.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetFileProps(mdFile mdf, out GetFilePropsResult result)
        {
            /*HRESULT GetFileProps(
            [In] mdFile mdf,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] IntPtr ppbHashValue,
            [Out] out int pcbHashValue,
            [Out] out CorFileFlags pdwFileFlags);*/
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            IntPtr ppbHashValue = default(IntPtr);
            int pcbHashValue;
            CorFileFlags pdwFileFlags;
            HRESULT hr = Raw.GetFileProps(mdf, szName, cchName, out pchName, ppbHashValue, out pcbHashValue, out pdwFileFlags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetFileProps(mdf, szName, cchName, out pchName, ppbHashValue, out pcbHashValue, out pdwFileFlags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFilePropsResult(szName.ToString(), ppbHashValue, pcbHashValue, pdwFileFlags);

                return hr;
            }

            fail:
            result = default(GetFilePropsResult);

            return hr;
        }

        #endregion
        #region GetExportedTypeProps

        /// <summary>
        /// Gets the set of properties of the exported type with the specified metadata signature.
        /// </summary>
        /// <param name="mdct">[in] An <see cref="mdExportedType"/> metadata token that represents the exported type.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetExportedTypePropsResult GetExportedTypeProps(mdExportedType mdct)
        {
            HRESULT hr;
            GetExportedTypePropsResult result;

            if ((hr = TryGetExportedTypeProps(mdct, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the set of properties of the exported type with the specified metadata signature.
        /// </summary>
        /// <param name="mdct">[in] An <see cref="mdExportedType"/> metadata token that represents the exported type.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetExportedTypeProps(mdExportedType mdct, out GetExportedTypePropsResult result)
        {
            /*HRESULT GetExportedTypeProps(
            [In] mdExportedType mdct,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out int ptkImplementation,
            [Out] out mdTypeDef ptkTypeDef,
            [Out] out CorTypeAttr pdwExportedTypeFlags);*/
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            int ptkImplementation;
            mdTypeDef ptkTypeDef;
            CorTypeAttr pdwExportedTypeFlags;
            HRESULT hr = Raw.GetExportedTypeProps(mdct, szName, cchName, out pchName, out ptkImplementation, out ptkTypeDef, out pdwExportedTypeFlags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetExportedTypeProps(mdct, szName, cchName, out pchName, out ptkImplementation, out ptkTypeDef, out pdwExportedTypeFlags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetExportedTypePropsResult(szName.ToString(), ptkImplementation, ptkTypeDef, pdwExportedTypeFlags);

                return hr;
            }

            fail:
            result = default(GetExportedTypePropsResult);

            return hr;
        }

        #endregion
        #region GetManifestResourceProps

        /// <summary>
        /// Gets the set of properties of the manifest resource with the specified metadata signature.
        /// </summary>
        /// <param name="mdmr">[in] An <see cref="mdManifestResource"/> token that represents the resource for which to get the properties.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetManifestResourcePropsResult GetManifestResourceProps(mdManifestResource mdmr)
        {
            HRESULT hr;
            GetManifestResourcePropsResult result;

            if ((hr = TryGetManifestResourceProps(mdmr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the set of properties of the manifest resource with the specified metadata signature.
        /// </summary>
        /// <param name="mdmr">[in] An <see cref="mdManifestResource"/> token that represents the resource for which to get the properties.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetManifestResourceProps(mdManifestResource mdmr, out GetManifestResourcePropsResult result)
        {
            /*HRESULT GetManifestResourceProps(
            [In] mdManifestResource mdmr,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out int ptkImplementation,
            [Out] out int pdwOffset,
            [Out] out CorManifestResourceFlags pdwResourceFlags);*/
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            int ptkImplementation;
            int pdwOffset;
            CorManifestResourceFlags pdwResourceFlags;
            HRESULT hr = Raw.GetManifestResourceProps(mdmr, szName, cchName, out pchName, out ptkImplementation, out pdwOffset, out pdwResourceFlags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetManifestResourceProps(mdmr, szName, cchName, out pchName, out ptkImplementation, out pdwOffset, out pdwResourceFlags);

            if (hr == HRESULT.S_OK)
            {
                result = new GetManifestResourcePropsResult(szName.ToString(), ptkImplementation, pdwOffset, pdwResourceFlags);

                return hr;
            }

            fail:
            result = default(GetManifestResourcePropsResult);

            return hr;
        }

        #endregion
        #region EnumAssemblyRefs

        /// <summary>
        /// Enumerates the <see cref="mdAssemblyRef"/> instances that are defined in the assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumAssemblyRefs method is called for the first time.</param>
        /// <returns>[out] The enumeration of <see cref="mdAssemblyRef"/> metadata tokens.</returns>
        public mdAssemblyRef[] EnumAssemblyRefs(IntPtr phEnum)
        {
            HRESULT hr;
            mdAssemblyRef[] rAssemblyRefsResult;

            if ((hr = TryEnumAssemblyRefs(phEnum, out rAssemblyRefsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rAssemblyRefsResult;
        }

        /// <summary>
        /// Enumerates the <see cref="mdAssemblyRef"/> instances that are defined in the assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumAssemblyRefs method is called for the first time.</param>
        /// <param name="rAssemblyRefsResult">[out] The enumeration of <see cref="mdAssemblyRef"/> metadata tokens.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumAssemblyRefs returned successfully.                                  |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        public HRESULT TryEnumAssemblyRefs(IntPtr phEnum, out mdAssemblyRef[] rAssemblyRefsResult)
        {
            /*HRESULT EnumAssemblyRefs(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdAssemblyRef[] rAssemblyRefs,
            [In] int cMax,
            [Out] out int pcTokens);*/
            mdAssemblyRef[] rAssemblyRefs = null;
            int cMax = 0;
            int pcTokens;
            HRESULT hr = Raw.EnumAssemblyRefs(ref phEnum, rAssemblyRefs, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cMax = pcTokens;
            rAssemblyRefs = new mdAssemblyRef[pcTokens];
            hr = Raw.EnumAssemblyRefs(ref phEnum, rAssemblyRefs, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
            {
                rAssemblyRefsResult = rAssemblyRefs;

                return hr;
            }

            fail:
            rAssemblyRefsResult = default(mdAssemblyRef[]);

            return hr;
        }

        #endregion
        #region EnumFiles

        /// <summary>
        /// Enumerates the files referenced in the current assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value for the first call of this method.</param>
        /// <returns>[out] The array used to store the <see cref="mdFile"/> metadata tokens.</returns>
        public mdFile[] EnumFiles(IntPtr phEnum)
        {
            HRESULT hr;
            mdFile[] rFilesResult;

            if ((hr = TryEnumFiles(phEnum, out rFilesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rFilesResult;
        }

        /// <summary>
        /// Enumerates the files referenced in the current assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value for the first call of this method.</param>
        /// <param name="rFilesResult">[out] The array used to store the <see cref="mdFile"/> metadata tokens.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumFiles returned successfully.                                         |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        public HRESULT TryEnumFiles(IntPtr phEnum, out mdFile[] rFilesResult)
        {
            /*HRESULT EnumFiles(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdFile[] rFiles,
            [In] int cMax,
            [Out] out int pcTokens);*/
            mdFile[] rFiles = null;
            int cMax = 0;
            int pcTokens;
            HRESULT hr = Raw.EnumFiles(ref phEnum, rFiles, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cMax = pcTokens;
            rFiles = new mdFile[pcTokens];
            hr = Raw.EnumFiles(ref phEnum, rFiles, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
            {
                rFilesResult = rFiles;

                return hr;
            }

            fail:
            rFilesResult = default(mdFile[]);

            return hr;
        }

        #endregion
        #region EnumExportedTypes

        /// <summary>
        /// Enumerates the exported types referenced in the assembly manifest in the current metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumExportedTypes method is called for the first time.</param>
        /// <returns>[out] The enumeration of <see cref="mdExportedType"/> metadata tokens.</returns>
        public mdExportedType[] EnumExportedTypes(IntPtr phEnum)
        {
            HRESULT hr;
            mdExportedType[] rExportedTypesResult;

            if ((hr = TryEnumExportedTypes(phEnum, out rExportedTypesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rExportedTypesResult;
        }

        /// <summary>
        /// Enumerates the exported types referenced in the assembly manifest in the current metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumExportedTypes method is called for the first time.</param>
        /// <param name="rExportedTypesResult">[out] The enumeration of <see cref="mdExportedType"/> metadata tokens.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumExportedTypes returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        public HRESULT TryEnumExportedTypes(IntPtr phEnum, out mdExportedType[] rExportedTypesResult)
        {
            /*HRESULT EnumExportedTypes(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdExportedType[] rExportedTypes,
            [In] int cMax,
            [Out] out int pcTokens);*/
            mdExportedType[] rExportedTypes = null;
            int cMax = 0;
            int pcTokens;
            HRESULT hr = Raw.EnumExportedTypes(ref phEnum, rExportedTypes, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cMax = pcTokens;
            rExportedTypes = new mdExportedType[pcTokens];
            hr = Raw.EnumExportedTypes(ref phEnum, rExportedTypes, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
            {
                rExportedTypesResult = rExportedTypes;

                return hr;
            }

            fail:
            rExportedTypesResult = default(mdExportedType[]);

            return hr;
        }

        #endregion
        #region EnumManifestResources

        /// <summary>
        /// Gets a pointer to an enumerator for the resources referenced in the current assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumManifestResources method is called for the first time.</param>
        /// <returns>[out] The array used to store the <see cref="mdManifestResource"/> metadata tokens.</returns>
        public mdManifestResource[] EnumManifestResources(IntPtr phEnum)
        {
            HRESULT hr;
            mdManifestResource[] rManifestResourcesResult;

            if ((hr = TryEnumManifestResources(phEnum, out rManifestResourcesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rManifestResourcesResult;
        }

        /// <summary>
        /// Gets a pointer to an enumerator for the resources referenced in the current assembly manifest.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be a null value when the EnumManifestResources method is called for the first time.</param>
        /// <param name="rManifestResourcesResult">[out] The array used to store the <see cref="mdManifestResource"/> metadata tokens.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumManifestResources returned successfully.                             |
        /// | S_FALSE | There are no tokens to enumerate. In this case, pcTokens is set to zero. |
        /// </returns>
        public HRESULT TryEnumManifestResources(IntPtr phEnum, out mdManifestResource[] rManifestResourcesResult)
        {
            /*HRESULT EnumManifestResources(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdManifestResource[] rManifestResources,
            [In] int cMax,
            [Out] out int pcTokens);*/
            mdManifestResource[] rManifestResources = null;
            int cMax = 0;
            int pcTokens;
            HRESULT hr = Raw.EnumManifestResources(ref phEnum, rManifestResources, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cMax = pcTokens;
            rManifestResources = new mdManifestResource[pcTokens];
            hr = Raw.EnumManifestResources(ref phEnum, rManifestResources, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
            {
                rManifestResourcesResult = rManifestResources;

                return hr;
            }

            fail:
            rManifestResourcesResult = default(mdManifestResource[]);

            return hr;
        }

        #endregion
        #region FindExportedTypeByName

        /// <summary>
        /// Gets a pointer to an exported type, given its name and enclosing type.
        /// </summary>
        /// <param name="szName">[in] The name of the exported type.</param>
        /// <param name="mdtExportedType">[in] The metadata token for the enclosing class of the exported type. This value is mdExportedTypeNil if the requested exported type is not a nested type.</param>
        /// <returns>[out] A pointer to the <see cref="mdExportedType"/> token that represents the exported type.</returns>
        /// <remarks>
        /// The FindExportedTypeByName method uses the standard rules employed by the common language runtime for resolving
        /// references.
        /// </remarks>
        public mdExportedType FindExportedTypeByName(string szName, mdToken mdtExportedType)
        {
            HRESULT hr;
            mdExportedType mdExportedType;

            if ((hr = TryFindExportedTypeByName(szName, mdtExportedType, out mdExportedType)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return mdExportedType;
        }

        /// <summary>
        /// Gets a pointer to an exported type, given its name and enclosing type.
        /// </summary>
        /// <param name="szName">[in] The name of the exported type.</param>
        /// <param name="mdtExportedType">[in] The metadata token for the enclosing class of the exported type. This value is mdExportedTypeNil if the requested exported type is not a nested type.</param>
        /// <param name="mdExportedType">[out] A pointer to the <see cref="mdExportedType"/> token that represents the exported type.</param>
        /// <remarks>
        /// The FindExportedTypeByName method uses the standard rules employed by the common language runtime for resolving
        /// references.
        /// </remarks>
        public HRESULT TryFindExportedTypeByName(string szName, mdToken mdtExportedType, out mdExportedType mdExportedType)
        {
            /*HRESULT FindExportedTypeByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] mdToken mdtExportedType,
            [Out] out mdExportedType mdExportedType);*/
            return Raw.FindExportedTypeByName(szName, mdtExportedType, out mdExportedType);
        }

        #endregion
        #region FindManifestResourceByName

        /// <summary>
        /// Gets a pointer to the manifest resource with the specified name.
        /// </summary>
        /// <param name="szName">[in] The name of the resource.</param>
        /// <returns>[out] The array used to store the <see cref="mdManifestResource"/> metadata tokens, each of which represents a manifest resource.</returns>
        /// <remarks>
        /// The FindManifestResourceByName method uses the standard rules employed by the common language runtime for resolving
        /// references.
        /// </remarks>
        public mdManifestResource[] FindManifestResourceByName(string szName)
        {
            HRESULT hr;
            mdManifestResource[] ptkManifestResource;

            if ((hr = TryFindManifestResourceByName(szName, out ptkManifestResource)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptkManifestResource;
        }

        /// <summary>
        /// Gets a pointer to the manifest resource with the specified name.
        /// </summary>
        /// <param name="szName">[in] The name of the resource.</param>
        /// <param name="ptkManifestResource">[out] The array used to store the <see cref="mdManifestResource"/> metadata tokens, each of which represents a manifest resource.</param>
        /// <remarks>
        /// The FindManifestResourceByName method uses the standard rules employed by the common language runtime for resolving
        /// references.
        /// </remarks>
        public HRESULT TryFindManifestResourceByName(string szName, out mdManifestResource[] ptkManifestResource)
        {
            /*HRESULT FindManifestResourceByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [Out] out mdManifestResource[] ptkManifestResource);*/
            return Raw.FindManifestResourceByName(szName, out ptkManifestResource);
        }

        #endregion
        #region CloseEnum

        /// <summary>
        /// Releases a reference to the specified enumeration instance.
        /// </summary>
        /// <param name="hEnum">[in] The enumeration instance to be closed.</param>
        public void CloseEnum(IntPtr hEnum)
        {
            HRESULT hr;

            if ((hr = TryCloseEnum(hEnum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Releases a reference to the specified enumeration instance.
        /// </summary>
        /// <param name="hEnum">[in] The enumeration instance to be closed.</param>
        public HRESULT TryCloseEnum(IntPtr hEnum)
        {
            /*HRESULT CloseEnum(
            [In] IntPtr hEnum);*/
            return Raw.CloseEnum(hEnum);
        }

        #endregion
        #region FindAssembliesByName

        /// <summary>
        /// Gets an array of assemblies with the specified szAssemblyName parameter, using the standard rules employed by the common language runtime (CLR) for resolving references.
        /// </summary>
        /// <param name="szAppBase">[in] The root directory in which to search for the given assembly. If this value is set to null, FindAssembliesByName will look only in the global assembly cache for the assembly.</param>
        /// <param name="szPrivateBin">[in] A list of semicolon-delimited subdirectories (for example, "bin;bin2"), under the root directory, in which to search for the assembly.<para/>
        /// These directories are probed in addition to those specified in the default probing rules.</param>
        /// <param name="szAssemblyName">[in] The name of the assembly to find. The format of this string is defined in the class reference page for <see cref="AssemblyName"/>.</param>
        /// <param name="cMax">[in] The maximum number of interface pointers to place in ppIUnk.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Given an assembly name, the FindAssembliesByName method finds the assembly by following the standard rules for
        /// resolving assembly references. (For more information, see How the Runtime Locates Assemblies.) FindAssembliesByName
        /// allows the caller to configure various aspects of the assembly resolver context, such as application base and private
        /// search path. The FindAssembliesByName method requires the CLR to be initialized in the process in order to invoke
        /// the assembly resolution logic. Therefore, you must call CoInitializeEE (passing COINITEE_DEFAULT) before calling
        /// FindAssembliesByName, and then follow with a call to CoUninitializeCor. FindAssembliesByName returns an <see cref="IMetaDataImport"/>
        /// pointer to the file containing the assembly manifest for the assembly name that is passed in. If the given assembly
        /// name is not fully specified (for example, if it does not include a version), multiple assemblies might be returned.
        /// FindAssembliesByName is commonly used by a compiler that attempts to find a referenced assembly at compile time.
        /// </remarks>
        public FindAssembliesByNameResult FindAssembliesByName(string szAppBase, string szPrivateBin, string szAssemblyName, int cMax)
        {
            HRESULT hr;
            FindAssembliesByNameResult result;

            if ((hr = TryFindAssembliesByName(szAppBase, szPrivateBin, szAssemblyName, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets an array of assemblies with the specified szAssemblyName parameter, using the standard rules employed by the common language runtime (CLR) for resolving references.
        /// </summary>
        /// <param name="szAppBase">[in] The root directory in which to search for the given assembly. If this value is set to null, FindAssembliesByName will look only in the global assembly cache for the assembly.</param>
        /// <param name="szPrivateBin">[in] A list of semicolon-delimited subdirectories (for example, "bin;bin2"), under the root directory, in which to search for the assembly.<para/>
        /// These directories are probed in addition to those specified in the default probing rules.</param>
        /// <param name="szAssemblyName">[in] The name of the assembly to find. The format of this string is defined in the class reference page for <see cref="AssemblyName"/>.</param>
        /// <param name="cMax">[in] The maximum number of interface pointers to place in ppIUnk.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                 |
        /// | ------- | ------------------------------------------- |
        /// | S_OK    | FindAssembliesByName returned successfully. |
        /// | S_FALSE | There are no assemblies.                    |
        /// </returns>
        /// <remarks>
        /// Given an assembly name, the FindAssembliesByName method finds the assembly by following the standard rules for
        /// resolving assembly references. (For more information, see How the Runtime Locates Assemblies.) FindAssembliesByName
        /// allows the caller to configure various aspects of the assembly resolver context, such as application base and private
        /// search path. The FindAssembliesByName method requires the CLR to be initialized in the process in order to invoke
        /// the assembly resolution logic. Therefore, you must call CoInitializeEE (passing COINITEE_DEFAULT) before calling
        /// FindAssembliesByName, and then follow with a call to CoUninitializeCor. FindAssembliesByName returns an <see cref="IMetaDataImport"/>
        /// pointer to the file containing the assembly manifest for the assembly name that is passed in. If the given assembly
        /// name is not fully specified (for example, if it does not include a version), multiple assemblies might be returned.
        /// FindAssembliesByName is commonly used by a compiler that attempts to find a referenced assembly at compile time.
        /// </remarks>
        public HRESULT TryFindAssembliesByName(string szAppBase, string szPrivateBin, string szAssemblyName, int cMax, out FindAssembliesByNameResult result)
        {
            /*HRESULT FindAssembliesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [Out, MarshalAs(UnmanagedType.Interface)] out object[] ppIUnk,
            [In] int cMax,
            [Out] out int pcAssemblies);*/
            object[] ppIUnk;
            int pcAssemblies;
            HRESULT hr = Raw.FindAssembliesByName(szAppBase, szPrivateBin, szAssemblyName, out ppIUnk, cMax, out pcAssemblies);

            if (hr == HRESULT.S_OK)
                result = new FindAssembliesByNameResult(ppIUnk, pcAssemblies);
            else
                result = default(FindAssembliesByNameResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class MetaDataAssemblyImport : ComObject<IMetaDataAssemblyImport>
    {
        public MetaDataAssemblyImport(IMetaDataAssemblyImport raw) : base(raw)
        {
        }

        #region IMetaDataAssemblyImport
        #region GetAssemblyFromScope

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

        public HRESULT TryGetAssemblyFromScope(out mdAssembly ptkAssembly)
        {
            /*HRESULT GetAssemblyFromScope(
            [Out] out mdAssembly ptkAssembly);*/
            return Raw.GetAssemblyFromScope(out ptkAssembly);
        }

        #endregion
        #region GetAssemblyProps

        public GetAssemblyPropsResult GetAssemblyProps(mdAssembly mda)
        {
            HRESULT hr;
            GetAssemblyPropsResult result;

            if ((hr = TryGetAssemblyProps(mda, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetAssemblyProps(mdAssembly mda, out GetAssemblyPropsResult result)
        {
            /*HRESULT GetAssemblyProps(
            [In] mdAssembly mda,
            [Out] out IntPtr ppbPublicKey,
            [Out] out uint pcbPublicKey,
            [Out] out uint pulHashAlgId,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] uint cchName,
            [Out] out uint pchName,
            [Out] out ASSEMBLYMETADATA pMetaData,
            [Out] out CorAssemblyFlags pdwAssemblyFlags);*/
            IntPtr ppbPublicKey;
            uint pcbPublicKey;
            uint pulHashAlgId;
            StringBuilder szName = null;
            uint cchName = 0;
            uint pchName;
            ASSEMBLYMETADATA pMetaData;
            CorAssemblyFlags pdwAssemblyFlags;
            HRESULT hr = Raw.GetAssemblyProps(mda, out ppbPublicKey, out pcbPublicKey, out pulHashAlgId, szName, cchName, out pchName, out pMetaData, out pdwAssemblyFlags);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder((int) pchName);
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

        public GetAssemblyRefPropsResult GetAssemblyRefProps(mdAssemblyRef mdar)
        {
            HRESULT hr;
            GetAssemblyRefPropsResult result;

            if ((hr = TryGetAssemblyRefProps(mdar, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetAssemblyRefProps(mdAssemblyRef mdar, out GetAssemblyRefPropsResult result)
        {
            /*HRESULT GetAssemblyRefProps(
            [In] mdAssemblyRef mdar,
            [Out] IntPtr ppbPublicKeyOrToken,
            [Out] out uint pcbPublicKeyOrToken,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] uint cchName,
            [Out] out uint pchName,
            [Out] out ASSEMBLYMETADATA pMetaData,
            [Out] IntPtr ppbHashValue,
            [Out] out uint pcbHashValue,
            [Out] out CorAssemblyFlags pdwAssemblyFlags);*/
            IntPtr ppbPublicKeyOrToken = default(IntPtr);
            uint pcbPublicKeyOrToken;
            StringBuilder szName = null;
            uint cchName = 0;
            uint pchName;
            ASSEMBLYMETADATA pMetaData;
            IntPtr ppbHashValue = default(IntPtr);
            uint pcbHashValue;
            CorAssemblyFlags pdwAssemblyFlags;
            HRESULT hr = Raw.GetAssemblyRefProps(mdar, ppbPublicKeyOrToken, out pcbPublicKeyOrToken, szName, cchName, out pchName, out pMetaData, ppbHashValue, out pcbHashValue, out pdwAssemblyFlags);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder((int) pchName);
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

        public GetFilePropsResult GetFileProps(mdFile mdf)
        {
            HRESULT hr;
            GetFilePropsResult result;

            if ((hr = TryGetFileProps(mdf, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetFileProps(mdFile mdf, out GetFilePropsResult result)
        {
            /*HRESULT GetFileProps(
            [In] mdFile mdf,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] uint cchName,
            [Out] out uint pchName,
            [Out] IntPtr ppbHashValue,
            [Out] out uint pcbHashValue,
            [Out] out CorFileFlags pdwFileFlags);*/
            StringBuilder szName = null;
            uint cchName = 0;
            uint pchName;
            IntPtr ppbHashValue = default(IntPtr);
            uint pcbHashValue;
            CorFileFlags pdwFileFlags;
            HRESULT hr = Raw.GetFileProps(mdf, szName, cchName, out pchName, ppbHashValue, out pcbHashValue, out pdwFileFlags);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder((int) pchName);
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

        public GetExportedTypePropsResult GetExportedTypeProps(mdExportedType mdct)
        {
            HRESULT hr;
            GetExportedTypePropsResult result;

            if ((hr = TryGetExportedTypeProps(mdct, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetExportedTypeProps(mdExportedType mdct, out GetExportedTypePropsResult result)
        {
            /*HRESULT GetExportedTypeProps(
            [In] mdExportedType mdct,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] uint cchName,
            [Out] out uint pchName,
            [Out] out uint ptkImplementation,
            [Out] out mdTypeDef ptkTypeDef,
            [Out] out CorTypeAttr pdwExportedTypeFlags);*/
            StringBuilder szName = null;
            uint cchName = 0;
            uint pchName;
            uint ptkImplementation;
            mdTypeDef ptkTypeDef;
            CorTypeAttr pdwExportedTypeFlags;
            HRESULT hr = Raw.GetExportedTypeProps(mdct, szName, cchName, out pchName, out ptkImplementation, out ptkTypeDef, out pdwExportedTypeFlags);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder((int) pchName);
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

        public GetManifestResourcePropsResult GetManifestResourceProps(mdManifestResource mdmr)
        {
            HRESULT hr;
            GetManifestResourcePropsResult result;

            if ((hr = TryGetManifestResourceProps(mdmr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetManifestResourceProps(mdManifestResource mdmr, out GetManifestResourcePropsResult result)
        {
            /*HRESULT GetManifestResourceProps(
            [In] mdManifestResource mdmr,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName,
            [In] uint cchName,
            [Out] out uint pchName,
            [Out] out uint ptkImplementation,
            [Out] out uint pdwOffset,
            [Out] out CorManifestResourceFlags pdwResourceFlags);*/
            StringBuilder szName = null;
            uint cchName = 0;
            uint pchName;
            uint ptkImplementation;
            uint pdwOffset;
            CorManifestResourceFlags pdwResourceFlags;
            HRESULT hr = Raw.GetManifestResourceProps(mdmr, szName, cchName, out pchName, out ptkImplementation, out pdwOffset, out pdwResourceFlags);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder((int) pchName);
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

        public mdAssemblyRef[] EnumAssemblyRefs(IntPtr phEnum)
        {
            HRESULT hr;
            mdAssemblyRef[] rAssemblyRefsResult;

            if ((hr = TryEnumAssemblyRefs(phEnum, out rAssemblyRefsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rAssemblyRefsResult;
        }

        public HRESULT TryEnumAssemblyRefs(IntPtr phEnum, out mdAssemblyRef[] rAssemblyRefsResult)
        {
            /*HRESULT EnumAssemblyRefs(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdAssemblyRef[] rAssemblyRefs,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            mdAssemblyRef[] rAssemblyRefs = null;
            uint cMax = 0;
            uint pcTokens;
            HRESULT hr = Raw.EnumAssemblyRefs(ref phEnum, rAssemblyRefs, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cMax = pcTokens;
            rAssemblyRefs = new mdAssemblyRef[(int) pcTokens];
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

        public mdFile[] EnumFiles(IntPtr phEnum)
        {
            HRESULT hr;
            mdFile[] rFilesResult;

            if ((hr = TryEnumFiles(phEnum, out rFilesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rFilesResult;
        }

        public HRESULT TryEnumFiles(IntPtr phEnum, out mdFile[] rFilesResult)
        {
            /*HRESULT EnumFiles(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdFile[] rFiles,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            mdFile[] rFiles = null;
            uint cMax = 0;
            uint pcTokens;
            HRESULT hr = Raw.EnumFiles(ref phEnum, rFiles, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cMax = pcTokens;
            rFiles = new mdFile[(int) pcTokens];
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

        public mdExportedType[] EnumExportedTypes(IntPtr phEnum)
        {
            HRESULT hr;
            mdExportedType[] rExportedTypesResult;

            if ((hr = TryEnumExportedTypes(phEnum, out rExportedTypesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rExportedTypesResult;
        }

        public HRESULT TryEnumExportedTypes(IntPtr phEnum, out mdExportedType[] rExportedTypesResult)
        {
            /*HRESULT EnumExportedTypes(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdExportedType[] rExportedTypes,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            mdExportedType[] rExportedTypes = null;
            uint cMax = 0;
            uint pcTokens;
            HRESULT hr = Raw.EnumExportedTypes(ref phEnum, rExportedTypes, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cMax = pcTokens;
            rExportedTypes = new mdExportedType[(int) pcTokens];
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

        public mdManifestResource[] EnumManifestResources(IntPtr phEnum)
        {
            HRESULT hr;
            mdManifestResource[] rManifestResourcesResult;

            if ((hr = TryEnumManifestResources(phEnum, out rManifestResourcesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rManifestResourcesResult;
        }

        public HRESULT TryEnumManifestResources(IntPtr phEnum, out mdManifestResource[] rManifestResourcesResult)
        {
            /*HRESULT EnumManifestResources(
            [In] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdManifestResource[] rManifestResources,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            mdManifestResource[] rManifestResources = null;
            uint cMax = 0;
            uint pcTokens;
            HRESULT hr = Raw.EnumManifestResources(ref phEnum, rManifestResources, cMax, out pcTokens);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cMax = pcTokens;
            rManifestResources = new mdManifestResource[(int) pcTokens];
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

        public mdExportedType FindExportedTypeByName(string szName, uint mdtExportedType)
        {
            HRESULT hr;
            mdExportedType mdExportedType;

            if ((hr = TryFindExportedTypeByName(szName, mdtExportedType, out mdExportedType)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return mdExportedType;
        }

        public HRESULT TryFindExportedTypeByName(string szName, uint mdtExportedType, out mdExportedType mdExportedType)
        {
            /*HRESULT FindExportedTypeByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] uint mdtExportedType,
            [Out] out mdExportedType mdExportedType);*/
            return Raw.FindExportedTypeByName(szName, mdtExportedType, out mdExportedType);
        }

        #endregion
        #region FindManifestResourceByName

        public mdManifestResource[] FindManifestResourceByName(string szName)
        {
            HRESULT hr;
            mdManifestResource[] ptkManifestResource;

            if ((hr = TryFindManifestResourceByName(szName, out ptkManifestResource)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptkManifestResource;
        }

        public HRESULT TryFindManifestResourceByName(string szName, out mdManifestResource[] ptkManifestResource)
        {
            /*HRESULT FindManifestResourceByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [Out] out mdManifestResource[] ptkManifestResource);*/
            return Raw.FindManifestResourceByName(szName, out ptkManifestResource);
        }

        #endregion
        #region CloseEnum

        public void CloseEnum(IntPtr hEnum)
        {
            HRESULT hr;

            if ((hr = TryCloseEnum(hEnum)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseEnum(IntPtr hEnum)
        {
            /*HRESULT CloseEnum(
            [In] IntPtr hEnum);*/
            return Raw.CloseEnum(hEnum);
        }

        #endregion
        #region FindAssembliesByName

        public FindAssembliesByNameResult FindAssembliesByName(string szAppBase, string szPrivateBin, string szAssemblyName, uint cMax)
        {
            HRESULT hr;
            FindAssembliesByNameResult result;

            if ((hr = TryFindAssembliesByName(szAppBase, szPrivateBin, szAssemblyName, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryFindAssembliesByName(string szAppBase, string szPrivateBin, string szAssemblyName, uint cMax, out FindAssembliesByNameResult result)
        {
            /*HRESULT FindAssembliesByName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [Out, MarshalAs(UnmanagedType.Interface)] out object[] ppIUnk,
            [In] uint cMax,
            [Out] out uint pcAssemblies);*/
            object[] ppIUnk;
            uint pcAssemblies;
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
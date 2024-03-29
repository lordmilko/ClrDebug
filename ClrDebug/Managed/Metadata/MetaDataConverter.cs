﻿using ClrDebug.TypeLib;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to map type libraries to their metadata signatures, and to convert from one to the other.
    /// <para/>This interface is retrieved from a QueryInterface to <see cref="ICorRuntimeHost"/>.
    /// </summary>
    public class MetaDataConverter : ComObject<IMetaDataConverter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataConverter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataConverter(IMetaDataConverter raw) : base(raw)
        {
        }

        #region IMetaDataConverter
        #region GetMetaDataFromTypeInfo

        /// <summary>
        /// Gets a pointer to an <see cref="IMetaDataImport"/> instance that represents the metadata signature of the type library referenced by the specified ITypeInfo instance.
        /// </summary>
        /// <param name="pITI">[in] A pointer to an ITypeInfo object that refers to the type library.</param>
        /// <returns>[out] A pointer to a location that receives the address of the <see cref="IMetaDataImport"/> instance that represents the metadata signature.</returns>
        public MetaDataImport GetMetaDataFromTypeInfo(ITypeInfo pITI)
        {
            MetaDataImport ppMDIResult;
            TryGetMetaDataFromTypeInfo(pITI, out ppMDIResult).ThrowOnNotOK();

            return ppMDIResult;
        }

        /// <summary>
        /// Gets a pointer to an <see cref="IMetaDataImport"/> instance that represents the metadata signature of the type library referenced by the specified ITypeInfo instance.
        /// </summary>
        /// <param name="pITI">[in] A pointer to an ITypeInfo object that refers to the type library.</param>
        /// <param name="ppMDIResult">[out] A pointer to a location that receives the address of the <see cref="IMetaDataImport"/> instance that represents the metadata signature.</param>
        public HRESULT TryGetMetaDataFromTypeInfo(ITypeInfo pITI, out MetaDataImport ppMDIResult)
        {
            /*HRESULT GetMetaDataFromTypeInfo(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeInfo pITI,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMetaDataImport ppMDI);*/
            IMetaDataImport ppMDI;
            HRESULT hr = Raw.GetMetaDataFromTypeInfo(pITI, out ppMDI);

            if (hr == HRESULT.S_OK)
                ppMDIResult = ppMDI == null ? null : new MetaDataImport(ppMDI);
            else
                ppMDIResult = default(MetaDataImport);

            return hr;
        }

        #endregion
        #region GetMetaDataFromTypeLib

        /// <summary>
        /// Gets an interface pointer to an <see cref="IMetaDataImport"/> instance that represents the metadata signature of the type library represented by the specified ITypeLib instance.
        /// </summary>
        /// <param name="pITL">[in] Pointer to an ITypeLib object that represents the type library.</param>
        /// <returns>[out] Pointer to a location that receives the address of the <see cref="IMetaDataImport"/> instance that represents the metadata signature.</returns>
        public MetaDataImport GetMetaDataFromTypeLib(ITypeLib pITL)
        {
            MetaDataImport ppMDIResult;
            TryGetMetaDataFromTypeLib(pITL, out ppMDIResult).ThrowOnNotOK();

            return ppMDIResult;
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="IMetaDataImport"/> instance that represents the metadata signature of the type library represented by the specified ITypeLib instance.
        /// </summary>
        /// <param name="pITL">[in] Pointer to an ITypeLib object that represents the type library.</param>
        /// <param name="ppMDIResult">[out] Pointer to a location that receives the address of the <see cref="IMetaDataImport"/> instance that represents the metadata signature.</param>
        public HRESULT TryGetMetaDataFromTypeLib(ITypeLib pITL, out MetaDataImport ppMDIResult)
        {
            /*HRESULT GetMetaDataFromTypeLib(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeLib pITL,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMetaDataImport ppMDI);*/
            IMetaDataImport ppMDI;
            HRESULT hr = Raw.GetMetaDataFromTypeLib(pITL, out ppMDI);

            if (hr == HRESULT.S_OK)
                ppMDIResult = ppMDI == null ? null : new MetaDataImport(ppMDI);
            else
                ppMDIResult = default(MetaDataImport);

            return hr;
        }

        #endregion
        #region GetTypeLibFromMetaData

        /// <summary>
        /// Gets a pointer to an ITypeLib instance that represents the type library that has the specified library and module names.
        /// </summary>
        /// <param name="strModule">[in] The name of the type library's module.</param>
        /// <param name="strTlbName">[in] The name of the type library.</param>
        /// <returns>[out] A pointer to a location that receives the address of the ITypeLib instance that represents the type library.</returns>
        public ComTypeLib GetTypeLibFromMetaData(string strModule, string strTlbName)
        {
            ComTypeLib ppITLResult;
            TryGetTypeLibFromMetaData(strModule, strTlbName, out ppITLResult).ThrowOnNotOK();

            return ppITLResult;
        }

        /// <summary>
        /// Gets a pointer to an ITypeLib instance that represents the type library that has the specified library and module names.
        /// </summary>
        /// <param name="strModule">[in] The name of the type library's module.</param>
        /// <param name="strTlbName">[in] The name of the type library.</param>
        /// <param name="ppITLResult">[out] A pointer to a location that receives the address of the ITypeLib instance that represents the type library.</param>
        public HRESULT TryGetTypeLibFromMetaData(string strModule, string strTlbName, out ComTypeLib ppITLResult)
        {
            /*HRESULT GetTypeLibFromMetaData(
            [In, MarshalAs(UnmanagedType.BStr)] string strModule,
            [In, MarshalAs(UnmanagedType.BStr)] string strTlbName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeLib ppITL);*/
            ITypeLib ppITL;
            HRESULT hr = Raw.GetTypeLibFromMetaData(strModule, strTlbName, out ppITL);

            if (hr == HRESULT.S_OK)
                ppITLResult = ppITL == null ? null : new ComTypeLib(ppITL);
            else
                ppITLResult = default(ComTypeLib);

            return hr;
        }

        #endregion
        #endregion
    }
}

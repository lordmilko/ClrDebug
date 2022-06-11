using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public class MetaDataConverter : ComObject<IMetaDataConverter>
    {
        public MetaDataConverter(IMetaDataConverter raw) : base(raw)
        {
        }

        #region IMetaDataConverter
        #region GetMetaDataFromTypeInfo

        public MetaDataImport GetMetaDataFromTypeInfo(ITypeInfo pITI)
        {
            HRESULT hr;
            MetaDataImport ppMDIResult;

            if ((hr = TryGetMetaDataFromTypeInfo(pITI, out ppMDIResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppMDIResult;
        }

        public HRESULT TryGetMetaDataFromTypeInfo(ITypeInfo pITI, out MetaDataImport ppMDIResult)
        {
            /*HRESULT GetMetaDataFromTypeInfo(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeInfo pITI,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMetaDataImport ppMDI);*/
            IMetaDataImport ppMDI;
            HRESULT hr = Raw.GetMetaDataFromTypeInfo(pITI, out ppMDI);

            if (hr == HRESULT.S_OK)
                ppMDIResult = new MetaDataImport(ppMDI);
            else
                ppMDIResult = default(MetaDataImport);

            return hr;
        }

        #endregion
        #region GetMetaDataFromTypeLib

        public MetaDataImport GetMetaDataFromTypeLib(ITypeLib pITL)
        {
            HRESULT hr;
            MetaDataImport ppMDIResult;

            if ((hr = TryGetMetaDataFromTypeLib(pITL, out ppMDIResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppMDIResult;
        }

        public HRESULT TryGetMetaDataFromTypeLib(ITypeLib pITL, out MetaDataImport ppMDIResult)
        {
            /*HRESULT GetMetaDataFromTypeLib(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeLib pITL,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMetaDataImport ppMDI);*/
            IMetaDataImport ppMDI;
            HRESULT hr = Raw.GetMetaDataFromTypeLib(pITL, out ppMDI);

            if (hr == HRESULT.S_OK)
                ppMDIResult = new MetaDataImport(ppMDI);
            else
                ppMDIResult = default(MetaDataImport);

            return hr;
        }

        #endregion
        #region GetTypeLibFromMetaData

        public ITypeLib GetTypeLibFromMetaData(string strModule, string strTlbName)
        {
            HRESULT hr;
            ITypeLib ppITL;

            if ((hr = TryGetTypeLibFromMetaData(strModule, strTlbName, out ppITL)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppITL;
        }

        public HRESULT TryGetTypeLibFromMetaData(string strModule, string strTlbName, out ITypeLib ppITL)
        {
            /*HRESULT GetTypeLibFromMetaData(
            [In, MarshalAs(UnmanagedType.BStr)] string strModule,
            [In, MarshalAs(UnmanagedType.BStr)] string strTlbName,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeLib ppITL);*/
            return Raw.GetTypeLibFromMetaData(strModule, strTlbName, out ppITL);
        }

        #endregion
        #endregion
    }
}
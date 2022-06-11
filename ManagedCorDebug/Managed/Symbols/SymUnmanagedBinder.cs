using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public class SymUnmanagedBinder : ComObject<ISymUnmanagedBinder>
    {
        public SymUnmanagedBinder(ISymUnmanagedBinder raw) : base(raw)
        {
        }

        #region ISymUnmanagedBinder
        #region GetReaderForFile

        public SymUnmanagedReader GetReaderForFile(IMetaDataImport importer, string fileName, string searchPath)
        {
            HRESULT hr;
            SymUnmanagedReader pRetValResult;

            if ((hr = TryGetReaderForFile(importer, fileName, searchPath, out pRetValResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetValResult;
        }

        public HRESULT TryGetReaderForFile(IMetaDataImport importer, string fileName, string searchPath, out SymUnmanagedReader pRetValResult)
        {
            /*HRESULT GetReaderForFile(
            [MarshalAs(UnmanagedType.IUnknown), In] IMetaDataImport importer,
            [In] string fileName,
            [In] string searchPath,
            [Out] out ISymUnmanagedReader pRetVal);*/
            ISymUnmanagedReader pRetVal;
            HRESULT hr = Raw.GetReaderForFile(importer, fileName, searchPath, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedReader(pRetVal);
            else
                pRetValResult = default(SymUnmanagedReader);

            return hr;
        }

        #endregion
        #region GetReaderFromStream

        public ISymUnmanagedReader GetReaderFromStream(IMetaDataImport importer, IStream pstream)
        {
            HRESULT hr;
            ISymUnmanagedReader pRetVal = default(ISymUnmanagedReader);

            if ((hr = TryGetReaderFromStream(importer, pstream, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetReaderFromStream(IMetaDataImport importer, IStream pstream, ref ISymUnmanagedReader pRetVal)
        {
            /*HRESULT GetReaderFromStream(
            [MarshalAs(UnmanagedType.IUnknown), In] IMetaDataImport importer,
            [MarshalAs(UnmanagedType.Interface), In] IStream pstream,
            [Out] ISymUnmanagedReader pRetVal);*/
            return Raw.GetReaderFromStream(importer, pstream, pRetVal);
        }

        #endregion
        #endregion
        #region ISymUnmanagedBinder2

        public ISymUnmanagedBinder2 Raw2 => (ISymUnmanagedBinder2) Raw;

        #region GetReaderForFile2

        public ISymUnmanagedReader GetReaderForFile2(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy)
        {
            HRESULT hr;
            ISymUnmanagedReader pRetVal = default(ISymUnmanagedReader);

            if ((hr = TryGetReaderForFile2(importer, fileName, searchPath, searchPolicy, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetReaderForFile2(IMetaDataImport importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, ref ISymUnmanagedReader pRetVal)
        {
            /*HRESULT GetReaderForFile2(
            [MarshalAs(UnmanagedType.IUnknown), In] IMetaDataImport importer,
            [In] string fileName,
            [In] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [Out] ISymUnmanagedReader pRetVal);*/
            return Raw2.GetReaderForFile2(importer, fileName, searchPath, searchPolicy, pRetVal);
        }

        #endregion
        #endregion
        #region ISymUnmanagedBinder3

        public ISymUnmanagedBinder3 Raw3 => (ISymUnmanagedBinder3) Raw;

        #region GetReaderFromCallback

        public ISymUnmanagedReader GetReaderFromCallback(object importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, object callback)
        {
            HRESULT hr;
            ISymUnmanagedReader pRetVal = default(ISymUnmanagedReader);

            if ((hr = TryGetReaderFromCallback(importer, fileName, searchPath, searchPolicy, callback, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryGetReaderFromCallback(object importer, string fileName, string searchPath, CorSymSearchPolicyAttributes searchPolicy, object callback, ref ISymUnmanagedReader pRetVal)
        {
            /*HRESULT GetReaderFromCallback(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object importer,
            [In] string fileName,
            [In] string searchPath,
            [In] CorSymSearchPolicyAttributes searchPolicy,
            [MarshalAs(UnmanagedType.IUnknown), In] object callback,
            [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedReader pRetVal);*/
            return Raw3.GetReaderFromCallback(importer, fileName, searchPath, searchPolicy, callback, pRetVal);
        }

        #endregion
        #endregion
    }
}
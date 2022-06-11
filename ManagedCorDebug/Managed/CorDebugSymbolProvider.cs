using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugSymbolProvider : ComObject<ICorDebugSymbolProvider>
    {
        public CorDebugSymbolProvider(ICorDebugSymbolProvider raw) : base(raw)
        {
        }

        #region ICorDebugSymbolProvider
        #region GetAssemblyImageMetadata

        public CorDebugMemoryBuffer AssemblyImageMetadata
        {
            get
            {
                HRESULT hr;
                CorDebugMemoryBuffer ppMemoryBufferResult;

                if ((hr = TryGetAssemblyImageMetadata(out ppMemoryBufferResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppMemoryBufferResult;
            }
        }

        public HRESULT TryGetAssemblyImageMetadata(out CorDebugMemoryBuffer ppMemoryBufferResult)
        {
            /*HRESULT GetAssemblyImageMetadata([MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);*/
            ICorDebugMemoryBuffer ppMemoryBuffer;
            HRESULT hr = Raw.GetAssemblyImageMetadata(out ppMemoryBuffer);

            if (hr == HRESULT.S_OK)
                ppMemoryBufferResult = new CorDebugMemoryBuffer(ppMemoryBuffer);
            else
                ppMemoryBufferResult = default(CorDebugMemoryBuffer);

            return hr;
        }

        #endregion
        #region GetStaticFieldSymbols

        public GetStaticFieldSymbolsResult GetStaticFieldSymbols(uint cbSignature, IntPtr typeSig, uint cRequestedSymbols)
        {
            HRESULT hr;
            GetStaticFieldSymbolsResult result;

            if ((hr = TryGetStaticFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetStaticFieldSymbols(uint cbSignature, IntPtr typeSig, uint cRequestedSymbols, out GetStaticFieldSymbolsResult result)
        {
            /*HRESULT GetStaticFieldSymbols(
            [In] uint cbSignature,
            [In] IntPtr typeSig,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            uint pcFetchedSymbols;
            IntPtr pSymbols = default(IntPtr);
            HRESULT hr = Raw.GetStaticFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
                result = new GetStaticFieldSymbolsResult(pcFetchedSymbols, pSymbols);
            else
                result = default(GetStaticFieldSymbolsResult);

            return hr;
        }

        #endregion
        #region GetInstanceFieldSymbols

        public GetInstanceFieldSymbolsResult GetInstanceFieldSymbols(uint cbSignature, IntPtr typeSig, uint cRequestedSymbols)
        {
            HRESULT hr;
            GetInstanceFieldSymbolsResult result;

            if ((hr = TryGetInstanceFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetInstanceFieldSymbols(uint cbSignature, IntPtr typeSig, uint cRequestedSymbols, out GetInstanceFieldSymbolsResult result)
        {
            /*HRESULT GetInstanceFieldSymbols(
            [In] uint cbSignature,
            [In] IntPtr typeSig,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            uint pcFetchedSymbols;
            IntPtr pSymbols = default(IntPtr);
            HRESULT hr = Raw.GetInstanceFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
                result = new GetInstanceFieldSymbolsResult(pcFetchedSymbols, pSymbols);
            else
                result = default(GetInstanceFieldSymbolsResult);

            return hr;
        }

        #endregion
        #region GetMethodLocalSymbols

        public GetMethodLocalSymbolsResult GetMethodLocalSymbols(uint nativeRVA, uint cRequestedSymbols)
        {
            HRESULT hr;
            GetMethodLocalSymbolsResult result;

            if ((hr = TryGetMethodLocalSymbols(nativeRVA, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodLocalSymbols(uint nativeRVA, uint cRequestedSymbols, out GetMethodLocalSymbolsResult result)
        {
            /*HRESULT GetMethodLocalSymbols(
            [In] uint nativeRVA,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            uint pcFetchedSymbols;
            IntPtr pSymbols = default(IntPtr);
            HRESULT hr = Raw.GetMethodLocalSymbols(nativeRVA, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
                result = new GetMethodLocalSymbolsResult(pcFetchedSymbols, pSymbols);
            else
                result = default(GetMethodLocalSymbolsResult);

            return hr;
        }

        #endregion
        #region GetMethodParameterSymbols

        public GetMethodParameterSymbolsResult GetMethodParameterSymbols(uint nativeRVA, uint cRequestedSymbols)
        {
            HRESULT hr;
            GetMethodParameterSymbolsResult result;

            if ((hr = TryGetMethodParameterSymbols(nativeRVA, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodParameterSymbols(uint nativeRVA, uint cRequestedSymbols, out GetMethodParameterSymbolsResult result)
        {
            /*HRESULT GetMethodParameterSymbols(
            [In] uint nativeRVA,
            [In] uint cRequestedSymbols,
            out uint pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            uint pcFetchedSymbols;
            IntPtr pSymbols = default(IntPtr);
            HRESULT hr = Raw.GetMethodParameterSymbols(nativeRVA, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
                result = new GetMethodParameterSymbolsResult(pcFetchedSymbols, pSymbols);
            else
                result = default(GetMethodParameterSymbolsResult);

            return hr;
        }

        #endregion
        #region GetMergedAssemblyRecords

        public GetMergedAssemblyRecordsResult GetMergedAssemblyRecords(uint cRequestedRecords)
        {
            HRESULT hr;
            GetMergedAssemblyRecordsResult result;

            if ((hr = TryGetMergedAssemblyRecords(cRequestedRecords, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMergedAssemblyRecords(uint cRequestedRecords, out GetMergedAssemblyRecordsResult result)
        {
            /*HRESULT GetMergedAssemblyRecords(
            [In] uint cRequestedRecords,
            out uint pcFetchedRecords,
            [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr pRecords);*/
            uint pcFetchedRecords;
            IntPtr pRecords = default(IntPtr);
            HRESULT hr = Raw.GetMergedAssemblyRecords(cRequestedRecords, out pcFetchedRecords, pRecords);

            if (hr == HRESULT.S_OK)
                result = new GetMergedAssemblyRecordsResult(pcFetchedRecords, pRecords);
            else
                result = default(GetMergedAssemblyRecordsResult);

            return hr;
        }

        #endregion
        #region GetMethodProps

        public GetMethodPropsResult GetMethodProps(uint codeRva, uint cbSignature)
        {
            HRESULT hr;
            GetMethodPropsResult result;

            if ((hr = TryGetMethodProps(codeRva, cbSignature, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodProps(uint codeRva, uint cbSignature, out GetMethodPropsResult result)
        {
            /*HRESULT GetMethodProps(
            [In] uint codeRva,
            out uint pMethodToken,
            out uint pcGenericParams,
            [In] uint cbSignature,
            out uint pcbSignature,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] signature);*/
            uint pMethodToken;
            uint pcGenericParams;
            uint pcbSignature;
            byte[] signature = null;
            HRESULT hr = Raw.GetMethodProps(codeRva, out pMethodToken, out pcGenericParams, cbSignature, out pcbSignature, signature);

            if (hr == HRESULT.S_OK)
                result = new GetMethodPropsResult(pMethodToken, pcGenericParams, pcbSignature, signature);
            else
                result = default(GetMethodPropsResult);

            return hr;
        }

        #endregion
        #region GetTypeProps

        public GetTypePropsResult GetTypeProps(uint vtableRva, uint cbSignature)
        {
            HRESULT hr;
            GetTypePropsResult result;

            if ((hr = TryGetTypeProps(vtableRva, cbSignature, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetTypeProps(uint vtableRva, uint cbSignature, out GetTypePropsResult result)
        {
            /*HRESULT GetTypeProps(
            [In] uint vtableRva,
            [In] uint cbSignature,
            out uint pcbSignature,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] signature);*/
            uint pcbSignature;
            byte[] signature = null;
            HRESULT hr = Raw.GetTypeProps(vtableRva, cbSignature, out pcbSignature, signature);

            if (hr == HRESULT.S_OK)
                result = new GetTypePropsResult(pcbSignature, signature);
            else
                result = default(GetTypePropsResult);

            return hr;
        }

        #endregion
        #region GetCodeRange

        public GetCodeRangeResult GetCodeRange(uint codeRva)
        {
            HRESULT hr;
            GetCodeRangeResult result;

            if ((hr = TryGetCodeRange(codeRva, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetCodeRange(uint codeRva, out GetCodeRangeResult result)
        {
            /*HRESULT GetCodeRange([In] uint codeRva, out uint pCodeStartAddress, ref uint pCodeSize);*/
            uint pCodeStartAddress;
            uint pCodeSize = default(uint);
            HRESULT hr = Raw.GetCodeRange(codeRva, out pCodeStartAddress, ref pCodeSize);

            if (hr == HRESULT.S_OK)
                result = new GetCodeRangeResult(pCodeStartAddress, pCodeSize);
            else
                result = default(GetCodeRangeResult);

            return hr;
        }

        #endregion
        #region GetAssemblyImageBytes

        public CorDebugMemoryBuffer GetAssemblyImageBytes(ulong rva, uint length)
        {
            HRESULT hr;
            CorDebugMemoryBuffer ppMemoryBufferResult;

            if ((hr = TryGetAssemblyImageBytes(rva, length, out ppMemoryBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppMemoryBufferResult;
        }

        public HRESULT TryGetAssemblyImageBytes(ulong rva, uint length, out CorDebugMemoryBuffer ppMemoryBufferResult)
        {
            /*HRESULT GetAssemblyImageBytes([In] ulong rva, [In] uint length,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);*/
            ICorDebugMemoryBuffer ppMemoryBuffer;
            HRESULT hr = Raw.GetAssemblyImageBytes(rva, length, out ppMemoryBuffer);

            if (hr == HRESULT.S_OK)
                ppMemoryBufferResult = new CorDebugMemoryBuffer(ppMemoryBuffer);
            else
                ppMemoryBufferResult = default(CorDebugMemoryBuffer);

            return hr;
        }

        #endregion
        #region GetObjectSize

        public uint GetObjectSize(uint cbSignature, IntPtr typeSig)
        {
            HRESULT hr;
            uint pObjectSize;

            if ((hr = TryGetObjectSize(cbSignature, typeSig, out pObjectSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pObjectSize;
        }

        public HRESULT TryGetObjectSize(uint cbSignature, IntPtr typeSig, out uint pObjectSize)
        {
            /*HRESULT GetObjectSize([In] uint cbSignature, [In] IntPtr typeSig, out uint pObjectSize);*/
            return Raw.GetObjectSize(cbSignature, typeSig, out pObjectSize);
        }

        #endregion
        #endregion
        #region ICorDebugSymbolProvider2

        public ICorDebugSymbolProvider2 Raw2 => (ICorDebugSymbolProvider2) Raw;

        #region GetGenericDictionaryInfo

        public CorDebugMemoryBuffer GenericDictionaryInfo
        {
            get
            {
                HRESULT hr;
                CorDebugMemoryBuffer ppMemoryBufferResult;

                if ((hr = TryGetGenericDictionaryInfo(out ppMemoryBufferResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppMemoryBufferResult;
            }
        }

        public HRESULT TryGetGenericDictionaryInfo(out CorDebugMemoryBuffer ppMemoryBufferResult)
        {
            /*HRESULT GetGenericDictionaryInfo([MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);*/
            ICorDebugMemoryBuffer ppMemoryBuffer;
            HRESULT hr = Raw2.GetGenericDictionaryInfo(out ppMemoryBuffer);

            if (hr == HRESULT.S_OK)
                ppMemoryBufferResult = new CorDebugMemoryBuffer(ppMemoryBuffer);
            else
                ppMemoryBufferResult = default(CorDebugMemoryBuffer);

            return hr;
        }

        #endregion
        #region GetFrameProps

        public GetFramePropsResult GetFrameProps(uint codeRva)
        {
            HRESULT hr;
            GetFramePropsResult result;

            if ((hr = TryGetFrameProps(codeRva, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetFrameProps(uint codeRva, out GetFramePropsResult result)
        {
            /*HRESULT GetFrameProps([In] uint codeRva, out uint pCodeStartRva, out uint pParentFrameStartRva);*/
            uint pCodeStartRva;
            uint pParentFrameStartRva;
            HRESULT hr = Raw2.GetFrameProps(codeRva, out pCodeStartRva, out pParentFrameStartRva);

            if (hr == HRESULT.S_OK)
                result = new GetFramePropsResult(pCodeStartRva, pParentFrameStartRva);
            else
                result = default(GetFramePropsResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
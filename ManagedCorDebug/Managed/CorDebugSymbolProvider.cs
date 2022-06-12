using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that can be used to retrieve debug symbol information.
    /// </summary>
    public class CorDebugSymbolProvider : ComObject<ICorDebugSymbolProvider>
    {
        public CorDebugSymbolProvider(ICorDebugSymbolProvider raw) : base(raw)
        {
        }

        #region ICorDebugSymbolProvider
        #region AssemblyImageMetadata

        /// <summary>
        /// Returns the metadata from a merged assembly.
        /// </summary>
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

        /// <summary>
        /// Returns the metadata from a merged assembly.
        /// </summary>
        /// <param name="ppMemoryBufferResult">[out] A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object that contains information about the size and address of the merged assembly's metadata.</param>
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

        /// <summary>
        /// Gets the static field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="cRequestedSymbols">[in] The number of symbols requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetStaticFieldSymbolsResult GetStaticFieldSymbols(int cbSignature, IntPtr typeSig, int cRequestedSymbols)
        {
            HRESULT hr;
            GetStaticFieldSymbolsResult result;

            if ((hr = TryGetStaticFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the static field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="cRequestedSymbols">[in] The number of symbols requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetStaticFieldSymbols(int cbSignature, IntPtr typeSig, int cRequestedSymbols, out GetStaticFieldSymbolsResult result)
        {
            /*HRESULT GetStaticFieldSymbols(
            [In] int cbSignature,
            [In] IntPtr typeSig,
            [In] int cRequestedSymbols,
            out int pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            int pcFetchedSymbols;
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

        /// <summary>
        /// Gets the instance field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="cRequestedSymbols">[in] The number of symbols requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetInstanceFieldSymbolsResult GetInstanceFieldSymbols(int cbSignature, IntPtr typeSig, int cRequestedSymbols)
        {
            HRESULT hr;
            GetInstanceFieldSymbolsResult result;

            if ((hr = TryGetInstanceFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the instance field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="cRequestedSymbols">[in] The number of symbols requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetInstanceFieldSymbols(int cbSignature, IntPtr typeSig, int cRequestedSymbols, out GetInstanceFieldSymbolsResult result)
        {
            /*HRESULT GetInstanceFieldSymbols(
            [In] int cbSignature,
            [In] IntPtr typeSig,
            [In] int cRequestedSymbols,
            out int pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            int pcFetchedSymbols;
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

        /// <summary>
        /// Gets a method's local symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="cRequestedSymbols">[in] The number of local symbols requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMethodLocalSymbolsResult GetMethodLocalSymbols(int nativeRVA, int cRequestedSymbols)
        {
            HRESULT hr;
            GetMethodLocalSymbolsResult result;

            if ((hr = TryGetMethodLocalSymbols(nativeRVA, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a method's local symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="cRequestedSymbols">[in] The number of local symbols requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMethodLocalSymbols(int nativeRVA, int cRequestedSymbols, out GetMethodLocalSymbolsResult result)
        {
            /*HRESULT GetMethodLocalSymbols(
            [In] int nativeRVA,
            [In] int cRequestedSymbols,
            out int pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            int pcFetchedSymbols;
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

        /// <summary>
        /// Gets a method's parameter symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="cRequestedSymbols">[in] The number of local symbols requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMethodParameterSymbolsResult GetMethodParameterSymbols(int nativeRVA, int cRequestedSymbols)
        {
            HRESULT hr;
            GetMethodParameterSymbolsResult result;

            if ((hr = TryGetMethodParameterSymbols(nativeRVA, cRequestedSymbols, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a method's parameter symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="cRequestedSymbols">[in] The number of local symbols requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMethodParameterSymbols(int nativeRVA, int cRequestedSymbols, out GetMethodParameterSymbolsResult result)
        {
            /*HRESULT GetMethodParameterSymbols(
            [In] int nativeRVA,
            [In] int cRequestedSymbols,
            out int pcFetchedSymbols,
            [Out] IntPtr pSymbols);*/
            int pcFetchedSymbols;
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

        /// <summary>
        /// Gets the symbol records for all the merged assemblies.
        /// </summary>
        /// <param name="cRequestedRecords">[in] The number of symbol records requested.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMergedAssemblyRecordsResult GetMergedAssemblyRecords(int cRequestedRecords)
        {
            HRESULT hr;
            GetMergedAssemblyRecordsResult result;

            if ((hr = TryGetMergedAssemblyRecords(cRequestedRecords, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the symbol records for all the merged assemblies.
        /// </summary>
        /// <param name="cRequestedRecords">[in] The number of symbol records requested.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMergedAssemblyRecords(int cRequestedRecords, out GetMergedAssemblyRecordsResult result)
        {
            /*HRESULT GetMergedAssemblyRecords(
            [In] int cRequestedRecords,
            out int pcFetchedRecords,
            [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr pRecords);*/
            int pcFetchedRecords;
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

        /// <summary>
        /// Returns information about method properties, such as the method's metadata token and information about its generic parameters, given a relative virtual address (RVA) in that method.
        /// </summary>
        /// <param name="codeRva">[in] A relative virtual address in the method about which information is to be retrieved.</param>
        /// <param name="cbSignature">[in] The size of the signature array. See the Remarks section.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// To get the required size of the method's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public GetMethodPropsResult GetMethodProps(int codeRva, int cbSignature)
        {
            HRESULT hr;
            GetMethodPropsResult result;

            if ((hr = TryGetMethodProps(codeRva, cbSignature, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns information about method properties, such as the method's metadata token and information about its generic parameters, given a relative virtual address (RVA) in that method.
        /// </summary>
        /// <param name="codeRva">[in] A relative virtual address in the method about which information is to be retrieved.</param>
        /// <param name="cbSignature">[in] The size of the signature array. See the Remarks section.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// To get the required size of the method's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public HRESULT TryGetMethodProps(int codeRva, int cbSignature, out GetMethodPropsResult result)
        {
            /*HRESULT GetMethodProps(
            [In] int codeRva,
            out int pMethodToken,
            out int pcGenericParams,
            [In] int cbSignature,
            out int pcbSignature,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] signature);*/
            int pMethodToken;
            int pcGenericParams;
            int pcbSignature;
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

        /// <summary>
        /// Returns information about a type's properties, such as the number of signature of its generic parameters, given a relative virtual address (RVA) in a vtable.
        /// </summary>
        /// <param name="vtableRva">[in] A relative virtual address (RVA) in a vtable.</param>
        /// <param name="cbSignature">[in] The size of the signature array. See the Remarks section.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// To get the required size of the type's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public GetTypePropsResult GetTypeProps(int vtableRva, int cbSignature)
        {
            HRESULT hr;
            GetTypePropsResult result;

            if ((hr = TryGetTypeProps(vtableRva, cbSignature, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns information about a type's properties, such as the number of signature of its generic parameters, given a relative virtual address (RVA) in a vtable.
        /// </summary>
        /// <param name="vtableRva">[in] A relative virtual address (RVA) in a vtable.</param>
        /// <param name="cbSignature">[in] The size of the signature array. See the Remarks section.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// To get the required size of the type's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public HRESULT TryGetTypeProps(int vtableRva, int cbSignature, out GetTypePropsResult result)
        {
            /*HRESULT GetTypeProps(
            [In] int vtableRva,
            [In] int cbSignature,
            out int pcbSignature,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] signature);*/
            int pcbSignature;
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

        /// <summary>
        /// Gets the method start address and size given a relative virtual address (RVA) in a method.
        /// </summary>
        /// <param name="codeRva">[in] The relative virtual address (RVA) in a method.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetCodeRangeResult GetCodeRange(int codeRva)
        {
            HRESULT hr;
            GetCodeRangeResult result;

            if ((hr = TryGetCodeRange(codeRva, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the method start address and size given a relative virtual address (RVA) in a method.
        /// </summary>
        /// <param name="codeRva">[in] The relative virtual address (RVA) in a method.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetCodeRange(int codeRva, out GetCodeRangeResult result)
        {
            /*HRESULT GetCodeRange([In] int codeRva, out int pCodeStartAddress, ref int pCodeSize);*/
            int pCodeStartAddress;
            int pCodeSize = default(int);
            HRESULT hr = Raw.GetCodeRange(codeRva, out pCodeStartAddress, ref pCodeSize);

            if (hr == HRESULT.S_OK)
                result = new GetCodeRangeResult(pCodeStartAddress, pCodeSize);
            else
                result = default(GetCodeRangeResult);

            return hr;
        }

        #endregion
        #region GetAssemblyImageBytes

        /// <summary>
        /// Reads data from a merged assembly given a relative virtual address (RVA) in the merged assembly.
        /// </summary>
        /// <param name="rva">[in] A relative virtual address (RVA) in a merged assembly.</param>
        /// <param name="length">The number of bytes to read from the merged assembly.</param>
        /// <returns>A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object that contains information about the memory buffer with merged assembly metadata.</returns>
        public CorDebugMemoryBuffer GetAssemblyImageBytes(long rva, int length)
        {
            HRESULT hr;
            CorDebugMemoryBuffer ppMemoryBufferResult;

            if ((hr = TryGetAssemblyImageBytes(rva, length, out ppMemoryBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppMemoryBufferResult;
        }

        /// <summary>
        /// Reads data from a merged assembly given a relative virtual address (RVA) in the merged assembly.
        /// </summary>
        /// <param name="rva">[in] A relative virtual address (RVA) in a merged assembly.</param>
        /// <param name="length">The number of bytes to read from the merged assembly.</param>
        /// <param name="ppMemoryBufferResult">A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object that contains information about the memory buffer with merged assembly metadata.</param>
        public HRESULT TryGetAssemblyImageBytes(long rva, int length, out CorDebugMemoryBuffer ppMemoryBufferResult)
        {
            /*HRESULT GetAssemblyImageBytes([In] long rva, [In] int length,
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

        /// <summary>
        /// Returns the object size for an object based on its typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typespec signature.</param>
        /// <param name="typeSig">[in] The typespec signature.</param>
        /// <returns>[out] A pointer to the size of the object.</returns>
        public int GetObjectSize(int cbSignature, IntPtr typeSig)
        {
            HRESULT hr;
            int pObjectSize;

            if ((hr = TryGetObjectSize(cbSignature, typeSig, out pObjectSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pObjectSize;
        }

        /// <summary>
        /// Returns the object size for an object based on its typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typespec signature.</param>
        /// <param name="typeSig">[in] The typespec signature.</param>
        /// <param name="pObjectSize">[out] A pointer to the size of the object.</param>
        public HRESULT TryGetObjectSize(int cbSignature, IntPtr typeSig, out int pObjectSize)
        {
            /*HRESULT GetObjectSize([In] int cbSignature, [In] IntPtr typeSig, out int pObjectSize);*/
            return Raw.GetObjectSize(cbSignature, typeSig, out pObjectSize);
        }

        #endregion
        #endregion
        #region ICorDebugSymbolProvider2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugSymbolProvider2 Raw2 => (ICorDebugSymbolProvider2) Raw;

        #region GenericDictionaryInfo

        /// <summary>
        /// Retrieves a generic dictionary map.
        /// </summary>
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

        /// <summary>
        /// Retrieves a generic dictionary map.
        /// </summary>
        /// <param name="ppMemoryBufferResult">[out] A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object containing the generic dictionary map.<para/>
        /// See the Remarks section for more information.</param>
        /// <remarks>
        /// The map consists of two top-level sections: 
        /// </remarks>
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

        /// <summary>
        /// Returns the method starting relative virtual address of a method and the parent frame given a code relative virtual address.
        /// </summary>
        /// <param name="codeRva">[in] A code relative virtual address.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetFramePropsResult GetFrameProps(int codeRva)
        {
            HRESULT hr;
            GetFramePropsResult result;

            if ((hr = TryGetFrameProps(codeRva, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns the method starting relative virtual address of a method and the parent frame given a code relative virtual address.
        /// </summary>
        /// <param name="codeRva">[in] A code relative virtual address.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetFrameProps(int codeRva, out GetFramePropsResult result)
        {
            /*HRESULT GetFrameProps([In] int codeRva, out int pCodeStartRva, out int pParentFrameStartRva);*/
            int pCodeStartRva;
            int pParentFrameStartRva;
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
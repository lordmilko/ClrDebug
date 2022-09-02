using System;
using System.Diagnostics;
using System.Linq;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that can be used to retrieve debug symbol information.
    /// </summary>
    public class CorDebugSymbolProvider : ComObject<ICorDebugSymbolProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugSymbolProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugSymbolProvider(ICorDebugSymbolProvider raw) : base(raw)
        {
        }

        #region ICorDebugSymbolProvider
        #region MergedAssemblyRecords

        /// <summary>
        /// Gets the symbol records for all the merged assemblies.
        /// </summary>
        public CorDebugMergedAssemblyRecord[] MergedAssemblyRecords
        {
            get
            {
                CorDebugMergedAssemblyRecord[] pRecordsResult;
                TryGetMergedAssemblyRecords(out pRecordsResult).ThrowOnNotOK();

                return pRecordsResult;
            }
        }

        /// <summary>
        /// Gets the symbol records for all the merged assemblies.
        /// </summary>
        /// <param name="pRecordsResult">A pointer to an array of <see cref="ICorDebugMergedAssemblyRecord"/> objects.</param>
        public HRESULT TryGetMergedAssemblyRecords(out CorDebugMergedAssemblyRecord[] pRecordsResult)
        {
            /*HRESULT GetMergedAssemblyRecords(
            [In] int cRequestedRecords,
            [Out] out int pcFetchedRecords,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] ICorDebugMergedAssemblyRecord[] pRecords);*/
            int cRequestedRecords = 0;
            int pcFetchedRecords;
            ICorDebugMergedAssemblyRecord[] pRecords;
            HRESULT hr = Raw.GetMergedAssemblyRecords(cRequestedRecords, out pcFetchedRecords, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRequestedRecords = pcFetchedRecords;
            pRecords = new ICorDebugMergedAssemblyRecord[cRequestedRecords];
            hr = Raw.GetMergedAssemblyRecords(cRequestedRecords, out pcFetchedRecords, pRecords);

            if (hr == HRESULT.S_OK)
            {
                pRecordsResult = pRecords.Select(v => new CorDebugMergedAssemblyRecord(v)).ToArray();

                return hr;
            }

            fail:
            pRecordsResult = default(CorDebugMergedAssemblyRecord[]);

            return hr;
        }

        #endregion
        #region AssemblyImageMetadata

        /// <summary>
        /// Returns the metadata from a merged assembly.
        /// </summary>
        public CorDebugMemoryBuffer AssemblyImageMetadata
        {
            get
            {
                CorDebugMemoryBuffer ppMemoryBufferResult;
                TryGetAssemblyImageMetadata(out ppMemoryBufferResult).ThrowOnNotOK();

                return ppMemoryBufferResult;
            }
        }

        /// <summary>
        /// Returns the metadata from a merged assembly.
        /// </summary>
        /// <param name="ppMemoryBufferResult">[out] A pointer to the address of an <see cref="ICorDebugMemoryBuffer"/> object that contains information about the size and address of the merged assembly's metadata.</param>
        public HRESULT TryGetAssemblyImageMetadata(out CorDebugMemoryBuffer ppMemoryBufferResult)
        {
            /*HRESULT GetAssemblyImageMetadata(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);*/
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
        /// <returns>[out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested static field symbols.</returns>
        public CorDebugStaticFieldSymbol[] GetStaticFieldSymbols(int cbSignature, IntPtr typeSig)
        {
            CorDebugStaticFieldSymbol[] pSymbolsResult;
            TryGetStaticFieldSymbols(cbSignature, typeSig, out pSymbolsResult).ThrowOnNotOK();

            return pSymbolsResult;
        }

        /// <summary>
        /// Gets the static field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="pSymbolsResult">[out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested static field symbols.</param>
        public HRESULT TryGetStaticFieldSymbols(int cbSignature, IntPtr typeSig, out CorDebugStaticFieldSymbol[] pSymbolsResult)
        {
            /*HRESULT GetStaticFieldSymbols(
            [In] int cbSignature,
            [In, MarshalAs(UnmanagedType.SysInt, SizeParamIndex = 0)] IntPtr typeSig,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ICorDebugStaticFieldSymbol[] pSymbols);*/
            int cRequestedSymbols = 0;
            int pcFetchedSymbols;
            ICorDebugStaticFieldSymbol[] pSymbols;
            HRESULT hr = Raw.GetStaticFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out pcFetchedSymbols, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRequestedSymbols = pcFetchedSymbols;
            pSymbols = new ICorDebugStaticFieldSymbol[cRequestedSymbols];
            hr = Raw.GetStaticFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
            {
                pSymbolsResult = pSymbols.Select(v => new CorDebugStaticFieldSymbol(v)).ToArray();

                return hr;
            }

            fail:
            pSymbolsResult = default(CorDebugStaticFieldSymbol[]);

            return hr;
        }

        #endregion
        #region GetInstanceFieldSymbols

        /// <summary>
        /// Gets the instance field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <returns>[out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested instance field symbols.</returns>
        public CorDebugInstanceFieldSymbol[] GetInstanceFieldSymbols(int cbSignature, IntPtr typeSig)
        {
            CorDebugInstanceFieldSymbol[] pSymbolsResult;
            TryGetInstanceFieldSymbols(cbSignature, typeSig, out pSymbolsResult).ThrowOnNotOK();

            return pSymbolsResult;
        }

        /// <summary>
        /// Gets the instance field symbols that correspond to a typespec signature.
        /// </summary>
        /// <param name="cbSignature">[in] The number of bytes in the typeSig array.</param>
        /// <param name="typeSig">[in] A byte array that contains the typespec signature.</param>
        /// <param name="pSymbolsResult">[out] A pointer to an <see cref="ICorDebugStaticFieldSymbol"/> array that contains the requested instance field symbols.</param>
        public HRESULT TryGetInstanceFieldSymbols(int cbSignature, IntPtr typeSig, out CorDebugInstanceFieldSymbol[] pSymbolsResult)
        {
            /*HRESULT GetInstanceFieldSymbols(
            [In] int cbSignature,
            [In, MarshalAs(UnmanagedType.SysInt, SizeParamIndex = 0)] IntPtr typeSig,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ICorDebugInstanceFieldSymbol[] pSymbols);*/
            int cRequestedSymbols = 0;
            int pcFetchedSymbols;
            ICorDebugInstanceFieldSymbol[] pSymbols;
            HRESULT hr = Raw.GetInstanceFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out pcFetchedSymbols, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRequestedSymbols = pcFetchedSymbols;
            pSymbols = new ICorDebugInstanceFieldSymbol[cRequestedSymbols];
            hr = Raw.GetInstanceFieldSymbols(cbSignature, typeSig, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
            {
                pSymbolsResult = pSymbols.Select(v => new CorDebugInstanceFieldSymbol(v)).ToArray();

                return hr;
            }

            fail:
            pSymbolsResult = default(CorDebugInstanceFieldSymbol[]);

            return hr;
        }

        #endregion
        #region GetMethodLocalSymbols

        /// <summary>
        /// Gets a method's local symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <returns>[out] A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.</returns>
        public CorDebugVariableSymbol[] GetMethodLocalSymbols(int nativeRVA)
        {
            CorDebugVariableSymbol[] pSymbolsResult;
            TryGetMethodLocalSymbols(nativeRVA, out pSymbolsResult).ThrowOnNotOK();

            return pSymbolsResult;
        }

        /// <summary>
        /// Gets a method's local symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="pSymbolsResult">[out] A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.</param>
        public HRESULT TryGetMethodLocalSymbols(int nativeRVA, out CorDebugVariableSymbol[] pSymbolsResult)
        {
            /*HRESULT GetMethodLocalSymbols(
            [In] int nativeRVA,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ICorDebugVariableSymbol[] pSymbols);*/
            int cRequestedSymbols = 0;
            int pcFetchedSymbols;
            ICorDebugVariableSymbol[] pSymbols;
            HRESULT hr = Raw.GetMethodLocalSymbols(nativeRVA, cRequestedSymbols, out pcFetchedSymbols, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRequestedSymbols = pcFetchedSymbols;
            pSymbols = new ICorDebugVariableSymbol[cRequestedSymbols];
            hr = Raw.GetMethodLocalSymbols(nativeRVA, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
            {
                pSymbolsResult = pSymbols.Select(v => new CorDebugVariableSymbol(v)).ToArray();

                return hr;
            }

            fail:
            pSymbolsResult = default(CorDebugVariableSymbol[]);

            return hr;
        }

        #endregion
        #region GetMethodParameterSymbols

        /// <summary>
        /// Gets a method's parameter symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <returns>[out] A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.</returns>
        public CorDebugVariableSymbol[] GetMethodParameterSymbols(int nativeRVA)
        {
            CorDebugVariableSymbol[] pSymbolsResult;
            TryGetMethodParameterSymbols(nativeRVA, out pSymbolsResult).ThrowOnNotOK();

            return pSymbolsResult;
        }

        /// <summary>
        /// Gets a method's parameter symbols given the relative virtual address (RVA) of that method.
        /// </summary>
        /// <param name="nativeRVA">[in] The native relative virtual address of the method.</param>
        /// <param name="pSymbolsResult">[out] A pointer to an <see cref="ICorDebugVariableSymbol"/> array that contains the method's local symbols.</param>
        public HRESULT TryGetMethodParameterSymbols(int nativeRVA, out CorDebugVariableSymbol[] pSymbolsResult)
        {
            /*HRESULT GetMethodParameterSymbols(
            [In] int nativeRVA,
            [In] int cRequestedSymbols,
            [Out] out int pcFetchedSymbols,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ICorDebugVariableSymbol[] pSymbols);*/
            int cRequestedSymbols = 0;
            int pcFetchedSymbols;
            ICorDebugVariableSymbol[] pSymbols;
            HRESULT hr = Raw.GetMethodParameterSymbols(nativeRVA, cRequestedSymbols, out pcFetchedSymbols, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRequestedSymbols = pcFetchedSymbols;
            pSymbols = new ICorDebugVariableSymbol[cRequestedSymbols];
            hr = Raw.GetMethodParameterSymbols(nativeRVA, cRequestedSymbols, out pcFetchedSymbols, pSymbols);

            if (hr == HRESULT.S_OK)
            {
                pSymbolsResult = pSymbols.Select(v => new CorDebugVariableSymbol(v)).ToArray();

                return hr;
            }

            fail:
            pSymbolsResult = default(CorDebugVariableSymbol[]);

            return hr;
        }

        #endregion
        #region GetMethodProps

        /// <summary>
        /// Returns information about method properties, such as the method's metadata token and information about its generic parameters, given a relative virtual address (RVA) in that method.
        /// </summary>
        /// <param name="codeRva">[in] A relative virtual address in the method about which information is to be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// To get the required size of the method's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public GetMethodPropsResult GetMethodProps(int codeRva)
        {
            GetMethodPropsResult result;
            TryGetMethodProps(codeRva, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Returns information about method properties, such as the method's metadata token and information about its generic parameters, given a relative virtual address (RVA) in that method.
        /// </summary>
        /// <param name="codeRva">[in] A relative virtual address in the method about which information is to be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// To get the required size of the method's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public HRESULT TryGetMethodProps(int codeRva, out GetMethodPropsResult result)
        {
            /*HRESULT GetMethodProps(
            [In] int codeRva,
            [Out] out mdToken pMethodToken,
            [Out] out int pcGenericParams,
            [In] int cbSignature,
            [Out] out int pcbSignature,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3), Out] byte[] signature);*/
            mdToken pMethodToken;
            int pcGenericParams;
            int cbSignature = 0;
            int pcbSignature;
            byte[] signature;
            HRESULT hr = Raw.GetMethodProps(codeRva, out pMethodToken, out pcGenericParams, cbSignature, out pcbSignature, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbSignature = pcbSignature;
            signature = new byte[cbSignature];
            hr = Raw.GetMethodProps(codeRva, out pMethodToken, out pcGenericParams, cbSignature, out pcbSignature, signature);

            if (hr == HRESULT.S_OK)
            {
                result = new GetMethodPropsResult(pMethodToken, pcGenericParams, signature);

                return hr;
            }

            fail:
            result = default(GetMethodPropsResult);

            return hr;
        }

        #endregion
        #region GetTypeProps

        /// <summary>
        /// Returns information about a type's properties, such as the number of signature of its generic parameters, given a relative virtual address (RVA) in a vtable.
        /// </summary>
        /// <param name="vtableRva">[in] A relative virtual address (RVA) in a vtable.</param>
        /// <returns>[out] A buffer that holds the typespec signatures of all generic parameters.</returns>
        /// <remarks>
        /// To get the required size of the type's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public byte[] GetTypeProps(int vtableRva)
        {
            byte[] signature;
            TryGetTypeProps(vtableRva, out signature).ThrowOnNotOK();

            return signature;
        }

        /// <summary>
        /// Returns information about a type's properties, such as the number of signature of its generic parameters, given a relative virtual address (RVA) in a vtable.
        /// </summary>
        /// <param name="vtableRva">[in] A relative virtual address (RVA) in a vtable.</param>
        /// <param name="signature">[out] A buffer that holds the typespec signatures of all generic parameters.</param>
        /// <remarks>
        /// To get the required size of the type's signature array, set the cbSignature argument to 0 and signature to null.
        /// When the method returns, pcbSignature will contain the number of bytes required for the signature array.
        /// </remarks>
        public HRESULT TryGetTypeProps(int vtableRva, out byte[] signature)
        {
            /*HRESULT GetTypeProps(
            [In] int vtableRva,
            [In] int cbSignature,
            [Out] out int pcbSignature,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] signature);*/
            int cbSignature = 0;
            int pcbSignature;
            signature = null;
            HRESULT hr = Raw.GetTypeProps(vtableRva, cbSignature, out pcbSignature, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbSignature = pcbSignature;
            signature = new byte[cbSignature];
            hr = Raw.GetTypeProps(vtableRva, cbSignature, out pcbSignature, signature);
            fail:
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
            GetCodeRangeResult result;
            TryGetCodeRange(codeRva, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the method start address and size given a relative virtual address (RVA) in a method.
        /// </summary>
        /// <param name="codeRva">[in] The relative virtual address (RVA) in a method.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetCodeRange(int codeRva, out GetCodeRangeResult result)
        {
            /*HRESULT GetCodeRange(
            [In] int codeRva,
            [Out] out int pCodeStartAddress,
            [Out] out int pCodeSize);*/
            int pCodeStartAddress;
            int pCodeSize;
            HRESULT hr = Raw.GetCodeRange(codeRva, out pCodeStartAddress, out pCodeSize);

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
            CorDebugMemoryBuffer ppMemoryBufferResult;
            TryGetAssemblyImageBytes(rva, length, out ppMemoryBufferResult).ThrowOnNotOK();

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
            /*HRESULT GetAssemblyImageBytes(
            [In] long rva,
            [In] int length,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);*/
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
            int pObjectSize;
            TryGetObjectSize(cbSignature, typeSig, out pObjectSize).ThrowOnNotOK();

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
            /*HRESULT GetObjectSize(
            [In] int cbSignature,
            [In] IntPtr typeSig,
            [Out] out int pObjectSize);*/
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
                CorDebugMemoryBuffer ppMemoryBufferResult;
                TryGetGenericDictionaryInfo(out ppMemoryBufferResult).ThrowOnNotOK();

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
            /*HRESULT GetGenericDictionaryInfo(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryBuffer ppMemoryBuffer);*/
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
            GetFramePropsResult result;
            TryGetFrameProps(codeRva, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Returns the method starting relative virtual address of a method and the parent frame given a code relative virtual address.
        /// </summary>
        /// <param name="codeRva">[in] A code relative virtual address.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetFrameProps(int codeRva, out GetFramePropsResult result)
        {
            /*HRESULT GetFrameProps(
            [In] int codeRva,
            [Out] out int pCodeStartRva,
            [Out] out int pParentFrameStartRva);*/
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

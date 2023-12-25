using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Facilitates walking the stack using the program debug database (.pdb) file.
    /// </summary>
    /// <remarks>
    /// This interface is called by the DIA code to obtain information about the executable to construct a list of stack
    /// frames during program execution. A client application implements this interface to support walking the stack during
    /// program execution. An instance of this interface is passed to the IDiaStackWalker or IDiaStackWalker methods.
    /// </remarks>
    public class DiaStackWalkHelper : ComObject<IDiaStackWalkHelper>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaStackWalkHelper"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaStackWalkHelper(IDiaStackWalkHelper raw) : base(raw)
        {
        }

        #region IDiaStackWalkHelper
        #region GetRegisterValue

        public long GetRegisterValue(int index)
        {
            long pRetVal;
            TryGetRegisterValue(index, out pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        public HRESULT TryGetRegisterValue(int index, out long pRetVal)
        {
            /*HRESULT get_registerValue(
            [In] int index,
            [Out] out long pRetVal);*/
            return Raw.get_registerValue(index, out pRetVal);
        }

        #endregion
        #region PutRegisterValue

        public void PutRegisterValue(int index, long pRetVal)
        {
            TryPutRegisterValue(index, pRetVal).ThrowOnNotOK();
        }

        public HRESULT TryPutRegisterValue(int index, long pRetVal)
        {
            /*HRESULT put_registerValue(
            [In] int index,
            [In] long pRetVal);*/
            return Raw.put_registerValue(index, pRetVal);
        }

        #endregion
        #region ReadMemory

        public byte[] ReadMemory(MemoryTypeEnum type, long va)
        {
            byte[] pbData;
            TryReadMemory(type, va, out pbData).ThrowOnNotOK();

            return pbData;
        }

        public HRESULT TryReadMemory(MemoryTypeEnum type, long va, out byte[] pbData)
        {
            /*HRESULT readMemory(
            [In] MemoryTypeEnum type,
            [In] long va,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbData);*/
            int cbData = 0;
            int pcbData;
            pbData = null;
            HRESULT hr = Raw.readMemory(type, va, cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.readMemory(type, va, cbData, out pcbData, pbData);
            fail:
            return hr;
        }

        #endregion
        #region SearchForReturnAddress

        public long SearchForReturnAddress(IDiaFrameData frame)
        {
            long returnAddress;
            TrySearchForReturnAddress(frame, out returnAddress).ThrowOnNotOK();

            return returnAddress;
        }

        public HRESULT TrySearchForReturnAddress(IDiaFrameData frame, out long returnAddress)
        {
            /*HRESULT searchForReturnAddress(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [Out] out long returnAddress);*/
            return Raw.searchForReturnAddress(frame, out returnAddress);
        }

        #endregion
        #region SearchForReturnAddressStart

        /// <summary>
        /// Searches the specified stack frame for a return address at or near the specified stack address.
        /// </summary>
        /// <param name="frame">[in] An IDiaFrameData object that represents the current stack frame.</param>
        /// <param name="startAddress">[in] A virtual memory address from which to begin searching.</param>
        /// <returns>[out] Returns the nearest function return address to startAddress.</returns>
        public long SearchForReturnAddressStart(IDiaFrameData frame, long startAddress)
        {
            long returnAddress;
            TrySearchForReturnAddressStart(frame, startAddress, out returnAddress).ThrowOnNotOK();

            return returnAddress;
        }

        /// <summary>
        /// Searches the specified stack frame for a return address at or near the specified stack address.
        /// </summary>
        /// <param name="frame">[in] An IDiaFrameData object that represents the current stack frame.</param>
        /// <param name="startAddress">[in] A virtual memory address from which to begin searching.</param>
        /// <param name="returnAddress">[out] Returns the nearest function return address to startAddress.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TrySearchForReturnAddressStart(IDiaFrameData frame, long startAddress, out long returnAddress)
        {
            /*HRESULT searchForReturnAddressStart(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [In] long startAddress,
            [Out] out long returnAddress);*/
            return Raw.searchForReturnAddressStart(frame, startAddress, out returnAddress);
        }

        #endregion
        #region FrameForVA

        public DiaFrameData FrameForVA(long va)
        {
            DiaFrameData ppFrameResult;
            TryFrameForVA(va, out ppFrameResult).ThrowOnNotOK();

            return ppFrameResult;
        }

        public HRESULT TryFrameForVA(long va, out DiaFrameData ppFrameResult)
        {
            /*HRESULT frameForVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData ppFrame);*/
            IDiaFrameData ppFrame;
            HRESULT hr = Raw.frameForVA(va, out ppFrame);

            if (hr == HRESULT.S_OK)
                ppFrameResult = ppFrame == null ? null : new DiaFrameData(ppFrame);
            else
                ppFrameResult = default(DiaFrameData);

            return hr;
        }

        #endregion
        #region SymbolForVA

        /// <summary>
        /// Retrieves the symbol that contains the specified virtual address.
        /// </summary>
        /// <param name="va">[in] The virtual address that is contained in the requested symbol. The symbol must be a SymTagFunctionType (a value from the SymTagEnum Enumeration enumeration).</param>
        /// <returns>[out] An IDiaSymbol object that represents the symbol at the specified address.</returns>
        public DiaSymbol SymbolForVA(long va)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolForVA(va, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Retrieves the symbol that contains the specified virtual address.
        /// </summary>
        /// <param name="va">[in] The virtual address that is contained in the requested symbol. The symbol must be a SymTagFunctionType (a value from the SymTagEnum Enumeration enumeration).</param>
        /// <param name="ppSymbolResult">[out] An IDiaSymbol object that represents the symbol at the specified address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TrySymbolForVA(long va, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolForVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.symbolForVA(va, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region PdataForVA

        public byte[] PdataForVA(long va)
        {
            byte[] pbData;
            TryPdataForVA(va, out pbData).ThrowOnNotOK();

            return pbData;
        }

        public HRESULT TryPdataForVA(long va, out byte[] pbData)
        {
            /*HRESULT pdataForVA(
            [In] long va,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData);*/
            int cbData = 0;
            int pcbData;
            pbData = null;
            HRESULT hr = Raw.pdataForVA(va, cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.pdataForVA(va, cbData, out pcbData, pbData);
            fail:
            return hr;
        }

        #endregion
        #region ImageForVA

        /// <summary>
        /// Returns the start of an executable's image in memory given a virtual address somewhere in the executable's memory space.
        /// </summary>
        /// <param name="vaContext">[in] The virtual address that lies somewhere in the executable's space.</param>
        /// <returns>[out] Returns the starting virtual address of the executable's image.</returns>
        public long ImageForVA(long vaContext)
        {
            long pvaImageStart;
            TryImageForVA(vaContext, out pvaImageStart).ThrowOnNotOK();

            return pvaImageStart;
        }

        /// <summary>
        /// Returns the start of an executable's image in memory given a virtual address somewhere in the executable's memory space.
        /// </summary>
        /// <param name="vaContext">[in] The virtual address that lies somewhere in the executable's space.</param>
        /// <param name="pvaImageStart">[out] Returns the starting virtual address of the executable's image.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryImageForVA(long vaContext, out long pvaImageStart)
        {
            /*HRESULT imageForVA(
            [In] long vaContext,
            [Out] out long pvaImageStart);*/
            return Raw.imageForVA(vaContext, out pvaImageStart);
        }

        #endregion
        #region AddressForVA

        public AddressForVAResult AddressForVA(long va)
        {
            AddressForVAResult result;
            TryAddressForVA(va, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryAddressForVA(long va, out AddressForVAResult result)
        {
            /*HRESULT addressForVA(
            [In] long va,
            [Out] out int pISect,
            [Out] out int pOffset);*/
            int pISect;
            int pOffset;
            HRESULT hr = Raw.addressForVA(va, out pISect, out pOffset);

            if (hr == HRESULT.S_OK)
                result = new AddressForVAResult(pISect, pOffset);
            else
                result = default(AddressForVAResult);

            return hr;
        }

        #endregion
        #region NumberOfFunctionFragmentsForVA

        public int NumberOfFunctionFragmentsForVA(long vaFunc, int cbFunc)
        {
            int pNumFragments;
            TryNumberOfFunctionFragmentsForVA(vaFunc, cbFunc, out pNumFragments).ThrowOnNotOK();

            return pNumFragments;
        }

        public HRESULT TryNumberOfFunctionFragmentsForVA(long vaFunc, int cbFunc, out int pNumFragments)
        {
            /*HRESULT numberOfFunctionFragmentsForVA(
            [In] long vaFunc,
            [In] int cbFunc,
            [Out] out int pNumFragments);*/
            return Raw.numberOfFunctionFragmentsForVA(vaFunc, cbFunc, out pNumFragments);
        }

        #endregion
        #region FunctionFragmentsForVA

        public FunctionFragmentsForVAResult FunctionFragmentsForVA(long vaFunc, int cbFunc, int cFragments)
        {
            FunctionFragmentsForVAResult result;
            TryFunctionFragmentsForVA(vaFunc, cbFunc, cFragments, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryFunctionFragmentsForVA(long vaFunc, int cbFunc, int cFragments, out FunctionFragmentsForVAResult result)
        {
            /*HRESULT functionFragmentsForVA(
            [In] long vaFunc,
            [In] int cbFunc,
            [In] int cFragments,
            [Out] out long pVaFragment,
            [Out] out int pLenFragment);*/
            long pVaFragment;
            int pLenFragment;
            HRESULT hr = Raw.functionFragmentsForVA(vaFunc, cbFunc, cFragments, out pVaFragment, out pLenFragment);

            if (hr == HRESULT.S_OK)
                result = new FunctionFragmentsForVAResult(pVaFragment, pLenFragment);
            else
                result = default(FunctionFragmentsForVAResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDiaStackWalkHelper2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaStackWalkHelper2 Raw2 => (IDiaStackWalkHelper2) Raw;

        #region GetPointerAuthenticationMask

        public long GetPointerAuthenticationMask(long ptrVal)
        {
            long authMask;
            TryGetPointerAuthenticationMask(ptrVal, out authMask).ThrowOnNotOK();

            return authMask;
        }

        public HRESULT TryGetPointerAuthenticationMask(long ptrVal, out long authMask)
        {
            /*HRESULT GetPointerAuthenticationMask(
            [In] long PtrVal,
            [Out] out long AuthMask);*/
            return Raw2.GetPointerAuthenticationMask(ptrVal, out authMask);
        }

        #endregion
        #endregion
    }
}

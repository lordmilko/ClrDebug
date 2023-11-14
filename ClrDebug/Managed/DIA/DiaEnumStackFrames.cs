namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various stack frames available.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the IDiaStackWalker or IDiaStackWalker methods.
    /// </remarks>
    public class DiaEnumStackFrames : ComObject<IDiaEnumStackFrames>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumStackFrames"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumStackFrames(IDiaEnumStackFrames raw) : base(raw)
        {
        }

        #region IDiaEnumStackFrames
        #region Next

        /// <summary>
        /// Retrieves a specified number of stack frame elements from the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of stackframe elements in the enumerator to be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public NextResult Next(int celt)
        {
            NextResult result;
            TryNext(celt, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves a specified number of stack frame elements from the enumeration sequence.
        /// </summary>
        /// <param name="celt">[in] The number of stackframe elements in the enumerator to be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more stack frames. Otherwise, returns an error code.</returns>
        public HRESULT TryNext(int celt, out NextResult result)
        {
            /*HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaStackFrame rgelt,
            [Out] out int pceltFetched);*/
            IDiaStackFrame rgelt;
            int pceltFetched;
            HRESULT hr = Raw.Next(celt, out rgelt, out pceltFetched);

            if (hr == HRESULT.S_OK)
                result = new NextResult(new DiaStackFrame(rgelt), pceltFetched);
            else
                result = default(NextResult);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowOnNotOK();
        }

        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns>Returns S_OK.</returns>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}

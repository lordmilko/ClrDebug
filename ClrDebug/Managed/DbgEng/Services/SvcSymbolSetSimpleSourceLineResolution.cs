namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a "simple interface" around the mapping of lines of code to addresses within the image and vice-versa.<para/>
    /// This is an optional interface for symbol sets to implement.
    /// </summary>
    public class SvcSymbolSetSimpleSourceLineResolution : ComObject<ISvcSymbolSetSimpleSourceLineResolution>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetSimpleSourceLineResolution"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetSimpleSourceLineResolution(ISvcSymbolSetSimpleSourceLineResolution raw) : base(raw)
        {
        }

        #region ISvcSymbolSetSimpleSourceLineResolution
        #region FindOffsetBySourceLine

        /// <summary>
        /// Finds the offset for the given line within the image. If there are multiple mappings for the given line, this will return the first/best (depending on the underlying provider) and return S_FALSE as an indication that a more in-depth query with more advanced interfaces are required.<para/>
        /// If there are no mappings for the given line but are for later lines in source, this will return the nearest matching source line (after the given one).<para/>
        /// The actual mapped line of the offset will be optionally returned to the caller. The *sourceFileName* argument may pass either - A path (full or relative) to the source file as returned from the symbol information in a call to FindSourceLineByOffset.<para/>
        /// - The file name. If the file name is not unique in the symbolic information, this method will fail and requires an explicit path.<para/>
        /// The actual name recorded in symbols (potentially a full path) can also optionally be returned in actualSourceFileName.
        /// </summary>
        public FindOffsetBySourceLineResult FindOffsetBySourceLine(string sourceFileName, long line)
        {
            FindOffsetBySourceLineResult result;
            TryFindOffsetBySourceLine(sourceFileName, line, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Finds the offset for the given line within the image. If there are multiple mappings for the given line, this will return the first/best (depending on the underlying provider) and return S_FALSE as an indication that a more in-depth query with more advanced interfaces are required.<para/>
        /// If there are no mappings for the given line but are for later lines in source, this will return the nearest matching source line (after the given one).<para/>
        /// The actual mapped line of the offset will be optionally returned to the caller. The *sourceFileName* argument may pass either - A path (full or relative) to the source file as returned from the symbol information in a call to FindSourceLineByOffset.<para/>
        /// - The file name. If the file name is not unique in the symbolic information, this method will fail and requires an explicit path.<para/>
        /// The actual name recorded in symbols (potentially a full path) can also optionally be returned in actualSourceFileName.
        /// </summary>
        public HRESULT TryFindOffsetBySourceLine(string sourceFileName, long line, out FindOffsetBySourceLineResult result)
        {
            /*HRESULT FindOffsetBySourceLine(
            [In, MarshalAs(UnmanagedType.LPWStr)] string sourceFileName,
            [In] long line,
            [Out] out long moduleOffset,
            [Out, MarshalAs(UnmanagedType.BStr)] out string actualSourceFileName,
            [Out] out long returnedLine);*/
            long moduleOffset;
            string actualSourceFileName;
            long returnedLine;
            HRESULT hr = Raw.FindOffsetBySourceLine(sourceFileName, line, out moduleOffset, out actualSourceFileName, out returnedLine);

            if (hr == HRESULT.S_OK)
                result = new FindOffsetBySourceLineResult(moduleOffset, actualSourceFileName, returnedLine);
            else
                result = default(FindOffsetBySourceLineResult);

            return hr;
        }

        #endregion
        #region FindSourceLineByOffset

        /// <summary>
        /// Finds the source line for a given offset within the image. If there are multiple mappings for the given line, this will return the first/best (depending on the underlying provider) and return S_FALSE as an indication that a more in-depth query with more advanced interfaces are required.<para/>
        /// The returned *sourceFileName* may be a file name or a path depending on what was actually recorded in the symbolic information by the original compiler which produced symbols.<para/>
        /// The returned lineDisplacement value is the number of bytes that 'moduleOffset' is from the first code byte of the given source line.<para/>
        /// In the event that the symbol provider has information for the given offset but it is unattributable to user code (e.g.: it is compiler generated), the special HRESULT S_UNATTRIBUTABLE_RESULT should be returned from the method.<para/>
        /// In this case sourceFileName : This may be set to nullptr sourceLine : This should be zero lineDisplacement: This may be valid to indicate an offset from the start of some compiler generated instructions, etc...<para/>
        /// It may also simply be zero.
        /// </summary>
        public FindSourceLineByOffsetResult FindSourceLineByOffset(long moduleOffset)
        {
            FindSourceLineByOffsetResult result;
            TryFindSourceLineByOffset(moduleOffset, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Finds the source line for a given offset within the image. If there are multiple mappings for the given line, this will return the first/best (depending on the underlying provider) and return S_FALSE as an indication that a more in-depth query with more advanced interfaces are required.<para/>
        /// The returned *sourceFileName* may be a file name or a path depending on what was actually recorded in the symbolic information by the original compiler which produced symbols.<para/>
        /// The returned lineDisplacement value is the number of bytes that 'moduleOffset' is from the first code byte of the given source line.<para/>
        /// In the event that the symbol provider has information for the given offset but it is unattributable to user code (e.g.: it is compiler generated), the special HRESULT S_UNATTRIBUTABLE_RESULT should be returned from the method.<para/>
        /// In this case sourceFileName : This may be set to nullptr sourceLine : This should be zero lineDisplacement: This may be valid to indicate an offset from the start of some compiler generated instructions, etc...<para/>
        /// It may also simply be zero.
        /// </summary>
        public HRESULT TryFindSourceLineByOffset(long moduleOffset, out FindSourceLineByOffsetResult result)
        {
            /*HRESULT FindSourceLineByOffset(
            [In] long moduleOffset,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFileName,
            [Out] out long sourceLine,
            [Out] out long lineDisplacement);*/
            string sourceFileName;
            long sourceLine;
            long lineDisplacement;
            HRESULT hr = Raw.FindSourceLineByOffset(moduleOffset, out sourceFileName, out sourceLine, out lineDisplacement);

            if (hr == HRESULT.S_OK)
                result = new FindSourceLineByOffsetResult(sourceFileName, sourceLine, lineDisplacement);
            else
                result = default(FindSourceLineByOffsetResult);

            return hr;
        }

        #endregion
        #endregion
    }
}

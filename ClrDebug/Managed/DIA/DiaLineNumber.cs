namespace ClrDebug.DIA
{
    /// <summary>
    /// Accesses information that describes the process of mapping from a block of bytes of image text to a source file line number.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the IDiaEnumLineNumbers or IDiaEnumLineNumbers methods.
    /// </remarks>
    public class DiaLineNumber : ComObject<IDiaLineNumber>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaLineNumber"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaLineNumber(IDiaLineNumber raw) : base(raw)
        {
        }

        #region IDiaLineNumber
        #region Compiland

        /// <summary>
        /// Retrieves a reference to the symbol for the compiland that contributed the bytes of image text.
        /// </summary>
        public DiaSymbol Compiland
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetCompiland(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a reference to the symbol for the compiland that contributed the bytes of image text.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object for the compiland that contributed the bytes of image text.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetCompiland(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_compiland(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_compiland(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region SourceFile

        /// <summary>
        /// Retrieves a reference to the source file.
        /// </summary>
        public DiaSourceFile SourceFile
        {
            get
            {
                DiaSourceFile pRetValResult;
                TryGetSourceFile(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a reference to the source file.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSourceFile object that represents the source file.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetSourceFile(out DiaSourceFile pRetValResult)
        {
            /*HRESULT get_sourceFile(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile pRetVal);*/
            IDiaSourceFile pRetVal;
            HRESULT hr = Raw.get_sourceFile(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new DiaSourceFile(pRetVal);
            else
                pRetValResult = default(DiaSourceFile);

            return hr;
        }

        #endregion
        #region LineNumber

        /// <summary>
        /// Retrieves the line number in the source file.
        /// </summary>
        public int LineNumber
        {
            get
            {
                int pRetVal;
                TryGetLineNumber(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the line number in the source file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the line number in the source file.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetLineNumber(out int pRetVal)
        {
            /*HRESULT get_lineNumber(
            [Out] out int pRetVal);*/
            return Raw.get_lineNumber(out pRetVal);
        }

        #endregion
        #region LineNumberEnd

        /// <summary>
        /// Retrieves the one-based source line number where the statement or expression ends.
        /// </summary>
        public int LineNumberEnd
        {
            get
            {
                int pRetVal;
                TryGetLineNumberEnd(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the one-based source line number where the statement or expression ends.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the line number where the statement or expression ends. If the value is zero, then the end information is not present.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetLineNumberEnd(out int pRetVal)
        {
            /*HRESULT get_lineNumberEnd(
            [Out] out int pRetVal);*/
            return Raw.get_lineNumberEnd(out pRetVal);
        }

        #endregion
        #region ColumnNumber

        /// <summary>
        /// Retrieves the column number where the expression or statement begins.
        /// </summary>
        public int ColumnNumber
        {
            get
            {
                int pRetVal;
                TryGetColumnNumber(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the column number where the expression or statement begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the column number where the expression or statement begins. If the value is zero, then column information is not present.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The column value returned by this method is a byte offset into the line to the first character of the statement
        /// on the line.
        /// </remarks>
        public HRESULT TryGetColumnNumber(out int pRetVal)
        {
            /*HRESULT get_columnNumber(
            [Out] out int pRetVal);*/
            return Raw.get_columnNumber(out pRetVal);
        }

        #endregion
        #region ColumnNumberEnd

        /// <summary>
        /// Retrieves the one-based source column number where the expression or statement ends.
        /// </summary>
        public int ColumnNumberEnd
        {
            get
            {
                int pRetVal;
                TryGetColumnNumberEnd(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the one-based source column number where the expression or statement ends.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the column number where the expression or statement ends. If the value is zero, then the column end information is not present.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The column value returned by this method is a byte offset into the line to the position after the last character
        /// of the statement on the line.
        /// </remarks>
        public HRESULT TryGetColumnNumberEnd(out int pRetVal)
        {
            /*HRESULT get_columnNumberEnd(
            [Out] out int pRetVal);*/
            return Raw.get_columnNumberEnd(out pRetVal);
        }

        #endregion
        #region AddressSection

        /// <summary>
        /// Retrieves the section part of the memory address where a block begins.
        /// </summary>
        public int AddressSection
        {
            get
            {
                int pRetVal;
                TryGetAddressSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the section part of the memory address where a block begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the memory address where a block begins.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAddressSection(out int pRetVal)
        {
            /*HRESULT get_addressSection(
            [Out] out int pRetVal);*/
            return Raw.get_addressSection(out pRetVal);
        }

        #endregion
        #region AddressOffset

        /// <summary>
        /// Retrieves the offset part of the memory address where a block begins.
        /// </summary>
        public int AddressOffset
        {
            get
            {
                int pRetVal;
                TryGetAddressOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset part of the memory address where a block begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the memory address where a block begins.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAddressOffset(out int pRetVal)
        {
            /*HRESULT get_addressOffset(
            [Out] out int pRetVal);*/
            return Raw.get_addressOffset(out pRetVal);
        }

        #endregion
        #region RelativeVirtualAddress

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the block.
        /// </summary>
        public int RelativeVirtualAddress
        {
            get
            {
                int pRetVal;
                TryGetRelativeVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the image-relative virtual address of the block.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_relativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region VirtualAddress

        /// <summary>
        /// Retrieves the virtual address (VA) of the block.
        /// </summary>
        public long VirtualAddress
        {
            get
            {
                long pRetVal;
                TryGetVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the virtual address (VA) of the block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the block.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_virtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_virtualAddress(out pRetVal);
        }

        #endregion
        #region Length

        /// <summary>
        /// Retrieves the number of bytes in a block.
        /// </summary>
        public int Length
        {
            get
            {
                int pRetVal;
                TryGetLength(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bytes in a block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes in a block.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The block is the length of source code on the line as represented by the IDiaLineNumber object.
        /// </remarks>
        public HRESULT TryGetLength(out int pRetVal)
        {
            /*HRESULT get_length(
            [Out] out int pRetVal);*/
            return Raw.get_length(out pRetVal);
        }

        #endregion
        #region SourceFileId

        /// <summary>
        /// Retrieves a unique source file identifier for the source file that contributed this line.
        /// </summary>
        public int SourceFileId
        {
            get
            {
                int pRetVal;
                TryGetSourceFileId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a unique source file identifier for the source file that contributed this line.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the unique source file identifier for the source file that contributed this line.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetSourceFileId(out int pRetVal)
        {
            /*HRESULT get_sourceFileId(
            [Out] out int pRetVal);*/
            return Raw.get_sourceFileId(out pRetVal);
        }

        #endregion
        #region Statement

        /// <summary>
        /// Retrieves a flag indicating that this line information describes the beginning of a statement, rather than an expression, in the program source.
        /// </summary>
        public bool Statement
        {
            get
            {
                bool pRetVal;
                TryGetStatement(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag indicating that this line information describes the beginning of a statement, rather than an expression, in the program source.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if this line information describes the beginning of a statement in the program source.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// Statements can span multiple lines. This method indicates if the associated line number marks the beginning of
        /// such a multi-line statement.
        /// </remarks>
        public HRESULT TryGetStatement(out bool pRetVal)
        {
            /*HRESULT get_statement(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_statement(out pRetVal);
        }

        #endregion
        #region CompilandId

        /// <summary>
        /// Retrieves a unique identifier for the compiland that contributed this line.
        /// </summary>
        public int CompilandId
        {
            get
            {
                int pRetVal;
                TryGetCompilandId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a unique identifier for the compiland that contributed this line.
        /// </summary>
        /// <param name="pRetVal">[out] Returns DWORD that contains the unique identifier for the compiland that contributed this line.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetCompilandId(out int pRetVal)
        {
            /*HRESULT get_compilandId(
            [Out] out int pRetVal);*/
            return Raw.get_compilandId(out pRetVal);
        }

        #endregion
        #endregion
    }
}

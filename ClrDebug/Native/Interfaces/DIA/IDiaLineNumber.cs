using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Accesses information that describes the process of mapping from a block of bytes of image text to a source file line number.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the IDiaEnumLineNumbers or IDiaEnumLineNumbers methods.
    /// </remarks>
    [Guid("B388EB14-BE4D-421D-A8A1-6CF7AB057086")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaLineNumber
    {
        /// <summary>
        /// Retrieves a reference to the symbol for the compiland that contributed the bytes of image text.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSymbol object for the compiland that contributed the bytes of image text.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_compiland(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);

        /// <summary>
        /// Retrieves a reference to the source file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns an IDiaSourceFile object that represents the source file.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_sourceFile(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile pRetVal);

        /// <summary>
        /// Retrieves the line number in the source file.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the line number in the source file.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_lineNumber(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the one-based source line number where the statement or expression ends.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the line number where the statement or expression ends. If the value is zero, then the end information is not present.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_lineNumberEnd(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the column number where the expression or statement begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the column number where the expression or statement begins. If the value is zero, then column information is not present.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The column value returned by this method is a byte offset into the line to the first character of the statement
        /// on the line.
        /// </remarks>
        [PreserveSig]
        HRESULT get_columnNumber(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the one-based source column number where the expression or statement ends.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the column number where the expression or statement ends. If the value is zero, then the column end information is not present.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The column value returned by this method is a byte offset into the line to the position after the last character
        /// of the statement on the line.
        /// </remarks>
        [PreserveSig]
        HRESULT get_columnNumberEnd(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the section part of the memory address where a block begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the memory address where a block begins.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_addressSection(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the offset part of the memory address where a block begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the memory address where a block begins.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_addressOffset(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the image-relative virtual address of the block.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the virtual address (VA) of the block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the block.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_virtualAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the number of bytes in a block.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes in a block.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The block is the length of source code on the line as represented by the IDiaLineNumber object.
        /// </remarks>
        [PreserveSig]
        HRESULT get_length(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a unique source file identifier for the source file that contributed this line.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the unique source file identifier for the source file that contributed this line.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_sourceFileId(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a flag indicating that this line information describes the beginning of a statement, rather than an expression, in the program source.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if this line information describes the beginning of a statement in the program source.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// Statements can span multiple lines. This method indicates if the associated line number marks the beginning of
        /// such a multi-line statement.
        /// </remarks>
        [PreserveSig]
        HRESULT get_statement(
            [Out] out bool pRetVal);

        /// <summary>
        /// Retrieves a unique identifier for the compiland that contributed this line.
        /// </summary>
        /// <param name="pRetVal">[out] Returns DWORD that contains the unique identifier for the compiland that contributed this line.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_compilandId(
            [Out] out int pRetVal);
    }
}

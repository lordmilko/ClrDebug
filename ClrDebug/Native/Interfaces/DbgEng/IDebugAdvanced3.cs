using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("cba4abb4-84c4-444d-87ca-a04e13286739")]
    [ComImport]
    public interface IDebugAdvanced3 : IDebugAdvanced2
    {
        #region IDebugAdvanced

        /// <summary>
        /// The GetThreadContext method returns the current thread context.
        /// </summary>
        /// <param name="Context">[out] Receives the current thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="ContextSize">[in] Specifies the size of the buffer Context.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        /// <summary>
        /// The SetThreadContext method sets the current thread context.
        /// </summary>
        /// <param name="Context">[in] Specifies the thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="ContextSize">[in] Specifies the size of the buffer Context.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        #endregion
        #region IDebugAdvanced2

        /// <summary>
        /// The Request method performs a variety of different operations.
        /// </summary>
        /// <param name="Request">[in] Specifies which operation to perform. Request can be one of the values in the following table. Details of each operation can be found by following the link in the "Request" column.<para/>
        /// DEBUG_REQUEST_SOURCE_PATH_HAS_SOURCE_SERVER DEBUG_REQUEST_TARGET_EXCEPTION_CONTEXT DEBUG_REQUEST_TARGET_EXCEPTION_THREAD DEBUG_REQUEST_TARGET_EXCEPTION_RECORD DEBUG_REQUEST_GET_ADDITIONAL_CREATE_OPTIONS DEBUG_REQUEST_SET_ADDITIONAL_CREATE_OPTIONS DEBUG_REQUEST_GET_WIN32_MAJOR_MINOR_VERSIONS DEBUG_REQUEST_READ_USER_MINIDUMP_STREAM DEBUG_REQUEST_TARGET_CAN_DETACH DEBUG_REQUEST_SET_LOCAL_IMPLICIT_COMMAND_LINE DEBUG_REQUEST_GET_CAPTURED_EVENT_CODE_OFFSET DEBUG_REQUEST_READ_CAPTURED_EVENT_CODE_STREAM DEBUG_REQUEST_EXT_TYPED_DATA_ANSI</param>
        /// <param name="InBuffer">[in, optional] Specifies the input to this method. The type and interpretation of the input depends on the Request parameter.</param>
        /// <param name="InBufferSize">[in] Specifies the size of the input buffer InBuffer. If the request requires no input, InBufferSize should be set to zero.</param>
        /// <param name="OutBuffer">[out, optional] Receives the output from this method. The type and interpretation of the output depends on the Request parameter.<para/>
        /// If OutBuffer is NULL, the output is not returned.</param>
        /// <param name="OutBufferSize">[in] Specifies the size of the output buffer OutBufferSize. If the type of the output returned to OutBuffer has a known size, OutBufferSize is usually expected to be exactly that size, even if OutBuffer is set to NULL.</param>
        /// <param name="OutSize">[out, optional] Receives the size of the output returned in the output buffer OutBuffer. If OutSize is NULL, this information is not returned.</param>
        /// <returns>The interpretation of the return value depends on the value of the Request parameter. Unless otherwise stated, the following values may be returned.<para/>
        /// This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT Request(
            [In] DEBUG_REQUEST Request,
            [In] IntPtr InBuffer,
            [In] int InBufferSize,
            [Out] IntPtr OutBuffer,
            [In] int OutBufferSize,
            [Out] out int OutSize);

        /// <summary>
        /// The GetSourceFileInformation method returns specified information about a source file.
        /// </summary>
        /// <param name="Which">[in] Specifies the piece of information to return. The Which parameter can take one of the values in the following table.<para/>
        /// Returns a token representing the specified source file on a source server. This token can be passed to <see cref="FindSourceFileAndToken"/> to retrieve information about the file.<para/>
        /// The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the size of the SrcSrv token.<para/>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and its command-line parameters.<para/>
        /// The command is returned to the Buffer buffer as a Unicode string.</param>
        /// <param name="SourceFile">[in] Specifies the source file whose information is being requested. The source file is looked up on all the source servers in the source path.</param>
        /// <param name="Arg64">[in] Specifies a 64-bit argument. The value of Which specifies the module whose symbol token is requested. Regardless of the value of Which, Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="Arg32">[in] Specifies a 32-bit argument. This parameter is currently unused.</param>
        /// <param name="Buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the Buffer buffer. If Buffer is NULL, BufferSize must also be NULL.</param>
        /// <param name="InfoSize">[out, optional] Specifies the size in bytes of the information returned to the Buffer buffer. This parameter can be NULL if the data is not required.<para/>
        /// Returns a token representing the specified source file on a source server. This token can be passed to <see cref="FindSourceFileAndToken"/> to retrieve information about the file.<para/>
        /// The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the size of the SrcSrv token.<para/>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and its command-line parameters.<para/>
        /// The command is returned to the Buffer buffer as a Unicode string.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetSourceFileInformation(
            [In] DEBUG_SRCFILE Which,
            [In, MarshalAs(UnmanagedType.LPStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        /// <summary>
        /// The FindSourceFileAndToken method returns the filename of a source file on the source path or return the value of a variable associated with a file token.
        /// </summary>
        /// <param name="StartElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path. StartElement is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags.</param>
        /// <param name="ModAddr">[in] Specifies a location within the memory allocation of the module in the target to which the source file is related.<para/>
        /// ModAddr is used for caching the search results and when querying source servers for the file. ModAddr can be NULL.<para/>
        /// ModAddr is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags. And it is not used for querying source servers if FileToken is not NULL.</param>
        /// <param name="File">[in] Specifies the path and filename of the file to search for. If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, the file is already specified by the token in FileToken.<para/>
        /// In this case, File specifies the name of a variable on the source server related to the file. The variable must begin and end with the percent sign ( % ), for example, %SRCSRVCMD%.<para/>
        /// The value of this variable is returned.</param>
        /// <param name="Flags">[in] Specifies the flags that control the behavior of this method. For a description of these flags, see Remarks.</param>
        /// <param name="FileToken">[in, optional] Specifies a file token representing a file on a source server. A file token can be obtained by setting Which to DEBUG_SRCFILE_SYMBOL_TOKEN in the method <see cref="GetSourceFileInformation"/>.<para/>
        /// If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, FileToken must not be NULL.</param>
        /// <param name="FileTokenSize">[in] Specifies the size in bytes of the FileToken token. If FileToken is NULL, this parameter is ignored.</param>
        /// <param name="FoundElement">[out, optional] Receives the index of the element within the source path that contained the file. If the file was found directly on the filing system (not using the source path), -1 is returned to FoundElement.<para/>
        /// If FoundElement is NULL or Flags contain DEBUG_SRCFILE_SYMBOL_TOKEN, this information is not returned.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the file that was found. If the file is not on a source server, this is the name of the file in the local source cache.<para/>
        /// If the flag DEBUG_FIND_SOURCE_FULL_PATH is set, this is the full canonical path name for the file. Otherwise, it is the concatenation of the directory in the source path with the tail of File that was used to find the file.<para/>
        /// If the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, Buffer receives the value of the variable named File associated with the file token FileToken.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the Buffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If Buffer is NULL, this parameter is ignored.</param>
        /// <param name="FoundSize">[out, optional] Specifies the size in characters of the name of the file. This size includes the space for the '\0' terminating character.<para/>
        /// If foundSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, this method does not search for a file on the source
        /// path. Instead, it looks up a variable associated with the file token provided in FileToken. These variables are
        /// documented in the topic Language Specification 1. For example, to retrieve the value of the variable SRCSRVCMD--the
        /// command to extract the source file from source control (also returned by the DEBUG_SRCFILE_SYMBOL_TOKEN_SOURCE_COMMAND_WIDE
        /// function of <see cref="GetSourceFileInformation"/>)--set File to %SRCSRVCMD%. The engine uses the following steps--in
        /// order--to search for the file: The first match found is returned. If the flag DEBUG_FIND_SOURCE_BEST_MATCH is set,
        /// the match with the longest overlap is returned; otherwise, the first match is returned. The first match found is
        /// returned. The DEBUG_FIND_SOURCE_XXX bit-flags are used to control the behavior of the methods <see cref="IDebugSymbols.FindSourceFile"/>
        /// and FindSourceFileAndToken when searching for source files. The flags can be any combination of values from the
        /// following table. If not set and the source path contains relative directories, relative path names can be returned.
        /// If this flag is set, the other flags are ignored. This flag cannot be used in the <see cref="IDebugSymbols.FindSourceFile"/>
        /// method. The value DEBUG_FIND_SOURCE_DEFULT defines the default set of flags, which means that all of the flags
        /// in the previous table are turned off.
        /// </remarks>
        [PreserveSig]
        new HRESULT FindSourceFileAndToken(
            [In] uint StartElement,
            [In] ulong ModAddr,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] IntPtr FileToken,
            [In] int FileTokenSize,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);

        /// <summary>
        /// The GetSymbolInformation method returns specified information about a symbol.
        /// </summary>
        /// <param name="Which">[in] Specifies the piece of information to return. Which can take one of the values in the follow table. No string is returned and StringBuffer, StringBufferSize, and StringSize must all be set to zero.</param>
        /// <param name="Arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Ignored.<para/>
        /// The base address of the module whose description is being requested. Specifies the address in the target's memory of the symbol whose name is being requested.<para/>
        /// Specifies the module whose symbols are requested. Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="Arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine breakpoint ID of the desired breakpoint.<para/>
        /// Set to zero. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation.</param>
        /// <param name="Buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in bytes, of the buffer Buffer.</param>
        /// <param name="InfoSize">[out, optional] If this method returns S_OK, InfoSize receives the size, in bytes, of the symbol information returned to Buffer.<para/>
        /// If this method returns S_FALSE, the supplied buffer is not big enough, and InfoSize receives the required buffer size.<para/>
        /// If InfoSize is NULL, this information is not returned.</param>
        /// <param name="StringBuffer">[out, optional] Receives the requested string. The interpretation of this string depends on the value of Which.<para/>
        /// If StringBuffer is NULL, this information is not returned.</param>
        /// <param name="StringBufferSize">[in] Specifies the size, in characters, of the string buffer StringBuffer.</param>
        /// <param name="StringSize">[out, optional] Receives the size, in characters, of the string returned to StringBuffer. If StringSize is NULL, this information is not returned.<para/>
        /// The engine breakpoint ID of the desired breakpoint. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. Set to zero. Ignored. Specifies the module whose symbols are requested.<para/>
        /// Arg64 is a location within the memory allocation of the module. Specifies the address in the target's memory of the symbol whose name is being requested.<para/>
        /// The base address of the module whose description is being requested.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT GetSymbolInformation(
            [In] DEBUG_SYMINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder StringBuffer,
            [In] int StringBufferSize,
            [Out] out int StringSize);

        /// <summary>
        /// The GetSystemObjectInformation method returns information about operating system objects on the target.
        /// </summary>
        /// <param name="Which">[in] Specifies the type of object and the type of information to return about that object. Which can take the following value.</param>
        /// <param name="Arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Not used.</param>
        /// <param name="Arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine thread ID of the desired thread.</param>
        /// <param name="Buffer">[out, optional] Receives the requested information. The type of data returned in Buffer depends on the value of Which.<para/>
        /// <see cref="DEBUG_THREAD_BASIC_INFORMATION"/></param>
        /// <param name="BufferSize">[in] Specifies the size, in bytes, of the buffer Buffer.</param>
        /// <param name="InfoSize">[out, optional] Receives the size of the information that is returned. The engine thread ID of the desired thread.<para/>
        /// Not used.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        new HRESULT GetSystemObjectInformation(
            [In] DEBUG_SYSOBJINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        #endregion
        #region IDebugAdvanced3

        /// <summary>
        /// The GetSourceFileInformationWide method returns specified information about a source file.
        /// </summary>
        /// <param name="Which">[in] Specifies the piece of information to return. The Which parameter can take one of the values in the following table.<para/>
        /// Returns a token representing the specified source file on a source server. This token can be passed to <see cref="FindSourceFileAndToken"/> to retrieve information about the file.<para/>
        /// The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the size of the SrcSrv token.<para/>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and its command-line parameters.<para/>
        /// The command is returned to the Buffer buffer as a Unicode string.</param>
        /// <param name="SourceFile">[in] Specifies the source file whose information is being requested. The source file is looked up on all the source servers in the source path.</param>
        /// <param name="Arg64">[in] Specifies a 64-bit argument. The value of Which specifies the module whose symbol token is requested. Regardless of the value of Which, Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="Arg32">[in] Specifies a 32-bit argument. This parameter is currently unused.</param>
        /// <param name="Buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in bytes of the Buffer buffer. If Buffer is NULL, BufferSize must also be NULL.</param>
        /// <param name="InfoSize">[out, optional] Specifies the size in bytes of the information returned to the Buffer buffer. This parameter can be NULL if the data is not required.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSourceFileInformationWide(
            [In] DEBUG_SRCFILE Which,
            [In, MarshalAs(UnmanagedType.LPWStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);

        /// <summary>
        /// The FindSourceFileAndTokenWide method returns the filename of a source file on the source path or return the value of a variable associated with a file token.
        /// </summary>
        /// <param name="StartElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path. StartElement is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags.</param>
        /// <param name="ModAddr">[in] Specifies a location within the memory allocation of the module in the target to which the source file is related.<para/>
        /// ModAddr is used for caching the search results and when querying source servers for the file. ModAddr can be NULL.<para/>
        /// ModAddr is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags. And it is not used for querying source servers if FileToken is not NULL.</param>
        /// <param name="File">[in] Specifies the path and filename of the file to search for. If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, the file is already specified by the token in FileToken.<para/>
        /// In this case, File specifies the name of a variable on the source server related to the file. The variable must begin and end with the percent sign ( % ), for example, %SRCSRVCMD%.<para/>
        /// The value of this variable is returned.</param>
        /// <param name="Flags">[in] Specifies the flags that control the behavior of this method. For a description of these flags, see DEBUG_FIND_SOURCE_XXX.</param>
        /// <param name="FileToken">[in, optional] Specifies a file token representing a file on a source server. A file token can be obtained by setting Which to DEBUG_SRCFILE_SYMBOL_TOKEN in the method <see cref="GetSourceFileInformation"/>.<para/>
        /// If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, FileToken must not be NULL.</param>
        /// <param name="FileTokenSize">[in] Specifies the size in bytes of the FileToken token. If FileToken is NULL, this parameter is ignored.</param>
        /// <param name="FoundElement">[out, optional] Receives the index of the element within the source path that contained the file. If the file was found directly on the filing system (not using the source path), -1 is returned to FoundElement.<para/>
        /// If FoundElement is NULL or Flags contain DEBUG_SRCFILE_SYMBOL_TOKEN, this information is not returned.</param>
        /// <param name="Buffer">[out, optional] Receives the name of the file that was found. If the file is not on a source server, this is the name of the file in the local source cache.<para/>
        /// If the flag DEBUG_FIND_SOURCE_FULL_PATH is set, this is the full canonical path name for the file. Otherwise, it is the concatenation of the directory in the source path with the tail of File that was used to find the file.<para/>
        /// If the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, Buffer receives the value of the variable named File associated with the file token FileToken.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the Buffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If Buffer is NULL, this parameter is ignored.</param>
        /// <param name="FoundSize">[out, optional] Specifies the size in characters of the name of the file. This size includes the space for the '\0' terminating character.<para/>
        /// If foundSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, this method does not search for a file on the source
        /// path. Instead, it looks up a variable associated with the file token provided in FileToken. These variables are
        /// documented in the topic Language Specification 1. For example, to retrieve the value of the variable SRCSRVCMD--the
        /// command to extract the source file from source control (also returned by the DEBUG_SRCFILE_SYMBOL_TOKEN_SOURCE_COMMAND_WIDE
        /// function of <see cref="GetSourceFileInformation"/>)--set File to %SRCSRVCMD%. The engine uses the following steps--in
        /// order--to search for the file: The first match found is returned. If the flag DEBUG_FIND_SOURCE_BEST_MATCH is set,
        /// the match with the longest overlap is returned; otherwise, the first match is returned. The first match found is
        /// returned.
        /// </remarks>
        [PreserveSig]
        HRESULT FindSourceFileAndTokenWide(
            [In] uint StartElement,
            [In] ulong ModAddr,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] IntPtr FileToken,
            [In] int FileTokenSize,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);

        /// <summary>
        /// The SetSymbolInformationWide method returns specified information about a symbol.
        /// </summary>
        /// <param name="Which">[in] Specifies the piece of information to return. Which can take one of the values in the follow table. No string is returned and StringBuffer, StringBufferSize, and StringSize must all be set to zero.</param>
        /// <param name="Arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Ignored.<para/>
        /// The base address of the module whose description is being requested. Specifies the address in the target's memory of the symbol whose name is being requested.<para/>
        /// Specifies the module whose symbols are requested. Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="Arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine breakpoint ID of the desired breakpoint.<para/>
        /// Set to zero. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation.</param>
        /// <param name="Buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size, in bytes, of the buffer Buffer.</param>
        /// <param name="InfoSize">[out, optional] If this method returns S_OK, InfoSize receives the size, in bytes, of the symbol information returned to Buffer.<para/>
        /// If this method returns S_FALSE, the supplied buffer is not big enough, and InfoSize receives the required buffer size.<para/>
        /// If InfoSize is NULL, this information is not returned.</param>
        /// <param name="StringBuffer">[out, optional] Receives the requested string. The interpretation of this string depends on the value of Which.<para/>
        /// If StringBuffer is NULL, this information is not returned.</param>
        /// <param name="StringBufferSize">[in] Specifies the size, in characters, of the string buffer StringBuffer.</param>
        /// <param name="StringSize">[out, optional] Receives the size, in characters, of the string returned to StringBuffer. If StringSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        [PreserveSig]
        HRESULT GetSymbolInformationWide(
            [In] DEBUG_SYMINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringBuffer,
            [In] int StringBufferSize,
            [Out] out int StringSize);

        #endregion
    }
}

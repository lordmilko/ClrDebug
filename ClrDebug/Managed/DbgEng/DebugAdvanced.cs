using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugAdvanced : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugAdvanced = new Guid("f2df5f53-071f-47bd-9de6-5734c3fed689");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugAdvancedVtbl* Vtbl => (IDebugAdvancedVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugAdvanced2Vtbl* Vtbl2 => (IDebugAdvanced2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugAdvanced3Vtbl* Vtbl3 => (IDebugAdvanced3Vtbl*) base.Vtbl;

        #endregion
        
        public DebugAdvanced(IntPtr raw) : base(raw, IID_IDebugAdvanced)
        {
        }

        public DebugAdvanced(IDebugAdvanced raw) : base(raw)
        {
        }

        #region IDebugAdvanced
        #region GetThreadContext

        /// <summary>
        /// The GetThreadContext method returns the current thread context.
        /// </summary>
        /// <param name="context">[out] Receives the current thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="contextSize">[in] Specifies the size of the buffer Context.</param>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        public void GetThreadContext(IntPtr context, uint contextSize)
        {
            TryGetThreadContext(context, contextSize).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The GetThreadContext method returns the current thread context.
        /// </summary>
        /// <param name="context">[out] Receives the current thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="contextSize">[in] Specifies the size of the buffer Context.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TryGetThreadContext(IntPtr context, uint contextSize)
        {
            InitDelegate(ref getThreadContext, Vtbl->GetThreadContext);

            /*HRESULT GetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);*/
            return getThreadContext(Raw, context, contextSize);
        }

        #endregion
        #region SetThreadContext

        /// <summary>
        /// The SetThreadContext method sets the current thread context.
        /// </summary>
        /// <param name="context">[in] Specifies the thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="contextSize">[in] Specifies the size of the buffer Context.</param>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        public void SetThreadContext(IntPtr context, uint contextSize)
        {
            TrySetThreadContext(context, contextSize).ThrowDbgEngNotOk();
        }

        /// <summary>
        /// The SetThreadContext method sets the current thread context.
        /// </summary>
        /// <param name="context">[in] Specifies the thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="contextSize">[in] Specifies the size of the buffer Context.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        public HRESULT TrySetThreadContext(IntPtr context, uint contextSize)
        {
            InitDelegate(ref setThreadContext, Vtbl->SetThreadContext);

            /*HRESULT SetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);*/
            return setThreadContext(Raw, context, contextSize);
        }

        #endregion
        #endregion
        #region IDebugAdvanced2
        #region Request

        /// <summary>
        /// The Request method performs a variety of different operations.
        /// </summary>
        /// <param name="request">[in] Specifies which operation to perform. Request can be one of the values in the following table. Details of each operation can be found by following the link in the "Request" column.<para/>
        /// DEBUG_REQUEST_SOURCE_PATH_HAS_SOURCE_SERVER DEBUG_REQUEST_TARGET_EXCEPTION_CONTEXT DEBUG_REQUEST_TARGET_EXCEPTION_THREAD DEBUG_REQUEST_TARGET_EXCEPTION_RECORD DEBUG_REQUEST_GET_ADDITIONAL_CREATE_OPTIONS DEBUG_REQUEST_SET_ADDITIONAL_CREATE_OPTIONS DEBUG_REQUEST_GET_WIN32_MAJOR_MINOR_VERSIONS DEBUG_REQUEST_READ_USER_MINIDUMP_STREAM DEBUG_REQUEST_TARGET_CAN_DETACH DEBUG_REQUEST_SET_LOCAL_IMPLICIT_COMMAND_LINE DEBUG_REQUEST_GET_CAPTURED_EVENT_CODE_OFFSET DEBUG_REQUEST_READ_CAPTURED_EVENT_CODE_STREAM DEBUG_REQUEST_EXT_TYPED_DATA_ANSI</param>
        /// <param name="inBuffer">[in, optional] Specifies the input to this method. The type and interpretation of the input depends on the Request parameter.</param>
        /// <param name="inBufferSize">[in] Specifies the size of the input buffer InBuffer. If the request requires no input, InBufferSize should be set to zero.</param>
        /// <param name="outBuffer">[out, optional] Receives the output from this method. The type and interpretation of the output depends on the Request parameter.<para/>
        /// If OutBuffer is NULL, the output is not returned.</param>
        /// <param name="outBufferSize">[in] Specifies the size of the output buffer OutBufferSize. If the type of the output returned to OutBuffer has a known size, OutBufferSize is usually expected to be exactly that size, even if OutBuffer is set to NULL.</param>
        /// <returns>[out, optional] Receives the size of the output returned in the output buffer OutBuffer. If OutSize is NULL, this information is not returned.</returns>
        public int Request(DEBUG_REQUEST request, IntPtr inBuffer, int inBufferSize, IntPtr outBuffer, int outBufferSize)
        {
            int outSize;
            TryRequest(request, inBuffer, inBufferSize, outBuffer, outBufferSize, out outSize).ThrowDbgEngNotOk();

            return outSize;
        }

        /// <summary>
        /// The Request method performs a variety of different operations.
        /// </summary>
        /// <param name="request">[in] Specifies which operation to perform. Request can be one of the values in the following table. Details of each operation can be found by following the link in the "Request" column.<para/>
        /// DEBUG_REQUEST_SOURCE_PATH_HAS_SOURCE_SERVER DEBUG_REQUEST_TARGET_EXCEPTION_CONTEXT DEBUG_REQUEST_TARGET_EXCEPTION_THREAD DEBUG_REQUEST_TARGET_EXCEPTION_RECORD DEBUG_REQUEST_GET_ADDITIONAL_CREATE_OPTIONS DEBUG_REQUEST_SET_ADDITIONAL_CREATE_OPTIONS DEBUG_REQUEST_GET_WIN32_MAJOR_MINOR_VERSIONS DEBUG_REQUEST_READ_USER_MINIDUMP_STREAM DEBUG_REQUEST_TARGET_CAN_DETACH DEBUG_REQUEST_SET_LOCAL_IMPLICIT_COMMAND_LINE DEBUG_REQUEST_GET_CAPTURED_EVENT_CODE_OFFSET DEBUG_REQUEST_READ_CAPTURED_EVENT_CODE_STREAM DEBUG_REQUEST_EXT_TYPED_DATA_ANSI</param>
        /// <param name="inBuffer">[in, optional] Specifies the input to this method. The type and interpretation of the input depends on the Request parameter.</param>
        /// <param name="inBufferSize">[in] Specifies the size of the input buffer InBuffer. If the request requires no input, InBufferSize should be set to zero.</param>
        /// <param name="outBuffer">[out, optional] Receives the output from this method. The type and interpretation of the output depends on the Request parameter.<para/>
        /// If OutBuffer is NULL, the output is not returned.</param>
        /// <param name="outBufferSize">[in] Specifies the size of the output buffer OutBufferSize. If the type of the output returned to OutBuffer has a known size, OutBufferSize is usually expected to be exactly that size, even if OutBuffer is set to NULL.</param>
        /// <param name="outSize">[out, optional] Receives the size of the output returned in the output buffer OutBuffer. If OutSize is NULL, this information is not returned.</param>
        /// <returns>The interpretation of the return value depends on the value of the Request parameter. Unless otherwise stated, the following values may be returned.<para/>
        /// This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryRequest(DEBUG_REQUEST request, IntPtr inBuffer, int inBufferSize, IntPtr outBuffer, int outBufferSize, out int outSize)
        {
            InitDelegate(ref request, Vtbl2->Request);

            /*HRESULT Request(
            [In] DEBUG_REQUEST Request,
            [In] IntPtr InBuffer,
            [In] int InBufferSize,
            [Out] IntPtr OutBuffer,
            [In] int OutBufferSize,
            [Out] out int OutSize);*/
            return this.request(Raw, request, inBuffer, inBufferSize, outBuffer, outBufferSize, out outSize);
        }

        #endregion
        #region GetSourceFileInformation

        /// <summary>
        /// The GetSourceFileInformation method returns specified information about a source file.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. The Which parameter can take one of the values in the following table.<para/>
        /// Returns a token representing the specified source file on a source server. This token can be passed to <see cref="FindSourceFileAndToken"/> to retrieve information about the file.<para/>
        /// The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the size of the SrcSrv token.<para/>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and its command-line parameters.<para/>
        /// The command is returned to the Buffer buffer as a Unicode string.</param>
        /// <param name="sourceFile">[in] Specifies the source file whose information is being requested. The source file is looked up on all the source servers in the source path.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. The value of Which specifies the module whose symbol token is requested. Regardless of the value of Which, Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter is currently unused.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the Buffer buffer. If Buffer is NULL, BufferSize must also be NULL.</param>
        /// <returns>[out, optional] Specifies the size in bytes of the information returned to the Buffer buffer. This parameter can be NULL if the data is not required.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public int GetSourceFileInformation(DEBUG_SRCFILE which, string sourceFile, ulong arg64, uint arg32, IntPtr buffer, int bufferSize)
        {
            int infoSize;
            TryGetSourceFileInformation(which, sourceFile, arg64, arg32, buffer, bufferSize, out infoSize).ThrowDbgEngNotOk();

            return infoSize;
        }

        /// <summary>
        /// The GetSourceFileInformation method returns specified information about a source file.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. The Which parameter can take one of the values in the following table.<para/>
        /// Returns a token representing the specified source file on a source server. This token can be passed to <see cref="FindSourceFileAndToken"/> to retrieve information about the file.<para/>
        /// The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the size of the SrcSrv token.<para/>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and its command-line parameters.<para/>
        /// The command is returned to the Buffer buffer as a Unicode string.</param>
        /// <param name="sourceFile">[in] Specifies the source file whose information is being requested. The source file is looked up on all the source servers in the source path.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. The value of Which specifies the module whose symbol token is requested. Regardless of the value of Which, Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter is currently unused.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the Buffer buffer. If Buffer is NULL, BufferSize must also be NULL.</param>
        /// <param name="infoSize">[out, optional] Specifies the size in bytes of the information returned to the Buffer buffer. This parameter can be NULL if the data is not required.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetSourceFileInformation(DEBUG_SRCFILE which, string sourceFile, ulong arg64, uint arg32, IntPtr buffer, int bufferSize, out int infoSize)
        {
            InitDelegate(ref getSourceFileInformation, Vtbl2->GetSourceFileInformation);

            /*HRESULT GetSourceFileInformation(
            [In] DEBUG_SRCFILE Which,
            [In, MarshalAs(UnmanagedType.LPStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);*/
            return getSourceFileInformation(Raw, which, sourceFile, arg64, arg32, buffer, bufferSize, out infoSize);
        }

        #endregion
        #region FindSourceFileAndToken

        /// <summary>
        /// The FindSourceFileAndToken method returns the filename of a source file on the source path or return the value of a variable associated with a file token.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path. StartElement is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags.</param>
        /// <param name="modAddr">[in] Specifies a location within the memory allocation of the module in the target to which the source file is related.<para/>
        /// ModAddr is used for caching the search results and when querying source servers for the file. ModAddr can be NULL.<para/>
        /// ModAddr is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags. And it is not used for querying source servers if FileToken is not NULL.</param>
        /// <param name="file">[in] Specifies the path and filename of the file to search for. If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, the file is already specified by the token in FileToken.<para/>
        /// In this case, File specifies the name of a variable on the source server related to the file. The variable must begin and end with the percent sign ( % ), for example, %SRCSRVCMD%.<para/>
        /// The value of this variable is returned.</param>
        /// <param name="flags">[in] Specifies the flags that control the behavior of this method. For a description of these flags, see Remarks.</param>
        /// <param name="fileToken">[in, optional] Specifies a file token representing a file on a source server. A file token can be obtained by setting Which to DEBUG_SRCFILE_SYMBOL_TOKEN in the method <see cref="GetSourceFileInformation"/>.<para/>
        /// If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, FileToken must not be NULL.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the Buffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If Buffer is NULL, this parameter is ignored.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// When the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, this method does not search for a file on the source
        /// path. Instead, it looks up a variable associated with the file token provided in FileToken. These variables are
        /// documented in the topic Language Specification 1. For example, to retrieve the value of the variable SRCSRVCMD--the
        /// command to extract the source file from source control (also returned by the DEBUG_SRCFILE_SYMBOL_TOKEN_SOURCE_COMMAND_WIDE
        /// function of <see cref="GetSourceFileInformation"/>)--set File to %SRCSRVCMD%. The engine uses the following steps--in
        /// order--to search for the file: The first match found is returned. If the flag DEBUG_FIND_SOURCE_BEST_MATCH is set,
        /// the match with the longest overlap is returned; otherwise, the first match is returned. The first match found is
        /// returned. The DEBUG_FIND_SOURCE_XXX bit-flags are used to control the behavior of the methods <see cref="DebugSymbols.FindSourceFile"/>
        /// and FindSourceFileAndToken when searching for source files. The flags can be any combination of values from the
        /// following table. If not set and the source path contains relative directories, relative path names can be returned.
        /// If this flag is set, the other flags are ignored. This flag cannot be used in the <see cref="DebugSymbols.FindSourceFile"/>
        /// method. The value DEBUG_FIND_SOURCE_DEFULT defines the default set of flags, which means that all of the flags
        /// in the previous table are turned off.
        /// </remarks>
        public FindSourceFileAndTokenResult FindSourceFileAndToken(uint startElement, ulong modAddr, string file, DEBUG_FIND_SOURCE flags, IntPtr fileToken, int bufferSize)
        {
            FindSourceFileAndTokenResult result;
            TryFindSourceFileAndToken(startElement, modAddr, file, flags, fileToken, bufferSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The FindSourceFileAndToken method returns the filename of a source file on the source path or return the value of a variable associated with a file token.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path. StartElement is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags.</param>
        /// <param name="modAddr">[in] Specifies a location within the memory allocation of the module in the target to which the source file is related.<para/>
        /// ModAddr is used for caching the search results and when querying source servers for the file. ModAddr can be NULL.<para/>
        /// ModAddr is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags. And it is not used for querying source servers if FileToken is not NULL.</param>
        /// <param name="file">[in] Specifies the path and filename of the file to search for. If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, the file is already specified by the token in FileToken.<para/>
        /// In this case, File specifies the name of a variable on the source server related to the file. The variable must begin and end with the percent sign ( % ), for example, %SRCSRVCMD%.<para/>
        /// The value of this variable is returned.</param>
        /// <param name="flags">[in] Specifies the flags that control the behavior of this method. For a description of these flags, see Remarks.</param>
        /// <param name="fileToken">[in, optional] Specifies a file token representing a file on a source server. A file token can be obtained by setting Which to DEBUG_SRCFILE_SYMBOL_TOKEN in the method <see cref="GetSourceFileInformation"/>.<para/>
        /// If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, FileToken must not be NULL.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the Buffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If Buffer is NULL, this parameter is ignored.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the flag DEBUG_SRCFILE_SYMBOL_TOKEN is set in Flags, this method does not search for a file on the source
        /// path. Instead, it looks up a variable associated with the file token provided in FileToken. These variables are
        /// documented in the topic Language Specification 1. For example, to retrieve the value of the variable SRCSRVCMD--the
        /// command to extract the source file from source control (also returned by the DEBUG_SRCFILE_SYMBOL_TOKEN_SOURCE_COMMAND_WIDE
        /// function of <see cref="GetSourceFileInformation"/>)--set File to %SRCSRVCMD%. The engine uses the following steps--in
        /// order--to search for the file: The first match found is returned. If the flag DEBUG_FIND_SOURCE_BEST_MATCH is set,
        /// the match with the longest overlap is returned; otherwise, the first match is returned. The first match found is
        /// returned. The DEBUG_FIND_SOURCE_XXX bit-flags are used to control the behavior of the methods <see cref="DebugSymbols.FindSourceFile"/>
        /// and FindSourceFileAndToken when searching for source files. The flags can be any combination of values from the
        /// following table. If not set and the source path contains relative directories, relative path names can be returned.
        /// If this flag is set, the other flags are ignored. This flag cannot be used in the <see cref="DebugSymbols.FindSourceFile"/>
        /// method. The value DEBUG_FIND_SOURCE_DEFULT defines the default set of flags, which means that all of the flags
        /// in the previous table are turned off.
        /// </remarks>
        public HRESULT TryFindSourceFileAndToken(uint startElement, ulong modAddr, string file, DEBUG_FIND_SOURCE flags, IntPtr fileToken, int bufferSize, out FindSourceFileAndTokenResult result)
        {
            InitDelegate(ref findSourceFileAndToken, Vtbl2->FindSourceFileAndToken);
            /*HRESULT FindSourceFileAndToken(
            [In] uint StartElement,
            [In] ulong ModAddr,
            [In, MarshalAs(UnmanagedType.LPStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] IntPtr FileToken,
            [In] int FileTokenSize,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);*/
            int fileTokenSize = 0;
            int foundElement;
            StringBuilder buffer = null;
            int foundSize;
            HRESULT hr = findSourceFileAndToken(Raw, startElement, modAddr, file, flags, fileToken, fileTokenSize, out foundElement, buffer, bufferSize, out foundSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileTokenSize = foundElement;
            buffer = new StringBuilder(fileTokenSize);
            hr = findSourceFileAndToken(Raw, startElement, modAddr, file, flags, fileToken, fileTokenSize, out foundElement, buffer, bufferSize, out foundSize);

            if (hr == HRESULT.S_OK)
            {
                result = new FindSourceFileAndTokenResult(buffer.ToString(), foundSize);

                return hr;
            }

            fail:
            result = default(FindSourceFileAndTokenResult);

            return hr;
        }

        #endregion
        #region GetSymbolInformation

        /// <summary>
        /// The GetSymbolInformation method returns specified information about a symbol.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. Which can take one of the values in the follow table. No string is returned and StringBuffer, StringBufferSize, and StringSize must all be set to zero.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Ignored.<para/>
        /// The base address of the module whose description is being requested. Specifies the address in the target's memory of the symbol whose name is being requested.<para/>
        /// Specifies the module whose symbols are requested. Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine breakpoint ID of the desired breakpoint.<para/>
        /// Set to zero. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="stringBufferSize">[in] Specifies the size, in characters, of the string buffer StringBuffer.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSymbolInformationResult GetSymbolInformation(DEBUG_SYMINFO which, ulong arg64, uint arg32, IntPtr buffer, int stringBufferSize)
        {
            GetSymbolInformationResult result;
            TryGetSymbolInformation(which, arg64, arg32, buffer, stringBufferSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The GetSymbolInformation method returns specified information about a symbol.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. Which can take one of the values in the follow table. No string is returned and StringBuffer, StringBufferSize, and StringSize must all be set to zero.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Ignored.<para/>
        /// The base address of the module whose description is being requested. Specifies the address in the target's memory of the symbol whose name is being requested.<para/>
        /// Specifies the module whose symbols are requested. Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine breakpoint ID of the desired breakpoint.<para/>
        /// Set to zero. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="stringBufferSize">[in] Specifies the size, in characters, of the string buffer StringBuffer.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetSymbolInformation(DEBUG_SYMINFO which, ulong arg64, uint arg32, IntPtr buffer, int stringBufferSize, out GetSymbolInformationResult result)
        {
            InitDelegate(ref getSymbolInformation, Vtbl2->GetSymbolInformation);
            /*HRESULT GetSymbolInformation(
            [In] DEBUG_SYMINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize,
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder StringBuffer,
            [In] int StringBufferSize,
            [Out] out int StringSize);*/
            int bufferSize = 0;
            int infoSize;
            StringBuilder stringBuffer = null;
            int stringSize;
            HRESULT hr = getSymbolInformation(Raw, which, arg64, arg32, buffer, bufferSize, out infoSize, stringBuffer, stringBufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = infoSize;
            stringBuffer = new StringBuilder(bufferSize);
            hr = getSymbolInformation(Raw, which, arg64, arg32, buffer, bufferSize, out infoSize, stringBuffer, stringBufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetSymbolInformationResult(stringBuffer.ToString(), stringSize);

                return hr;
            }

            fail:
            result = default(GetSymbolInformationResult);

            return hr;
        }

        #endregion
        #region GetSystemObjectInformation

        /// <summary>
        /// The GetSystemObjectInformation method returns information about operating system objects on the target.
        /// </summary>
        /// <param name="which">[in] Specifies the type of object and the type of information to return about that object. Which can take the following value.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Not used.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine thread ID of the desired thread.</param>
        /// <param name="buffer">[out, optional] Receives the requested information. The type of data returned in Buffer depends on the value of Which.<para/>
        /// <see cref="DEBUG_THREAD_BASIC_INFORMATION"/></param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the buffer Buffer.</param>
        /// <returns>[out, optional] Receives the size of the information that is returned.</returns>
        public int GetSystemObjectInformation(DEBUG_SYSOBJINFO which, ulong arg64, uint arg32, IntPtr buffer, int bufferSize)
        {
            int infoSize;
            TryGetSystemObjectInformation(which, arg64, arg32, buffer, bufferSize, out infoSize).ThrowDbgEngNotOk();

            return infoSize;
        }

        /// <summary>
        /// The GetSystemObjectInformation method returns information about operating system objects on the target.
        /// </summary>
        /// <param name="which">[in] Specifies the type of object and the type of information to return about that object. Which can take the following value.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Not used.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine thread ID of the desired thread.</param>
        /// <param name="buffer">[out, optional] Receives the requested information. The type of data returned in Buffer depends on the value of Which.<para/>
        /// <see cref="DEBUG_THREAD_BASIC_INFORMATION"/></param>
        /// <param name="bufferSize">[in] Specifies the size, in bytes, of the buffer Buffer.</param>
        /// <param name="infoSize">[out, optional] Receives the size of the information that is returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetSystemObjectInformation(DEBUG_SYSOBJINFO which, ulong arg64, uint arg32, IntPtr buffer, int bufferSize, out int infoSize)
        {
            InitDelegate(ref getSystemObjectInformation, Vtbl2->GetSystemObjectInformation);

            /*HRESULT GetSystemObjectInformation(
            [In] DEBUG_SYSOBJINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);*/
            return getSystemObjectInformation(Raw, which, arg64, arg32, buffer, bufferSize, out infoSize);
        }

        #endregion
        #endregion
        #region IDebugAdvanced3
        #region GetSourceFileInformationWide

        /// <summary>
        /// The GetSourceFileInformationWide method returns specified information about a source file.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. The Which parameter can take one of the values in the following table.<para/>
        /// Returns a token representing the specified source file on a source server. This token can be passed to <see cref="FindSourceFileAndToken"/> to retrieve information about the file.<para/>
        /// The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the size of the SrcSrv token.<para/>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and its command-line parameters.<para/>
        /// The command is returned to the Buffer buffer as a Unicode string.</param>
        /// <param name="sourceFile">[in] Specifies the source file whose information is being requested. The source file is looked up on all the source servers in the source path.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. The value of Which specifies the module whose symbol token is requested. Regardless of the value of Which, Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter is currently unused.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the Buffer buffer. If Buffer is NULL, BufferSize must also be NULL.</param>
        /// <returns>[out, optional] Specifies the size in bytes of the information returned to the Buffer buffer. This parameter can be NULL if the data is not required.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public int GetSourceFileInformationWide(DEBUG_SRCFILE which, string sourceFile, ulong arg64, uint arg32, IntPtr buffer, int bufferSize)
        {
            int infoSize;
            TryGetSourceFileInformationWide(which, sourceFile, arg64, arg32, buffer, bufferSize, out infoSize).ThrowDbgEngNotOk();

            return infoSize;
        }

        /// <summary>
        /// The GetSourceFileInformationWide method returns specified information about a source file.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. The Which parameter can take one of the values in the following table.<para/>
        /// Returns a token representing the specified source file on a source server. This token can be passed to <see cref="FindSourceFileAndToken"/> to retrieve information about the file.<para/>
        /// The token is returned to the Buffer buffer as an array of bytes. The size of this token is a reflection of the size of the SrcSrv token.<para/>
        /// Queries a source server for the command to extract the source file from source control. This includes the name of the executable file and its command-line parameters.<para/>
        /// The command is returned to the Buffer buffer as a Unicode string.</param>
        /// <param name="sourceFile">[in] Specifies the source file whose information is being requested. The source file is looked up on all the source servers in the source path.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. The value of Which specifies the module whose symbol token is requested. Regardless of the value of Which, Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter is currently unused.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="bufferSize">[in] Specifies the size in bytes of the Buffer buffer. If Buffer is NULL, BufferSize must also be NULL.</param>
        /// <param name="infoSize">[out, optional] Specifies the size in bytes of the information returned to the Buffer buffer. This parameter can be NULL if the data is not required.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about source files, see Using Source Files.
        /// </remarks>
        public HRESULT TryGetSourceFileInformationWide(DEBUG_SRCFILE which, string sourceFile, ulong arg64, uint arg32, IntPtr buffer, int bufferSize, out int infoSize)
        {
            InitDelegate(ref getSourceFileInformationWide, Vtbl3->GetSourceFileInformationWide);

            /*HRESULT GetSourceFileInformationWide(
            [In] DEBUG_SRCFILE Which,
            [In, MarshalAs(UnmanagedType.LPWStr)] string SourceFile,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize);*/
            return getSourceFileInformationWide(Raw, which, sourceFile, arg64, arg32, buffer, bufferSize, out infoSize);
        }

        #endregion
        #region FindSourceFileAndTokenWide

        /// <summary>
        /// The FindSourceFileAndTokenWide method returns the filename of a source file on the source path or return the value of a variable associated with a file token.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path. StartElement is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags.</param>
        /// <param name="modAddr">[in] Specifies a location within the memory allocation of the module in the target to which the source file is related.<para/>
        /// ModAddr is used for caching the search results and when querying source servers for the file. ModAddr can be NULL.<para/>
        /// ModAddr is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags. And it is not used for querying source servers if FileToken is not NULL.</param>
        /// <param name="file">[in] Specifies the path and filename of the file to search for. If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, the file is already specified by the token in FileToken.<para/>
        /// In this case, File specifies the name of a variable on the source server related to the file. The variable must begin and end with the percent sign ( % ), for example, %SRCSRVCMD%.<para/>
        /// The value of this variable is returned.</param>
        /// <param name="flags">[in] Specifies the flags that control the behavior of this method. For a description of these flags, see DEBUG_FIND_SOURCE_XXX.</param>
        /// <param name="fileToken">[in, optional] Specifies a file token representing a file on a source server. A file token can be obtained by setting Which to DEBUG_SRCFILE_SYMBOL_TOKEN in the method <see cref="GetSourceFileInformation"/>.<para/>
        /// If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, FileToken must not be NULL.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the Buffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If Buffer is NULL, this parameter is ignored.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
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
        public FindSourceFileAndTokenWideResult FindSourceFileAndTokenWide(uint startElement, ulong modAddr, string file, DEBUG_FIND_SOURCE flags, IntPtr fileToken, int bufferSize)
        {
            FindSourceFileAndTokenWideResult result;
            TryFindSourceFileAndTokenWide(startElement, modAddr, file, flags, fileToken, bufferSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The FindSourceFileAndTokenWide method returns the filename of a source file on the source path or return the value of a variable associated with a file token.
        /// </summary>
        /// <param name="startElement">[in] Specifies the index of an element within the source path to start searching from. All elements in the source path before StartElement are excluded from the search.<para/>
        /// The index of the first element is zero. If StartElement is greater than or equal to the number of elements in the source path, the filing system is checked directly.<para/>
        /// This parameter can be used with FoundElement to check for multiple matches in the source path. StartElement is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags.</param>
        /// <param name="modAddr">[in] Specifies a location within the memory allocation of the module in the target to which the source file is related.<para/>
        /// ModAddr is used for caching the search results and when querying source servers for the file. ModAddr can be NULL.<para/>
        /// ModAddr is ignored if the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set in Flags. And it is not used for querying source servers if FileToken is not NULL.</param>
        /// <param name="file">[in] Specifies the path and filename of the file to search for. If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, the file is already specified by the token in FileToken.<para/>
        /// In this case, File specifies the name of a variable on the source server related to the file. The variable must begin and end with the percent sign ( % ), for example, %SRCSRVCMD%.<para/>
        /// The value of this variable is returned.</param>
        /// <param name="flags">[in] Specifies the flags that control the behavior of this method. For a description of these flags, see DEBUG_FIND_SOURCE_XXX.</param>
        /// <param name="fileToken">[in, optional] Specifies a file token representing a file on a source server. A file token can be obtained by setting Which to DEBUG_SRCFILE_SYMBOL_TOKEN in the method <see cref="GetSourceFileInformation"/>.<para/>
        /// If the flag DEBUG_FIND_SOURCE_TOKEN_LOOKUP is set, FileToken must not be NULL.</param>
        /// <param name="bufferSize">[in] Specifies the size in characters of the Buffer buffer. This size includes the space for the '\0' terminating character.<para/>
        /// If Buffer is NULL, this parameter is ignored.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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
        public HRESULT TryFindSourceFileAndTokenWide(uint startElement, ulong modAddr, string file, DEBUG_FIND_SOURCE flags, IntPtr fileToken, int bufferSize, out FindSourceFileAndTokenWideResult result)
        {
            InitDelegate(ref findSourceFileAndTokenWide, Vtbl3->FindSourceFileAndTokenWide);
            /*HRESULT FindSourceFileAndTokenWide(
            [In] uint StartElement,
            [In] ulong ModAddr,
            [In, MarshalAs(UnmanagedType.LPWStr)] string File,
            [In] DEBUG_FIND_SOURCE Flags,
            [Out] IntPtr FileToken,
            [In] int FileTokenSize,
            [Out] out int FoundElement,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out int FoundSize);*/
            int fileTokenSize = 0;
            int foundElement;
            StringBuilder buffer = null;
            int foundSize;
            HRESULT hr = findSourceFileAndTokenWide(Raw, startElement, modAddr, file, flags, fileToken, fileTokenSize, out foundElement, buffer, bufferSize, out foundSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            fileTokenSize = foundElement;
            buffer = new StringBuilder(fileTokenSize);
            hr = findSourceFileAndTokenWide(Raw, startElement, modAddr, file, flags, fileToken, fileTokenSize, out foundElement, buffer, bufferSize, out foundSize);

            if (hr == HRESULT.S_OK)
            {
                result = new FindSourceFileAndTokenWideResult(buffer.ToString(), foundSize);

                return hr;
            }

            fail:
            result = default(FindSourceFileAndTokenWideResult);

            return hr;
        }

        #endregion
        #region GetSymbolInformationWide

        /// <summary>
        /// The SetSymbolInformationWide method returns specified information about a symbol.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. Which can take one of the values in the follow table. No string is returned and StringBuffer, StringBufferSize, and StringSize must all be set to zero.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Ignored.<para/>
        /// The base address of the module whose description is being requested. Specifies the address in the target's memory of the symbol whose name is being requested.<para/>
        /// Specifies the module whose symbols are requested. Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine breakpoint ID of the desired breakpoint.<para/>
        /// Set to zero. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="stringBufferSize">[in] Specifies the size, in characters, of the string buffer StringBuffer.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSymbolInformationWideResult GetSymbolInformationWide(DEBUG_SYMINFO which, ulong arg64, uint arg32, IntPtr buffer, int stringBufferSize)
        {
            GetSymbolInformationWideResult result;
            TryGetSymbolInformationWide(which, arg64, arg32, buffer, stringBufferSize, out result).ThrowDbgEngNotOk();

            return result;
        }

        /// <summary>
        /// The SetSymbolInformationWide method returns specified information about a symbol.
        /// </summary>
        /// <param name="which">[in] Specifies the piece of information to return. Which can take one of the values in the follow table. No string is returned and StringBuffer, StringBufferSize, and StringSize must all be set to zero.</param>
        /// <param name="arg64">[in] Specifies a 64-bit argument. This parameter has the following interpretations depending on the value of Which: Ignored.<para/>
        /// The base address of the module whose description is being requested. Specifies the address in the target's memory of the symbol whose name is being requested.<para/>
        /// Specifies the module whose symbols are requested. Arg64 is a location within the memory allocation of the module.</param>
        /// <param name="arg32">[in] Specifies a 32-bit argument. This parameter has the following interpretations depending on the value of Which: The engine breakpoint ID of the desired breakpoint.<para/>
        /// Set to zero. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation. The PDB classification of the symbol. Arg32 must be one of the values in the SymTagEnum enumeration defined in Dbghelp.h.<para/>
        /// For more information, see PDB documentation.</param>
        /// <param name="buffer">[out, optional] Receives the requested symbol information. The type of the data returned depends on the value of Which.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="stringBufferSize">[in] Specifies the size, in characters, of the string buffer StringBuffer.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryGetSymbolInformationWide(DEBUG_SYMINFO which, ulong arg64, uint arg32, IntPtr buffer, int stringBufferSize, out GetSymbolInformationWideResult result)
        {
            InitDelegate(ref getSymbolInformationWide, Vtbl3->GetSymbolInformationWide);
            /*HRESULT GetSymbolInformationWide(
            [In] DEBUG_SYMINFO Which,
            [In] ulong Arg64,
            [In] uint Arg32,
            [Out] IntPtr Buffer,
            [In] int BufferSize,
            [Out] out int InfoSize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringBuffer,
            [In] int StringBufferSize,
            [Out] out int StringSize);*/
            int bufferSize = 0;
            int infoSize;
            StringBuilder stringBuffer = null;
            int stringSize;
            HRESULT hr = getSymbolInformationWide(Raw, which, arg64, arg32, buffer, bufferSize, out infoSize, stringBuffer, stringBufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = infoSize;
            stringBuffer = new StringBuilder(bufferSize);
            hr = getSymbolInformationWide(Raw, which, arg64, arg32, buffer, bufferSize, out infoSize, stringBuffer, stringBufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetSymbolInformationWideResult(stringBuffer.ToString(), stringSize);

                return hr;
            }

            fail:
            result = default(GetSymbolInformationWideResult);

            return hr;
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugAdvanced

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetThreadContextDelegate getThreadContext;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetThreadContextDelegate setThreadContext;

        #endregion
        #region IDebugAdvanced2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RequestDelegate request;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceFileInformationDelegate getSourceFileInformation;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FindSourceFileAndTokenDelegate findSourceFileAndToken;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolInformationDelegate getSymbolInformation;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSystemObjectInformationDelegate getSystemObjectInformation;

        #endregion
        #region IDebugAdvanced3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSourceFileInformationWideDelegate getSourceFileInformationWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FindSourceFileAndTokenWideDelegate findSourceFileAndTokenWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetSymbolInformationWideDelegate getSymbolInformationWide;

        #endregion
        #endregion
        #region Delegates
        #region IDebugAdvanced

        private delegate HRESULT GetThreadContextDelegate(IntPtr self, [In] IntPtr Context, [In] uint ContextSize);
        private delegate HRESULT SetThreadContextDelegate(IntPtr self, [In] IntPtr Context, [In] uint ContextSize);

        #endregion
        #region IDebugAdvanced2

        private delegate HRESULT RequestDelegate(IntPtr self, [In] DEBUG_REQUEST Request, [In] IntPtr InBuffer, [In] int InBufferSize, [Out] IntPtr OutBuffer, [In] int OutBufferSize, [Out] out int OutSize);
        private delegate HRESULT GetSourceFileInformationDelegate(IntPtr self, [In] DEBUG_SRCFILE Which, [In, MarshalAs(UnmanagedType.LPStr)] string SourceFile, [In] ulong Arg64, [In] uint Arg32, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out int InfoSize);
        private delegate HRESULT FindSourceFileAndTokenDelegate(IntPtr self, [In] uint StartElement, [In] ulong ModAddr, [In, MarshalAs(UnmanagedType.LPStr)] string File, [In] DEBUG_FIND_SOURCE Flags, [Out] IntPtr FileToken, [In] int FileTokenSize, [Out] out int FoundElement, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out int FoundSize);
        private delegate HRESULT GetSymbolInformationDelegate(IntPtr self, [In] DEBUG_SYMINFO Which, [In] ulong Arg64, [In] uint Arg32, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out int InfoSize, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder StringBuffer, [In] int StringBufferSize, [Out] out int StringSize);
        private delegate HRESULT GetSystemObjectInformationDelegate(IntPtr self, [In] DEBUG_SYSOBJINFO Which, [In] ulong Arg64, [In] uint Arg32, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out int InfoSize);

        #endregion
        #region IDebugAdvanced3

        private delegate HRESULT GetSourceFileInformationWideDelegate(IntPtr self, [In] DEBUG_SRCFILE Which, [In, MarshalAs(UnmanagedType.LPWStr)] string SourceFile, [In] ulong Arg64, [In] uint Arg32, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out int InfoSize);
        private delegate HRESULT FindSourceFileAndTokenWideDelegate(IntPtr self, [In] uint StartElement, [In] ulong ModAddr, [In, MarshalAs(UnmanagedType.LPWStr)] string File, [In] DEBUG_FIND_SOURCE Flags, [Out] IntPtr FileToken, [In] int FileTokenSize, [Out] out int FoundElement, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, [In] int BufferSize, [Out] out int FoundSize);
        private delegate HRESULT GetSymbolInformationWideDelegate(IntPtr self, [In] DEBUG_SYMINFO Which, [In] ulong Arg64, [In] uint Arg32, [Out] IntPtr Buffer, [In] int BufferSize, [Out] out int InfoSize, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder StringBuffer, [In] int StringBufferSize, [Out] out int StringSize);

        #endregion
        #endregion
    }
}

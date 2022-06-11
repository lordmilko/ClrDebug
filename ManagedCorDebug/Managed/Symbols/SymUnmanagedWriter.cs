using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public class SymUnmanagedWriter : ComObject<ISymUnmanagedWriter>
    {
        public SymUnmanagedWriter(ISymUnmanagedWriter raw) : base(raw)
        {
        }

        #region ISymUnmanagedWriter
        #region DefineDocument

        public SymUnmanagedDocumentWriter DefineDocument(string url, Guid language, Guid languageVendor, Guid documentType)
        {
            HRESULT hr;
            SymUnmanagedDocumentWriter pRetValResult;

            if ((hr = TryDefineDocument(url, language, languageVendor, documentType, out pRetValResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetValResult;
        }

        public HRESULT TryDefineDocument(string url, Guid language, Guid languageVendor, Guid documentType, out SymUnmanagedDocumentWriter pRetValResult)
        {
            /*HRESULT DefineDocument(
            [In] string url,
            [In] ref Guid language,
            [In] ref Guid languageVendor,
            [In] ref Guid documentType,
            [Out] out ISymUnmanagedDocumentWriter pRetVal);*/
            ISymUnmanagedDocumentWriter pRetVal;
            HRESULT hr = Raw.DefineDocument(url, ref language, ref languageVendor, ref documentType, out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedDocumentWriter(pRetVal);
            else
                pRetValResult = default(SymUnmanagedDocumentWriter);

            return hr;
        }

        #endregion
        #region SetUserEntryPoint

        public void SetUserEntryPoint(uint entryMethod)
        {
            HRESULT hr;

            if ((hr = TrySetUserEntryPoint(entryMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetUserEntryPoint(uint entryMethod)
        {
            /*HRESULT SetUserEntryPoint([In] uint entryMethod);*/
            return Raw.SetUserEntryPoint(entryMethod);
        }

        #endregion
        #region OpenMethod

        public void OpenMethod(uint method)
        {
            HRESULT hr;

            if ((hr = TryOpenMethod(method)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOpenMethod(uint method)
        {
            /*HRESULT OpenMethod([In] uint method);*/
            return Raw.OpenMethod(method);
        }

        #endregion
        #region CloseMethod

        public void CloseMethod()
        {
            HRESULT hr;

            if ((hr = TryCloseMethod()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseMethod()
        {
            /*HRESULT CloseMethod();*/
            return Raw.CloseMethod();
        }

        #endregion
        #region OpenScope

        public uint OpenScope(uint startOffset)
        {
            HRESULT hr;
            uint pRetVal;

            if ((hr = TryOpenScope(startOffset, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        public HRESULT TryOpenScope(uint startOffset, out uint pRetVal)
        {
            /*HRESULT OpenScope([In] uint startOffset, [Out] out uint pRetVal);*/
            return Raw.OpenScope(startOffset, out pRetVal);
        }

        #endregion
        #region CloseScope

        public void CloseScope(uint endOffset)
        {
            HRESULT hr;

            if ((hr = TryCloseScope(endOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseScope(uint endOffset)
        {
            /*HRESULT CloseScope([In] uint endOffset);*/
            return Raw.CloseScope(endOffset);
        }

        #endregion
        #region SetScopeRange

        public void SetScopeRange(uint scopeID, uint startOffset, uint endOffset)
        {
            HRESULT hr;

            if ((hr = TrySetScopeRange(scopeID, startOffset, endOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetScopeRange(uint scopeID, uint startOffset, uint endOffset)
        {
            /*HRESULT SetScopeRange([In] uint scopeID, [In] uint startOffset, [In] uint endOffset);*/
            return Raw.SetScopeRange(scopeID, startOffset, endOffset);
        }

        #endregion
        #region DefineLocalVariable

        public void DefineLocalVariable(string name, uint attributes, uint cSig, IntPtr signature, uint addrKind, uint addr1, uint addr2, uint addr3, uint startOffset, uint endOffset)
        {
            HRESULT hr;

            if ((hr = TryDefineLocalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3, startOffset, endOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineLocalVariable(string name, uint attributes, uint cSig, IntPtr signature, uint addrKind, uint addr1, uint addr2, uint addr3, uint startOffset, uint endOffset)
        {
            /*HRESULT DefineLocalVariable(
            [In] string name,
            [In] uint attributes,
            [In] uint cSig,
            [In] IntPtr signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3,
            [In] uint startOffset,
            [In] uint endOffset);*/
            return Raw.DefineLocalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3, startOffset, endOffset);
        }

        #endregion
        #region DefineParameter

        public void DefineParameter(string name, uint attributes, uint sequence, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            HRESULT hr;

            if ((hr = TryDefineParameter(name, attributes, sequence, addrKind, addr1, addr2, addr3)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineParameter(string name, uint attributes, uint sequence, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            /*HRESULT DefineParameter(
            [In] string name,
            [In] uint attributes,
            [In] uint sequence,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);*/
            return Raw.DefineParameter(name, attributes, sequence, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region DefineField

        public void DefineField(uint parent, string name, uint attributes, uint cSig, IntPtr signature, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            HRESULT hr;

            if ((hr = TryDefineField(parent, name, attributes, cSig, signature, addrKind, addr1, addr2, addr3)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineField(uint parent, string name, uint attributes, uint cSig, IntPtr signature, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            /*HRESULT DefineField(
            [In] uint parent,
            [In] string name,
            [In] uint attributes,
            [In] uint cSig,
            [In] IntPtr signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);*/
            return Raw.DefineField(parent, name, attributes, cSig, signature, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region DefineGlobalVariable

        public void DefineGlobalVariable(string name, uint attributes, uint cSig, IntPtr signature, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            HRESULT hr;

            if ((hr = TryDefineGlobalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineGlobalVariable(string name, uint attributes, uint cSig, IntPtr signature, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            /*HRESULT DefineGlobalVariable(
            [In] string name,
            [In] uint attributes,
            [In] uint cSig,
            [In] IntPtr signature,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);*/
            return Raw.DefineGlobalVariable(name, attributes, cSig, signature, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region Close

        public void Close()
        {
            HRESULT hr;

            if ((hr = TryClose()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryClose()
        {
            /*HRESULT Close();*/
            return Raw.Close();
        }

        #endregion
        #region SetSymAttribute

        public void SetSymAttribute(uint parent, string name, uint cData, IntPtr data)
        {
            HRESULT hr;

            if ((hr = TrySetSymAttribute(parent, name, cData, data)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetSymAttribute(uint parent, string name, uint cData, IntPtr data)
        {
            /*HRESULT SetSymAttribute([In] uint parent, [In] string name, [In] uint cData, [In] IntPtr data);*/
            return Raw.SetSymAttribute(parent, name, cData, data);
        }

        #endregion
        #region OpenNamespace

        public void OpenNamespace(string name)
        {
            HRESULT hr;

            if ((hr = TryOpenNamespace(name)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOpenNamespace(string name)
        {
            /*HRESULT OpenNamespace([In] string name);*/
            return Raw.OpenNamespace(name);
        }

        #endregion
        #region CloseNamespace

        public void CloseNamespace()
        {
            HRESULT hr;

            if ((hr = TryCloseNamespace()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseNamespace()
        {
            /*HRESULT CloseNamespace();*/
            return Raw.CloseNamespace();
        }

        #endregion
        #region UsingNamespace

        public void UsingNamespace(string fullName)
        {
            HRESULT hr;

            if ((hr = TryUsingNamespace(fullName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUsingNamespace(string fullName)
        {
            /*HRESULT UsingNamespace([In] string fullName);*/
            return Raw.UsingNamespace(fullName);
        }

        #endregion
        #region SetMethodSourceRange

        public void SetMethodSourceRange(ISymUnmanagedDocumentWriter startDoc, uint startLine, uint startColumn, ISymUnmanagedDocumentWriter endDoc, uint endLine, uint endColumn)
        {
            HRESULT hr;

            if ((hr = TrySetMethodSourceRange(startDoc, startLine, startColumn, endDoc, endLine, endColumn)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetMethodSourceRange(ISymUnmanagedDocumentWriter startDoc, uint startLine, uint startColumn, ISymUnmanagedDocumentWriter endDoc, uint endLine, uint endColumn)
        {
            /*HRESULT SetMethodSourceRange(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter startDoc,
            [In] uint startLine,
            [In] uint startColumn,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter endDoc,
            [In] uint endLine,
            [In] uint endColumn);*/
            return Raw.SetMethodSourceRange(startDoc, startLine, startColumn, endDoc, endLine, endColumn);
        }

        #endregion
        #region Initialize

        public void Initialize(object emitter, string filename, IStream pIStream, int fFullBuild)
        {
            HRESULT hr;

            if ((hr = TryInitialize(emitter, filename, pIStream, fFullBuild)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryInitialize(object emitter, string filename, IStream pIStream, int fFullBuild)
        {
            /*HRESULT Initialize([MarshalAs(UnmanagedType.IUnknown), In]
            object emitter, [In] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] int fFullBuild);*/
            return Raw.Initialize(emitter, filename, pIStream, fFullBuild);
        }

        #endregion
        #region GetDebugInfo

        public GetDebugInfoResult GetDebugInfo(uint cData)
        {
            HRESULT hr;
            GetDebugInfoResult result;

            if ((hr = TryGetDebugInfo(cData, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetDebugInfo(uint cData, out GetDebugInfoResult result)
        {
            /*HRESULT GetDebugInfo([In, Out]
            ref ulong pIDD, [In] uint cData, out uint pcData, [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);*/
            ulong pIDD = default(ulong);
            uint pcData;
            byte[] data = null;
            HRESULT hr = Raw.GetDebugInfo(ref pIDD, cData, out pcData, data);

            if (hr == HRESULT.S_OK)
                result = new GetDebugInfoResult(pIDD, pcData, data);
            else
                result = default(GetDebugInfoResult);

            return hr;
        }

        #endregion
        #region DefineSequencePoints

        public void DefineSequencePoints(ISymUnmanagedDocumentWriter document, uint spCount, uint offsets, uint lines, uint columns, uint endLines, uint endColumns)
        {
            HRESULT hr;

            if ((hr = TryDefineSequencePoints(document, spCount, offsets, lines, columns, endLines, endColumns)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineSequencePoints(ISymUnmanagedDocumentWriter document, uint spCount, uint offsets, uint lines, uint columns, uint endLines, uint endColumns)
        {
            /*HRESULT DefineSequencePoints(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] uint spCount,
            [In] ref uint offsets,
            [In] ref uint lines,
            [In] ref uint columns,
            [In] ref uint endLines,
            [In] ref uint endColumns);*/
            return Raw.DefineSequencePoints(document, spCount, ref offsets, ref lines, ref columns, ref endLines, ref endColumns);
        }

        #endregion
        #region RemapToken

        public void RemapToken(uint oldToken, uint newToken)
        {
            HRESULT hr;

            if ((hr = TryRemapToken(oldToken, newToken)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryRemapToken(uint oldToken, uint newToken)
        {
            /*HRESULT RemapToken([In] uint oldToken, [In] uint newToken);*/
            return Raw.RemapToken(oldToken, newToken);
        }

        #endregion
        #region Initialize2

        public void Initialize2(object emitter, string tempfilename, IStream pIStream, int fFullBuild, string finalfilename)
        {
            HRESULT hr;

            if ((hr = TryInitialize2(emitter, tempfilename, pIStream, fFullBuild, finalfilename)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryInitialize2(object emitter, string tempfilename, IStream pIStream, int fFullBuild, string finalfilename)
        {
            /*HRESULT Initialize2(
            [MarshalAs(UnmanagedType.IUnknown), In]
            object emitter,
            [In] string tempfilename,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream,
            [In] int fFullBuild,
            [In] string finalfilename);*/
            return Raw.Initialize2(emitter, tempfilename, pIStream, fFullBuild, finalfilename);
        }

        #endregion
        #region DefineConstant

        public void DefineConstant(string name, object value, uint cSig, IntPtr signature)
        {
            HRESULT hr;

            if ((hr = TryDefineConstant(name, value, cSig, signature)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineConstant(string name, object value, uint cSig, IntPtr signature)
        {
            /*HRESULT DefineConstant([In] string name, [MarshalAs(UnmanagedType.Struct), In] object value, [In] uint cSig,
            [In] IntPtr signature);*/
            return Raw.DefineConstant(name, value, cSig, signature);
        }

        #endregion
        #region Abort

        public void Abort()
        {
            HRESULT hr;

            if ((hr = TryAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAbort()
        {
            /*HRESULT Abort();*/
            return Raw.Abort();
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter2

        public ISymUnmanagedWriter2 Raw2 => (ISymUnmanagedWriter2) Raw;

        #region DefineLocalVariable2

        public void DefineLocalVariable2(string name, uint attributes, uint sigToken, uint addrKind, uint addr1, uint addr2, uint addr3, uint startOffset, uint endOffset)
        {
            HRESULT hr;

            if ((hr = TryDefineLocalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3, startOffset, endOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineLocalVariable2(string name, uint attributes, uint sigToken, uint addrKind, uint addr1, uint addr2, uint addr3, uint startOffset, uint endOffset)
        {
            /*HRESULT DefineLocalVariable2(
            [In] string name,
            [In] uint attributes,
            [In] uint sigToken,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3,
            [In] uint startOffset,
            [In] uint endOffset);*/
            return Raw2.DefineLocalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3, startOffset, endOffset);
        }

        #endregion
        #region DefineGlobalVariable2

        public void DefineGlobalVariable2(string name, uint attributes, uint sigToken, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            HRESULT hr;

            if ((hr = TryDefineGlobalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineGlobalVariable2(string name, uint attributes, uint sigToken, uint addrKind, uint addr1, uint addr2, uint addr3)
        {
            /*HRESULT DefineGlobalVariable2(
            [In] string name,
            [In] uint attributes,
            [In] uint sigToken,
            [In] uint addrKind,
            [In] uint addr1,
            [In] uint addr2,
            [In] uint addr3);*/
            return Raw2.DefineGlobalVariable2(name, attributes, sigToken, addrKind, addr1, addr2, addr3);
        }

        #endregion
        #region DefineConstant2

        public void DefineConstant2(string name, object value, uint sigToken)
        {
            HRESULT hr;

            if ((hr = TryDefineConstant2(name, value, sigToken)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineConstant2(string name, object value, uint sigToken)
        {
            /*HRESULT DefineConstant2([In] string name, [MarshalAs(UnmanagedType.Struct), In] object value,
            [In] uint sigToken);*/
            return Raw2.DefineConstant2(name, value, sigToken);
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter3

        public ISymUnmanagedWriter3 Raw3 => (ISymUnmanagedWriter3) Raw;

        #region OpenMethod2

        public void OpenMethod2(uint method, uint isect, uint offset)
        {
            HRESULT hr;

            if ((hr = TryOpenMethod2(method, isect, offset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOpenMethod2(uint method, uint isect, uint offset)
        {
            /*HRESULT OpenMethod2([In] uint method, [In] uint isect, [In] uint offset);*/
            return Raw3.OpenMethod2(method, isect, offset);
        }

        #endregion
        #region Commit

        public void Commit()
        {
            HRESULT hr;

            if ((hr = TryCommit()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCommit()
        {
            /*HRESULT Commit();*/
            return Raw3.Commit();
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter4

        public ISymUnmanagedWriter4 Raw4 => (ISymUnmanagedWriter4) Raw;

        #region GetDebugInfoWithPadding

        public GetDebugInfoWithPaddingResult GetDebugInfoWithPadding(uint cData)
        {
            HRESULT hr;
            GetDebugInfoWithPaddingResult result;

            if ((hr = TryGetDebugInfoWithPadding(cData, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetDebugInfoWithPadding(uint cData, out GetDebugInfoWithPaddingResult result)
        {
            /*HRESULT GetDebugInfoWithPadding(
            [In, Out] ref ulong pIDD,
            [In] uint cData,
            out uint pcData,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] data);*/
            ulong pIDD = default(ulong);
            uint pcData;
            byte[] data = null;
            HRESULT hr = Raw4.GetDebugInfoWithPadding(ref pIDD, cData, out pcData, data);

            if (hr == HRESULT.S_OK)
                result = new GetDebugInfoWithPaddingResult(pIDD, pcData, data);
            else
                result = default(GetDebugInfoWithPaddingResult);

            return hr;
        }

        #endregion
        #endregion
        #region ISymUnmanagedWriter5

        public ISymUnmanagedWriter5 Raw5 => (ISymUnmanagedWriter5) Raw;

        #region OpenMapTokensToSourceSpans

        public void OpenMapTokensToSourceSpans()
        {
            HRESULT hr;

            if ((hr = TryOpenMapTokensToSourceSpans()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOpenMapTokensToSourceSpans()
        {
            /*HRESULT OpenMapTokensToSourceSpans();*/
            return Raw5.OpenMapTokensToSourceSpans();
        }

        #endregion
        #region CloseMapTokensToSourceSpans

        public void CloseMapTokensToSourceSpans()
        {
            HRESULT hr;

            if ((hr = TryCloseMapTokensToSourceSpans()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseMapTokensToSourceSpans()
        {
            /*HRESULT CloseMapTokensToSourceSpans();*/
            return Raw5.CloseMapTokensToSourceSpans();
        }

        #endregion
        #region MapTokenToSourceSpan

        public void MapTokenToSourceSpan(uint token, ISymUnmanagedDocumentWriter document, uint line, uint column, uint endLine, uint endColumn)
        {
            HRESULT hr;

            if ((hr = TryMapTokenToSourceSpan(token, document, line, column, endLine, endColumn)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMapTokenToSourceSpan(uint token, ISymUnmanagedDocumentWriter document, uint line, uint column, uint endLine, uint endColumn)
        {
            /*HRESULT MapTokenToSourceSpan(
            [In] uint token,
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocumentWriter document,
            [In] uint line,
            [In] uint column,
            [In] uint endLine,
            [In] uint endColumn);*/
            return Raw5.MapTokenToSourceSpan(token, document, line, column, endLine, endColumn);
        }

        #endregion
        #endregion
    }
}
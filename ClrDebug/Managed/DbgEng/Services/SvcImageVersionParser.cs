using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class SvcImageVersionParser : ComObject<ISvcImageVersionParser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageVersionParser"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageVersionParser(ISvcImageVersionParser raw) : base(raw)
        {
        }

        #region ISvcImageVersionParser
        #region GetVersionString

        public string GetVersionString(VersionKind kind)
        {
            string pVersion;
            TryGetVersionString(kind, out pVersion).ThrowDbgEngNotOK();

            return pVersion;
        }

        public HRESULT TryGetVersionString(VersionKind kind, out string pVersion)
        {
            /*HRESULT GetVersionString(
            [In] VersionKind kind,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersion);*/
            return Raw.GetVersionString(kind, out pVersion);
        }

        #endregion
        #region GetVersionNumber

        public GetVersionNumberResult GetVersionNumber(VersionKind kind)
        {
            GetVersionNumberResult result;
            TryGetVersionNumber(kind, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetVersionNumber(VersionKind kind, out GetVersionNumberResult result)
        {
            /*HRESULT GetVersionNumber(
            [In] VersionKind kind,
            [Out] out long p1,
            [Out] out long p2,
            [Out] out long p3,
            [Out] out long p4);*/
            long p1;
            long p2;
            long p3;
            long p4;
            HRESULT hr = Raw.GetVersionNumber(kind, out p1, out p2, out p3, out p4);

            if (hr == HRESULT.S_OK)
                result = new GetVersionNumberResult(p1, p2, p3, p4);
            else
                result = default(GetVersionNumberResult);

            return hr;
        }

        #endregion
        #region GetVersionDataString

        public string GetVersionDataString(Guid pVersionDataIdentifierGuid, string pVersionDataIdentifierString)
        {
            string pVersionDataString;
            TryGetVersionDataString(pVersionDataIdentifierGuid, pVersionDataIdentifierString, out pVersionDataString).ThrowDbgEngNotOK();

            return pVersionDataString;
        }

        public HRESULT TryGetVersionDataString(Guid pVersionDataIdentifierGuid, string pVersionDataIdentifierString, out string pVersionDataString)
        {
            /*HRESULT GetVersionDataString(
            [In] Guid pVersionDataIdentifierGuid,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString);*/
            return Raw.GetVersionDataString(pVersionDataIdentifierGuid, pVersionDataIdentifierString, out pVersionDataString);
        }

        #endregion
        #endregion
        #region ISvcImageVersionParser2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISvcImageVersionParser2 Raw2 => (ISvcImageVersionParser2) Raw;

        #region EnumerateVersionData

        public SvcImageVersionDataEnumerator EnumerateVersionData()
        {
            SvcImageVersionDataEnumerator enumeratorResult;
            TryEnumerateVersionData(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        public HRESULT TryEnumerateVersionData(out SvcImageVersionDataEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateVersionData(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageVersionDataEnumerator enumerator);*/
            ISvcImageVersionDataEnumerator enumerator;
            HRESULT hr = Raw2.EnumerateVersionData(out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new SvcImageVersionDataEnumerator(enumerator);
            else
                enumeratorResult = default(SvcImageVersionDataEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}

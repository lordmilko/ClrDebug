using System;

namespace ClrDebug.DbgEng
{
    public class SvcImageVersionDataEnumerator : ComObject<ISvcImageVersionDataEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageVersionDataEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageVersionDataEnumerator(ISvcImageVersionDataEnumerator raw) : base(raw)
        {
        }

        #region ISvcImageVersionDataEnumerator
        #region Next

        public SvcImageVersionDataEnumerator_GetNextResult Next
        {
            get
            {
                SvcImageVersionDataEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetNext(out SvcImageVersionDataEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out] out Guid pVersionDataIdentifierGuid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataIdentifierString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataString,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pVersionDataDescription,
            [Out] out VersionKind pVersionKind);*/
            Guid pVersionDataIdentifierGuid;
            string pVersionDataIdentifierString;
            string pVersionDataString;
            string pVersionDataDescription;
            VersionKind pVersionKind;
            HRESULT hr = Raw.GetNext(out pVersionDataIdentifierGuid, out pVersionDataIdentifierString, out pVersionDataString, out pVersionDataDescription, out pVersionKind);

            if (hr == HRESULT.S_OK)
                result = new SvcImageVersionDataEnumerator_GetNextResult(pVersionDataIdentifierGuid, pVersionDataIdentifierString, pVersionDataString, pVersionDataDescription, pVersionKind);
            else
                result = default(SvcImageVersionDataEnumerator_GetNextResult);

            return hr;
        }

        #endregion
        #region Reset

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}

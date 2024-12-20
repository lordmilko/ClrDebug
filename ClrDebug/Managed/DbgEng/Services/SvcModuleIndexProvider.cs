using System;

namespace ClrDebug.DbgEng
{
    public class SvcModuleIndexProvider : ComObject<ISvcModuleIndexProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcModuleIndexProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcModuleIndexProvider(ISvcModuleIndexProvider raw) : base(raw)
        {
        }

        #region ISvcModuleIndexProvider
        #region GetModuleIndexKey

        /// <summary>
        /// Gets a key for the given module which is used as an index on the symbol server.
        /// </summary>
        public GetModuleIndexKeyResult GetModuleIndexKey(ISvcModule pModule)
        {
            GetModuleIndexKeyResult result;
            TryGetModuleIndexKey(pModule, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Gets a key for the given module which is used as an index on the symbol server.
        /// </summary>
        public HRESULT TryGetModuleIndexKey(ISvcModule pModule, out GetModuleIndexKeyResult result)
        {
            /*HRESULT GetModuleIndexKey(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pModuleIndex,
            [Out] out Guid pModuleIndexKind);*/
            string pModuleIndex;
            Guid pModuleIndexKind;
            HRESULT hr = Raw.GetModuleIndexKey(pModule, out pModuleIndex, out pModuleIndexKind);

            if (hr == HRESULT.S_OK)
                result = new GetModuleIndexKeyResult(pModuleIndex, pModuleIndexKind);
            else
                result = default(GetModuleIndexKeyResult);

            return hr;
        }

        #endregion
        #endregion
    }
}

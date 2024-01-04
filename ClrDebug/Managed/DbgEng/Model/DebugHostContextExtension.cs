using System;

namespace ClrDebug.DbgEng
{
    public class DebugHostContextExtension : ComObject<IDebugHostContextExtension>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostContextExtension"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostContextExtension(IDebugHostContextExtension raw) : base(raw)
        {
        }

        #region IDebugHostContextExtension
        #region AddExtensionData

        public void AddExtensionData(int blobId, int dataSize, IntPtr data)
        {
            TryAddExtensionData(blobId, dataSize, data).ThrowDbgEngNotOK();
        }

        public HRESULT TryAddExtensionData(int blobId, int dataSize, IntPtr data)
        {
            /*HRESULT AddExtensionData(
            [In] int blobId,
            [In] int dataSize,
            [In] IntPtr data);*/
            return Raw.AddExtensionData(blobId, dataSize, data);
        }

        #endregion
        #region FinalizeContext

        public DebugHostContext FinalizeContext()
        {
            DebugHostContext immutableContextResult;
            TryFinalizeContext(out immutableContextResult).ThrowDbgEngNotOK();

            return immutableContextResult;
        }

        public HRESULT TryFinalizeContext(out DebugHostContext immutableContextResult)
        {
            /*HRESULT FinalizeContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext immutableContext);*/
            IDebugHostContext immutableContext;
            HRESULT hr = Raw.FinalizeContext(out immutableContext);

            if (hr == HRESULT.S_OK)
                immutableContextResult = immutableContext == null ? null : new DebugHostContext(immutableContext);
            else
                immutableContextResult = default(DebugHostContext);

            return hr;
        }

        #endregion
        #endregion
    }
}

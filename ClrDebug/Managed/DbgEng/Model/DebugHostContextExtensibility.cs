using System;

namespace ClrDebug.DbgEng
{
    public class DebugHostContextExtensibility : ComObject<IDebugHostContextExtensibility>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostContextExtensibility"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostContextExtensibility(IDebugHostContextExtensibility raw) : base(raw)
        {
        }

        #region IDebugHostContextExtensibility
        #region HasExtensionData

        public bool HasExtensionData(int blobId)
        {
            /*bool HasExtensionData(
            [In] int blobId);*/
            return Raw.HasExtensionData(blobId);
        }

        #endregion
        #region ReadExtensionData

        public void ReadExtensionData(int blobId, int bufferSize, IntPtr buffer)
        {
            TryReadExtensionData(blobId, bufferSize, buffer).ThrowDbgEngNotOK();
        }

        public HRESULT TryReadExtensionData(int blobId, int bufferSize, IntPtr buffer)
        {
            /*HRESULT ReadExtensionData(
            [In] int blobId,
            [In] int bufferSize,
            [Out] IntPtr buffer);*/
            return Raw.ReadExtensionData(blobId, bufferSize, buffer);
        }

        #endregion
        #region CloneContextForModification

        public DebugHostContextExtension CloneContextForModification()
        {
            DebugHostContextExtension extensionHandleResult;
            TryCloneContextForModification(out extensionHandleResult).ThrowDbgEngNotOK();

            return extensionHandleResult;
        }

        public HRESULT TryCloneContextForModification(out DebugHostContextExtension extensionHandleResult)
        {
            /*HRESULT CloneContextForModification(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContextExtension extensionHandle);*/
            IDebugHostContextExtension extensionHandle;
            HRESULT hr = Raw.CloneContextForModification(out extensionHandle);

            if (hr == HRESULT.S_OK)
                extensionHandleResult = extensionHandle == null ? null : new DebugHostContextExtension(extensionHandle);
            else
                extensionHandleResult = default(DebugHostContextExtension);

            return hr;
        }

        #endregion
        #region CloneContextWithModification

        public DebugHostContext CloneContextWithModification(int blobId, int dataSize, IntPtr data)
        {
            DebugHostContext clonedContextResult;
            TryCloneContextWithModification(blobId, dataSize, data, out clonedContextResult).ThrowDbgEngNotOK();

            return clonedContextResult;
        }

        public HRESULT TryCloneContextWithModification(int blobId, int dataSize, IntPtr data, out DebugHostContext clonedContextResult)
        {
            /*HRESULT CloneContextWithModification(
            [In] int blobId,
            [In] int dataSize,
            [In] IntPtr data,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext clonedContext);*/
            IDebugHostContext clonedContext;
            HRESULT hr = Raw.CloneContextWithModification(blobId, dataSize, data, out clonedContext);

            if (hr == HRESULT.S_OK)
                clonedContextResult = clonedContext == null ? null : new DebugHostContext(clonedContext);
            else
                clonedContextResult = default(DebugHostContext);

            return hr;
        }

        #endregion
        #endregion
    }
}

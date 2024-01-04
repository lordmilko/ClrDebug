namespace ClrDebug.DbgEng
{
    public class SvcOSKernelObject : ComObject<ISvcOSKernelObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcOSKernelObject"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcOSKernelObject(ISvcOSKernelObject raw) : base(raw)
        {
        }

        #region ISvcOSKernelObject
        #region AssociatedKernelObject

        public GetAssociatedKernelObjectResult AssociatedKernelObject
        {
            get
            {
                GetAssociatedKernelObjectResult result;
                TryGetAssociatedKernelObject(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetAssociatedKernelObject(out GetAssociatedKernelObjectResult result)
        {
            /*HRESULT GetAssociatedKernelObject(
            [Out] out long kernelObjectAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext kernelAddressContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule kernelModule,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol kernelObjectType);*/
            long kernelObjectAddress;
            ISvcAddressContext kernelAddressContext;
            ISvcModule kernelModule;
            ISvcSymbol kernelObjectType;
            HRESULT hr = Raw.GetAssociatedKernelObject(out kernelObjectAddress, out kernelAddressContext, out kernelModule, out kernelObjectType);

            if (hr == HRESULT.S_OK)
                result = new GetAssociatedKernelObjectResult(kernelObjectAddress, kernelAddressContext == null ? null : new SvcAddressContext(kernelAddressContext), SvcModule.New(kernelModule), kernelObjectType == null ? null : new SvcSymbol(kernelObjectType));
            else
                result = default(GetAssociatedKernelObjectResult);

            return hr;
        }

        #endregion
        #endregion
    }
}

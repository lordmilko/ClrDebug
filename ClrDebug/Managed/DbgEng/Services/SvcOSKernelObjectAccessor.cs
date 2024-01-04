namespace ClrDebug.DbgEng
{
    public class SvcOSKernelObjectAccessor : ComObject<ISvcOSKernelObjectAccessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcOSKernelObjectAccessor"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcOSKernelObjectAccessor(ISvcOSKernelObjectAccessor raw) : base(raw)
        {
        }

        #region ISvcOSKernelObjectAccessor
        #region GetObjectFromAssociatedKernelObject

        public object GetObjectFromAssociatedKernelObject(long kernelObjectAddress)
        {
            object serviceObject;
            TryGetObjectFromAssociatedKernelObject(kernelObjectAddress, out serviceObject).ThrowDbgEngNotOK();

            return serviceObject;
        }

        public HRESULT TryGetObjectFromAssociatedKernelObject(long kernelObjectAddress, out object serviceObject)
        {
            /*HRESULT GetObjectFromAssociatedKernelObject(
            [In] long kernelObjectAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out object serviceObject);*/
            return Raw.GetObjectFromAssociatedKernelObject(kernelObjectAddress, out serviceObject);
        }

        #endregion
        #endregion
    }
}

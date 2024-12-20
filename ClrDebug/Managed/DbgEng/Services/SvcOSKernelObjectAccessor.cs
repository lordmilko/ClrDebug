namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Various enumeration services (process enumeration services, thread enumeration services,. module enumeration services, etc...).
    /// </summary>
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

        /// <summary>
        /// From the address of a kernel object as returned from ISvcOSKernelObject::GetAssociatedKernelObject, return the ISvc* interface (* = Process, Thread, Module, etc...) for that object.<para/>
        /// The given address must be valid in the default address context.
        /// </summary>
        public object GetObjectFromAssociatedKernelObject(long kernelObjectAddress)
        {
            object serviceObject;
            TryGetObjectFromAssociatedKernelObject(kernelObjectAddress, out serviceObject).ThrowDbgEngNotOK();

            return serviceObject;
        }

        /// <summary>
        /// From the address of a kernel object as returned from ISvcOSKernelObject::GetAssociatedKernelObject, return the ISvc* interface (* = Process, Thread, Module, etc...) for that object.<para/>
        /// The given address must be valid in the default address context.
        /// </summary>
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

namespace ClrDebug.DbgEng
{
    public class ConstructableConcept : ComObject<IConstructableConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructableConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ConstructableConcept(IConstructableConcept raw) : base(raw)
        {
        }

        #region IConstructableConcept
        #region CreateInstance

        public ModelObject CreateInstance(long argCount, IModelObject[] ppArguments)
        {
            ModelObject ppInstanceResult;
            TryCreateInstance(argCount, ppArguments, out ppInstanceResult).ThrowDbgEngNotOK();

            return ppInstanceResult;
        }

        public HRESULT TryCreateInstance(long argCount, IModelObject[] ppArguments, out ModelObject ppInstanceResult)
        {
            /*HRESULT CreateInstance(
            [In] long argCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IModelObject[] ppArguments,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppInstance);*/
            IModelObject ppInstance;
            HRESULT hr = Raw.CreateInstance(argCount, ppArguments, out ppInstance);

            if (hr == HRESULT.S_OK)
                ppInstanceResult = ppInstance == null ? null : new ModelObject(ppInstance);
            else
                ppInstanceResult = default(ModelObject);

            return hr;
        }

        #endregion
        #endregion
    }
}

namespace ClrDebug.DbgEng
{
    public class DeconstructableConcept : ComObject<IDeconstructableConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeconstructableConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DeconstructableConcept(IDeconstructableConcept raw) : base(raw)
        {
        }

        #region IDeconstructableConcept
        #region GetConstructableModelName

        public string GetConstructableModelName(IModelObject contextObject)
        {
            string constructableModelName;
            TryGetConstructableModelName(contextObject, out constructableModelName).ThrowDbgEngNotOK();

            return constructableModelName;
        }

        public HRESULT TryGetConstructableModelName(IModelObject contextObject, out string constructableModelName)
        {
            /*HRESULT GetConstructableModelName(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.BStr)] out string constructableModelName);*/
            return Raw.GetConstructableModelName(contextObject, out constructableModelName);
        }

        #endregion
        #region GetConstructorArgumentCount

        public long GetConstructorArgumentCount(IModelObject contextObject)
        {
            long argCount;
            TryGetConstructorArgumentCount(contextObject, out argCount).ThrowDbgEngNotOK();

            return argCount;
        }

        public HRESULT TryGetConstructorArgumentCount(IModelObject contextObject, out long argCount)
        {
            /*HRESULT GetConstructorArgumentCount(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long argCount);*/
            return Raw.GetConstructorArgumentCount(contextObject, out argCount);
        }

        #endregion
        #region GetConstructorArguments

        public IModelObject[] GetConstructorArguments(IModelObject contextObject, long argCount)
        {
            IModelObject[] constructorArguments;
            TryGetConstructorArguments(contextObject, argCount, out constructorArguments).ThrowDbgEngNotOK();

            return constructorArguments;
        }

        public HRESULT TryGetConstructorArguments(IModelObject contextObject, long argCount, out IModelObject[] constructorArguments)
        {
            /*HRESULT GetConstructorArguments(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long argCount,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] constructorArguments);*/
            constructorArguments = new IModelObject[(int) argCount];
            HRESULT hr = Raw.GetConstructorArguments(contextObject, argCount, constructorArguments);

            return hr;
        }

        #endregion
        #endregion
    }
}

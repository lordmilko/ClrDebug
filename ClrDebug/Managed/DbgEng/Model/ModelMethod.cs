namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a method which can be called. Extensions which implement methods would implement this interface one or more times for the methods which it provides.
    /// </summary>
    public class ModelMethod : ComObject<IModelMethod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelMethod"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ModelMethod(IModelMethod raw) : base(raw)
        {
        }

        #region IModelMethod
        #region Call

        /// <summary>
        /// The Call method is the way in which any method defined in the data model is invoked. The caller is responsible for passing an accurate instance object (this pointer) and an arbitrary set of arguments.<para/>
        /// The result of the method and any optional metadata associated with that result is returned. Methods which do not logically return a value still must return a valid <see cref="IModelObject"/>.<para/>
        /// In such a case, the <see cref="IModelObject"/> is a boxed no value. In the event a method fails, it may return optional extended error information in the input argument (even if the returned HRESULT is a failure).<para/>
        /// It is imperative that callers check for this. An underlying method may choose to provide its own implementation of "overload resolution" performing different actions based on the actual types or quantity of its input arguments.<para/>
        /// The data model provides no assistance for such.
        /// </summary>
        /// <param name="pContextObject">The context object (instance this pointer) from which the method was fetched.</param>
        /// <param name="argCount">The number of arguments being passed to the method call.</param>
        /// <param name="ppArguments">An array of <see cref="IModelObject"/> objects, one for each argument in the call.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public CallResult Call(IModelObject pContextObject, long argCount, IModelObject[] ppArguments)
        {
            CallResult result;
            TryCall(pContextObject, argCount, ppArguments, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The Call method is the way in which any method defined in the data model is invoked. The caller is responsible for passing an accurate instance object (this pointer) and an arbitrary set of arguments.<para/>
        /// The result of the method and any optional metadata associated with that result is returned. Methods which do not logically return a value still must return a valid <see cref="IModelObject"/>.<para/>
        /// In such a case, the <see cref="IModelObject"/> is a boxed no value. In the event a method fails, it may return optional extended error information in the input argument (even if the returned HRESULT is a failure).<para/>
        /// It is imperative that callers check for this. An underlying method may choose to provide its own implementation of "overload resolution" performing different actions based on the actual types or quantity of its input arguments.<para/>
        /// The data model provides no assistance for such.
        /// </summary>
        /// <param name="pContextObject">The context object (instance this pointer) from which the method was fetched.</param>
        /// <param name="argCount">The number of arguments being passed to the method call.</param>
        /// <param name="ppArguments">An array of <see cref="IModelObject"/> objects, one for each argument in the call.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCall(IModelObject pContextObject, long argCount, IModelObject[] ppArguments, out CallResult result)
        {
            /*HRESULT Call(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pContextObject,
            [In] long argCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] ppArguments,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore ppMetadata);*/
            IModelObject ppResult;
            IKeyStore ppMetadata;
            HRESULT hr = Raw.Call(pContextObject, argCount, ppArguments, out ppResult, out ppMetadata);

            if (hr == HRESULT.S_OK)
                result = new CallResult(ppResult == null ? null : new ModelObject(ppResult), ppMetadata == null ? null : new KeyStore(ppMetadata));
            else
                result = default(CallResult);

            return hr;
        }

        #endregion
        #endregion
    }
}

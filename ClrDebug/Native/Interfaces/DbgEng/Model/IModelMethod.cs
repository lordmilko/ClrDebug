using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a method which can be called. Extensions which implement methods would implement this interface one or more times for the methods which it provides.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("80600C1F-B90B-4896-82AD-1C00207909E8")]
    [ComImport]
    public interface IModelMethod
    {
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
        /// <param name="ppResult">The return value of the call. In the event that the call semantically returns nothing, a boxed no value object will be returned.<para/>
        /// Should the call fail (as indicated by a failing HRESULT), optional extended error information may be present here.</param>
        /// <param name="ppMetadata">Optional metadata about the call result may be placed here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT Call(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pContextObject,
            [In] long argCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] ppArguments,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore ppMetadata);
    }
}

using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The data model representation of a property accessor (get/set).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5A0C63D9-0526-42B8-960C-9516A3254C85")]
    [ComImport]
    public interface IModelPropertyAccessor
    {
        /// <summary>
        /// The GetValue method is the getter for the property accessor. It is called whenever a client wishes to fetch the underlying value of the property.<para/>
        /// Note that any caller which directly gets a property accessor is responsible for passing the key name and accurate instance object (this pointer) to the property accessor's GetValue method.
        /// </summary>
        /// <param name="key">The name of the key to get a value for. A caller which fetches a property accessor directly is responsible for passing this accurately.</param>
        /// <param name="contextObject">The context object (instance this pointer) from which the property accessor was fetched.</param>
        /// <param name="value">The underlying value of the property is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value);

        /// <summary>
        /// The SetValue method is the setter for the property accessor. It is called whenever a client wishes to assign a value to the underlying property.<para/>
        /// Many properties are read-only. In such cases, calling the SetValue method will return E_NOTIMPL. Note that any caller which directly gets a property accessor is responsible for passing the key name and accurate instance object (this pointer) to the property accessor's SetValue method.
        /// </summary>
        /// <param name="key">The name of the key to get a value for. A caller which fetches a property accessor directly is responsible for passing this accurately.</param>
        /// <param name="contextObject">The context object (instance this pointer) from which the property accessor was fetched.</param>
        /// <param name="value">The value to assign to the property.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT SetValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject value);
    }
}

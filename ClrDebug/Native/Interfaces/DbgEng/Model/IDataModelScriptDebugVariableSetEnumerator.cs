using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates a set of variables (arguments, parameters, locals, etc...)
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0F9FEED7-D045-4AC3-98A8-A98942CF6A35")]
    [ComImport]
    public interface IDataModelScriptDebugVariableSetEnumerator
    {
        /// <summary>
        /// The Reset method resets the position of the enumerator to where it was immediately after creation -- that is, before the first element of the set.
        /// </summary>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// The GetNext method moves the enumerator to the next variable in the set and returns the variable's name, value, and any metadata associated with it.<para/>
        /// If the enumerator has hit the end of the set, the error E_BOUNDS is returned. Once the E_BOUNDS marker has been returned from the GetNext method, it will continue to produce E_BOUNDS when called again unless an intervening Reset call is made.
        /// </summary>
        /// <param name="variableName">The name of the variable in the set is returned here as a string allocated by the SysAllocString function. The caller is responsible for freeing the returned string via SysFreeString.</param>
        /// <param name="variableValue">The current value of the variable is returned here. The value must be marshaled out to an <see cref="IModelObject"/> representation.<para/>
        /// Every property or other construct on the <see cref="IModelObject"/> must be able to be acquired while the debugger is in a break state.</param>
        /// <param name="variableMetadata">Optional metadata about the variable and its presentation may be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string variableName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject variableValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore variableMetadata);
    }
}

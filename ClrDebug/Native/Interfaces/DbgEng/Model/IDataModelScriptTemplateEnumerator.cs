using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which enumerates an available set of script templates. An enumerator interface that the script provider implements in order to advertise all the various templates it supports.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("69CE6AE2-2268-4E6F-B062-20CE62BFE677")]
    [ComImport]
    public interface IDataModelScriptTemplateEnumerator
    {
        /// <summary>
        /// The Reset method resets the enumerator to the position it was at when it was first created -- before the first template produced.
        /// </summary>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// The GetNext method moves the enumerator to the next template and returns it. At the end of enumeration, the enumerator returns E_BOUNDS.<para/>
        /// Once the E_BOUNDS marker has been hit, the enumerator will continue to produce E_BOUNDS errors indefinitely until a Reset call is made.
        /// </summary>
        /// <param name="templateContent">The next template in enumeration order is returned here as a component implementing the <see cref="IDataModelScriptTemplate"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplate templateContent);
    }
}

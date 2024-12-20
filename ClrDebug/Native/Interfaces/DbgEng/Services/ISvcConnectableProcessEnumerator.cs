using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E184675D-EBF8-46E0-BC60-514378AF6F35")]
    [ComImport]
    public interface ISvcConnectableProcessEnumerator
    {
        /// <summary>
        /// Resets the enumerator to the first process.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next connectable process in the list.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcConnectableProcess connectableProcess);
    }
}

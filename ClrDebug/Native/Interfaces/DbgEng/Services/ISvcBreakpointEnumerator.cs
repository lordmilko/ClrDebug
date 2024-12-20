using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates breakpoints.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("53FBB33A-2F42-4465-9F02-0899ABF13460")]
    [ComImport]
    public interface ISvcBreakpointEnumerator
    {
        /// <summary>
        /// Resets the enumerator so that the first breakpoint in the collection is returned from the subsequent GetNext call.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next breakpoint in the collection.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);
    }
}

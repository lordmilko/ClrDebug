using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Various objects returned from services (processes, threads, symbol sets, etc...).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("131E4723-1CC2-4EC7-BB12-9F40EDF63B66")]
    [ComImport]
    public interface ISvcDescription
    {
        /// <summary>
        /// Gets a description of the object on which the interface exists. This is intended for short textual display in some UI element.
        /// </summary>
        [PreserveSig]
        HRESULT GetDescription(
            [Out, MarshalAs(UnmanagedType.BStr)] out string objectDescription);
    }
}

using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Optionally provided by any symbol set. Represents a way to query the capabilities (and some key properties) of a symbol set.<para/>
    /// This interface is *ENTIRELY* optional. If it is not present, the default value of any capability queried must be assumed.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("05D19D56-C15E-4C1D-9125-BB14D61B9784")]
    [ComImport]
    public interface ISvcSymbolSetCapabilities
    {
        /// <summary>
        /// Asks the symbol set about a particular capability as identified by a set GUID and an ID within that set. Each GUID/ID identifies the type of data returned in the resulting buffer.<para/>
        /// The following error codes carry special semantics with this API E_NOT_SET: The symbol set does not understand the capability.<para/>
        /// Assume default behavior.
        /// </summary>
        [PreserveSig]
        HRESULT QueryCapability(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [In] int bufferSize,
            [Out] IntPtr buffer);
    }
}

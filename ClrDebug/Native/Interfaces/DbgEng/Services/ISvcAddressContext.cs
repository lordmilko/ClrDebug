using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface represents an address context. From many user's perspective, this is a largely opaque construct which is passed from place to place.<para/>
    /// An object which implements this interface can be several different types of address context (as indicated by AddressContextKind above).<para/>
    /// The object will either QI for ISvcProcess of ISvcAddressContextHardware ISvcExecutionUnitHardware.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2DDF4CC0-BBA8-4FB0-BD53-5F4C92218280")]
    [ComImport]
    public interface ISvcAddressContext
    {
        /// <summary>
        /// Gets the kind of address context.
        /// </summary>
        [PreserveSig]
        AddressContextKind GetAddressContextKind();
    }
}

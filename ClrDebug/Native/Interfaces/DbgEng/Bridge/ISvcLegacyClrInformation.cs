using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Private bridge interface to inquire about existing CLR capability.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("25C75342-66A8-44cb-89A9-13751F662786")]
    [ComImport]
    public interface ISvcLegacyClrInformation
    {
        /// <summary>
        /// Indicates whether or not there is specific unwinder support for managed stack unwinds.
        /// </summary>
        [PreserveSig]
        bool SupportsManagedStackUnwind();
    }
}

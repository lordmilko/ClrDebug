using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Indicates information about a file or image and how it was mapped into memory. An implemtnation of ISvcModule can optionally support this interface to indicate how the image was placed into memory.<para/>
    /// If this interface is *NOT* implemented on an ISvcModule, callers should assume that the module is a standard load (e.g.: SvcMappingLoaded).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("31A3942E-E145-4112-9014-88DC7593028E")]
    [ComImport]
    public interface ISvcMappingInformation
    {
        /// <summary>
        /// Gets the manner in which the object QI'd for this interface is mapped into memory.
        /// </summary>
        [PreserveSig]
        SvcMappingForm GetMappingForm();
    }
}

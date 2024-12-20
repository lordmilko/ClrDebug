using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterFlagInformation interface describes details about a particular control/status flag within a register (e.g.: the zero flag, the carry flag, etc...).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5ED13135-FA5D-4D29-BB93-C80CB72ADFD4")]
    [ComImport]
    public interface ISvcRegisterFlagInformation
    {
        /// <summary>
        /// Gets the name of the flag (e.g.: carry, overflow, etc...).
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string flagName);

        /// <summary>
        /// Gets a short abbreviation of the flag (e.g.: cf, zf, of, etc...).
        /// </summary>
        [PreserveSig]
        HRESULT GetAbbreviation(
            [Out, MarshalAs(UnmanagedType.BStr)] out string abbrevName);

        /// <summary>
        /// Gets the bit position of this flag within its containing register.
        /// </summary>
        [PreserveSig]
        int GetPosition();

        /// <summary>
        /// Gets the size of the flag information. Typically, this would be one bit. If this is not one, the flag is assumed to go from [ GetPosition(lsb), 'GetPosition + GetSize'(msb) ).
        /// </summary>
        [PreserveSig]
        int GetSize();
    }
}

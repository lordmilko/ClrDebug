using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterInformation interface describes details about a particular machine register.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B91E34DE-6407-4583-BBAE-95FE20548363")]
    [ComImport]
    public interface ISvcRegisterInformation
    {
        /// <summary>
        /// Gets the name of the register.
        /// </summary>
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string registerName);

        /// <summary>
        /// Gets the ID of this register. This is the canonical register number for the architecture. If the architecture is a custom architecture, this ID can be custom.<para/>
        /// The *default behavior* of a symbol provider without explicit knowledge of a given architecture is to directly map register numbers in debug information to the register ID returned here.<para/>
        /// The DWARF symbol provider, for instance, will directly map a register number N in DWARF debug information to the register in the context whose GetId returns N unless it has explicit knowledge about the architecture and/or ABI being targeted.<para/>
        /// Providing a custom mapping to particular formats requres implementing interfaces beyond ISvcMachineArchitecture.<para/>
        /// It requires supporting a DEBUG_SERVICE_REGISTERTRANSLATION conditional service whose primary condition is the architecture GUID and whose secondary condition is a GUID describing the debug format.
        /// </summary>
        [PreserveSig]
        int GetId();

        /// <summary>
        /// Gets the set of flags describing the category, etc... of this register.
        /// </summary>
        [PreserveSig]
        SvcContextFlags GetFlags();

        /// <summary>
        /// Gets the size of this register.
        /// </summary>
        [PreserveSig]
        int GetSize();

        /// <summary>
        /// ; Gets the sub-register mapping for this register. This will fail with E_NOT_SET if the register is NOT part of another register; otherwise, the parent register and the least/most significant bits of the mapping are returned.<para/>
        /// For instance, 'ah' would return a parent id of 'ax' and bits 0-7. Likewise, 'ax' would return 'eax' as a parent id and bits 0-15.
        /// </summary>
        [PreserveSig]
        HRESULT GetSubRegisterInformation(
            [Out] out int parentRegisterId,
            [Out] out int lsbOfMapping,
            [Out] out int msbOfMapping);

        /// <summary>
        /// Enumerates all of the control flags within the register. This will fail with E_NOT_SET if the register is NOT a flags register.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateRegisterFlags(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagsEnumerator flagsEnum);

        /// <summary>
        /// Gets the flag information for a particular bit of a flags register. This will fail with E_NOT_SET if the register is NOT a flags register.<para/>
        /// This will fail with E_BOUNDS if the bit position within the register is not a valid flag bit.
        /// </summary>
        [PreserveSig]
        HRESULT GetRegisterFlagInformation(
            [In] int position,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagInformation flagInfo);
    }
}

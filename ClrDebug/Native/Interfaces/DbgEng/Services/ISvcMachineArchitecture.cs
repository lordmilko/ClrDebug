using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_ARCHINFO. The ISvcMachineArchitecture interface provides access to architecture specific capabilities that are general information about a given architecture (bitness, pointer sizes, disassembly, page sizes, etc...).<para/>
    /// The service which provides this interface must be in every target composition stack regardless of whether it is debugging user mode processes, an OS kernel, or a hardware connection (e.g.: JTAG).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C9CD3D26-2A2D-4E14-99CD-2196F08C921A")]
    [ComImport]
    public interface ISvcMachineArchitecture
    {
        /// <summary>
        /// Gets an IMAGE_FILE_MACHINE_* constant definining the architecture described by this interface. Note that some machines cannot be described by an IMAGE_FILE_MACHINE constant and would return IMAGE_CUSTOM from this.<para/>
        /// With such a return value, the architecture must be understood via the architecture GUID returned from GetArchitectureGuid.
        /// </summary>
        [PreserveSig]
        int GetArchitecture();

        /// <summary>
        /// Returns the architecture GUID defining the architecture. This is either a DEBUG_ARCHDEF_* standard GUID or is a GUID defining a custom architecture.<para/>
        /// The GUID returned here *MUST* also be a component GUID for the architecture specific components.
        /// </summary>
        [PreserveSig]
        HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);

        /// <summary>
        /// Gets the bitness of the architecture (32/64/etc...).
        /// </summary>
        [PreserveSig]
        long GetBitness();

        /// <summary>
        /// Gets the standard page size of the machine.
        /// </summary>
        [PreserveSig]
        long GetPageSize();

        /// <summary>
        /// Gets the standard bit shift to get the page number from a given physical offset.
        /// </summary>
        [PreserveSig]
        long GetPageShift();

        /// <summary>
        /// Returns an enumerator which enumerates all registers for this architecture that are covered by the inpassed set of flags.
        /// </summary>
        [PreserveSig]
        HRESULT EnumerateRegisters(
            [In] SvcContextFlags flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterEnumerator registerEnumerator);

        /// <summary>
        /// Gets the register information for a particular register by its canonical id.
        /// </summary>
        [PreserveSig]
        HRESULT GetRegisterInformation(
            [In] int registerId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterInformation registerInformation);

        /// <summary>
        /// Gets the canonical register number for a given abstract register. If the architecture does not have such register (e.g.: the return address register is queried for X86), E_BOUNDS is returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetIdForAbstractRegister(
            [In] SvcAbstractRegister abstractId,
            [Out] out int canonicalId);

        /// <summary>
        /// Creates an empty register context. While the canonical ISvcMachineArchitecture implementation is required to implement a "standard register record" that supports get/set of all registers in the architecture, there is **ABSOLUTELY NO REQUIREMENT** that this is the record returned by any call to get register state.<para/>
        /// Plug-ins are free to implement ISvcRegisterContext on their own.
        /// </summary>
        [PreserveSig]
        HRESULT CreateRegisterContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppArchRegisterContext);

        /// <summary>
        /// From special registers, get the directory base (zero extended to 64-bit).
        /// </summary>
        [PreserveSig]
        long GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);

        /// <summary>
        /// From special registers, get the number of paging levels the hardware is configured to utilize.
        /// </summary>
        [PreserveSig]
        int GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);
    }
}

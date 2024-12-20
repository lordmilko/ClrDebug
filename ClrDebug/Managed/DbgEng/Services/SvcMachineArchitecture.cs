using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_ARCHINFO. The ISvcMachineArchitecture interface provides access to architecture specific capabilities that are general information about a given architecture (bitness, pointer sizes, disassembly, page sizes, etc...).<para/>
    /// The service which provides this interface must be in every target composition stack regardless of whether it is debugging user mode processes, an OS kernel, or a hardware connection (e.g.: JTAG).
    /// </summary>
    public class SvcMachineArchitecture : ComObject<ISvcMachineArchitecture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMachineArchitecture"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMachineArchitecture(ISvcMachineArchitecture raw) : base(raw)
        {
        }

        #region ISvcMachineArchitecture
        #region Architecture

        /// <summary>
        /// Gets an IMAGE_FILE_MACHINE_* constant definining the architecture described by this interface. Note that some machines cannot be described by an IMAGE_FILE_MACHINE constant and would return IMAGE_CUSTOM from this.<para/>
        /// With such a return value, the architecture must be understood via the architecture GUID returned from GetArchitectureGuid.
        /// </summary>
        public int Architecture
        {
            get
            {
                /*int GetArchitecture();*/
                return Raw.GetArchitecture();
            }
        }

        #endregion
        #region ArchitectureGuid

        /// <summary>
        /// Returns the architecture GUID defining the architecture. This is either a DEBUG_ARCHDEF_* standard GUID or is a GUID defining a custom architecture.<para/>
        /// The GUID returned here *MUST* also be a component GUID for the architecture specific components.
        /// </summary>
        public Guid ArchitectureGuid
        {
            get
            {
                Guid architecture;
                TryGetArchitectureGuid(out architecture).ThrowDbgEngNotOK();

                return architecture;
            }
        }

        /// <summary>
        /// Returns the architecture GUID defining the architecture. This is either a DEBUG_ARCHDEF_* standard GUID or is a GUID defining a custom architecture.<para/>
        /// The GUID returned here *MUST* also be a component GUID for the architecture specific components.
        /// </summary>
        public HRESULT TryGetArchitectureGuid(out Guid architecture)
        {
            /*HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);*/
            return Raw.GetArchitectureGuid(out architecture);
        }

        #endregion
        #region Bitness

        /// <summary>
        /// Gets the bitness of the architecture (32/64/etc...).
        /// </summary>
        public long Bitness
        {
            get
            {
                /*long GetBitness();*/
                return Raw.GetBitness();
            }
        }

        #endregion
        #region PageSize

        /// <summary>
        /// Gets the standard page size of the machine.
        /// </summary>
        public long PageSize
        {
            get
            {
                /*long GetPageSize();*/
                return Raw.GetPageSize();
            }
        }

        #endregion
        #region PageShift

        /// <summary>
        /// Gets the standard bit shift to get the page number from a given physical offset.
        /// </summary>
        public long PageShift
        {
            get
            {
                /*long GetPageShift();*/
                return Raw.GetPageShift();
            }
        }

        #endregion
        #region EnumerateRegisters

        /// <summary>
        /// Returns an enumerator which enumerates all registers for this architecture that are covered by the inpassed set of flags.
        /// </summary>
        public SvcRegisterEnumerator EnumerateRegisters(SvcContextFlags flags)
        {
            SvcRegisterEnumerator registerEnumeratorResult;
            TryEnumerateRegisters(flags, out registerEnumeratorResult).ThrowDbgEngNotOK();

            return registerEnumeratorResult;
        }

        /// <summary>
        /// Returns an enumerator which enumerates all registers for this architecture that are covered by the inpassed set of flags.
        /// </summary>
        public HRESULT TryEnumerateRegisters(SvcContextFlags flags, out SvcRegisterEnumerator registerEnumeratorResult)
        {
            /*HRESULT EnumerateRegisters(
            [In] SvcContextFlags flags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterEnumerator registerEnumerator);*/
            ISvcRegisterEnumerator registerEnumerator;
            HRESULT hr = Raw.EnumerateRegisters(flags, out registerEnumerator);

            if (hr == HRESULT.S_OK)
                registerEnumeratorResult = registerEnumerator == null ? null : new SvcRegisterEnumerator(registerEnumerator);
            else
                registerEnumeratorResult = default(SvcRegisterEnumerator);

            return hr;
        }

        #endregion
        #region GetRegisterInformation

        /// <summary>
        /// Gets the register information for a particular register by its canonical id.
        /// </summary>
        public SvcRegisterInformation GetRegisterInformation(int registerId)
        {
            SvcRegisterInformation registerInformationResult;
            TryGetRegisterInformation(registerId, out registerInformationResult).ThrowDbgEngNotOK();

            return registerInformationResult;
        }

        /// <summary>
        /// Gets the register information for a particular register by its canonical id.
        /// </summary>
        public HRESULT TryGetRegisterInformation(int registerId, out SvcRegisterInformation registerInformationResult)
        {
            /*HRESULT GetRegisterInformation(
            [In] int registerId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterInformation registerInformation);*/
            ISvcRegisterInformation registerInformation;
            HRESULT hr = Raw.GetRegisterInformation(registerId, out registerInformation);

            if (hr == HRESULT.S_OK)
                registerInformationResult = registerInformation == null ? null : new SvcRegisterInformation(registerInformation);
            else
                registerInformationResult = default(SvcRegisterInformation);

            return hr;
        }

        #endregion
        #region GetIdForAbstractRegister

        /// <summary>
        /// Gets the canonical register number for a given abstract register. If the architecture does not have such register (e.g.: the return address register is queried for X86), E_BOUNDS is returned.
        /// </summary>
        public int GetIdForAbstractRegister(SvcAbstractRegister abstractId)
        {
            int canonicalId;
            TryGetIdForAbstractRegister(abstractId, out canonicalId).ThrowDbgEngNotOK();

            return canonicalId;
        }

        /// <summary>
        /// Gets the canonical register number for a given abstract register. If the architecture does not have such register (e.g.: the return address register is queried for X86), E_BOUNDS is returned.
        /// </summary>
        public HRESULT TryGetIdForAbstractRegister(SvcAbstractRegister abstractId, out int canonicalId)
        {
            /*HRESULT GetIdForAbstractRegister(
            [In] SvcAbstractRegister abstractId,
            [Out] out int canonicalId);*/
            return Raw.GetIdForAbstractRegister(abstractId, out canonicalId);
        }

        #endregion
        #region CreateRegisterContext

        /// <summary>
        /// Creates an empty register context. While the canonical ISvcMachineArchitecture implementation is required to implement a "standard register record" that supports get/set of all registers in the architecture, there is **ABSOLUTELY NO REQUIREMENT** that this is the record returned by any call to get register state.<para/>
        /// Plug-ins are free to implement ISvcRegisterContext on their own.
        /// </summary>
        public SvcRegisterContext CreateRegisterContext()
        {
            SvcRegisterContext ppArchRegisterContextResult;
            TryCreateRegisterContext(out ppArchRegisterContextResult).ThrowDbgEngNotOK();

            return ppArchRegisterContextResult;
        }

        /// <summary>
        /// Creates an empty register context. While the canonical ISvcMachineArchitecture implementation is required to implement a "standard register record" that supports get/set of all registers in the architecture, there is **ABSOLUTELY NO REQUIREMENT** that this is the record returned by any call to get register state.<para/>
        /// Plug-ins are free to implement ISvcRegisterContext on their own.
        /// </summary>
        public HRESULT TryCreateRegisterContext(out SvcRegisterContext ppArchRegisterContextResult)
        {
            /*HRESULT CreateRegisterContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppArchRegisterContext);*/
            ISvcRegisterContext ppArchRegisterContext;
            HRESULT hr = Raw.CreateRegisterContext(out ppArchRegisterContext);

            if (hr == HRESULT.S_OK)
                ppArchRegisterContextResult = ppArchRegisterContext == null ? null : new SvcRegisterContext(ppArchRegisterContext);
            else
                ppArchRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region GetDirectoryBase

        /// <summary>
        /// From special registers, get the directory base (zero extended to 64-bit).
        /// </summary>
        public long GetDirectoryBase(DirectoryBaseKind dirKind, ISvcRegisterContext pSpecialContext)
        {
            /*long GetDirectoryBase(
            [In] DirectoryBaseKind dirKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);*/
            return Raw.GetDirectoryBase(dirKind, pSpecialContext);
        }

        #endregion
        #region GetPagingLevels

        /// <summary>
        /// From special registers, get the number of paging levels the hardware is configured to utilize.
        /// </summary>
        public void GetPagingLevels(ISvcRegisterContext pSpecialContext)
        {
            TryGetPagingLevels(pSpecialContext).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// From special registers, get the number of paging levels the hardware is configured to utilize.
        /// </summary>
        public HRESULT TryGetPagingLevels(ISvcRegisterContext pSpecialContext)
        {
            /*int GetPagingLevels(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pSpecialContext);*/
            return (HRESULT) Raw.GetPagingLevels(pSpecialContext);
        }

        #endregion
        #endregion
    }
}

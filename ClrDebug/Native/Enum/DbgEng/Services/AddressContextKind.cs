namespace ClrDebug.DbgEng
{
    public enum AddressContextKind : uint
    {
        /// <summary>
        /// This address context refers to the address context of a particular *execution unit* which can be queried for the directory base via a hardware register (e.g.: CR3 on AMD64) Such context must QI for ISvcExecutionUnitHardware successfully.
        /// </summary>
        AddressContextHardware,

        /// <summary>
        /// This address context refers to a process. The OS service may be able to query for the directory base or may not and this may only be valid to query virtual memory against.<para/>
        /// Such context must QI for ISvcProcess successfully.
        /// </summary>
        AddressContextProcess
    }
}

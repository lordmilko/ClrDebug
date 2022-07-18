using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The EXT_TYPED_DATA structure is passed to and returned from the DEBUG_REQUEST_EXT_TYPED_DATA_ANSI Request operation.<para/>
    /// It contains the input and output parameters for the operation as well as specifying which particular suboperation to perform.
    /// </summary>
    /// <remarks>
    /// The members of this structure are used as the input and output parameters to the DEBUG_REQUEST_EXT_TYPED_DATA_ANSI
    /// Request operation. The interpretation of most of the parameters depends on the particular suboperation being performed,
    /// as specified by the Operation member. This structure can optionally specify additional data--using the members
    /// InStrIndex and StrBufferIndex--that is included with the structure. This additional data is specified relative
    /// to the address of the instance of this structure. When used with the DEBUG_REQUEST_EXT_TYPED_DATA_ANSI Request
    /// operation, the additional data is included in the InBuffer and OutBuffer (as appropriate) and should be included
    /// in the size of these two buffers.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct EXT_TYPED_DATA
    {
        /// <summary>
        /// Specifies which suboperation the DEBUG_REQUEST_EXT_TYPED_DATA_ANSIRequest operation should perform. The interpretation of some of the other members depends on Operation.<para/>
        /// For a list of possible suboperations, see <see cref="EXT_TDOP"/>.
        /// </summary>
        public EXT_TDOP Operation;

        /// <summary>
        /// Specifies the bit flags describing the target's memory in which the data resides. If no flags are present, the data is considered to be in virtual memory.<para/>
        /// One of the following flags may be present:
        /// </summary>
        public EXT_TDF Flags;

        /// <summary>
        /// Specifies typed data to be used as input to the operation. For details about this structure, see <see cref="DEBUG_TYPED_DATA"/>.<para/>
        /// The interpretation of InData depends on the value of Operation.
        /// </summary>
        public DEBUG_TYPED_DATA InData;

        /// <summary>
        /// Receives typed data as output from the operation. Any suboperation that returns typed data to OutData initially copies the contents of InData to OutData, then modifies OutData in place, so that the input parameters in InData are also present in OutData.<para/>
        /// For details about this structure, see <see cref="DEBUG_TYPED_DATA"/>. The interpretation of OutData depends on the value of Operation.
        /// </summary>
        public DEBUG_TYPED_DATA OutData;

        /// <summary>
        /// Specifies the position of an ANSI string to be used as input to the operation. InStrIndex can be zero to indicate that the input parameters do not include an ANSI string.<para/>
        /// The position of the string is relative to the base address of this EXT_TYPED_DATA structure. The string must follow this structure, so InStrIndex must be greater than the size of this structure.<para/>
        /// The string is part of the input to the operation and InStrIndex must be smaller than InBufferSize, the size of the input buffer passed to Request.<para/>
        /// The interpretation of the string depends on the value of Operation.
        /// </summary>
        public uint InStrIndex;

        /// <summary>
        /// Specifies a 32-bit parameter to be used as input to the operation. The interpretation of In32 depends on the value of Operation.
        /// </summary>
        public uint In32;

        /// <summary>
        /// Receives a 32-bit value as output from the operation. The interpretation of Out32 depends on the value of Operation.
        /// </summary>
        public uint Out32;

        /// <summary>
        /// Specifies a 64-bit parameter to be used as input to the operation. The interpretation of In64 depends on the value of Operation.
        /// </summary>
        public ulong In64;

        /// <summary>
        /// Receives a 64-bit value as output from the operation. The interpretation of Out64 depends on the value of Operation.
        /// </summary>
        public ulong Out64;

        /// <summary>
        /// Specifies the position to return an ANSI string as output from the operation. StrBufferIndex can be zero if no ANSI string is to be received from the operation.<para/>
        /// The position of the string is relative to the base address of the returned EXT_TYPED_DATA structure. The string must follow the structure, so StrBufferIndex must be greater than the size of this structure.<para/>
        /// The string is part of the output from the suboperation, and StrBufferIndex plus StrBufferChars must be smaller than OutBufferSize, the size of the output buffer passed to Request.<para/>
        /// The interpretation of the string depends on the value of Operation.
        /// </summary>
        public uint StrBufferIndex;

        /// <summary>
        /// Specifies the size in characters of the ANSI string buffer specified by StrBufferIndex.
        /// </summary>
        public uint StrBufferChars;

        /// <summary>
        /// Receives the number of characters needed by the string buffer specified by StrBufferIndex.
        /// </summary>
        public uint StrCharsNeeded;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public uint DataBufferIndex;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public uint DataBufferBytes;

        /// <summary>
        /// Set to zero,
        /// </summary>
        public uint DataBytesNeeded;

        /// <summary>
        /// Receives the status code returned by the operation. This is the same value returned by Request.
        /// </summary>
        public HRESULT Status;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public fixed ulong Reserved[8];
    }
}

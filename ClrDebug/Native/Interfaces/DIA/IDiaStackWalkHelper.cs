using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Facilitates walking the stack using the program debug database (.pdb) file.
    /// </summary>
    /// <remarks>
    /// This interface is called by the DIA code to obtain information about the executable to construct a list of stack
    /// frames during program execution. A client application implements this interface to support walking the stack during
    /// program execution. An instance of this interface is passed to the IDiaStackWalker or IDiaStackWalker methods.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("21F81B1B-C5BB-42A3-BC4F-CCBAA75B9F19")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaStackWalkHelper
    {
        [PreserveSig]
        HRESULT get_registerValue(
            [In] CV_HREG_e index,
            [Out] out long pRetVal);

        [PreserveSig]
        HRESULT put_registerValue(
            [In] CV_HREG_e index,
            [In] long NewVal);

        [PreserveSig]
        HRESULT readMemory(
            [In] MemoryTypeEnum type,
            [In] long va,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbData);

        [PreserveSig]
        HRESULT searchForReturnAddress(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [Out] out long returnAddress);

        /// <summary>
        /// Searches the specified stack frame for a return address at or near the specified stack address.
        /// </summary>
        /// <param name="frame">[in] An IDiaFrameData object that represents the current stack frame.</param>
        /// <param name="startAddress">[in] A virtual memory address from which to begin searching.</param>
        /// <param name="returnAddress">[out] Returns the nearest function return address to startAddress.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT searchForReturnAddressStart(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [In] long startAddress,
            [Out] out long returnAddress);

        [PreserveSig]
        HRESULT frameForVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData ppFrame);

        /// <summary>
        /// Retrieves the symbol that contains the specified virtual address.
        /// </summary>
        /// <param name="va">[in] The virtual address that is contained in the requested symbol. The symbol must be a SymTagFunctionType (a value from the SymTagEnum Enumeration enumeration).</param>
        /// <param name="ppSymbol">[out] An IDiaSymbol object that represents the symbol at the specified address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT symbolForVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        [PreserveSig]
        HRESULT pdataForVA(
            [In] long va,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData);

        /// <summary>
        /// Returns the start of an executable's image in memory given a virtual address somewhere in the executable's memory space.
        /// </summary>
        /// <param name="vaContext">[in] The virtual address that lies somewhere in the executable's space.</param>
        /// <param name="pvaImageStart">[out] Returns the starting virtual address of the executable's image.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT imageForVA(
            [In] long vaContext,
            [Out] out long pvaImageStart);

        [PreserveSig]
        HRESULT addressForVA(
            [In] long va,
            [Out] out int pISect,
            [Out] out int pOffset);

        [PreserveSig]
        HRESULT numberOfFunctionFragmentsForVA(
            [In] long vaFunc,
            [In] int cbFunc,
            [Out] out int pNumFragments);

        [PreserveSig]
        HRESULT functionFragmentsForVA(
            [In] long vaFunc,
            [In] int cbFunc,
            [In] int cFragments,
            [Out] out long pVaFragment,
            [Out] out int pLenFragment);
    }
}

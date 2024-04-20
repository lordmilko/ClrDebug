using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    [Guid("8222C490-507B-4BEF-B3BD-41DCA7B5934C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaStackWalkHelper2 : IDiaStackWalkHelper
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT get_registerValue(
            [In] CV_HREG_e index,
            [Out] out long pRetVal);

        [PreserveSig]
        new HRESULT put_registerValue(
            [In] CV_HREG_e index,
            [In] long NewVal);

        [PreserveSig]
        new HRESULT readMemory(
            [In] MemoryTypeEnum type,
            [In] long va,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbData);

        [PreserveSig]
        new HRESULT searchForReturnAddress(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [Out] out long returnAddress);

        /// <summary>
        /// Searches the specified stack frame for a return address at or near the specified stack address.
        /// </summary>
        /// <param name="frame">[in] An <see cref="IDiaFrameData"/> object that represents the current stack frame.</param>
        /// <param name="startAddress">[in] A virtual memory address from which to begin searching.</param>
        /// <param name="returnAddress">[out] Returns the nearest function return address to startAddress.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT searchForReturnAddressStart(
            [MarshalAs(UnmanagedType.Interface), In] IDiaFrameData frame,
            [In] long startAddress,
            [Out] out long returnAddress);

        [PreserveSig]
        new HRESULT frameForVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData ppFrame);

        /// <summary>
        /// Retrieves the symbol that contains the specified virtual address.
        /// </summary>
        /// <param name="va">[in] The virtual address that is contained in the requested symbol. The symbol must be a SymTagFunctionType (a value from the <see cref="SymTagEnum"/> enumeration).</param>
        /// <param name="ppSymbol">[out] An <see cref="IDiaSymbol"/> object that represents the symbol at the specified address.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        new HRESULT symbolForVA(
            [In] long va,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);

        [PreserveSig]
        new HRESULT pdataForVA(
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
        new HRESULT imageForVA(
            [In] long vaContext,
            [Out] out long pvaImageStart);

        [PreserveSig]
        new HRESULT addressForVA(
            [In] long va,
            [Out] out int pISect,
            [Out] out int pOffset);

        [PreserveSig]
        new HRESULT numberOfFunctionFragmentsForVA(
            [In] long vaFunc,
            [In] int cbFunc,
            [Out] out int pNumFragments);

        [PreserveSig]
        new HRESULT functionFragmentsForVA(
            [In] long vaFunc,
            [In] int cbFunc,
            [In] int cFragments,
            [Out] out long pVaFragment,
            [Out] out int pLenFragment);
#endif

        [PreserveSig]
        HRESULT GetPointerAuthenticationMask(
            [In] long PtrVal,
            [Out] out long AuthMask);
    }
}

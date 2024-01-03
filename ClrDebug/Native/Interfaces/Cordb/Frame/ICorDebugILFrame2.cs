using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// A logical extension of the <see cref="ICorDebugILFrame"/> interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5D88A994-6C30-479B-890F-BCEF88B129A5")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugILFrame2
    {
        /// <summary>
        /// Remaps an edited function by specifying the new Microsoft intermediate language (MSIL) offset
        /// </summary>
        /// <param name="newILOffset">[in] The stack frame's new MSIL offset at which the instruction pointer should be placed. This value must be a sequence point.<para/>
        /// It is the caller’s responsibility to ensure the validity of this value. For example, the MSIL offset is not valid if it is outside the bounds of the function.</param>
        /// <remarks>
        /// When a frame’s function has been edited, the debugger can call the RemapFunction method to swap in the latest version
        /// of the frame's function so it can be executed. The code execution will begin at the given MSIL offset. The RemapFunction
        /// method can be called only in the context of the current frame, and only in one of the following cases:
        /// </remarks>
        [PreserveSig]
        HRESULT RemapFunction(
            [In] int newILOffset);

        /// <summary>
        /// Gets an <see cref="ICorDebugTypeEnum"/> object that contains the <see cref="Type"/> parameters in this frame.
        /// </summary>
        /// <param name="ppTyParEnum">A pointer to the address of a <see cref="ICorDebugTypeEnum"/> interface object that allows enumeration of type parameters. The list of type parameters include the class type parameters (if any) followed by the method type parameters (if any).</param>
        /// <remarks>
        /// Use the <see cref="IMetaDataImport2.EnumGenericParams"/> method to determine how many class type parameters and
        /// method type parameters this list contains. The type parameters are not always available.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumerateTypeParameters(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);
    }
}

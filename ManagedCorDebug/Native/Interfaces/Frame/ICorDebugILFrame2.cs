using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A logical extension of the ICorDebugILFrame interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5D88A994-6C30-479B-890F-BCEF88B129A5")]
    [ComImport]
    public interface ICorDebugILFrame2
    {
        /// <summary>
        /// Remaps an edited function by specifying the new Microsoft intermediate language (MSIL) offset
        /// </summary>
        /// <param name="newILOffset">[in] The stack frame's new MSIL offset at which the instruction pointer should be placed. This value must be a sequence point.
        /// It is the caller’s responsibility to ensure the validity of this value. For example, the MSIL offset is not valid if it is outside the bounds of the function.</param>
        /// <remarks>
        /// When a frame’s function has been edited, the debugger can call the RemapFunction method to swap in the latest version
        /// of the frame's function so it can be executed. The code execution will begin at the given MSIL offset. The RemapFunction
        /// method can be called only in the context of the current frame, and only in one of the following cases:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RemapFunction([In] uint newILOffset);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateTypeParameters([MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);
    }
}
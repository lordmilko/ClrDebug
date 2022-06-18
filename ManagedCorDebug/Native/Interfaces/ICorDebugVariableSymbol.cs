using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Retrieves the debug symbol information for a variable.
    /// </summary>
    [Guid("707E8932-1163-48D9-8A93-F5B1F480FBB7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugVariableSymbol
    {
        /// <summary>
        /// Gets the name of a variable.
        /// </summary>
        /// <param name="cchName">[in] The number of characters in the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to the number of characters actually written to the szName buffer.</param>
        /// <param name="szName">A pointer to a character array that contains the variable name.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);

        /// <summary>
        /// Gets the size of a variable in bytes.
        /// </summary>
        /// <param name="pcbValue">A pointer to a 32-bit unsigned integer containing the size of the variable.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize([Out] out int pcbValue);

        /// <summary>
        /// Gets the value of a variable as a byte array.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable from which to read the value. This parameter is used when reading member fields in an object.</param>
        /// <param name="cbContext">[in] The size in bytes of the context argument.</param>
        /// <param name="context">[in] The thread context used to read the value.</param>
        /// <param name="cbValue">[in] The size in bytes of the pValue buffer.</param>
        /// <param name="pcbValue">[out] The number of bytes actually written to the pValue buffer.</param>
        /// <param name="pValue">[out] A byte array that contains the value of the variable.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetValue(
            [In] int offset,
            [In] int cbContext,
            [In] IntPtr context,
            [In] int cbValue,
            [Out] out int pcbValue,
            [MarshalAs(UnmanagedType.LPArray), Out] byte[] pValue);

        /// <summary>
        /// Assigns the value of a byte array to a variable.
        /// </summary>
        /// <param name="offset">[in] The starting offset in the variable at which to set the value. This parameter is used when writing to member fields in an object.</param>
        /// <param name="threadID">[in] The thread identifier of the thread whose context must be updated to reflect the new value.</param>
        /// <param name="cbContext">[in] The size in bytes of the thread context.</param>
        /// <param name="context">[in] The thread context used to write the value.</param>
        /// <param name="cbValue">[in] The size in bytes of the pValue buffer.</param>
        /// <param name="pValue">[in] The buffer that contains the value to set.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetValue(
            [In] int offset,
            [In] int threadID,
            [In] int cbContext,
            [In] IntPtr context,
            [In] int cbValue,
            [In] IntPtr pValue);

        /// <summary>
        /// Gets the managed slot index of a local variable.
        /// </summary>
        /// <param name="pSlotIndex">[out] A pointer to the local variable's slot index.</param>
        /// <returns>S_OK if successful. E_FAIL if the variable is a function argument.</returns>
        /// <remarks>
        /// The managed slot index of a local variable can be used to retrieve the variable's metadata information
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSlotIndex([Out] out int pSlotIndex);
    }
}
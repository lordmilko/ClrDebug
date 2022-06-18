using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the "ICorDebugValue" and "ICorDebugValue2" interfaces to provide support for arrays that are larger than 2 GB.
    /// </summary>
    /// <remarks>
    /// The <see cref="GetSize64"/> method returns an object size that ranges from 0 to 2,147,483,647 bytes. In the .NET
    /// Framework 4.5, the size of arrays can exceed 2 GB. The <see cref="ICorDebugValue3"/> interface enables you to determine the size
    /// of these arrays.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("565005FC-0F8A-4F3E-9EDB-83102B156595")]
    [ComImport]
    public interface ICorDebugValue3
    {
        /// <summary>
        /// Gets the size, in bytes, of this <see cref="ICorDebugValue3"/> object.
        /// </summary>
        /// <param name="pSize">[out] A pointer to the size, in bytes, of this object.</param>
        /// <remarks>
        /// If this value's type is a reference type, this method returns the size of the pointer rather than the size of the
        /// object. The <see cref="GetSize64"/> method differs from the <see cref="ICorDebugValue.GetSize"/> method in the
        /// type of its output parameter. In <see cref="ICorDebugValue.GetSize"/>, the output parameter is a ULONG32; in <see cref="GetSize64"/>,
        /// it is a ULONG64. This enables the <see cref="ICorDebugValue3"/> interface to report the size of arrays that exceed
        /// 2GB.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSize64([Out] out long pSize);
    }
}
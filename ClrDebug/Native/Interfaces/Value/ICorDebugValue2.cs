using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Extends the "ICorDebugValue" interface to provide support for "ICorDebugType" objects.
    /// </summary>
    [Guid("5E0B54E7-D88A-4626-9420-A691E0A78B49")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugValue2
    {
        /// <summary>
        /// Gets an interface pointer to an "ICorDebugType" object that represents the <see cref="Type"/> of this value.
        /// </summary>
        /// <param name="ppType">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the <see cref="Type"/> of the value represented by this "ICorDebugValue2" object.</param>
        /// <remarks>
        /// The generics-aware GetExactType method supersedes both the <see cref="ICorDebugObjectValue.GetClass"/> and the
        /// <see cref="ICorDebugValue.GetType(out CorElementType)"/> methods, each of which return information about the type
        /// of a value.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetExactType([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
    }
}
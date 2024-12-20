using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to abstract runtime type information (whether RTTI based or based upon another type system).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F6B2366A-C094-4072-845D-A06E5C97F77F")]
    [ComImport]
    public interface ISvcSymbolSetRuntimeTypeInformation
    {
        /// <summary>
        /// For an object of a given type at a given address within a specified address context (e.g.: process), utilize RTTI or other type system information to determine the actual runtime type of the object and its location.<para/>
        /// This method can arbitrarily fail.
        /// </summary>
        [PreserveSig]
        HRESULT GetRuntimeType(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long staticObjectOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType staticObjectType,
            [Out] out long runtimeObjectOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType runtimeObjectType);
    }
}

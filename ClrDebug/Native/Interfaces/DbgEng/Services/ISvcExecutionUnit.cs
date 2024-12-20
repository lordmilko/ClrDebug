using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcExecutionUnit interface is provided by a debug primitive which is capable of execution of code. This may be a thread.<para/>
    /// It may be a processor core.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("01C932D4-9F5E-4268-8B12-EC246582A82D")]
    [ComImport]
    public interface ISvcExecutionUnit
    {
        /// <summary>
        /// Gets the register context of the execution unit. Which categories of registers are retrieved is dependent upon the flags passed in.<para/>
        /// If the method returns S_OK, all registers of the given categories were retrieved. If the method returns S_FALSE, some registers of the given categories were retrieved.<para/>
        /// S_FALSE may indicate that an entire category was not retrieved (e.g.: a dump or core contains no record of SSE/AVX registers) or it may indicate that some registers of a category were retrieved and some were not.
        /// </summary>
        [PreserveSig]
        HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);

        /// <summary>
        /// Sets the register context of the execution unit. Which categories of registers are written is dependent upon the flags passed in.<para/>
        /// The S_OK/S_FALSE definitions mirror GetContextEx. Note that registers which are not contained in the register context will not be written regardless of what SvcContextFlags indicates.
        /// </summary>
        [PreserveSig]
        HRESULT SetContext(
            [In] SvcContextFlags contextFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pRegisterContext);
    }
}

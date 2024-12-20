using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7FA6E76A-FEE4-44BF-82B9-E41B6FBC87DF")]
    [ComImport]
    public interface IComponentStackUnwindContextInitializer2 : IComponentStackUnwindContextInitializer
    {
        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT component.
        /// </summary>
        [PreserveSig]
        new HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess unwindProcess,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcThread unwindThread);

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT component.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize2(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess unwindProcess,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit unwindExecUnit);
    }
}

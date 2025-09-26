using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("316D57FC-A856-400A-A259-93D9166955AF")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcEventArgumentExecutionStateChange
    {
        /// <summary>
        /// Gets the kind of execution state change which has occurred.
        /// </summary>
        [PreserveSig]
        SvcExecutionStateChangeKind GetChangeKind();

        /// <summary>
        /// Gets the process and/or execution unit which is affected by the state change. These may be null on output, indicating that the change affected every process/execution unit in the debug target.
        /// </summary>
        [PreserveSig]
        HRESULT GetChangeEffects(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit executionUnit);
    }
}

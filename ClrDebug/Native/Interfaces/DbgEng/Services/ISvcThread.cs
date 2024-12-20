using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// It is expected that any implementation of ISvcThread will successfully QI for ISvcExecutionUnit in order to read thread context and provide other core attributes of something which can successfully "step".
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C6648B7C-F2E4-4304-9A3E-ED71CF0F26C6")]
    [ComImport]
    public interface ISvcThread
    {
        /// <summary>
        /// Gets the unique key of the process to which this thread belongs. This is the same key returned from the containing ISvcProcess's GetKey method.
        /// </summary>
        [PreserveSig]
        HRESULT GetContainingProcessKey(
            [Out] out long containingProcessKey);

        /// <summary>
        /// Gets the unique "per-process" thread key. The interpretation of this key is dependent upon the service which provides this interface.<para/>
        /// For Windows Kernel, this may be the address of an ETHREAD in the target. For Windows User, this may be the TID.
        /// </summary>
        [PreserveSig]
        HRESULT GetKey(
            [Out] out long threadKey);

        /// <summary>
        /// Gets the thread's ID as defined by the underlying platform. This may or may not be the same value as returned from GetKey.
        /// </summary>
        [PreserveSig]
        HRESULT GetId(
            [Out] out long threadId);
    }
}

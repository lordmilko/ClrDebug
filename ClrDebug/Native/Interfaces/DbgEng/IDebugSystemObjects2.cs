using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0ae9f5ff-1852-4679-b055-494bee6407ee")]
    [ComImport]
    public interface IDebugSystemObjects2 : IDebugSystemObjects
    {
        #region IDebugSystemObjects

        [PreserveSig]
        new HRESULT GetEventThread(
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetEventProcess(
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentThreadId(
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT SetCurrentThreadId(
            [In] uint Id);

        [PreserveSig]
        new HRESULT GetCurrentProcessId(
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT SetCurrentProcessId(
            [In] uint Id);

        [PreserveSig]
        new HRESULT GetNumberThreads(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetTotalNumberThreads(
            [Out] out uint Total,
            [Out] out uint LargestProcess);

        [PreserveSig]
        new HRESULT GetThreadIdsByIndex(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] SysIds);

        [PreserveSig]
        new HRESULT GetThreadIdByProcessor(
            [In] uint Processor,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentThreadDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetThreadIdByDataOffset(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentThreadTeb(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetThreadIdByTeb(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentThreadSystemId(
            [Out] out uint SysId);

        [PreserveSig]
        new HRESULT GetThreadIdBySystemId(
            [In] uint SysId,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentThreadHandle(
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT GetThreadIdByHandle(
            [In] ulong Handle,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetNumberProcesses(
            [Out] out uint Number);

        [PreserveSig]
        new HRESULT GetProcessIdsByIndex(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            uint[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            uint[] SysIds);

        [PreserveSig]
        new HRESULT GetCurrentProcessDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetProcessIdByDataOffset(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentProcessPeb(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT GetProcessIdByPeb(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentProcessSystemId(
            [Out] out uint SysId);

        [PreserveSig]
        new HRESULT GetProcessIdBySystemId(
            [In] uint SysId,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentProcessHandle(
            [Out] out ulong Handle);

        [PreserveSig]
        new HRESULT GetProcessIdByHandle(
            [In] ulong Handle,
            [Out] out uint Id);

        [PreserveSig]
        new HRESULT GetCurrentProcessExecutableName(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExeSize);

        #endregion
        #region IDebugSystemObjects2

        [PreserveSig]
        HRESULT GetCurrentProcessUpTime(
            [Out] out uint UpTime);

        [PreserveSig]
        HRESULT GetImplicitThreadDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT SetImplicitThreadDataOffset(
            [In] ulong Offset);

        [PreserveSig]
        HRESULT GetImplicitProcessDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT SetImplicitProcessDataOffset(
            [In] ulong Offset);

        #endregion
    }
}

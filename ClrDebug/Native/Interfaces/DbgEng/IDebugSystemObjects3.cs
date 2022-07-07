using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("e9676e2f-e286-4ea3-b0f9-dfe5d9fc330e")]
    [ComImport]
    public interface IDebugSystemObjects3 : IDebugSystemObjects2
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
            [Out, MarshalAs(UnmanagedType.LPArray)]
            uint[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray)]
            uint[] SysIds);

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
        new HRESULT GetCurrentProcessUpTime(
            [Out] out uint UpTime);

        [PreserveSig]
        new HRESULT GetImplicitThreadDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT SetImplicitThreadDataOffset(
            [In] ulong Offset);

        [PreserveSig]
        new HRESULT GetImplicitProcessDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        new HRESULT SetImplicitProcessDataOffset(
            [In] ulong Offset);

        #endregion
        #region IDebugSystemObjects3

        [PreserveSig]
        HRESULT GetEventSystem([Out] out uint id);

        [PreserveSig]
        HRESULT GetCurrentSystemId([Out] out uint id);

        [PreserveSig]
        HRESULT SetCurrentSystemId([In] uint id);

        [PreserveSig]
        HRESULT GetNumberSystems([Out] out uint count);

        [PreserveSig]
        HRESULT GetSystemIdsByIndex(
            [In] uint start,
            [In] uint count,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] Ids);

        [PreserveSig]
        HRESULT GetTotalNumberThreadsAndProcesses(
            [Out] out uint totalThreads,
            [Out] out uint totalProcesses,
            [Out] out uint largestProcessThreads,
            [Out] out uint largestSystemThreads,
            [Out] out uint largestSystemProcesses);

        [PreserveSig]
        HRESULT GetCurrentSystemServer([Out] out ulong server);

        [PreserveSig]
        HRESULT GetSystemByServer([In] ulong server, [Out] out uint id);
        [PreserveSig]
        HRESULT GetCurrentSystemServerName([Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, [In] uint size, [Out] out uint needed);

        #endregion
    }
}

using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6b86fe2c-2c4f-4f0c-9da2-174311acc327")]
    [ComImport]
    public interface IDebugSystemObjects
    {
        [PreserveSig]
        HRESULT GetEventThread(
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetEventProcess(
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentThreadId(
            [Out] out uint Id);

        [PreserveSig]
        HRESULT SetCurrentThreadId(
            [In] uint Id);

        [PreserveSig]
        HRESULT GetCurrentProcessId(
            [Out] out uint Id);

        [PreserveSig]
        HRESULT SetCurrentProcessId(
            [In] uint Id);

        [PreserveSig]
        HRESULT GetNumberThreads(
            [Out] out uint Number);

        [PreserveSig]
        HRESULT GetTotalNumberThreads(
            [Out] out uint Total,
            [Out] out uint LargestProcess);

        [PreserveSig]
        HRESULT GetThreadIdsByIndex(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] SysIds);

        [PreserveSig]
        HRESULT GetThreadIdByProcessor(
            [In] uint Processor,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentThreadDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetThreadIdByDataOffset(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentThreadTeb(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetThreadIdByTeb(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentThreadSystemId(
            [Out] out uint SysId);

        [PreserveSig]
        HRESULT GetThreadIdBySystemId(
            [In] uint SysId,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentThreadHandle(
            [Out] out ulong Handle);

        [PreserveSig]
        HRESULT GetThreadIdByHandle(
            [In] ulong Handle,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetNumberProcesses(
            [Out] out uint Number);

        [PreserveSig]
        HRESULT GetProcessIdsByIndex(
            [In] uint Start,
            [In] uint Count,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] Ids,
            [Out, MarshalAs(UnmanagedType.LPArray)] uint[] SysIds);

        [PreserveSig]
        HRESULT GetCurrentProcessDataOffset(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetProcessIdByDataOffset(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentProcessPeb(
            [Out] out ulong Offset);

        [PreserveSig]
        HRESULT GetProcessIdByPeb(
            [In] ulong Offset,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentProcessSystemId(
            [Out] out uint SysId);

        [PreserveSig]
        HRESULT GetProcessIdBySystemId(
            [In] uint SysId,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentProcessHandle(
            [Out] out ulong Handle);

        [PreserveSig]
        HRESULT GetProcessIdByHandle(
            [In] ulong Handle,
            [Out] out uint Id);

        [PreserveSig]
        HRESULT GetCurrentProcessExecutableName(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] int BufferSize,
            [Out] out uint ExeSize);
    }
}

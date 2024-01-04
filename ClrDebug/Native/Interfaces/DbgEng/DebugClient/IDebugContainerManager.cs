using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    //Service GUID: 5D20504A-8A2A-4DD0-AFD8-3DC7D7EE1F0E

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("390a7e36-079a-4dbe-82d6-76c96fa040b2")]
    [ComImport]
    public interface IDebugContainerManager
    {
        [PreserveSig]
        HRESULT CreateContainer(
            [MarshalAs(UnmanagedType.LPWStr), In] string owner,
            [In] int maxContainerMemory,
            [Out] out long container);

        [PreserveSig]
        HRESULT OpenContainer(
            [MarshalAs(UnmanagedType.LPStruct), In] Guid id,
            [Out] out long container);

        [PreserveSig]
        HRESULT CloseContainer(
            [In] long container);

        [PreserveSig]
        HRESULT GetOwner(
            [In] long containerHandle,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), SRI.Out] char[] owner,
            [In] int ownerSize,
            [Out] out int ownerRequiredSize);

        [PreserveSig]
        HRESULT StartActivity(
            [In] long container,
            [Out] out long activity);

        [PreserveSig]
        HRESULT StartProcessInContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string commandLine,
            [MarshalAs(UnmanagedType.LPWStr), In] string username,
            [In] bool useExistingLoginSession);

        [PreserveSig]
        HRESULT RunProcessInContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string commandLine,
            [MarshalAs(UnmanagedType.LPWStr), In] string username,
            [In] bool useExistingLoginSession,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream programOutput,
            [Out] out int exitCode);

        [PreserveSig]
        HRESULT MapFolderToContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string hostFolder,
            [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder,
            [In] bool readOnly);

        [PreserveSig]
        HRESULT UnmapFolderFromContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder);

        [PreserveSig]
        HRESULT StopActivity(
            [In] long activity);

        [PreserveSig]
        HRESULT EnumerateContainers(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] Guid[] containerGuids,
            [In] int size,
            [Out] out int numContainers);
    }
}

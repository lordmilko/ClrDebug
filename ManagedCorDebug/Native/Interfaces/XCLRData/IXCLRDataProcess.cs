using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [Guid("5c552ab6-fc09-4cb3-8e36-22fa03c798b7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataProcess
    {
        [PreserveSig]
        HRESULT Flush();

        [PreserveSig]
        HRESULT StartEnumTasks(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumTask(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataTask task);

        [PreserveSig]
        HRESULT EndEnumTasks(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetTaskByOSThreadID(
            [In] int osThreadID,
            [Out] out IXCLRDataTask task);

        [PreserveSig]
        HRESULT GetTaskByUniqueID(
            [In] long taskID,
            [Out] out IXCLRDataTask task);

        [PreserveSig]
        HRESULT GetFlags(
            [Out] out CLRDataProcessFlag flags);

        [PreserveSig]
        HRESULT IsSameObject(
            [In] IXCLRDataProcess process);

        [PreserveSig]
        HRESULT GetManagedObject(
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT GetDesiredExecutionState(
            [Out] out int state);

        [PreserveSig]
        HRESULT SetDesiredExecutionState(
            [In] int state);

        [PreserveSig]
        HRESULT GetAddressType(
            [In] CLRDATA_ADDRESS address,
            [Out] out CLRDataAddressType type);

        [PreserveSig]
        HRESULT GetRuntimeNameByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int flags,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out CLRDATA_ADDRESS displacement);

        [PreserveSig]
        HRESULT StartEnumAppDomains(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumAppDomain(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT EndEnumAppDomains(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetAppDomainByUniqueID(
            [In] long id,
            [Out] out IXCLRDataAppDomain appDomain);

        [PreserveSig]
        HRESULT StartEnumAssemblies(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumAssembly(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataAssembly assembly);

        [PreserveSig]
        HRESULT EndEnumAssemblies(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT StartEnumModules(
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumModule(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT EndEnumModules(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetModuleByAddress(
            [In] CLRDATA_ADDRESS address,
            [Out] out IXCLRDataModule mod);

        [PreserveSig]
        HRESULT StartEnumMethodInstancesByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodInstanceByAddress(
            [In] IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT EndEnumMethodInstancesByAddress(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetDataByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int flags,
            [In] IXCLRDataAppDomain appDomain,
            [In] IXCLRDataTask tlsTask,
            [In] int bufLen,
            [Out] out int nameLen,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder nameBuf,
            [Out] out IXCLRDataValue value,
            [Out] out CLRDATA_ADDRESS displacement);

        [PreserveSig]
        HRESULT GetExceptionStateByExceptionRecord(
            [In] EXCEPTION_RECORD64 record,
            [Out] out IXCLRDataExceptionState exState);

        [PreserveSig]
        HRESULT TranslateExceptionRecordToNotification(
            [In] ref EXCEPTION_RECORD64 record,
            [In] IXCLRDataExceptionNotification notify);

        [PreserveSig]
        HRESULT Request(
            [In] uint reqCode,
            [In] int inBufferSize,
            [In] IntPtr inBuffer,
            [In] int outBufferSize,
            [Out] IntPtr outBuffer);

        [PreserveSig]
        HRESULT CreateMemoryValue(
            [In] IXCLRDataAppDomain appDomain,
            [In] IXCLRDataTask tlsTask,
            [In] IXCLRDataTypeInstance type,
            [In] CLRDATA_ADDRESS addr,
            [Out] out IXCLRDataValue value);

        [PreserveSig]
        HRESULT SetAllTypeNotifications(
            [In] IXCLRDataModule mod,
            [In] int flags);

        [PreserveSig]
        HRESULT SetAllCodeNotifications(
            [In] IXCLRDataModule mod,
            [In] int flags);

        [PreserveSig]
        HRESULT GetTypeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdTypeDef tokens,
            [Out] out int flags);

        [PreserveSig]
        HRESULT SetTypeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdTypeDef tokens,
            [In] int flags,
            [In] int singleFlags);

        [PreserveSig]
        HRESULT GetCodeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdMethodDef tokens,
            [Out] out int flags);

        [PreserveSig]
        HRESULT SetCodeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In] mdMethodDef tokens,
            [In] int flags,
            [In] int singleFlags);

        [PreserveSig]
        HRESULT GetOtherNotificationFlags(
            [Out] out int flags);

        [PreserveSig]
        HRESULT SetOtherNotificationFlags(
            [In] int flags);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitionsByAddress(
            [In] CLRDATA_ADDRESS address,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodDefinitionByAddress(
            [In] IntPtr handle,
            [Out] out IXCLRDataMethodDefinition method);

        [PreserveSig]
        HRESULT EndEnumMethodDefinitionsByAddress([In] IntPtr handle);

        [PreserveSig]
        HRESULT FollowStub(
            [In] int inFlags,
            [In] CLRDATA_ADDRESS inAddr,
            [In] ref CLRDATA_FOLLOW_STUB_BUFFER inBuffer,
            [Out] out CLRDATA_ADDRESS outAddr,
            [Out] out CLRDATA_FOLLOW_STUB_BUFFER outBuffer,
            [Out] out int outFlags);

        [PreserveSig]
        HRESULT FollowStub2(
            [In] IXCLRDataTask task,
            [In] int inFlags,
            [In] CLRDATA_ADDRESS inAddr,
            [In] ref CLRDATA_FOLLOW_STUB_BUFFER inBuffer,
            [Out] out CLRDATA_ADDRESS outAddr,
            [Out] out CLRDATA_FOLLOW_STUB_BUFFER outBuffer,
            [Out] out int outFlags);

        [PreserveSig]
        HRESULT DumpNativeImage([In] CLRDATA_ADDRESS loadedBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] IXCLRDataDisplay display,
            [In] IXCLRLibrarySupport libSupport,
            [In] IXCLRDisassemblySupport dis);
    }
}

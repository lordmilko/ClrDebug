﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for querying information about a process.
    /// </summary>
    /// <remarks>
    /// This interface lives inside the runtime and is not exposed through any headers or library files. However, it's
    /// a COM interface that derives from IUnknown with GUID 5c552ab6-fc09-4cb3-8e36-22fa03c798b7 that can be obtained
    /// through the usual COM mechanisms.
    /// </remarks>
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

        /// <summary>
        /// Gets a name for the given address.
        /// </summary>
        /// <param name="address">[in] A CLRDATA_ADDRESS value that represents a code address.</param>
        /// <param name="flags">[in] Set to '0'.</param>
        /// <param name="bufLen">[in] The length of the buffer.</param>
        /// <param name="nameLen">[out] A pointer to the number of characters returned.</param>
        /// <param name="nameBuf">[out, size_is(bufLen)] The input buffer of length bufLen that stores the runtime name.</param>
        /// <param name="displacement">[out] A CLRDATA_ADDRESS pointer to the code offset of the returned symbol.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 16th slot of the virtual-method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT GetRuntimeNameByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int flags, //Unused, must be 0
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

        /// <summary>
        /// Gets an AppDomain in a process based on its unique identifier.
        /// </summary>
        /// <param name="id">[in] The unique identifier of the AppDomain</param>
        /// <param name="appDomain">[out] The AppDomain</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 20th slot of the virtual method
        /// table. The IXCLRDataAppDomain* returned is used for interaction with other APIs.
        /// </remarks>
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

        /// <summary>
        /// Provides a handle to enumerate the modules of a process.
        /// </summary>
        /// <param name="handle">[out] A handle for enumerating the modules.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 24th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT StartEnumModules(
            [Out] out IntPtr handle);

        /// <summary>
        /// Enumerates the modules of this process.
        /// </summary>
        /// <param name="handle">[in, out] A handle for enumerating the modules.</param>
        /// <param name="mod">[out] The enumerated module.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 25th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumModule(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataModule mod);

        /// <summary>
        /// Releases the resources used by internal iterators used during module enumeration.
        /// </summary>
        /// <param name="handle">[out] A handle for enumerating the modules.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 26th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT EndEnumModules(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetModuleByAddress(
            [In] CLRDATA_ADDRESS address,
            [Out] out IXCLRDataModule mod);

        /// <summary>
        /// Provides a handle to enumerate the method instances of AppDomain starting at a given address.
        /// </summary>
        /// <param name="address">[in] The address of the first method instance.</param>
        /// <param name="appDomain">[in] The AppDomain of the method instances.</param>
        /// <param name="handle">[out] A handle for enumerating the method instances.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 28th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT StartEnumMethodInstancesByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] IXCLRDataAppDomain appDomain,
            [Out] out IntPtr handle);

        /// <summary>
        /// Enumerates the method instances of this process starting at an address offset.
        /// </summary>
        /// <param name="handle">[in] A handle for enumerating the method instances.</param>
        /// <param name="method">[out] The enumerated method instance.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 29th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumMethodInstanceByAddress(
            [In, Out] ref IntPtr handle,
            [Out] out IXCLRDataMethodInstance method);

        /// <summary>
        /// Releases the resources used by internal iterators used during instance enumeration.
        /// </summary>
        /// <param name="handle">[out] A handle for enumerating the method instances.</param>
        /// <remarks>
        /// The provided method is part of the IXCLRDataProcess interface and corresponds to the 30th slot of the virtual method
        /// table.
        /// </remarks>
        [PreserveSig]
        HRESULT EndEnumMethodInstancesByAddress(
            [In] IntPtr handle);

        [PreserveSig]
        HRESULT GetDataByAddress(
            [In] CLRDATA_ADDRESS address,
            [In] int flags, //Unused, must be 0
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
            [In] uint reqCode, //Requests can be across a variety of enums
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
            [In] CLRDataMethodCodeNotification flags);

        [PreserveSig]
        HRESULT GetTypeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In, MarshalAs(UnmanagedType.LPArray)] mdTypeDef[] tokens,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] flags);

        [PreserveSig]
        HRESULT SetTypeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In, MarshalAs(UnmanagedType.LPArray)] mdTypeDef[] tokens,
            [In, MarshalAs(UnmanagedType.LPArray)] int[] flags,
            [In] int singleFlags);

        [PreserveSig]
        HRESULT GetCodeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In, MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] tokens,
            [Out, MarshalAs(UnmanagedType.LPArray)] CLRDataMethodCodeNotification[] flags);

        [PreserveSig]
        HRESULT SetCodeNotifications(
            [In] int numTokens,
            [In, MarshalAs(UnmanagedType.LPArray)] IXCLRDataModule[] mods,
            [In] IXCLRDataModule singleMod,
            [In, MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] tokens,
            [In, MarshalAs(UnmanagedType.LPArray)] CLRDataMethodCodeNotification flags,
            [In] int singleFlags);

        [PreserveSig]
        HRESULT GetOtherNotificationFlags(
            [Out] out CLRDataOtherNotifyFlag flags);

        [PreserveSig]
        HRESULT SetOtherNotificationFlags(
            [In] CLRDataOtherNotifyFlag flags);

        [PreserveSig]
        HRESULT StartEnumMethodDefinitionsByAddress(
            [In] CLRDATA_ADDRESS address,
            [Out] out IntPtr handle);

        [PreserveSig]
        HRESULT EnumMethodDefinitionByAddress(
            [In, Out] ref IntPtr handle,
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
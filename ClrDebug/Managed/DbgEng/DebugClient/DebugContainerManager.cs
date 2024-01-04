using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugContainerManager : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugContainerManager = new Guid("390a7e36-079a-4dbe-82d6-76c96fa040b2");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugContainerManagerVtbl* Vtbl => (IDebugContainerManagerVtbl*) base.Vtbl;

        #endregion

        public DebugContainerManager(IntPtr raw) : base(raw, IID_IDebugContainerManager)
        {
        }

        public DebugContainerManager(IDebugContainerManager raw) : base(raw)
        {
        }

        #region IDebugContainerManager
        #region CreateContainer

        public long CreateContainer(string owner, int maxContainerMemory)
        {
            long container;
            TryCreateContainer(owner, maxContainerMemory, out container).ThrowDbgEngNotOK();

            return container;
        }

        public HRESULT TryCreateContainer(string owner, int maxContainerMemory, out long container)
        {
            InitDelegate(ref createContainer, Vtbl->CreateContainer);

            /*HRESULT CreateContainer(
            [MarshalAs(UnmanagedType.LPWStr), In] string owner,
            [In] int maxContainerMemory,
            [Out] out long container);*/
            return createContainer(Raw, owner, maxContainerMemory, out container);
        }

        #endregion
        #region OpenContainer

        public long OpenContainer(Guid id)
        {
            long container;
            TryOpenContainer(id, out container).ThrowDbgEngNotOK();

            return container;
        }

        public HRESULT TryOpenContainer(Guid id, out long container)
        {
            InitDelegate(ref openContainer, Vtbl->OpenContainer);

            /*HRESULT OpenContainer(
            [MarshalAs(UnmanagedType.LPStruct), In] Guid id,
            [Out] out long container);*/
            return openContainer(Raw, id, out container);
        }

        #endregion
        #region CloseContainer

        public void CloseContainer(long container)
        {
            TryCloseContainer(container).ThrowDbgEngNotOK();
        }

        public HRESULT TryCloseContainer(long container)
        {
            InitDelegate(ref closeContainer, Vtbl->CloseContainer);

            /*HRESULT CloseContainer(
            [In] long container);*/
            return closeContainer(Raw, container);
        }

        #endregion
        #region GetOwner

        public string GetOwner(long containerHandle)
        {
            string ownerResult;
            TryGetOwner(containerHandle, out ownerResult).ThrowDbgEngNotOK();

            return ownerResult;
        }

        public HRESULT TryGetOwner(long containerHandle, out string ownerResult)
        {
            InitDelegate(ref getOwner, Vtbl->GetOwner);
            /*HRESULT GetOwner(
            [In] long containerHandle,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), SRI.Out] char[] owner,
            [In] int ownerSize,
            [Out] out int ownerRequiredSize);*/
            char[] owner;
            int ownerSize = 0;
            int ownerRequiredSize;
            HRESULT hr = getOwner(Raw, containerHandle, null, ownerSize, out ownerRequiredSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            ownerSize = ownerRequiredSize;
            owner = new char[ownerSize];
            hr = getOwner(Raw, containerHandle, owner, ownerSize, out ownerRequiredSize);

            if (hr == HRESULT.S_OK)
            {
                ownerResult = CreateString(owner, ownerRequiredSize);

                return hr;
            }

            fail:
            ownerResult = default(string);

            return hr;
        }

        #endregion
        #region StartActivity

        public long StartActivity(long container)
        {
            long activity;
            TryStartActivity(container, out activity).ThrowDbgEngNotOK();

            return activity;
        }

        public HRESULT TryStartActivity(long container, out long activity)
        {
            InitDelegate(ref startActivity, Vtbl->StartActivity);

            /*HRESULT StartActivity(
            [In] long container,
            [Out] out long activity);*/
            return startActivity(Raw, container, out activity);
        }

        #endregion
        #region StartProcessInContainer

        public void StartProcessInContainer(long activity, string commandLine, string username, bool useExistingLoginSession)
        {
            TryStartProcessInContainer(activity, commandLine, username, useExistingLoginSession).ThrowDbgEngNotOK();
        }

        public HRESULT TryStartProcessInContainer(long activity, string commandLine, string username, bool useExistingLoginSession)
        {
            InitDelegate(ref startProcessInContainer, Vtbl->StartProcessInContainer);

            /*HRESULT StartProcessInContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string commandLine,
            [MarshalAs(UnmanagedType.LPWStr), In] string username,
            [In] bool useExistingLoginSession);*/
            return startProcessInContainer(Raw, activity, commandLine, username, useExistingLoginSession);
        }

        #endregion
        #region RunProcessInContainer

        public int RunProcessInContainer(long activity, string commandLine, string username, bool useExistingLoginSession, IDebugOutputStream programOutput)
        {
            int exitCode;
            TryRunProcessInContainer(activity, commandLine, username, useExistingLoginSession, programOutput, out exitCode).ThrowDbgEngNotOK();

            return exitCode;
        }

        public HRESULT TryRunProcessInContainer(long activity, string commandLine, string username, bool useExistingLoginSession, IDebugOutputStream programOutput, out int exitCode)
        {
            InitDelegate(ref runProcessInContainer, Vtbl->RunProcessInContainer);

            /*HRESULT RunProcessInContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string commandLine,
            [MarshalAs(UnmanagedType.LPWStr), In] string username,
            [In] bool useExistingLoginSession,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream programOutput,
            [Out] out int exitCode);*/
            return runProcessInContainer(Raw, activity, commandLine, username, useExistingLoginSession, programOutput, out exitCode);
        }

        #endregion
        #region MapFolderToContainer

        public void MapFolderToContainer(long activity, string hostFolder, string containerFolder, bool readOnly)
        {
            TryMapFolderToContainer(activity, hostFolder, containerFolder, readOnly).ThrowDbgEngNotOK();
        }

        public HRESULT TryMapFolderToContainer(long activity, string hostFolder, string containerFolder, bool readOnly)
        {
            InitDelegate(ref mapFolderToContainer, Vtbl->MapFolderToContainer);

            /*HRESULT MapFolderToContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string hostFolder,
            [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder,
            [In] bool readOnly);*/
            return mapFolderToContainer(Raw, activity, hostFolder, containerFolder, readOnly);
        }

        #endregion
        #region UnmapFolderFromContainer

        public void UnmapFolderFromContainer(long activity, string containerFolder)
        {
            TryUnmapFolderFromContainer(activity, containerFolder).ThrowDbgEngNotOK();
        }

        public HRESULT TryUnmapFolderFromContainer(long activity, string containerFolder)
        {
            InitDelegate(ref unmapFolderFromContainer, Vtbl->UnmapFolderFromContainer);

            /*HRESULT UnmapFolderFromContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder);*/
            return unmapFolderFromContainer(Raw, activity, containerFolder);
        }

        #endregion
        #region StopActivity

        public void StopActivity(long activity)
        {
            TryStopActivity(activity).ThrowDbgEngNotOK();
        }

        public HRESULT TryStopActivity(long activity)
        {
            InitDelegate(ref stopActivity, Vtbl->StopActivity);

            /*HRESULT StopActivity(
            [In] long activity);*/
            return stopActivity(Raw, activity);
        }

        #endregion
        #region EnumerateContainers

        public Guid[] Containers => EnumerateContainers().ToArray();

        public Guid[] EnumerateContainers()
        {
            Guid[] containerGuids;
            TryEnumerateContainers(out containerGuids).ThrowDbgEngNotOK();

            return containerGuids;
        }

        public HRESULT TryEnumerateContainers(out Guid[] containerGuids)
        {
            InitDelegate(ref enumerateContainers, Vtbl->EnumerateContainers);
            /*HRESULT EnumerateContainers(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] Guid[] containerGuids,
            [In] int size,
            [Out] out int numContainers);*/
            containerGuids = null;
            int size = 0;
            int numContainers;
            HRESULT hr = enumerateContainers(Raw, null, size, out numContainers);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            size = numContainers;
            containerGuids = new Guid[size];
            hr = enumerateContainers(Raw, containerGuids, size, out numContainers);
            fail:
            return hr;
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugContainerManager

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateContainerDelegate createContainer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenContainerDelegate openContainer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseContainerDelegate closeContainer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOwnerDelegate getOwner;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartActivityDelegate startActivity;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartProcessInContainerDelegate startProcessInContainer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RunProcessInContainerDelegate runProcessInContainer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private MapFolderToContainerDelegate mapFolderToContainer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private UnmapFolderFromContainerDelegate unmapFolderFromContainer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StopActivityDelegate stopActivity;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EnumerateContainersDelegate enumerateContainers;

        #endregion
        #endregion
        #region Delegates
        #region IDebugContainerManager

        private delegate HRESULT CreateContainerDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string owner, [In] int maxContainerMemory, [Out] out long container);
        private delegate HRESULT OpenContainerDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPStruct), In] Guid id, [Out] out long container);
        private delegate HRESULT CloseContainerDelegate(IntPtr self, [In] long container);
        private delegate HRESULT GetOwnerDelegate(IntPtr self, [In] long containerHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), SRI.Out] char[] owner, [In] int ownerSize, [Out] out int ownerRequiredSize);
        private delegate HRESULT StartActivityDelegate(IntPtr self, [In] long container, [Out] out long activity);
        private delegate HRESULT StartProcessInContainerDelegate(IntPtr self, [In] long activity, [MarshalAs(UnmanagedType.LPWStr), In] string commandLine, [MarshalAs(UnmanagedType.LPWStr), In] string username, [In] bool useExistingLoginSession);
        private delegate HRESULT RunProcessInContainerDelegate(IntPtr self, [In] long activity, [MarshalAs(UnmanagedType.LPWStr), In] string commandLine, [MarshalAs(UnmanagedType.LPWStr), In] string username, [In] bool useExistingLoginSession, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream programOutput, [Out] out int exitCode);
        private delegate HRESULT MapFolderToContainerDelegate(IntPtr self, [In] long activity, [MarshalAs(UnmanagedType.LPWStr), In] string hostFolder, [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder, [In] bool readOnly);
        private delegate HRESULT UnmapFolderFromContainerDelegate(IntPtr self, [In] long activity, [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder);
        private delegate HRESULT StopActivityDelegate(IntPtr self, [In] long activity);
        private delegate HRESULT EnumerateContainersDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] Guid[] containerGuids, [In] int size, [Out] out int numContainers);

        #endregion
        #endregion
    }
}

using System;
using System.Linq;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    public class DebugContainerManager : ComObject<IDebugContainerManager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugContainerManager"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
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
            /*HRESULT CreateContainer(
            [MarshalAs(UnmanagedType.LPWStr), In] string owner,
            [In] int maxContainerMemory,
            [Out] out long container);*/
            return Raw.CreateContainer(owner, maxContainerMemory, out container);
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
            /*HRESULT OpenContainer(
            [MarshalAs(UnmanagedType.LPStruct), In] Guid id,
            [Out] out long container);*/
            return Raw.OpenContainer(id, out container);
        }

        #endregion
        #region CloseContainer

        public void CloseContainer(long container)
        {
            TryCloseContainer(container).ThrowDbgEngNotOK();
        }

        public HRESULT TryCloseContainer(long container)
        {
            /*HRESULT CloseContainer(
            [In] long container);*/
            return Raw.CloseContainer(container);
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
            /*HRESULT GetOwner(
            [In] long containerHandle,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), SRI.Out] char[] owner,
            [In] int ownerSize,
            [Out] out int ownerRequiredSize);*/
            char[] owner;
            int ownerSize = 0;
            int ownerRequiredSize;
            HRESULT hr = Raw.GetOwner(containerHandle, null, ownerSize, out ownerRequiredSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            ownerSize = ownerRequiredSize;
            owner = new char[ownerSize];
            hr = Raw.GetOwner(containerHandle, owner, ownerSize, out ownerRequiredSize);

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
            /*HRESULT StartActivity(
            [In] long container,
            [Out] out long activity);*/
            return Raw.StartActivity(container, out activity);
        }

        #endregion
        #region StartProcessInContainer

        public void StartProcessInContainer(long activity, string commandLine, string username, bool useExistingLoginSession)
        {
            TryStartProcessInContainer(activity, commandLine, username, useExistingLoginSession).ThrowDbgEngNotOK();
        }

        public HRESULT TryStartProcessInContainer(long activity, string commandLine, string username, bool useExistingLoginSession)
        {
            /*HRESULT StartProcessInContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string commandLine,
            [MarshalAs(UnmanagedType.LPWStr), In] string username,
            [In, MarshalAs(UnmanagedType.Bool)] bool useExistingLoginSession);*/
            return Raw.StartProcessInContainer(activity, commandLine, username, useExistingLoginSession);
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
            /*HRESULT RunProcessInContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string commandLine,
            [MarshalAs(UnmanagedType.LPWStr), In] string username,
            [In, MarshalAs(UnmanagedType.Bool)] bool useExistingLoginSession,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream programOutput,
            [Out] out int exitCode);*/
            return Raw.RunProcessInContainer(activity, commandLine, username, useExistingLoginSession, programOutput, out exitCode);
        }

        #endregion
        #region MapFolderToContainer

        public void MapFolderToContainer(long activity, string hostFolder, string containerFolder, bool readOnly)
        {
            TryMapFolderToContainer(activity, hostFolder, containerFolder, readOnly).ThrowDbgEngNotOK();
        }

        public HRESULT TryMapFolderToContainer(long activity, string hostFolder, string containerFolder, bool readOnly)
        {
            /*HRESULT MapFolderToContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string hostFolder,
            [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder,
            [In, MarshalAs(UnmanagedType.Bool)] bool readOnly);*/
            return Raw.MapFolderToContainer(activity, hostFolder, containerFolder, readOnly);
        }

        #endregion
        #region UnmapFolderFromContainer

        public void UnmapFolderFromContainer(long activity, string containerFolder)
        {
            TryUnmapFolderFromContainer(activity, containerFolder).ThrowDbgEngNotOK();
        }

        public HRESULT TryUnmapFolderFromContainer(long activity, string containerFolder)
        {
            /*HRESULT UnmapFolderFromContainer(
            [In] long activity,
            [MarshalAs(UnmanagedType.LPWStr), In] string containerFolder);*/
            return Raw.UnmapFolderFromContainer(activity, containerFolder);
        }

        #endregion
        #region StopActivity

        public void StopActivity(long activity)
        {
            TryStopActivity(activity).ThrowDbgEngNotOK();
        }

        public HRESULT TryStopActivity(long activity)
        {
            /*HRESULT StopActivity(
            [In] long activity);*/
            return Raw.StopActivity(activity);
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
            /*HRESULT EnumerateContainers(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), SRI.Out] Guid[] containerGuids,
            [In] int size,
            [Out] out int numContainers);*/
            containerGuids = null;
            int size = 0;
            int numContainers;
            HRESULT hr = Raw.EnumerateContainers(null, size, out numContainers);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            size = numContainers;
            containerGuids = new Guid[size];
            hr = Raw.EnumerateContainers(containerGuids, size, out numContainers);
            fail:
            return hr;
        }

        #endregion
        #endregion
    }
}

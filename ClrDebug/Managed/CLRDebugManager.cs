using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that allow a host to associate a set of tasks with an identifier and a friendly name.
    /// </summary>
    /// <remarks>
    /// In debugging scenarios, a host might want to group tasks according to its own programming logic. For example, a
    /// grouping would allow a developer to see only the tasks required by the developer's APIs, instead of seeing every
    /// task running in the process. <see cref="ICLRDebugManager"/> allows the host to implement this kind of grouping. The grouping,
    /// and the identifiers and friendly names that the host assigns to the grouping, have no meaning for the common language
    /// runtime (CLR). The CLR merely passes the information along to the debugger.
    /// </remarks>
    public class CLRDebugManager : ComObject<ICLRDebugManager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRDebugManager"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRDebugManager(ICLRDebugManager raw) : base(raw)
        {
        }

        #region ICLRDebugManager
        #region Dacl

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        public IntPtr Dacl
        {
            get
            {
                IntPtr pacl;
                TryGetDacl(out pacl).ThrowOnNotOK();

                return pacl;
            }
            set
            {
                TrySetDacl(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="pacl">[out] An interface pointer to the Access Control List (ACL).</param>
        /// <returns>
        /// | HRESULT   | Description                    |
        /// | --------- | ------------------------------ |
        /// | E_NOTIMPL | The method is not implemented. |
        /// </returns>
        public HRESULT TryGetDacl(out IntPtr pacl)
        {
            /*HRESULT GetDacl(
            [Out] out IntPtr pacl);*/
            return Raw.GetDacl(out pacl);
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="pacl">[in] A pointer to the Access Control List (ACL).</param>
        /// <returns>
        /// | HRESULT   | Description                    |
        /// | --------- | ------------------------------ |
        /// | E_NOTIMPL | The method is not implemented. |
        /// </returns>
        public HRESULT TrySetDacl(IntPtr pacl)
        {
            /*HRESULT SetDacl(
            [In] IntPtr pacl);*/
            return Raw.SetDacl(pacl);
        }

        #endregion
        #region IsDebuggerAttached

        /// <summary>
        /// Gets a value that indicates whether a debugger is attached to the process.
        /// </summary>
        public bool IsDebuggerAttached
        {
            get
            {
                bool pbAttached;
                TryIsDebuggerAttached(out pbAttached).ThrowOnNotOK();

                return pbAttached;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether a debugger is attached to the process.
        /// </summary>
        /// <param name="pbAttached">[out] true if a debugger is attached to the process; otherwise, false.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | IsDebuggerAttached returned successfully.                                                                                                                                                   |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                        |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// IsDebuggerAttached allows the host to query the CLR to determine whether a debugger is attached to the process.
        /// </remarks>
        public HRESULT TryIsDebuggerAttached(out bool pbAttached)
        {
            /*HRESULT IsDebuggerAttached(
            [Out] out bool pbAttached);*/
            return Raw.IsDebuggerAttached(out pbAttached);
        }

        #endregion
        #region BeginConnection

        /// <summary>
        /// Establishes a new connection between the host and the debugger to associate a list of tasks with an identifier and a friendly name.
        /// </summary>
        /// <param name="dwConnectionId">[in] An identifier to associate with the list of common language runtime (CLR) tasks.</param>
        /// <param name="szConnectionName">[in] A friendly name to associate with the list of CLR tasks.</param>
        /// <remarks>
        /// <see cref="ICLRDebugManager"/> provides three methods, BeginConnection, <see cref="SetConnectionTasks"/>, and <see
        /// cref="EndConnection"/>, for associating task lists with identifiers and friendly names.
        /// </remarks>
        public void BeginConnection(int dwConnectionId, string szConnectionName)
        {
            TryBeginConnection(dwConnectionId, szConnectionName).ThrowOnNotOK();
        }

        /// <summary>
        /// Establishes a new connection between the host and the debugger to associate a list of tasks with an identifier and a friendly name.
        /// </summary>
        /// <param name="dwConnectionId">[in] An identifier to associate with the list of common language runtime (CLR) tasks.</param>
        /// <param name="szConnectionName">[in] A friendly name to associate with the list of CLR tasks.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | BeginConnection returned successfully.                                                                                                                                                      |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                  |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_INVALIDARG           | dwConnectionId was zero, or BeginConnection was already called using this dwConnectionId value, or szConnectionName was null.                                                               |
        /// | E_OUTOFMEMORY          | Not enough memory could be allocated to hold the list of tasks associated with this connection.                                                                                             |
        /// </returns>
        /// <remarks>
        /// <see cref="ICLRDebugManager"/> provides three methods, BeginConnection, <see cref="SetConnectionTasks"/>, and <see
        /// cref="EndConnection"/>, for associating task lists with identifiers and friendly names.
        /// </remarks>
        public HRESULT TryBeginConnection(int dwConnectionId, string szConnectionName)
        {
            /*HRESULT BeginConnection(
            [In] int dwConnectionId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szConnectionName);*/
            return Raw.BeginConnection(dwConnectionId, szConnectionName);
        }

        #endregion
        #region SetConnectionTasks

        /// <summary>
        /// Associates a list of <see cref="ICLRTask"/> instances with an identifier and a friendly name.
        /// </summary>
        /// <param name="id">[in] The host-specific identifier for the connection with which to associate the ppCLRTask array.</param>
        /// <param name="dwCount">[in] The number of members of ppCLRTask. This number must be greater than zero.</param>
        /// <param name="ppCLRTask">[in] An array of <see cref="ICLRTask"/> pointers to associate with the connection identified by id. This array must contain at least one member.</param>
        /// <remarks>
        /// <see cref="ICLRDebugManager"/> provides three methods, BeginConnection, SetConnectionTasks, and <see cref="EndConnection"/>,
        /// for associating task lists with identifiers and friendly names.
        /// </remarks>
        public void SetConnectionTasks(int id, int dwCount, IntPtr ppCLRTask)
        {
            TrySetConnectionTasks(id, dwCount, ppCLRTask).ThrowOnNotOK();
        }

        /// <summary>
        /// Associates a list of <see cref="ICLRTask"/> instances with an identifier and a friendly name.
        /// </summary>
        /// <param name="id">[in] The host-specific identifier for the connection with which to associate the ppCLRTask array.</param>
        /// <param name="dwCount">[in] The number of members of ppCLRTask. This number must be greater than zero.</param>
        /// <param name="ppCLRTask">[in] An array of <see cref="ICLRTask"/> pointers to associate with the connection identified by id. This array must contain at least one member.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | SetConnectionTasks returned successfully.                                                                                                                                                   |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                        |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_INVALIDARG           | <see cref="BeginConnection"/> has not been called using this value of id, or dwCount or id is zero, or one of the elements of ppCLRTask is null.                                            |
        /// </returns>
        /// <remarks>
        /// <see cref="ICLRDebugManager"/> provides three methods, BeginConnection, SetConnectionTasks, and <see cref="EndConnection"/>,
        /// for associating task lists with identifiers and friendly names.
        /// </remarks>
        public HRESULT TrySetConnectionTasks(int id, int dwCount, IntPtr ppCLRTask)
        {
            /*HRESULT SetConnectionTasks(
            [In] int id,
            [In] int dwCount,
            [In] IntPtr ppCLRTask);*/
            return Raw.SetConnectionTasks(id, dwCount, ppCLRTask);
        }

        #endregion
        #region EndConnection

        /// <summary>
        /// Removes the association between a list of tasks and an identifier and a friendly name.
        /// </summary>
        /// <param name="dwConnectionId">[in] The host-specific identifier for the connection and the associated list of common language runtime (CLR) tasks.</param>
        /// <remarks>
        /// <see cref="ICLRDebugManager"/> provides three methods, BeginConnection, <see cref="SetConnectionTasks"/>, and EndConnection,
        /// for associating task lists with identifiers and friendly names.
        /// </remarks>
        public void EndConnection(int dwConnectionId)
        {
            TryEndConnection(dwConnectionId).ThrowOnNotOK();
        }

        /// <summary>
        /// Removes the association between a list of tasks and an identifier and a friendly name.
        /// </summary>
        /// <param name="dwConnectionId">[in] The host-specific identifier for the connection and the associated list of common language runtime (CLR) tasks.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | EndConnection returned successfully.                                                                                                                                                        |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                  |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_INVALIDARG           | <see cref="BeginConnection"/> was never called using dwConnectionId, or dwConnectionId was zero.                                                                                            |
        /// </returns>
        /// <remarks>
        /// <see cref="ICLRDebugManager"/> provides three methods, BeginConnection, <see cref="SetConnectionTasks"/>, and EndConnection,
        /// for associating task lists with identifiers and friendly names.
        /// </remarks>
        public HRESULT TryEndConnection(int dwConnectionId)
        {
            /*HRESULT EndConnection(
            [In] int dwConnectionId);*/
            return Raw.EndConnection(dwConnectionId);
        }

        #endregion
        #region SetSymbolReadingPolicy

        /// <summary>
        /// Sets the policy for reading program database (PDB) files. The policy determines whether information about line numbers and files is included in call stacks.
        /// </summary>
        /// <param name="policy">[in] A member of the <see cref="ESymbolReadingPolicy"/> enumeration.</param>
        public void SetSymbolReadingPolicy(ESymbolReadingPolicy policy)
        {
            TrySetSymbolReadingPolicy(policy).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the policy for reading program database (PDB) files. The policy determines whether information about line numbers and files is included in call stacks.
        /// </summary>
        /// <param name="policy">[in] A member of the <see cref="ESymbolReadingPolicy"/> enumeration.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | SetSymbolReadingPolicy returned successfully.                                                                                                                                               |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                        |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        public HRESULT TrySetSymbolReadingPolicy(ESymbolReadingPolicy policy)
        {
            /*HRESULT SetSymbolReadingPolicy(
            [In] ESymbolReadingPolicy policy);*/
            return Raw.SetSymbolReadingPolicy(policy);
        }

        #endregion
        #endregion
    }
}

using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRDebugManager : ComObject<ICLRDebugManager>
    {
        public CLRDebugManager(ICLRDebugManager raw) : base(raw)
        {
        }

        #region ICLRDebugManager
        #region GetDacl

        public IntPtr Dacl
        {
            get
            {
                HRESULT hr;
                IntPtr pacl = default(IntPtr);

                if ((hr = TryGetDacl(ref pacl)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pacl;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetDacl(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetDacl(ref IntPtr pacl)
        {
            /*HRESULT GetDacl([Out] IntPtr pacl);*/
            return Raw.GetDacl(pacl);
        }

        public HRESULT TrySetDacl(IntPtr pacl)
        {
            /*HRESULT SetDacl([In] IntPtr pacl);*/
            return Raw.SetDacl(pacl);
        }

        #endregion
        #region IsDebuggerAttached

        public int IsDebuggerAttached
        {
            get
            {
                HRESULT hr;
                int pbAttached;

                if ((hr = TryIsDebuggerAttached(out pbAttached)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbAttached;
            }
        }

        public HRESULT TryIsDebuggerAttached(out int pbAttached)
        {
            /*HRESULT IsDebuggerAttached([Out] out int pbAttached);*/
            return Raw.IsDebuggerAttached(out pbAttached);
        }

        #endregion
        #region BeginConnection

        public void BeginConnection(uint dwConnectionId, string szConnectionName)
        {
            HRESULT hr;

            if ((hr = TryBeginConnection(dwConnectionId, szConnectionName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBeginConnection(uint dwConnectionId, string szConnectionName)
        {
            /*HRESULT BeginConnection(
            [In] uint dwConnectionId,
            [In] string szConnectionName);*/
            return Raw.BeginConnection(dwConnectionId, szConnectionName);
        }

        #endregion
        #region SetConnectionTasks

        public void SetConnectionTasks(uint id, uint dwCount, IntPtr ppCLRTask)
        {
            HRESULT hr;

            if ((hr = TrySetConnectionTasks(id, dwCount, ppCLRTask)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetConnectionTasks(uint id, uint dwCount, IntPtr ppCLRTask)
        {
            /*HRESULT SetConnectionTasks(
            [In] uint id,
            [In] uint dwCount,
            [In] IntPtr ppCLRTask);*/
            return Raw.SetConnectionTasks(id, dwCount, ppCLRTask);
        }

        #endregion
        #region EndConnection

        public void EndConnection(uint dwConnectionId)
        {
            HRESULT hr;

            if ((hr = TryEndConnection(dwConnectionId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndConnection(uint dwConnectionId)
        {
            /*HRESULT EndConnection([In] uint dwConnectionId);*/
            return Raw.EndConnection(dwConnectionId);
        }

        #endregion
        #region SetSymbolReadingPolicy

        public void SetSymbolReadingPolicy(ESymbolReadingPolicy policy)
        {
            HRESULT hr;

            if ((hr = TrySetSymbolReadingPolicy(policy)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetSymbolReadingPolicy(ESymbolReadingPolicy policy)
        {
            /*HRESULT SetSymbolReadingPolicy([In] ESymbolReadingPolicy policy);*/
            return Raw.SetSymbolReadingPolicy(policy);
        }

        #endregion
        #endregion
    }
}
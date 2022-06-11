using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostSecurityManager : ComObject<IHostSecurityManager>
    {
        public HostSecurityManager(IHostSecurityManager raw) : base(raw)
        {
        }

        #region IHostSecurityManager
        #region ImpersonateLoggedOnUser

        public void ImpersonateLoggedOnUser(IntPtr hToken)
        {
            HRESULT hr;

            if ((hr = TryImpersonateLoggedOnUser(hToken)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryImpersonateLoggedOnUser(IntPtr hToken)
        {
            /*HRESULT ImpersonateLoggedOnUser([In] IntPtr hToken);*/
            return Raw.ImpersonateLoggedOnUser(hToken);
        }

        #endregion
        #region RevertToSelf

        public void RevertToSelf()
        {
            HRESULT hr;

            if ((hr = TryRevertToSelf()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryRevertToSelf()
        {
            /*HRESULT RevertToSelf();*/
            return Raw.RevertToSelf();
        }

        #endregion
        #region OpenThreadToken

        public IntPtr OpenThreadToken(uint dwDesiredAccess, int bOpenAsSelf)
        {
            HRESULT hr;
            IntPtr phThreadToken = default(IntPtr);

            if ((hr = TryOpenThreadToken(dwDesiredAccess, bOpenAsSelf, ref phThreadToken)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return phThreadToken;
        }

        public HRESULT TryOpenThreadToken(uint dwDesiredAccess, int bOpenAsSelf, ref IntPtr phThreadToken)
        {
            /*HRESULT OpenThreadToken(
            [In] uint dwDesiredAccess,
            [In] int bOpenAsSelf,
            [Out] IntPtr phThreadToken
        );*/
            return Raw.OpenThreadToken(dwDesiredAccess, bOpenAsSelf, phThreadToken);
        }

        #endregion
        #region SetThreadToken

        public void SetThreadToken(IntPtr hToken)
        {
            HRESULT hr;

            if ((hr = TrySetThreadToken(hToken)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetThreadToken(IntPtr hToken)
        {
            /*HRESULT SetThreadToken(
            [In] IntPtr hToken);*/
            return Raw.SetThreadToken(hToken);
        }

        #endregion
        #region GetSecurityContext

        public HostSecurityContext GetSecurityContext(EContextType eContextType)
        {
            HRESULT hr;
            HostSecurityContext ppSecurityContextResult;

            if ((hr = TryGetSecurityContext(eContextType, out ppSecurityContextResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppSecurityContextResult;
        }

        public HRESULT TryGetSecurityContext(EContextType eContextType, out HostSecurityContext ppSecurityContextResult)
        {
            /*HRESULT GetSecurityContext(
            [In] EContextType eContextType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IHostSecurityContext ppSecurityContext);*/
            IHostSecurityContext ppSecurityContext;
            HRESULT hr = Raw.GetSecurityContext(eContextType, out ppSecurityContext);

            if (hr == HRESULT.S_OK)
                ppSecurityContextResult = new HostSecurityContext(ppSecurityContext);
            else
                ppSecurityContextResult = default(HostSecurityContext);

            return hr;
        }

        #endregion
        #region SetSecurityContext

        public void SetSecurityContext(EContextType eContextType, IHostSecurityContext pSecurityContext)
        {
            HRESULT hr;

            if ((hr = TrySetSecurityContext(eContextType, pSecurityContext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetSecurityContext(EContextType eContextType, IHostSecurityContext pSecurityContext)
        {
            /*HRESULT SetSecurityContext(
            [In] EContextType eContextType,
            [In, MarshalAs(UnmanagedType.Interface)] IHostSecurityContext pSecurityContext);*/
            return Raw.SetSecurityContext(eContextType, pSecurityContext);
        }

        #endregion
        #endregion
    }
}
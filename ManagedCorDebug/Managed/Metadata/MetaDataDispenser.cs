using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public abstract class MetaDataDispenser : ComObject<IMetaDataDispenser>
    {
        public static MetaDataDispenser New(IMetaDataDispenser value)
        {
            if (value is IMetaDataDispenserEx)
                return new MetaDataDispenserEx((IMetaDataDispenserEx) value);

            throw new NotImplementedException("Encountered an IMetaDataDispenser' interface of an unknown type. Cannot create wrapper type.");
        }

        protected MetaDataDispenser(IMetaDataDispenser raw) : base(raw)
        {
        }

        #region IMetaDataDispenser
        #region DefineScope

        public void DefineScope(Guid rclsid, uint dwCreateFlags, Guid riid)
        {
            HRESULT hr;

            if ((hr = TryDefineScope(rclsid, dwCreateFlags, riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineScope(Guid rclsid, uint dwCreateFlags, Guid riid)
        {
            /*HRESULT DefineScope(
            [In] ref Guid rclsid,
            [In] uint dwCreateFlags,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppIUnk);*/
            object ppIUnk;

            return Raw.DefineScope(ref rclsid, dwCreateFlags, ref riid, out ppIUnk);
        }

        #endregion
        #region OpenScope

        public object OpenScope(string szScope, CorOpenFlags dwOpenFlags, Guid riid)
        {
            HRESULT hr;
            object ppIUnk;

            if ((hr = TryOpenScope(szScope, dwOpenFlags, riid, out ppIUnk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppIUnk;
        }

        public HRESULT TryOpenScope(string szScope, CorOpenFlags dwOpenFlags, Guid riid, out object ppIUnk)
        {
            /*HRESULT OpenScope(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szScope,
            [In] CorOpenFlags dwOpenFlags,
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppIUnk);*/
            return Raw.OpenScope(szScope, dwOpenFlags, riid, out ppIUnk);
        }

        #endregion
        #region OpenScopeOnMemory

        public void OpenScopeOnMemory(IntPtr pData, uint cbData, CorOpenFlags dwOpenFlags, Guid riid)
        {
            HRESULT hr;

            if ((hr = TryOpenScopeOnMemory(pData, cbData, dwOpenFlags, riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOpenScopeOnMemory(IntPtr pData, uint cbData, CorOpenFlags dwOpenFlags, Guid riid)
        {
            /*HRESULT OpenScopeOnMemory(
            [In] IntPtr pData,
            [In] uint cbData,
            [In] CorOpenFlags dwOpenFlags,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppIUnk);*/
            object ppIUnk;

            return Raw.OpenScopeOnMemory(pData, cbData, dwOpenFlags, ref riid, out ppIUnk);
        }

        #endregion
        #endregion
    }
}
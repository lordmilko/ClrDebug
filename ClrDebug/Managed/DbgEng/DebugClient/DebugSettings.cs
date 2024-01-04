using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugSettings : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugSettings = new Guid("9d339be5-30cd-4403-92c3-57ea33799cb1");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugSettingsVtbl* Vtbl => (IDebugSettingsVtbl*) base.Vtbl;

        #endregion

        public DebugSettings(IntPtr raw) : base(raw, IID_IDebugSettings)
        {
        }

        public DebugSettings(IDebugSettings raw) : base(raw)
        {
        }

        #region IDebugSettings
        #region LoadSettingsFromString

        public void LoadSettingsFromString(string contents)
        {
            TryLoadSettingsFromString(contents).ThrowDbgEngNotOK();
        }

        public HRESULT TryLoadSettingsFromString(string contents)
        {
            InitDelegate(ref loadSettingsFromString, Vtbl->LoadSettingsFromString);

            /*HRESULT LoadSettingsFromString(
            [MarshalAs(UnmanagedType.LPWStr), In] string contents);*/
            return loadSettingsFromString(Raw, contents);
        }

        #endregion
        #region StoreSettingsInStream

        public void StoreSettingsInStream(IDebugOutputStream output)
        {
            TryStoreSettingsInStream(output).ThrowDbgEngNotOK();
        }

        public HRESULT TryStoreSettingsInStream(IDebugOutputStream output)
        {
            InitDelegate(ref storeSettingsInStream, Vtbl->StoreSettingsInStream);

            /*HRESULT StoreSettingsInStream(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream output);*/
            return storeSettingsInStream(Raw, output);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugSettings

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private LoadSettingsFromStringDelegate loadSettingsFromString;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StoreSettingsInStreamDelegate storeSettingsInStream;

        #endregion
        #endregion
        #region Delegates
        #region IDebugSettings

        private delegate HRESULT LoadSettingsFromStringDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string contents);
        private delegate HRESULT StoreSettingsInStreamDelegate(IntPtr self, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream output);

        #endregion
        #endregion
    }
}

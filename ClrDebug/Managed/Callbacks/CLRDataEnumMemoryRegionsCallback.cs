﻿using System;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a callback method for <see cref="CLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
    /// </summary>
#if GENERATED_MARSHALLING
    [GeneratedComClass]
#endif
    public partial class CLRDataEnumMemoryRegionsCallback : ICLRDataEnumMemoryRegionsCallback, ICLRDataEnumMemoryRegionsCallback2
    {
        public event EventHandler<CLRDataEnumMemoryRegionsCallbackEventArgs> OnAnyEvent;

        #region ICLRDataEnumMemoryRegionsCallback EventHandlers

        /// <summary>
        /// Called by <see cref="ICLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
        /// </summary>
        public event EventHandler<EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs> OnEnumMemoryRegion;

        #endregion
        #region ICLRDataEnumMemoryRegionsCallback2 EventHandlers

        public event EventHandler<UpdateMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs> OnUpdateMemoryRegion;

        #endregion
        #region ICLRDataEnumMemoryRegionsCallback Methods

        HRESULT ICLRDataEnumMemoryRegionsCallback.EnumMemoryRegion(CLRDATA_ADDRESS address, int size) => HandleEvent(OnEnumMemoryRegion, new EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(address, size));

        #endregion
        #region ICLRDataEnumMemoryRegionsCallback2 Methods

#if !GENERATED_MARSHALLING
        HRESULT ICLRDataEnumMemoryRegionsCallback2.EnumMemoryRegion(CLRDATA_ADDRESS address, int size) => HandleEvent(OnEnumMemoryRegion, new EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(address, size));
#endif

        HRESULT ICLRDataEnumMemoryRegionsCallback2.UpdateMemoryRegion(CLRDATA_ADDRESS address, int bufferSize, IntPtr buffer) => HandleEvent(OnUpdateMemoryRegion, new UpdateMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(address, bufferSize, buffer));

        #endregion

        protected virtual HRESULT HandleEvent<T>(EventHandler<T> handler, CLRDataEnumMemoryRegionsCallbackEventArgs args)
            where T : CLRDataEnumMemoryRegionsCallbackEventArgs
        {
            handler?.Invoke(this, (T) args);
            OnAnyEvent?.Invoke(this, args);

            return HRESULT.S_OK;
        }
    }
}

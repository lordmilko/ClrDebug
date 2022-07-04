using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides a callback method for <see cref="CLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
    /// </summary>
    public class CLRDataEnumMemoryRegionsCallback : ICLRDataEnumMemoryRegionsCallback, ICLRDataEnumMemoryRegionsCallback2
    {
        public EventHandler<CLRDataEnumMemoryRegionsCallbackEventArgs> OnAnyEvent;

        #region ICLRDataEnumMemoryRegionsCallback EventHandlers

        /// <summary>
        /// Called by <see cref="ICLRDataEnumMemoryRegions.EnumMemoryRegions"/> to report to the debugger the result of an attempt to enumerate a specified region of memory.
        /// </summary>
        public EventHandler<EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs> OnEnumMemoryRegion;

        #endregion
        #region ICLRDataEnumMemoryRegionsCallback2 EventHandlers

        public EventHandler<UpdateMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs> OnUpdateMemoryRegion;

        #endregion
        #region ICLRDataEnumMemoryRegionsCallback Methods

        HRESULT ICLRDataEnumMemoryRegionsCallback.EnumMemoryRegion(CLRDATA_ADDRESS address, int size) => HandleEvent(OnEnumMemoryRegion, new EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(address, size));

        #endregion
        #region ICLRDataEnumMemoryRegionsCallback2 Methods

        HRESULT ICLRDataEnumMemoryRegionsCallback2.EnumMemoryRegion(CLRDATA_ADDRESS address, int size) => HandleEvent(OnEnumMemoryRegion, new EnumMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(address, size));
        HRESULT ICLRDataEnumMemoryRegionsCallback2.UpdateMemoryRegion(CLRDATA_ADDRESS address, int bufferSize, IntPtr buffer) => HandleEvent(OnUpdateMemoryRegion, new UpdateMemoryRegionCLRDataEnumMemoryRegionsCallbackEventArgs(address, bufferSize, buffer));

        #endregion
        
        protected virtual HRESULT HandleEvent<T>(EventHandler<T> handler, CLRDataEnumMemoryRegionsCallbackEventArgs args)
            where T : CLRDataEnumMemoryRegionsCallbackEventArgs
        {
            OnAnyEvent?.Invoke(this, args);
            handler?.Invoke(this, (T) args);

            return HRESULT.S_OK;
        }
    }
}

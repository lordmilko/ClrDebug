﻿namespace ClrDebug.DbgEng
{
    public class ComponentVirtualMemoryFromFileInitializer : ComObject<IComponentVirtualMemoryFromFileInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentVirtualMemoryFromFileInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentVirtualMemoryFromFileInitializer(IComponentVirtualMemoryFromFileInitializer raw) : base(raw)
        {
        }

        #region IComponentVirtualMemoryFromFileInitializer
        #region Initialize

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_VIRTUALMEMORY_FROM_FILE component.
        /// </summary>
        public void Initialize(long mappingBaseAddress)
        {
            TryInitialize(mappingBaseAddress).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_VIRTUALMEMORY_FROM_FILE component.
        /// </summary>
        public HRESULT TryInitialize(long mappingBaseAddress)
        {
            /*HRESULT Initialize(
            [In] long mappingBaseAddress);*/
            return Raw.Initialize(mappingBaseAddress);
        }

        #endregion
        #endregion
    }
}

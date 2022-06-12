using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a method that allows the garbage collector to request the host to change the limits of virtual memory.
    /// </summary>
    public class GCHostControl : ComObject<IGCHostControl>
    {
        public GCHostControl(IGCHostControl raw) : base(raw)
        {
        }

        #region IGCHostControl
        #region RequestVirtualMemLimit

        /// <summary>
        /// Requests the host to change the limits of virtual memory.
        /// </summary>
        /// <param name="sztMaxVirtualMemMB">[in] The requested size of memory to be allocated.</param>
        /// <returns>[in, out] A pointer to the actual size of memory allocated.</returns>
        public uint RequestVirtualMemLimit(uint sztMaxVirtualMemMB)
        {
            HRESULT hr;
            uint psztNewMaxVirtualMemMB = default(uint);

            if ((hr = TryRequestVirtualMemLimit(sztMaxVirtualMemMB, ref psztNewMaxVirtualMemMB)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return psztNewMaxVirtualMemMB;
        }

        /// <summary>
        /// Requests the host to change the limits of virtual memory.
        /// </summary>
        /// <param name="sztMaxVirtualMemMB">[in] The requested size of memory to be allocated.</param>
        /// <param name="psztNewMaxVirtualMemMB">[in, out] A pointer to the actual size of memory allocated.</param>
        public HRESULT TryRequestVirtualMemLimit(uint sztMaxVirtualMemMB, ref uint psztNewMaxVirtualMemMB)
        {
            /*HRESULT RequestVirtualMemLimit([In] uint sztMaxVirtualMemMB, [In, Out] ref uint psztNewMaxVirtualMemMB);*/
            return Raw.RequestVirtualMemLimit(sztMaxVirtualMemMB, ref psztNewMaxVirtualMemMB);
        }

        #endregion
        #endregion
    }
}
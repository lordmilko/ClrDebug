using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a method that allows the garbage collector to request the host to change the limits of virtual memory.
    /// </summary>
    public class GCHostControl : ComObject<IGCHostControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GCHostControl"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
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
        public int RequestVirtualMemLimit(int sztMaxVirtualMemMB)
        {
            HRESULT hr;
            int psztNewMaxVirtualMemMB = default(int);

            if ((hr = TryRequestVirtualMemLimit(sztMaxVirtualMemMB, ref psztNewMaxVirtualMemMB)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return psztNewMaxVirtualMemMB;
        }

        /// <summary>
        /// Requests the host to change the limits of virtual memory.
        /// </summary>
        /// <param name="sztMaxVirtualMemMB">[in] The requested size of memory to be allocated.</param>
        /// <param name="psztNewMaxVirtualMemMB">[in, out] A pointer to the actual size of memory allocated.</param>
        public HRESULT TryRequestVirtualMemLimit(int sztMaxVirtualMemMB, ref int psztNewMaxVirtualMemMB)
        {
            /*HRESULT RequestVirtualMemLimit([In] int sztMaxVirtualMemMB, [In, Out] ref int psztNewMaxVirtualMemMB);*/
            return Raw.RequestVirtualMemLimit(sztMaxVirtualMemMB, ref psztNewMaxVirtualMemMB);
        }

        #endregion
        #endregion
    }
}
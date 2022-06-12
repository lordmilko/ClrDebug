using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDataTarget"/> interface to support mutable data targets.
    /// </summary>
    /// <remarks>
    /// This extension to the <see cref="ICorDebugDataTarget"/> interface can be implemented by debugging tools that wish
    /// to modify the target process (for example, to perform live invasive debugging). All of these methods are optional
    /// in the sense that no core inspection-based debugging functionality is lost by not implementing this interface or
    /// by the failure of calls to these methods. Any failure <see cref="HRESULT"/> from these methods will propagate out as the <see cref="HRESULT"/>
    /// from the <see cref="ICorDebug"/> method call. Note that a single <see cref="ICorDebug"/> method call may result in multiple mutations, and
    /// that there is no mechanism for ensuring related mutations are applied transactionally (all-or-none). This means
    /// that if a mutation fails after others (for the same <see cref="ICorDebug"/> call) have succeeded, the target process may be left
    /// in an inconsistent state and debugging may become unreliable.
    /// </remarks>
    public class CorDebugMutableDataTarget : CorDebugDataTarget
    {
        public CorDebugMutableDataTarget(ICorDebugMutableDataTarget raw) : base(raw)
        {
        }

        #region ICorDebugMutableDataTarget

        public new ICorDebugMutableDataTarget Raw => (ICorDebugMutableDataTarget) base.Raw;

        #region WriteVirtual

        /// <summary>
        /// Writes memory into the target process address space.
        /// </summary>
        /// <param name="address">[in] The address at which to write the contents of pBuffer.</param>
        /// <param name="pBuffer">[in] A pointer to a byte array that contains the bytes to be written.</param>
        /// <param name="bytesRequested">[in] The number of bytes in pBuffer.</param>
        /// <remarks>
        /// If any bytes cannot be written, the method call fails without changing any bytes in the target address space. (Otherwise,
        /// the target would be in an inconsistent state that makes further debugging unreliable.)
        /// </remarks>
        public void WriteVirtual(long address, IntPtr pBuffer, int bytesRequested)
        {
            HRESULT hr;

            if ((hr = TryWriteVirtual(address, pBuffer, bytesRequested)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Writes memory into the target process address space.
        /// </summary>
        /// <param name="address">[in] The address at which to write the contents of pBuffer.</param>
        /// <param name="pBuffer">[in] A pointer to a byte array that contains the bytes to be written.</param>
        /// <param name="bytesRequested">[in] The number of bytes in pBuffer.</param>
        /// <returns>S_OK on success, or any other <see cref="HRESULT"/> on failure.</returns>
        /// <remarks>
        /// If any bytes cannot be written, the method call fails without changing any bytes in the target address space. (Otherwise,
        /// the target would be in an inconsistent state that makes further debugging unreliable.)
        /// </remarks>
        public HRESULT TryWriteVirtual(long address, IntPtr pBuffer, int bytesRequested)
        {
            /*HRESULT WriteVirtual([In] long address, [In] IntPtr pBuffer, [In] int bytesRequested);*/
            return Raw.WriteVirtual(address, pBuffer, bytesRequested);
        }

        #endregion
        #region SetThreadContext

        /// <summary>
        /// Sets the context (register values) for a thread.
        /// </summary>
        /// <param name="dwThreadId">[in] The operating system-defined thread identifier.</param>
        /// <param name="contextSize">[in] The size of the pContext buffer to be written.</param>
        /// <param name="pContext">[in] A pointer to the bytes to be written.</param>
        /// <remarks>
        /// The SetThreadContext method updates the current context for the thread specified by the operating system-defined
        /// dwThreadID argument. The format of the context record is determined by the platform indicated by the <see cref="CorDebugDataTarget.Platform"/>
        /// property. On Windows, this is a CONTEXT structure.
        /// </remarks>
        public void SetThreadContext(int dwThreadId, int contextSize, IntPtr pContext)
        {
            HRESULT hr;

            if ((hr = TrySetThreadContext(dwThreadId, contextSize, pContext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets the context (register values) for a thread.
        /// </summary>
        /// <param name="dwThreadId">[in] The operating system-defined thread identifier.</param>
        /// <param name="contextSize">[in] The size of the pContext buffer to be written.</param>
        /// <param name="pContext">[in] A pointer to the bytes to be written.</param>
        /// <remarks>
        /// The SetThreadContext method updates the current context for the thread specified by the operating system-defined
        /// dwThreadID argument. The format of the context record is determined by the platform indicated by the <see cref="CorDebugDataTarget.Platform"/>
        /// property. On Windows, this is a CONTEXT structure.
        /// </remarks>
        public HRESULT TrySetThreadContext(int dwThreadId, int contextSize, IntPtr pContext)
        {
            /*HRESULT SetThreadContext([In] int dwThreadId, [In] int contextSize, [In] IntPtr pContext);*/
            return Raw.SetThreadContext(dwThreadId, contextSize, pContext);
        }

        #endregion
        #region ContinueStatusChanged

        /// <summary>
        /// Changes the continuation status for the outstanding debug event on the specified thread.
        /// </summary>
        /// <param name="dwThreadId">The operating system-defined thread identifier.</param>
        /// <param name="continueStatus">A COREDB_CONTINUE_STATUS value that represents the new requested continuation status.</param>
        /// <remarks>
        /// The debugger calls the ContinueStatusChanged method when it calls an <see cref="ICorDebug"/> method that requires the current
        /// debug event to be handled in a way that is potentially different from the way in which it normally would be handled.
        /// For example, if there is an outstanding exception, and the debugger requests an operation that would cancel the
        /// exception (such as <see cref="CorDebugILFrame.SetIP"/> or FuncEval), this API is used to request that the exception
        /// be cancelled.
        /// </remarks>
        public void ContinueStatusChanged(int dwThreadId, int continueStatus)
        {
            HRESULT hr;

            if ((hr = TryContinueStatusChanged(dwThreadId, continueStatus)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Changes the continuation status for the outstanding debug event on the specified thread.
        /// </summary>
        /// <param name="dwThreadId">The operating system-defined thread identifier.</param>
        /// <param name="continueStatus">A COREDB_CONTINUE_STATUS value that represents the new requested continuation status.</param>
        /// <remarks>
        /// The debugger calls the ContinueStatusChanged method when it calls an <see cref="ICorDebug"/> method that requires the current
        /// debug event to be handled in a way that is potentially different from the way in which it normally would be handled.
        /// For example, if there is an outstanding exception, and the debugger requests an operation that would cancel the
        /// exception (such as <see cref="CorDebugILFrame.SetIP"/> or FuncEval), this API is used to request that the exception
        /// be cancelled.
        /// </remarks>
        public HRESULT TryContinueStatusChanged(int dwThreadId, int continueStatus)
        {
            /*HRESULT ContinueStatusChanged([In] int dwThreadId, [In] int continueStatus);*/
            return Raw.ContinueStatusChanged(dwThreadId, continueStatus);
        }

        #endregion
        #endregion
    }
}
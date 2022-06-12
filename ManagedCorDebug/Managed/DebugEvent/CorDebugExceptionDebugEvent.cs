using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDebugEvent"/> interface to support exception events.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugExceptionDebugEvent"/> interface is implemented by the following event types:
    /// </remarks>
    public class CorDebugExceptionDebugEvent : CorDebugDebugEvent
    {
        public CorDebugExceptionDebugEvent(ICorDebugExceptionDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugExceptionDebugEvent

        public new ICorDebugExceptionDebugEvent Raw => (ICorDebugExceptionDebugEvent) base.Raw;

        #region GetStackPointer

        /// <summary>
        /// Gets the stack pointer for this exception debug event.
        /// </summary>
        public long StackPointer
        {
            get
            {
                HRESULT hr;
                long pStackPointer;

                if ((hr = TryGetStackPointer(out pStackPointer)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pStackPointer;
            }
        }

        /// <summary>
        /// Gets the stack pointer for this exception debug event.
        /// </summary>
        /// <param name="pStackPointer">[out] A pointer to the address of the stack pointer for this exception debug event. See the Remarks section for more information.</param>
        /// <remarks>
        /// The meaning of this stack pointer depends on the event type, as shown in the following table. The event type is
        /// available from the <see cref="CorDebugDebugEvent.EventKind"/> property.
        /// </remarks>
        public HRESULT TryGetStackPointer(out long pStackPointer)
        {
            /*HRESULT GetStackPointer(out long pStackPointer);*/
            return Raw.GetStackPointer(out pStackPointer);
        }

        #endregion
        #region GetNativeIP

        /// <summary>
        /// Gets the native instruction pointer for this exception debug event.
        /// </summary>
        public long NativeIP
        {
            get
            {
                HRESULT hr;
                long pIP;

                if ((hr = TryGetNativeIP(out pIP)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIP;
            }
        }

        /// <summary>
        /// Gets the native instruction pointer for this exception debug event.
        /// </summary>
        /// <param name="pIP">[out] A pointer to the instruction pointer for this exception debug event. See the Remarks section for more information.</param>
        /// <remarks>
        /// The meaning of this instruction pointer depends on the event type, as shown in the following table. The event type
        /// is available from the <see cref="CorDebugDebugEvent.EventKind"/> property.
        /// </remarks>
        public HRESULT TryGetNativeIP(out long pIP)
        {
            /*HRESULT GetNativeIP(out long pIP);*/
            return Raw.GetNativeIP(out pIP);
        }

        #endregion
        #region GetFlags

        /// <summary>
        /// Gets a flag that indicates whether the exception can be intercepted.
        /// </summary>
        public CorDebugExceptionFlags Flags
        {
            get
            {
                HRESULT hr;
                CorDebugExceptionFlags pdwFlags;

                if ((hr = TryGetFlags(out pdwFlags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwFlags;
            }
        }

        /// <summary>
        /// Gets a flag that indicates whether the exception can be intercepted.
        /// </summary>
        /// <param name="pdwFlags">[out] A pointer to a <see cref="CorDebugExceptionFlags"/> value that indicates whether the exception can be intercepted.</param>
        public HRESULT TryGetFlags(out CorDebugExceptionFlags pdwFlags)
        {
            /*HRESULT GetFlags(out CorDebugExceptionFlags pdwFlags);*/
            return Raw.GetFlags(out pdwFlags);
        }

        #endregion
        #endregion
    }
}
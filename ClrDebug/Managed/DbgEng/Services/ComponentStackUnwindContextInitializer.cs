using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class ComponentStackUnwindContextInitializer : ComObject<IComponentStackUnwindContextInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentStackUnwindContextInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentStackUnwindContextInitializer(IComponentStackUnwindContextInitializer raw) : base(raw)
        {
        }

        #region IComponentStackUnwindContextInitializer
        #region Initialize

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT component.
        /// </summary>
        public void Initialize(ISvcProcess unwindProcess, ISvcThread unwindThread)
        {
            TryInitialize(unwindProcess, unwindThread).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT component.
        /// </summary>
        public HRESULT TryInitialize(ISvcProcess unwindProcess, ISvcThread unwindThread)
        {
            /*HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess unwindProcess,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcThread unwindThread);*/
            return Raw.Initialize(unwindProcess, unwindThread);
        }

        #endregion
        #endregion
        #region IComponentStackUnwindContextInitializer2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IComponentStackUnwindContextInitializer2 Raw2 => (IComponentStackUnwindContextInitializer2) Raw;

        #region Initialize2

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT component.
        /// </summary>
        public void Initialize2(ISvcProcess unwindProcess, ISvcExecutionUnit unwindExecUnit)
        {
            TryInitialize2(unwindProcess, unwindExecUnit).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_STACKUNWIND_CONTEXT component.
        /// </summary>
        public HRESULT TryInitialize2(ISvcProcess unwindProcess, ISvcExecutionUnit unwindExecUnit)
        {
            /*HRESULT Initialize2(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess unwindProcess,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit unwindExecUnit);*/
            return Raw2.Initialize2(unwindProcess, unwindExecUnit);
        }

        #endregion
        #endregion
    }
}

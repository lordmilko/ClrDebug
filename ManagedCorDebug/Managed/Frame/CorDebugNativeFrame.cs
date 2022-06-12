using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A specialized implementation of <see cref="ICorDebugFrame"/> used for native frames.
    /// </summary>
    public class CorDebugNativeFrame : CorDebugFrame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugNativeFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugNativeFrame(ICorDebugNativeFrame raw) : base(raw)
        {
        }

        #region ICorDebugNativeFrame

        public new ICorDebugNativeFrame Raw => (ICorDebugNativeFrame) base.Raw;

        #region IP

        /// <summary>
        /// Gets or sets the native code offset location to which the instruction pointer is currently set.
        /// </summary>
        public int IP
        {
            get
            {
                HRESULT hr;
                int pnOffset;

                if ((hr = TryGetIP(out pnOffset)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnOffset;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetIP(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        /// <summary>
        /// Gets the native code offset location to which the instruction pointer is currently set.
        /// </summary>
        /// <param name="pnOffset">[out] A pointer to the offset location in the native code.</param>
        /// <remarks>
        /// If the stack frame that is represented by this "ICorDebugNativeFrame" is active, the offset is the address of the
        /// next instruction to be executed. If this stack frame is not active, the offset is the address of the next instruction
        /// to be executed when the stack frame is reactivated.
        /// </remarks>
        public HRESULT TryGetIP(out int pnOffset)
        {
            /*HRESULT GetIP(out int pnOffset);*/
            return Raw.GetIP(out pnOffset);
        }

        /// <summary>
        /// Sets the instruction pointer to the specified offset location in native code.
        /// </summary>
        /// <param name="nOffset">[in] The offset location in the native code.</param>
        /// <remarks>
        /// Calls to SetIP immediately invalidate all frames and chains for the current thread. If the debugger needs frame
        /// information after a call to SetIP, it must perform a new stack trace. <see cref="ICorDebug"/> will attempt to keep
        /// the stack frame in a valid state. However, even if the frame is in a valid state, as far as the runtime is concerned,
        /// there still may be problems, such as uninitialized local variables, and so on. The caller is responsible for insuring
        /// coherency of the running program. On 64-bit platforms, the instruction pointer cannot be moved out of a catch or
        /// finally block. If SetIP is called to make such a move on a 64-bit platform, it will return an <see cref="HRESULT"/> indicating
        /// failure.
        /// </remarks>
        public HRESULT TrySetIP(int nOffset)
        {
            /*HRESULT SetIP([In] int nOffset);*/
            return Raw.SetIP(nOffset);
        }

        #endregion
        #region RegisterSet

        /// <summary>
        /// Gets the register set for this stack frame.
        /// </summary>
        public CorDebugRegisterSet RegisterSet
        {
            get
            {
                HRESULT hr;
                CorDebugRegisterSet ppRegistersResult;

                if ((hr = TryGetRegisterSet(out ppRegistersResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppRegistersResult;
            }
        }

        /// <summary>
        /// Gets the register set for this stack frame.
        /// </summary>
        /// <param name="ppRegistersResult">[out] A pointer to the address of an <see cref="ICorDebugRegisterSet"/> object that represents the register set for this stack frame.</param>
        public HRESULT TryGetRegisterSet(out CorDebugRegisterSet ppRegistersResult)
        {
            /*HRESULT GetRegisterSet([MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);*/
            ICorDebugRegisterSet ppRegisters;
            HRESULT hr = Raw.GetRegisterSet(out ppRegisters);

            if (hr == HRESULT.S_OK)
                ppRegistersResult = new CorDebugRegisterSet(ppRegisters);
            else
                ppRegistersResult = default(CorDebugRegisterSet);

            return hr;
        }

        #endregion
        #region GetLocalRegisterValue

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the specified register for this native frame.
        /// </summary>
        /// <param name="reg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register.</returns>
        /// <remarks>
        /// The GetLocalRegisterValue method can be used either in a native frame or a just-in-time (JIT)-compiled frame.
        /// </remarks>
        public CorDebugValue GetLocalRegisterValue(CorDebugRegister reg, int cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalRegisterValue(reg, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the specified register for this native frame.
        /// </summary>
        /// <param name="reg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register.</param>
        /// <remarks>
        /// The GetLocalRegisterValue method can be used either in a native frame or a just-in-time (JIT)-compiled frame.
        /// </remarks>
        public HRESULT TryGetLocalRegisterValue(CorDebugRegister reg, int cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalRegisterValue(
            [In] CorDebugRegister reg,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalRegisterValue(reg, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalDoubleRegisterValue

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the two specified registers for this native frame.
        /// </summary>
        /// <param name="highWordReg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the high word of the value.</param>
        /// <param name="lowWordReg">[in] A value of the <see cref="CorDebugRegister"/> enumeration that specifies the register containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified registers.</returns>
        /// <remarks>
        /// The GetLocalDoubleRegisterValue method can be used either in a native frame or a just-in-time (JIT)-compiled frame.
        /// </remarks>
        public CorDebugValue GetLocalDoubleRegisterValue(CorDebugRegister highWordReg, CorDebugRegister lowWordReg, int cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalDoubleRegisterValue(highWordReg, lowWordReg, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the two specified registers for this native frame.
        /// </summary>
        /// <param name="highWordReg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the high word of the value.</param>
        /// <param name="lowWordReg">[in] A value of the <see cref="CorDebugRegister"/> enumeration that specifies the register containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified registers.</param>
        /// <remarks>
        /// The GetLocalDoubleRegisterValue method can be used either in a native frame or a just-in-time (JIT)-compiled frame.
        /// </remarks>
        public HRESULT TryGetLocalDoubleRegisterValue(CorDebugRegister highWordReg, CorDebugRegister lowWordReg, int cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalDoubleRegisterValue(
            [In] CorDebugRegister highWordReg,
            [In] CorDebugRegister lowWordReg,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalDoubleRegisterValue(highWordReg, lowWordReg, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalMemoryValue

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the specified memory location for this native frame.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified memory location.</returns>
        public CorDebugValue GetLocalMemoryValue(CORDB_ADDRESS address, int cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalMemoryValue(address, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of an argument or local variable that is stored in the specified memory location for this native frame.
        /// </summary>
        /// <param name="address">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified memory location.</param>
        public HRESULT TryGetLocalMemoryValue(CORDB_ADDRESS address, int cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalMemoryValue(
            [In] CORDB_ADDRESS address,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalMemoryValue(address, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalRegisterMemoryValue

        /// <summary>
        /// Gets the value of an argument or local variable, of which the low word and high word are stored in the memory location and specified register, respectively, for this native frame.
        /// </summary>
        /// <param name="highWordReg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the high word of the value.</param>
        /// <param name="lowWordAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.</returns>
        public CorDebugValue GetLocalRegisterMemoryValue(CorDebugRegister highWordReg, CORDB_ADDRESS lowWordAddress, int cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalRegisterMemoryValue(highWordReg, lowWordAddress, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of an argument or local variable, of which the low word and high word are stored in the memory location and specified register, respectively, for this native frame.
        /// </summary>
        /// <param name="highWordReg">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the high word of the value.</param>
        /// <param name="lowWordAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.</param>
        public HRESULT TryGetLocalRegisterMemoryValue(CorDebugRegister highWordReg, CORDB_ADDRESS lowWordAddress, int cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalRegisterMemoryValue(
            [In] CorDebugRegister highWordReg,
            [In] CORDB_ADDRESS lowWordAddress,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalRegisterMemoryValue(highWordReg, lowWordAddress, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetLocalMemoryRegisterValue

        /// <summary>
        /// Gets the value of an argument or local variable, of which the low word and high word are stored in the specified register and memory location, respectively, for this native frame.
        /// </summary>
        /// <param name="highWordAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the high word of the value.</param>
        /// <param name="lowWordRegister">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.</returns>
        public CorDebugValue GetLocalMemoryRegisterValue(CORDB_ADDRESS highWordAddress, CorDebugRegister lowWordRegister, int cbSigBlob, IntPtr pvSigBlob)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetLocalMemoryRegisterValue(highWordAddress, lowWordRegister, cbSigBlob, pvSigBlob, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of an argument or local variable, of which the low word and high word are stored in the specified register and memory location, respectively, for this native frame.
        /// </summary>
        /// <param name="highWordAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the memory location containing the high word of the value.</param>
        /// <param name="lowWordRegister">[in] A value of the "CorDebugRegister" enumeration that specifies the register containing the low word of the value.</param>
        /// <param name="cbSigBlob">[in] An integer that specifies the size of the binary metadata signature which is referenced by the pvSigBlob parameter.</param>
        /// <param name="pvSigBlob">[in] A PCCOR_SIGNATURE value that points to the binary metadata signature of the value's type.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an "ICorDebugValue" object representing the retrieved value that is stored in the specified register and memory location.</param>
        public HRESULT TryGetLocalMemoryRegisterValue(CORDB_ADDRESS highWordAddress, CorDebugRegister lowWordRegister, int cbSigBlob, IntPtr pvSigBlob, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetLocalMemoryRegisterValue(
            [In] CORDB_ADDRESS highWordAddress,
            [In] CorDebugRegister lowWordRegister,
            [In] int cbSigBlob,
            [In] IntPtr pvSigBlob,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetLocalMemoryRegisterValue(highWordAddress, lowWordRegister, cbSigBlob, pvSigBlob, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region CanSetIP

        /// <summary>
        /// Gets an <see cref="HRESULT"/> that indicates whether it is safe to set the instruction pointer (IP) to the specified offset location in native code.
        /// </summary>
        /// <param name="nOffset">[in] The desired setting for the instruction pointer.</param>
        /// <remarks>
        /// Use the CanSetIP method prior to calling the <see cref="IP"/> property. If CanSetIP returns any <see cref="HRESULT"/> other
        /// than S_OK, you can still invoke <see cref="IP"/>, but there is no guarantee that the debugger will continue
        /// the safe and correct execution of the code being debugged.
        /// </remarks>
        public void CanSetIP(int nOffset)
        {
            HRESULT hr;

            if ((hr = TryCanSetIP(nOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Gets an <see cref="HRESULT"/> that indicates whether it is safe to set the instruction pointer (IP) to the specified offset location in native code.
        /// </summary>
        /// <param name="nOffset">[in] The desired setting for the instruction pointer.</param>
        /// <remarks>
        /// Use the CanSetIP method prior to calling the <see cref="IP"/> property. If CanSetIP returns any <see cref="HRESULT"/> other
        /// than S_OK, you can still invoke <see cref="IP"/>, but there is no guarantee that the debugger will continue
        /// the safe and correct execution of the code being debugged.
        /// </remarks>
        public HRESULT TryCanSetIP(int nOffset)
        {
            /*HRESULT CanSetIP([In] int nOffset);*/
            return Raw.CanSetIP(nOffset);
        }

        #endregion
        #endregion
        #region ICorDebugNativeFrame2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugNativeFrame2 Raw2 => (ICorDebugNativeFrame2) Raw;

        #region IsChild

        /// <summary>
        /// Determines whether the current frame is a child frame.
        /// </summary>
        public bool IsChild
        {
            get
            {
                HRESULT hr;
                bool pIsChildResult;

                if ((hr = TryIsChild(out pIsChildResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIsChildResult;
            }
        }

        /// <summary>
        /// Determines whether the current frame is a child frame.
        /// </summary>
        /// <param name="pIsChildResult">[out] A Boolean value that specifies whether the current frame is a child frame.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                 |
        /// | ------------ | ------------------------------------------- |
        /// | S_OK         | The child status was successfully returned. |
        /// | E_FAIL       | The child status could not be returned.     |
        /// | E_INVALIDARG | pIsChild is null.                           |
        /// </returns>
        /// <remarks>
        /// The IsChild method returns true if the frame object on which you call the method is a child of another frame. If
        /// this is the case, use the <see cref="IsMatchingParentFrame"/> method to check whether a frame is its parent.
        /// </remarks>
        public HRESULT TryIsChild(out bool pIsChildResult)
        {
            /*HRESULT IsChild(out int pIsChild);*/
            int pIsChild;
            HRESULT hr = Raw2.IsChild(out pIsChild);

            if (hr == HRESULT.S_OK)
                pIsChildResult = pIsChild == 1;
            else
                pIsChildResult = default(bool);

            return hr;
        }

        #endregion
        #region StackParameterSize

        /// <summary>
        /// Returns the cumulative size of the parameters on the stack on x86 operating systems.
        /// </summary>
        public int StackParameterSize
        {
            get
            {
                HRESULT hr;
                int pSize;

                if ((hr = TryGetStackParameterSize(out pSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSize;
            }
        }

        /// <summary>
        /// Returns the cumulative size of the parameters on the stack on x86 operating systems.
        /// </summary>
        /// <param name="pSize">[out] A pointer to the cumulative size of the parameters on the stack.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                             |
        /// | ------------ | ------------------------------------------------------- |
        /// | S_OK         | The stack size was successfully returned.               |
        /// | S_FALSE      | GetStackParameterSize was called on a non-x86 platform. |
        /// | E_FAIL       | The size of the parameters could not be returned.       |
        /// | E_INVALIDARG | pSize Is null.                                          |
        /// </returns>
        /// <remarks>
        /// The <see cref="ICorDebugStackWalk"/> methods do not adjust the stack pointer for parameters that are pushed on
        /// the stack. Instead, you can use the value returned by GetStackParameterSize to adjust the stack pointer to seed
        /// a native unwinder, which does adjust for the parameters.
        /// </remarks>
        public HRESULT TryGetStackParameterSize(out int pSize)
        {
            /*HRESULT GetStackParameterSize(out int pSize);*/
            return Raw2.GetStackParameterSize(out pSize);
        }

        #endregion
        #region IsMatchingParentFrame

        /// <summary>
        /// Determines whether the specified frame is the parent of the current frame.
        /// </summary>
        /// <param name="pPotentialParentFrame">[in] A pointer to the frame object that you want to evaluate for parent status.</param>
        /// <returns>[out] true if pPotentialParentFrame is the current frame’s parent; otherwise, false.</returns>
        /// <remarks>
        /// IsMatchingParentFrame returns true if the frame object you pass to the method is the parent of the frame object
        /// on which the method was called. If you call the method on a frame that is not a child of the specified frame, it
        /// returns an error.
        /// </remarks>
        public int IsMatchingParentFrame(ICorDebugNativeFrame2 pPotentialParentFrame)
        {
            HRESULT hr;
            int pIsParent;

            if ((hr = TryIsMatchingParentFrame(pPotentialParentFrame, out pIsParent)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pIsParent;
        }

        /// <summary>
        /// Determines whether the specified frame is the parent of the current frame.
        /// </summary>
        /// <param name="pPotentialParentFrame">[in] A pointer to the frame object that you want to evaluate for parent status.</param>
        /// <param name="pIsParent">[out] true if pPotentialParentFrame is the current frame’s parent; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                  |
        /// | ------------ | -------------------------------------------- |
        /// | S_OK         | The parent status was successfully returned. |
        /// | E_FAIL       | The parent status could not be returned.     |
        /// | E_INVALIDARG | pPotentialParentFrame or pIsParent is null.  |
        /// </returns>
        /// <remarks>
        /// IsMatchingParentFrame returns true if the frame object you pass to the method is the parent of the frame object
        /// on which the method was called. If you call the method on a frame that is not a child of the specified frame, it
        /// returns an error.
        /// </remarks>
        public HRESULT TryIsMatchingParentFrame(ICorDebugNativeFrame2 pPotentialParentFrame, out int pIsParent)
        {
            /*HRESULT IsMatchingParentFrame([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugNativeFrame2 pPotentialParentFrame, out int pIsParent);*/
            return Raw2.IsMatchingParentFrame(pPotentialParentFrame, out pIsParent);
        }

        #endregion
        #endregion
    }
}
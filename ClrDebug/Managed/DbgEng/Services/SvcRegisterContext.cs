using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterContext unit describes a set of registers and their values. A register context for a standard supported platform can optionally support ISvcClassicRegisterContext where the given register context can be represented by a platform specific Windows CONTEXT structure.<para/>
    /// In addition, a register context which holds a set of "special context" for a standard supported platform can optionally support ISvcClassicSpecialContext where that part of the register context can be presented by a platform specific Windows KSPECIAL_REGISTERS structure.
    /// </summary>
    public class SvcRegisterContext : ComObject<ISvcRegisterContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterContext(ISvcRegisterContext raw) : base(raw)
        {
        }

        #region ISvcRegisterContext
        #region ArchitectureGuid

        /// <summary>
        /// Returns the architecture of the registers that this register context holds. This is either a DEBUG_ARCHDEF_* standard GUID or is a GUID defining a custom architecture.
        /// </summary>
        public Guid ArchitectureGuid
        {
            get
            {
                Guid architecture;
                TryGetArchitectureGuid(out architecture).ThrowDbgEngNotOK();

                return architecture;
            }
        }

        /// <summary>
        /// Returns the architecture of the registers that this register context holds. This is either a DEBUG_ARCHDEF_* standard GUID or is a GUID defining a custom architecture.
        /// </summary>
        public HRESULT TryGetArchitectureGuid(out Guid architecture)
        {
            /*HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);*/
            return Raw.GetArchitectureGuid(out architecture);
        }

        #endregion
        #region GetRegisterValue

        /// <summary>
        /// Gets the value of a register as given by its canonical register number. The following error codes carry special meaning E_INSUFFICIENT_BUFFER: The in-passed buffer is not large enough to hold the register value.<para/>
        /// The actual size of the register is returned in registerSize. E_NOT_SET : The register context does not contain a value for the given register and such cannot be retrieved.
        /// </summary>
        public int GetRegisterValue(int registerId, IntPtr buffer, int bufferSize)
        {
            int registerSize;
            TryGetRegisterValue(registerId, buffer, bufferSize, out registerSize).ThrowDbgEngNotOK();

            return registerSize;
        }

        /// <summary>
        /// Gets the value of a register as given by its canonical register number. The following error codes carry special meaning E_INSUFFICIENT_BUFFER: The in-passed buffer is not large enough to hold the register value.<para/>
        /// The actual size of the register is returned in registerSize. E_NOT_SET : The register context does not contain a value for the given register and such cannot be retrieved.
        /// </summary>
        public HRESULT TryGetRegisterValue(int registerId, IntPtr buffer, int bufferSize, out int registerSize)
        {
            /*HRESULT GetRegisterValue(
            [In] int registerId,
            [Out] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);*/
            return Raw.GetRegisterValue(registerId, buffer, bufferSize, out registerSize);
        }

        #endregion
        #region GetRegisterValue64

        /// <summary>
        /// Similar to GetRegisterValue, this is a convenience method for integer/GPR registers of 64-bits or less where the value of the register will be zero extended to 64-bits and returned.
        /// </summary>
        public long GetRegisterValue64(int registerId)
        {
            long pRegisterValue;
            TryGetRegisterValue64(registerId, out pRegisterValue).ThrowDbgEngNotOK();

            return pRegisterValue;
        }

        /// <summary>
        /// Similar to GetRegisterValue, this is a convenience method for integer/GPR registers of 64-bits or less where the value of the register will be zero extended to 64-bits and returned.
        /// </summary>
        public HRESULT TryGetRegisterValue64(int registerId, out long pRegisterValue)
        {
            /*HRESULT GetRegisterValue64(
            [In] int registerId,
            [Out] out long pRegisterValue);*/
            return Raw.GetRegisterValue64(registerId, out pRegisterValue);
        }

        #endregion
        #region GetAbstractRegisterValue64

        /// <summary>
        /// Behaves as GetRegisterValue64 but on an abstract ID.
        /// </summary>
        public long GetAbstractRegisterValue64(SvcAbstractRegister abstractId)
        {
            long pRegisterValue;
            TryGetAbstractRegisterValue64(abstractId, out pRegisterValue).ThrowDbgEngNotOK();

            return pRegisterValue;
        }

        /// <summary>
        /// Behaves as GetRegisterValue64 but on an abstract ID.
        /// </summary>
        public HRESULT TryGetAbstractRegisterValue64(SvcAbstractRegister abstractId, out long pRegisterValue)
        {
            /*HRESULT GetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [Out] out long pRegisterValue);*/
            return Raw.GetAbstractRegisterValue64(abstractId, out pRegisterValue);
        }

        #endregion
        #region SetRegisterValue

        /// <summary>
        /// Sets the value of a register as given by its canonical register number. The following error codes carry special meaning E_INSUFFICIENT_BUFFER: The in-passed buffer is not large enough for the register's value.<para/>
        /// The required size of the register value is returned in registerSize. E_NOTIMPL : The context does not allow the setting of this register value.
        /// </summary>
        public int SetRegisterValue(int registerId, IntPtr buffer, int bufferSize)
        {
            int registerSize;
            TrySetRegisterValue(registerId, buffer, bufferSize, out registerSize).ThrowDbgEngNotOK();

            return registerSize;
        }

        /// <summary>
        /// Sets the value of a register as given by its canonical register number. The following error codes carry special meaning E_INSUFFICIENT_BUFFER: The in-passed buffer is not large enough for the register's value.<para/>
        /// The required size of the register value is returned in registerSize. E_NOTIMPL : The context does not allow the setting of this register value.
        /// </summary>
        public HRESULT TrySetRegisterValue(int registerId, IntPtr buffer, int bufferSize, out int registerSize)
        {
            /*HRESULT SetRegisterValue(
            [In] int registerId,
            [In] IntPtr buffer,
            [In] int bufferSize,
            [Out] out int registerSize);*/
            return Raw.SetRegisterValue(registerId, buffer, bufferSize, out registerSize);
        }

        #endregion
        #region SetRegisterValue64

        /// <summary>
        /// Similar to SetRegisterValue, this is a convenience method for integer/GPR registers of 64-bits or less where the value of the register will be set from a (presumed) zero extended 64-bit value.
        /// </summary>
        public void SetRegisterValue64(int registerId, long registerValue)
        {
            TrySetRegisterValue64(registerId, registerValue).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Similar to SetRegisterValue, this is a convenience method for integer/GPR registers of 64-bits or less where the value of the register will be set from a (presumed) zero extended 64-bit value.
        /// </summary>
        public HRESULT TrySetRegisterValue64(int registerId, long registerValue)
        {
            /*HRESULT SetRegisterValue64(
            [In] int registerId,
            [In] long registerValue);*/
            return Raw.SetRegisterValue64(registerId, registerValue);
        }

        #endregion
        #region SetAbstractRegisterValue64

        /// <summary>
        /// Behaves as SetRegisterValue64 but on an abstract ID.
        /// </summary>
        public void SetAbstractRegisterValue64(SvcAbstractRegister abstractId, long registerValue)
        {
            TrySetAbstractRegisterValue64(abstractId, registerValue).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Behaves as SetRegisterValue64 but on an abstract ID.
        /// </summary>
        public HRESULT TrySetAbstractRegisterValue64(SvcAbstractRegister abstractId, long registerValue)
        {
            /*HRESULT SetAbstractRegisterValue64(
            [In] SvcAbstractRegister abstractId,
            [In] long registerValue);*/
            return Raw.SetAbstractRegisterValue64(abstractId, registerValue);
        }

        #endregion
        #region GetRegisterValues

        /// <summary>
        /// Gets the value of multiple registers in a single call. Registers are given by a structure defining their canonical register number and the position the value should be placed within an output structure.
        /// </summary>
        public int[] GetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer)
        {
            int[] registerSizes;
            TryGetRegisterValues(registerCount, pRegisters, bufferSize, buffer, out registerSizes).ThrowDbgEngNotOK();

            return registerSizes;
        }

        /// <summary>
        /// Gets the value of multiple registers in a single call. Registers are given by a structure defining their canonical register number and the position the value should be placed within an output structure.
        /// </summary>
        public HRESULT TryGetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer, out int[] registerSizes)
        {
            /*HRESULT GetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [Out] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);*/
            registerSizes = new int[registerCount];
            HRESULT hr = Raw.GetRegisterValues(registerCount, pRegisters, bufferSize, buffer, registerSizes);

            return hr;
        }

        #endregion
        #region SetRegisterValues

        /// <summary>
        /// Sets the value of multiple registers in a single call. Registers are given by a structure defining their canonical register number and the position the value should be retrieved from within an input structure.
        /// </summary>
        public int[] SetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer)
        {
            int[] registerSizes;
            TrySetRegisterValues(registerCount, pRegisters, bufferSize, buffer, out registerSizes).ThrowDbgEngNotOK();

            return registerSizes;
        }

        /// <summary>
        /// Sets the value of multiple registers in a single call. Registers are given by a structure defining their canonical register number and the position the value should be retrieved from within an input structure.
        /// </summary>
        public HRESULT TrySetRegisterValues(int registerCount, RegisterInformationQuery[] pRegisters, int bufferSize, IntPtr buffer, out int[] registerSizes)
        {
            /*HRESULT SetRegisterValues(
            [In] int registerCount,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RegisterInformationQuery[] pRegisters,
            [In] int bufferSize,
            [In] IntPtr buffer,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] registerSizes);*/
            registerSizes = new int[registerCount];
            HRESULT hr = Raw.SetRegisterValues(registerCount, pRegisters, bufferSize, buffer, registerSizes);

            return hr;
        }

        #endregion
        #region SetToContext

        /// <summary>
        /// Copies the values of one register context into this register context.
        /// </summary>
        public void SetToContext(ISvcRegisterContext registerContext)
        {
            TrySetToContext(registerContext).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Copies the values of one register context into this register context.
        /// </summary>
        public HRESULT TrySetToContext(ISvcRegisterContext registerContext)
        {
            /*HRESULT SetToContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext registerContext);*/
            return Raw.SetToContext(registerContext);
        }

        #endregion
        #region Duplicate

        /// <summary>
        /// Creates a duplicate copy of the register context. Changes made to the duplicate copy do not affect the original.
        /// </summary>
        public SvcRegisterContext Duplicate()
        {
            SvcRegisterContext duplicateContextResult;
            TryDuplicate(out duplicateContextResult).ThrowDbgEngNotOK();

            return duplicateContextResult;
        }

        /// <summary>
        /// Creates a duplicate copy of the register context. Changes made to the duplicate copy do not affect the original.
        /// </summary>
        public HRESULT TryDuplicate(out SvcRegisterContext duplicateContextResult)
        {
            /*HRESULT Duplicate(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext duplicateContext);*/
            ISvcRegisterContext duplicateContext;
            HRESULT hr = Raw.Duplicate(out duplicateContext);

            if (hr == HRESULT.S_OK)
                duplicateContextResult = duplicateContext == null ? null : new SvcRegisterContext(duplicateContext);
            else
                duplicateContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #endregion
    }
}

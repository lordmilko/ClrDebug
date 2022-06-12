using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a value in the process being debugged. The value can be a read or a write value.
    /// </summary>
    /// <remarks>
    /// In general, ownership of a value object is passed when it is returned. The recipient is responsible for removing
    /// a reference from the object when it is finished with the object. Depending on where the value was retrieved from,
    /// the value may not remain valid after the process is resumed. So, in general, the value shouldn't be held across
    /// a call of the <see cref="CorDebugController.Continue"/> method.
    /// </remarks>
    public abstract class CorDebugValue : ComObject<ICorDebugValue>
    {
        public static CorDebugValue New(ICorDebugValue value)
        {
            if (value is ICorDebugGenericValue)
                return new CorDebugGenericValue((ICorDebugGenericValue) value);

            if (value is ICorDebugArrayValue)
                return new CorDebugArrayValue((ICorDebugArrayValue) value);

            if (value is ICorDebugBoxValue)
                return new CorDebugBoxValue((ICorDebugBoxValue) value);

            if (value is ICorDebugStringValue)
                return new CorDebugStringValue((ICorDebugStringValue) value);

            if (value is ICorDebugContext)
                return new CorDebugContext((ICorDebugContext) value);

            if (value is ICorDebugHandleValue)
                return new CorDebugHandleValue((ICorDebugHandleValue) value);

            throw new NotImplementedException("Encountered an ICorDebugValue' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugValue(ICorDebugValue raw) : base(raw)
        {
        }

        #region ICorDebugValue
        #region GetType

        /// <summary>
        /// Gets the primitive type of this "ICorDebugValue" object.
        /// </summary>
        public CorElementType Type
        {
            get
            {
                HRESULT hr;
                CorElementType pType;

                if ((hr = TryGetType(out pType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pType;
            }
        }

        /// <summary>
        /// Gets the primitive type of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the "CorElementType" enumeration that indicates the value's type.</param>
        /// <remarks>
        /// If the object is a complex run-time type, that type may be examined through the appropriate subclasses of the <see cref="ICorDebugValue"/>
        /// interface. For example, "ICorDebugObjectValue", which inherits from <see cref="ICorDebugValue"/>, represents a complex type.
        /// The GetType and <see cref="CorDebugObjectValue.Class"/> propertys each return information about the type of a
        /// value. They are both superseded by the generics-aware <see cref="ExactType"/> property.
        /// </remarks>
        public HRESULT TryGetType(out CorElementType pType)
        {
            /*HRESULT GetType(out CorElementType pType);*/
            return Raw.GetType(out pType);
        }

        #endregion
        #region GetSize

        /// <summary>
        /// Gets the size, in bytes, of this "ICorDebugValue" object.
        /// </summary>
        public int Size
        {
            get
            {
                HRESULT hr;
                int pSize;

                if ((hr = TryGetSize(out pSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSize;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pSize">[out] The size, in bytes, of this value object.</param>
        /// <remarks>
        /// If the value's type is a reference type, this method returns the size of the pointer rather than the size of the
        /// object. The <see cref="Size"/> property returns COR_E_OVERFLOW for objects that are larger than 4 GB on 64-bit
        /// platforms. Use the <see cref="Size64"/> property instead for objects that are larger than 4 GB.
        /// </remarks>
        public HRESULT TryGetSize(out int pSize)
        {
            /*HRESULT GetSize(out int pSize);*/
            return Raw.GetSize(out pSize);
        }

        #endregion
        #region GetAddress

        /// <summary>
        /// Gets the address of this "ICorDebugValue" object, which is in the process of being debugged.
        /// </summary>
        public CORDB_ADDRESS Address
        {
            get
            {
                HRESULT hr;
                CORDB_ADDRESS pAddress;

                if ((hr = TryGetAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        /// <summary>
        /// Gets the address of this "ICorDebugValue" object, which is in the process of being debugged.
        /// </summary>
        /// <param name="pAddress">[out] Pointer to a <see cref="CORDB_ADDRESS"/> object that specifies the address of this value object.</param>
        /// <remarks>
        /// If the value is unavailable, 0 (zero) is returned. This could happen if the value is at least partly in registers
        /// or stored in a garbage collector handle (GCHandle).
        /// </remarks>
        public HRESULT TryGetAddress(out CORDB_ADDRESS pAddress)
        {
            /*HRESULT GetAddress(out CORDB_ADDRESS pAddress);*/
            return Raw.GetAddress(out pAddress);
        }

        #endregion
        #region CreateBreakpoint

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        public CorDebugValueBreakpoint CreateBreakpoint()
        {
            HRESULT hr;
            CorDebugValueBreakpoint ppBreakpointResult;

            if ((hr = TryCreateBreakpoint(out ppBreakpointResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointResult;
        }

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        public HRESULT TryCreateBreakpoint(out CorDebugValueBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);*/
            ICorDebugValueBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugValueBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugValueBreakpoint);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugValue2

        public ICorDebugValue2 Raw2 => (ICorDebugValue2) Raw;

        #region GetExactType

        /// <summary>
        /// Gets an interface pointer to an "ICorDebugType" object that represents the <see cref="Type"/> of this value.
        /// </summary>
        public CorDebugType ExactType
        {
            get
            {
                HRESULT hr;
                CorDebugType ppTypeResult;

                if ((hr = TryGetExactType(out ppTypeResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppTypeResult;
            }
        }

        /// <summary>
        /// Gets an interface pointer to an "ICorDebugType" object that represents the <see cref="Type"/> of this value.
        /// </summary>
        /// <param name="ppTypeResult">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the <see cref="Type"/> of the value represented by this "ICorDebugValue2" object.</param>
        /// <remarks>
        /// The generics-aware GetExactType method supersedes both the <see cref="CorDebugObjectValue.Class"/> and the
        /// <see cref="Type"/> propertys, each of which return information about the type
        /// of a value.
        /// </remarks>
        public HRESULT TryGetExactType(out CorDebugType ppTypeResult)
        {
            /*HRESULT GetExactType([MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetExactType(out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugValue3

        public ICorDebugValue3 Raw3 => (ICorDebugValue3) Raw;

        #region GetSize64

        /// <summary>
        /// Gets the size, in bytes, of this <see cref="ICorDebugValue3"/> object.
        /// </summary>
        public long Size64
        {
            get
            {
                HRESULT hr;
                long pSize;

                if ((hr = TryGetSize64(out pSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSize;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of this <see cref="ICorDebugValue3"/> object.
        /// </summary>
        /// <param name="pSize">[out] A pointer to the size, in bytes, of this object.</param>
        /// <remarks>
        /// If this value's type is a reference type, this method returns the size of the pointer rather than the size of the
        /// object. The <see cref="Size64"/> property differs from the <see cref="Size"/> property in the
        /// type of its output parameter. In <see cref="Size"/>, the output parameter is a ULONG32; in <see cref="Size64"/>,
        /// it is a ULONG64. This enables the <see cref="ICorDebugValue3"/> interface to report the size of arrays that exceed
        /// 2GB.
        /// </remarks>
        public HRESULT TryGetSize64(out long pSize)
        {
            /*HRESULT GetSize64(out long pSize);*/
            return Raw3.GetSize64(out pSize);
        }

        #endregion
        #endregion
    }
}
using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of "ICorDebugValue" that applies to all values. This interface provides Get and Set methods for the value.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugGenericValue"/> is a sub-interface because it is non-remotable. For reference types, the value is the reference
    /// rather than the contents of the reference. This interface does not support being called remotely, either cross-machine
    /// or cross-process.
    /// </remarks>
    public class CorDebugGenericValue : CorDebugValue
    {
        public CorDebugGenericValue(ICorDebugGenericValue raw) : base(raw)
        {
        }

        #region ICorDebugGenericValue

        public new ICorDebugGenericValue Raw => (ICorDebugGenericValue) base.Raw;

        #region GetValue

        /// <summary>
        /// Copies the value of this generic into the specified buffer.
        /// </summary>
        public IntPtr Value
        {
            get
            {
                HRESULT hr;
                IntPtr pTo = default(IntPtr);

                if ((hr = TryGetValue(ref pTo)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTo;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetValue(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        /// <summary>
        /// Copies the value of this generic into the specified buffer.
        /// </summary>
        /// <param name="pTo">[out] A pointer to the value that is represented by this <see cref="ICorDebugGenericValue"/> object. The value may be a simple type or a reference type (that is, a pointer).</param>
        public HRESULT TryGetValue(ref IntPtr pTo)
        {
            /*HRESULT GetValue([Out] IntPtr pTo);*/
            return Raw.GetValue(pTo);
        }

        /// <summary>
        /// Copies a new value from the specified buffer.
        /// </summary>
        /// <param name="pFrom">[in] A pointer to the buffer from which to copy the value.</param>
        /// <remarks>
        /// For reference types, the value is the reference, not the content.
        /// </remarks>
        public HRESULT TrySetValue(IntPtr pFrom)
        {
            /*HRESULT SetValue([In] IntPtr pFrom);*/
            return Raw.SetValue(pFrom);
        }

        #endregion
        #endregion
    }
}
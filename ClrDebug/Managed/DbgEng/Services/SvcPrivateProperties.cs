using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Various services.
    /// </summary>
    public class SvcPrivateProperties : ComObject<ISvcPrivateProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcPrivateProperties"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcPrivateProperties(ISvcPrivateProperties raw) : base(raw)
        {
        }

        #region ISvcPrivateProperties
        #region HasProperty

        /// <summary>
        /// Indicates whether this object supports a private property.
        /// </summary>
        public bool HasProperty(Guid set, int id)
        {
            bool hasProperty;
            TryHasProperty(set, id, out hasProperty).ThrowDbgEngNotOK();

            return hasProperty;
        }

        /// <summary>
        /// Indicates whether this object supports a private property.
        /// </summary>
        public HRESULT TryHasProperty(Guid set, int id, out bool hasProperty)
        {
            /*HRESULT HasProperty(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasProperty);*/
            return Raw.HasProperty(set, id, out hasProperty);
        }

        #endregion
        #region GetProperty

        /// <summary>
        /// Gets a private property.
        /// </summary>
        public void GetProperty(Guid set, int id, int bufferSize, IntPtr buffer)
        {
            TryGetProperty(set, id, bufferSize, buffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Gets a private property.
        /// </summary>
        public HRESULT TryGetProperty(Guid set, int id, int bufferSize, IntPtr buffer)
        {
            /*HRESULT GetProperty(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [In] int bufferSize,
            [Out] IntPtr buffer);*/
            return Raw.GetProperty(set, id, bufferSize, buffer);
        }

        #endregion
        #region SetProperty

        /// <summary>
        /// Sets a private property.
        /// </summary>
        public void SetProperty(Guid set, int id, int valueSize, IntPtr valueBuffer)
        {
            TrySetProperty(set, id, valueSize, valueBuffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Sets a private property.
        /// </summary>
        public HRESULT TrySetProperty(Guid set, int id, int valueSize, IntPtr valueBuffer)
        {
            /*HRESULT SetProperty(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid set,
            [In] int id,
            [In] int valueSize,
            [In] IntPtr valueBuffer);*/
            return Raw.SetProperty(set, id, valueSize, valueBuffer);
        }

        #endregion
        #endregion
    }
}

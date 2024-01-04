using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class ComponentFileSourceInitializer : ComObject<IComponentFileSourceInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentFileSourceInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentFileSourceInitializer(IComponentFileSourceInitializer raw) : base(raw)
        {
        }

        #region IComponentFileSourceInitializer
        #region Initialize

        public void Initialize(string filePath)
        {
            TryInitialize(filePath).ThrowDbgEngNotOK();
        }

        public HRESULT TryInitialize(string filePath)
        {
            /*HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.LPWStr)] string filePath);*/
            return Raw.Initialize(filePath);
        }

        #endregion
        #endregion
        #region IComponentFileSourceInitializer2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IComponentFileSourceInitializer2 Raw2 => (IComponentFileSourceInitializer2) Raw;

        #region InitializeFromHandle

        public void InitializeFromHandle(string fileName, IntPtr fileHandle)
        {
            TryInitializeFromHandle(fileName, fileHandle).ThrowDbgEngNotOK();
        }

        public HRESULT TryInitializeFromHandle(string fileName, IntPtr fileHandle)
        {
            /*HRESULT InitializeFromHandle(
            [In, MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [In] IntPtr fileHandle);*/
            return Raw2.InitializeFromHandle(fileName, fileHandle);
        }

        #endregion
        #endregion
    }
}

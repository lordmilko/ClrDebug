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

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_FILESOURCE component by opening a file at the given path. This method will fail if no such file exists or it cannot be opened.
        /// </summary>
        public void Initialize(string filePath)
        {
            TryInitialize(filePath).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_FILESOURCE component by opening a file at the given path. This method will fail if no such file exists or it cannot be opened.
        /// </summary>
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

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_FILESOURCE component from an already opened file handle. While a file name must be provided, it has no bearing on the utilized file.<para/>
        /// If this method succeeds, ownership of the file handle is *TRANSFERRED* to the file source.
        /// </summary>
        public void InitializeFromHandle(string fileName, IntPtr fileHandle)
        {
            TryInitializeFromHandle(fileName, fileHandle).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_FILESOURCE component from an already opened file handle. While a file name must be provided, it has no bearing on the utilized file.<para/>
        /// If this method succeeds, ownership of the file handle is *TRANSFERRED* to the file source.
        /// </summary>
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

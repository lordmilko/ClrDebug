using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug
{
    public unsafe class RuntimeCallableWrapper : IDisposable
    {
        /// <summary>
        /// Gets a pointer to the object this RCW encapsulates. If no specific interface is specified,
        /// this value points to IUnknown.
        /// </summary>
        public IntPtr Raw { get; private set; }

        /// <summary>
        /// Gets the IUnknown vtable of this object.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IUnknownVtbl* IUnknownVtbl { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected void* Vtbl => IUnknownVtbl + 1;

        public static readonly Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");

        /// <summary>
        /// Gets the reference count on the underlying COM object.
        /// </summary>
        private int RefCount
        {
            get
            {
                lock (lockObj)
                {
                    AddRef();
                    return Release();
                }
            }
        }

        /// <summary>
        /// Gets the reference count of any normal RCWs that have been created by the runtime.<para/>
        /// If this value is <see langword="null"/>, the underlying interface does not properly implement IUnknown.
        /// </summary>
        private int? RCWRefCount
        {
            get
            {
                lock (lockObj)
                {
                    var hr = QueryInterface(IID_IUnknown, out var _);

                    if (hr != HRESULT.S_OK)
                        return null;

                    var o = Marshal.GetObjectForIUnknown(Raw);
                    return Marshal.ReleaseComObject(o);
                }
            }
        }

        private bool disposed;

        //Though we're only locking resources owned by a single RuntimeCallableWrapper, there's no point wasting memory
        //on each object just to store this lock
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static object lockObj = new object();

        public RuntimeCallableWrapper(object value) : this(GetIUnknownPointer(value), value.GetType().GUID)
        {
        }

        public RuntimeCallableWrapper(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;

            IUnknownVtbl = *(IUnknownVtbl**)raw;
        }

        public RuntimeCallableWrapper(IntPtr raw, Guid riid) : this(raw)
        {
            IntPtr ppvObject;
            Marshal.ThrowExceptionForHR((int) QueryInterface(riid, out ppvObject));
            Release();

            Raw = ppvObject;
            IUnknownVtbl = *(IUnknownVtbl**)ppvObject;

            queryInterface = null;
            addRef = null;
            release = null;
        }

        ~RuntimeCallableWrapper()
        {
            Dispose(false);
        }

        private static IntPtr GetIUnknownPointer(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!value.GetType().IsCOMObject)
                throw new ArgumentException("Value is not a COM object.", nameof(value));

            return Marshal.GetIUnknownForObject(value);
        }

        protected void InitDelegate<T>(ref T @delegate, IntPtr vtablePtr)
        {
            //If we've already initialized this delegate, no need to do it again
            if (@delegate != null)
                return;

            @delegate = Marshal.GetDelegateForFunctionPointer<T>(vtablePtr);
        }

        /// <summary>
        /// Marshals a real RCW of a specified interface type from the underlying object pointer.<para/>
        /// If the COM object does not respond to QueryInterface against IUnknown, this method will
        /// throw an exception.
        /// </summary>
        /// <typeparam name="T">The type of interface to marshal.</typeparam>
        /// <returns>A real RCW of type <typeparamref name="T"/>.</returns>
        public T AsInterface<T>()
        {
            var unk = Marshal.GetObjectForIUnknown(Raw);

            return (T)unk;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //Free managed references
                }

                Release();
                Raw = IntPtr.Zero;
                disposed = true;
            }
        }

        #region IUnknown

        public HRESULT QueryInterface(Guid riid, out IntPtr ppvObject)
        {
            InitDelegate(ref queryInterface, IUnknownVtbl->QueryInterface);

            return queryInterface(Raw, ref riid, out ppvObject);
        }

        public int AddRef()
        {
            InitDelegate(ref addRef, IUnknownVtbl->AddRef);

            return addRef(Raw);
        }

        public int Release()
        {
            InitDelegate(ref release, IUnknownVtbl->Release);

            return release(Raw);
        }

        #endregion
        #region Cached Delegates

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryInterfaceDelegate queryInterface;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddRefDelegate addRef;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReleaseDelegate release;

        #endregion
        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate HRESULT QueryInterfaceDelegate(IntPtr self, ref Guid riid, out IntPtr ppvObject);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate int AddRefDelegate(IntPtr self);

        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        private delegate int ReleaseDelegate(IntPtr self);

        #endregion
    }
}

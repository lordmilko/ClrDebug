using System;
using System.ComponentModel;
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

#if DEBUG
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int remainingRefs;
#endif

        public static readonly Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");

        /// <summary>
        /// Gets the reference count of the underlying COM object.
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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int UnsafeRefCount => RefCount;

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

#pragma warning disable CA1416 //This call site is reachable on all platforms
                    var o = Marshal.GetObjectForIUnknown(Raw);
                    return Marshal.ReleaseComObject(o);
#pragma warning restore CA1416 //This call site is reachable on all platforms
                }
            }
        }

        protected bool disposed;

        //Though we're only locking resources owned by a single RuntimeCallableWrapper, there's no point wasting memory
        //on each object just to store this lock
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static object lockObj = new object();

        public RuntimeCallableWrapper(object value) : this(GetIUnknownPointer(value), value.GetType().GUID)
        {
        }

        private RuntimeCallableWrapper(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;

            IUnknownVtbl = *(IUnknownVtbl**) raw;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeCallableWrapper"/> class from a raw COM pointer and an interface IID that the pointer should be
        /// converted to via a call to QueryInterface().<para/>
        /// Upon performing a successful QueryInterface(), the reference count of the underlying COM object will be increased by 1. Upon disposing this
        /// <see cref="RuntimeCallableWrapper"/>, if the remaining reference count is 1, this instance will also perform the final Release() to bring the reference count to 0.
        /// </summary>
        /// <param name="raw">The pointer to the COM object that should be encapsulated in this <see cref="RuntimeCallableWrapper"/>.</param>
        /// <param name="riid">The <see cref="Guid"/> of the interface that <paramref name="raw"/> should be converted to.</param>
        public RuntimeCallableWrapper(IntPtr raw, Guid riid) : this(raw)
        {
            IntPtr ppvObject;
            QueryInterface(riid, out ppvObject).ThrowOnNotOK();

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

#pragma warning disable CA1416 //This call site is reachable on all platforms
            return Marshal.GetIUnknownForObject(value);
#pragma warning restore CA1416 //This call site is reachable on all platforms
        }

        protected void InitDelegate<T>(ref T @delegate, IntPtr vtablePtr)
        {
            //If we've already initialized this delegate, no need to do it again
            if (@delegate != null)
                return;

            @delegate = Marshal.GetDelegateForFunctionPointer<T>(vtablePtr);
        }

        protected void InitInterface(Guid riid, ref IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                QueryInterface(riid, out ptr).ThrowOnNotOK();
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
#pragma warning disable CA1416 //This call site is reachable on all platforms
            var unk = Marshal.GetObjectForIUnknown(Raw);
#pragma warning restore CA1416 //This call site is reachable on all platforms

            return (T) unk;
        }

        /// <summary>
        /// Disposes all <see cref="RuntimeCallableWrapper"/> extension members that may be associated with this object,
        /// and decreases the reference count of the underlying COM object by 1.<para/>If, after decreasing the underlying COM object's
        /// reference count, the remaining count is now 1, this method also performs the final release of the given COM object.
        /// </summary>
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

                if (Raw != IntPtr.Zero)
                {
                    //When this RCW was constructed, the reference count was already 1. When we QI'd for the interface type that this RCW encapsulates,
                    //the count jumped up to 2. Because we take ownership of the object that we encapsulate, when the count hits 1 again, we need to also
                    //perform the final release 

#if DEBUG
                    remainingRefs = Release();

                    if (remainingRefs == 1)
                    {
                        Release();
                        remainingRefs = 0;
                    }
#else
                    if (Release() == 1)
                        Release();
#endif

                }

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

#if DEBUG
        public override string ToString()
        {
            if (Raw == IntPtr.Zero)
                return $"[Destroyed / RefCount: {remainingRefs}] {GetType().Name}";

            return $"[RefCount {RefCount}] {GetType().Name}";
        }
#endif
    }
}

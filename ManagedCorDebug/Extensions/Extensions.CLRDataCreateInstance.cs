using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from a <see cref="CLRDataCreateInstanceDelegate"/>.
        /// </summary>
        public class CLRDataCreateInstanceInterfaces
        {
            private CLRDataCreateInstanceDelegate clrDataCreateInstance;
            private ICLRDataTarget target;

            internal CLRDataCreateInstanceInterfaces(CLRDataCreateInstanceDelegate clrDataCreateInstance, ICLRDataTarget target)
            {
                this.clrDataCreateInstance = clrDataCreateInstance;
                this.target = target;
            }

            public XCLRDataProcess XCLRDataProcess => new XCLRDataProcess(CreateInstance<IXCLRDataProcess>());

            public SOSDacInterface SOSDacInterface => new SOSDacInterface(CreateInstance<ISOSDacInterface>());

            private T CreateInstance<T>()
            {
                var iid = typeof(T).GUID;
                object iface;
                var hr = clrDataCreateInstance(ref iid, target, out iface);
                Marshal.ThrowExceptionForHR((int)hr);

                return (T)iface;
            }
        }
    }
}

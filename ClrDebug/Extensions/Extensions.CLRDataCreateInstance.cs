using System.Runtime.InteropServices;

namespace ClrDebug
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
                var hr = clrDataCreateInstance(iid, target, out iface);
                hr.ThrowOnNotOK();

                return (T)iface;
            }
        }
    }
}

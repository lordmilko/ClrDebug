using System;

namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Provides facilities for retrieving interfaces that are commonly retrieved from a <see cref="DllGetClassObjectDelegate"/>.
        /// </summary>
        public class DllGetClassObjectInterfaces
        {
            private DllGetClassObjectDelegate dllGetClassObject;

            public DllGetClassObjectInterfaces(DllGetClassObjectDelegate dllGetClassObject)
            {
                this.dllGetClassObject = dllGetClassObject;
            }

            public IClassFactory GetClassFactory(Guid rclsid) => CreateInstance<IClassFactory>(rclsid);

            private T CreateInstance<T>(Guid rclsid)
            {
                var iid = typeof(T).GUID;
                var hr = dllGetClassObject(rclsid, iid, out var iface);
                hr.ThrowOnNotOK();

                return (T) iface;
            }
        }
    }
}

using System;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static T CreateInstance<T>(this IClassFactory classFactory, object pUnkOuter = null)
        {
            classFactory.CreateInstance(pUnkOuter, typeof(T).GUID, out var ppvObject).ThrowOnNotOK();

            return (T) ppvObject;
        }
    }
}

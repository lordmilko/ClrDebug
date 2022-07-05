using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static XCLRDataModule[] EnumModules(this XCLRDataAssembly assembly)
        {
            XCLRDataModule value;

            var handle = assembly.StartEnumModules();

            try
            {
                var list = new List<XCLRDataModule>();

                while (assembly.TryEnumModule(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                assembly.EndEnumModules(handle);
            }
        }

        public static XCLRDataAppDomain[] EnumAppDomains(this XCLRDataAssembly assembly)
        {
            XCLRDataAppDomain value;

            var handle = assembly.StartEnumAppDomains();

            try
            {
                var list = new List<XCLRDataAppDomain>();

                while (assembly.TryEnumAppDomain(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                assembly.EndEnumAppDomains(handle);
            }
        }
    }
}

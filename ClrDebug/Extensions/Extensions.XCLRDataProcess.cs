using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static XCLRDataTask[] EnumTasks(this XCLRDataProcess process)
        {
            XCLRDataTask value;

            var handle = process.StartEnumTasks();

            try
            {
                var list = new List<XCLRDataTask>();

                while (process.TryEnumTask(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                process.EndEnumTasks(handle);
            }
        }

        public static XCLRDataAppDomain[] EnumAppDomains(this XCLRDataProcess process)
        {
            XCLRDataAppDomain value;

            var handle = process.StartEnumAppDomains();

            try
            {
                var list = new List<XCLRDataAppDomain>();

                while (process.TryEnumAppDomain(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                process.EndEnumAppDomains(handle);
            }
        }

        public static XCLRDataAssembly[] EnumAssemblies(this XCLRDataProcess process)
        {
            XCLRDataAssembly value;

            var handle = process.StartEnumAssemblies();

            try
            {
                var list = new List<XCLRDataAssembly>();

                while (process.TryEnumAssembly(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                process.EndEnumAssemblies(handle);
            }
        }

        public static XCLRDataModule[] EnumModules(this XCLRDataProcess process)
        {
            XCLRDataModule value;

            var handle = process.StartEnumModules();

            try
            {
                var list = new List<XCLRDataModule>();

                while (process.TryEnumModule(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                process.EndEnumModules(handle);
            }
        }

        public static XCLRDataMethodInstance[] EnumMethodInstancesByAddress(this XCLRDataProcess process, CLRDATA_ADDRESS address, IXCLRDataAppDomain appDomain)
        {
            XCLRDataMethodInstance value;

            var handle = process.StartEnumMethodInstancesByAddress(address, appDomain);

            try
            {
                var list = new List<XCLRDataMethodInstance>();

                while (process.TryEnumMethodInstanceByAddress(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                process.EndEnumMethodInstancesByAddress(handle);
            }
        }

        public static XCLRDataMethodDefinition[] EnumMethodDefinitionsByAddress(this XCLRDataProcess process, CLRDATA_ADDRESS address)
        {
            XCLRDataMethodDefinition value;

            var handle = process.StartEnumMethodDefinitionsByAddress(address);

            try
            {
                var list = new List<XCLRDataMethodDefinition>();

                while (process.TryEnumMethodDefinitionByAddress(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                process.EndEnumMethodDefinitionsByAddress(handle);
            }
        }
    }
}

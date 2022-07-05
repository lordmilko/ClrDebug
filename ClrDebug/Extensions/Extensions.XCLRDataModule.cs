using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static XCLRDataAssembly[] EnumAssemblies(this XCLRDataModule module)
        {
            XCLRDataAssembly value;

            var handle = module.StartEnumAssemblies();

            try
            {
                var list = new List<XCLRDataAssembly>();

                while (module.TryEnumAssembly(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumAssemblies(handle);
            }
        }

        public static XCLRDataTypeDefinition[] EnumTypeDefinitions(this XCLRDataModule module)
        {
            XCLRDataTypeDefinition value;

            var handle = module.StartEnumTypeDefinitions();

            try
            {
                var list = new List<XCLRDataTypeDefinition>();

                while (module.TryEnumTypeDefinition(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumTypeDefinitions(handle);
            }
        }

        public static XCLRDataTypeInstance[] EnumTypeInstances(this XCLRDataModule module, IXCLRDataAppDomain appDomain)
        {
            XCLRDataTypeInstance value;

            var handle = module.StartEnumTypeInstances(appDomain);

            try
            {
                var list = new List<XCLRDataTypeInstance>();

                while (module.TryEnumTypeInstance(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumTypeInstances(handle);
            }
        }

        public static XCLRDataTypeDefinition[] EnumTypeDefinitionsByName(this XCLRDataModule module, string name, CLRDataByNameFlag flags)
        {
            XCLRDataTypeDefinition value;

            var handle = module.StartEnumTypeDefinitionsByName(name, flags);

            try
            {
                var list = new List<XCLRDataTypeDefinition>();

                while (module.TryEnumTypeDefinitionByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumTypeDefinitionsByName(handle);
            }
        }

        public static XCLRDataTypeInstance[] EnumTypeInstancesByName(this XCLRDataModule module, string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain)
        {
            XCLRDataTypeInstance value;

            var handle = module.StartEnumTypeInstancesByName(name, flags, appDomain);

            try
            {
                var list = new List<XCLRDataTypeInstance>();

                while (module.TryEnumTypeInstanceByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumTypeInstancesByName(handle);
            }
        }

        public static XCLRDataMethodDefinition[] EnumMethodDefinitionsByName(this XCLRDataModule module, string name, CLRDataByNameFlag flags)
        {
            XCLRDataMethodDefinition value;

            var handle = module.StartEnumMethodDefinitionsByName(name, flags);

            try
            {
                var list = new List<XCLRDataMethodDefinition>();

                while (module.TryEnumMethodDefinitionByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumMethodDefinitionsByName(handle);
            }
        }

        public static XCLRDataMethodInstance[] EnumMethodInstancesByName(this XCLRDataModule module, string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain)
        {
            XCLRDataMethodInstance value;

            var handle = module.StartEnumMethodInstancesByName(name, flags, appDomain);

            try
            {
                var list = new List<XCLRDataMethodInstance>();

                while (module.TryEnumMethodInstanceByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumMethodInstancesByName(handle);
            }
        }

        public static XCLRDataValue[] EnumDataByName(this XCLRDataModule module, string name, CLRDataByNameFlag flags, IXCLRDataAppDomain appDomain, IXCLRDataTask tlsTask)
        {
            XCLRDataValue value;

            var handle = module.StartEnumDataByName(name, flags, appDomain, tlsTask);

            try
            {
                var list = new List<XCLRDataValue>();

                while (module.TryEnumDataByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumDataByName(handle);
            }
        }

        public static CLRDATA_MODULE_EXTENT[] EnumExtents(this XCLRDataModule module)
        {
            CLRDATA_MODULE_EXTENT value;

            var handle = module.StartEnumExtents();

            try
            {
                var list = new List<CLRDATA_MODULE_EXTENT>();

                while (module.TryEnumExtent(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumExtents(handle);
            }
        }

        public static XCLRDataAppDomain[] EnumAppDomains(this XCLRDataModule module)
        {
            XCLRDataAppDomain value;

            var handle = module.StartEnumAppDomains();

            try
            {
                var list = new List<XCLRDataAppDomain>();

                while (module.TryEnumAppDomain(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                module.EndEnumAppDomains(handle);
            }
        }
    }
}

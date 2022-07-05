using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static XCLRDataMethodDefinition[] EnumMethodDefinitions(this XCLRDataTypeDefinition typeDefinition)
        {
            XCLRDataMethodDefinition value;

            var handle = typeDefinition.StartEnumMethodDefinitions();

            try
            {
                var list = new List<XCLRDataMethodDefinition>();

                while (typeDefinition.TryEnumMethodDefinition(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeDefinition.EndEnumMethodDefinitions(handle);
            }
        }

        public static XCLRDataMethodDefinition[] EnumMethodDefinitionsByName(this XCLRDataTypeDefinition typeDefinition, string name, CLRDataByNameFlag flags)
        {
            XCLRDataMethodDefinition value;

            var handle = typeDefinition.StartEnumMethodDefinitionsByName(name, flags);

            try
            {
                var list = new List<XCLRDataMethodDefinition>();

                while (typeDefinition.TryEnumMethodDefinitionByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeDefinition.EndEnumMethodDefinitionsByName(handle);
            }
        }

        public static XCLRDataTypeInstance[] EnumInstances(this XCLRDataTypeDefinition typeDefinition, IXCLRDataAppDomain appDomain)
        {
            XCLRDataTypeInstance value;

            var handle = typeDefinition.StartEnumInstances(appDomain);

            try
            {
                var list = new List<XCLRDataTypeInstance>();

                while (typeDefinition.TryEnumInstance(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeDefinition.EndEnumInstances(handle);
            }
        }

        public static EnumFieldResult[] EnumFields(this XCLRDataTypeDefinition typeDefinition, CLRDataFieldFlag flags)
        {
            EnumFieldResult value;

            var handle = typeDefinition.StartEnumFields(flags);

            try
            {
                var list = new List<EnumFieldResult>();

                while (typeDefinition.TryEnumField(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeDefinition.EndEnumFields(handle);
            }
        }

        public static EnumFieldByNameResult[] EnumFieldsByName(this XCLRDataTypeDefinition typeDefinition, string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags)
        {
            EnumFieldByNameResult value;

            var handle = typeDefinition.StartEnumFieldsByName(name, nameFlags, fieldFlags);

            try
            {
                var list = new List<EnumFieldByNameResult>();

                while (typeDefinition.TryEnumFieldByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeDefinition.EndEnumFieldsByName(handle);
            }
        }

        public static EnumField2Result[] EnumFields2(this XCLRDataTypeDefinition typeDefinition, CLRDataFieldFlag flags)
        {
            EnumField2Result value;

            var handle = typeDefinition.StartEnumFields(flags);

            try
            {
                var list = new List<EnumField2Result>();

                while (typeDefinition.TryEnumField2(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeDefinition.EndEnumFieldsByName(handle);
            }
        }

        public static EnumFieldByName2Result[] EnumFieldsByName2(this XCLRDataTypeDefinition typeDefinition, string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags)
        {
            EnumFieldByName2Result value;

            var handle = typeDefinition.StartEnumFieldsByName(name, nameFlags, fieldFlags);

            try
            {
                var list = new List<EnumFieldByName2Result>();

                while (typeDefinition.TryEnumFieldByName2(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeDefinition.EndEnumFieldsByName(handle);
            }
        }
    }
}

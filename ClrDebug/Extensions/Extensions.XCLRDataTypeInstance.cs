using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static XCLRDataMethodInstance[] EnumMethodInstances(this XCLRDataTypeInstance typeInstance)
        {
            XCLRDataMethodInstance value;

            var handle = typeInstance.StartEnumMethodInstances();

            try
            {
                var list = new List<XCLRDataMethodInstance>();

                while (typeInstance.TryEnumMethodInstance(ref handle, out value).ThrowOnFailed().ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeInstance.EndEnumMethodInstances(handle);
            }
        }

        public static XCLRDataMethodInstance[] EnumMethodInstancesByName(this XCLRDataTypeInstance typeInstance, string name, CLRDataByNameFlag flags)
        {
            XCLRDataMethodInstance value;

            var handle = typeInstance.StartEnumMethodInstancesByName(name, flags);

            try
            {
                var list = new List<XCLRDataMethodInstance>();

                while (typeInstance.TryEnumMethodInstanceByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeInstance.EndEnumMethodInstancesByName(handle);
            }
        }

        public static XCLRDataValue[] EnumStaticFieldsByName(this XCLRDataTypeInstance typeInstance, string name, CLRDataByNameFlag flags, IXCLRDataTask tlsTask)
        {
            XCLRDataValue value;

            var handle = typeInstance.StartEnumStaticFieldsByName(name, flags, tlsTask);

            try
            {
                var list = new List<XCLRDataValue>();

                while (typeInstance.TryEnumStaticFieldByName(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeInstance.EndEnumStaticFieldsByName(handle);
            }
        }

        public static XCLRDataValue[] EnumStaticFields(this XCLRDataTypeInstance typeInstance, CLRDataFieldFlag flags, IXCLRDataTask tlsTask)
        {
            XCLRDataValue value;

            var handle = typeInstance.StartEnumStaticFields(flags, tlsTask);

            try
            {
                var list = new List<XCLRDataValue>();

                while (typeInstance.TryEnumStaticField(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeInstance.EndEnumStaticFields(handle);
            }
        }

        public static XCLRDataValue[] EnumStaticFieldsByName2(this XCLRDataTypeInstance typeInstance, string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTask tlsTask)
        {
            XCLRDataValue value;

            var handle = typeInstance.StartEnumStaticFieldsByName2(name, nameFlags, fieldFlags, tlsTask);

            try
            {
                var list = new List<XCLRDataValue>();

                while (typeInstance.TryEnumStaticFieldByName2(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeInstance.EndEnumStaticFieldsByName2(handle);
            }
        }

        public static EnumStaticField2Result[] EnumStaticFields2(this XCLRDataTypeInstance typeInstance, CLRDataFieldFlag flags, IXCLRDataTask tlsTask)
        {
            EnumStaticField2Result value;

            var handle = typeInstance.StartEnumStaticFields(flags, tlsTask);

            try
            {
                var list = new List<EnumStaticField2Result>();

                while (typeInstance.TryEnumStaticField2(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeInstance.EndEnumStaticFields(handle);
            }
        }

        public static EnumStaticFieldByName3Result[] EnumStaticFieldsByName3(this XCLRDataTypeInstance typeInstance, string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTask tlsTask)
        {
            EnumStaticFieldByName3Result value;

            var handle = typeInstance.StartEnumStaticFieldsByName2(name, nameFlags, fieldFlags, tlsTask);

            try
            {
                var list = new List<EnumStaticFieldByName3Result>();

                while (typeInstance.TryEnumStaticFieldByName3(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                typeInstance.EndEnumStaticFieldsByName2(handle);
            }
        }
    }
}

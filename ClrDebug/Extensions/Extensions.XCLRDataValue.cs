using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static XCLRDataValue_EnumFieldResult[] EnumFields(this XCLRDataValue value, CLRDataFieldFlag flags, IXCLRDataTypeInstance fromType)
        {
            XCLRDataValue_EnumFieldResult field;

            var handle = value.StartEnumFields(flags, fromType);

            try
            {
                var list = new List<XCLRDataValue_EnumFieldResult>();

                while (value.TryEnumField(ref handle, out field).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(field);

                return list.ToArray();
            }
            finally
            {
                value.EndEnumFields(handle);
            }
        }

        public static XCLRDataValue_EnumFieldByNameResult[] EnumFieldsByName(this XCLRDataValue value, string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTypeInstance fromType)
        {
            XCLRDataValue_EnumFieldByNameResult field;

            var handle = value.StartEnumFieldsByName(name, nameFlags, fieldFlags, fromType);

            try
            {
                var list = new List<XCLRDataValue_EnumFieldByNameResult>();

                while (value.TryEnumFieldByName(ref handle, out field).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(field);

                return list.ToArray();
            }
            finally
            {
                value.EndEnumFieldsByName(handle);
            }
        }

        public static XCLRDataValue_EnumField2Result[] EnumFields2(this XCLRDataValue value, CLRDataFieldFlag flags, IXCLRDataTypeInstance fromType)
        {
            XCLRDataValue_EnumField2Result field;

            var handle = value.StartEnumFields(flags, fromType);

            try
            {
                var list = new List<XCLRDataValue_EnumField2Result>();

                while (value.TryEnumField2(ref handle, out field).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(field);

                return list.ToArray();
            }
            finally
            {
                value.EndEnumFields(handle);
            }
        }

        public static XCLRDataValue_EnumFieldByName2Result[] EnumFieldsByName2(this XCLRDataValue value, string name, CLRDataByNameFlag nameFlags, CLRDataFieldFlag fieldFlags, IXCLRDataTypeInstance fromType)
        {
            XCLRDataValue_EnumFieldByName2Result field;

            var handle = value.StartEnumFieldsByName(name, nameFlags, fieldFlags, fromType);

            try
            {
                var list = new List<XCLRDataValue_EnumFieldByName2Result>();

                while (value.TryEnumFieldByName2(ref handle, out field).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(field);

                return list.ToArray();
            }
            finally
            {
                value.EndEnumFieldsByName(handle);
            }
        }
    }
}

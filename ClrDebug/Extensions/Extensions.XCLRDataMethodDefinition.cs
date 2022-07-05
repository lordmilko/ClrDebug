using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static XCLRDataMethodInstance[] EnumInstances(this XCLRDataMethodDefinition methodDefinition, IXCLRDataAppDomain appDomain)
        {
            XCLRDataMethodInstance value;

            var handle = methodDefinition.StartEnumInstances(appDomain);

            try
            {
                var list = new List<XCLRDataMethodInstance>();

                while (methodDefinition.TryEnumInstance(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                methodDefinition.EndEnumInstances(handle);
            }
        }

        public static CLRDATA_METHDEF_EXTENT[] EnumExtents(this XCLRDataMethodDefinition methodDefinition)
        {
            CLRDATA_METHDEF_EXTENT value;

            var handle = methodDefinition.StartEnumExtents();

            try
            {
                var list = new List<CLRDATA_METHDEF_EXTENT>();

                while (methodDefinition.TryEnumExtent(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                methodDefinition.EndEnumExtents(handle);
            }
        }
    }
}

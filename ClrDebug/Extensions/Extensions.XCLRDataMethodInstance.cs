using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        public static CLRDATA_ADDRESS_RANGE[] EnumExtents(this XCLRDataMethodInstance methodInstance)
        {
            CLRDATA_ADDRESS_RANGE value;

            var handle = methodInstance.StartEnumExtents();

            try
            {
                var list = new List<CLRDATA_ADDRESS_RANGE>();

                while (methodInstance.TryEnumExtent(ref handle, out value).ThrowOnFailed() == HRESULT.S_OK)
                    list.Add(value);

                return list.ToArray();
            }
            finally
            {
                methodInstance.EndEnumExtents(handle);
            }
        }
    }
}

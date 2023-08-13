using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClrDebug.Tests
{
    class MarshalTestMethodAttribute : TestMethodAttribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            yield return new object[] { false };
#if NET8_0_OR_GREATER
            yield return new object[] { true };
#endif
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            var value = (bool)data[0];

            if (value)
                return $"{methodInfo.Name}_NativeAOT";

            return methodInfo.Name;
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ClrDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public abstract partial class CorDebugValue
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
        {
            get
            {
                //Gets the name of the current wrapper type and a list of interfaces
                //that are supported by the underlying COM object

                var builder = new StringBuilder();

                builder.Append("[").Append(GetType().Name);

                builder.Append("] Interfaces = ");

                var types = new List<string>();

                if (Raw is ICorDebugArrayValue)
                    types.Add("Array");

                if (Raw is ICorDebugBoxValue)
                    types.Add("Box");

                if (Raw is ICorDebugComObjectValue)
                    types.Add("ComObject");

                if (Raw is ICorDebugContext)
                    types.Add("Context");

                if (Raw is ICorDebugDelegateObjectValue)
                    types.Add("DelegateObject");

                if (Raw is ICorDebugExceptionObjectValue)
                    types.Add("Exception");

                if (Raw is ICorDebugGenericValue)
                    types.Add("Generic");

                if (Raw is ICorDebugHandleValue)
                    types.Add("Handle");

                if (Raw is ICorDebugHeapValue)
                    types.Add("Heap");

                if (Raw is ICorDebugHeapValue2)
                    types.Add("Heap2");

                if (Raw is ICorDebugHeapValue3)
                    types.Add("Heap3");

                if (Raw is ICorDebugObjectValue)
                    types.Add("Object");

                if (Raw is ICorDebugObjectValue2)
                    types.Add("Object2");

                if (Raw is ICorDebugReferenceValue)
                    types.Add("Reference");

                if (Raw is ICorDebugStringValue)
                    types.Add("String");

                if (Raw is ICorDebugValue2)
                    types.Add("Value2");

                if (Raw is ICorDebugValue3)
                    types.Add("Value3");

                builder.Append(string.Join(", ", types));

                builder.Append(")");

                return builder.ToString();
            }
        }
    }
}

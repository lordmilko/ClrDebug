using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClrDebug.Tests
{
    [TestClass]
    public unsafe class NumberTests
    {
        private static Type[] AddressTypes = {
            typeof(CORDB_ADDRESS),
            typeof(CORDB_REGISTER),
            typeof(CLRDATA_ADDRESS)
        };

        private static Type[] ProfilerTypes = {
            typeof(ProcessID),
            typeof(AssemblyID),
            typeof(AppDomainID),
            typeof(ModuleID),
            typeof(ClassID),
            typeof(ThreadID),
            typeof(ContextID),
            typeof(FunctionID),
            typeof(ObjectID),
            typeof(GCHandleID),
            typeof(COR_PRF_ELT_INFO),
            typeof(COR_PRF_FRAME_INFO),
            typeof(ReJITID),
            typeof(EVENTPIPE_PROVIDER)
        };

        private static Type[] IntPtrTypes => AddressTypes.Union(ProfilerTypes).ToArray();

        [TestMethod]
        public void Number_Address_AsIntPtr()
        {
            ulong value = 0x81A1D000;

            foreach (var type in IntPtrTypes)
            {
                var result = As<IntPtr>(value, type);

                Assert.AreEqual(value, (ulong) (void*) result);
            }
        }

        [TestMethod]
        public void Number_MathOps()
        {
            var ops = new (ExpressionType op, string expected)[]
            {
                (ExpressionType.Add, "0x81A1D003"),
                (ExpressionType.Subtract, "0x81A1CFFF"),
                (ExpressionType.And, "0x0"),
                (ExpressionType.Or, "0x81A1D003"),
                (ExpressionType.Multiply, "0x10343A002"),
                (ExpressionType.Divide, "0x40D0E800"),
                (ExpressionType.Modulo, "0x1")
            };

            ulong value = 0x81A1D001;

            var custom = new (Type type, ExpressionType op, string expected)[]
            {
                (typeof(CLRDATA_ADDRESS), ExpressionType.Multiply, "0x343A002")
            };

            foreach (var type in AddressTypes)
            {
                foreach (var item in ops)
                {
                    var result = TestOp(value, type, item.op);

                    var expected = item.expected;

                    var customExpected = custom.SingleOrDefault(c => c.type == type && c.op == item.op);

                    if (customExpected != default)
                        expected = customExpected.expected;

                    Assert.AreEqual(expected, result, $"Result of {item} on type {type} was not correct");
                }
            }
        }

        [TestMethod]
        public void Number_BoolOps()
        {
            var ops = new (ExpressionType op, string expected, Type[] toCheck)[]
            {
                (ExpressionType.GreaterThan, "True", AddressTypes),
                (ExpressionType.LessThan, "False", AddressTypes),
                (ExpressionType.Equal, "False", IntPtrTypes),
                (ExpressionType.NotEqual, "True", IntPtrTypes),
                (ExpressionType.GreaterThanOrEqual, "True", AddressTypes),
                (ExpressionType.LessThanOrEqual, "False", AddressTypes),
            };

            ulong value = 0x81A1D000;

            foreach (var item in ops)
            {
                foreach(var type in item.toCheck)
                {
                    var result = TestOp(value, type, item.op);

                    Assert.AreEqual(item.expected, result, $"Result of {item} on type {type} was not correct");
                }
            }
        }

        private T As<T>(ulong value, Type type)
        {
            var parameter = Expression.Parameter(typeof(ulong));

            //Expressions like Convert and MakeBinary will automatically reflect our user defined implicit conversion/custom operators
            var converted = Expression.Convert(
                Expression.Convert(parameter, type),
                typeof(T)
            );

            var lambda = Expression.Lambda(converted, parameter);

            var method = lambda.Compile();

            var result = (T) method.DynamicInvoke(value);

            return result;
        }

        private string TestOp(ulong value, Type type, ExpressionType op)
        {
            var parameter = Expression.Parameter(typeof(ulong));

            var lhs = Expression.Convert(parameter, type);
            var rhs = Expression.Convert(Expression.Constant(2), type);

            var binary = Expression.MakeBinary(op, lhs, rhs);

            var lambda = Expression.Lambda(binary, parameter);

            var method = lambda.Compile();

            var result = method.DynamicInvoke(value);

            return result.ToString();
        }
    }
}

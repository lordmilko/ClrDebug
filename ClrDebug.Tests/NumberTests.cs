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
        public void Number_MathOps_x86()
        {
            var ops = new (ExpressionType op, string normalExpected, string complementExpected)[]
            {
                (ExpressionType.Add, "0x81A1D003", "0x81A1CFFE"),
                (ExpressionType.Subtract, "0x81A1CFFF", "0x81A1D004"),
                (ExpressionType.And, "0x0", "0x81A1D001"),
                (ExpressionType.Or, "0x81A1D003", "0xFFFFFFFFFFFFFFFD"),
                (ExpressionType.Multiply, "0x10343A002", "0xFFFFFFFE7B1A8FFD"),
                (ExpressionType.Divide, "0x40D0E800", "0xFFFFFFFFD4CA1000"),
                (ExpressionType.Modulo, "0x1", "0x1")
            };

            ulong value = 0x81A1D001;

            //Custom comparisons just for CLRDATA_ADDRESS
            var custom = new (Type type, ExpressionType op, string normalExpected, string complementExpected)[]
            {
                (typeof(CLRDATA_ADDRESS), ExpressionType.Or,       "0x81A1D003",                                    IntPtr.Size == 4 ? "0xFFFFFFFD" : "0xFFFFFFFFFFFFFFFD"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.Multiply, IntPtr.Size == 4 ? "0x343A002" : "0x10343A002",  IntPtr.Size == 4 ? "0x7B1A8FFD" : "0xFFFFFFFE7B1A8FFD"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.Divide,   "0x40D0E800",                                    IntPtr.Size == 4 ? "0xD4CA1000" : "0xFFFFFFFFD4CA1000")
            };

            TestMath(value, ops, custom);
        }

        [TestMethod]
        public void Number_MathOps_x64()
        {
            var ops = new (ExpressionType op, string normalExpected, string complementExpected)[]
            {
                (ExpressionType.Add, "0x7FFAD43DE632", "0x7FFAD43DE62D"),
                (ExpressionType.Subtract, "0x7FFAD43DE62E", "0x7FFAD43DE633"),
                (ExpressionType.And, "0x0", "0x7FFAD43DE630"),
                (ExpressionType.Or, "0x7FFAD43DE632", "0xFFFFFFFFFFFFFFFD"),
                (ExpressionType.Multiply, "0xFFF5A87BCC60", "0xFFFE800F83464D70"),
                (ExpressionType.Divide, "0x3FFD6A1EF318", "0xFFFFD5570E96089B"),
                (ExpressionType.Modulo, "0x0", "0x1")
            };

            ulong value = 0x7FFAD43DE630;

            //Custom comparisons just for CLRDATA_ADDRESS
            var custom = new (Type type, ExpressionType op, string normalExpected, string complementExpected)[]
            {
                (typeof(CLRDATA_ADDRESS), ExpressionType.Add,      IntPtr.Size == 4 ? "0xD43DE632" : "0x7FFAD43DE632", IntPtr.Size == 4 ? "0xD43DE62D" : "0x7FFAD43DE62D"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.Subtract, IntPtr.Size == 4 ? "0xD43DE62E" : "0x7FFAD43DE62E", IntPtr.Size == 4 ? "0xD43DE633" : "0x7FFAD43DE633"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.And,      "0x0",                                              IntPtr.Size == 4 ? "0xD43DE630" : "0x7FFAD43DE630"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.Or,       IntPtr.Size == 4 ? "0xD43DE632" : "0x7FFAD43DE632", IntPtr.Size == 4 ? "0xFFFFFFFD" : "0xFFFFFFFFFFFFFFFD"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.Multiply, IntPtr.Size == 4 ? "0xA87BCC60" : "0xFFF5A87BCC60", IntPtr.Size == 4 ? "0x83464D70" : "0xFFFE800F83464D70"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.Divide,   IntPtr.Size == 4 ? "0x6A1EF318" : "0x3FFD6A1EF318", IntPtr.Size == 4 ? "0xB940B346" : "0xFFFFD5570E96089B"),
                (typeof(CLRDATA_ADDRESS), ExpressionType.Modulo,   "0x0",                                              IntPtr.Size == 4 ? "0x2" : "0x1")
            };

            TestMath(value, ops, custom);
        }

        private void TestMath(
            ulong value,
            (ExpressionType op, string normalExpected, string complementExpected)[] ops,
            (Type type, ExpressionType op, string normalExpected, string complementExpected)[] custom)
        {
            foreach (var type in AddressTypes)
            {
                foreach (var item in ops)
                {
                    foreach (var complement in new[] { false, true })
                    {
                        var result = TestOp(value, type, item.op, complement);

                        var expected = complement ? item.complementExpected : item.normalExpected;

                        var customExpected = custom.SingleOrDefault(c => c.type == type && c.op == item.op);

                        if (customExpected != default)
                            expected = complement ? customExpected.complementExpected : customExpected.normalExpected;

                        Assert.AreEqual(expected, result, $"{Environment.NewLine}{Environment.NewLine}Result of {item} on type {type} was not correct (Complement: {complement})");
                    }
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
                    var result = TestOp(value, type, item.op, false);

                    Assert.AreEqual(item.expected, result, $"Result of {item} on type {type} was not correct");
                }
            }
        }

        [TestMethod]
        public void Number_CompareTo_UInt64()
        {
            //For each type, compare to itself, an invalid type, an int, a uint, a long and a ulong

            CORDB_ADDRESS source = 1;

            var values = new object[]
            {
                (CORDB_ADDRESS) 2,
                (int) 2,
                (uint) 2,
                (long) 2,
                (ulong) 2,
            };

            foreach (var value in values)
                Assert.AreEqual(-1, source.CompareTo(value));
        }

        [TestMethod]
        public void Number_CompareTo_UInt32()
        {
            //For each type, compare to itself, an invalid type, an int, a uint, a long and a ulong

            mdToken source = 1;

            var values = new object[]
            {
                (mdToken) 2,
                (int) 2,
                (uint) 2,
            };

            foreach (var value in values)
                Assert.AreEqual(-1, source.CompareTo(value));
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

        private string TestOp(ulong value, Type type, ExpressionType op, bool complement)
        {
            var parameter = Expression.Parameter(typeof(ulong));

            Expression rhsValue = Expression.Constant(2);

            if (complement)
                rhsValue = Expression.OnesComplement(rhsValue);

            var lhs = Expression.Convert(parameter, type);
            var rhs = rhsValue;

            var binary = Expression.MakeBinary(op, lhs, rhs);

            var lambda = Expression.Lambda(binary, parameter);

            var method = lambda.Compile();

            var result = method.DynamicInvoke(value);

            return result.ToString();
        }
    }
}

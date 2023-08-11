﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ClrDebug.Extensions;

namespace ClrDebug.Tests
{
    public delegate HRESULT DllGetClassObject(
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
        [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
        [Out] out IntPtr ppv);

    [TestClass]
    public class MarshalTests
    {
        private static IVariantTest test;

        private static Guid CLSID_Test = new Guid("326A6F4B-040F-4248-B0CD-95C80764784A");
        private static Guid IID_Test = new Guid("BB5760D0-1345-494E-A92D-D36E753693A3");

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var dll = typeof(MarshalTests).Assembly.Location;
            var dir = Path.GetDirectoryName(dll);

            var solution = Path.GetFullPath(Path.Combine(dir, "..", "..", "..", ".."));

#if DEBUG
            var configuration = "Debug";
#else
            var configuration = "Release";
#endif

            var lib = Path.Combine(
                solution,
                "TestLib",
                "bin",
                configuration,
                IntPtr.Size == 4 ? "x86" : "x64",
                IntPtr.Size == 4 ? "TestLib.x86.dll" : "TestLib.x64.dll"
            );

            if (!File.Exists(lib))
                throw new FileNotFoundException($"Could not find '{lib}'", lib);

            var hLib = NativeMethods.LoadLibrary(lib);

            if (hLib == IntPtr.Zero)
                throw new InvalidOperationException("Failed to load TestLib: " + (HRESULT) Marshal.GetHRForLastWin32Error() + ". Please build TestLib.sln");

            var proc = NativeMethods.GetProcAddress(hLib, "DllGetClassObject");

            if (proc == IntPtr.Zero)
                throw new InvalidOperationException("Failed to find DllGetClassObject: " + (HRESULT)Marshal.GetHRForLastWin32Error());

            var dllGetClassObject = Marshal.GetDelegateForFunctionPointer<DllGetClassObject>(proc);

            dllGetClassObject(CLSID_Test, typeof(IClassFactory).GUID, out var ppv).ThrowOnNotOK();

            var pClassFactory = GetObjectForIUnknown<IClassFactory>(ppv);

            pClassFactory.CreateInstance(null, IID_Test, out var ppvObject).ThrowOnNotOK();

            //If we let ComWrappers marshal the interface, when we test marshalling variants containing interfaces, we'll be using OUR ComWrappers instance
            //to resolve the interface, hence we won't use the same cache. Thus, we must use a custom equality comparer whenever comparing against System.Runtime.InteropServices.Marshalling.ComObject instances
            test = (IVariantTest) ppvObject;
        }

        #region Get Variant

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_Empty() => TestGet<object>(test.GetEmpty(), null);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_Null() => TestGet<DBNull>(test.GetNull(), DBNull.Value);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_U1() => TestGet<byte>(test.GetU1(), (byte)8);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_U2() => TestGet<ushort>(test.GetU2(), (ushort)32000);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_U4() => TestGet<uint>(test.GetU4(), (uint)123456789);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_U8() => TestGet<ulong>(test.GetU8(), (ulong)1234567812345678);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_I1() => TestGet<sbyte>(test.GetI1(), (sbyte)-8);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_I2() => TestGet<short>(test.GetI2(), (short)-32000);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_I4() => TestGet<int>(test.GetI4(), -123456789);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_I8() => TestGet<long>(test.GetI8(), (long) -1234567812345678);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_BStr() => TestGet<string>(test.GetBStr(), "hello");

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_Bool() => TestGet<bool>(test.GetBool(), true);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_Unknown()
        {
            var actual = (IVariantTest) test.GetUnknown();

#if GENERATED_MARSHALLING
            //The objects are reference equal if we used ClrDebug's cached StrategyBasedComWrappers instance. If we use
            //StrategyBasedComWrappers.Instance (which source generated COM will use), we'll have a different cache and won't
            //be able to tell the object is the same
            Assert.IsTrue(ComWrappersInterfaceEqualityComparer<IVariantTest>.Instance.Equals(test, actual));
#else
            Assert.AreEqual(test, actual);
#endif
        }

        //Void cashes the CLR to crash
        //[TestMethod]
        //public void Marshal_Variant_FromUnmanaged_Void() => Test<object>(test.GetVoid(), (byte)8);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_Float() => TestGet<float>(test.GetFloat(), 1.2f);

        [TestMethod]
        public void Marshal_Variant_FromUnmanaged_Double() => TestGet<double>(test.GetDouble(), 1.23456789);

#endregion
        #region Set Variant

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_Empty() => TestSet(test.SetEmpty(null));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_Null() => TestSet(test.SetNull(DBNull.Value));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_U1() => TestSet(test.SetU1((byte)8));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_U2() => TestSet(test.SetU2((ushort)32000));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_U4() => TestSet(test.SetU4((uint)123456789));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_U8() => TestSet(test.SetU8((ulong)1234567812345678));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_I1() => TestSet(test.SetI1((sbyte)-8));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_I2() => TestSet(test.SetI2((short)-32000));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_I4() => TestSet(test.SetI4(-123456789));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_I8() => TestSet(test.SetI8((long)-1234567812345678));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_BStr() => TestSet(test.SetBStr("hello"));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_Bool() => TestSet(test.SetBool(true));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_Unknown() => TestSet(test.SetUnknown(test));

        //Void cashes the CLR to crash
        //[TestMethod]
        //public void Marshal_Variant_ToUnmanaged_Void() => Test<object>(test.SetVoid((byte))8);

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_Float() => TestSet(test.SetFloat(1.2f));

        [TestMethod]
        public void Marshal_Variant_ToUnmanaged_Double() => TestSet(test.SetDouble(1.23456789));

        #endregion

        private void TestGet<T>(object actual, object expected)
        {
            if (expected == null)
                Assert.IsNull(actual);
            else
            {
                Assert.AreEqual(typeof(T), actual.GetType());

                Assert.AreEqual(expected, actual);
            }
        }

        private void TestSet(HRESULT hr) => hr.ThrowOnFailed();
    }
}

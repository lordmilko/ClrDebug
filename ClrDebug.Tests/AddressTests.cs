using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClrDebug.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void CORDB_ADDRESS_FromSmallInt()
        {
            CORDB_ADDRESS value = 8;

            ulong expected = 0x0000000000000008;

            Assert.AreEqual(expected, value.Value);
        }

        [TestMethod]
        public void CORDB_ADDRESS_FromSmallUInt()
        {
            uint v = 8;
            CORDB_ADDRESS value = (ulong) v;

            ulong expected = 0x0000000000000008;

            Assert.AreEqual(expected, value.Value);
        }

        [TestMethod]
        public void CORDB_ADDRESS_FromIntMax()
        {
            int intMax = -1;

            CORDB_ADDRESS value = intMax;

            Assert.AreEqual(0xFFFFFFFFFFFFFFFF, value.Value);
        }

        [TestMethod]
        public void CORDB_ADDRESS_FromUIntMax()
        {
            uint uintMax = unchecked((uint) -1);

            CORDB_ADDRESS value = (ulong) uintMax;

            Assert.AreEqual(0x00000000ffffffff, value.Value);
        }

        [TestMethod]
        public void CORDB_ADDRESS_FromUIntMaxPlusOne()
        {
            uint uintMax = unchecked((uint)-1);

            CORDB_ADDRESS value = ((ulong)uintMax) + 1;
            CLRDATA_ADDRESS address = value;

            var next = address + 1;

            ulong expected = 0x0000000100000000;

            if (IntPtr.Size == 4)
                Assert.AreEqual((ulong) 0, address.Value);
            else
                Assert.AreEqual(value.Value, address.Value);

            Assert.AreEqual(expected, value.Value);
        }
    }
}

using System;
using ClrDebug.DbgEng;
using ClrDebug.DIA;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClrDebug.Tests.DbgEng
{
    [TestClass]
    public class DebugAdvancedRequestTests
    {
        private static Debugger debugger;

        public static DebugClient client => debugger.Client;

        public static DbgEngExtensions.DebugAdvancedRequests Requests => client.Advanced.Request();

        public static DbgEngExtensions.DebugAdvancedExtTypedDataAnsiRequests Ext => Requests.ExtTypedDataAnsi();

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            debugger = new Debugger();

            debugger.Run();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            debugger.Client.Control.Execute(DEBUG_OUTCTL.ALL_CLIENTS, "q", DEBUG_EXECUTE.DEFAULT);
        }

        [TestMethod]
        public void DebugAdvanced_Request_GetWin32MajorMinorVersions()
        {
            var version = Requests.GetWin32MajorMinorVersions();

            //This returns 6.2 in our DbgEngConsole sample and 10.0 here. This value comes from a property of the g_Target, but thats all i know

            Assert.AreEqual(new Version(10, 0), version);
        }

        [TestMethod]
        [TestCategory(TestCategory.SkipCI)] //Appveyor loads the PDB but we still get an EVENT_E_INTERNALEXCEPTION
        public void DebugAdvanced_Request_ExtTDOP_SetFromExpr()
        {
            debugger.EnsurePDB("C:\\Windows\\system32\\ntdll.dll");

            var result = Requests.ExtTypedDataAnsi().SetFromExpr("(ntdll!_PEB*)@$peb");

            Assert.AreEqual(SymTagEnum.PointerType, result.Tag);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using ClrDebug.PDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClrDebug.Tests
{
    [TestClass]
    public class PdbTests
    {
        [TestMethod]
        public void Pdb_AllMethods_ThisCall()
        {
            //All PDB1 method delegates (including related interfaces like DBI1, TPI1 and Mod1) must be declared as thiscall, as "this" is passed in ecx in x86

            var pdbTypes = typeof(PDB1).Assembly
                .GetTypes()
                .Where(t => t.IsClass && t.Namespace == typeof(PDB1).Namespace && t.DeclaringType == null)
                .ToArray();

            var bad = new List<string>();

            foreach (var pdbType in pdbTypes)
            {
                var delegates = pdbType.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic);

                foreach (var @delegate in delegates)
                {
                    if (@delegate == typeof(GSI1.MiniPDBNHBuildStatusCallback))
                        continue;

                    var callingConvention = @delegate.GetCustomAttribute<UnmanagedFunctionPointerAttribute>();

                    if (callingConvention == null || callingConvention.CallingConvention != CallingConvention.ThisCall)
                        bad.Add(@delegate.FullName);

                    var parameters = @delegate.GetMethod("Invoke").GetParameters();

                    if (parameters.Length == 0 || parameters[0].Name != "this")
                        Assert.Fail($"{@delegate.FullName} does not have a 'this' parameter");
                }
            }

            if (bad.Count > 0)
                Assert.Fail($"{bad.Count} PDB1 delegate(s) are not declared as thiscall. thiscall is required on x86 as 'this' must be passed in ecx" + Environment.NewLine + Environment.NewLine + string.Join(Environment.NewLine, bad));
        }
    }
}

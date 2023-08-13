using ClrDebug.TypeLib;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static ClrDebug.Tests.MarshalTestImpl;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No args specified");
                Environment.Exit(1);
            }

            var result = Test(args[0]);

            if (!result)
                Environment.Exit(1);
        }

        private static bool Test(string name)
        {
            Console.WriteLine("Executing " + name);

            switch (name)
            {
                case "wait":
                    Thread.Sleep(3000);
                    return true;

                case nameof(Marshal_Delegate_Call):
                    return Marshal_Delegate_Call(Process.Start(GetDebugTargetPath(), "wait"), GetDACModule());

                case nameof(Marshal_Delegate_Call_WithOutInterface):
                    return Marshal_Delegate_Call_WithOutInterface();

                case nameof(Marshal_Delegate_Call_WithInInterface):
                    return Marshal_Delegate_Call_WithInInterface(GetDebugTargetPath(), GetDbgShimPath());

                case nameof(Marshal_MetaDataDispenser_Call):
                    return Marshal_MetaDataDispenser_Call(GetDebugTargetPath(), GetCLRModule());

                default:
                    throw new NotImplementedException();
            }
        }

        [UnconditionalSuppressMessage("SingleFile", "IL3000:Avoid accessing Assembly file path when publishing as a single file", Justification = "<Pending>")]
        private static string GetDebugTargetPath()
        {
            var assemblyLocation = typeof(Program).Assembly.Location;

            if (assemblyLocation == string.Empty)
            {
                //We're NativeAOT

                var appPath = AppContext.BaseDirectory;
                var parentDir = Path.GetDirectoryName(appPath.TrimEnd(Path.DirectorySeparatorChar));
                var managed = Path.Combine(parentDir!, "TestApp.exe");

                if (!File.Exists(managed))
                    throw new FileNotFoundException($"Could not find '{managed}'", managed);

                Console.WriteLine($"Using managed assembly '{managed}'");
                return managed;
            }
            else
                return Path.ChangeExtension(assemblyLocation, "exe"); //We're given TestApp.dll, but we want TestApp.exe
        }

        private static string GetDbgShimPath() => GetManagedBuildFile("dbgshim.dll");
        private static IntPtr? GetCLRModule() => NativeLibrary.Load(GetManagedBuildFile("coreclr.dll"));
        private static IntPtr? GetDACModule() => NativeLibrary.Load(GetManagedBuildFile("mscordaccore.dll"));

        [UnconditionalSuppressMessage("SingleFile", "IL3000:Avoid accessing Assembly file path when publishing as a single file", Justification = "<Pending>")]
        private static string GetManagedBuildFile(string name)
        {
            var assemblyLocation = typeof(Program).Assembly.Location;

            if (assemblyLocation == string.Empty)
            {
                //We're NativeAOT

                var appPath = AppContext.BaseDirectory;
                var parentDir = Path.GetDirectoryName(appPath.TrimEnd(Path.DirectorySeparatorChar));

                var libPath = Path.Combine(parentDir, name);

                if (!File.Exists(libPath))
                    throw new FileNotFoundException($"Could not find '{libPath}'", libPath);

                return libPath;
            }

            //Use the default resolver
            return null;
        }
    }
}

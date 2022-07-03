using System;
using SymStore;

namespace NativeSymbols
{
    /// <summary>
    /// Provides facilities for logging symbol download operations.
    /// </summary>
    internal class Tracer : ITracer
    {
        public void WriteLine(string message)
        {
            throw new System.NotImplementedException();
        }

        public void WriteLine(string format, params object[] arguments)
        {
            throw new System.NotImplementedException();
        }

        public void Information(string message)
        {
            throw new System.NotImplementedException();
        }

        public void Information(string format, params object[] arguments)
        {
            throw new System.NotImplementedException();
        }

        public void Warning(string message)
        {
            throw new System.NotImplementedException();
        }

        public void Warning(string format, params object[] arguments)
        {
            throw new System.NotImplementedException();
        }

        public void Error(string message)
        {
            throw new System.NotImplementedException();
        }

        public void Error(string format, params object[] arguments)
        {
            Console.WriteLine("Error: " + string.Format(format, arguments));
        }

        public void Verbose(string message)
        {
            throw new System.NotImplementedException();
        }

        public void Verbose(string format, params object[] arguments)
        {
            Console.WriteLine(format, arguments);
        }
    }
}

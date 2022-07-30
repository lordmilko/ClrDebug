using System;
using SymStore;

namespace ClrDebug.Tests
{
    internal class Tracer : ITracer
    {
        public void WriteLine(string message)
        {
        }

        public void WriteLine(string format, params object[] arguments)
        {
        }

        public void Information(string message)
        {
        }

        public void Information(string format, params object[] arguments)
        {
        }

        public void Warning(string message)
        {
        }

        public void Warning(string format, params object[] arguments)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(string format, params object[] arguments)
        {
        }

        public void Verbose(string message)
        {
        }

        public void Verbose(string format, params object[] arguments)
        {
        }
    }
}

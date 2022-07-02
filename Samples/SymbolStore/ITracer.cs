namespace SymStore
{
    /// <summary>
    /// A simple trace/logging interface.
    /// </summary>
    public interface ITracer
    {
        void WriteLine(string message);

        void WriteLine(string format, params object[] arguments);

        void Information(string message);

        void Information(string format, params object[] arguments);

        void Warning(string message);

        void Warning(string format, params object[] arguments);

        void Error(string message);

        void Error(string format, params object[] arguments);

        void Verbose(string message);

        void Verbose(string format, params object[] arguments);
    }
}
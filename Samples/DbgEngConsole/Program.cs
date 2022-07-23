namespace DbgEngConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Our debugger class encapsulates the entire logic of loading DbgEng, creating a DebugClient,
            //launching a process and running the main engine loop

            var debugger = new Debugger();

            debugger.Run();
        }
    }
}

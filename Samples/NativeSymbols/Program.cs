using System;

namespace NativeSymbols
{
    class Program
    {
        //This sample demonstrates how symbols can be retrieved from either your local symbol server, or Microsoft's public symbol server,
        //and then used to retrieve a symbol from a native DLL
        static void Main(string[] args)
        {
            Console.Title = "NativeSymbols";

            /* DbgHelp's SymInitialize() wants you to specify some kind of unique identifier for all the symbols you're resolving;
             * this could be the handle of an actual process, or whatever - as long as its unique for each "target" that may contain symbols.
             * For the purposes of this sample, we simply use an identifier of "1". In a real debugger, it's often a good idea to use the handle
             * of the process you're debugging */
            var symbolManager = new SymbolManager(new IntPtr(1));

            while (true)
            {
                Console.WriteLine("Enter a symbol expression (e.g. kernel32, notepad!*, etc) [-a | -t]:");
                Console.Write("> ");

                var command = Console.ReadLine();

                if (command == "q")
                    return;

                var dll = command.Trim('\"');

                try
                {
                    //Demonstrate getting all symbols that match a specified expression
                    var symbols = symbolManager.GetSymbols(dll);

                    foreach (var symbol in symbols)
                        Console.WriteLine($"{symbol} ({symbol.Tag})");

                    if (symbols.Length > 0)
                    {
                        //Demonstrate various other things you can retrieve from DbgHelp. Not all symbol kinds (UDTs, Data fields, etc) may support all operations

                        try
                        {
                            //Demonstrate getting a symbol name from an address
                            var addressSymbol = symbolManager.GetSymbol(symbols[0].Address);

                            //Demonstrate getting the information about a module from an address within it
                            var moduleInfo = symbolManager.GetModule(symbols[0].Address);

                            //Demonstrate getting the base address of a module from an address within it
                            var moduleBase = symbolManager.GetModuleBase(symbols[0].Address);
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }

                Console.WriteLine();
            }
        }
    }
}

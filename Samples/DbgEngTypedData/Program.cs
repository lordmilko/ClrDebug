namespace DbgEngTypedData
{
    class Program
    {
        //This sample demonstrates how you can retrieve typed data using IDebugSymbols.
        //This is similar to IDebugAdvanced's EXT_TYPED_DATA API seen when developing EngExtCpp extensions,
        //however IDebugSymbols provides access to the underlying API that EXT_TYPED_DATA is built on top of.
        static void Main(string[] args)
        {
            //Spin up a debugger/process for demonstrating the sample.
            //All the action in this sample occurs in the TypedDataDebugger.InputLoop() method

            var debugger = new TypedDataDebugger();

            debugger.Run();
        }
    }
}

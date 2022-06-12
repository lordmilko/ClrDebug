namespace ManagedCorDebug
{
    public struct GetPEKindResult
    {
        public CorPEKind PdwPEKind { get; }

        public int PdwMachine { get; }

        public GetPEKindResult(CorPEKind pdwPEKind, int pdwMachine)
        {
            PdwPEKind = pdwPEKind;
            PdwMachine = pdwMachine;
        }
    }
}
namespace ManagedCorDebug
{
    public struct GetPEKindResult
    {
        public CorPEKind PdwPEKind { get; }

        public uint PdwMachine { get; }

        public GetPEKindResult(CorPEKind pdwPEKind, uint pdwMachine)
        {
            PdwPEKind = pdwPEKind;
            PdwMachine = pdwMachine;
        }
    }
}